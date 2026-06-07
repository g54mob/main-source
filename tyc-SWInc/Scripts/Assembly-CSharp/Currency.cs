public struct Currency
{
	public readonly string Name;

	public readonly string Prefix;

	public readonly string Postfix;

	public readonly float Rate;

	public Currency(string name, string pre, string post, float rate)
	{
		Name = name;
		Prefix = pre;
		Postfix = post;
		Rate = rate;
	}

	public Currency(XMLParser.XMLNode node)
	{
		Name = node.GetNode("Name").Value;
		Prefix = node.GetNode("Prefix").Value;
		Postfix = node.GetNode("Postfix").Value;
		Rate = node.GetNode("Rate").Value.ConvertToFloat("Currency rate");
	}
}
