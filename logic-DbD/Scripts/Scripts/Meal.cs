public class Meal
{
	public string id;

	public string itemPurchased;

	public Meal(int id, string itemPurchased)
	{
		this.id = id.ToString("D5");
		this.itemPurchased = itemPurchased;
	}

	public override string ToString()
	{
		return "'" + id + "', '" + itemPurchased + "'";
	}
}
