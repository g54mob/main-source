using System;
using System.Runtime.CompilerServices;

internal struct YQuCEeifdZlVOVdlokMhgPWKIrzY : IEquatable<YQuCEeifdZlVOVdlokMhgPWKIrzY>
{
	public static readonly YQuCEeifdZlVOVdlokMhgPWKIrzY gtTNTtGBfnIeDHbTOYBncMiWVDgV = new YQuCEeifdZlVOVdlokMhgPWKIrzY(0f, 0f);

	public static readonly YQuCEeifdZlVOVdlokMhgPWKIrzY JmCbepClxClFcOsgvemIBWtBJPWab = gtTNTtGBfnIeDHbTOYBncMiWVDgV;

	public float zKIWWxGQIXwYpLOSPftCjynYeNnf;

	public float BJDaeQFQtsCGyAoFxCRTQWBvtqAsA;

	public YQuCEeifdZlVOVdlokMhgPWKIrzY(float P_0, float P_1)
	{
		zKIWWxGQIXwYpLOSPftCjynYeNnf = P_0;
		BJDaeQFQtsCGyAoFxCRTQWBvtqAsA = P_1;
	}

	public bool Equals(YQuCEeifdZlVOVdlokMhgPWKIrzY other)
	{
		if (other.zKIWWxGQIXwYpLOSPftCjynYeNnf == zKIWWxGQIXwYpLOSPftCjynYeNnf)
		{
			return other.BJDaeQFQtsCGyAoFxCRTQWBvtqAsA == BJDaeQFQtsCGyAoFxCRTQWBvtqAsA;
		}
		return false;
	}

	bool IEquatable<YQuCEeifdZlVOVdlokMhgPWKIrzY>.Equals(YQuCEeifdZlVOVdlokMhgPWKIrzY other)
	{
		//ILSpy generated this explicit interface implementation from .override directive in Equals
		return this.Equals(other);
	}

	public bool hKhQmXPfFiGVrrlartpEfSCyFTojA(object P_0)
	{
		if (P_0 == null)
		{
			return false;
		}
		if (P_0.GetType() != typeof(YQuCEeifdZlVOVdlokMhgPWKIrzY))
		{
			return false;
		}
		return Equals((YQuCEeifdZlVOVdlokMhgPWKIrzY)P_0);
	}

	public int cmiMRgetXDgngDiJOuykVvTIsqyL()
	{
		return (zKIWWxGQIXwYpLOSPftCjynYeNnf.GetHashCode() * 397) ^ BJDaeQFQtsCGyAoFxCRTQWBvtqAsA.GetHashCode();
	}

	[SpecialName]
	public static bool FCpXMkbjIyeVBKCmTkFuiyVTTJON(YQuCEeifdZlVOVdlokMhgPWKIrzY P_0, YQuCEeifdZlVOVdlokMhgPWKIrzY P_1)
	{
		return P_0.Equals(P_1);
	}

	[SpecialName]
	public static bool XbHYohplzpuzueDlfFbotmjhMbAP(YQuCEeifdZlVOVdlokMhgPWKIrzY P_0, YQuCEeifdZlVOVdlokMhgPWKIrzY P_1)
	{
		return !P_0.Equals(P_1);
	}

	public string nBOfAZpJisHbTfdLQZuoIfGJDdxA()
	{
		return $"({zKIWWxGQIXwYpLOSPftCjynYeNnf},{BJDaeQFQtsCGyAoFxCRTQWBvtqAsA})";
	}
}
