using System;
using Rewired;

internal sealed class JuxAmvlvwOWoqJaGcoORwookXVmr : IControllerTemplateElementSource, IControllerTemplateAxisSource, IControllerTemplateButtonSource
{
	private ControllerTemplateElementType iMluJCAfvykITswgpmWuMSmkxgar;

	private bool ozcGrjpiHEEbvIRDAGnbaiZEfZMqA;

	private IControllerElementTarget rgEJZoKLUwkNarJMiqOuOncQdCVQ;

	private IControllerElementTarget tDFNnOlaDdmttNafyYLfxPFrAWEP;

	private IControllerElementTarget ZLwEncifDEKROKlEYErzYVxgDRpqA;

	ControllerTemplateElementSourceType IControllerTemplateElementSource.type => SVQbmGoCgjXlQooYDoNZCFflMVzP.HCkgUNddabJoZqfMogdaWOENwpBY(iMluJCAfvykITswgpmWuMSmkxgar, false);

	bool IControllerTemplateAxisSource.splitAxis => ozcGrjpiHEEbvIRDAGnbaiZEfZMqA;

	IControllerElementTarget IControllerTemplateAxisSource.fullTarget => rgEJZoKLUwkNarJMiqOuOncQdCVQ;

	IControllerElementTarget IControllerTemplateAxisSource.positiveTarget => tDFNnOlaDdmttNafyYLfxPFrAWEP;

	IControllerElementTarget IControllerTemplateAxisSource.negativeTarget => ZLwEncifDEKROKlEYErzYVxgDRpqA;

	IControllerElementTarget IControllerTemplateButtonSource.target => rgEJZoKLUwkNarJMiqOuOncQdCVQ;

	internal JuxAmvlvwOWoqJaGcoORwookXVmr(ControllerTemplateElementType P_0, bool P_1, IControllerElementTarget P_2, IControllerElementTarget P_3, IControllerElementTarget P_4)
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
		iMluJCAfvykITswgpmWuMSmkxgar = P_0;
		ozcGrjpiHEEbvIRDAGnbaiZEfZMqA = P_1;
		rgEJZoKLUwkNarJMiqOuOncQdCVQ = P_2;
		tDFNnOlaDdmttNafyYLfxPFrAWEP = P_3;
		ZLwEncifDEKROKlEYErzYVxgDRpqA = P_4;
	}

	internal static JuxAmvlvwOWoqJaGcoORwookXVmr CTMmuhVtiKsahRTskWIWTjBxGsrE(ControllerTemplateElementType P_0)
	{
		return new JuxAmvlvwOWoqJaGcoORwookXVmr(P_0, false, qgrPcdpmqcnDBnMOyFdgBKbuNEyIb.yKFZOeFZwVLSDDajwmHMnTpZEMVh(), qgrPcdpmqcnDBnMOyFdgBKbuNEyIb.yKFZOeFZwVLSDDajwmHMnTpZEMVh(), qgrPcdpmqcnDBnMOyFdgBKbuNEyIb.yKFZOeFZwVLSDDajwmHMnTpZEMVh());
	}
}
