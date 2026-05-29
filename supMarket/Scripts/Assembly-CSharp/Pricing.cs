using System;
using ExitGames.Client.Photon;
using UnityEngine;

[Serializable]
public class Pricing
{
	public int ProductID;

	public float Price;

	public int LastChangeDate;

	[Range(0f, 100f)]
	public int DiscountRate;

	private int _saleIndex;

	private static readonly byte[] m_Bytes;

	public bool IsDiscounted => false;

	public bool IsReallyDiscounted => false;

	public float RealDiscountRate => 0f;

	public float DiscountedPrice => 0f;

	public float DiscountPoints => 0f;

	public float AvgCost => 0f;

	public float PreviousCost => 0f;

	public float CurrentCost => 0f;

	public float MarketPrice => 0f;

	public float Profit => 0f;

	public float SellingPrice => 0f;

	public static short Serialize(StreamBuffer outStream, object customObject)
	{
		return 0;
	}

	public static object Deserialize(StreamBuffer inStream, short length)
	{
		return null;
	}

	private static int GetSize()
	{
		return 0;
	}

	public int GetSaleSign()
	{
		return 0;
	}

	public void SetSaleSign(int saleIndex)
	{
	}

	public Pricing()
	{
	}

	public Pricing(Pricing pricing)
	{
	}

	public Pricing(int id, float price)
	{
	}

	public Pricing(int id, float price, float previousPrice, int lastChangeDate)
	{
	}
}
