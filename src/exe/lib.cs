using Clone;

namespace exe;

[Cloneable]
partial class A
{
    public int Id;
}

[Cloneable]
partial class B : A
{
    public string a;
}

[Cloneable]
partial class O
{
    public Dictionary<string, A> Dictionary = new Dictionary<string, A>();
}