using System;
using UnityEngine;

[Serializable]
public class CustomerRating
{
	public byte service;

	public byte product;

	public byte ambient;

	public int cleanness;

	public bool gotServiced;

	public static int GetDevineMin()
	{
		return 245;
	}

	public static int GetDevineMax()
	{
		return 255;
	}

	public static int GetGreatMin()
	{
		return 228;
	}

	public static int GetGreatMax()
	{
		return 245;
	}

	public static int GetGoodMin()
	{
		return 160;
	}

	public static int GetGoodMax()
	{
		return 228;
	}

	public static int GetOkMin()
	{
		return 96;
	}

	public static int GetOkMax()
	{
		return 160;
	}

	public static int GetMehMin()
	{
		return 48;
	}

	public static int GetMehMax()
	{
		return 96;
	}

	public static int GetDisgustingMin()
	{
		return 0;
	}

	public static int GetDisgustingMax()
	{
		return 48;
	}

	public int GetAverageRating()
	{
		int num = (int)(Mathf.InverseLerp(CustomerManager.GetCleanupMin(), CustomerManager.GetCleanupMax(), cleanness) * 255f);
		return (service + product + ambient + num) / 4;
	}

	public float GetStarRating()
	{
		float t = Mathf.InverseLerp(0f, 255f, GetAverageRating());
		return Mathf.Lerp(0f, 5f, t);
	}

	public string GetReview()
	{
		return "Review Placeholder";
	}

	public static CustomerRating Start()
	{
		return new CustomerRating
		{
			service = 128,
			product = 128,
			ambient = 128,
			cleanness = CustomerManager.GetCleanupMin(),
			gotServiced = false
		};
	}
}
