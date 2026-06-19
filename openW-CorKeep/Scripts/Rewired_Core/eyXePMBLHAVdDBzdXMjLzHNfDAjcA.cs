using System;
using Rewired;

internal sealed class eyXePMBLHAVdDBzdXMjLzHNfDAjcA : IControllerTemplateElementSource, IControllerTemplateAxisSource, IControllerTemplateButtonSource
{
	private ControllerTemplateElementType RLHNgvoJAqHDiceRAhxeGTRxThdIb;

	private bool DzQGQKbNoWMqSIEapSUhLtiZMCZz;

	private IControllerElementTarget SOmgwXuvbsHCXDllFDtsYJFTrPQDb;

	private IControllerElementTarget KOnuSxXhirjwEaFWJwcbwXamfVTgA;

	private IControllerElementTarget onUKIFNUqOKClfSbbiQtAmQxcCiP;

	ControllerTemplateElementSourceType IControllerTemplateElementSource.type => nwsTruCLxjorysrNysDvPYrmMcrb.arCTUwHoZlQoimjhZKkmNbpIBqCq(RLHNgvoJAqHDiceRAhxeGTRxThdIb, false);

	bool IControllerTemplateAxisSource.splitAxis => DzQGQKbNoWMqSIEapSUhLtiZMCZz;

	IControllerElementTarget IControllerTemplateAxisSource.fullTarget => SOmgwXuvbsHCXDllFDtsYJFTrPQDb;

	IControllerElementTarget IControllerTemplateAxisSource.positiveTarget => KOnuSxXhirjwEaFWJwcbwXamfVTgA;

	IControllerElementTarget IControllerTemplateAxisSource.negativeTarget => onUKIFNUqOKClfSbbiQtAmQxcCiP;

	IControllerElementTarget IControllerTemplateButtonSource.target => SOmgwXuvbsHCXDllFDtsYJFTrPQDb;

	internal eyXePMBLHAVdDBzdXMjLzHNfDAjcA(ControllerTemplateElementType P_0, bool P_1, IControllerElementTarget P_2, IControllerElementTarget P_3, IControllerElementTarget P_4)
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
		RLHNgvoJAqHDiceRAhxeGTRxThdIb = P_0;
		DzQGQKbNoWMqSIEapSUhLtiZMCZz = P_1;
		SOmgwXuvbsHCXDllFDtsYJFTrPQDb = P_2;
		KOnuSxXhirjwEaFWJwcbwXamfVTgA = P_3;
		onUKIFNUqOKClfSbbiQtAmQxcCiP = P_4;
	}

	internal static eyXePMBLHAVdDBzdXMjLzHNfDAjcA fycPWQxAWErCODAuTpxKKuGkZEgl(ControllerTemplateElementType P_0)
	{
		return new eyXePMBLHAVdDBzdXMjLzHNfDAjcA(P_0, false, JrHSDKJJRmfQuafjRnKcPPKpIBhpA.HgjmLTdDFHYuwPSDLFOPmOvQPEnb(), JrHSDKJJRmfQuafjRnKcPPKpIBhpA.HgjmLTdDFHYuwPSDLFOPmOvQPEnb(), JrHSDKJJRmfQuafjRnKcPPKpIBhpA.HgjmLTdDFHYuwPSDLFOPmOvQPEnb());
	}
}
