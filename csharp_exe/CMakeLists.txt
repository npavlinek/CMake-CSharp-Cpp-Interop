cmake_minimum_required(VERSION 3.23)
project(csharp_exe CSharp)

add_executable(csharp_exe Program.cs)
set_target_properties(csharp_exe
    PROPERTIES
        DOTNET_SDK Microsoft.NET.Sdk
        DOTNET_TARGET_FRAMEWORK net9.0
)
target_compile_options(csharp_exe PRIVATE /unsafe)
