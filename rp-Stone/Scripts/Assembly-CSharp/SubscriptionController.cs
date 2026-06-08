using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Purchasing;

public class SubscriptionController : MonoBehaviour
{
	public class SubData
	{
		public string id;

		public DateTime expiration;

		public SubData()
		{
		}

		public SubData(SubscriptionInfo info)
		{
			id = info.getProductId();
			expiration = info.getExpireDate();
		}

		public bool HasExpired()
		{
			return DateTime.Now >= expiration;
		}

		public static SubData FromString(string sjson)
		{
			return new SubData
			{
				id = SlimJson.Parse(sjson, "id"),
				expiration = SlimJson.ParseDateTime(sjson, "ex")
			};
		}

		public override string ToString()
		{
			SlimJson.BeginSerialization();
			SlimJson.AddProperty("id", id);
			SlimJson.AddProperty("ex", expiration);
			return SlimJson.EndSerialization();
		}
	}

	public static string EVENTS_SUBSCRIPTION_ID = "sub_events";

	private string[] subscriptionIDs = new string[1] { EVENTS_SUBSCRIPTION_ID };

	private List<SubData> activeSubs = new List<SubData>();

	private List<SubData> expiredSubs = new List<SubData>();

	private List<SubData> giftedSubs = new List<SubData>();

	private List<SubData> playerPrefsSubs = new List<SubData>();

	private bool hasParsed;

	public static SubscriptionController singleton { get; private set; }

	public static event Action<SubData> OnSubscriptionAdded;

	public void OnInitialized(IStoreController controller, Dictionary<string, string> introPriceDict)
	{
		Product[] all = controller.products.all;
		foreach (Product product in all)
		{
			if (product.receipt != null && product.definition.type == ProductType.Subscription)
			{
				string intro_json = ((introPriceDict == null || !introPriceDict.ContainsKey(product.definition.storeSpecificId)) ? null : introPriceDict[product.definition.storeSpecificId]);
				SubscriptionInfo subscriptionInfo = new SubscriptionManager(product, intro_json).getSubscriptionInfo();
				if (subscriptionInfo.isExpired() == Result.True)
				{
					expiredSubs.Add(new SubData(subscriptionInfo));
				}
				else if (subscriptionInfo.isSubscribed() == Result.True)
				{
					activeSubs.Add(new SubData(subscriptionInfo));
				}
			}
		}
	}

	public bool HasSubscription(string subId)
	{
		if (hasParsed && _FindAndPruneExpired(giftedSubs, subId) != null)
		{
			return true;
		}
		if (!hasParsed && _FindAndPruneExpired(playerPrefsSubs, subId) != null)
		{
			return true;
		}
		if (_FindAndPruneExpired(activeSubs, subId) != null)
		{
			return true;
		}
		return false;
	}

	private SubData _FindAndPruneExpired(List<SubData> collection, string subId)
	{
		SubData result = null;
		for (int num = collection.Count - 1; num >= 0; num--)
		{
			SubData subData = collection[num];
			if (subData.expiration <= DateTime.Now)
			{
				collection.RemoveAt(num);
			}
			else if (subData.id == subId)
			{
				result = subData;
			}
		}
		return result;
	}

	public void AddGifted(string subId)
	{
		SubData subData = new SubData();
		subData.id = subId;
		subData.expiration = DateTime.Now + new TimeSpan(30, 0, 0, 0);
		AddGifted(subData);
		SavePlayerPrefsGiftedData();
	}

	private void AddGifted(SubData data)
	{
		for (int i = 0; i < giftedSubs.Count; i++)
		{
			if (giftedSubs[i].id == data.id)
			{
				if (giftedSubs[i].expiration < data.expiration)
				{
					giftedSubs[i].expiration = data.expiration;
				}
				return;
			}
		}
		giftedSubs.Add(data);
	}

	private void AddSubscription(SubData sub)
	{
		expiredSubs.RemoveAll((SubData s) => s.id == sub.id);
		activeSubs.RemoveAll((SubData s) => s.id == sub.id);
		activeSubs.Add(sub);
	}

	public bool IsASubscription(string subId)
	{
		return Array.Find(subscriptionIDs, (string sId) => sId == subId) != null;
	}

	public void AddProducts(ConfigurationBuilder builder)
	{
		for (int i = 0; i < subscriptionIDs.Length; i++)
		{
			builder.AddProduct(subscriptionIDs[i], ProductType.Subscription);
		}
	}

	public void ProcessPurchase(Product product, Dictionary<string, string> introPriceDict)
	{
		string id = product.definition.id;
		if (product.definition.type == ProductType.Subscription && IsASubscription(id))
		{
			InAppPurchaseController.singleton.MarkPurchaseAsDelivered(product);
		}
	}

	private void SavePlayerPrefsGiftedData()
	{
		string key = "gifted_subs";
		if (giftedSubs.Count > 0)
		{
			SlimJson.BeginSerialization();
			SlimJson.AddProperty("g", giftedSubs.ToArray());
			string value = SlimJson.EndSerialization();
			PlayerPrefs.SetString(key, value);
			PlayerPrefs.Save();
		}
		else
		{
			PlayerPrefs.DeleteKey(key);
		}
	}

	private void LoadPlayerPrefsGiftedData()
	{
		string key = "gifted_subs";
		playerPrefsSubs.Clear();
		if (PlayerPrefs.HasKey(key))
		{
			SubData[] collection = SlimJson.ParseArray(PlayerPrefs.GetString(key), "g", SubData.FromString);
			playerPrefsSubs.AddRange(collection);
		}
	}

	public void ClearProgress()
	{
	}

	public void Parse(string sjson)
	{
		ClearProgress();
		if (sjson != null)
		{
			SubData[] array = SlimJson.ParseArray(sjson, "s", SubData.FromString);
			array = SlimJson.ParseArray(sjson, "g", SubData.FromString);
			if (array != null)
			{
				for (int i = 0; i < array.Length; i++)
				{
					AddGifted(array[i]);
				}
			}
		}
		hasParsed = true;
	}

	public string Serialize()
	{
		SlimJson.BeginSerialization();
		if (activeSubs.Count > 0)
		{
			SlimJson.AddProperty("s", activeSubs.ToArray());
		}
		if (giftedSubs.Count > 0)
		{
			SlimJson.AddProperty("g", giftedSubs.ToArray());
		}
		if (playerPrefsSubs.Count != giftedSubs.Count)
		{
			SavePlayerPrefsGiftedData();
		}
		return SlimJson.EndSerialization();
	}

	private void Awake()
	{
		singleton = this;
		LoadPlayerPrefsGiftedData();
	}
}
