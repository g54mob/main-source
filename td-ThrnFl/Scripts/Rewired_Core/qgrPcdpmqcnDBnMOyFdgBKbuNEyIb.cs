using System;
using Rewired;
using Rewired.Interfaces;
using Rewired.Utils.Classes.Utility;

internal sealed class qgrPcdpmqcnDBnMOyFdgBKbuNEyIb : IControllerElementTarget, IPoolableObject_Internal, IPoolableObject, IDisposable
{
	[Serializable]
	private sealed class OspFdvdPOLfjWDripfBRmNkdPvnc
	{
		public static readonly OspFdvdPOLfjWDripfBRmNkdPvnc _003C_003E9 = new OspFdvdPOLfjWDripfBRmNkdPvnc();

		public static Func<qgrPcdpmqcnDBnMOyFdgBKbuNEyIb> _003C_003E9__30_0;

		internal qgrPcdpmqcnDBnMOyFdgBKbuNEyIb SgvAATafTigMjUpJRFRqcEQXkAvt()
		{
			return yKFZOeFZwVLSDDajwmHMnTpZEMVh();
		}
	}

	private static ObjectPool<qgrPcdpmqcnDBnMOyFdgBKbuNEyIb> lqrpXoNnguBiwcoByzGWuKHKKUJQ;

	private Controller ZIkkQDVNsiTMNbLsugINGYVrefYi;

	private int YdmtPeLMinUMHmXXpIgsFFnOsyeC;

	private AxisRange gJBNtVvwGGIolotvZKRGtWOTGeur;

	private IObjectPool pmnyYASsToAYVkuJIgCXmLxiOJGN;

	private bool AnJwYsZyZwOxdZeCDuXjtyRayOdk;

	int IControllerElementTarget.elementIdentifierId => YdmtPeLMinUMHmXXpIgsFFnOsyeC;

	AxisRange IControllerElementTarget.axisRange => gJBNtVvwGGIolotvZKRGtWOTGeur;

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
			if (ZIkkQDVNsiTMNbLsugINGYVrefYi == null)
			{
				return string.Empty;
			}
			ControllerElementIdentifier elementIdentifierById = ZIkkQDVNsiTMNbLsugINGYVrefYi.GetElementIdentifierById(YdmtPeLMinUMHmXXpIgsFFnOsyeC);
			if (elementIdentifierById == null)
			{
				return string.Empty;
			}
			Controller.Element elementById = ZIkkQDVNsiTMNbLsugINGYVrefYi.GetElementById(YdmtPeLMinUMHmXXpIgsFFnOsyeC);
			if (elementById == null)
			{
				return string.Empty;
			}
			return elementIdentifierById.GetDisplayName(elementById.type, gJBNtVvwGGIolotvZKRGtWOTGeur);
		}
	}

	Controller IControllerElementTarget.controller => ZIkkQDVNsiTMNbLsugINGYVrefYi;

	Controller.Element IControllerElementTarget.element
	{
		get
		{
			if (ZIkkQDVNsiTMNbLsugINGYVrefYi == null)
			{
				return null;
			}
			if (ZIkkQDVNsiTMNbLsugINGYVrefYi.GetElementIdentifierById(YdmtPeLMinUMHmXXpIgsFFnOsyeC) == null)
			{
				return null;
			}
			return ZIkkQDVNsiTMNbLsugINGYVrefYi.GetElementById(YdmtPeLMinUMHmXXpIgsFFnOsyeC);
		}
	}

	public ControllerElementIdentifier kjXvRMMNfLIQBZRoChsHbcxYbrbDb
	{
		get
		{
			if (ZIkkQDVNsiTMNbLsugINGYVrefYi == null)
			{
				return null;
			}
			return ZIkkQDVNsiTMNbLsugINGYVrefYi.GetElementIdentifierById(YdmtPeLMinUMHmXXpIgsFFnOsyeC);
		}
	}

	IObjectPool IPoolableObject_Internal.pool
	{
		get
		{
			return pmnyYASsToAYVkuJIgCXmLxiOJGN;
		}
		set
		{
			pmnyYASsToAYVkuJIgCXmLxiOJGN = value;
		}
	}

	internal qgrPcdpmqcnDBnMOyFdgBKbuNEyIb(Controller P_0, int P_1, AxisRange P_2)
	{
		ZIkkQDVNsiTMNbLsugINGYVrefYi = P_0;
		YdmtPeLMinUMHmXXpIgsFFnOsyeC = P_1;
		gJBNtVvwGGIolotvZKRGtWOTGeur = P_2;
	}

	internal void cgkhzdGCzxJsrdtskFjDGwlylSsHA(ControllerElementTarget P_0)
	{
		ZIkkQDVNsiTMNbLsugINGYVrefYi = P_0.controller;
		YdmtPeLMinUMHmXXpIgsFFnOsyeC = P_0.elementIdentifierId;
		gJBNtVvwGGIolotvZKRGtWOTGeur = P_0.axisRange;
	}

	internal void ykDlchdfLGcnQiiOsztjSuTTljFx(IControllerElementTarget P_0)
	{
		ZIkkQDVNsiTMNbLsugINGYVrefYi = P_0.controller;
		YdmtPeLMinUMHmXXpIgsFFnOsyeC = P_0.elementIdentifierId;
		gJBNtVvwGGIolotvZKRGtWOTGeur = P_0.axisRange;
	}

	internal void WxYvdfWLHjDMiZaIizdoEbFlremH(qgrPcdpmqcnDBnMOyFdgBKbuNEyIb P_0)
	{
		ykDlchdfLGcnQiiOsztjSuTTljFx(P_0);
	}

	void IPoolableObject_Internal.Clear()
	{
		ZIkkQDVNsiTMNbLsugINGYVrefYi = null;
		YdmtPeLMinUMHmXXpIgsFFnOsyeC = -1;
		gJBNtVvwGGIolotvZKRGtWOTGeur = AxisRange.Full;
	}

	void IPoolableObject.Return()
	{
		if (pmnyYASsToAYVkuJIgCXmLxiOJGN != null)
		{
			pmnyYASsToAYVkuJIgCXmLxiOJGN.Return(this);
		}
	}

	internal static qgrPcdpmqcnDBnMOyFdgBKbuNEyIb raaPzVfUuTWxxwHZxcLUXczpEWqB()
	{
		if (lqrpXoNnguBiwcoByzGWuKHKKUJQ == null)
		{
			lqrpXoNnguBiwcoByzGWuKHKKUJQ = new ObjectPool<qgrPcdpmqcnDBnMOyFdgBKbuNEyIb>(OspFdvdPOLfjWDripfBRmNkdPvnc._003C_003E9.SgvAATafTigMjUpJRFRqcEQXkAvt);
		}
		return lqrpXoNnguBiwcoByzGWuKHKKUJQ.Get();
	}

	internal static qgrPcdpmqcnDBnMOyFdgBKbuNEyIb UonzQUMBmRTcGnEIJcoQvobZckog(ControllerElementTarget P_0)
	{
		qgrPcdpmqcnDBnMOyFdgBKbuNEyIb obj = raaPzVfUuTWxxwHZxcLUXczpEWqB();
		obj.cgkhzdGCzxJsrdtskFjDGwlylSsHA(P_0);
		return obj;
	}

	internal static void VNaLqWfLZTBMqvZzsicqBOVWljAl(qgrPcdpmqcnDBnMOyFdgBKbuNEyIb P_0)
	{
		if (P_0 != null && lqrpXoNnguBiwcoByzGWuKHKKUJQ != null)
		{
			lqrpXoNnguBiwcoByzGWuKHKKUJQ.Return(P_0);
		}
	}

	internal static qgrPcdpmqcnDBnMOyFdgBKbuNEyIb yKFZOeFZwVLSDDajwmHMnTpZEMVh()
	{
		return new qgrPcdpmqcnDBnMOyFdgBKbuNEyIb(null, -1, AxisRange.Full);
	}

	void IDisposable.Dispose()
	{
		EYTQlBgGiyHwHrINmqSksNTfwYhl(true);
		GC.SuppressFinalize(this);
	}

	protected void uYaGaaiWZBUVonUfiHAYLnVkTYcK()
	{
		try
		{
			EYTQlBgGiyHwHrINmqSksNTfwYhl(false);
		}
		finally
		{
			base.Finalize();
		}
	}

	private void EYTQlBgGiyHwHrINmqSksNTfwYhl(bool P_0)
	{
		if (!AnJwYsZyZwOxdZeCDuXjtyRayOdk)
		{
			if (P_0)
			{
				((IPoolableObject)this).Return();
			}
			AnJwYsZyZwOxdZeCDuXjtyRayOdk = true;
		}
	}
}
