using System;
using System.Runtime.CompilerServices;
using Rewired;
using Rewired.Interfaces;
using Rewired.Utils.Classes.Utility;

internal sealed class auqagPyfULkTIGtBZGYbYCoEQli : IDisposable, IControllerElementTarget, IPoolableObject, IPoolableObject_Internal
{
	private static ObjectPool<auqagPyfULkTIGtBZGYbYCoEQli> XvjvRZSvMAJxgfnmDuUuTxrTqVG;

	private Controller ktnvQXcbwjTTWobUkcIrbxSoyaKH;

	private int TZSPqisJATrQkFfRXLKedgRIcwv;

	private AxisRange jlEnqYlFCTxpQiXKkRUPTZLnjeL;

	private IObjectPool VQPWRbKOUMcQQSOcpisujDSJyBXH;

	private bool QQqHByfwytAJSuMZiCPjJlZYHKG;

	[CompilerGenerated]
	private static Func<auqagPyfULkTIGtBZGYbYCoEQli> autMBJdbnRzwuaphYbdbvPoQqzm;

	public int elementIdentifierId
	{
		get
		{
			return TZSPqisJATrQkFfRXLKedgRIcwv;
		}
	}

	public AxisRange axisRange
	{
		get
		{
			return jlEnqYlFCTxpQiXKkRUPTZLnjeL;
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
			if (ktnvQXcbwjTTWobUkcIrbxSoyaKH == null)
			{
				return string.Empty;
			}
			ControllerElementIdentifier elementIdentifierById = ktnvQXcbwjTTWobUkcIrbxSoyaKH.GetElementIdentifierById(TZSPqisJATrQkFfRXLKedgRIcwv);
			while (true)
			{
				int num = -1641208509;
				while (true)
				{
					switch (num ^ -1641208511)
					{
					case 0:
						break;
					case 2:
					{
						if (elementIdentifierById == null)
						{
							goto IL_0041;
						}
						Controller.Element elementById = ktnvQXcbwjTTWobUkcIrbxSoyaKH.GetElementById(TZSPqisJATrQkFfRXLKedgRIcwv);
						if (elementById == null)
						{
							return string.Empty;
						}
						return elementIdentifierById.GetDisplayName(elementById.type, jlEnqYlFCTxpQiXKkRUPTZLnjeL);
					}
					default:
						return string.Empty;
					}
					break;
					IL_0041:
					num = -1641208512;
				}
			}
		}
	}

	public Controller controller
	{
		get
		{
			return ktnvQXcbwjTTWobUkcIrbxSoyaKH;
		}
	}

	public Controller.Element element
	{
		get
		{
			if (ktnvQXcbwjTTWobUkcIrbxSoyaKH == null)
			{
				return null;
			}
			ControllerElementIdentifier elementIdentifierById = ktnvQXcbwjTTWobUkcIrbxSoyaKH.GetElementIdentifierById(TZSPqisJATrQkFfRXLKedgRIcwv);
			if (elementIdentifierById == null)
			{
				return null;
			}
			return ktnvQXcbwjTTWobUkcIrbxSoyaKH.GetElementById(TZSPqisJATrQkFfRXLKedgRIcwv);
		}
	}

	public ControllerElementIdentifier elementIdentifier
	{
		get
		{
			if (ktnvQXcbwjTTWobUkcIrbxSoyaKH == null)
			{
				return null;
			}
			return ktnvQXcbwjTTWobUkcIrbxSoyaKH.GetElementIdentifierById(TZSPqisJATrQkFfRXLKedgRIcwv);
		}
	}

	IObjectPool IPoolableObject_Internal.pool
	{
		get
		{
			return VQPWRbKOUMcQQSOcpisujDSJyBXH;
		}
		set
		{
			VQPWRbKOUMcQQSOcpisujDSJyBXH = value;
		}
	}

	internal auqagPyfULkTIGtBZGYbYCoEQli(Controller controller, int elementIdentifierId, AxisRange axisRange)
	{
		ktnvQXcbwjTTWobUkcIrbxSoyaKH = controller;
		TZSPqisJATrQkFfRXLKedgRIcwv = elementIdentifierId;
		jlEnqYlFCTxpQiXKkRUPTZLnjeL = axisRange;
	}

	internal void kLnQybMiVBnKwrnVkGeKjoKJKGa(ControllerElementTarget P_0)
	{
		ktnvQXcbwjTTWobUkcIrbxSoyaKH = P_0.controller;
		TZSPqisJATrQkFfRXLKedgRIcwv = P_0.elementIdentifierId;
		jlEnqYlFCTxpQiXKkRUPTZLnjeL = P_0.axisRange;
	}

	internal void kLnQybMiVBnKwrnVkGeKjoKJKGa(IControllerElementTarget P_0)
	{
		ktnvQXcbwjTTWobUkcIrbxSoyaKH = P_0.controller;
		TZSPqisJATrQkFfRXLKedgRIcwv = P_0.elementIdentifierId;
		jlEnqYlFCTxpQiXKkRUPTZLnjeL = P_0.axisRange;
	}

	internal void kLnQybMiVBnKwrnVkGeKjoKJKGa(auqagPyfULkTIGtBZGYbYCoEQli P_0)
	{
		kLnQybMiVBnKwrnVkGeKjoKJKGa((IControllerElementTarget)P_0);
	}

	void IPoolableObject_Internal.Clear()
	{
		ktnvQXcbwjTTWobUkcIrbxSoyaKH = null;
		TZSPqisJATrQkFfRXLKedgRIcwv = -1;
		jlEnqYlFCTxpQiXKkRUPTZLnjeL = AxisRange.Full;
	}

	void IPoolableObject.Return()
	{
		if (VQPWRbKOUMcQQSOcpisujDSJyBXH != null)
		{
			VQPWRbKOUMcQQSOcpisujDSJyBXH.Return(this);
		}
	}

	internal static auqagPyfULkTIGtBZGYbYCoEQli RAogkGGXATfLnoLSmrKCnfyrAHzh()
	{
		if (XvjvRZSvMAJxgfnmDuUuTxrTqVG == null)
		{
			if (autMBJdbnRzwuaphYbdbvPoQqzm == null)
			{
				goto IL_000e;
			}
			goto IL_0048;
		}
		goto IL_005e;
		IL_005e:
		return XvjvRZSvMAJxgfnmDuUuTxrTqVG.Get();
		IL_000e:
		int num = -1062700571;
		goto IL_0013;
		IL_0013:
		while (true)
		{
			switch (num ^ -1062700569)
			{
			case 0:
				break;
			case 2:
				autMBJdbnRzwuaphYbdbvPoQqzm = () => dawcjtsNOciSWAmaKVxbSHSsCoQM();
				num = -1062700570;
				continue;
			case 1:
				goto IL_0048;
			default:
				goto IL_005e;
			}
			break;
		}
		goto IL_000e;
		IL_0048:
		XvjvRZSvMAJxgfnmDuUuTxrTqVG = new ObjectPool<auqagPyfULkTIGtBZGYbYCoEQli>(autMBJdbnRzwuaphYbdbvPoQqzm);
		num = -1062700572;
		goto IL_0013;
	}

	internal static auqagPyfULkTIGtBZGYbYCoEQli RAogkGGXATfLnoLSmrKCnfyrAHzh(ControllerElementTarget P_0)
	{
		auqagPyfULkTIGtBZGYbYCoEQli auqagPyfULkTIGtBZGYbYCoEQli2 = RAogkGGXATfLnoLSmrKCnfyrAHzh();
		auqagPyfULkTIGtBZGYbYCoEQli2.kLnQybMiVBnKwrnVkGeKjoKJKGa(P_0);
		return auqagPyfULkTIGtBZGYbYCoEQli2;
	}

	internal static void OQcTHnlxFrSnyNNFspeSqjQJkaC(auqagPyfULkTIGtBZGYbYCoEQli P_0)
	{
		if (P_0 == null)
		{
			return;
		}
		if (XvjvRZSvMAJxgfnmDuUuTxrTqVG == null)
		{
			while (true)
			{
				switch (0x70000514 ^ 0x70000515)
				{
				case 2:
					continue;
				case 1:
					return;
				}
				break;
			}
		}
		XvjvRZSvMAJxgfnmDuUuTxrTqVG.Return(P_0);
	}

	internal static auqagPyfULkTIGtBZGYbYCoEQli dawcjtsNOciSWAmaKVxbSHSsCoQM()
	{
		return new auqagPyfULkTIGtBZGYbYCoEQli(null, -1, AxisRange.Full);
	}

	void IDisposable.Dispose()
	{
		yByeqDDEKPzAKiUpxfZrBkMpiHln(true);
		GC.SuppressFinalize(this);
	}

	~auqagPyfULkTIGtBZGYbYCoEQli()
	{
		yByeqDDEKPzAKiUpxfZrBkMpiHln(false);
	}

	private void yByeqDDEKPzAKiUpxfZrBkMpiHln(bool P_0)
	{
		if (QQqHByfwytAJSuMZiCPjJlZYHKG)
		{
			goto IL_0008;
		}
		goto IL_0032;
		IL_0008:
		int num = 283172974;
		goto IL_000d;
		IL_000d:
		switch (num ^ 0x10E0E06F)
		{
		case 0:
			break;
		case 1:
			return;
		case 3:
			goto IL_0032;
		default:
			goto IL_0042;
		}
		goto IL_0008;
		IL_0032:
		if (P_0)
		{
			((IPoolableObject)this).Return();
			num = 283172973;
			goto IL_000d;
		}
		goto IL_0042;
		IL_0042:
		QQqHByfwytAJSuMZiCPjJlZYHKG = true;
	}

	[CompilerGenerated]
	private static auqagPyfULkTIGtBZGYbYCoEQli BsjSKpojFGcLvgRXLVMcIlrJyDZ()
	{
		return dawcjtsNOciSWAmaKVxbSHSsCoQM();
	}
}
