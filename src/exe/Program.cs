using System.Reflection;
using System.Runtime.CompilerServices;
using Clone;
using exe;
using shared;

var type = Type.GetType("System.Int32");
Console.WriteLine(type);

O o = new O() { Dictionary = new Dictionary<string, A>() { ["A"] = new B() } };

var b  = Cloner.Make(o);

Console.WriteLine(b);

Console.WriteLine(double.MaxValue);

Helper.MeasureGC(() =>
{
    var i = 1;
    object z1 = i;
    object z2 = i;
    object z3 = i;
    
    F2(i);
    
    // F(z1); // 24
    // F(z1); // 24
    // F(z1); // 24

    // F(z1); // 24
    // F(z2); // 48
    // F(z3); // 72
    
    // F((int)z1); // 48
    // F((int)z2); // 96
    // F((int)z3); // 144
});

// [MethodImpl(MethodImplOptions.NoOptimization)]
[MethodImpl(MethodImplOptions.AggressiveOptimization)]
void F(object x)
{
}

[MethodImpl(MethodImplOptions.NoOptimization)]
void F2(int x)
{
}

