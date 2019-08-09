#version 330 core
in vec3 Normal;
in vec3 FragPos;
in vec2 TexCoords;

out vec4 FragColor;

struct Material{
	sampler2D diffuse;
	sampler2D specular;
	// sampler2D emission;
	float shininess;
};

struct Light{
	vec3 position;
	vec3 direction;
	float cutOff;
	float outerCutOff;

	vec3 ambient;
	vec3 diffuse;
	vec3 specular;

	float constant;
	float linear;
	float quadratic;
};

uniform Material material;
uniform Light light;
uniform vec3 viewPos;

void main()
{
	vec3 lightDir = normalize(light.position - FragPos);
	float theta = dot(lightDir, normalize(-light.direction));

	if(theta > light.cutOff){
		// ambient
		vec3 ambient = light.ambient * texture(material.diffuse, TexCoords).rgb;

		// diffuse
		vec3 norm = normalize(Normal);
		float diff = max(dot(norm, lightDir), 0.0);
		vec3 diffuse = light.diffuse * diff * texture(material.diffuse, TexCoords).rgb;

		// specular
		vec3 viewDir = normalize(viewPos - FragPos);
		vec3 reflectDir = reflect(-lightDir, norm);
		float spec = pow(max(dot(viewDir, reflectDir), 0.0), material.shininess);
		vec3 specular = light.specular * spec * texture(material.specular, TexCoords).rgb;

		// attenuation
		float distance = length(light.position - FragPos);
		float attenuation = 1.0 / (light.constant + light.linear * distance +light.quadratic * (distance * distance));

		diffuse *= attenuation;
		specular *= attenuation;
		
		vec3 result = ambient + diffuse + specular;
		FragColor = vec4(result, 1.0);
	}else{
		FragColor = vec4(light.ambient * texture(material.diffuse, TexCoords).rgb, 1.0);
	}
}