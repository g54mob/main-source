using System;
using System.Runtime.CompilerServices;
using Rewired;
using Rewired.Interfaces;
using Rewired.Utils.Classes.Utility;

internal sealed class RPsfaUSCQTmtficMhKUbbYyMecr : IDisposable, IControllerElementTarget, IPoolableObject, IPoolableObject_Internal
{
	private static ObjectPool<RPsfaUSCQTmtficMhKUbbYyMecr> eshfMCcaQYQWTRJfjmKqgcdkXWHR;

	private Controller HUdfNKdOgxfoxjMZAKUlkQYPszXh;

	private int wyOUtAQIXRMHfdYotPsXMPVUbwu;

	private AxisRange ObWitXNhWFZMnOJBWvYTcBBfVnG;

	private IObjectPool oQJBQmusEWAvdHgvPBkmIuGgRYSh;

	private bool vsurYtRlepcrpAzAENwjqjJEZPT;

	[CompilerGenerated]
	private static Func<RPsfaUSCQTmtficMhKUbbYyMecr> PkdHFYJlZLMiTCimwpAnCiFWpZz;

	public int elementIdentifierId
	{
		get
		{
			return wyOUtAQIXRMHfdYotPsXMPVUbwu;
		}
	}

	public AxisRange axisRange
	{
		get
		{
			return ObWitXNhWFZMnOJBWvYTcBBfVnG;
		}
	}

	public bool hasTarget
	{
		get
		{
			return element != null;
		}
	}

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
			if (HUdfNKdOgxfoxjMZAKUlkQYPszXh == null)
			{
				goto IL_0008;
			}
			ControllerElementIdentifier elementIdentifierById = HUdfNKdOgxfoxjMZAKUlkQYPszXh.GetElementIdentifierById(wyOUtAQIXRMHfdYotPsXMPVUbwu);
			if (elementIdentifierById == null)
			{
				return string.Empty;
			}
			Controller.Element elementById = HUdfNKdOgxfoxjMZAKUlkQYPszXh.GetElementById(wyOUtAQIXRMHfdYotPsXMPVUbwu);
			int num;
			if (elementById == null)
			{
				num = 125476600;
				goto IL_000d;
			}
			return elementIdentifierById.GetDisplayName(elementById.type, ObWitXNhWFZMnOJBWvYTcBBfVnG);
			IL_000d:
			switch (num ^ 0x77A9EF8)
			{
			case 2:
				break;
			case 1:
				return string.Empty;
			default:
				return string.Empty;
			}
			goto IL_0008;
			IL_0008:
			num = 125476601;
			goto IL_000d;
		}
	}

	public Controller controller
	{
		get
		{
			return HUdfNKdOgxfoxjMZAKUlkQYPszXh;
		}
	}

	public Controller.Element element
	{
		get
		{
			if (HUdfNKdOgxfoxjMZAKUlkQYPszXh == null)
			{
				return null;
			}
			ControllerElementIdentifier elementIdentifierById = HUdfNKdOgxfoxjMZAKUlkQYPszXh.GetElementIdentifierById(wyOUtAQIXRMHfdYotPsXMPVUbwu);
			if (elementIdentifierById == null)
			{
				return null;
			}
			return HUdfNKdOgxfoxjMZAKUlkQYPszXh.GetElementById(wyOUtAQIXRMHfdYotPsXMPVUbwu);
		}
	}

	public ControllerElementIdentifier elementIdentifier
	{
		get
		{
			if (HUdfNKdOgxfoxjMZAKUlkQYPszXh == null)
			{
				return null;
			}
			return HUdfNKdOgxfoxjMZAKUlkQYPszXh.GetElementIdentifierById(wyOUtAQIXRMHfdYotPsXMPVUbwu);
		}
	}

	IObjectPool IPoolableObject_Internal.pool
	{
		get
		{
			return oQJBQmusEWAvdHgvPBkmIuGgRYSh;
		}
		set
		{
			oQJBQmusEWAvdHgvPBkmIuGgRYSh = value;
		}
	}

	internal RPsfaUSCQTmtficMhKUbbYyMecr(Controller controller, int elementIdentifierId, AxisRange axisRange)
	{
		HUdfNKdOgxfoxjMZAKUlkQYPszXh = controller;
		wyOUtAQIXRMHfdYotPsXMPVUbwu = elementIdentifierId;
		ObWitXNhWFZMnOJBWvYTcBBfVnG = axisRange;
	}

	internal void DzhGtommJNlpRFKUAFaKGOCHKTz(ControllerElementTarget P_0)
	{
		HUdfNKdOgxfoxjMZAKUlkQYPszXh = P_0.controller;
		wyOUtAQIXRMHfdYotPsXMPVUbwu = P_0.elementIdentifierId;
		ObWitXNhWFZMnOJBWvYTcBBfVnG = P_0.axisRange;
	}

	internal void DzhGtommJNlpRFKUAFaKGOCHKTz(IControllerElementTarget P_0)
	{
		HUdfNKdOgxfoxjMZAKUlkQYPszXh = P_0.controller;
		wyOUtAQIXRMHfdYotPsXMPVUbwu = P_0.elementIdentifierId;
		ObWitXNhWFZMnOJBWvYTcBBfVnG = P_0.axisRange;
	}

	internal void DzhGtommJNlpRFKUAFaKGOCHKTz(RPsfaUSCQTmtficMhKUbbYyMecr P_0)
	{
		DzhGtommJNlpRFKUAFaKGOCHKTz((IControllerElementTarget)P_0);
	}

	void IPoolableObject_Internal.Clear()
	{
		HUdfNKdOgxfoxjMZAKUlkQYPszXh = null;
		wyOUtAQIXRMHfdYotPsXMPVUbwu = -1;
		ObWitXNhWFZMnOJBWvYTcBBfVnG = AxisRange.Full;
	}

	void IPoolableObject.Return()
	{
		if (oQJBQmusEWAvdHgvPBkmIuGgRYSh == null)
		{
			return;
		}
		while (true)
		{
			oQJBQmusEWAvdHgvPBkmIuGgRYSh.Return(this);
			int num = -554588071;
			while (true)
			{
				switch (num ^ -554588071)
				{
				case 2:
					goto IL_0009;
				default:
					return;
				case 1:
					break;
				case 0:
					return;
				}
				break;
				IL_0009:
				num = -554588072;
			}
		}
	}

	internal static RPsfaUSCQTmtficMhKUbbYyMecr ekwKfFcYONBmEYVTASOMSVczoEq()
	{
		if (eshfMCcaQYQWTRJfjmKqgcdkXWHR == null)
		{
			while (true)
			{
				int num = 1984280613;
				while (true)
				{
					switch (num ^ 0x7645B824)
					{
					case 0:
						break;
					case 1:
						if (PkdHFYJlZLMiTCimwpAnCiFWpZz == null)
						{
							PkdHFYJlZLMiTCimwpAnCiFWpZz = () => EacwNkMfYaHjbQRdeDfnuPOoebXI();
							num = 1984280614;
							continue;
						}
						goto case 2;
					case 2:
						eshfMCcaQYQWTRJfjmKqgcdkXWHR = new ObjectPool<RPsfaUSCQTmtficMhKUbbYyMecr>(PkdHFYJlZLMiTCimwpAnCiFWpZz);
						num = 1984280615;
						continue;
					default:
						goto end_IL_0007;
					}
					break;
				}
				continue;
				end_IL_0007:
				break;
			}
		}
		return eshfMCcaQYQWTRJfjmKqgcdkXWHR.Get();
	}

	internal static RPsfaUSCQTmtficMhKUbbYyMecr ekwKfFcYONBmEYVTASOMSVczoEq(ControllerElementTarget P_0)
	{
		RPsfaUSCQTmtficMhKUbbYyMecr rPsfaUSCQTmtficMhKUbbYyMecr = ekwKfFcYONBmEYVTASOMSVczoEq();
		rPsfaUSCQTmtficMhKUbbYyMecr.DzhGtommJNlpRFKUAFaKGOCHKTz(P_0);
		return rPsfaUSCQTmtficMhKUbbYyMecr;
	}

	internal static void fIwAMwHkLhYlTnWMCSbGViIFIbJg(RPsfaUSCQTmtficMhKUbbYyMecr P_0)
	{
		if (P_0 != null)
		{
			if (eshfMCcaQYQWTRJfjmKqgcdkXWHR == null)
			{
				goto IL_000a;
			}
			goto IL_0034;
		}
		return;
		IL_0034:
		eshfMCcaQYQWTRJfjmKqgcdkXWHR.Return(P_0);
		int num = 1492659813;
		goto IL_000f;
		IL_000a:
		num = 1492659814;
		goto IL_000f;
		IL_000f:
		switch (num ^ 0x58F82E67)
		{
		case 0:
			break;
		default:
			return;
		case 1:
			return;
		case 3:
			goto IL_0034;
		case 2:
			return;
		}
		goto IL_000a;
	}

	internal static RPsfaUSCQTmtficMhKUbbYyMecr EacwNkMfYaHjbQRdeDfnuPOoebXI()
	{
		return new RPsfaUSCQTmtficMhKUbbYyMecr(null, -1, AxisRange.Full);
	}

	void IDisposable.Dispose()
	{
		DJeUzQoMEVOxbEpwDFXbTBWdIKu(true);
		GC.SuppressFinalize(this);
	}

	~RPsfaUSCQTmtficMhKUbbYyMecr()
	{
		DJeUzQoMEVOxbEpwDFXbTBWdIKu(false);
	}

	private void DJeUzQoMEVOxbEpwDFXbTBWdIKu(bool P_0)
	{
		if (vsurYtRlepcrpAzAENwjqjJEZPT)
		{
			return;
		}
		while (true)
		{
			int num;
			if (P_0)
			{
				((IPoolableObject)this).Return();
				num = -642167587;
				goto IL_000e;
			}
			goto IL_003b;
			IL_000e:
			while (true)
			{
				switch (num ^ -642167585)
				{
				case 3:
					num = -642167586;
					continue;
				default:
					return;
				case 1:
					break;
				case 2:
					goto IL_003b;
				case 0:
					return;
				}
				break;
			}
			continue;
			IL_003b:
			vsurYtRlepcrpAzAENwjqjJEZPT = true;
			num = -642167585;
			goto IL_000e;
		}
	}

	[CompilerGenerated]
	private static RPsfaUSCQTmtficMhKUbbYyMecr mEzVqWKZHATGECKkxXfotifJlpM()
	{
		return EacwNkMfYaHjbQRdeDfnuPOoebXI();
	}
}
