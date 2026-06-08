public class SearchHistory
{
	public string ip;

	public string website;

	public int date;

	public int time;

	public SearchHistory(string ip, string website, int date, int time)
	{
		this.ip = ip;
		this.website = website;
		this.date = date;
		this.time = time;
	}

	public override string ToString()
	{
		return $"'{ip}', '{website}', '{date}', {time}";
	}
}
