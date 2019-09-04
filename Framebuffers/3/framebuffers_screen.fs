#version 330 core
out vec4 FragColor;

in vec2 TexCoords;

uniform sampler2D screenTexture;

void main()
{
	vec3 col = texture(screenTexture, TexCoords).rgb;
	float average = (col.r + col.g + col.b) / 3.0;
	FragColor = vec4(average, average, average, 1.0);
}