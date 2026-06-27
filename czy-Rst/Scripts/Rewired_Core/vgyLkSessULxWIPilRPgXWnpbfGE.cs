using System;
using Rewired;

internal sealed class vgyLkSessULxWIPilRPgXWnpbfGE : IControllerTemplateElementSource, IControllerTemplateAxisSource, IControllerTemplateButtonSource
{
	private ControllerTemplateElementType SwgaxUXdePhhMtjaNPLirChMGIbA;

	private bool OivQaSyDZAGUFRiMBKuMRmrPcfgV;

	private IControllerElementTarget VuJesPFtOwwsGuvXjVUHhsSZmhxk;

	private IControllerElementTarget TMGaSdceBjgYXBKcbYECmOpcMswbb;

	private IControllerElementTarget rWzCCHyDDYiaugVNBaXCynRlncTj;

	ControllerTemplateElementSourceType IControllerTemplateElementSource.type => moNrVnhMyxFSevnVWYTclYHmdtVI.tWndHcbmixjydCbXifaFPduGQNfTb(SwgaxUXdePhhMtjaNPLirChMGIbA, false);

	bool IControllerTemplateAxisSource.splitAxis => OivQaSyDZAGUFRiMBKuMRmrPcfgV;

	IControllerElementTarget IControllerTemplateAxisSource.fullTarget => VuJesPFtOwwsGuvXjVUHhsSZmhxk;

	IControllerElementTarget IControllerTemplateAxisSource.positiveTarget => TMGaSdceBjgYXBKcbYECmOpcMswbb;

	IControllerElementTarget IControllerTemplateAxisSource.negativeTarget => rWzCCHyDDYiaugVNBaXCynRlncTj;

	IControllerElementTarget IControllerTemplateButtonSource.target => VuJesPFtOwwsGuvXjVUHhsSZmhxk;

	internal vgyLkSessULxWIPilRPgXWnpbfGE(ControllerTemplateElementType P_0, bool P_1, IControllerElementTarget P_2, IControllerElementTarget P_3, IControllerElementTarget P_4)
	{
		if (P_2 == null)
		{
			throw new ArgumentNullException("target");
		}
		if (P_4 == null)
		{
			throw new ArgumentNullException("positiveTarget");
		}
		if (P_3 == null)
		{
			throw new ArgumentNullException("negativeTarget");
		}
		SwgaxUXdePhhMtjaNPLirChMGIbA = P_0;
		OivQaSyDZAGUFRiMBKuMRmrPcfgV = P_1;
		VuJesPFtOwwsGuvXjVUHhsSZmhxk = P_2;
		TMGaSdceBjgYXBKcbYECmOpcMswbb = P_3;
		rWzCCHyDDYiaugVNBaXCynRlncTj = P_4;
	}

	internal static vgyLkSessULxWIPilRPgXWnpbfGE apVaRSCStYlLRACQjFZtmwVgcaPhb(ControllerTemplateElementType P_0)
	{
		return new vgyLkSessULxWIPilRPgXWnpbfGE(P_0, false, QpmNXOwiqgDcvsLLtrkLzeVpLiAW.CxCLqVWbkPcebbGqlizpSUHShkpGb(), QpmNXOwiqgDcvsLLtrkLzeVpLiAW.CxCLqVWbkPcebbGqlizpSUHShkpGb(), QpmNXOwiqgDcvsLLtrkLzeVpLiAW.CxCLqVWbkPcebbGqlizpSUHShkpGb());
	}
}
