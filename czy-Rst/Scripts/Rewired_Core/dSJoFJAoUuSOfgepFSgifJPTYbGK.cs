using Rewired;

internal sealed class dSJoFJAoUuSOfgepFSgifJPTYbGK : NDfpyFSaZLfkCDZsJNmfUbzjrxqoA
{
	protected bool SfFNmTEidaahMiJXkhwPPYqKdMMI(Pole P_0)
	{
		return base.dUUDrzPkiDVoUVOJOYUjkoDyEkRM switch
		{
			wDdhIfgQYXRpSeEwrBrHOItkwVRlA.Axis => true, 
			wDdhIfgQYXRpSeEwrBrHOItkwVRlA.Button => P_0 switch
			{
				Pole.Positive => false, 
				Pole.Negative => true, 
				_ => false, 
			}, 
			_ => false, 
		};
	}

	protected bool hAcEPiAiWWOFiBvSuzHaQdXbCEJxA(Pole P_0)
	{
		switch (base.dUUDrzPkiDVoUVOJOYUjkoDyEkRM)
		{
		case wDdhIfgQYXRpSeEwrBrHOItkwVRlA.Axis:
			return true;
		case wDdhIfgQYXRpSeEwrBrHOItkwVRlA.Button:
			if ((uint)P_0 <= 1u)
			{
				return true;
			}
			return false;
		default:
			return false;
		}
	}

	private dSJoFJAoUuSOfgepFSgifJPTYbGK(wDdhIfgQYXRpSeEwrBrHOItkwVRlA P_0, NpYWoxDajscclIyARrpcWpXeFhgi P_1)
		: base(P_0, P_1)
	{
	}

	private dSJoFJAoUuSOfgepFSgifJPTYbGK(bXtOivlsOYjkGZtzvdtdZjoKDUCF P_0, wDdhIfgQYXRpSeEwrBrHOItkwVRlA P_1, NpYWoxDajscclIyARrpcWpXeFhgi P_2)
		: base(P_0, P_1, P_2)
	{
	}

	public static dSJoFJAoUuSOfgepFSgifJPTYbGK mVUkfdnDdDmEvcqoRjPHVObfdEbc(wDdhIfgQYXRpSeEwrBrHOItkwVRlA P_0, NpYWoxDajscclIyARrpcWpXeFhgi P_1)
	{
		return new dSJoFJAoUuSOfgepFSgifJPTYbGK(P_0, P_1);
	}

	public static dSJoFJAoUuSOfgepFSgifJPTYbGK HfoGyyEErDkplEKhuGjriMRuNvdQA(bXtOivlsOYjkGZtzvdtdZjoKDUCF P_0, wDdhIfgQYXRpSeEwrBrHOItkwVRlA P_1, NpYWoxDajscclIyARrpcWpXeFhgi P_2)
	{
		dSJoFJAoUuSOfgepFSgifJPTYbGK obj = new dSJoFJAoUuSOfgepFSgifJPTYbGK(P_0, P_1, P_2);
		obj.vtJxVkbxQgQVbPknOGkynGbiyVxG();
		return obj;
	}
}
