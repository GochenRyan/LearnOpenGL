#version 420 core
out vec4 FragColor;
// layout(depth_greater) out float gl_FragDepth;
// layout(depth_less) out float gl_FragDepth;
// layout(depth_any) out float gl_FragDepth;
layout(depth_unchanged) out float gl_FragDepth;

void main()
{
	FragColor = vec4(1.0);
	gl_FragDepth = gl_FragCoord.z + 0.1;
}