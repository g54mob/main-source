using System;
using Rewired;

internal sealed class uRvJKnYnMDIXSDaSbLxWqKFPfOYl : IControllerTemplateElementSource, IControllerTemplateAxisSource, IControllerTemplateButtonSource
{
	private ControllerTemplateElementType yWNDZKfljBHzdFXVgCeuIlnzKfx;

	private bool JAifvaXJAhyLKbiUjZpZxjKunhO;

	private IControllerElementTarget lpUDMEmXzhZtLWlAXkyddMkXuPw;

	private IControllerElementTarget exnphOzPkgGNVFBITSTKRCNuaBIJ;

	private IControllerElementTarget vbVMlFgbjkyEWxAhlphhAkpcjRz;

	ControllerTemplateElementSourceType IControllerTemplateElementSource.type => bEUEMZWgpCwBXKGSoWTyQESUVD.XTtNjVcbsHiNgoCtwpmbAFGrKts(yWNDZKfljBHzdFXVgCeuIlnzKfx, false);

	bool IControllerTemplateAxisSource.splitAxis => JAifvaXJAhyLKbiUjZpZxjKunhO;

	IControllerElementTarget IControllerTemplateAxisSource.fullTarget => lpUDMEmXzhZtLWlAXkyddMkXuPw;

	IControllerElementTarget IControllerTemplateAxisSource.positiveTarget => exnphOzPkgGNVFBITSTKRCNuaBIJ;

	IControllerElementTarget IControllerTemplateAxisSource.negativeTarget => vbVMlFgbjkyEWxAhlphhAkpcjRz;

	IControllerElementTarget IControllerTemplateButtonSource.target => lpUDMEmXzhZtLWlAXkyddMkXuPw;

	internal uRvJKnYnMDIXSDaSbLxWqKFPfOYl(ControllerTemplateElementType elementType, bool splitAxis, IControllerElementTarget target, IControllerElementTarget positiveTarget, IControllerElementTarget negativeTarget)
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
		yWNDZKfljBHzdFXVgCeuIlnzKfx = elementType;
		JAifvaXJAhyLKbiUjZpZxjKunhO = splitAxis;
		lpUDMEmXzhZtLWlAXkyddMkXuPw = target;
		exnphOzPkgGNVFBITSTKRCNuaBIJ = positiveTarget;
		vbVMlFgbjkyEWxAhlphhAkpcjRz = negativeTarget;
	}

	internal static uRvJKnYnMDIXSDaSbLxWqKFPfOYl AapzLJOSMOptjeIdgEhpjxotmUy(ControllerTemplateElementType P_0)
	{
		return new uRvJKnYnMDIXSDaSbLxWqKFPfOYl(P_0, splitAxis: false, BIzzMnQbYdgezaQAnFAxzmYBsLQP.AapzLJOSMOptjeIdgEhpjxotmUy(), BIzzMnQbYdgezaQAnFAxzmYBsLQP.AapzLJOSMOptjeIdgEhpjxotmUy(), BIzzMnQbYdgezaQAnFAxzmYBsLQP.AapzLJOSMOptjeIdgEhpjxotmUy());
	}
}
