## 关注点
main.cpp
glDebugger.h
glDebugger.cpp

## 注意
包含glad的头文件一定要在包含glfw的头文件之前使用。因为glad的头文件包含了正确的openGL头文件（例如GL/gl.h）,所以需要在需要依赖于openGL的头文件之前使用glad.