using System;
using Rewired;

internal sealed class aZegFSKVtbYbsDQcYCKVgyHJAnPy : IControllerTemplateElementSource, IControllerTemplateAxisSource, IControllerTemplateButtonSource
{
	private ControllerTemplateElementType iDCCUtfTWxxiRkkzZhazaAppvzo;

	private bool HoZoxULbiFYxrKfSMkaoXVtyTCg;

	private IControllerElementTarget zYRfDpaHKTeTtdnogfJyqPkHckpW;

	private IControllerElementTarget wBkzkzlmZEAjjuxcefcTktPyjwBf;

	private IControllerElementTarget lQQXXqwJQWYRqUHgMATmcjbyYDk;

	ControllerTemplateElementSourceType IControllerTemplateElementSource.type => zRJHFfVYpYamSokTjXZVUKlCnAG.POoMsemLJtYIKBCNJkQeoSUfHSd(iDCCUtfTWxxiRkkzZhazaAppvzo, false);

	bool IControllerTemplateAxisSource.splitAxis => HoZoxULbiFYxrKfSMkaoXVtyTCg;

	IControllerElementTarget IControllerTemplateAxisSource.fullTarget => zYRfDpaHKTeTtdnogfJyqPkHckpW;

	IControllerElementTarget IControllerTemplateAxisSource.positiveTarget => wBkzkzlmZEAjjuxcefcTktPyjwBf;

	IControllerElementTarget IControllerTemplateAxisSource.negativeTarget => lQQXXqwJQWYRqUHgMATmcjbyYDk;

	IControllerElementTarget IControllerTemplateButtonSource.target => zYRfDpaHKTeTtdnogfJyqPkHckpW;

	internal aZegFSKVtbYbsDQcYCKVgyHJAnPy(ControllerTemplateElementType elementType, bool splitAxis, IControllerElementTarget target, IControllerElementTarget positiveTarget, IControllerElementTarget negativeTarget)
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
		iDCCUtfTWxxiRkkzZhazaAppvzo = elementType;
		HoZoxULbiFYxrKfSMkaoXVtyTCg = splitAxis;
		zYRfDpaHKTeTtdnogfJyqPkHckpW = target;
		wBkzkzlmZEAjjuxcefcTktPyjwBf = positiveTarget;
		lQQXXqwJQWYRqUHgMATmcjbyYDk = negativeTarget;
	}

	internal static aZegFSKVtbYbsDQcYCKVgyHJAnPy WDwRGsIphwHRFBDBHPIyGNmfHrtw(ControllerTemplateElementType P_0)
	{
		return new aZegFSKVtbYbsDQcYCKVgyHJAnPy(P_0, splitAxis: false, TtePFCKBdNmQRluqYJdgMTWVuTZ.WDwRGsIphwHRFBDBHPIyGNmfHrtw(), TtePFCKBdNmQRluqYJdgMTWVuTZ.WDwRGsIphwHRFBDBHPIyGNmfHrtw(), TtePFCKBdNmQRluqYJdgMTWVuTZ.WDwRGsIphwHRFBDBHPIyGNmfHrtw());
	}
}
