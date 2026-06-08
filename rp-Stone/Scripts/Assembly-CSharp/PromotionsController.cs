using UnityEngine;

public class PromotionsController : MonoBehaviour
{
	private int purchasedBundles;

	public static PromotionsController singleton { get; private set; }

	private int ProductIdToIndex(string productId)
	{
		return productId switch
		{
			"iap_tickets_0" => 0, 
			"iap_tickets_1" => 1, 
			"iap_tickets_2" => 2, 
			"iap_tickets_3" => 3, 
			_ => -1, 
		};
	}

	public bool HasPurchased(string productId)
	{
		int num = ProductIdToIndex(productId);
		return (purchasedBundles & (1 << num)) != 0;
	}

	public void SetPurchased(string productId)
	{
		purchasedBundles |= 1 << ProductIdToIndex(productId);
	}

	public void ClearProgress()
	{
		purchasedBundles = 0;
	}

	public void Parse(string sjson)
	{
		ClearProgress();
		if (sjson != null)
		{
			purchasedBundles = SlimJson.ParseInt(sjson, "pb");
		}
	}

	public string Serialize()
	{
		SlimJson.BeginSerialization();
		if (purchasedBundles != 0)
		{
			SlimJson.AddProperty("pb", purchasedBundles);
		}
		return SlimJson.EndSerialization();
	}

	private void Awake()
	{
		singleton = this;
	}
}
