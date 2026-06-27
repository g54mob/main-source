using System;
using Rewired;
using Rewired.Interfaces;
using Rewired.Utils.Classes.Utility;

internal sealed class QpmNXOwiqgDcvsLLtrkLzeVpLiAW : IControllerElementTarget, IPoolableObject_Internal, IPoolableObject, IDisposable
{
	[Serializable]
	private sealed class cgmXoGsaPLYOPMNeoSkiRdtmVdZu
	{
		public static readonly cgmXoGsaPLYOPMNeoSkiRdtmVdZu _003C_003E9 = new cgmXoGsaPLYOPMNeoSkiRdtmVdZu();

		public static Func<QpmNXOwiqgDcvsLLtrkLzeVpLiAW> _003C_003E9__30_0;

		internal QpmNXOwiqgDcvsLLtrkLzeVpLiAW mYcGhqrjZeBjJhREIKUVoTsMjqVnA()
		{
			return CxCLqVWbkPcebbGqlizpSUHShkpGb();
		}
	}

	private static ObjectPool<QpmNXOwiqgDcvsLLtrkLzeVpLiAW> BFmiURIgokJLAdYKzdNbHtrVBafR;

	private Controller tbjGNwSooyYepmfjltxonexgFUuhA;

	private int ysnZUTKPGhUxzvCSsRNVaJrBaGAT;

	private AxisRange CXWIleqhOYCJJvucMDOrMdcCsGCT;

	private IObjectPool DsebklDRswzatxCoTZVqBLkxjlyd;

	private bool sWLpJjUVwwhDYMDEnrYkMdlnOXdA;

	int IControllerElementTarget.elementIdentifierId => ysnZUTKPGhUxzvCSsRNVaJrBaGAT;

	AxisRange IControllerElementTarget.axisRange => CXWIleqhOYCJJvucMDOrMdcCsGCT;

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
			if (tbjGNwSooyYepmfjltxonexgFUuhA == null)
			{
				return string.Empty;
			}
			ControllerElementIdentifier elementIdentifierById = tbjGNwSooyYepmfjltxonexgFUuhA.GetElementIdentifierById(ysnZUTKPGhUxzvCSsRNVaJrBaGAT);
			if (elementIdentifierById == null)
			{
				return string.Empty;
			}
			Controller.Element elementById = tbjGNwSooyYepmfjltxonexgFUuhA.GetElementById(ysnZUTKPGhUxzvCSsRNVaJrBaGAT);
			if (elementById == null)
			{
				return string.Empty;
			}
			return elementIdentifierById.GetDisplayName(elementById.type, CXWIleqhOYCJJvucMDOrMdcCsGCT);
		}
	}

	Controller IControllerElementTarget.controller => tbjGNwSooyYepmfjltxonexgFUuhA;

	Controller.Element IControllerElementTarget.element
	{
		get
		{
			if (tbjGNwSooyYepmfjltxonexgFUuhA == null)
			{
				return null;
			}
			if (tbjGNwSooyYepmfjltxonexgFUuhA.GetElementIdentifierById(ysnZUTKPGhUxzvCSsRNVaJrBaGAT) == null)
			{
				return null;
			}
			return tbjGNwSooyYepmfjltxonexgFUuhA.GetElementById(ysnZUTKPGhUxzvCSsRNVaJrBaGAT);
		}
	}

	public ControllerElementIdentifier CWwenuVhFMpvnUfDdxmPXRZSRVQA
	{
		get
		{
			if (tbjGNwSooyYepmfjltxonexgFUuhA == null)
			{
				return null;
			}
			return tbjGNwSooyYepmfjltxonexgFUuhA.GetElementIdentifierById(ysnZUTKPGhUxzvCSsRNVaJrBaGAT);
		}
	}

	IObjectPool IPoolableObject_Internal.pool
	{
		get
		{
			return DsebklDRswzatxCoTZVqBLkxjlyd;
		}
		set
		{
			DsebklDRswzatxCoTZVqBLkxjlyd = value;
		}
	}

	internal QpmNXOwiqgDcvsLLtrkLzeVpLiAW(Controller P_0, int P_1, AxisRange P_2)
	{
		tbjGNwSooyYepmfjltxonexgFUuhA = P_0;
		ysnZUTKPGhUxzvCSsRNVaJrBaGAT = P_1;
		CXWIleqhOYCJJvucMDOrMdcCsGCT = P_2;
	}

	internal void CrfEpQXDtfVRBmhrzemgLCNpdqQgA(ControllerElementTarget P_0)
	{
		tbjGNwSooyYepmfjltxonexgFUuhA = P_0.controller;
		ysnZUTKPGhUxzvCSsRNVaJrBaGAT = P_0.elementIdentifierId;
		CXWIleqhOYCJJvucMDOrMdcCsGCT = P_0.axisRange;
	}

	internal void QvIjISgsJCWGyzBXtpySlhlMrLvx(IControllerElementTarget P_0)
	{
		tbjGNwSooyYepmfjltxonexgFUuhA = P_0.controller;
		ysnZUTKPGhUxzvCSsRNVaJrBaGAT = P_0.elementIdentifierId;
		CXWIleqhOYCJJvucMDOrMdcCsGCT = P_0.axisRange;
	}

	internal void uSXzWUNDXrpyAAzrhyMZjdreJJGt(QpmNXOwiqgDcvsLLtrkLzeVpLiAW P_0)
	{
		QvIjISgsJCWGyzBXtpySlhlMrLvx(P_0);
	}

	void IPoolableObject_Internal.Clear()
	{
		tbjGNwSooyYepmfjltxonexgFUuhA = null;
		ysnZUTKPGhUxzvCSsRNVaJrBaGAT = -1;
		CXWIleqhOYCJJvucMDOrMdcCsGCT = AxisRange.Full;
	}

	void IPoolableObject.Return()
	{
		if (DsebklDRswzatxCoTZVqBLkxjlyd != null)
		{
			DsebklDRswzatxCoTZVqBLkxjlyd.Return(this);
		}
	}

	internal static QpmNXOwiqgDcvsLLtrkLzeVpLiAW PVbGmwJgQLLnVhvIuPloLoQuTuqHA()
	{
		if (BFmiURIgokJLAdYKzdNbHtrVBafR == null)
		{
			BFmiURIgokJLAdYKzdNbHtrVBafR = new ObjectPool<QpmNXOwiqgDcvsLLtrkLzeVpLiAW>(cgmXoGsaPLYOPMNeoSkiRdtmVdZu._003C_003E9.mYcGhqrjZeBjJhREIKUVoTsMjqVnA);
		}
		return BFmiURIgokJLAdYKzdNbHtrVBafR.Get();
	}

	internal static QpmNXOwiqgDcvsLLtrkLzeVpLiAW kJmZGzDiTVCmqhsRWjvpOYJAhYIZ(ControllerElementTarget P_0)
	{
		QpmNXOwiqgDcvsLLtrkLzeVpLiAW qpmNXOwiqgDcvsLLtrkLzeVpLiAW = PVbGmwJgQLLnVhvIuPloLoQuTuqHA();
		qpmNXOwiqgDcvsLLtrkLzeVpLiAW.CrfEpQXDtfVRBmhrzemgLCNpdqQgA(P_0);
		return qpmNXOwiqgDcvsLLtrkLzeVpLiAW;
	}

	internal static void ldvVnfwjLZGuCeomzYzHsndJPPgX(QpmNXOwiqgDcvsLLtrkLzeVpLiAW P_0)
	{
		if (P_0 != null && BFmiURIgokJLAdYKzdNbHtrVBafR != null)
		{
			BFmiURIgokJLAdYKzdNbHtrVBafR.Return(P_0);
		}
	}

	internal static QpmNXOwiqgDcvsLLtrkLzeVpLiAW CxCLqVWbkPcebbGqlizpSUHShkpGb()
	{
		return new QpmNXOwiqgDcvsLLtrkLzeVpLiAW(null, -1, AxisRange.Full);
	}

	void IDisposable.Dispose()
	{
		aKMPlqlVasFrzmgUdGRXFihgfcFZ(true);
		GC.SuppressFinalize(this);
	}

	protected void AGbTcJdeVDBuCmfgvITnBwpnYcMaA()
	{
		try
		{
			aKMPlqlVasFrzmgUdGRXFihgfcFZ(false);
		}
		finally
		{
			base.Finalize();
		}
	}

	private void aKMPlqlVasFrzmgUdGRXFihgfcFZ(bool P_0)
	{
		if (!sWLpJjUVwwhDYMDEnrYkMdlnOXdA)
		{
			if (P_0)
			{
				((IPoolableObject)this).Return();
			}
			sWLpJjUVwwhDYMDEnrYkMdlnOXdA = true;
		}
	}
}
