cmake_minimum_required(VERSION 3.10)

# Set the project name
project(HelloTriangle)

# Specify the C++ standard
set(CMAKE_CXX_STANDARD 17)
set(CMAKE_CXX_STANDARD_REQUIRED True)

# Find OpenGL and GLFW
find_package(OpenGL REQUIRED)
find_package(glfw3 REQUIRED)

# Include directories
include_directories(${OPENGL_INCLUDE_DIRS} ${GLFW_INCLUDE_DIRS})

# Include GLAD
add_library(glad ../dependencies/GLAD/src/glad.c)
include_directories(../dependencies/GLAD/include)

# Source files
set(SOURCES
    src/hello_triangle_indexed.cpp
)

# Create the executable
add_executable(HelloTriangle ${SOURCES})

# Link libraries
target_link_libraries(HelloTriangle glad ${OPENGL_LIBRARIES} glfw dl)