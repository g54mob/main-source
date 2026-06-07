using System;
using Rewired;
using Rewired.Interfaces;
using Rewired.Utils.Classes.Utility;

internal sealed class xExZPlwOYSQiIkFqHDDyWovrVnsK : IDisposable, IControllerElementTarget, IPoolableObject, IPoolableObject_Internal
{
	[Serializable]
	private sealed class NWnDcheiflcckQQNCnBFJeJwQKdvA
	{
		public static readonly NWnDcheiflcckQQNCnBFJeJwQKdvA _003C_003E9 = new NWnDcheiflcckQQNCnBFJeJwQKdvA();

		public static Func<xExZPlwOYSQiIkFqHDDyWovrVnsK> _003C_003E9__30_0;

		internal xExZPlwOYSQiIkFqHDDyWovrVnsK vgkBNWnuKYEZRuXwFwLJlNPdAuLgA()
		{
			return ckrUQVcMUnHdCWgDQIywBRRTSKOn();
		}
	}

	private static ObjectPool<xExZPlwOYSQiIkFqHDDyWovrVnsK> OhsdubaMGJRswMBVLJJvEDesghAXA;

	private Controller nEgdvbuTaiHYWdQfyyXkKnXDhOQcb;

	private int MToyChcGWGmeBbeiJGjHlICtSgbd;

	private AxisRange emLkZqjpKMMiQMkdaETOTOIMfGJq;

	private IObjectPool UGUFiZdMCNaPWOkBxXjvhLZgUrTQA;

	private bool JChPmMbeaoLOGQvosPYqDDInSiCs;

	public int elementIdentifierId => MToyChcGWGmeBbeiJGjHlICtSgbd;

	public AxisRange axisRange => emLkZqjpKMMiQMkdaETOTOIMfGJq;

	public bool hasTarget => element != null;

	public ControllerElementType elementType
	{
		get
		{
			if (element == null)
			{
				return ControllerElementType.Axis;
			}
			return element.type;
		}
	}

	public string descriptiveName
	{
		get
		{
			if (nEgdvbuTaiHYWdQfyyXkKnXDhOQcb == null)
			{
				return string.Empty;
			}
			ControllerElementIdentifier elementIdentifierById = nEgdvbuTaiHYWdQfyyXkKnXDhOQcb.GetElementIdentifierById(MToyChcGWGmeBbeiJGjHlICtSgbd);
			if (elementIdentifierById == null)
			{
				return string.Empty;
			}
			Controller.Element elementById = nEgdvbuTaiHYWdQfyyXkKnXDhOQcb.GetElementById(MToyChcGWGmeBbeiJGjHlICtSgbd);
			if (elementById == null)
			{
				return string.Empty;
			}
			return elementIdentifierById.GetDisplayName(elementById.type, emLkZqjpKMMiQMkdaETOTOIMfGJq);
		}
	}

	public Controller controller => nEgdvbuTaiHYWdQfyyXkKnXDhOQcb;

	public Controller.Element element
	{
		get
		{
			if (nEgdvbuTaiHYWdQfyyXkKnXDhOQcb == null)
			{
				return null;
			}
			if (nEgdvbuTaiHYWdQfyyXkKnXDhOQcb.GetElementIdentifierById(MToyChcGWGmeBbeiJGjHlICtSgbd) == null)
			{
				return null;
			}
			return nEgdvbuTaiHYWdQfyyXkKnXDhOQcb.GetElementById(MToyChcGWGmeBbeiJGjHlICtSgbd);
		}
	}

	public ControllerElementIdentifier iRNWSabdDLjDXepqFRBNkmOFhCUO
	{
		get
		{
			if (nEgdvbuTaiHYWdQfyyXkKnXDhOQcb == null)
			{
				return null;
			}
			return nEgdvbuTaiHYWdQfyyXkKnXDhOQcb.GetElementIdentifierById(MToyChcGWGmeBbeiJGjHlICtSgbd);
		}
	}

	IObjectPool IPoolableObject_Internal.pool
	{
		get
		{
			return UGUFiZdMCNaPWOkBxXjvhLZgUrTQA;
		}
		set
		{
			UGUFiZdMCNaPWOkBxXjvhLZgUrTQA = uGUFiZdMCNaPWOkBxXjvhLZgUrTQA;
		}
	}

	internal xExZPlwOYSQiIkFqHDDyWovrVnsK(Controller P_0, int P_1, AxisRange P_2)
	{
		nEgdvbuTaiHYWdQfyyXkKnXDhOQcb = P_0;
		MToyChcGWGmeBbeiJGjHlICtSgbd = P_1;
		emLkZqjpKMMiQMkdaETOTOIMfGJq = P_2;
	}

	internal void xIgDRHQmTOVJkRVsknhXpBHuPygR(ControllerElementTarget P_0)
	{
		nEgdvbuTaiHYWdQfyyXkKnXDhOQcb = P_0.controller;
		MToyChcGWGmeBbeiJGjHlICtSgbd = P_0.elementIdentifierId;
		emLkZqjpKMMiQMkdaETOTOIMfGJq = P_0.axisRange;
	}

	internal void xIgDRHQmTOVJkRVsknhXpBHuPygR(IControllerElementTarget P_0)
	{
		nEgdvbuTaiHYWdQfyyXkKnXDhOQcb = P_0.controller;
		MToyChcGWGmeBbeiJGjHlICtSgbd = P_0.elementIdentifierId;
		emLkZqjpKMMiQMkdaETOTOIMfGJq = P_0.axisRange;
	}

	internal void xIgDRHQmTOVJkRVsknhXpBHuPygR(xExZPlwOYSQiIkFqHDDyWovrVnsK P_0)
	{
		xIgDRHQmTOVJkRVsknhXpBHuPygR((IControllerElementTarget)P_0);
	}

	private void gSGPOkiSYxmzVlkCHRUqPJMSLrwM()
	{
		nEgdvbuTaiHYWdQfyyXkKnXDhOQcb = null;
		MToyChcGWGmeBbeiJGjHlICtSgbd = -1;
		emLkZqjpKMMiQMkdaETOTOIMfGJq = AxisRange.Full;
	}

	void IPoolableObject_Internal.Clear()
	{
		//ILSpy generated this explicit interface implementation from .override directive in gSGPOkiSYxmzVlkCHRUqPJMSLrwM
		this.gSGPOkiSYxmzVlkCHRUqPJMSLrwM();
	}

	void IPoolableObject.Return()
	{
		if (UGUFiZdMCNaPWOkBxXjvhLZgUrTQA != null)
		{
			UGUFiZdMCNaPWOkBxXjvhLZgUrTQA.Return(this);
		}
	}

	internal static xExZPlwOYSQiIkFqHDDyWovrVnsK CadQRsOQEKbSlMKveBVLdGfIYlpR()
	{
		if (OhsdubaMGJRswMBVLJJvEDesghAXA == null)
		{
			OhsdubaMGJRswMBVLJJvEDesghAXA = new ObjectPool<xExZPlwOYSQiIkFqHDDyWovrVnsK>(NWnDcheiflcckQQNCnBFJeJwQKdvA._003C_003E9.vgkBNWnuKYEZRuXwFwLJlNPdAuLgA);
		}
		return OhsdubaMGJRswMBVLJJvEDesghAXA.Get();
	}

	internal static xExZPlwOYSQiIkFqHDDyWovrVnsK CadQRsOQEKbSlMKveBVLdGfIYlpR(ControllerElementTarget P_0)
	{
		xExZPlwOYSQiIkFqHDDyWovrVnsK obj = CadQRsOQEKbSlMKveBVLdGfIYlpR();
		obj.xIgDRHQmTOVJkRVsknhXpBHuPygR(P_0);
		return obj;
	}

	internal static void NttCoRtmXanRyjJwgBuTkHDytWWp(xExZPlwOYSQiIkFqHDDyWovrVnsK P_0)
	{
		if (P_0 != null && OhsdubaMGJRswMBVLJJvEDesghAXA != null)
		{
			OhsdubaMGJRswMBVLJJvEDesghAXA.Return(P_0);
		}
	}

	internal static xExZPlwOYSQiIkFqHDDyWovrVnsK ckrUQVcMUnHdCWgDQIywBRRTSKOn()
	{
		return new xExZPlwOYSQiIkFqHDDyWovrVnsK(null, -1, AxisRange.Full);
	}

	void IDisposable.Dispose()
	{
		jZtwTxQjIMBZMEAKpWMmMcJOortz(true);
		GC.SuppressFinalize(this);
	}

	protected void hQVInFWrTMOWfdrNDZJGjCGXxatd()
	{
		try
		{
			jZtwTxQjIMBZMEAKpWMmMcJOortz(false);
		}
		finally
		{
			base.Finalize();
		}
	}

	private void jZtwTxQjIMBZMEAKpWMmMcJOortz(bool P_0)
	{
		if (!JChPmMbeaoLOGQvosPYqDDInSiCs)
		{
			if (P_0)
			{
				((IPoolableObject)this).Return();
			}
			JChPmMbeaoLOGQvosPYqDDInSiCs = true;
		}
	}
}
