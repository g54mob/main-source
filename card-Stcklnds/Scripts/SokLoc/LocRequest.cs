public struct LocRequest
{
	public string Text;

	public LocParam[] Params;

	public LocRequest(string text, LocParam[] p)
	{
		Text = text;
		Params = p;
	}
}
