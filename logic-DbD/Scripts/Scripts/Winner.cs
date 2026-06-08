public class Winner : Person
{
	public double amountWon;

	public Winner(string firstName, string lastName, double amountWon)
		: base(firstName, lastName)
	{
		this.amountWon = amountWon;
	}

	public override string ToString()
	{
		return $"{base.ToString()}, {amountWon}";
	}

	public new static Winner BuildFromRow(string[] row)
	{
		string obj = row[0];
		string text = row[1];
		double num = double.Parse(row[2]);
		return new Winner(obj, text, num);
	}
}
