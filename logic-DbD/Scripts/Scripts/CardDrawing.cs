public class CardDrawing
{
	public int week;

	public string card1;

	public string card2;

	public string card3;

	public string card4;

	public string card5;

	public CardDrawing(int week, string card1, string card2, string card3, string card4, string card5)
	{
		this.week = week;
		this.card1 = card1;
		this.card2 = card2;
		this.card3 = card3;
		this.card4 = card4;
		this.card5 = card5;
	}

	public override string ToString()
	{
		return $"{week}, '{card1}', '{card2}', '{card3}', '{card4}', '{card5}'";
	}

	public static CardDrawing BuildFromRow(string[] row)
	{
		int num = int.Parse(row[0]);
		string text = row[1];
		string text2 = row[2];
		string text3 = row[3];
		string text4 = row[4];
		string text5 = row[5];
		return new CardDrawing(num, text, text2, text3, text4, text5);
	}
}
