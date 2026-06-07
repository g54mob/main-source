using System;
using Rewired;
using Rewired.Platforms;
using Rewired.Utils;

internal class lEXUOZyrtptSFduQgbxDtqJIFtc
{
	public int OzrddnKJxlYmeWScchUUCYVqptOH;

	public int NYmsntNmerBdfjqWsqOAJSxXtHzm;

	public bool HBIGRpUjnIczXcgrjICXrydfKCdDA;

	public string drwYfDsmzyYnzGtWAmJDQsBHFltY;

	public string TFFZHdPkZyEmJCBRHEQlTPxRXAgmA;

	public Guid jQbemCbXkYArMcGFAxSBRspzqPAs;

	public Guid uXtavkpiGnTELWlIoiAOdjmSccCe;

	public int xaFCqVfuYPPZYAWPQgdNpgdYGngE;

	public int HelnMFnZCbVTCBEOyjdnjFdMoTAtA;

	public int vpyKIZrHOUkyVjQPhuddtTzxnrnN;

	public int JHyGyDWWPkLfNdXYLnZhbtmFjqyE;

	public PidVid pSZQgdQrodZQLYmMrMcsEiLCMCFu;

	public Guid AexFKwfvXOxVHfzFkvRLOBobyiox;

	public int JCCCSUFKrhxdCqscZOPsAciHEyQo;

	public int fmADaoASFvUyyGxMmcxiOcArLSLJ;

	public void EVLgyDCaChVNyISVIIVXrgAyzVxR()
	{
		byte[] value = jQbemCbXkYArMcGFAxSBRspzqPAs.ToByteArray();
		int startIndex;
		int startIndex2;
		switch (UnityTools.effectivePlatform)
		{
		case Platform.Windows:
			startIndex = 0;
			startIndex2 = 2;
			break;
		case Platform.OSX:
			startIndex = 0;
			startIndex2 = 8;
			break;
		case Platform.Linux:
			startIndex = 4;
			startIndex2 = 8;
			break;
		default:
			throw new NotImplementedException();
		}
		JCCCSUFKrhxdCqscZOPsAciHEyQo = BitConverter.ToUInt16(value, startIndex);
		fmADaoASFvUyyGxMmcxiOcArLSLJ = BitConverter.ToUInt16(value, startIndex2);
		pSZQgdQrodZQLYmMrMcsEiLCMCFu = new PidVid((ushort)fmADaoASFvUyyGxMmcxiOcArLSLJ, (ushort)JCCCSUFKrhxdCqscZOPsAciHEyQo);
		AexFKwfvXOxVHfzFkvRLOBobyiox = MiscTools.CreateGuidHashSHA1(drwYfDsmzyYnzGtWAmJDQsBHFltY + pSZQgdQrodZQLYmMrMcsEiLCMCFu.ToString() + NYmsntNmerBdfjqWsqOAJSxXtHzm);
		if (string.IsNullOrEmpty(TFFZHdPkZyEmJCBRHEQlTPxRXAgmA))
		{
			TFFZHdPkZyEmJCBRHEQlTPxRXAgmA = drwYfDsmzyYnzGtWAmJDQsBHFltY;
		}
	}

	public virtual string KEpaSLqyFjUDqEeYhftqLOAySVCl()
	{
		string text = string.Concat(string.Concat(string.Concat(string.Concat("" + "joystickIndex = " + OzrddnKJxlYmeWScchUUCYVqptOH + "\n", "joystickId = ", NYmsntNmerBdfjqWsqOAJSxXtHzm.ToString(), "\n"), "isGameController = ", HBIGRpUjnIczXcgrjICXrydfKCdDA.ToString(), "\n"), "hardwareName = ", drwYfDsmzyYnzGtWAmJDQsBHFltY, "\n"), "friendlyName = ", TFFZHdPkZyEmJCBRHEQlTPxRXAgmA, "\n");
		Guid guid = jQbemCbXkYArMcGFAxSBRspzqPAs;
		string text2 = text + "sdlJoystickGuid = " + guid.ToString() + "\n";
		guid = uXtavkpiGnTELWlIoiAOdjmSccCe;
		string text3 = string.Concat(string.Concat(string.Concat(string.Concat(text2 + "sdlDeviceGuid = " + guid.ToString() + "\n", "buttonCount = ", xaFCqVfuYPPZYAWPQgdNpgdYGngE.ToString(), "\n"), "axisCount = ", HelnMFnZCbVTCBEOyjdnjFdMoTAtA.ToString(), "\n"), "hatCount = ", vpyKIZrHOUkyVjQPhuddtTzxnrnN.ToString(), "\n"), "ballCount = ", JHyGyDWWPkLfNdXYLnZhbtmFjqyE.ToString(), "\n");
		PidVid pidVid = pSZQgdQrodZQLYmMrMcsEiLCMCFu;
		string text4 = text3 + "pidVid = " + pidVid.ToString() + "\n";
		guid = AexFKwfvXOxVHfzFkvRLOBobyiox;
		return string.Concat(string.Concat(text4 + "instanceGuid = " + guid.ToString() + "\n", "vendorId = ", JCCCSUFKrhxdCqscZOPsAciHEyQo.ToString(), "\n"), "productId = ", fmADaoASFvUyyGxMmcxiOcArLSLJ.ToString(), "\n");
	}
}
