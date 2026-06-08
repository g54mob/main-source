using System;
using System.Runtime.CompilerServices;
using Rewired;
using Rewired.Interfaces;
using Rewired.Utils.Classes.Utility;

internal sealed class TtePFCKBdNmQRluqYJdgMTWVuTZ : IDisposable, IControllerElementTarget, IPoolableObject, IPoolableObject_Internal
{
	private static ObjectPool<TtePFCKBdNmQRluqYJdgMTWVuTZ> cOjgMlcdPMabGERTKvvAJNvSKbV;

	private Controller PQxjKAQNRjWZaZhctvIytmcdtVz;

	private int yBWjkrHKbDlkjegyONinAthRElAh;

	private AxisRange ULUBoZXZbPaLHXiblpGEJyjatZk;

	private IObjectPool sJNccIozQGDHbpDWmNnnRmwMMsK;

	private bool xRygqjRmTtURDPiwlgMmFcdNBrr;

	[CompilerGenerated]
	private static Func<TtePFCKBdNmQRluqYJdgMTWVuTZ> TblfxMGFSPowbRLCNkMeDtWBtrTm;

	public int elementIdentifierId => yBWjkrHKbDlkjegyONinAthRElAh;

	public AxisRange axisRange => ULUBoZXZbPaLHXiblpGEJyjatZk;

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
			if (PQxjKAQNRjWZaZhctvIytmcdtVz == null)
			{
				goto IL_0008;
			}
			ControllerElementIdentifier elementIdentifierById = PQxjKAQNRjWZaZhctvIytmcdtVz.GetElementIdentifierById(yBWjkrHKbDlkjegyONinAthRElAh);
			int num = -475814016;
			goto IL_000d;
			IL_000d:
			Controller.Element elementById = default(Controller.Element);
			while (true)
			{
				switch (num ^ -475814015)
				{
				case 0:
					break;
				case 3:
					return string.Empty;
				case 1:
					if (elementIdentifierById != null)
					{
						elementById = PQxjKAQNRjWZaZhctvIytmcdtVz.GetElementById(yBWjkrHKbDlkjegyONinAthRElAh);
						num = -475814013;
					}
					else
					{
						num = -475814014;
					}
					continue;
				case 4:
					return string.Empty;
				default:
					if (elementById == null)
					{
						return string.Empty;
					}
					return elementIdentifierById.GetDisplayName(elementById.type, ULUBoZXZbPaLHXiblpGEJyjatZk);
				}
				break;
			}
			goto IL_0008;
			IL_0008:
			num = -475814011;
			goto IL_000d;
		}
	}

	public Controller controller => PQxjKAQNRjWZaZhctvIytmcdtVz;

	public Controller.Element element
	{
		get
		{
			if (PQxjKAQNRjWZaZhctvIytmcdtVz == null)
			{
				return null;
			}
			ControllerElementIdentifier elementIdentifierById = PQxjKAQNRjWZaZhctvIytmcdtVz.GetElementIdentifierById(yBWjkrHKbDlkjegyONinAthRElAh);
			if (elementIdentifierById == null)
			{
				return null;
			}
			return PQxjKAQNRjWZaZhctvIytmcdtVz.GetElementById(yBWjkrHKbDlkjegyONinAthRElAh);
		}
	}

	public ControllerElementIdentifier elementIdentifier
	{
		get
		{
			if (PQxjKAQNRjWZaZhctvIytmcdtVz == null)
			{
				return null;
			}
			return PQxjKAQNRjWZaZhctvIytmcdtVz.GetElementIdentifierById(yBWjkrHKbDlkjegyONinAthRElAh);
		}
	}

	IObjectPool IPoolableObject_Internal.pool
	{
		get
		{
			return sJNccIozQGDHbpDWmNnnRmwMMsK;
		}
		set
		{
			sJNccIozQGDHbpDWmNnnRmwMMsK = value;
		}
	}

	internal TtePFCKBdNmQRluqYJdgMTWVuTZ(Controller controller, int elementIdentifierId, AxisRange axisRange)
	{
		PQxjKAQNRjWZaZhctvIytmcdtVz = controller;
		yBWjkrHKbDlkjegyONinAthRElAh = elementIdentifierId;
		ULUBoZXZbPaLHXiblpGEJyjatZk = axisRange;
	}

	internal void FMjbXwujmHnZzQbodRBJzieOPHZ(ControllerElementTarget P_0)
	{
		PQxjKAQNRjWZaZhctvIytmcdtVz = P_0.controller;
		yBWjkrHKbDlkjegyONinAthRElAh = P_0.elementIdentifierId;
		ULUBoZXZbPaLHXiblpGEJyjatZk = P_0.axisRange;
	}

	internal void FMjbXwujmHnZzQbodRBJzieOPHZ(IControllerElementTarget P_0)
	{
		PQxjKAQNRjWZaZhctvIytmcdtVz = P_0.controller;
		yBWjkrHKbDlkjegyONinAthRElAh = P_0.elementIdentifierId;
		ULUBoZXZbPaLHXiblpGEJyjatZk = P_0.axisRange;
	}

	internal void FMjbXwujmHnZzQbodRBJzieOPHZ(TtePFCKBdNmQRluqYJdgMTWVuTZ P_0)
	{
		FMjbXwujmHnZzQbodRBJzieOPHZ((IControllerElementTarget)P_0);
	}

	private void WeZCRVETlynHOwGCSyPiPGlyJQX()
	{
		PQxjKAQNRjWZaZhctvIytmcdtVz = null;
		yBWjkrHKbDlkjegyONinAthRElAh = -1;
		ULUBoZXZbPaLHXiblpGEJyjatZk = AxisRange.Full;
	}

	void IPoolableObject_Internal.Clear()
	{
		//ILSpy generated this explicit interface implementation from .override directive in WeZCRVETlynHOwGCSyPiPGlyJQX
		this.WeZCRVETlynHOwGCSyPiPGlyJQX();
	}

	private void zbsHpOrtRoAUnAglhquhBWpqgyVV()
	{
		if (sJNccIozQGDHbpDWmNnnRmwMMsK == null)
		{
			while (true)
			{
				switch (-159477710 ^ -159477712)
				{
				case 0:
					continue;
				case 2:
					return;
				}
				break;
			}
		}
		sJNccIozQGDHbpDWmNnnRmwMMsK.Return(this);
	}

	void IPoolableObject.Return()
	{
		//ILSpy generated this explicit interface implementation from .override directive in zbsHpOrtRoAUnAglhquhBWpqgyVV
		this.zbsHpOrtRoAUnAglhquhBWpqgyVV();
	}

	internal static TtePFCKBdNmQRluqYJdgMTWVuTZ axyDWBaevBEdcNutlzYJvrYkUXO()
	{
		if (cOjgMlcdPMabGERTKvvAJNvSKbV == null)
		{
			if (TblfxMGFSPowbRLCNkMeDtWBtrTm == null)
			{
				goto IL_000e;
			}
			goto IL_0048;
		}
		goto IL_005e;
		IL_005e:
		return cOjgMlcdPMabGERTKvvAJNvSKbV.Get();
		IL_000e:
		int num = -988518928;
		goto IL_0013;
		IL_0013:
		while (true)
		{
			switch (num ^ -988518925)
			{
			case 2:
				break;
			case 3:
				TblfxMGFSPowbRLCNkMeDtWBtrTm = () => WDwRGsIphwHRFBDBHPIyGNmfHrtw();
				num = -988518925;
				continue;
			case 0:
				goto IL_0048;
			default:
				goto IL_005e;
			}
			break;
		}
		goto IL_000e;
		IL_0048:
		cOjgMlcdPMabGERTKvvAJNvSKbV = new ObjectPool<TtePFCKBdNmQRluqYJdgMTWVuTZ>(TblfxMGFSPowbRLCNkMeDtWBtrTm);
		num = -988518926;
		goto IL_0013;
	}

	internal static TtePFCKBdNmQRluqYJdgMTWVuTZ axyDWBaevBEdcNutlzYJvrYkUXO(ControllerElementTarget P_0)
	{
		TtePFCKBdNmQRluqYJdgMTWVuTZ ttePFCKBdNmQRluqYJdgMTWVuTZ = axyDWBaevBEdcNutlzYJvrYkUXO();
		ttePFCKBdNmQRluqYJdgMTWVuTZ.FMjbXwujmHnZzQbodRBJzieOPHZ(P_0);
		return ttePFCKBdNmQRluqYJdgMTWVuTZ;
	}

	internal static void nUqfikRMgdyVbwPofFMThwkULhhr(TtePFCKBdNmQRluqYJdgMTWVuTZ P_0)
	{
		if (P_0 == null)
		{
			return;
		}
		if (cOjgMlcdPMabGERTKvvAJNvSKbV == null)
		{
			while (true)
			{
				switch (-1839641003 ^ -1839641001)
				{
				case 0:
					continue;
				case 2:
					return;
				}
				break;
			}
		}
		cOjgMlcdPMabGERTKvvAJNvSKbV.Return(P_0);
	}

	internal static TtePFCKBdNmQRluqYJdgMTWVuTZ WDwRGsIphwHRFBDBHPIyGNmfHrtw()
	{
		return new TtePFCKBdNmQRluqYJdgMTWVuTZ(null, -1, AxisRange.Full);
	}

	void IDisposable.Dispose()
	{
		XUyPrOkreNDOTTMFamEakBsuIHM(true);
		GC.SuppressFinalize(this);
	}

	~TtePFCKBdNmQRluqYJdgMTWVuTZ()
	{
		XUyPrOkreNDOTTMFamEakBsuIHM(false);
	}

	private void XUyPrOkreNDOTTMFamEakBsuIHM(bool P_0)
	{
		if (xRygqjRmTtURDPiwlgMmFcdNBrr)
		{
			return;
		}
		while (true)
		{
			int num;
			if (P_0)
			{
				((IPoolableObject)this).Return();
				num = 596913591;
				goto IL_000e;
			}
			goto IL_003b;
			IL_000e:
			while (true)
			{
				switch (num ^ 0x23942DB4)
				{
				case 2:
					num = 596913589;
					continue;
				default:
					return;
				case 1:
					break;
				case 3:
					goto IL_003b;
				case 0:
					return;
				}
				break;
			}
			continue;
			IL_003b:
			xRygqjRmTtURDPiwlgMmFcdNBrr = true;
			num = 596913588;
			goto IL_000e;
		}
	}

	[CompilerGenerated]
	private static TtePFCKBdNmQRluqYJdgMTWVuTZ szlFpefEgIkbeyDsENapcSJQAtcB()
	{
		return WDwRGsIphwHRFBDBHPIyGNmfHrtw();
	}
}
