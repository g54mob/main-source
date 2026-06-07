using System;
using System.Runtime.CompilerServices;

internal class cIsqeClJDjClFdJDnHdnzuXgkan
{
	private byte lZCttbwivRmmoyucYsebUBrwJHS;

	private byte[] xJFeNeAtIjqWlzdnhDKMwUOvoTql = new byte[0];

	private readonly VOwBPRSIcgMbwNNxsMOAWsKZwrz.QZzRVjbhYCXXPVBPQINWuWPfZDO sWPNMgaxJTfWEHLbOUfiDDxIPgJ;

	[CompilerGenerated]
	private bool FnVmxgSIRFNmgEXGBQmjQebRARh;

	public bool Exists
	{
		[CompilerGenerated]
		get
		{
			return FnVmxgSIRFNmgEXGBQmjQebRARh;
		}
		[CompilerGenerated]
		private set
		{
			FnVmxgSIRFNmgEXGBQmjQebRARh = value;
		}
	}

	public VOwBPRSIcgMbwNNxsMOAWsKZwrz.QZzRVjbhYCXXPVBPQINWuWPfZDO ReadStatus
	{
		get
		{
			return sWPNMgaxJTfWEHLbOUfiDDxIPgJ;
		}
	}

	public byte ReportId
	{
		get
		{
			return lZCttbwivRmmoyucYsebUBrwJHS;
		}
		set
		{
			lZCttbwivRmmoyucYsebUBrwJHS = value;
			Exists = true;
		}
	}

	public byte[] Data
	{
		get
		{
			return xJFeNeAtIjqWlzdnhDKMwUOvoTql;
		}
		set
		{
			xJFeNeAtIjqWlzdnhDKMwUOvoTql = value;
			Exists = true;
		}
	}

	public cIsqeClJDjClFdJDnHdnzuXgkan(int reportSize)
	{
		Array.Resize(ref xJFeNeAtIjqWlzdnhDKMwUOvoTql, reportSize - 1);
	}

	public cIsqeClJDjClFdJDnHdnzuXgkan(int reportSize, VOwBPRSIcgMbwNNxsMOAWsKZwrz deviceData)
	{
		sWPNMgaxJTfWEHLbOUfiDDxIPgJ = deviceData.Status;
		Array.Resize(ref xJFeNeAtIjqWlzdnhDKMwUOvoTql, reportSize - 1);
		if (deviceData.Data != null)
		{
			if (deviceData.Data.Length > 0)
			{
				lZCttbwivRmmoyucYsebUBrwJHS = deviceData.Data[0];
				Exists = true;
				if (deviceData.Data.Length > 1)
				{
					int length = reportSize - 1;
					if (deviceData.Data.Length < reportSize - 1)
					{
						length = deviceData.Data.Length;
					}
					Array.Copy(deviceData.Data, 1, xJFeNeAtIjqWlzdnhDKMwUOvoTql, 0, length);
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

	public byte[] WiuwVYgxrLUyClHYNlttEtIUrde()
	{
		byte[] array = null;
		Array.Resize(ref array, xJFeNeAtIjqWlzdnhDKMwUOvoTql.Length + 1);
		array[0] = lZCttbwivRmmoyucYsebUBrwJHS;
		Array.Copy(xJFeNeAtIjqWlzdnhDKMwUOvoTql, 0, array, 1, xJFeNeAtIjqWlzdnhDKMwUOvoTql.Length);
		return array;
	}
}
