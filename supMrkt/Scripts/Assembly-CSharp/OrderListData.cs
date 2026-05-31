using System;
using System.Collections.Generic;
using ExitGames.Client.Photon;

[Serializable]
public class OrderListData
{
	public int ID;

	public string CustomerName;

	public CustomerGender CustomerGender;

	public List<OrderData> OrderItems;

	public int OrderDay;

	public float OrderTime;

	public bool IsAttachedToBag;

	public bool IsRead;

	public int ExpirationDay;

	public float ExpirationTime;

	public bool IsExpired;

	public int CustomerSpawnIndex;

	public int CustomerPrefabIndex;

	public float Distance;

	public float DistancePrice;

	public bool HasExpiration;

	public float TotalPrice => 0f;

	public static OrderListData Empty { get; }

	public int GetSize()
	{
		return 0;
	}

	public OrderData GetOrderDataOfId(int productId)
	{
		return null;
	}

	public bool HasProductOfId(int productId)
	{
		return false;
	}

	public float GetCachedPrice(int productId)
	{
		return 0f;
	}

	public static short Serialize(StreamBuffer outStream, object customObject)
	{
		return 0;
	}

	public static object Deserialize(StreamBuffer inStream, short length)
	{
		return null;
	}
}
