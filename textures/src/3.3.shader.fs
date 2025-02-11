#version 330 core
out vec4 FragColor;
  
in vec3 ourColor;
in vec2 TexCoord;

uniform sampler2D texture1;
uniform sampler2D texture2;
uniform float mixValue;

void main()
{
    vec2 flipped_tex = vec2(1 - TexCoord.x, TexCoord.y);
    //apply mix value
    FragColor = mix(texture(texture1, TexCoord), texture(texture2, flipped_tex), mixValue);
}