using System;
using Rewired;

internal struct XdujyUCYlHSoIpCOCCzhzoIPeqwC : IEquatable<XdujyUCYlHSoIpCOCCzhzoIPeqwC>
{
	public KeyboardKeyCode OcRQTdGWosQWyZkzSAxBrIGBaAZ;

	public ModifierKey dzVdjlEVQwgzvzhVUKnnyxEfDccq;

	public ModifierKey QevfNgMhRGjlsMgBpjDuDOAeljTh;

	public ModifierKey yKFGycBpxalffjUWjPHPvRPQTWmG;

	public XdujyUCYlHSoIpCOCCzhzoIPeqwC(KeyboardKeyCode keyCode, ModifierKey modifierKey1, ModifierKey modifierKey2, ModifierKey modifierKey3)
	{
		OcRQTdGWosQWyZkzSAxBrIGBaAZ = keyCode;
		dzVdjlEVQwgzvzhVUKnnyxEfDccq = modifierKey1;
		QevfNgMhRGjlsMgBpjDuDOAeljTh = modifierKey2;
		yKFGycBpxalffjUWjPHPvRPQTWmG = modifierKey3;
	}

	public void VcHhfbFqwxAmqhwBHKVJpDjlfufe()
	{
		if (OcRQTdGWosQWyZkzSAxBrIGBaAZ != KeyboardKeyCode.None)
		{
			OcRQTdGWosQWyZkzSAxBrIGBaAZ = KeyboardKeyCode.None;
		}
		if (dzVdjlEVQwgzvzhVUKnnyxEfDccq != ModifierKey.None)
		{
			dzVdjlEVQwgzvzhVUKnnyxEfDccq = ModifierKey.None;
		}
		if (QevfNgMhRGjlsMgBpjDuDOAeljTh != ModifierKey.None)
		{
			QevfNgMhRGjlsMgBpjDuDOAeljTh = ModifierKey.None;
		}
		if (yKFGycBpxalffjUWjPHPvRPQTWmG != ModifierKey.None)
		{
			yKFGycBpxalffjUWjPHPvRPQTWmG = ModifierKey.None;
		}
	}

	public bool Equals(XdujyUCYlHSoIpCOCCzhzoIPeqwC other)
	{
		if (OcRQTdGWosQWyZkzSAxBrIGBaAZ == other.OcRQTdGWosQWyZkzSAxBrIGBaAZ && dzVdjlEVQwgzvzhVUKnnyxEfDccq == other.dzVdjlEVQwgzvzhVUKnnyxEfDccq && QevfNgMhRGjlsMgBpjDuDOAeljTh == other.QevfNgMhRGjlsMgBpjDuDOAeljTh)
		{
			return yKFGycBpxalffjUWjPHPvRPQTWmG == other.yKFGycBpxalffjUWjPHPvRPQTWmG;
		}
		return false;
	}

	public override bool Equals(object obj)
	{
		if (obj == null || !(obj is XdujyUCYlHSoIpCOCCzhzoIPeqwC))
		{
			return false;
		}
		return Equals((XdujyUCYlHSoIpCOCCzhzoIPeqwC)obj);
	}

	public override int GetHashCode()
	{
		int num = 17;
		num = num * 29 + OcRQTdGWosQWyZkzSAxBrIGBaAZ.GetHashCode();
		num = num * 29 + dzVdjlEVQwgzvzhVUKnnyxEfDccq.GetHashCode();
		num = num * 29 + QevfNgMhRGjlsMgBpjDuDOAeljTh.GetHashCode();
		return num * 29 + yKFGycBpxalffjUWjPHPvRPQTWmG.GetHashCode();
	}

	public static bool operator ==(XdujyUCYlHSoIpCOCCzhzoIPeqwC a, XdujyUCYlHSoIpCOCCzhzoIPeqwC b)
	{
		if (a.OcRQTdGWosQWyZkzSAxBrIGBaAZ == b.OcRQTdGWosQWyZkzSAxBrIGBaAZ && a.dzVdjlEVQwgzvzhVUKnnyxEfDccq == b.dzVdjlEVQwgzvzhVUKnnyxEfDccq && a.QevfNgMhRGjlsMgBpjDuDOAeljTh == b.QevfNgMhRGjlsMgBpjDuDOAeljTh)
		{
			return a.yKFGycBpxalffjUWjPHPvRPQTWmG == b.yKFGycBpxalffjUWjPHPvRPQTWmG;
		}
		return false;
	}

	public static bool operator !=(XdujyUCYlHSoIpCOCCzhzoIPeqwC a, XdujyUCYlHSoIpCOCCzhzoIPeqwC b)
	{
		return !(a == b);
	}
}
