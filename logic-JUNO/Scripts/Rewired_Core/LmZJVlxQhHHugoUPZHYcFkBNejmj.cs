using System;
using Rewired;
using Rewired.Interfaces;
using Rewired.Utils.Classes.Utility;

internal sealed class LmZJVlxQhHHugoUPZHYcFkBNejmj : IControllerElementTarget, IPoolableObject_Internal, IPoolableObject, IDisposable
{
	[Serializable]
	private sealed class bnTZqzvsQahrOWlyEdDNtPlOZpdo
	{
		public static readonly bnTZqzvsQahrOWlyEdDNtPlOZpdo _003C_003E9 = new bnTZqzvsQahrOWlyEdDNtPlOZpdo();

		public static Func<LmZJVlxQhHHugoUPZHYcFkBNejmj> _003C_003E9__30_0;

		internal LmZJVlxQhHHugoUPZHYcFkBNejmj zsLlhTciUTqKCBTKmFbanqiuqSdm()
		{
			return TTzGqiHDtqPPkQzcZWKCaWViogRO();
		}
	}

	private static ObjectPool<LmZJVlxQhHHugoUPZHYcFkBNejmj> AwJaXiLtnVioDxJQZoGYrRbtoLPG;

	private Controller mdMtFLRppZSNocHrBBYBFZxYWEAOA;

	private int rBCXEwNQREbUatvCSNcaKkzrPUmw;

	private AxisRange BXnIaTteHbGmIjzaiUbGgDkmmUsw;

	private IObjectPool YbNjfYOBGHEQuxNSzerVdeRDhmMI;

	private bool tzvbKeZHAVOOGWmTgAOpqSjZKjff;

	int IControllerElementTarget.elementIdentifierId => rBCXEwNQREbUatvCSNcaKkzrPUmw;

	AxisRange IControllerElementTarget.axisRange => BXnIaTteHbGmIjzaiUbGgDkmmUsw;

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
			if (mdMtFLRppZSNocHrBBYBFZxYWEAOA == null)
			{
				return string.Empty;
			}
			ControllerElementIdentifier elementIdentifierById = mdMtFLRppZSNocHrBBYBFZxYWEAOA.GetElementIdentifierById(rBCXEwNQREbUatvCSNcaKkzrPUmw);
			if (elementIdentifierById == null)
			{
				return string.Empty;
			}
			Controller.Element elementById = mdMtFLRppZSNocHrBBYBFZxYWEAOA.GetElementById(rBCXEwNQREbUatvCSNcaKkzrPUmw);
			if (elementById == null)
			{
				return string.Empty;
			}
			return elementIdentifierById.GetDisplayName(elementById.type, BXnIaTteHbGmIjzaiUbGgDkmmUsw);
		}
	}

	Controller IControllerElementTarget.controller => mdMtFLRppZSNocHrBBYBFZxYWEAOA;

	Controller.Element IControllerElementTarget.element
	{
		get
		{
			if (mdMtFLRppZSNocHrBBYBFZxYWEAOA == null)
			{
				return null;
			}
			if (mdMtFLRppZSNocHrBBYBFZxYWEAOA.GetElementIdentifierById(rBCXEwNQREbUatvCSNcaKkzrPUmw) == null)
			{
				return null;
			}
			return mdMtFLRppZSNocHrBBYBFZxYWEAOA.GetElementById(rBCXEwNQREbUatvCSNcaKkzrPUmw);
		}
	}

	public ControllerElementIdentifier XXdoTMAhkoOWoAspvUtFjKPtDTng
	{
		get
		{
			if (mdMtFLRppZSNocHrBBYBFZxYWEAOA == null)
			{
				return null;
			}
			return mdMtFLRppZSNocHrBBYBFZxYWEAOA.GetElementIdentifierById(rBCXEwNQREbUatvCSNcaKkzrPUmw);
		}
	}

	IObjectPool IPoolableObject_Internal.pool
	{
		get
		{
			return YbNjfYOBGHEQuxNSzerVdeRDhmMI;
		}
		set
		{
			YbNjfYOBGHEQuxNSzerVdeRDhmMI = value;
		}
	}

	internal LmZJVlxQhHHugoUPZHYcFkBNejmj(Controller P_0, int P_1, AxisRange P_2)
	{
		mdMtFLRppZSNocHrBBYBFZxYWEAOA = P_0;
		rBCXEwNQREbUatvCSNcaKkzrPUmw = P_1;
		BXnIaTteHbGmIjzaiUbGgDkmmUsw = P_2;
	}

	internal void JgAOdeUoECaIumvCJFFFnJlFsXse(ControllerElementTarget P_0)
	{
		mdMtFLRppZSNocHrBBYBFZxYWEAOA = P_0.controller;
		rBCXEwNQREbUatvCSNcaKkzrPUmw = P_0.elementIdentifierId;
		BXnIaTteHbGmIjzaiUbGgDkmmUsw = P_0.axisRange;
	}

	internal void RCxoSproYtbjjjZJHPWhJMzgTfRK(IControllerElementTarget P_0)
	{
		mdMtFLRppZSNocHrBBYBFZxYWEAOA = P_0.controller;
		rBCXEwNQREbUatvCSNcaKkzrPUmw = P_0.elementIdentifierId;
		BXnIaTteHbGmIjzaiUbGgDkmmUsw = P_0.axisRange;
	}

	internal void dJaeSfkUYYxDDTAjBxJokFrAbPevA(LmZJVlxQhHHugoUPZHYcFkBNejmj P_0)
	{
		RCxoSproYtbjjjZJHPWhJMzgTfRK(P_0);
	}

	void IPoolableObject_Internal.Clear()
	{
		mdMtFLRppZSNocHrBBYBFZxYWEAOA = null;
		rBCXEwNQREbUatvCSNcaKkzrPUmw = -1;
		BXnIaTteHbGmIjzaiUbGgDkmmUsw = AxisRange.Full;
	}

	void IPoolableObject.Return()
	{
		if (YbNjfYOBGHEQuxNSzerVdeRDhmMI != null)
		{
			YbNjfYOBGHEQuxNSzerVdeRDhmMI.Return(this);
		}
	}

	internal static LmZJVlxQhHHugoUPZHYcFkBNejmj ELWWyDzHBwUGQphGAAKBAZQWBiGP()
	{
		if (AwJaXiLtnVioDxJQZoGYrRbtoLPG == null)
		{
			AwJaXiLtnVioDxJQZoGYrRbtoLPG = new ObjectPool<LmZJVlxQhHHugoUPZHYcFkBNejmj>(bnTZqzvsQahrOWlyEdDNtPlOZpdo._003C_003E9.zsLlhTciUTqKCBTKmFbanqiuqSdm);
		}
		return AwJaXiLtnVioDxJQZoGYrRbtoLPG.Get();
	}

	internal static LmZJVlxQhHHugoUPZHYcFkBNejmj pkDXGCQjAiRHdkJFwjAEsOHuJOav(ControllerElementTarget P_0)
	{
		LmZJVlxQhHHugoUPZHYcFkBNejmj lmZJVlxQhHHugoUPZHYcFkBNejmj = ELWWyDzHBwUGQphGAAKBAZQWBiGP();
		lmZJVlxQhHHugoUPZHYcFkBNejmj.JgAOdeUoECaIumvCJFFFnJlFsXse(P_0);
		return lmZJVlxQhHHugoUPZHYcFkBNejmj;
	}

	internal static void agEPZUxPMkDBVgJqZEjgICltJWCl(LmZJVlxQhHHugoUPZHYcFkBNejmj P_0)
	{
		if (P_0 != null && AwJaXiLtnVioDxJQZoGYrRbtoLPG != null)
		{
			AwJaXiLtnVioDxJQZoGYrRbtoLPG.Return(P_0);
		}
	}

	internal static LmZJVlxQhHHugoUPZHYcFkBNejmj TTzGqiHDtqPPkQzcZWKCaWViogRO()
	{
		return new LmZJVlxQhHHugoUPZHYcFkBNejmj(null, -1, AxisRange.Full);
	}

	void IDisposable.Dispose()
	{
		pTzkbNsjbRjwoesYJjukebtKCivdb(true);
		GC.SuppressFinalize(this);
	}

	protected void FgGTnogHOufXNyasRLeEMMvNuueK()
	{
		try
		{
			pTzkbNsjbRjwoesYJjukebtKCivdb(false);
		}
		finally
		{
			base.Finalize();
		}
	}

	private void pTzkbNsjbRjwoesYJjukebtKCivdb(bool P_0)
	{
		if (!tzvbKeZHAVOOGWmTgAOpqSjZKjff)
		{
			if (P_0)
			{
				((IPoolableObject)this).Return();
			}
			tzvbKeZHAVOOGWmTgAOpqSjZKjff = true;
		}
	}
}
