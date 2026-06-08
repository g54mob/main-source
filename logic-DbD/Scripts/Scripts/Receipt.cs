public class Receipt : Person
{
	public string mealId;

	public string tip;

	public Receipt(string firstName, string lastName, int mealId, float tip)
		: base(firstName, lastName)
	{
		this.mealId = mealId.ToString("D5");
		this.tip = tip.ToString("0.00");
	}

	public override string ToString()
	{
		return base.ToString() + ", '" + mealId + "', '" + tip + "'";
	}
}
