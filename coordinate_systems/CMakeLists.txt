cmake_minimum_required(VERSION 3.10)

cmake_policy(SET CMP0072 NEW)
set(OpenGL_GL_PREFERENCE GLVND)
find_package(OpenGL REQUIRED)


# Set the project name
project(coordinate_systems)

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

# Include glm
find_package(glm REQUIRED)
include_directories(${GLM_INCLUDE_DIRS})


# Source files
set(SOURCES
    ${CMAKE_SOURCE_DIR}/coordinate_systems/src/coordinate_systems.cpp
)

# Create the executable
add_executable(coordinate_systems ${SOURCES})

# Link libraries
target_link_libraries(coordinate_systems glad ${OPENGL_LIBRARIES} glfw dl)

# Define the path to the shaders
target_compile_definitions(coordinate_systems PRIVATE SHADER_PATH=\"${CMAKE_SOURCE_DIR}/coordinate_systems/src\")
target_compile_definitions(coordinate_systems PRIVATE TEXTURES_PATH=\"${CMAKE_SOURCE_DIR}/coordinate_systems/src\")


# Set build types
set(CMAKE_CXX_FLAGS_DEBUG "-g")
set(CMAKE_CXX_FLAGS_RELEASE "-O3")

# Set the default build type to Release if not specified
if(NOT CMAKE_BUILD_TYPE)
  set(CMAKE_BUILD_TYPE Release)
endif()