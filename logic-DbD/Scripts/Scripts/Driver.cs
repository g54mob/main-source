public class Driver : Person
{
	public string neighborhood;

	public Driver(string firstName, string lastName, string neighborhood)
		: base(firstName, lastName)
	{
		this.neighborhood = neighborhood;
	}

	public override string ToString()
	{
		return base.ToString() + ", '" + neighborhood + "'";
	}

	public new static Driver BuildFromRow(string[] row)
	{
		string obj = row[0];
		string text = row[1];
		string text2 = row[2];
		return new Driver(obj, text, text2);
	}
}
