using System.Collections.Generic;
using Rewired.Utils;

internal class gSldsSEmupMsqVSjeuDcObuSeWgYA : ENWnDnaAhOlIoZpZqNFJUJOhEaPY
{
	private List<BwdFQrjilUxbiuArjLjEmOMRvhfH> UmgBueTiuUIaQfNAsOUsysDsDIXH;

	private BwdFQrjilUxbiuArjLjEmOMRvhfH[] ksuJyeTRhNNFyWIAIEZBfxHcCcbl;

	private bool wLOVAYdRQUWYKNnvhcEVfSNkgrud;

	public gSldsSEmupMsqVSjeuDcObuSeWgYA()
	{
		UmgBueTiuUIaQfNAsOUsysDsDIXH = new List<BwdFQrjilUxbiuArjLjEmOMRvhfH>();
	}

	public virtual void EueAeBKDnUvFrBlFCvxHLwshXiNJ(BwdFQrjilUxbiuArjLjEmOMRvhfH P_0)
	{
		UmgBueTiuUIaQfNAsOUsysDsDIXH.Add(P_0);
	}

	public float FiZcIydOFFkBDRoaLKdIbAHURWmAA(int P_0)
	{
		if (P_0 < 0 || P_0 >= ksuJyeTRhNNFyWIAIEZBfxHcCcbl.Length)
		{
			return 0f;
		}
		return kzbflRKESszijLQwFjtxETzUPBGUA(ksuJyeTRhNNFyWIAIEZBfxHcCcbl[P_0].wdGocxNvQFSyJZNPSTEJPDAVnUwO);
	}

	public int ibvalSINfXCSBsTXQnuQyzTYwSNb(int P_0)
	{
		if (P_0 < 0 || P_0 >= ksuJyeTRhNNFyWIAIEZBfxHcCcbl.Length)
		{
			return 0;
		}
		return (int)ksuJyeTRhNNFyWIAIEZBfxHcCcbl[P_0].lULddQiBvNbjBdxqWggTEtugAzueb;
	}

	public virtual void PLanBCHWJXdchBrIyVHfNPyyNgVM()
	{
		if (!wLOVAYdRQUWYKNnvhcEVfSNkgrud)
		{
			wLOVAYdRQUWYKNnvhcEVfSNkgrud = true;
			ksuJyeTRhNNFyWIAIEZBfxHcCcbl = UmgBueTiuUIaQfNAsOUsysDsDIXH.ToArray();
			UmgBueTiuUIaQfNAsOUsysDsDIXH = null;
		}
	}

	private static float kzbflRKESszijLQwFjtxETzUPBGUA(int P_0)
	{
		if (P_0 == 0)
		{
			return 0f;
		}
		return MathTools.Clamp((float)MathTools.Abs(P_0) / 65535f * (float)MathTools.Sign(P_0), -1f, 1f);
	}
}
