#include "lib.h"

#include <print>

int Add(int a, int b)
{
    return a + b;
}

Something GetSomething(Data data)
{
    std::print("Message from C++: {}\n", data.Message);

    return {
        .F = 2.7f,
        .B = true,
        .Thing{.A = 123},
    };
}
