public struct InputName
{
	public string str;

	public InputName(string str)
	{
		this.str = null;
	}

	public static implicit operator string(InputName inputName)
	{
		return null;
	}

	public static implicit operator InputName(string inputName)
	{
		return default(InputName);
	}
}
