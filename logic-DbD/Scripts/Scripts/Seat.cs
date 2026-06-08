public class Seat : Person
{
	public string seat;

	public Seat(string firstName, string lastName, string seat)
		: base(firstName, lastName)
	{
		this.seat = seat;
	}

	public override string ToString()
	{
		return base.ToString() + ", '" + seat + "'";
	}

	public new static Seat BuildFromRow(string[] row)
	{
		string obj = row[0];
		string text = row[1];
		string text2 = row[2];
		return new Seat(obj, text, text2);
	}
}
