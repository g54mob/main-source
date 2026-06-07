using System;

[Serializable]
public class BerryCultist_Info
{
	public string cultistName;

	public int tier;

	public BerryCultist_Info(int _tier, string _name)
	{
		tier = _tier;
		cultistName = _name;
	}
}
