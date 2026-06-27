using System;
using Rewired;
using Rewired.Platforms;
using Rewired.Utils;

internal class xLaUnUyMsswyKdClfravuOBgHcWK
{
	public int OoJuevhgfcfVmuTaJiKSbChRudLK;

	public int TcEgshAqqmtivaZWDpRQCqZscUsLA;

	public bool FxiSShpcvFWaJATxKNUPZhHSfNsP;

	public string hbYkmFXHvlEwzGyQvyWThqtoHaoP;

	public string HTvJYtgCDjbbLdlVkEJtMaVkdNtxA;

	public Guid hiDVvQIckDQiQIJHnjFRCcHEhCHSA;

	public Guid goJvanYGceBGFukvFCxQAkZvbdHdA;

	public int rnbZLAKOOeSQBcKppxNCFMxePvhA;

	public int ROBDNZDKWqoEShvGBiydIyDrhGRvA;

	public int xFGdPPaCINLnNwZRSgahHETSgsyWA;

	public int NLGLjTvLejQSNFUaqisnYWHigbdg;

	public PidVid pFrExjGfaoqFDvkGWwziQjrxHFAdb;

	public Guid EsFsVcIVDPHAXXtJHvILhtGQcrnT;

	public int BsPBWaghspcKeCcFsTkJhOjylDBe;

	public int rgqtPifgDwfoaerQRzxgdwxYIFIg;

	public void EWtyrDbhAcsYiuxZnISZALcFeImu()
	{
		byte[] value = hiDVvQIckDQiQIJHnjFRCcHEhCHSA.ToByteArray();
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
		BsPBWaghspcKeCcFsTkJhOjylDBe = BitConverter.ToUInt16(value, startIndex);
		rgqtPifgDwfoaerQRzxgdwxYIFIg = BitConverter.ToUInt16(value, startIndex2);
		pFrExjGfaoqFDvkGWwziQjrxHFAdb = new PidVid((ushort)rgqtPifgDwfoaerQRzxgdwxYIFIg, (ushort)BsPBWaghspcKeCcFsTkJhOjylDBe);
		EsFsVcIVDPHAXXtJHvILhtGQcrnT = MiscTools.CreateGuidHashSHA1(hbYkmFXHvlEwzGyQvyWThqtoHaoP + pFrExjGfaoqFDvkGWwziQjrxHFAdb.ToString() + TcEgshAqqmtivaZWDpRQCqZscUsLA);
		if (string.IsNullOrEmpty(HTvJYtgCDjbbLdlVkEJtMaVkdNtxA))
		{
			HTvJYtgCDjbbLdlVkEJtMaVkdNtxA = hbYkmFXHvlEwzGyQvyWThqtoHaoP;
		}
	}

	public virtual string UpZnPXZNIyLpgyQnAchqcgaHJKBH()
	{
		string text = string.Concat(string.Concat(string.Concat(string.Concat("" + "joystickIndex = " + OoJuevhgfcfVmuTaJiKSbChRudLK + "\n", "joystickId = ", TcEgshAqqmtivaZWDpRQCqZscUsLA.ToString(), "\n"), "isGameController = ", FxiSShpcvFWaJATxKNUPZhHSfNsP.ToString(), "\n"), "hardwareName = ", hbYkmFXHvlEwzGyQvyWThqtoHaoP, "\n"), "friendlyName = ", HTvJYtgCDjbbLdlVkEJtMaVkdNtxA, "\n");
		Guid guid = hiDVvQIckDQiQIJHnjFRCcHEhCHSA;
		string text2 = text + "sdlJoystickGuid = " + guid.ToString() + "\n";
		guid = goJvanYGceBGFukvFCxQAkZvbdHdA;
		string text3 = string.Concat(string.Concat(string.Concat(string.Concat(text2 + "sdlDeviceGuid = " + guid.ToString() + "\n", "buttonCount = ", rnbZLAKOOeSQBcKppxNCFMxePvhA.ToString(), "\n"), "axisCount = ", ROBDNZDKWqoEShvGBiydIyDrhGRvA.ToString(), "\n"), "hatCount = ", xFGdPPaCINLnNwZRSgahHETSgsyWA.ToString(), "\n"), "ballCount = ", NLGLjTvLejQSNFUaqisnYWHigbdg.ToString(), "\n");
		PidVid pidVid = pFrExjGfaoqFDvkGWwziQjrxHFAdb;
		string text4 = text3 + "pidVid = " + pidVid.ToString() + "\n";
		guid = EsFsVcIVDPHAXXtJHvILhtGQcrnT;
		return string.Concat(string.Concat(text4 + "instanceGuid = " + guid.ToString() + "\n", "vendorId = ", BsPBWaghspcKeCcFsTkJhOjylDBe.ToString(), "\n"), "productId = ", rgqtPifgDwfoaerQRzxgdwxYIFIg.ToString(), "\n");
	}
}
