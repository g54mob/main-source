using System;
using System.Runtime.CompilerServices;
using Rewired;
using Rewired.Interfaces;
using Rewired.Utils.Classes.Utility;

internal sealed class BIzzMnQbYdgezaQAnFAxzmYBsLQP : IDisposable, IControllerElementTarget, IPoolableObject, IPoolableObject_Internal
{
	private static ObjectPool<BIzzMnQbYdgezaQAnFAxzmYBsLQP> gEicdjkzQiLAFnZrbQIwftHEmty;

	private Controller BheccrWcwXwuvsNLWjWrFwcrgAqE;

	private int aKTKfMYcYdTWZLyYfpZoZfzZGQT;

	private AxisRange INqAuPUOdfKjEyVKDGDlvfaJUlc;

	private IObjectPool uyYrlZqvMcvYdQVjDiAulViAxCp;

	private bool jgbpvYJovPcfzmcAEJzdxdrBmcm;

	[CompilerGenerated]
	private static Func<BIzzMnQbYdgezaQAnFAxzmYBsLQP> ZCwIsrHovbcKJeKasXtvDGSZlUI;

	public int elementIdentifierId => aKTKfMYcYdTWZLyYfpZoZfzZGQT;

	public AxisRange axisRange => INqAuPUOdfKjEyVKDGDlvfaJUlc;

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
			if (BheccrWcwXwuvsNLWjWrFwcrgAqE == null)
			{
				return string.Empty;
			}
			ControllerElementIdentifier elementIdentifierById = BheccrWcwXwuvsNLWjWrFwcrgAqE.GetElementIdentifierById(aKTKfMYcYdTWZLyYfpZoZfzZGQT);
			if (elementIdentifierById == null)
			{
				return string.Empty;
			}
			Controller.Element elementById = BheccrWcwXwuvsNLWjWrFwcrgAqE.GetElementById(aKTKfMYcYdTWZLyYfpZoZfzZGQT);
			if (elementById == null)
			{
				return string.Empty;
			}
			return elementIdentifierById.GetDisplayName(elementById.type, INqAuPUOdfKjEyVKDGDlvfaJUlc);
		}
	}

	public Controller controller => BheccrWcwXwuvsNLWjWrFwcrgAqE;

	public Controller.Element element
	{
		get
		{
			if (BheccrWcwXwuvsNLWjWrFwcrgAqE == null)
			{
				return null;
			}
			ControllerElementIdentifier elementIdentifierById = BheccrWcwXwuvsNLWjWrFwcrgAqE.GetElementIdentifierById(aKTKfMYcYdTWZLyYfpZoZfzZGQT);
			if (elementIdentifierById == null)
			{
				return null;
			}
			return BheccrWcwXwuvsNLWjWrFwcrgAqE.GetElementById(aKTKfMYcYdTWZLyYfpZoZfzZGQT);
		}
	}

	public ControllerElementIdentifier elementIdentifier
	{
		get
		{
			if (BheccrWcwXwuvsNLWjWrFwcrgAqE == null)
			{
				return null;
			}
			return BheccrWcwXwuvsNLWjWrFwcrgAqE.GetElementIdentifierById(aKTKfMYcYdTWZLyYfpZoZfzZGQT);
		}
	}

	IObjectPool IPoolableObject_Internal.pool
	{
		get
		{
			return uyYrlZqvMcvYdQVjDiAulViAxCp;
		}
		set
		{
			uyYrlZqvMcvYdQVjDiAulViAxCp = value;
		}
	}

	internal BIzzMnQbYdgezaQAnFAxzmYBsLQP(Controller controller, int elementIdentifierId, AxisRange axisRange)
	{
		BheccrWcwXwuvsNLWjWrFwcrgAqE = controller;
		aKTKfMYcYdTWZLyYfpZoZfzZGQT = elementIdentifierId;
		INqAuPUOdfKjEyVKDGDlvfaJUlc = axisRange;
	}

	internal void JYyEPkmZztzXfbEgKghAFieAytO(ControllerElementTarget P_0)
	{
		BheccrWcwXwuvsNLWjWrFwcrgAqE = P_0.controller;
		aKTKfMYcYdTWZLyYfpZoZfzZGQT = P_0.elementIdentifierId;
		INqAuPUOdfKjEyVKDGDlvfaJUlc = P_0.axisRange;
	}

	internal void JYyEPkmZztzXfbEgKghAFieAytO(IControllerElementTarget P_0)
	{
		BheccrWcwXwuvsNLWjWrFwcrgAqE = P_0.controller;
		aKTKfMYcYdTWZLyYfpZoZfzZGQT = P_0.elementIdentifierId;
		INqAuPUOdfKjEyVKDGDlvfaJUlc = P_0.axisRange;
	}

	internal void JYyEPkmZztzXfbEgKghAFieAytO(BIzzMnQbYdgezaQAnFAxzmYBsLQP P_0)
	{
		JYyEPkmZztzXfbEgKghAFieAytO((IControllerElementTarget)P_0);
	}

	private void QICZhoUIAOXeuHxyzXdztdryHrM()
	{
		BheccrWcwXwuvsNLWjWrFwcrgAqE = null;
		aKTKfMYcYdTWZLyYfpZoZfzZGQT = -1;
		INqAuPUOdfKjEyVKDGDlvfaJUlc = AxisRange.Full;
	}

	void IPoolableObject_Internal.Clear()
	{
		//ILSpy generated this explicit interface implementation from .override directive in QICZhoUIAOXeuHxyzXdztdryHrM
		this.QICZhoUIAOXeuHxyzXdztdryHrM();
	}

	private void nltjefxKyKdePDFTWrByRyfujBMl()
	{
		if (uyYrlZqvMcvYdQVjDiAulViAxCp != null)
		{
			uyYrlZqvMcvYdQVjDiAulViAxCp.Return(this);
		}
	}

	void IPoolableObject.Return()
	{
		//ILSpy generated this explicit interface implementation from .override directive in nltjefxKyKdePDFTWrByRyfujBMl
		this.nltjefxKyKdePDFTWrByRyfujBMl();
	}

	internal static BIzzMnQbYdgezaQAnFAxzmYBsLQP mlbUbmcCGlibSeAVWGWEZZOqvxX()
	{
		if (gEicdjkzQiLAFnZrbQIwftHEmty == null)
		{
			gEicdjkzQiLAFnZrbQIwftHEmty = new ObjectPool<BIzzMnQbYdgezaQAnFAxzmYBsLQP>(() => AapzLJOSMOptjeIdgEhpjxotmUy());
		}
		return gEicdjkzQiLAFnZrbQIwftHEmty.Get();
	}

	internal static BIzzMnQbYdgezaQAnFAxzmYBsLQP mlbUbmcCGlibSeAVWGWEZZOqvxX(ControllerElementTarget P_0)
	{
		BIzzMnQbYdgezaQAnFAxzmYBsLQP bIzzMnQbYdgezaQAnFAxzmYBsLQP = mlbUbmcCGlibSeAVWGWEZZOqvxX();
		bIzzMnQbYdgezaQAnFAxzmYBsLQP.JYyEPkmZztzXfbEgKghAFieAytO(P_0);
		return bIzzMnQbYdgezaQAnFAxzmYBsLQP;
	}

	internal static void bIxblVJXTRfjDgVIYRbYhAcCoIcF(BIzzMnQbYdgezaQAnFAxzmYBsLQP P_0)
	{
		if (P_0 != null && gEicdjkzQiLAFnZrbQIwftHEmty != null)
		{
			gEicdjkzQiLAFnZrbQIwftHEmty.Return(P_0);
		}
	}

	internal static BIzzMnQbYdgezaQAnFAxzmYBsLQP AapzLJOSMOptjeIdgEhpjxotmUy()
	{
		return new BIzzMnQbYdgezaQAnFAxzmYBsLQP(null, -1, AxisRange.Full);
	}

	void IDisposable.Dispose()
	{
		TKtGozqoOtxUzimyRPnpCnmqxwZ(true);
		GC.SuppressFinalize(this);
	}

	~BIzzMnQbYdgezaQAnFAxzmYBsLQP()
	{
		TKtGozqoOtxUzimyRPnpCnmqxwZ(false);
	}

	private void TKtGozqoOtxUzimyRPnpCnmqxwZ(bool P_0)
	{
		if (!jgbpvYJovPcfzmcAEJzdxdrBmcm)
		{
			if (P_0)
			{
				((IPoolableObject)this).Return();
			}
			jgbpvYJovPcfzmcAEJzdxdrBmcm = true;
		}
	}

	[CompilerGenerated]
	private static BIzzMnQbYdgezaQAnFAxzmYBsLQP ssiJeBKoBaTROocSdpRqsMHUHYl()
	{
		return AapzLJOSMOptjeIdgEhpjxotmUy();
	}
}
