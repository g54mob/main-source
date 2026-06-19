using System;
using System.Runtime.CompilerServices;

internal class kVIAiGUXiHUgrqGpkFpZAChkKzK
{
	private byte dEyIPlDNffEDEplIJeQNlDFszIt;

	private byte[] lRzpywKaCNnEFwLVwiIyjkenMDP = new byte[0];

	private readonly VTSWpJxdqWwWKExRbpiyfgoBilMC.FXbUGyTYVjOagsEdlFJThCphbFhe oIdsheBRHvlCiGeNJVLKwnRSlNe;

	[CompilerGenerated]
	private bool DObeIsbfZbhsMRDaQRiFqtXVdIUi;

	public bool Exists
	{
		[CompilerGenerated]
		get
		{
			return DObeIsbfZbhsMRDaQRiFqtXVdIUi;
		}
		[CompilerGenerated]
		private set
		{
			DObeIsbfZbhsMRDaQRiFqtXVdIUi = value;
		}
	}

	public VTSWpJxdqWwWKExRbpiyfgoBilMC.FXbUGyTYVjOagsEdlFJThCphbFhe ReadStatus => oIdsheBRHvlCiGeNJVLKwnRSlNe;

	public byte ReportId
	{
		get
		{
			return dEyIPlDNffEDEplIJeQNlDFszIt;
		}
		set
		{
			dEyIPlDNffEDEplIJeQNlDFszIt = value;
			Exists = true;
		}
	}

	public byte[] Data
	{
		get
		{
			return lRzpywKaCNnEFwLVwiIyjkenMDP;
		}
		set
		{
			lRzpywKaCNnEFwLVwiIyjkenMDP = value;
			Exists = true;
		}
	}

	public kVIAiGUXiHUgrqGpkFpZAChkKzK(int reportSize)
	{
		Array.Resize(ref lRzpywKaCNnEFwLVwiIyjkenMDP, reportSize - 1);
	}

	public kVIAiGUXiHUgrqGpkFpZAChkKzK(int reportSize, VTSWpJxdqWwWKExRbpiyfgoBilMC deviceData)
	{
		oIdsheBRHvlCiGeNJVLKwnRSlNe = deviceData.Status;
		Array.Resize(ref lRzpywKaCNnEFwLVwiIyjkenMDP, reportSize - 1);
		if (deviceData.Data != null)
		{
			if (deviceData.Data.Length > 0)
			{
				dEyIPlDNffEDEplIJeQNlDFszIt = deviceData.Data[0];
				Exists = true;
				if (deviceData.Data.Length > 1)
				{
					int length = reportSize - 1;
					if (deviceData.Data.Length < reportSize - 1)
					{
						length = deviceData.Data.Length;
					}
					Array.Copy(deviceData.Data, 1, lRzpywKaCNnEFwLVwiIyjkenMDP, 0, length);
				}
			}
			else
			{
				Exists = false;
			}
		}
		else
		{
			Exists = false;
		}
	}

	public byte[] AFMnGZBHbXGrOgafNOBFEvRdQgYb()
	{
		byte[] array = null;
		Array.Resize(ref array, lRzpywKaCNnEFwLVwiIyjkenMDP.Length + 1);
		array[0] = dEyIPlDNffEDEplIJeQNlDFszIt;
		Array.Copy(lRzpywKaCNnEFwLVwiIyjkenMDP, 0, array, 1, lRzpywKaCNnEFwLVwiIyjkenMDP.Length);
		return array;
	}
}
