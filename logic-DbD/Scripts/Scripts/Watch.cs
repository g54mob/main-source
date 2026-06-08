public class Watch
{
	public string title;

	public Watch(string title)
	{
		this.title = title;
	}

	public override string ToString()
	{
		return "'" + title + "'";
	}
}
