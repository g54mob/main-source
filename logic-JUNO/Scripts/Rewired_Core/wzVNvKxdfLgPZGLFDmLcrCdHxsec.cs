using System;
using Rewired;

internal sealed class wzVNvKxdfLgPZGLFDmLcrCdHxsec : IControllerTemplateElementSource, IControllerTemplateAxisSource, IControllerTemplateButtonSource
{
	private ControllerTemplateElementType JsTsaUCcoHWhkdMnWomkVUINALkh;

	private bool TFEEoflHWfifYBmShLTzpZbzbHSf;

	private IControllerElementTarget ENmcPcOgNRdLVymDXMekJCWvqkPV;

	private IControllerElementTarget MJzOaEtEESBrGScgRCfzeczIOgSHb;

	private IControllerElementTarget kUKGegzWjvRlwcHzKHzaMHBthhXA;

	ControllerTemplateElementSourceType IControllerTemplateElementSource.type => tqmHLUqTfYnnflPJaWxRPIPYjlrx.uVGtRDnnhCsBeprNVAHmNnysXHJm(JsTsaUCcoHWhkdMnWomkVUINALkh, false);

	bool IControllerTemplateAxisSource.splitAxis => TFEEoflHWfifYBmShLTzpZbzbHSf;

	IControllerElementTarget IControllerTemplateAxisSource.fullTarget => ENmcPcOgNRdLVymDXMekJCWvqkPV;

	IControllerElementTarget IControllerTemplateAxisSource.positiveTarget => MJzOaEtEESBrGScgRCfzeczIOgSHb;

	IControllerElementTarget IControllerTemplateAxisSource.negativeTarget => kUKGegzWjvRlwcHzKHzaMHBthhXA;

	IControllerElementTarget IControllerTemplateButtonSource.target => ENmcPcOgNRdLVymDXMekJCWvqkPV;

	internal wzVNvKxdfLgPZGLFDmLcrCdHxsec(ControllerTemplateElementType P_0, bool P_1, IControllerElementTarget P_2, IControllerElementTarget P_3, IControllerElementTarget P_4)
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
		JsTsaUCcoHWhkdMnWomkVUINALkh = P_0;
		TFEEoflHWfifYBmShLTzpZbzbHSf = P_1;
		ENmcPcOgNRdLVymDXMekJCWvqkPV = P_2;
		MJzOaEtEESBrGScgRCfzeczIOgSHb = P_3;
		kUKGegzWjvRlwcHzKHzaMHBthhXA = P_4;
	}

	internal static wzVNvKxdfLgPZGLFDmLcrCdHxsec zEoyTjVDsjfgGhOOPsiGOIZOMqbcb(ControllerTemplateElementType P_0)
	{
		return new wzVNvKxdfLgPZGLFDmLcrCdHxsec(P_0, false, LmZJVlxQhHHugoUPZHYcFkBNejmj.TTzGqiHDtqPPkQzcZWKCaWViogRO(), LmZJVlxQhHHugoUPZHYcFkBNejmj.TTzGqiHDtqPPkQzcZWKCaWViogRO(), LmZJVlxQhHHugoUPZHYcFkBNejmj.TTzGqiHDtqPPkQzcZWKCaWViogRO());
	}
}
