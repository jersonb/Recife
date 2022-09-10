using Xunit.Abstractions;

namespace ObjectToCsv.Tests;

public class ObjectToCsvExtensionTests
{
    private readonly ITestOutputHelper output;

    public ObjectToCsvExtensionTests(ITestOutputHelper output)
    {
        this.output = output;
    }

    [Fact]
    public void Test1()
    {
        var test1 = new Test1
        {
            Id = 1,
            Classification = 2.2m,
            Name = "test1"
        };

        var a = test1.ToCsv();

        output.WriteLine(a);

        Assert.NotEmpty(a);
    }

    [Fact]
    public void Test2()
    {
        var test2 = new List<Test1>
        {
            new()
            {
                Id = 1,
                Classification = 2.2m,
                Name = "test1"
            },
            new()
            {
                Id = 2,
                Classification = 3.1m,
                Name = "test2"
            },
        };

        var a = test2.ToCsv();

        output.WriteLine(a);

        Assert.NotEmpty(a);
    }

    [Fact]
    public void Test3()
    {
        var test1 = new Test1
        {
            Id = 1,
            Classification = default,
            Name = null
        };

        var a = test1.ToCsv();

        output.WriteLine(a);

        Assert.NotEmpty(a);
    }
}

public class Test1
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty!;
    public decimal Classification { get; set; }
}