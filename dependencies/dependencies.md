## GLFW
[Download and install](https://github.com/glfw/glfw)

#### Ubuntu dependencies

```bash
sudo apt install libwayland-dev libxkbcommon-dev xorg-dev libglm-dev
```

#### Download and compile source code, for OpenGL 3.3

```bash
git clone https://github.com/glfw/glfw.git
cd glfw

# Switch to version 3.3
git checkout 3.3 

# Generate Makefiles
cmake -S . -D BUILD_SHARED_LIBS=ON -B build

# Compile
cd build
make

#Install
sudo make install
```

The header files and dependencies will be in /usr/local/include and /usr/local/lib. And the pkgconfig is in /usr/local/lib/pkgconfig/glfw3.pc.

## GLAD

#### Download for OpenGL 3.3

[Download installer](https://glad.dav1d.de/)

Select version 3.3, profile Core, and Generate a loader.

It will download a zip file with the include and src folders to include in your project. 