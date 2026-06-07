using System;
using Rewired;

internal sealed class OyJZlVlspSSqIjquoKnBSuwliGg : IControllerTemplateElementSource, IControllerTemplateAxisSource, IControllerTemplateButtonSource
{
	private ControllerTemplateElementType IDlBgcIyMAualOodjeMvFCUPFMBW;

	private bool fMyKPPmwkmDPBsiIqDBgrTMAFtH;

	private IControllerElementTarget PzcnjoNqEkQAHZfcMtoihQXpiFG;

	private IControllerElementTarget YdNgIybWFhQcLBGkYQDXPLmAxRec;

	private IControllerElementTarget NsdxkvLbYxGZCeUywBfoOVEGwrN;

	ControllerTemplateElementSourceType IControllerTemplateElementSource.type => XqmnYoifzflCsKxcFaHDewlkEkh.rqHcoxLXFOnPmvALtcjiEEdZOdIu(IDlBgcIyMAualOodjeMvFCUPFMBW, false);

	bool IControllerTemplateAxisSource.splitAxis => fMyKPPmwkmDPBsiIqDBgrTMAFtH;

	IControllerElementTarget IControllerTemplateAxisSource.fullTarget => PzcnjoNqEkQAHZfcMtoihQXpiFG;

	IControllerElementTarget IControllerTemplateAxisSource.positiveTarget => YdNgIybWFhQcLBGkYQDXPLmAxRec;

	IControllerElementTarget IControllerTemplateAxisSource.negativeTarget => NsdxkvLbYxGZCeUywBfoOVEGwrN;

	IControllerElementTarget IControllerTemplateButtonSource.target => PzcnjoNqEkQAHZfcMtoihQXpiFG;

	internal OyJZlVlspSSqIjquoKnBSuwliGg(ControllerTemplateElementType elementType, bool splitAxis, IControllerElementTarget target, IControllerElementTarget positiveTarget, IControllerElementTarget negativeTarget)
	{
		if (target == null)
		{
			throw new ArgumentNullException("target");
		}
		if (negativeTarget == null)
		{
			throw new ArgumentNullException("positiveTarget");
		}
		if (positiveTarget == null)
		{
			throw new ArgumentNullException("negativeTarget");
		}
		IDlBgcIyMAualOodjeMvFCUPFMBW = elementType;
		fMyKPPmwkmDPBsiIqDBgrTMAFtH = splitAxis;
		PzcnjoNqEkQAHZfcMtoihQXpiFG = target;
		YdNgIybWFhQcLBGkYQDXPLmAxRec = positiveTarget;
		NsdxkvLbYxGZCeUywBfoOVEGwrN = negativeTarget;
	}

	internal static OyJZlVlspSSqIjquoKnBSuwliGg wDPkgttzlRAAdnlXproyhCFJCGW(ControllerTemplateElementType P_0)
	{
		return new OyJZlVlspSSqIjquoKnBSuwliGg(P_0, splitAxis: false, rRNhjRpfbeHXdDjgkCEeGsrflVcU.wDPkgttzlRAAdnlXproyhCFJCGW(), rRNhjRpfbeHXdDjgkCEeGsrflVcU.wDPkgttzlRAAdnlXproyhCFJCGW(), rRNhjRpfbeHXdDjgkCEeGsrflVcU.wDPkgttzlRAAdnlXproyhCFJCGW());
	}
}
