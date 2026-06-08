public class Game
{
	public int date;

	public int season;

	public int game;

	public string team;

	public int finalScore;

	public Game(int date, int season, int game, string team, int finalScore)
	{
		this.date = date;
		this.season = season;
		this.game = game;
		this.team = team;
		this.finalScore = finalScore;
	}

	public override string ToString()
	{
		return $"{date}, {season}, {game}, '{team}', {finalScore}";
	}

	public static Game BuildFromRow(string[] row)
	{
		int num = int.Parse(row[0]);
		int num2 = int.Parse(row[1]);
		int num3 = int.Parse(row[2]);
		string text = row[3];
		int num4 = int.Parse(row[4]);
		return new Game(num, num2, num3, text, num4);
	}
}
