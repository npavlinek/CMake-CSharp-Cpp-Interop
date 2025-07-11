#ifndef LIB_H
#define LIB_H

extern "C" __declspec(dllexport) int Add(int a, int b);

struct Data {
    const char* Message;
};

struct Something {
    struct Thing {
        int A;
    };

    float F;
    bool B;
    Thing Thing;
};

extern "C" __declspec(dllexport) Something GetSomething(Data data);

#endif
