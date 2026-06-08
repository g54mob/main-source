public class Order
{
	public string item_name;

	public int weight_in_grams;

	public double price;

	public double shipping_fee;

	public Order(string item_name, int weight_in_grams, double price, double shipping_fee)
	{
		this.item_name = item_name;
		this.weight_in_grams = weight_in_grams;
		this.price = price;
		this.shipping_fee = shipping_fee;
	}

	public override string ToString()
	{
		return $"'{item_name}', {weight_in_grams}, {price}, {shipping_fee}";
	}
}
