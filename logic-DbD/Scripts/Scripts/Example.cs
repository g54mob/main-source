public class Example
{
	private int col1;

	private int col2;

	public Example(int col1, int col2)
	{
		this.col1 = col1;
		this.col2 = col2;
	}

	public override string ToString()
	{
		return $"{col1}, {col2}";
	}
}
