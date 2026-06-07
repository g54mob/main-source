using System;
using System.Runtime.CompilerServices;

internal struct HBMYoYSdNwbDlOnXcSCWizgHeQkO : IEquatable<HBMYoYSdNwbDlOnXcSCWizgHeQkO>
{
	public static readonly HBMYoYSdNwbDlOnXcSCWizgHeQkO RHehBwDLhoBlJseolcvUnZfDCgeS = new HBMYoYSdNwbDlOnXcSCWizgHeQkO(0f, 0f);

	public static readonly HBMYoYSdNwbDlOnXcSCWizgHeQkO kVxYLzSxBBkDqfykqfQrFXMXcttV = RHehBwDLhoBlJseolcvUnZfDCgeS;

	public float gxJIBqAQdiyAMmXguRqDxGkQCqUl;

	public float QxJWgmYYskAoNDIDObyygnCJDtcGb;

	public HBMYoYSdNwbDlOnXcSCWizgHeQkO(float P_0, float P_1)
	{
		gxJIBqAQdiyAMmXguRqDxGkQCqUl = P_0;
		QxJWgmYYskAoNDIDObyygnCJDtcGb = P_1;
	}

	public bool Equals(HBMYoYSdNwbDlOnXcSCWizgHeQkO other)
	{
		if (other.gxJIBqAQdiyAMmXguRqDxGkQCqUl == gxJIBqAQdiyAMmXguRqDxGkQCqUl)
		{
			return other.QxJWgmYYskAoNDIDObyygnCJDtcGb == QxJWgmYYskAoNDIDObyygnCJDtcGb;
		}
		return false;
	}

	public bool JRxBWnhQlwwPGktFTDexAbegXFrzB(object P_0)
	{
		if (P_0 == null)
		{
			return false;
		}
		if ((object)P_0.GetType() != typeof(HBMYoYSdNwbDlOnXcSCWizgHeQkO))
		{
			return false;
		}
		return Equals((HBMYoYSdNwbDlOnXcSCWizgHeQkO)P_0);
	}

	public int fEwcDhFDzGumYFCZRxsMimpbheAt()
	{
		return (gxJIBqAQdiyAMmXguRqDxGkQCqUl.GetHashCode() * 397) ^ QxJWgmYYskAoNDIDObyygnCJDtcGb.GetHashCode();
	}

	[SpecialName]
	public static bool KnRQEmwHYQnLlhpqQiYLhcNhPfug(HBMYoYSdNwbDlOnXcSCWizgHeQkO P_0, HBMYoYSdNwbDlOnXcSCWizgHeQkO P_1)
	{
		return P_0.Equals(P_1);
	}

	[SpecialName]
	public static bool aVrCGbDxOYyGJCHKjqMUEaQwsGZeb(HBMYoYSdNwbDlOnXcSCWizgHeQkO P_0, HBMYoYSdNwbDlOnXcSCWizgHeQkO P_1)
	{
		return !P_0.Equals(P_1);
	}

	public string GvNCmPFePpgwRPnXVCmFehxNQKcDb()
	{
		return $"({gxJIBqAQdiyAMmXguRqDxGkQCqUl},{QxJWgmYYskAoNDIDObyygnCJDtcGb})";
	}
}
