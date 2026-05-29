using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Rewired.Libraries.SharpDX.DirectInput;

internal class BjRUJDxfKOdDOmRMbKjONGYIzTK : TypeSpecificParameters
{
	[CompilerGenerated]
	private int iKSkxthOQZRfKohDEpxNtMfHclQ;

	[CompilerGenerated]
	private int IoICTOGHOmiIFfjqfNqFTSvREMtP;

	[CompilerGenerated]
	private int iRfiWPfNHJBMWlRDNIrkMQtkLSw;

	[CompilerGenerated]
	private int RCxBNpDqQnthtSsGCqyIfQsCwkmV;

	public int Magnitude
	{
		[CompilerGenerated]
		get
		{
			return iKSkxthOQZRfKohDEpxNtMfHclQ;
		}
		[CompilerGenerated]
		set
		{
			iKSkxthOQZRfKohDEpxNtMfHclQ = value;
		}
	}

	public int Offset
	{
		[CompilerGenerated]
		get
		{
			return IoICTOGHOmiIFfjqfNqFTSvREMtP;
		}
		[CompilerGenerated]
		set
		{
			IoICTOGHOmiIFfjqfNqFTSvREMtP = value;
		}
	}

	public int Phase
	{
		[CompilerGenerated]
		get
		{
			return iRfiWPfNHJBMWlRDNIrkMQtkLSw;
		}
		[CompilerGenerated]
		set
		{
			iRfiWPfNHJBMWlRDNIrkMQtkLSw = value;
		}
	}

	public int Period
	{
		[CompilerGenerated]
		get
		{
			return RCxBNpDqQnthtSsGCqyIfQsCwkmV;
		}
		[CompilerGenerated]
		set
		{
			RCxBNpDqQnthtSsGCqyIfQsCwkmV = value;
		}
	}

	public override int Size
	{
		get
		{
			return QiyhMeApbloIAQYCjGAvUEQIhAz.THBpTsDJKmVwufYBxLzZkiSYLgH<KUZpTHKqNEcstdZeuHedCfuiGaL>();
		}
	}

	protected unsafe override TypeSpecificParameters MarshalFrom(int P_0, IntPtr P_1)
	{
		if (P_0 != sizeof(KUZpTHKqNEcstdZeuHedCfuiGaL))
		{
			return null;
		}
		Magnitude = ((KUZpTHKqNEcstdZeuHedCfuiGaL*)(void*)P_1)->IAYfOfnCdHbByEvdeKnGBmGFweo;
		Offset = ((KUZpTHKqNEcstdZeuHedCfuiGaL*)(void*)P_1)->hjBppRkfXtnYcuOOIniKzsiloNt;
		Phase = ((KUZpTHKqNEcstdZeuHedCfuiGaL*)(void*)P_1)->DbQxHSbvrwdocOLUrEugyJYqLu;
		Period = ((KUZpTHKqNEcstdZeuHedCfuiGaL*)(void*)P_1)->fkaaImIpqnVLdNyftenDiPCgqWb;
		return this;
	}

	internal unsafe override IntPtr MarshalTo()
	{
		IntPtr intPtr = Marshal.AllocHGlobal(Size);
		((KUZpTHKqNEcstdZeuHedCfuiGaL*)(void*)intPtr)->IAYfOfnCdHbByEvdeKnGBmGFweo = Magnitude;
		((KUZpTHKqNEcstdZeuHedCfuiGaL*)(void*)intPtr)->hjBppRkfXtnYcuOOIniKzsiloNt = Offset;
		((KUZpTHKqNEcstdZeuHedCfuiGaL*)(void*)intPtr)->DbQxHSbvrwdocOLUrEugyJYqLu = Phase;
		((KUZpTHKqNEcstdZeuHedCfuiGaL*)(void*)intPtr)->fkaaImIpqnVLdNyftenDiPCgqWb = Period;
		return intPtr;
	}
}
