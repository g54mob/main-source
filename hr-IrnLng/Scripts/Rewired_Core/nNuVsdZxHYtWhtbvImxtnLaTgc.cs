using System;
using Rewired;
using Rewired.Platforms;
using Rewired.Utils;

internal class nNuVsdZxHYtWhtbvImxtnLaTgc
{
	public int YeoWTxCQgRnimGZWwTJsKNURUbe;

	public int sdUcfBHJKZrpwNGKHzcwwlwLVTI;

	public bool VjQTFGTPeABliEUxEaDhSqJgqcad;

	public string SzYRXywEPUSdsLwYXuWDoPjSZCH;

	public string iiSTExMiHYwCqXJDsMrnFbtdknJ;

	public Guid CMFtfkGsxOEywTzjktNctHAIUpO;

	public Guid QjIgOSUFmhjTxyJFVchIHcvaGPRD;

	public int qrXpdbCUzFLCBfjCDTfPHyJCus;

	public int rGEuFEtJcMmFaLOCcsmbRHUjSpy;

	public int EgZAgydUSUMAbFugLVPACbffArM;

	public int YheYnwPCtGgZIFrqJXlGuLcCMmg;

	public PidVid xkvdTpabuwPDnVPwRjEibxPKerR;

	public Guid ocDFctqVRVXkjlFXQuNGYFHpaVHi;

	public int xWIfnycVeScryAKfrRyhksBsyEww;

	public int RlmaoXaMoKUZWqFptaxMnKyGgXWx;

	public void KfBKHnOxjftuCpCkJBMbkWxcLWv()
	{
		byte[] value = CMFtfkGsxOEywTzjktNctHAIUpO.ToByteArray();
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
		xWIfnycVeScryAKfrRyhksBsyEww = BitConverter.ToUInt16(value, startIndex);
		RlmaoXaMoKUZWqFptaxMnKyGgXWx = BitConverter.ToUInt16(value, startIndex2);
		xkvdTpabuwPDnVPwRjEibxPKerR = new PidVid((ushort)RlmaoXaMoKUZWqFptaxMnKyGgXWx, (ushort)xWIfnycVeScryAKfrRyhksBsyEww);
		ocDFctqVRVXkjlFXQuNGYFHpaVHi = MiscTools.CreateGuidHashSHA1(SzYRXywEPUSdsLwYXuWDoPjSZCH + xkvdTpabuwPDnVPwRjEibxPKerR.ToString() + sdUcfBHJKZrpwNGKHzcwwlwLVTI);
		if (string.IsNullOrEmpty(iiSTExMiHYwCqXJDsMrnFbtdknJ))
		{
			iiSTExMiHYwCqXJDsMrnFbtdknJ = SzYRXywEPUSdsLwYXuWDoPjSZCH;
		}
	}

	public override string ToString()
	{
		string text = "";
		object obj = text;
		text = string.Concat(obj, "joystickIndex = ", YeoWTxCQgRnimGZWwTJsKNURUbe, "\n");
		object obj2 = text;
		text = string.Concat(obj2, "joystickId = ", sdUcfBHJKZrpwNGKHzcwwlwLVTI, "\n");
		object obj3 = text;
		text = string.Concat(obj3, "isGameController = ", VjQTFGTPeABliEUxEaDhSqJgqcad, "\n");
		text = text + "hardwareName = " + SzYRXywEPUSdsLwYXuWDoPjSZCH + "\n";
		text = text + "friendlyName = " + iiSTExMiHYwCqXJDsMrnFbtdknJ + "\n";
		object obj4 = text;
		text = string.Concat(obj4, "sdlJoystickGuid = ", CMFtfkGsxOEywTzjktNctHAIUpO, "\n");
		object obj5 = text;
		text = string.Concat(obj5, "sdlDeviceGuid = ", QjIgOSUFmhjTxyJFVchIHcvaGPRD, "\n");
		object obj6 = text;
		text = string.Concat(obj6, "buttonCount = ", qrXpdbCUzFLCBfjCDTfPHyJCus, "\n");
		object obj7 = text;
		text = string.Concat(obj7, "axisCount = ", rGEuFEtJcMmFaLOCcsmbRHUjSpy, "\n");
		object obj8 = text;
		text = string.Concat(obj8, "hatCount = ", EgZAgydUSUMAbFugLVPACbffArM, "\n");
		object obj9 = text;
		text = string.Concat(obj9, "ballCount = ", YheYnwPCtGgZIFrqJXlGuLcCMmg, "\n");
		object obj10 = text;
		text = string.Concat(obj10, "pidVid = ", xkvdTpabuwPDnVPwRjEibxPKerR, "\n");
		object obj11 = text;
		text = string.Concat(obj11, "instanceGuid = ", ocDFctqVRVXkjlFXQuNGYFHpaVHi, "\n");
		object obj12 = text;
		text = string.Concat(obj12, "vendorId = ", xWIfnycVeScryAKfrRyhksBsyEww, "\n");
		object obj13 = text;
		return string.Concat(obj13, "productId = ", RlmaoXaMoKUZWqFptaxMnKyGgXWx, "\n");
	}
}
