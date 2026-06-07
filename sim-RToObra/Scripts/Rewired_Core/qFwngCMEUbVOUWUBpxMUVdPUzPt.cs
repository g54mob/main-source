using System;
using Rewired;

internal sealed class qFwngCMEUbVOUWUBpxMUVdPUzPt : IControllerTemplateElementSource, IControllerTemplateAxisSource, IControllerTemplateButtonSource
{
	private ControllerTemplateElementType geStyfnIbdATvfzZcIGcHdNutpK;

	private bool XqXfOULwLZmkXJjmjWVxcYNhpUY;

	private IControllerElementTarget pjZjqriAjRgtRcmANkmfeRSKwaR;

	private IControllerElementTarget ixeGQvrDkMDBHlwMXLwCORhjmGj;

	private IControllerElementTarget hHYozqcDhYxqWXKItbWfRZZjOVI;

	ControllerTemplateElementSourceType IControllerTemplateElementSource.type
	{
		get
		{
			return jHLGlrXjGMMIuxAEONcGlnwHltw.XSaogomKcrJgoEtpmWlrLVouCEB(geStyfnIbdATvfzZcIGcHdNutpK, false);
		}
	}

	bool IControllerTemplateAxisSource.splitAxis
	{
		get
		{
			return XqXfOULwLZmkXJjmjWVxcYNhpUY;
		}
	}

	IControllerElementTarget IControllerTemplateAxisSource.fullTarget
	{
		get
		{
			return pjZjqriAjRgtRcmANkmfeRSKwaR;
		}
	}

	IControllerElementTarget IControllerTemplateAxisSource.positiveTarget
	{
		get
		{
			return ixeGQvrDkMDBHlwMXLwCORhjmGj;
		}
	}

	IControllerElementTarget IControllerTemplateAxisSource.negativeTarget
	{
		get
		{
			return hHYozqcDhYxqWXKItbWfRZZjOVI;
		}
	}

	IControllerElementTarget IControllerTemplateButtonSource.target
	{
		get
		{
			return pjZjqriAjRgtRcmANkmfeRSKwaR;
		}
	}

	internal qFwngCMEUbVOUWUBpxMUVdPUzPt(ControllerTemplateElementType elementType, bool splitAxis, IControllerElementTarget target, IControllerElementTarget positiveTarget, IControllerElementTarget negativeTarget)
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
		geStyfnIbdATvfzZcIGcHdNutpK = elementType;
		XqXfOULwLZmkXJjmjWVxcYNhpUY = splitAxis;
		pjZjqriAjRgtRcmANkmfeRSKwaR = target;
		ixeGQvrDkMDBHlwMXLwCORhjmGj = positiveTarget;
		hHYozqcDhYxqWXKItbWfRZZjOVI = negativeTarget;
	}

	internal static qFwngCMEUbVOUWUBpxMUVdPUzPt EacwNkMfYaHjbQRdeDfnuPOoebXI(ControllerTemplateElementType P_0)
	{
		return new qFwngCMEUbVOUWUBpxMUVdPUzPt(P_0, false, RPsfaUSCQTmtficMhKUbbYyMecr.EacwNkMfYaHjbQRdeDfnuPOoebXI(), RPsfaUSCQTmtficMhKUbbYyMecr.EacwNkMfYaHjbQRdeDfnuPOoebXI(), RPsfaUSCQTmtficMhKUbbYyMecr.EacwNkMfYaHjbQRdeDfnuPOoebXI());
	}
}
