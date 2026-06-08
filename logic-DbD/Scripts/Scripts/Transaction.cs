public class Transaction
{
	public int date;

	public int time;

	public int quantity;

	public string buyer;

	public string seller;

	public Transaction(int date, int time, int quantity, string buyer, string seller)
	{
		this.date = date;
		this.time = time;
		this.quantity = quantity;
		this.buyer = buyer;
		this.seller = seller;
	}

	public override string ToString()
	{
		return $"{date}, {time}, {quantity}, '{buyer}', '{seller}'";
	}

	public static Transaction BuildFromRow(string[] row)
	{
		int num = int.Parse(row[0]);
		int num2 = int.Parse(row[1]);
		int num3 = int.Parse(row[2]);
		string text = row[3];
		string text2 = row[4];
		return new Transaction(num, num2, num3, text, text2);
	}
}
