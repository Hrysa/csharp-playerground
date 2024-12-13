using NUnit.Framework;
using NUnit.Framework.Internal;

namespace playground1;

public class Tuple
{
    enum E
    {
        A,
        B
    }

    [Test]
    public void TestDefaultValue()
    {
        List<(E, string, int)> values = new();
        var r = values.FirstOrDefault();

        Assert.That(r.Item1, Is.EqualTo(E.A));
        Assert.That(r.Item2, Is.EqualTo(null));
        Assert.That(r.Item3, Is.EqualTo(0));
    }
}