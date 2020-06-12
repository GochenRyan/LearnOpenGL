#pragma once
#include <glad/glad.h>
#include <GLFW/glfw3.h>
extern GLenum glCheckError_(const char* file, int line);
#define glCheckError() glCheckError_(__FILE__,  __LINE__)

//extern void APIENTRY glDebugOutput(GLenum source, GLenum type, GLuint id, GLenum severity,
//    GLsizei length, const GLchar* message, const void* userParam);