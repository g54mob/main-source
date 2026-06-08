public class ExampleJoin
{
	private int id;

	private string name;

	public ExampleJoin(int id, string name)
	{
		this.id = id;
		this.name = name;
	}

	public override string ToString()
	{
		return $"{id}, '{name}'";
	}
}
