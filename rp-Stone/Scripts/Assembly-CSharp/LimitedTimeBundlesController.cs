using System.Collections.Generic;

public class LimitedTimeBundlesController
{
	public static readonly long TIME_1_HOUR_IN_SECONDS = 3600L;

	public static readonly long TIME_48_HOURS_IN_SECONDS = 172800L;

	private readonly bool DEBUG_RESET_BUNDLE_SAVE_STATES;

	public bool canUnlockNextSuperBundle = true;

	private Dictionary<string, List<ShopData.LimitedTimeBundle>> allShopBundles;

	private Dictionary<string, ShopData.LimitedTimeBundle> activeSuperBundles;

	private Dictionary<string, ShopData.LimitedTimeBundle> activeBeginnerBundles;

	private List<string> completedBundles;

	private static LimitedTimeBundlesController _ref;

	public int antsKilled { get; set; }

	public int purchaseCount { get; private set; }

	public static LimitedTimeBundlesController singleton
	{
		get
		{
			if (_ref == null)
			{
				_ref = new LimitedTimeBundlesController();
			}
			return _ref;
		}
	}

	public ShopData.LimitedTimeBundle GetActiveSuperBundle(string shopId)
	{
		if (activeSuperBundles == null)
		{
			return null;
		}
		UpdateActiveSuperBundles(shopId);
		if (activeSuperBundles.ContainsKey(shopId))
		{
			return activeSuperBundles[shopId];
		}
		return null;
	}

	private void UpdateActiveSuperBundles(string shopId)
	{
		if (activeSuperBundles.ContainsKey(shopId))
		{
			ShopData.LimitedTimeBundle limitedTimeBundle = activeSuperBundles[shopId];
			if (!limitedTimeBundle.HasExpired())
			{
				return;
			}
			completedBundles.Add(limitedTimeBundle.id);
			activeSuperBundles.Remove(shopId);
			canUnlockNextSuperBundle = false;
		}
		if (!canUnlockNextSuperBundle)
		{
			return;
		}
		List<ShopData.LimitedTimeBundle> list = allShopBundles[shopId];
		for (int i = 0; i < list.Count; i++)
		{
			ShopData.LimitedTimeBundle limitedTimeBundle2 = list[i];
			if (!completedBundles.Contains(limitedTimeBundle2.id) && !limitedTimeBundle2.isBeginnerBundle && limitedTimeBundle2.CheckStartConditions())
			{
				limitedTimeBundle2.StartClock();
				activeSuperBundles[shopId] = limitedTimeBundle2;
				break;
			}
		}
	}

	public ShopData.LimitedTimeBundle GetActiveBeginnerBundle(string shopId)
	{
		if (activeBeginnerBundles == null)
		{
			return null;
		}
		UpdateActiveBeginnerBundles(shopId);
		if (activeBeginnerBundles.ContainsKey(shopId))
		{
			return activeBeginnerBundles[shopId];
		}
		return null;
	}

	private void UpdateActiveBeginnerBundles(string shopId)
	{
		if (activeBeginnerBundles.ContainsKey(shopId))
		{
			ShopData.LimitedTimeBundle limitedTimeBundle = activeBeginnerBundles[shopId];
			if (!limitedTimeBundle.HasExpired())
			{
				return;
			}
			completedBundles.Add(limitedTimeBundle.id);
			activeBeginnerBundles.Remove(shopId);
		}
		List<ShopData.LimitedTimeBundle> list = allShopBundles[shopId];
		for (int i = 0; i < list.Count; i++)
		{
			ShopData.LimitedTimeBundle limitedTimeBundle2 = list[i];
			if (!completedBundles.Contains(limitedTimeBundle2.id) && limitedTimeBundle2.isBeginnerBundle && limitedTimeBundle2.CheckStartConditions())
			{
				limitedTimeBundle2.StartClock();
				activeBeginnerBundles[shopId] = limitedTimeBundle2;
				break;
			}
		}
	}

	public ShopData.LimitedTimeBundle GetPotentialActiveBundle(string shopId)
	{
		if (activeSuperBundles == null)
		{
			return null;
		}
		if (activeSuperBundles.ContainsKey(shopId))
		{
			ShopData.LimitedTimeBundle limitedTimeBundle = activeSuperBundles[shopId];
			if (!limitedTimeBundle.HasExpired())
			{
				return limitedTimeBundle;
			}
		}
		List<ShopData.LimitedTimeBundle> list = allShopBundles[shopId];
		for (int i = 0; i < list.Count; i++)
		{
			ShopData.LimitedTimeBundle limitedTimeBundle2 = list[i];
			if (!completedBundles.Contains(limitedTimeBundle2.id) && !limitedTimeBundle2.isBeginnerBundle && limitedTimeBundle2.CheckStartConditions())
			{
				return limitedTimeBundle2;
			}
		}
		return null;
	}

	public ShopData.LimitedTimeBundle GetPotentialBeginnerBundle(string shopId)
	{
		if (activeBeginnerBundles == null)
		{
			return null;
		}
		if (activeBeginnerBundles.ContainsKey(shopId))
		{
			ShopData.LimitedTimeBundle limitedTimeBundle = activeBeginnerBundles[shopId];
			if (!limitedTimeBundle.HasExpired())
			{
				return limitedTimeBundle;
			}
		}
		List<ShopData.LimitedTimeBundle> list = allShopBundles[shopId];
		for (int i = 0; i < list.Count; i++)
		{
			ShopData.LimitedTimeBundle limitedTimeBundle2 = list[i];
			if (!completedBundles.Contains(limitedTimeBundle2.id) && limitedTimeBundle2.isBeginnerBundle && limitedTimeBundle2.CheckStartConditions())
			{
				return limitedTimeBundle2;
			}
		}
		return null;
	}

	public void RegisterShopBundle(string shopId, ShopData.LimitedTimeBundle bundleData)
	{
		if (activeSuperBundles != null)
		{
			List<ShopData.LimitedTimeBundle> list;
			if (allShopBundles.ContainsKey(shopId))
			{
				list = allShopBundles[shopId];
			}
			else
			{
				list = new List<ShopData.LimitedTimeBundle>();
				allShopBundles.Add(shopId, list);
			}
			list.Add(bundleData);
		}
	}

	public void Complete(string shopId, string bundleId)
	{
		bool flag = false;
		if (activeSuperBundles.ContainsKey(shopId) && activeSuperBundles[shopId].id == bundleId)
		{
			activeSuperBundles.Remove(shopId);
			flag = true;
			canUnlockNextSuperBundle = false;
		}
		if (activeBeginnerBundles.ContainsKey(shopId) && activeBeginnerBundles[shopId].id == bundleId)
		{
			activeBeginnerBundles.Remove(shopId);
			flag = true;
		}
		if (!completedBundles.Contains(bundleId))
		{
			completedBundles.Add(bundleId);
			purchaseCount++;
		}
		if (!flag && bundleId.EndsWith("off"))
		{
			string bundleId2 = bundleId.Substring(0, bundleId.Length - 6);
			Complete(shopId, bundleId2);
		}
	}

	private void HandleEnemyDied(Character c, Character.DeathReason reason, Damage dmg)
	{
		if (c.id == "ant")
		{
			antsKilled++;
		}
	}

	public void Parse(string sjson)
	{
		ClearProgress();
		if (sjson == null || activeSuperBundles == null || DEBUG_RESET_BUNDLE_SAVE_STATES)
		{
			return;
		}
		purchaseCount = SlimJson.ParseInt(sjson, "pcount");
		string[] array = SlimJson.ParseArray(sjson, "shopIds");
		if (array != null)
		{
			foreach (string key in array)
			{
				if (SlimJson.Parse(sjson, key, ShopData.Entry.FromString) is ShopData.LimitedTimeBundle value)
				{
					activeSuperBundles[key] = value;
				}
			}
		}
		array = SlimJson.ParseArray(sjson, "bShopIds");
		if (array != null)
		{
			foreach (string text in array)
			{
				if (SlimJson.Parse(sjson, "b_" + text, ShopData.Entry.FromString) is ShopData.LimitedTimeBundle value2)
				{
					activeBeginnerBundles[text] = value2;
				}
			}
		}
		string[] array2 = SlimJson.ParseArray(sjson, "completed");
		if (array2 != null && array2.Length != 0)
		{
			completedBundles.AddRange(array2);
		}
	}

	public string Serialize()
	{
		if (activeSuperBundles == null)
		{
			return null;
		}
		SlimJson.BeginSerialization();
		if (purchaseCount > 0)
		{
			SlimJson.AddProperty("pcount", purchaseCount);
		}
		if (activeSuperBundles.Count > 0)
		{
			string[] array = new string[activeSuperBundles.Count];
			int num = 0;
			foreach (KeyValuePair<string, ShopData.LimitedTimeBundle> activeSuperBundle in activeSuperBundles)
			{
				string key = (array[num] = activeSuperBundle.Key);
				num++;
				SlimJson.AddProperty(key, activeSuperBundle.Value.ToString());
			}
			SlimJson.AddProperty("shopIds", array);
		}
		if (activeBeginnerBundles.Count > 0)
		{
			string[] array2 = new string[activeBeginnerBundles.Count];
			int num2 = 0;
			foreach (KeyValuePair<string, ShopData.LimitedTimeBundle> activeBeginnerBundle in activeBeginnerBundles)
			{
				string text = (array2[num2] = activeBeginnerBundle.Key);
				num2++;
				SlimJson.AddProperty("b_" + text, activeBeginnerBundle.Value.ToString());
			}
			SlimJson.AddProperty("bShopIds", array2);
		}
		SlimJson.AddProperty("completed", completedBundles.ToArray());
		return SlimJson.EndSerialization();
	}

	public void ClearProgress()
	{
		antsKilled = 0;
		purchaseCount = 0;
		if (activeSuperBundles != null)
		{
			activeSuperBundles.Clear();
			activeBeginnerBundles.Clear();
			completedBundles.Clear();
		}
	}
}
