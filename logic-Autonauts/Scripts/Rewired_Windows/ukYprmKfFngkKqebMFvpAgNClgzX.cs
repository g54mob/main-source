using System;
using System.Runtime.CompilerServices;

internal class ukYprmKfFngkKqebMFvpAgNClgzX
{
	private byte ftobiJhZtVYnbPhOrqmjDZbAnXEW;

	private byte[] lEvWREIACrPawuSVWQCYTyAHFma = new byte[0];

	private readonly HgGLQtrCokhwjfGTXVIAhJMhlgpp.WduIOqHRwwBaWaNUdPEmNPGgTRcT yxlBhMVHZFbZVSWBrkbwIgfiZsZ;

	[CompilerGenerated]
	private bool TZnjdKrGFHXUnTseaVAxPGdbELhK;

	public bool Exists
	{
		[CompilerGenerated]
		get
		{
			return TZnjdKrGFHXUnTseaVAxPGdbELhK;
		}
		[CompilerGenerated]
		private set
		{
			TZnjdKrGFHXUnTseaVAxPGdbELhK = value;
		}
	}

	public HgGLQtrCokhwjfGTXVIAhJMhlgpp.WduIOqHRwwBaWaNUdPEmNPGgTRcT ReadStatus
	{
		get
		{
			return yxlBhMVHZFbZVSWBrkbwIgfiZsZ;
		}
	}

	public byte ReportId
	{
		get
		{
			return ftobiJhZtVYnbPhOrqmjDZbAnXEW;
		}
		set
		{
			ftobiJhZtVYnbPhOrqmjDZbAnXEW = value;
			Exists = true;
		}
	}

	public byte[] Data
	{
		get
		{
			return lEvWREIACrPawuSVWQCYTyAHFma;
		}
		set
		{
			lEvWREIACrPawuSVWQCYTyAHFma = value;
			Exists = true;
		}
	}

	public ukYprmKfFngkKqebMFvpAgNClgzX(int reportSize)
	{
		Array.Resize(ref lEvWREIACrPawuSVWQCYTyAHFma, reportSize - 1);
	}

	public ukYprmKfFngkKqebMFvpAgNClgzX(int reportSize, HgGLQtrCokhwjfGTXVIAhJMhlgpp deviceData)
	{
		yxlBhMVHZFbZVSWBrkbwIgfiZsZ = deviceData.Status;
		Array.Resize(ref lEvWREIACrPawuSVWQCYTyAHFma, reportSize - 1);
		if (deviceData.Data != null)
		{
			if (deviceData.Data.Length > 0)
			{
				ftobiJhZtVYnbPhOrqmjDZbAnXEW = deviceData.Data[0];
				Exists = true;
				if (deviceData.Data.Length > 1)
				{
					int length = reportSize - 1;
					if (deviceData.Data.Length < reportSize - 1)
					{
						length = deviceData.Data.Length;
					}
					Array.Copy(deviceData.Data, 1, lEvWREIACrPawuSVWQCYTyAHFma, 0, length);
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

	public byte[] OtKVfrLldftVtoQrtrtdZshyEpx()
	{
		byte[] array = null;
		Array.Resize(ref array, lEvWREIACrPawuSVWQCYTyAHFma.Length + 1);
		array[0] = ftobiJhZtVYnbPhOrqmjDZbAnXEW;
		Array.Copy(lEvWREIACrPawuSVWQCYTyAHFma, 0, array, 1, lEvWREIACrPawuSVWQCYTyAHFma.Length);
		return array;
	}
}
