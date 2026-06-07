using System.Collections.Generic;

public class LocRequestComparer : IEqualityComparer<LocRequest>
{
	public bool Equals(LocRequest x, LocRequest y)
	{
		if (x.Text != y.Text)
		{
			return false;
		}
		if (x.Params.Length != y.Params.Length)
		{
			return false;
		}
		for (int i = 0; i < x.Params.Length; i++)
		{
			LocParam locParam = x.Params[i];
			LocParam locParam2 = y.Params[i];
			if (locParam.Name != locParam2.Name || locParam.PluralCount != locParam2.PluralCount || locParam.Value != locParam2.Value)
			{
				return false;
			}
		}
		return true;
	}

	public int GetHashCode(LocRequest obj)
	{
		int num = 17;
		num = num * 23 + obj.Text.GetHashCode();
		for (int i = 0; i < obj.Params.Length; i++)
		{
			num = num * 23 + obj.Params[i].GetHashCode();
		}
		return num;
	}
}
