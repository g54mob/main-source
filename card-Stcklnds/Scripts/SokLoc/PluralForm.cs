public class PluralForm
{
	public string One;

	public string Many;

	public string Other;

	public string GetCorrectPluralForm(string language, int count)
	{
		int i = GetI(count);
		int v = GetV(count);
		GetE(count);
		switch (language)
		{
		case "English":
			if (i == 1 && v == 0)
			{
				return One;
			}
			return Other;
		case "Dutch":
			if (i == 1 && v == 0)
			{
				return One;
			}
			return Other;
		case "Chinese (Traditional)":
			return Other;
		default:
			if (i == 1 && v == 0)
			{
				return One;
			}
			return Other;
		}
	}

	public bool IsEmpty()
	{
		if (string.IsNullOrEmpty(One) && string.IsNullOrEmpty(Many))
		{
			return string.IsNullOrEmpty(Other);
		}
		return false;
	}

	private int GetI(float f)
	{
		return (int)f;
	}

	private int GetE(float f)
	{
		return 0;
	}

	private int GetV(float f)
	{
		return 0;
	}
}
