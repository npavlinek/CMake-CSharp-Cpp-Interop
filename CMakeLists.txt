cmake_minimum_required(VERSION 3.23)
project(cmake_cpp_csharp CXX)

add_library(cpp_lib MODULE)
target_sources(cpp_lib
    PUBLIC FILE_SET HEADERS FILES
        cpp_lib/lib.h
    PRIVATE
        cpp_lib/lib.cpp
)
set_target_properties(cpp_lib PROPERTIES CXX_EXTENSIONS OFF)
target_compile_features(cpp_lib PRIVATE cxx_std_23)

add_subdirectory(csharp_exe)

add_custom_command(
    TARGET cpp_lib POST_BUILD
    COMMAND "${CMAKE_COMMAND}" -E copy "$<TARGET_FILE_DIR:cpp_lib>/$<TARGET_FILE_NAME:cpp_lib>" "$<TARGET_FILE_DIR:csharp_exe>"
    COMMAND_EXPAND_LISTS
)

add_dependencies(csharp_exe cpp_lib)
