using System;
using System.Runtime.CompilerServices;

internal class nQfFkZhVbYgCICGbKJhqQlKDtpOT
{
	private byte aURAjgKwPgDvhHhAmhsgUpkzjIv;

	private byte[] uKUmVzZiqQOryQfFHTEZWGFoFWDA = new byte[0];

	private readonly QzxTvOeWALIhvefHOWyHODDSlRY.XBcNpFaeWDnLzGdLucKDiaKKEhr nYOFGdkAjsWrTVqPgOxznDsLxbyo;

	[CompilerGenerated]
	private bool IOQklyoroImlapaHvSiMUsbIGIU;

	public bool Exists
	{
		[CompilerGenerated]
		get
		{
			return IOQklyoroImlapaHvSiMUsbIGIU;
		}
		[CompilerGenerated]
		private set
		{
			IOQklyoroImlapaHvSiMUsbIGIU = value;
		}
	}

	public QzxTvOeWALIhvefHOWyHODDSlRY.XBcNpFaeWDnLzGdLucKDiaKKEhr ReadStatus => nYOFGdkAjsWrTVqPgOxznDsLxbyo;

	public byte ReportId
	{
		get
		{
			return aURAjgKwPgDvhHhAmhsgUpkzjIv;
		}
		set
		{
			aURAjgKwPgDvhHhAmhsgUpkzjIv = value;
			Exists = true;
		}
	}

	public byte[] Data
	{
		get
		{
			return uKUmVzZiqQOryQfFHTEZWGFoFWDA;
		}
		set
		{
			uKUmVzZiqQOryQfFHTEZWGFoFWDA = value;
			Exists = true;
		}
	}

	public nQfFkZhVbYgCICGbKJhqQlKDtpOT(int reportSize)
	{
		Array.Resize(ref uKUmVzZiqQOryQfFHTEZWGFoFWDA, reportSize - 1);
	}

	public nQfFkZhVbYgCICGbKJhqQlKDtpOT(int reportSize, QzxTvOeWALIhvefHOWyHODDSlRY deviceData)
	{
		nYOFGdkAjsWrTVqPgOxznDsLxbyo = deviceData.Status;
		Array.Resize(ref uKUmVzZiqQOryQfFHTEZWGFoFWDA, reportSize - 1);
		if (deviceData.Data != null)
		{
			if (deviceData.Data.Length > 0)
			{
				aURAjgKwPgDvhHhAmhsgUpkzjIv = deviceData.Data[0];
				Exists = true;
				if (deviceData.Data.Length > 1)
				{
					int length = reportSize - 1;
					if (deviceData.Data.Length < reportSize - 1)
					{
						length = deviceData.Data.Length;
					}
					Array.Copy(deviceData.Data, 1, uKUmVzZiqQOryQfFHTEZWGFoFWDA, 0, length);
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

	public byte[] DNfixSCAPOlLhCiluKtoYOiDmuO()
	{
		byte[] array = null;
		Array.Resize(ref array, uKUmVzZiqQOryQfFHTEZWGFoFWDA.Length + 1);
		array[0] = aURAjgKwPgDvhHhAmhsgUpkzjIv;
		Array.Copy(uKUmVzZiqQOryQfFHTEZWGFoFWDA, 0, array, 1, uKUmVzZiqQOryQfFHTEZWGFoFWDA.Length);
		return array;
	}
}
