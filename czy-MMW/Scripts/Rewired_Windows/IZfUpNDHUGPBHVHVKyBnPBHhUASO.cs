using System.Collections.Generic;
using Rewired.Utils;

internal class IZfUpNDHUGPBHVHVKyBnPBHhUASO : PEnBNvygTVNIRpDFmQSAfHAcuKUT
{
	private List<McAjpDVOvHGeSJiXqSDeUWLrXJOWA> SRvnaCFMfSedoikjpJwiNkznEQTTA;

	private McAjpDVOvHGeSJiXqSDeUWLrXJOWA[] knJHmTCsIOJFIHThJmnkCRQUUiRr;

	private bool EzmvMjKzryTRAHzTRCmQOBcFwGxx;

	public IZfUpNDHUGPBHVHVKyBnPBHhUASO()
	{
		SRvnaCFMfSedoikjpJwiNkznEQTTA = new List<McAjpDVOvHGeSJiXqSDeUWLrXJOWA>();
	}

	public virtual void VjAsrMmqtBQGyiaDoCAtTEoSXbpx(McAjpDVOvHGeSJiXqSDeUWLrXJOWA P_0)
	{
		SRvnaCFMfSedoikjpJwiNkznEQTTA.Add(P_0);
	}

	public float kKmkfKwfgeIfRACyulEZdmLhqveXb(int P_0)
	{
		if (P_0 < 0 || P_0 >= knJHmTCsIOJFIHThJmnkCRQUUiRr.Length)
		{
			return 0f;
		}
		return svNACiRCQoXLZxpjnNcKMXgJWufQ(knJHmTCsIOJFIHThJmnkCRQUUiRr[P_0].iyEOQWrRdEtYBnxuqepHuHzxmnFx);
	}

	public int FLbHrGSdLcltVBrKSDPsaRByGLLe(int P_0)
	{
		if (P_0 < 0 || P_0 >= knJHmTCsIOJFIHThJmnkCRQUUiRr.Length)
		{
			return 0;
		}
		return (int)knJHmTCsIOJFIHThJmnkCRQUUiRr[P_0].JZDochzZCTJtsWtJtPxIeIlTCyPN;
	}

	public virtual void jeQrFCcgvuoiIupIHUsvPyireuP()
	{
		if (!EzmvMjKzryTRAHzTRCmQOBcFwGxx)
		{
			EzmvMjKzryTRAHzTRCmQOBcFwGxx = true;
			knJHmTCsIOJFIHThJmnkCRQUUiRr = SRvnaCFMfSedoikjpJwiNkznEQTTA.ToArray();
			SRvnaCFMfSedoikjpJwiNkznEQTTA = null;
		}
	}

	private float svNACiRCQoXLZxpjnNcKMXgJWufQ(int P_0)
	{
		if (P_0 == 0)
		{
			return 0f;
		}
		return MathTools.Clamp((float)MathTools.Abs(P_0) / 65535f * (float)MathTools.Sign(P_0), -1f, 1f);
	}
}
