#version 330 core
layout (location = 0) in vec2 aPos;

out VS_OUT {
	vec4 gl_Position;
} vs_out;

void main()
{
	gl_Position = vec4(aPos.x, aPos.y, 0.0, 1.0);
	vs_out.gl_Position = gl_Position;
}