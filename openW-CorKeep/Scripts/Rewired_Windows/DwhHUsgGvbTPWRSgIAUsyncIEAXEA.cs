using System.Collections.Generic;
using Rewired.Utils;

internal class DwhHUsgGvbTPWRSgIAUsyncIEAXEA : tZGWdXmeeMqtWCvUSDWRJbQvngwO
{
	private List<wbbfCXvBfWGUStOsLNAUvlORxvSw> xmozwQPfVArewgGJYRxytRlyLyad;

	private wbbfCXvBfWGUStOsLNAUvlORxvSw[] RqidTSDaJZgvMJHXqBRJqBOoSGGD;

	private bool BVQpogzQCMdJaWTsVboRmdSyilPK;

	public DwhHUsgGvbTPWRSgIAUsyncIEAXEA()
	{
		xmozwQPfVArewgGJYRxytRlyLyad = new List<wbbfCXvBfWGUStOsLNAUvlORxvSw>();
	}

	public virtual void fOuaknOwgWQETCdCuBoDCKwrlNgr(wbbfCXvBfWGUStOsLNAUvlORxvSw P_0)
	{
		xmozwQPfVArewgGJYRxytRlyLyad.Add(P_0);
	}

	public float aFJKkYSyCZCopbUtfJsAJpDKyGTt(int P_0)
	{
		if (P_0 < 0 || P_0 >= RqidTSDaJZgvMJHXqBRJqBOoSGGD.Length)
		{
			return 0f;
		}
		return DErFNnEJHcZDLPGfvWujWodWbJzy(RqidTSDaJZgvMJHXqBRJqBOoSGGD[P_0].NlCYCHZDBPENtgCMklRFIOALFQFlA);
	}

	public int PgrdIPEUWJuhshMYudwmBlnASwpMA(int P_0)
	{
		if (P_0 < 0 || P_0 >= RqidTSDaJZgvMJHXqBRJqBOoSGGD.Length)
		{
			return 0;
		}
		return (int)RqidTSDaJZgvMJHXqBRJqBOoSGGD[P_0].UDHlscgVBIflukrarSDkCkcjQJh;
	}

	public virtual void qByZbmVCORnNVOaXCJQpItyuSssp()
	{
		if (!BVQpogzQCMdJaWTsVboRmdSyilPK)
		{
			BVQpogzQCMdJaWTsVboRmdSyilPK = true;
			RqidTSDaJZgvMJHXqBRJqBOoSGGD = xmozwQPfVArewgGJYRxytRlyLyad.ToArray();
			xmozwQPfVArewgGJYRxytRlyLyad = null;
		}
	}

	private static float DErFNnEJHcZDLPGfvWujWodWbJzy(int P_0)
	{
		if (P_0 == 0)
		{
			return 0f;
		}
		return MathTools.Clamp((float)MathTools.Abs(P_0) / 65535f * (float)MathTools.Sign(P_0), -1f, 1f);
	}
}
