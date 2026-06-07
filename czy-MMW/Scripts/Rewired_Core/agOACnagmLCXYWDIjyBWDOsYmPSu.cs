using System;
using Rewired;

internal sealed class agOACnagmLCXYWDIjyBWDOsYmPSu : IControllerTemplateElementSource, IControllerTemplateAxisSource, IControllerTemplateButtonSource
{
	private ControllerTemplateElementType RYGavMVLrlCtldtcifNxpXiAJaUS;

	private bool HjRPObkXDHCDXJEFRyPkFGRmjRos;

	private IControllerElementTarget OQrrnsNIHfuEWofGlHgjnxswAYvg;

	private IControllerElementTarget WMiFBUyZJyIVVWjKrQEaWXeZWaef;

	private IControllerElementTarget stXVaaaoHZquakfUJomeyWvWBNTK;

	ControllerTemplateElementSourceType IControllerTemplateElementSource.type => pMvvECjJycyKibKKCAXEnFbBPTVk.cPFfIBupiwDuxenOpDirWhIpFzbuA(RYGavMVLrlCtldtcifNxpXiAJaUS, false);

	bool IControllerTemplateAxisSource.splitAxis => HjRPObkXDHCDXJEFRyPkFGRmjRos;

	IControllerElementTarget IControllerTemplateAxisSource.fullTarget => OQrrnsNIHfuEWofGlHgjnxswAYvg;

	IControllerElementTarget IControllerTemplateAxisSource.positiveTarget => WMiFBUyZJyIVVWjKrQEaWXeZWaef;

	IControllerElementTarget IControllerTemplateAxisSource.negativeTarget => stXVaaaoHZquakfUJomeyWvWBNTK;

	IControllerElementTarget IControllerTemplateButtonSource.target => OQrrnsNIHfuEWofGlHgjnxswAYvg;

	internal agOACnagmLCXYWDIjyBWDOsYmPSu(ControllerTemplateElementType P_0, bool P_1, IControllerElementTarget P_2, IControllerElementTarget P_3, IControllerElementTarget P_4)
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
		RYGavMVLrlCtldtcifNxpXiAJaUS = P_0;
		HjRPObkXDHCDXJEFRyPkFGRmjRos = P_1;
		OQrrnsNIHfuEWofGlHgjnxswAYvg = P_2;
		WMiFBUyZJyIVVWjKrQEaWXeZWaef = P_3;
		stXVaaaoHZquakfUJomeyWvWBNTK = P_4;
	}

	internal static agOACnagmLCXYWDIjyBWDOsYmPSu zixJGzEXzPtVLUqRvkHLoUbTNSVv(ControllerTemplateElementType P_0)
	{
		return new agOACnagmLCXYWDIjyBWDOsYmPSu(P_0, false, VpAKgrswCxoCdmGxzoexhctSYmGI.BAgYxiMqyGCojQPffpTNQctlDIrW(), VpAKgrswCxoCdmGxzoexhctSYmGI.BAgYxiMqyGCojQPffpTNQctlDIrW(), VpAKgrswCxoCdmGxzoexhctSYmGI.BAgYxiMqyGCojQPffpTNQctlDIrW());
	}
}
