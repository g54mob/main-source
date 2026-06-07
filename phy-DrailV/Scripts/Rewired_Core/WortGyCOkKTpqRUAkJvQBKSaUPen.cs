using System;
using Rewired;
using Rewired.Interfaces;
using Rewired.Utils.Classes.Utility;

internal sealed class WortGyCOkKTpqRUAkJvQBKSaUPen : IDisposable, IControllerElementTarget, IPoolableObject, IPoolableObject_Internal
{
	[Serializable]
	private sealed class pWTKBuFsWICuDuBCGYsmBBcThBeaA
	{
		public static readonly pWTKBuFsWICuDuBCGYsmBBcThBeaA _003C_003E9 = new pWTKBuFsWICuDuBCGYsmBBcThBeaA();

		public static Func<WortGyCOkKTpqRUAkJvQBKSaUPen> _003C_003E9__30_0;

		internal WortGyCOkKTpqRUAkJvQBKSaUPen YWcSkFNfgOCmdTRIeerfdicyyqBBA()
		{
			return ZthtDKCPytXmopXrdcSWOpqCJOGs();
		}
	}

	private static ObjectPool<WortGyCOkKTpqRUAkJvQBKSaUPen> dKyhpwaBiPBJYsHjufxZaCLnEnKqA;

	private Controller SHugpoIFWkCnojYBXWjOaAoAAYCW;

	private int hkJhlFMpiETPSIkMyOmVuFxkJKlT;

	private AxisRange PpBKvDDuwSJgSbXdRraQGlHTKPPc;

	private IObjectPool vxIblCcKaTjoeLItQrZZCfsxBbFn;

	private bool wFtxnVROnubhehGUBaPWAtQsiPAD;

	public int elementIdentifierId => hkJhlFMpiETPSIkMyOmVuFxkJKlT;

	public AxisRange axisRange => PpBKvDDuwSJgSbXdRraQGlHTKPPc;

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
			if (SHugpoIFWkCnojYBXWjOaAoAAYCW == null)
			{
				return string.Empty;
			}
			ControllerElementIdentifier elementIdentifierById = SHugpoIFWkCnojYBXWjOaAoAAYCW.GetElementIdentifierById(hkJhlFMpiETPSIkMyOmVuFxkJKlT);
			if (elementIdentifierById == null)
			{
				return string.Empty;
			}
			Controller.Element elementById = SHugpoIFWkCnojYBXWjOaAoAAYCW.GetElementById(hkJhlFMpiETPSIkMyOmVuFxkJKlT);
			if (elementById == null)
			{
				return string.Empty;
			}
			return elementIdentifierById.GetDisplayName(elementById.type, PpBKvDDuwSJgSbXdRraQGlHTKPPc);
		}
	}

	public Controller controller => SHugpoIFWkCnojYBXWjOaAoAAYCW;

	public Controller.Element element
	{
		get
		{
			if (SHugpoIFWkCnojYBXWjOaAoAAYCW == null)
			{
				return null;
			}
			if (SHugpoIFWkCnojYBXWjOaAoAAYCW.GetElementIdentifierById(hkJhlFMpiETPSIkMyOmVuFxkJKlT) == null)
			{
				return null;
			}
			return SHugpoIFWkCnojYBXWjOaAoAAYCW.GetElementById(hkJhlFMpiETPSIkMyOmVuFxkJKlT);
		}
	}

	public ControllerElementIdentifier RoTFBzhVfVaytqDUsufnSrdCSCQSA
	{
		get
		{
			if (SHugpoIFWkCnojYBXWjOaAoAAYCW == null)
			{
				return null;
			}
			return SHugpoIFWkCnojYBXWjOaAoAAYCW.GetElementIdentifierById(hkJhlFMpiETPSIkMyOmVuFxkJKlT);
		}
	}

	IObjectPool IPoolableObject_Internal.pool
	{
		get
		{
			return vxIblCcKaTjoeLItQrZZCfsxBbFn;
		}
		set
		{
			vxIblCcKaTjoeLItQrZZCfsxBbFn = objectPool;
		}
	}

	internal WortGyCOkKTpqRUAkJvQBKSaUPen(Controller P_0, int P_1, AxisRange P_2)
	{
		SHugpoIFWkCnojYBXWjOaAoAAYCW = P_0;
		hkJhlFMpiETPSIkMyOmVuFxkJKlT = P_1;
		PpBKvDDuwSJgSbXdRraQGlHTKPPc = P_2;
	}

	internal void IqWUQdetEUgWKmOIFRihysPfqZgC(ControllerElementTarget P_0)
	{
		SHugpoIFWkCnojYBXWjOaAoAAYCW = P_0.controller;
		hkJhlFMpiETPSIkMyOmVuFxkJKlT = P_0.elementIdentifierId;
		PpBKvDDuwSJgSbXdRraQGlHTKPPc = P_0.axisRange;
	}

	internal void IqWUQdetEUgWKmOIFRihysPfqZgC(IControllerElementTarget P_0)
	{
		SHugpoIFWkCnojYBXWjOaAoAAYCW = P_0.controller;
		hkJhlFMpiETPSIkMyOmVuFxkJKlT = P_0.elementIdentifierId;
		PpBKvDDuwSJgSbXdRraQGlHTKPPc = P_0.axisRange;
	}

	internal void IqWUQdetEUgWKmOIFRihysPfqZgC(WortGyCOkKTpqRUAkJvQBKSaUPen P_0)
	{
		IqWUQdetEUgWKmOIFRihysPfqZgC((IControllerElementTarget)P_0);
	}

	private void TjONofIJkpKSnSTscwQWIahBrUal()
	{
		SHugpoIFWkCnojYBXWjOaAoAAYCW = null;
		hkJhlFMpiETPSIkMyOmVuFxkJKlT = -1;
		PpBKvDDuwSJgSbXdRraQGlHTKPPc = AxisRange.Full;
	}

	void IPoolableObject_Internal.Clear()
	{
		//ILSpy generated this explicit interface implementation from .override directive in TjONofIJkpKSnSTscwQWIahBrUal
		this.TjONofIJkpKSnSTscwQWIahBrUal();
	}

	void IPoolableObject.Return()
	{
		if (vxIblCcKaTjoeLItQrZZCfsxBbFn != null)
		{
			vxIblCcKaTjoeLItQrZZCfsxBbFn.Return(this);
		}
	}

	internal static WortGyCOkKTpqRUAkJvQBKSaUPen lQlAsdadwIrBBlEHFJjzwWQNAhrm()
	{
		if (dKyhpwaBiPBJYsHjufxZaCLnEnKqA == null)
		{
			dKyhpwaBiPBJYsHjufxZaCLnEnKqA = new ObjectPool<WortGyCOkKTpqRUAkJvQBKSaUPen>(pWTKBuFsWICuDuBCGYsmBBcThBeaA._003C_003E9.YWcSkFNfgOCmdTRIeerfdicyyqBBA);
		}
		return dKyhpwaBiPBJYsHjufxZaCLnEnKqA.Get();
	}

	internal static WortGyCOkKTpqRUAkJvQBKSaUPen lQlAsdadwIrBBlEHFJjzwWQNAhrm(ControllerElementTarget P_0)
	{
		WortGyCOkKTpqRUAkJvQBKSaUPen wortGyCOkKTpqRUAkJvQBKSaUPen = lQlAsdadwIrBBlEHFJjzwWQNAhrm();
		wortGyCOkKTpqRUAkJvQBKSaUPen.IqWUQdetEUgWKmOIFRihysPfqZgC(P_0);
		return wortGyCOkKTpqRUAkJvQBKSaUPen;
	}

	internal static void mChfdSJRxqNkGWGYLQKdLjonbMYVA(WortGyCOkKTpqRUAkJvQBKSaUPen P_0)
	{
		if (P_0 != null && dKyhpwaBiPBJYsHjufxZaCLnEnKqA != null)
		{
			dKyhpwaBiPBJYsHjufxZaCLnEnKqA.Return(P_0);
		}
	}

	internal static WortGyCOkKTpqRUAkJvQBKSaUPen ZthtDKCPytXmopXrdcSWOpqCJOGs()
	{
		return new WortGyCOkKTpqRUAkJvQBKSaUPen(null, -1, AxisRange.Full);
	}

	void IDisposable.Dispose()
	{
		IqfGwssNeOuHmhjiKHsCvtuZOnrU(true);
		GC.SuppressFinalize(this);
	}

	protected void ANNKHugeDGzbmYmFyhvbuPpYVvpn()
	{
		try
		{
			IqfGwssNeOuHmhjiKHsCvtuZOnrU(false);
		}
		finally
		{
			base.Finalize();
		}
	}

	private void IqfGwssNeOuHmhjiKHsCvtuZOnrU(bool P_0)
	{
		if (!wFtxnVROnubhehGUBaPWAtQsiPAD)
		{
			if (P_0)
			{
				((IPoolableObject)this).Return();
			}
			wFtxnVROnubhehGUBaPWAtQsiPAD = true;
		}
	}
}
