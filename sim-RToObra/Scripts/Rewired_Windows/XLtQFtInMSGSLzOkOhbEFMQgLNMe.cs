using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Rewired.Libraries.SharpDX.DirectInput;

internal class XLtQFtInMSGSLzOkOhbEFMQgLNMe : TypeSpecificParameters
{
	[CompilerGenerated]
	private int eNuItBMEOBiKDHnpfOfNUszzmkME;

	[CompilerGenerated]
	private int QaiOKoaFGcLvOimOsuyFBrbiKDt;

	[CompilerGenerated]
	private int qBJLQjGTDXLzPetdovocNYhUYXy;

	[CompilerGenerated]
	private int LHZQFHeAjHeubtelocSBNyHOyas;

	public int Magnitude
	{
		[CompilerGenerated]
		get
		{
			return eNuItBMEOBiKDHnpfOfNUszzmkME;
		}
		[CompilerGenerated]
		set
		{
			eNuItBMEOBiKDHnpfOfNUszzmkME = value;
		}
	}

	public int Offset
	{
		[CompilerGenerated]
		get
		{
			return QaiOKoaFGcLvOimOsuyFBrbiKDt;
		}
		[CompilerGenerated]
		set
		{
			QaiOKoaFGcLvOimOsuyFBrbiKDt = value;
		}
	}

	public int Phase
	{
		[CompilerGenerated]
		get
		{
			return qBJLQjGTDXLzPetdovocNYhUYXy;
		}
		[CompilerGenerated]
		set
		{
			qBJLQjGTDXLzPetdovocNYhUYXy = value;
		}
	}

	public int Period
	{
		[CompilerGenerated]
		get
		{
			return LHZQFHeAjHeubtelocSBNyHOyas;
		}
		[CompilerGenerated]
		set
		{
			LHZQFHeAjHeubtelocSBNyHOyas = value;
		}
	}

	public override int Size
	{
		get
		{
			return WISJwItoxlmpVJIyUeIxBJGahMp.XMvgwMGgZmqMvpsoWuNJPriqSDB<GZfewzHdaOmbrUifTSBruDvGJKDf>();
		}
	}

	protected unsafe override TypeSpecificParameters MarshalFrom(int P_0, IntPtr P_1)
	{
		if (P_0 != sizeof(GZfewzHdaOmbrUifTSBruDvGJKDf))
		{
			return null;
		}
		Magnitude = ((GZfewzHdaOmbrUifTSBruDvGJKDf*)(void*)P_1)->OCgbesCSWhwkQdhTQAQtmCwwNyiB;
		Offset = ((GZfewzHdaOmbrUifTSBruDvGJKDf*)(void*)P_1)->hlnAktRuJhzkjrZorFzKwMoDRqv;
		Phase = ((GZfewzHdaOmbrUifTSBruDvGJKDf*)(void*)P_1)->JQNxFnhbddPbtpJkrjhcxNswggw;
		Period = ((GZfewzHdaOmbrUifTSBruDvGJKDf*)(void*)P_1)->pPOFlOUhgnCwyziNEdIBOMQYWLz;
		return this;
	}

	internal unsafe override IntPtr MarshalTo()
	{
		IntPtr intPtr = Marshal.AllocHGlobal(Size);
		((GZfewzHdaOmbrUifTSBruDvGJKDf*)(void*)intPtr)->OCgbesCSWhwkQdhTQAQtmCwwNyiB = Magnitude;
		((GZfewzHdaOmbrUifTSBruDvGJKDf*)(void*)intPtr)->hlnAktRuJhzkjrZorFzKwMoDRqv = Offset;
		((GZfewzHdaOmbrUifTSBruDvGJKDf*)(void*)intPtr)->JQNxFnhbddPbtpJkrjhcxNswggw = Phase;
		((GZfewzHdaOmbrUifTSBruDvGJKDf*)(void*)intPtr)->pPOFlOUhgnCwyziNEdIBOMQYWLz = Period;
		return intPtr;
	}
}
