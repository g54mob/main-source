using System.Collections.Generic;
using Rewired.Utils;

internal class EkjPPGtMfdCmBOwKmCFAiaihYVqrA : BWhlahGgwqzZnsKWAMzsCpuXBaYA
{
	private List<GwKCNWerMwGDIZpUKnXBMbelrGkBA> ghmEKlJYCMdiiuMuqJaOaOnPuauEA;

	private GwKCNWerMwGDIZpUKnXBMbelrGkBA[] tIRfmhDNktQIHCgMoMmZwoXJhFIQA;

	private bool gyNGjEipoCkuajmEcIwIcseXnSmH;

	public EkjPPGtMfdCmBOwKmCFAiaihYVqrA()
	{
		ghmEKlJYCMdiiuMuqJaOaOnPuauEA = new List<GwKCNWerMwGDIZpUKnXBMbelrGkBA>();
	}

	public override void JbWypadEzUVMQhbKNHjDTgfeGuSy(GwKCNWerMwGDIZpUKnXBMbelrGkBA P_0)
	{
		ghmEKlJYCMdiiuMuqJaOaOnPuauEA.Add(P_0);
	}

	public float gtExFxcpYcZTABrBeLFEPTMTniaw(int P_0)
	{
		if (P_0 < 0 || P_0 >= tIRfmhDNktQIHCgMoMmZwoXJhFIQA.Length)
		{
			return 0f;
		}
		return ZeCVkTdiUyWuvkSDDwvSKXKKMqkf(tIRfmhDNktQIHCgMoMmZwoXJhFIQA[P_0].bHhKLBYReRMVzLmXXVGCAnLNQrgi);
	}

	public int ABlNUnzdvpBOUkUNIiXYyXkXjYbK(int P_0)
	{
		if (P_0 < 0 || P_0 >= tIRfmhDNktQIHCgMoMmZwoXJhFIQA.Length)
		{
			return 0;
		}
		return (int)tIRfmhDNktQIHCgMoMmZwoXJhFIQA[P_0].IpowQrWgAKWJbohdrclSaosMreNB;
	}

	public override void lFBNbAMEKrzMztPjNJKGhofhxkyd()
	{
		if (!gyNGjEipoCkuajmEcIwIcseXnSmH)
		{
			gyNGjEipoCkuajmEcIwIcseXnSmH = true;
			tIRfmhDNktQIHCgMoMmZwoXJhFIQA = ghmEKlJYCMdiiuMuqJaOaOnPuauEA.ToArray();
			ghmEKlJYCMdiiuMuqJaOaOnPuauEA = null;
		}
	}

	private float ZeCVkTdiUyWuvkSDDwvSKXKKMqkf(int P_0)
	{
		if (P_0 == 0)
		{
			return 0f;
		}
		return MathTools.Clamp((float)MathTools.Abs(P_0) / 65535f * (float)MathTools.Sign(P_0), -1f, 1f);
	}
}
