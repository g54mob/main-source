using System;
using Rewired;

internal sealed class fMlgSaItucfCTlOMuaOrAzViaQaCA : IControllerTemplateElementSource, IControllerTemplateAxisSource, IControllerTemplateButtonSource
{
	private ControllerTemplateElementType jRBPSVtNKcYysODJtvbPjIhQUBZJ;

	private bool GsWbeMRxbGxfWgwgwmCMIjzDllXg;

	private IControllerElementTarget mVGfEDJkBUWwIPTCEuHOmMoilJMqA;

	private IControllerElementTarget zvdLzDtbWPfGICVMECcjbsJHqFaiA;

	private IControllerElementTarget cADEtSwGPHzqPssWyQsAtdrHxZDg;

	ControllerTemplateElementSourceType IControllerTemplateElementSource.type => uAOMfTHsnTLbvEUpHTchXYOhMgjh.YyjJqQyIpkrdrxdRdEuEvKgCrLGD(jRBPSVtNKcYysODJtvbPjIhQUBZJ, false);

	bool IControllerTemplateAxisSource.splitAxis => GsWbeMRxbGxfWgwgwmCMIjzDllXg;

	IControllerElementTarget IControllerTemplateAxisSource.fullTarget => mVGfEDJkBUWwIPTCEuHOmMoilJMqA;

	IControllerElementTarget IControllerTemplateAxisSource.positiveTarget => zvdLzDtbWPfGICVMECcjbsJHqFaiA;

	IControllerElementTarget IControllerTemplateAxisSource.negativeTarget => cADEtSwGPHzqPssWyQsAtdrHxZDg;

	IControllerElementTarget IControllerTemplateButtonSource.target => mVGfEDJkBUWwIPTCEuHOmMoilJMqA;

	internal fMlgSaItucfCTlOMuaOrAzViaQaCA(ControllerTemplateElementType P_0, bool P_1, IControllerElementTarget P_2, IControllerElementTarget P_3, IControllerElementTarget P_4)
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
		jRBPSVtNKcYysODJtvbPjIhQUBZJ = P_0;
		GsWbeMRxbGxfWgwgwmCMIjzDllXg = P_1;
		mVGfEDJkBUWwIPTCEuHOmMoilJMqA = P_2;
		zvdLzDtbWPfGICVMECcjbsJHqFaiA = P_3;
		cADEtSwGPHzqPssWyQsAtdrHxZDg = P_4;
	}

	internal static fMlgSaItucfCTlOMuaOrAzViaQaCA ZthtDKCPytXmopXrdcSWOpqCJOGs(ControllerTemplateElementType P_0)
	{
		return new fMlgSaItucfCTlOMuaOrAzViaQaCA(P_0, false, WortGyCOkKTpqRUAkJvQBKSaUPen.ZthtDKCPytXmopXrdcSWOpqCJOGs(), WortGyCOkKTpqRUAkJvQBKSaUPen.ZthtDKCPytXmopXrdcSWOpqCJOGs(), WortGyCOkKTpqRUAkJvQBKSaUPen.ZthtDKCPytXmopXrdcSWOpqCJOGs());
	}
}
