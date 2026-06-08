public class Influence
{
	public string philosopher;

	public string direct_influence;

	public Influence(string philosopher, string direct_influence)
	{
		this.philosopher = philosopher;
		this.direct_influence = direct_influence;
	}

	public override string ToString()
	{
		return "'" + philosopher + "', '" + direct_influence + "'";
	}
}
