using System;
using Rewired;
using Rewired.Interfaces;
using Rewired.Utils.Classes.Utility;

internal sealed class JrHSDKJJRmfQuafjRnKcPPKpIBhpA : IControllerElementTarget, IPoolableObject_Internal, IPoolableObject, IDisposable
{
	[Serializable]
	private sealed class nBZekOFHyVpyGHYCCuGVnduyVYkL
	{
		public static readonly nBZekOFHyVpyGHYCCuGVnduyVYkL _003C_003E9 = new nBZekOFHyVpyGHYCCuGVnduyVYkL();

		public static Func<JrHSDKJJRmfQuafjRnKcPPKpIBhpA> _003C_003E9__30_0;

		internal JrHSDKJJRmfQuafjRnKcPPKpIBhpA rLThoiEksiNQKIhgasBatOhOLaoI()
		{
			return HgjmLTdDFHYuwPSDLFOPmOvQPEnb();
		}
	}

	private static ObjectPool<JrHSDKJJRmfQuafjRnKcPPKpIBhpA> ShBSwHhKBmujJmQiPcbOnQoRBVWv;

	private Controller wiCXMizJoqAvgjHlBBKPZoqwlAXE;

	private int tNAMmHfplxPmweakSebgULsXjXdl;

	private AxisRange ZkruQqBlvGwlOsxWyckKoFfOsffx;

	private IObjectPool MHFRzdonsaTXouIgdwxTzAUhSOFw;

	private bool rmjLrVtVyaSHYFylwdHdqQcjAtwjA;

	int IControllerElementTarget.elementIdentifierId => tNAMmHfplxPmweakSebgULsXjXdl;

	AxisRange IControllerElementTarget.axisRange => ZkruQqBlvGwlOsxWyckKoFfOsffx;

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
			if (wiCXMizJoqAvgjHlBBKPZoqwlAXE == null)
			{
				return string.Empty;
			}
			ControllerElementIdentifier elementIdentifierById = wiCXMizJoqAvgjHlBBKPZoqwlAXE.GetElementIdentifierById(tNAMmHfplxPmweakSebgULsXjXdl);
			if (elementIdentifierById == null)
			{
				return string.Empty;
			}
			Controller.Element elementById = wiCXMizJoqAvgjHlBBKPZoqwlAXE.GetElementById(tNAMmHfplxPmweakSebgULsXjXdl);
			if (elementById == null)
			{
				return string.Empty;
			}
			return elementIdentifierById.GetDisplayName(elementById.type, ZkruQqBlvGwlOsxWyckKoFfOsffx);
		}
	}

	Controller IControllerElementTarget.controller => wiCXMizJoqAvgjHlBBKPZoqwlAXE;

	Controller.Element IControllerElementTarget.element
	{
		get
		{
			if (wiCXMizJoqAvgjHlBBKPZoqwlAXE == null)
			{
				return null;
			}
			if (wiCXMizJoqAvgjHlBBKPZoqwlAXE.GetElementIdentifierById(tNAMmHfplxPmweakSebgULsXjXdl) == null)
			{
				return null;
			}
			return wiCXMizJoqAvgjHlBBKPZoqwlAXE.GetElementById(tNAMmHfplxPmweakSebgULsXjXdl);
		}
	}

	public ControllerElementIdentifier ZKvmqfglUNJBiTsTdEFTxrYJJwmO
	{
		get
		{
			if (wiCXMizJoqAvgjHlBBKPZoqwlAXE == null)
			{
				return null;
			}
			return wiCXMizJoqAvgjHlBBKPZoqwlAXE.GetElementIdentifierById(tNAMmHfplxPmweakSebgULsXjXdl);
		}
	}

	IObjectPool IPoolableObject_Internal.pool
	{
		get
		{
			return MHFRzdonsaTXouIgdwxTzAUhSOFw;
		}
		set
		{
			MHFRzdonsaTXouIgdwxTzAUhSOFw = value;
		}
	}

	internal JrHSDKJJRmfQuafjRnKcPPKpIBhpA(Controller P_0, int P_1, AxisRange P_2)
	{
		wiCXMizJoqAvgjHlBBKPZoqwlAXE = P_0;
		tNAMmHfplxPmweakSebgULsXjXdl = P_1;
		ZkruQqBlvGwlOsxWyckKoFfOsffx = P_2;
	}

	internal void HuAiIMahYfRfYbGLTeYLFnKrBRfpA(ControllerElementTarget P_0)
	{
		wiCXMizJoqAvgjHlBBKPZoqwlAXE = P_0.controller;
		tNAMmHfplxPmweakSebgULsXjXdl = P_0.elementIdentifierId;
		ZkruQqBlvGwlOsxWyckKoFfOsffx = P_0.axisRange;
	}

	internal void HDfUKILfiAeExabbNeMfFJmIrkWO(IControllerElementTarget P_0)
	{
		wiCXMizJoqAvgjHlBBKPZoqwlAXE = P_0.controller;
		tNAMmHfplxPmweakSebgULsXjXdl = P_0.elementIdentifierId;
		ZkruQqBlvGwlOsxWyckKoFfOsffx = P_0.axisRange;
	}

	internal void hqqaQAmZutUwTTfJNIYyDLqqVczW(JrHSDKJJRmfQuafjRnKcPPKpIBhpA P_0)
	{
		HDfUKILfiAeExabbNeMfFJmIrkWO(P_0);
	}

	void IPoolableObject_Internal.Clear()
	{
		wiCXMizJoqAvgjHlBBKPZoqwlAXE = null;
		tNAMmHfplxPmweakSebgULsXjXdl = -1;
		ZkruQqBlvGwlOsxWyckKoFfOsffx = AxisRange.Full;
	}

	void IPoolableObject.Return()
	{
		if (MHFRzdonsaTXouIgdwxTzAUhSOFw != null)
		{
			MHFRzdonsaTXouIgdwxTzAUhSOFw.Return(this);
		}
	}

	internal static JrHSDKJJRmfQuafjRnKcPPKpIBhpA YrGcpyJkzVZCIqoaKNmXEAXePHPk()
	{
		if (ShBSwHhKBmujJmQiPcbOnQoRBVWv == null)
		{
			ShBSwHhKBmujJmQiPcbOnQoRBVWv = new ObjectPool<JrHSDKJJRmfQuafjRnKcPPKpIBhpA>(nBZekOFHyVpyGHYCCuGVnduyVYkL._003C_003E9.rLThoiEksiNQKIhgasBatOhOLaoI);
		}
		return ShBSwHhKBmujJmQiPcbOnQoRBVWv.Get();
	}

	internal static JrHSDKJJRmfQuafjRnKcPPKpIBhpA hCBMMpiSqNKuftopqJiKegMStdpm(ControllerElementTarget P_0)
	{
		JrHSDKJJRmfQuafjRnKcPPKpIBhpA jrHSDKJJRmfQuafjRnKcPPKpIBhpA = YrGcpyJkzVZCIqoaKNmXEAXePHPk();
		jrHSDKJJRmfQuafjRnKcPPKpIBhpA.HuAiIMahYfRfYbGLTeYLFnKrBRfpA(P_0);
		return jrHSDKJJRmfQuafjRnKcPPKpIBhpA;
	}

	internal static void mEWWRvXleLvCZfUUVlNaMPaNPoTO(JrHSDKJJRmfQuafjRnKcPPKpIBhpA P_0)
	{
		if (P_0 != null && ShBSwHhKBmujJmQiPcbOnQoRBVWv != null)
		{
			ShBSwHhKBmujJmQiPcbOnQoRBVWv.Return(P_0);
		}
	}

	internal static JrHSDKJJRmfQuafjRnKcPPKpIBhpA HgjmLTdDFHYuwPSDLFOPmOvQPEnb()
	{
		return new JrHSDKJJRmfQuafjRnKcPPKpIBhpA(null, -1, AxisRange.Full);
	}

	void IDisposable.Dispose()
	{
		bhOzqOMFezxsbtoDfjwVlcyPBiUA(true);
		GC.SuppressFinalize(this);
	}

	protected void ZAQjBTERuVySNfJKRvhOILwvNFnu()
	{
		try
		{
			bhOzqOMFezxsbtoDfjwVlcyPBiUA(false);
		}
		finally
		{
			base.Finalize();
		}
	}

	private void bhOzqOMFezxsbtoDfjwVlcyPBiUA(bool P_0)
	{
		if (!rmjLrVtVyaSHYFylwdHdqQcjAtwjA)
		{
			if (P_0)
			{
				((IPoolableObject)this).Return();
			}
			rmjLrVtVyaSHYFylwdHdqQcjAtwjA = true;
		}
	}
}
