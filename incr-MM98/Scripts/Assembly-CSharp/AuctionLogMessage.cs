public readonly struct AuctionLogMessage
{
	public readonly string Username;

	public readonly string Item;

	public readonly double Value;

	public readonly double Cut;

	public readonly float CutPercentage;

	public AuctionLogMessage(string username, string item, double value, double cut, float cutPercentage)
	{
		Username = username;
		Item = item;
		Value = value;
		Cut = cut;
		CutPercentage = cutPercentage;
	}
}
