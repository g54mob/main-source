public class BankTransaction
{
	public int date;

	public int time;

	public string account_name;

	public int money_transferred;

	public string note;

	public BankTransaction(int date, int time, string account_name, int money_transferred, string note)
	{
		this.date = date;
		this.time = time;
		this.account_name = account_name;
		this.money_transferred = money_transferred;
		this.note = note;
	}

	public override string ToString()
	{
		return $"{date}, {time}, '{account_name}', {money_transferred}, '{note}'";
	}

	public static BankTransaction BuildFromRow(string[] row)
	{
		int num = int.Parse(row[0]);
		int num2 = int.Parse(row[1]);
		string text = row[2];
		int num3 = int.Parse(row[3]);
		string text2 = row[4];
		return new BankTransaction(num, num2, text, num3, text2);
	}
}
