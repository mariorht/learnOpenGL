cmake_minimum_required(VERSION 3.10)

# Set the project name
project(Textures)

# Specify the C++ standard
set(CMAKE_CXX_STANDARD 17)
set(CMAKE_CXX_STANDARD_REQUIRED True)

# Find OpenGL and GLFW
find_package(OpenGL REQUIRED)
find_package(glfw3 REQUIRED)

# Include directories
include_directories(${OPENGL_INCLUDE_DIRS} ${GLFW_INCLUDE_DIRS})

# Include GLAD only if it hasn't been included already
if(NOT TARGET glad)
    add_library(glad ../dependencies/GLAD/src/glad.c)
endif()
include_directories(../dependencies/GLAD/include)


# Source files
set(SOURCES
    src/textures.cpp
    src/shader_s.h
    src/stb_image.h
)

# Create the executable
add_executable(Textures ${SOURCES})

# Link libraries
target_link_libraries(Textures glad ${OPENGL_LIBRARIES} glfw dl)

# Define the path to the shaders
target_compile_definitions(Textures PRIVATE SHADER_PATH=\"${CMAKE_SOURCE_DIR}/textures/src\")
target_compile_definitions(Textures PRIVATE TEXTURES_PATH=\"${CMAKE_SOURCE_DIR}/textures/src\")


# Set build types
set(CMAKE_CXX_FLAGS_DEBUG "-g")
set(CMAKE_CXX_FLAGS_RELEASE "-O3")

# Set the default build type to Release if not specified
if(NOT CMAKE_BUILD_TYPE)
  set(CMAKE_BUILD_TYPE Release)
endif()