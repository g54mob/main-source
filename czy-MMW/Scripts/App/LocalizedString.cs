public class LocalizedString
{
	public Locale locale;

	public string localString;

	public LocalizedString(Locale newLocale, string newLocalString)
	{
		locale = newLocale;
		localString = newLocalString;
	}

	public override bool Equals(object obj)
	{
		if (!(obj is LocalizedString))
		{
			return false;
		}
		return Equals((LocalizedString)obj);
	}

	public bool Equals(LocalizedString obj)
	{
		if (locale == obj.locale)
		{
			return localString == obj.localString;
		}
		return false;
	}

	public override int GetHashCode()
	{
		return locale.GetHashCode() ^ localString.GetHashCode();
	}

	public static bool operator ==(LocalizedString x, LocalizedString y)
	{
		if ((object)x == null || (object)y == null)
		{
			if ((object)x == null)
			{
				return (object)y == null;
			}
			return false;
		}
		return x.Equals(y);
	}

	public static bool operator !=(LocalizedString x, LocalizedString y)
	{
		return !(x == y);
	}

	public override string ToString()
	{
		return localString;
	}
}
