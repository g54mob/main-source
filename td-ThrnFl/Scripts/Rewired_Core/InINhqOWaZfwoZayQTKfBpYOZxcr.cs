using System;
using System.Runtime.CompilerServices;
using Rewired;

internal struct InINhqOWaZfwoZayQTKfBpYOZxcr : IEquatable<InINhqOWaZfwoZayQTKfBpYOZxcr>
{
	public KeyboardKeyCode emHhlTirQktKsphoBdFmeloSKzKL;

	public ModifierKey diBtOwVMYGOoFtgFjLVezMocrIcE;

	public ModifierKey hlQhVNXnHAJcwJzarWcgfWLTEPbHA;

	public ModifierKey zIfGIqxwpIeXWkYJlytJzAssSfAK;

	public InINhqOWaZfwoZayQTKfBpYOZxcr(KeyboardKeyCode P_0, ModifierKey P_1, ModifierKey P_2, ModifierKey P_3)
	{
		emHhlTirQktKsphoBdFmeloSKzKL = P_0;
		diBtOwVMYGOoFtgFjLVezMocrIcE = P_1;
		hlQhVNXnHAJcwJzarWcgfWLTEPbHA = P_2;
		zIfGIqxwpIeXWkYJlytJzAssSfAK = P_3;
	}

	public void KaSiLZvmcKbCVrEkYUifcHUJXYNp()
	{
		if (emHhlTirQktKsphoBdFmeloSKzKL != KeyboardKeyCode.None)
		{
			emHhlTirQktKsphoBdFmeloSKzKL = KeyboardKeyCode.None;
		}
		if (diBtOwVMYGOoFtgFjLVezMocrIcE != ModifierKey.None)
		{
			diBtOwVMYGOoFtgFjLVezMocrIcE = ModifierKey.None;
		}
		if (hlQhVNXnHAJcwJzarWcgfWLTEPbHA != ModifierKey.None)
		{
			hlQhVNXnHAJcwJzarWcgfWLTEPbHA = ModifierKey.None;
		}
		if (zIfGIqxwpIeXWkYJlytJzAssSfAK != ModifierKey.None)
		{
			zIfGIqxwpIeXWkYJlytJzAssSfAK = ModifierKey.None;
		}
	}

	public bool Equals(InINhqOWaZfwoZayQTKfBpYOZxcr other)
	{
		if (emHhlTirQktKsphoBdFmeloSKzKL == other.emHhlTirQktKsphoBdFmeloSKzKL && diBtOwVMYGOoFtgFjLVezMocrIcE == other.diBtOwVMYGOoFtgFjLVezMocrIcE && hlQhVNXnHAJcwJzarWcgfWLTEPbHA == other.hlQhVNXnHAJcwJzarWcgfWLTEPbHA)
		{
			return zIfGIqxwpIeXWkYJlytJzAssSfAK == other.zIfGIqxwpIeXWkYJlytJzAssSfAK;
		}
		return false;
	}

	bool IEquatable<InINhqOWaZfwoZayQTKfBpYOZxcr>.Equals(InINhqOWaZfwoZayQTKfBpYOZxcr other)
	{
		//ILSpy generated this explicit interface implementation from .override directive in Equals
		return this.Equals(other);
	}

	public bool BGEDkRqzICNSINOXazNLdOzoMHUN(object P_0)
	{
		if (P_0 == null || !(P_0 is InINhqOWaZfwoZayQTKfBpYOZxcr))
		{
			return false;
		}
		return Equals((InINhqOWaZfwoZayQTKfBpYOZxcr)P_0);
	}

	public int EYaGMSEyulrZEtRPDMmuDEfIyXBDA()
	{
		return (((17 * 29 + emHhlTirQktKsphoBdFmeloSKzKL.GetHashCode()) * 29 + diBtOwVMYGOoFtgFjLVezMocrIcE.GetHashCode()) * 29 + hlQhVNXnHAJcwJzarWcgfWLTEPbHA.GetHashCode()) * 29 + zIfGIqxwpIeXWkYJlytJzAssSfAK.GetHashCode();
	}

	[SpecialName]
	public static bool KTQkteKBPMOItfcJPKeIoWkaTeli(InINhqOWaZfwoZayQTKfBpYOZxcr P_0, InINhqOWaZfwoZayQTKfBpYOZxcr P_1)
	{
		if (P_0.emHhlTirQktKsphoBdFmeloSKzKL == P_1.emHhlTirQktKsphoBdFmeloSKzKL && P_0.diBtOwVMYGOoFtgFjLVezMocrIcE == P_1.diBtOwVMYGOoFtgFjLVezMocrIcE && P_0.hlQhVNXnHAJcwJzarWcgfWLTEPbHA == P_1.hlQhVNXnHAJcwJzarWcgfWLTEPbHA)
		{
			return P_0.zIfGIqxwpIeXWkYJlytJzAssSfAK == P_1.zIfGIqxwpIeXWkYJlytJzAssSfAK;
		}
		return false;
	}

	[SpecialName]
	public static bool UBkWjArnRplFXwSasWCzswJgfhTo(InINhqOWaZfwoZayQTKfBpYOZxcr P_0, InINhqOWaZfwoZayQTKfBpYOZxcr P_1)
	{
		return !KTQkteKBPMOItfcJPKeIoWkaTeli(P_0, P_1);
	}
}
