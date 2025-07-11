using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;

[assembly: DisableRuntimeMarshalling]

partial class Program
{
    private static partial class CppLib
    {
        [LibraryImport("cpp_lib")]
        public static partial int Add(int a, int b);

        [StructLayout(LayoutKind.Sequential)]
        public struct Data
        {
            public string Message;
        }

        [CustomMarshaller(typeof(Data), MarshalMode.ManagedToUnmanagedIn, typeof(DataMarshaller))]
        private static unsafe class DataMarshaller
        {
            internal struct DataUnmanaged
            {
                public byte* Message;
            }

            public static DataUnmanaged ConvertToUnmanaged(Data data) => new()
            {
                Message = Utf8StringMarshaller.ConvertToUnmanaged(data.Message),
            };

            public static void Free(DataUnmanaged data) => Utf8StringMarshaller.Free(data.Message);
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct Thing
        {
            public int A;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct Something
        {
            public float F;
            public bool B;
            public Thing Thing;
        }

        [LibraryImport("cpp_lib")]
        public static partial Something GetSomething([MarshalUsing(typeof(DataMarshaller))] Data data);
    }

    static void Main(string[] args)
    {
        _ = args;

        int result = CppLib.Add(5, 3);
        Console.WriteLine($"The result is {result}");

        var something = CppLib.GetSomething(new CppLib.Data { Message = "Hello, 世界!" });
        Console.WriteLine($"Something: F={something.F} B={something.B} Thing.A={something.Thing.A}");
    }
}
