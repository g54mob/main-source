public class MenuItem
{
	public string item;

	public string price;

	public MenuItem(string item, float price)
	{
		this.item = item;
		this.price = price.ToString("0.00");
	}

	public override string ToString()
	{
		return "'" + item + "', '" + price + "'";
	}
}
