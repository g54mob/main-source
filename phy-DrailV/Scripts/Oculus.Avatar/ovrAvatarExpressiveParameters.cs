using UnityEngine;

public struct ovrAvatarExpressiveParameters
{
	public Vector4 irisColor;

	public Vector4 scleraColor;

	public Vector4 lashColor;

	public Vector4 browColor;

	public Vector4 lipColor;

	public Vector4 teethColor;

	public Vector4 gumColor;

	public float browLashIntensity;

	public float lipSmoothness;

	private static bool VectorEquals(Vector4 a, Vector4 b)
	{
		if (a.x == b.x && a.y == b.y && a.z == b.z)
		{
			return a.w == b.w;
		}
		return false;
	}

	public override bool Equals(object obj)
	{
		if (!(obj is ovrAvatarExpressiveParameters ovrAvatarExpressiveParameters2))
		{
			return false;
		}
		if (!VectorEquals(irisColor, ovrAvatarExpressiveParameters2.irisColor))
		{
			return false;
		}
		if (!VectorEquals(scleraColor, ovrAvatarExpressiveParameters2.scleraColor))
		{
			return false;
		}
		if (!VectorEquals(lashColor, ovrAvatarExpressiveParameters2.lashColor))
		{
			return false;
		}
		if (!VectorEquals(browColor, ovrAvatarExpressiveParameters2.browColor))
		{
			return false;
		}
		if (!VectorEquals(lipColor, ovrAvatarExpressiveParameters2.lipColor))
		{
			return false;
		}
		if (!VectorEquals(teethColor, ovrAvatarExpressiveParameters2.teethColor))
		{
			return false;
		}
		if (!VectorEquals(gumColor, ovrAvatarExpressiveParameters2.gumColor))
		{
			return false;
		}
		if (browLashIntensity != ovrAvatarExpressiveParameters2.browLashIntensity)
		{
			return false;
		}
		if (lipSmoothness != ovrAvatarExpressiveParameters2.lipSmoothness)
		{
			return false;
		}
		return true;
	}

	public override int GetHashCode()
	{
		return irisColor.GetHashCode() ^ scleraColor.GetHashCode() ^ lashColor.GetHashCode() ^ browColor.GetHashCode() ^ lipColor.GetHashCode() ^ teethColor.GetHashCode() ^ gumColor.GetHashCode() ^ browLashIntensity.GetHashCode() ^ lipSmoothness.GetHashCode();
	}
}
