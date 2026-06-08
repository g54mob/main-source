public class PredictionRate
{
	public int season;

	public string code;

	public float rate;

	public PredictionRate(int season, string code, float rate)
	{
		this.season = season;
		this.code = code;
		this.rate = rate;
	}

	public override string ToString()
	{
		return $"{season}, '{code}', {rate}";
	}

	public static PredictionRate BuildFromRow(string[] row)
	{
		int num = int.Parse(row[0]);
		string text = row[1];
		float num2 = float.Parse(row[2]);
		return new PredictionRate(num, text, num2);
	}
}
