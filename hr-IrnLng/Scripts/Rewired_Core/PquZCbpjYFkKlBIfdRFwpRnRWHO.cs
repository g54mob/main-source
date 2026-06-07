using Rewired;
using Rewired.Utils;

internal class PquZCbpjYFkKlBIfdRFwpRnRWHO
{
	private class NrhTHvasnKNuaFvRpMFUAHkKdoB
	{
		public bool NosALOCJZWSRRlLkYnXjziASvDO;

		public bool NOPQVhqkBWMrvrfDpfQaBWDBYUI;

		public double qrbwLYJjtGFdpgsrupVlChDHstaj;

		public bool cbNvXklQjimXaRAbfEFPfqqoneTr;

		public void VcHhfbFqwxAmqhwBHKVJpDjlfufe()
		{
			NosALOCJZWSRRlLkYnXjziASvDO = false;
			cbNvXklQjimXaRAbfEFPfqqoneTr = false;
		}
	}

	private const int lRVQfPHPGtDgSWjWZSpkMmZSGDv = 2;

	private bool rDXFGACXzNvmEuFurHYAqqwyQzh;

	private bool FgxTivEavZGuUBCHNsKPEijgyxC;

	private bool IuLUQAhofOOuwNpKdqVNWXINDWQ;

	private float vPeAQNbxKkDxFkAcxXjfOSZngYHa;

	private readonly NrhTHvasnKNuaFvRpMFUAHkKdoB[] GyzrkAoCIbzHSlYtSiabBjCgruu;

	private bool PNcmAQOHdRVjSnpwmBUJbJzhciwJ;

	private bool qrmEienrZQiraaNmshZjAigNatnd;

	public bool doublePressHold => rDXFGACXzNvmEuFurHYAqqwyQzh;

	public bool doublePressUp
	{
		get
		{
			if (!rDXFGACXzNvmEuFurHYAqqwyQzh)
			{
				return FgxTivEavZGuUBCHNsKPEijgyxC;
			}
			return false;
		}
	}

	public bool doublePressDown
	{
		get
		{
			if (rDXFGACXzNvmEuFurHYAqqwyQzh)
			{
				return !FgxTivEavZGuUBCHNsKPEijgyxC;
			}
			return false;
		}
	}

	public float speed => vPeAQNbxKkDxFkAcxXjfOSZngYHa;

	public bool singlePressHold => qrmEienrZQiraaNmshZjAigNatnd;

	public bool singlePressDown
	{
		get
		{
			if (qrmEienrZQiraaNmshZjAigNatnd)
			{
				return !PNcmAQOHdRVjSnpwmBUJbJzhciwJ;
			}
			return false;
		}
	}

	public bool singlePressUp
	{
		get
		{
			if (!qrmEienrZQiraaNmshZjAigNatnd)
			{
				return PNcmAQOHdRVjSnpwmBUJbJzhciwJ;
			}
			return false;
		}
	}

	public PquZCbpjYFkKlBIfdRFwpRnRWHO(float speed)
	{
		vPeAQNbxKkDxFkAcxXjfOSZngYHa = speed;
		GyzrkAoCIbzHSlYtSiabBjCgruu = new NrhTHvasnKNuaFvRpMFUAHkKdoB[2];
		ArrayTools.Populate(GyzrkAoCIbzHSlYtSiabBjCgruu);
	}

	public void iAnBBfDdWbgOiFHwNWqxFDtiXzYA(float P_0, bool P_1, bool P_2)
	{
		bool flag = ((!IuLUQAhofOOuwNpKdqVNWXINDWQ) ? P_1 : P_2);
		if (P_0 != speed)
		{
			NvdAKrQlqPLyYWDQMUQclkSncjJ(P_0);
		}
		PNcmAQOHdRVjSnpwmBUJbJzhciwJ = qrmEienrZQiraaNmshZjAigNatnd;
		FgxTivEavZGuUBCHNsKPEijgyxC = rDXFGACXzNvmEuFurHYAqqwyQzh;
		if (!rDXFGACXzNvmEuFurHYAqqwyQzh)
		{
			if (!flag && PNcmAQOHdRVjSnpwmBUJbJzhciwJ)
			{
				qrmEienrZQiraaNmshZjAigNatnd = false;
			}
			for (int num = 1; num >= 0; num--)
			{
				if (GyzrkAoCIbzHSlYtSiabBjCgruu[num].NosALOCJZWSRRlLkYnXjziASvDO && GyzrkAoCIbzHSlYtSiabBjCgruu[num].NOPQVhqkBWMrvrfDpfQaBWDBYUI && !GyzrkAoCIbzHSlYtSiabBjCgruu[num].cbNvXklQjimXaRAbfEFPfqqoneTr)
				{
					if (!qrmEienrZQiraaNmshZjAigNatnd && ReInput.unscaledTime - GyzrkAoCIbzHSlYtSiabBjCgruu[num].qrbwLYJjtGFdpgsrupVlChDHstaj > (double)P_0)
					{
						qrmEienrZQiraaNmshZjAigNatnd = true;
						GyzrkAoCIbzHSlYtSiabBjCgruu[num].cbNvXklQjimXaRAbfEFPfqqoneTr = true;
					}
					break;
				}
			}
		}
		if (IuLUQAhofOOuwNpKdqVNWXINDWQ == flag)
		{
			return;
		}
		IuLUQAhofOOuwNpKdqVNWXINDWQ = flag;
		if (!flag)
		{
			if (rDXFGACXzNvmEuFurHYAqqwyQzh)
			{
				rDXFGACXzNvmEuFurHYAqqwyQzh = false;
			}
			return;
		}
		if (qrmEienrZQiraaNmshZjAigNatnd)
		{
			qrmEienrZQiraaNmshZjAigNatnd = false;
		}
		double unscaledTime = ReInput.unscaledTime;
		for (int i = 0; i < 2; i++)
		{
			if (GyzrkAoCIbzHSlYtSiabBjCgruu[i].NosALOCJZWSRRlLkYnXjziASvDO && unscaledTime - GyzrkAoCIbzHSlYtSiabBjCgruu[i].qrbwLYJjtGFdpgsrupVlChDHstaj > (double)vPeAQNbxKkDxFkAcxXjfOSZngYHa)
			{
				GyzrkAoCIbzHSlYtSiabBjCgruu[i].VcHhfbFqwxAmqhwBHKVJpDjlfufe();
			}
		}
		if (!GyzrkAoCIbzHSlYtSiabBjCgruu[0].NosALOCJZWSRRlLkYnXjziASvDO)
		{
			MiscTools.Swap(ref GyzrkAoCIbzHSlYtSiabBjCgruu[0], ref GyzrkAoCIbzHSlYtSiabBjCgruu[1]);
		}
		int num2 = 0;
		for (int j = 0; j < 2; j++)
		{
			if (GyzrkAoCIbzHSlYtSiabBjCgruu[j].NosALOCJZWSRRlLkYnXjziASvDO)
			{
				num2++;
				continue;
			}
			GyzrkAoCIbzHSlYtSiabBjCgruu[j].NosALOCJZWSRRlLkYnXjziASvDO = true;
			GyzrkAoCIbzHSlYtSiabBjCgruu[j].NOPQVhqkBWMrvrfDpfQaBWDBYUI = flag;
			GyzrkAoCIbzHSlYtSiabBjCgruu[j].qrbwLYJjtGFdpgsrupVlChDHstaj = unscaledTime;
			num2++;
			break;
		}
		if (num2 >= 2)
		{
			if (!rDXFGACXzNvmEuFurHYAqqwyQzh)
			{
				rDXFGACXzNvmEuFurHYAqqwyQzh = true;
				qrmEienrZQiraaNmshZjAigNatnd = false;
			}
			for (int k = 0; k < 2; k++)
			{
				GyzrkAoCIbzHSlYtSiabBjCgruu[k].VcHhfbFqwxAmqhwBHKVJpDjlfufe();
			}
		}
	}

	public void NvdAKrQlqPLyYWDQMUQclkSncjJ(float P_0)
	{
		agvWMBoHtblzmgSmVloJbsDkfGk();
		vPeAQNbxKkDxFkAcxXjfOSZngYHa = P_0;
	}

	public void agvWMBoHtblzmgSmVloJbsDkfGk()
	{
		IuLUQAhofOOuwNpKdqVNWXINDWQ = false;
		rDXFGACXzNvmEuFurHYAqqwyQzh = false;
		qrmEienrZQiraaNmshZjAigNatnd = false;
		PNcmAQOHdRVjSnpwmBUJbJzhciwJ = false;
		for (int i = 0; i < 2; i++)
		{
			GyzrkAoCIbzHSlYtSiabBjCgruu[i].VcHhfbFqwxAmqhwBHKVJpDjlfufe();
		}
	}
}
