using System;
using System.Runtime.CompilerServices;

internal class bJdArpFKhPHGqYwVeHitnnoUJsNt
{
	private byte iALAuETyHpkHVfyqJopxSXOCTDc;

	private byte[] qRWrOPYuwHqbUuZdueJIYyxXETU = new byte[0];

	private readonly OFtWxwvQaCIdBMAlbBrAEqpvclJ.JfoGbzDvvdBhXClXWKldOuKXltib bRSaVDiLdftvbsOhRkmehBOGqanm;

	[CompilerGenerated]
	private bool ASUxPhxphrsXxNSGUDtrQKatDjX;

	public bool Exists
	{
		[CompilerGenerated]
		get
		{
			return ASUxPhxphrsXxNSGUDtrQKatDjX;
		}
		[CompilerGenerated]
		private set
		{
			ASUxPhxphrsXxNSGUDtrQKatDjX = value;
		}
	}

	public OFtWxwvQaCIdBMAlbBrAEqpvclJ.JfoGbzDvvdBhXClXWKldOuKXltib ReadStatus => bRSaVDiLdftvbsOhRkmehBOGqanm;

	public byte ReportId
	{
		get
		{
			return iALAuETyHpkHVfyqJopxSXOCTDc;
		}
		set
		{
			iALAuETyHpkHVfyqJopxSXOCTDc = value;
			Exists = true;
		}
	}

	public byte[] Data
	{
		get
		{
			return qRWrOPYuwHqbUuZdueJIYyxXETU;
		}
		set
		{
			qRWrOPYuwHqbUuZdueJIYyxXETU = value;
			Exists = true;
		}
	}

	public bJdArpFKhPHGqYwVeHitnnoUJsNt(int reportSize)
	{
		Array.Resize(ref qRWrOPYuwHqbUuZdueJIYyxXETU, reportSize - 1);
	}

	public bJdArpFKhPHGqYwVeHitnnoUJsNt(int reportSize, OFtWxwvQaCIdBMAlbBrAEqpvclJ deviceData)
	{
		bRSaVDiLdftvbsOhRkmehBOGqanm = deviceData.Status;
		Array.Resize(ref qRWrOPYuwHqbUuZdueJIYyxXETU, reportSize - 1);
		if (deviceData.Data != null)
		{
			if (deviceData.Data.Length > 0)
			{
				iALAuETyHpkHVfyqJopxSXOCTDc = deviceData.Data[0];
				Exists = true;
				if (deviceData.Data.Length > 1)
				{
					int length = reportSize - 1;
					if (deviceData.Data.Length < reportSize - 1)
					{
						length = deviceData.Data.Length;
					}
					Array.Copy(deviceData.Data, 1, qRWrOPYuwHqbUuZdueJIYyxXETU, 0, length);
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

	public byte[] PUzdToHPXHzkHoDTNeJdUHYqrpX()
	{
		byte[] array = null;
		Array.Resize(ref array, qRWrOPYuwHqbUuZdueJIYyxXETU.Length + 1);
		array[0] = iALAuETyHpkHVfyqJopxSXOCTDc;
		Array.Copy(qRWrOPYuwHqbUuZdueJIYyxXETU, 0, array, 1, qRWrOPYuwHqbUuZdueJIYyxXETU.Length);
		return array;
	}
}
