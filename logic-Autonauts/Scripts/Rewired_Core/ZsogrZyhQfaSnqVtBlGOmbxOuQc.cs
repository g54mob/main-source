using System;
using Rewired;

internal sealed class ZsogrZyhQfaSnqVtBlGOmbxOuQc : IControllerTemplateElementSource, IControllerTemplateAxisSource, IControllerTemplateButtonSource
{
	private ControllerTemplateElementType ZcCJfoFOnfaVWPxSGABewnPoqKP;

	private bool wMZpJNjUZRjNottxZqRxRvVfpFT;

	private IControllerElementTarget EaBgueQMzRKPoEnRrsktTmWKrOG;

	private IControllerElementTarget VZwBmuLotUowZBRFvBEDvnzbxoH;

	private IControllerElementTarget QUEEerSLtUzNrliJHbbzcnXpKDF;

	ControllerTemplateElementSourceType IControllerTemplateElementSource.type
	{
		get
		{
			return KVNLqybISELdZVRJeMgGCnyHIcv.ctsjnxILofJVXeJcAthlmduipVQ(ZcCJfoFOnfaVWPxSGABewnPoqKP, false);
		}
	}

	bool IControllerTemplateAxisSource.splitAxis
	{
		get
		{
			return wMZpJNjUZRjNottxZqRxRvVfpFT;
		}
	}

	IControllerElementTarget IControllerTemplateAxisSource.fullTarget
	{
		get
		{
			return EaBgueQMzRKPoEnRrsktTmWKrOG;
		}
	}

	IControllerElementTarget IControllerTemplateAxisSource.positiveTarget
	{
		get
		{
			return VZwBmuLotUowZBRFvBEDvnzbxoH;
		}
	}

	IControllerElementTarget IControllerTemplateAxisSource.negativeTarget
	{
		get
		{
			return QUEEerSLtUzNrliJHbbzcnXpKDF;
		}
	}

	IControllerElementTarget IControllerTemplateButtonSource.target
	{
		get
		{
			return EaBgueQMzRKPoEnRrsktTmWKrOG;
		}
	}

	internal ZsogrZyhQfaSnqVtBlGOmbxOuQc(ControllerTemplateElementType elementType, bool splitAxis, IControllerElementTarget target, IControllerElementTarget positiveTarget, IControllerElementTarget negativeTarget)
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
		ZcCJfoFOnfaVWPxSGABewnPoqKP = elementType;
		wMZpJNjUZRjNottxZqRxRvVfpFT = splitAxis;
		EaBgueQMzRKPoEnRrsktTmWKrOG = target;
		VZwBmuLotUowZBRFvBEDvnzbxoH = positiveTarget;
		QUEEerSLtUzNrliJHbbzcnXpKDF = negativeTarget;
	}

	internal static ZsogrZyhQfaSnqVtBlGOmbxOuQc dawcjtsNOciSWAmaKVxbSHSsCoQM(ControllerTemplateElementType P_0)
	{
		return new ZsogrZyhQfaSnqVtBlGOmbxOuQc(P_0, false, auqagPyfULkTIGtBZGYbYCoEQli.dawcjtsNOciSWAmaKVxbSHSsCoQM(), auqagPyfULkTIGtBZGYbYCoEQli.dawcjtsNOciSWAmaKVxbSHSsCoQM(), auqagPyfULkTIGtBZGYbYCoEQli.dawcjtsNOciSWAmaKVxbSHSsCoQM());
	}
}
