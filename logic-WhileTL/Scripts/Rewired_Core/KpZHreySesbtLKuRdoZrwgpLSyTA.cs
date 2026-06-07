using System;
using Rewired;

internal sealed class KpZHreySesbtLKuRdoZrwgpLSyTA : IControllerTemplateElementSource, IControllerTemplateAxisSource, IControllerTemplateButtonSource
{
	private ControllerTemplateElementType QoNNWCBWhstwCjczWDBfosWZEUNR;

	private bool vbQJczfMXYzGaRnQPdOcDRWMjdTq;

	private IControllerElementTarget BzUaLEMAzIdLahimlKbygLBhWDUxA;

	private IControllerElementTarget CmruFYXdmPffgvVgtSoFpCoUXcem;

	private IControllerElementTarget PxVqLFQvvNjKrDVeTTqugnWMbbBP;

	ControllerTemplateElementSourceType IControllerTemplateElementSource.type => DXYiJElpUHxcPboaihvPaElwMWxMA.zHblEHYQmkuCTOULSdessKzBllYk(QoNNWCBWhstwCjczWDBfosWZEUNR, false);

	bool IControllerTemplateAxisSource.splitAxis => vbQJczfMXYzGaRnQPdOcDRWMjdTq;

	IControllerElementTarget IControllerTemplateAxisSource.fullTarget => BzUaLEMAzIdLahimlKbygLBhWDUxA;

	IControllerElementTarget IControllerTemplateAxisSource.positiveTarget => CmruFYXdmPffgvVgtSoFpCoUXcem;

	IControllerElementTarget IControllerTemplateAxisSource.negativeTarget => PxVqLFQvvNjKrDVeTTqugnWMbbBP;

	IControllerElementTarget IControllerTemplateButtonSource.target => BzUaLEMAzIdLahimlKbygLBhWDUxA;

	internal KpZHreySesbtLKuRdoZrwgpLSyTA(ControllerTemplateElementType P_0, bool P_1, IControllerElementTarget P_2, IControllerElementTarget P_3, IControllerElementTarget P_4)
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
		QoNNWCBWhstwCjczWDBfosWZEUNR = P_0;
		vbQJczfMXYzGaRnQPdOcDRWMjdTq = P_1;
		BzUaLEMAzIdLahimlKbygLBhWDUxA = P_2;
		CmruFYXdmPffgvVgtSoFpCoUXcem = P_3;
		PxVqLFQvvNjKrDVeTTqugnWMbbBP = P_4;
	}

	internal static KpZHreySesbtLKuRdoZrwgpLSyTA ckrUQVcMUnHdCWgDQIywBRRTSKOn(ControllerTemplateElementType P_0)
	{
		return new KpZHreySesbtLKuRdoZrwgpLSyTA(P_0, false, xExZPlwOYSQiIkFqHDDyWovrVnsK.ckrUQVcMUnHdCWgDQIywBRRTSKOn(), xExZPlwOYSQiIkFqHDDyWovrVnsK.ckrUQVcMUnHdCWgDQIywBRRTSKOn(), xExZPlwOYSQiIkFqHDDyWovrVnsK.ckrUQVcMUnHdCWgDQIywBRRTSKOn());
	}
}
