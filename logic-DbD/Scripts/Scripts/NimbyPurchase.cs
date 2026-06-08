public class NimbyPurchase
{
	public string purchased_by;

	public string broker;

	public NimbyPurchase(string purchased_by, string broker)
	{
		this.purchased_by = purchased_by;
		this.broker = broker;
	}

	public override string ToString()
	{
		return "'" + purchased_by + "', '" + broker + "'";
	}

	public static NimbyPurchase BuildFromRow(string[] row)
	{
		string obj = row[0];
		string text = row[1];
		return new NimbyPurchase(obj, text);
	}
}
