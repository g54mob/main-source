using System;

[Serializable]
public class Group
{
	public string name;

	public bool locked;

	public Group(string _name)
	{
		name = _name;
		locked = false;
	}
}
