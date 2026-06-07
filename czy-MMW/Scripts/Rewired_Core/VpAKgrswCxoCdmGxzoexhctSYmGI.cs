using System;
using Rewired;
using Rewired.Interfaces;
using Rewired.Utils.Classes.Utility;

internal sealed class VpAKgrswCxoCdmGxzoexhctSYmGI : IControllerElementTarget, IPoolableObject_Internal, IPoolableObject, IDisposable
{
	[Serializable]
	private sealed class xgGnlvsATQSMNCDtkcoIJWXTCJVFA
	{
		public static readonly xgGnlvsATQSMNCDtkcoIJWXTCJVFA _003C_003E9 = new xgGnlvsATQSMNCDtkcoIJWXTCJVFA();

		public static Func<VpAKgrswCxoCdmGxzoexhctSYmGI> _003C_003E9__30_0;

		internal VpAKgrswCxoCdmGxzoexhctSYmGI rYWBePduPjdlJDHTElOlWJWxqCZOA()
		{
			return BAgYxiMqyGCojQPffpTNQctlDIrW();
		}
	}

	private static ObjectPool<VpAKgrswCxoCdmGxzoexhctSYmGI> OzQteoGsopXyAdVGtJTHVZjeMelD;

	private Controller mZDgKHAGkpPyzOqmzprMcjBHpiyIA;

	private int jvDiXwWeKoopjhDHaURtmnNiRsYp;

	private AxisRange JrmHBBoAlTDaJdfrEMXDQFEfcpIK;

	private IObjectPool YXGcHKRzDlvpnfQDJDjODZdWPgsj;

	private bool pVadeaOuVvdvNGVSMBzsGAHCViBs;

	int IControllerElementTarget.elementIdentifierId => jvDiXwWeKoopjhDHaURtmnNiRsYp;

	AxisRange IControllerElementTarget.axisRange => JrmHBBoAlTDaJdfrEMXDQFEfcpIK;

	bool IControllerElementTarget.hasTarget => ((IControllerElementTarget)this).element != null;

	ControllerElementType IControllerElementTarget.elementType
	{
		get
		{
			if (((IControllerElementTarget)this).element == null)
			{
				return ControllerElementType.Axis;
			}
			return ((IControllerElementTarget)this).element.type;
		}
	}

	string IControllerElementTarget.descriptiveName
	{
		get
		{
			if (mZDgKHAGkpPyzOqmzprMcjBHpiyIA == null)
			{
				return string.Empty;
			}
			ControllerElementIdentifier elementIdentifierById = mZDgKHAGkpPyzOqmzprMcjBHpiyIA.GetElementIdentifierById(jvDiXwWeKoopjhDHaURtmnNiRsYp);
			if (elementIdentifierById == null)
			{
				return string.Empty;
			}
			Controller.Element elementById = mZDgKHAGkpPyzOqmzprMcjBHpiyIA.GetElementById(jvDiXwWeKoopjhDHaURtmnNiRsYp);
			if (elementById == null)
			{
				return string.Empty;
			}
			return elementIdentifierById.GetDisplayName(elementById.type, JrmHBBoAlTDaJdfrEMXDQFEfcpIK);
		}
	}

	Controller IControllerElementTarget.controller => mZDgKHAGkpPyzOqmzprMcjBHpiyIA;

	Controller.Element IControllerElementTarget.element
	{
		get
		{
			if (mZDgKHAGkpPyzOqmzprMcjBHpiyIA == null)
			{
				return null;
			}
			if (mZDgKHAGkpPyzOqmzprMcjBHpiyIA.GetElementIdentifierById(jvDiXwWeKoopjhDHaURtmnNiRsYp) == null)
			{
				return null;
			}
			return mZDgKHAGkpPyzOqmzprMcjBHpiyIA.GetElementById(jvDiXwWeKoopjhDHaURtmnNiRsYp);
		}
	}

	public ControllerElementIdentifier NUsbfGFilMtbtCmyXRvYFhzsChXHA
	{
		get
		{
			if (mZDgKHAGkpPyzOqmzprMcjBHpiyIA == null)
			{
				return null;
			}
			return mZDgKHAGkpPyzOqmzprMcjBHpiyIA.GetElementIdentifierById(jvDiXwWeKoopjhDHaURtmnNiRsYp);
		}
	}

	IObjectPool IPoolableObject_Internal.pool
	{
		get
		{
			return YXGcHKRzDlvpnfQDJDjODZdWPgsj;
		}
		set
		{
			YXGcHKRzDlvpnfQDJDjODZdWPgsj = value;
		}
	}

	internal VpAKgrswCxoCdmGxzoexhctSYmGI(Controller P_0, int P_1, AxisRange P_2)
	{
		mZDgKHAGkpPyzOqmzprMcjBHpiyIA = P_0;
		jvDiXwWeKoopjhDHaURtmnNiRsYp = P_1;
		JrmHBBoAlTDaJdfrEMXDQFEfcpIK = P_2;
	}

	internal void BMDRmdZSleNNTmFobqxUHpzIIoKg(ControllerElementTarget P_0)
	{
		mZDgKHAGkpPyzOqmzprMcjBHpiyIA = P_0.controller;
		jvDiXwWeKoopjhDHaURtmnNiRsYp = P_0.elementIdentifierId;
		JrmHBBoAlTDaJdfrEMXDQFEfcpIK = P_0.axisRange;
	}

	internal void DZibDbBuVFTCwfpSdKaeMdJzJtjSA(IControllerElementTarget P_0)
	{
		mZDgKHAGkpPyzOqmzprMcjBHpiyIA = P_0.controller;
		jvDiXwWeKoopjhDHaURtmnNiRsYp = P_0.elementIdentifierId;
		JrmHBBoAlTDaJdfrEMXDQFEfcpIK = P_0.axisRange;
	}

	internal void hnvNVvVqNqQwOMMahkivtiRXBrKP(VpAKgrswCxoCdmGxzoexhctSYmGI P_0)
	{
		DZibDbBuVFTCwfpSdKaeMdJzJtjSA(P_0);
	}

	void IPoolableObject_Internal.Clear()
	{
		mZDgKHAGkpPyzOqmzprMcjBHpiyIA = null;
		jvDiXwWeKoopjhDHaURtmnNiRsYp = -1;
		JrmHBBoAlTDaJdfrEMXDQFEfcpIK = AxisRange.Full;
	}

	void IPoolableObject.Return()
	{
		if (YXGcHKRzDlvpnfQDJDjODZdWPgsj != null)
		{
			YXGcHKRzDlvpnfQDJDjODZdWPgsj.Return(this);
		}
	}

	internal static VpAKgrswCxoCdmGxzoexhctSYmGI EpLgzXsdYMGrXzqFwUjEeguVcIkIA()
	{
		if (OzQteoGsopXyAdVGtJTHVZjeMelD == null)
		{
			OzQteoGsopXyAdVGtJTHVZjeMelD = new ObjectPool<VpAKgrswCxoCdmGxzoexhctSYmGI>(xgGnlvsATQSMNCDtkcoIJWXTCJVFA._003C_003E9.rYWBePduPjdlJDHTElOlWJWxqCZOA);
		}
		return OzQteoGsopXyAdVGtJTHVZjeMelD.Get();
	}

	internal static VpAKgrswCxoCdmGxzoexhctSYmGI xDAKHQNoHKFqiySCGMtHCjfpzmMo(ControllerElementTarget P_0)
	{
		VpAKgrswCxoCdmGxzoexhctSYmGI vpAKgrswCxoCdmGxzoexhctSYmGI = EpLgzXsdYMGrXzqFwUjEeguVcIkIA();
		vpAKgrswCxoCdmGxzoexhctSYmGI.BMDRmdZSleNNTmFobqxUHpzIIoKg(P_0);
		return vpAKgrswCxoCdmGxzoexhctSYmGI;
	}

	internal static void wzXUUXuVeUiCeyrUltjgkXWqnwcc(VpAKgrswCxoCdmGxzoexhctSYmGI P_0)
	{
		if (P_0 != null && OzQteoGsopXyAdVGtJTHVZjeMelD != null)
		{
			OzQteoGsopXyAdVGtJTHVZjeMelD.Return(P_0);
		}
	}

	internal static VpAKgrswCxoCdmGxzoexhctSYmGI BAgYxiMqyGCojQPffpTNQctlDIrW()
	{
		return new VpAKgrswCxoCdmGxzoexhctSYmGI(null, -1, AxisRange.Full);
	}

	void IDisposable.Dispose()
	{
		fQeXoNzVgbWZzcdFfIXfJGJJlSJo(true);
		GC.SuppressFinalize(this);
	}

	protected void JJXOpkrJAScEIyErbLBDuiVAgSWm()
	{
		try
		{
			fQeXoNzVgbWZzcdFfIXfJGJJlSJo(false);
		}
		finally
		{
			base.Finalize();
		}
	}

	private void fQeXoNzVgbWZzcdFfIXfJGJJlSJo(bool P_0)
	{
		if (!pVadeaOuVvdvNGVSMBzsGAHCViBs)
		{
			if (P_0)
			{
				((IPoolableObject)this).Return();
			}
			pVadeaOuVvdvNGVSMBzsGAHCViBs = true;
		}
	}
}
