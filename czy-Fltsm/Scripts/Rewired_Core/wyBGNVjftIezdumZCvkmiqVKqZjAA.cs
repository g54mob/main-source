using System;
using Rewired;

internal sealed class wyBGNVjftIezdumZCvkmiqVKqZjAA : IControllerTemplateElementSource, IControllerTemplateAxisSource, IControllerTemplateButtonSource
{
	private ControllerTemplateElementType HPZywcWnumtDOFBbTomBOjFArknW;

	private bool XZMEQTfhMQBmgzRGkvZMsBwcoDNO;

	private IControllerElementTarget OiygkIEAVaTClARZWHyXGaRstSQr;

	private IControllerElementTarget YRjoKezlMluiumaaOonGrcsPQUXU;

	private IControllerElementTarget cLGdYOdtIIRANqQTgqFSfROYZZabA;

	ControllerTemplateElementSourceType IControllerTemplateElementSource.type => bVcNkmaJvbHeBNQRpaleQvWHeXqv.omIVfvtBbvSnYNTqKHHPWFbbdjKH(HPZywcWnumtDOFBbTomBOjFArknW, false);

	bool IControllerTemplateAxisSource.splitAxis => XZMEQTfhMQBmgzRGkvZMsBwcoDNO;

	IControllerElementTarget IControllerTemplateAxisSource.fullTarget => OiygkIEAVaTClARZWHyXGaRstSQr;

	IControllerElementTarget IControllerTemplateAxisSource.positiveTarget => YRjoKezlMluiumaaOonGrcsPQUXU;

	IControllerElementTarget IControllerTemplateAxisSource.negativeTarget => cLGdYOdtIIRANqQTgqFSfROYZZabA;

	IControllerElementTarget IControllerTemplateButtonSource.target => OiygkIEAVaTClARZWHyXGaRstSQr;

	internal wyBGNVjftIezdumZCvkmiqVKqZjAA(ControllerTemplateElementType P_0, bool P_1, IControllerElementTarget P_2, IControllerElementTarget P_3, IControllerElementTarget P_4)
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
		HPZywcWnumtDOFBbTomBOjFArknW = P_0;
		XZMEQTfhMQBmgzRGkvZMsBwcoDNO = P_1;
		OiygkIEAVaTClARZWHyXGaRstSQr = P_2;
		YRjoKezlMluiumaaOonGrcsPQUXU = P_3;
		cLGdYOdtIIRANqQTgqFSfROYZZabA = P_4;
	}

	internal static wyBGNVjftIezdumZCvkmiqVKqZjAA tveLONDaoWrbqwSWMitxVOABUhik(ControllerTemplateElementType P_0)
	{
		return new wyBGNVjftIezdumZCvkmiqVKqZjAA(P_0, false, XuJpBJvxrqVOEMAPQQDPCLYEUJbk.LMxcmGJjdPVYSyQoCbYjlrUbIUQQ(), XuJpBJvxrqVOEMAPQQDPCLYEUJbk.LMxcmGJjdPVYSyQoCbYjlrUbIUQQ(), XuJpBJvxrqVOEMAPQQDPCLYEUJbk.LMxcmGJjdPVYSyQoCbYjlrUbIUQQ());
	}
}
