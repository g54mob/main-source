using System;
using System.Collections;
using System.Collections.Generic;
using SafeTypes;
using UnityEngine;
using UnityEngine.Networking;

public class ReferralController : MonoBehaviour
{
	public const bool SCOTTY_EXPLAINS_EXHAUSTION_ENABLED = true;

	private const string BASE_URL = "https://stonestoryrpg.com/ref/";

	public string inputSalt;

	public string outputSalt;

	private string currentRedeemingKey;

	private List<string> lastRedeemedKeys;

	private SafeInt totalRedeemedKeys;

	public Action<ReferralDataModel> OnReferralDataChanged;

	private float lastTime_Update;

	private float lastTime_IsSystemEnabled;

	private bool lastValue_IsSystemEnabled;

	private float lastTime_SendHeartbeat;

	public ReferralDataModel data { get; set; }

	public bool hasSeenScottyQuestion { get; set; }

	public bool scottyExplainsExhaustion { get; set; }

	public static ReferralController singleton { get; private set; }

	public bool HasTreasureToCollect()
	{
		if (data == null)
		{
			return false;
		}
		return data.HasTreasureToCollect();
	}

	public void UnlockReferralQuest()
	{
		IsSystemEnabled(delegate(bool isEnabled)
		{
			if (isEnabled)
			{
				GetKey(delegate(string key, int redeemCount)
				{
					if (key != null)
					{
						bool flag = false;
						if (data == null)
						{
							flag = true;
							data = new ReferralDataModel();
							AnalyticsMacros.ReferralQuestUnlocked();
						}
						if (flag || data.HasExpired() || data.redemptionCount.GetValue() != redeemCount)
						{
							data.referralKey = key;
							data.redemptionCount = new SafeInt(redeemCount);
							data.Refresh();
							if (OnReferralDataChanged != null)
							{
								OnReferralDataChanged(data);
							}
						}
					}
				});
			}
		});
		singleton.scottyExplainsExhaustion = true;
	}

	public void UpdateReferralQuestData()
	{
		if (data == null || (lastTime_Update > 0f && Time.realtimeSinceStartup - lastTime_Update < 10f))
		{
			return;
		}
		lastTime_Update = Time.realtimeSinceStartup;
		IsSystemEnabled(delegate(bool isEnabled)
		{
			if (isEnabled)
			{
				GetKey(delegate(string key, int redeemCount)
				{
					if (key != null && (data.referralKey != key || data.redemptionCount.GetValue() != redeemCount))
					{
						data.referralKey = key;
						data.redemptionCount = new SafeInt(redeemCount);
						data.UpdateProgressValues();
						if (OnReferralDataChanged != null)
						{
							OnReferralDataChanged(data);
						}
					}
				});
			}
		});
	}

	public TreasureItem CollectOneTreasureReward()
	{
		++data.collectedTreasureCount;
		data.Refresh();
		AnalyticsMacros.ReferralQuestReward();
		if (OnReferralDataChanged != null)
		{
			OnReferralDataChanged(data);
		}
		TreasureItem obj = ItemFactory.singleton.MakeItem("treasure_gold") as TreasureItem;
		obj.itemsInTreasure = TreasureFactory.singleton.MakeShopTreasureData("mushroom_shop", TreasureItem.Type.Gold, null);
		return obj;
	}

	public bool CanRedeem()
	{
		int value = totalRedeemedKeys.GetValue();
		int num = 0;
		if (data != null)
		{
			num = Mathf.Max(data.collectedTreasureCount.GetValue(), Mathf.CeilToInt((float)data.redemptionCount.GetValue() * 0.95f));
		}
		return value <= num;
	}

	public void IsSystemEnabled(Action<bool> callback)
	{
		if (!HeroSettings.isNameSet)
		{
			callback(obj: false);
			return;
		}
		if (lastTime_IsSystemEnabled > 0f && Time.realtimeSinceStartup - lastTime_IsSystemEnabled < 1200f)
		{
			callback(lastValue_IsSystemEnabled);
			return;
		}
		lastTime_IsSystemEnabled = Time.realtimeSinceStartup;
		StartCoroutine(_IsSystemEnabled(delegate(bool value)
		{
			lastValue_IsSystemEnabled = value;
			callback(value);
		}));
	}

	public void SendHeartbeat()
	{
		if (HeroSettings.isNameSet && (lastTime_SendHeartbeat == 0f || Time.realtimeSinceStartup - lastTime_SendHeartbeat > 86400f))
		{
			lastTime_SendHeartbeat = Time.realtimeSinceStartup;
			StartCoroutine(_SendHeartbeat(GetHeroName(), GetSaveFileId()));
		}
	}

	public void GetKey(Action<string, int> callback)
	{
		if (!HeroSettings.isNameSet)
		{
			callback(null, 0);
			return;
		}
		lastTime_SendHeartbeat = Time.realtimeSinceStartup;
		StartCoroutine(_GetKey(GetHeroName(), GetSaveFileId(), SaveFiles.deviceId, callback));
	}

	public void RedeemKey(string referralKey, Action<bool, string> callback)
	{
		referralKey = referralKey.ToUpperInvariant();
		StartCoroutine(_RedeemKey(referralKey, GetSaveFileId(), SaveFiles.deviceId, callback));
	}

	private string GetHeroName()
	{
		return HeroSettings.name;
	}

	private string GetSaveFileId()
	{
		if (GameSave.activeSaveFile == null)
		{
			return null;
		}
		return GameSave.activeSaveFile.uniqueId;
	}

	private IEnumerator _IsSystemEnabled(Action<bool> callback)
	{
		string text = "https://stonestoryrpg.com/ref/isenabled.php";
		Utils.LogIfEditor("Calling remote: " + text);
		WWWForm formData = new WWWForm();
		using UnityWebRequest webRequest = UnityWebRequest.Post(text, formData);
		yield return webRequest.SendWebRequest();
		if (webRequest.result != UnityWebRequest.Result.Success)
		{
			Utils.LogErrorIfEditor(webRequest.error);
			callback(obj: false);
		}
		else if (webRequest.downloadHandler.text.Contains("True"))
		{
			callback(obj: true);
		}
		else
		{
			callback(obj: false);
		}
	}

	private IEnumerator _SendHeartbeat(string heroName, string saveFileId)
	{
		string text = "https://stonestoryrpg.com/ref/heartbeat.php";
		Utils.LogIfEditor("Calling remote: " + text);
		WWWForm wWWForm = new WWWForm();
		wWWForm.AddField("name", heroName);
		wWWForm.AddField("save_id", saveFileId);
		using UnityWebRequest webRequest = UnityWebRequest.Post(text, wWWForm);
		yield return webRequest.SendWebRequest();
		if (webRequest.result != UnityWebRequest.Result.Success)
		{
			Utils.LogErrorIfEditor(webRequest.error);
		}
	}

	private IEnumerator _GetKey(string heroName, string saveFileId, string deviceId, Action<string, int> callback)
	{
		string text = "https://stonestoryrpg.com/ref/getkey.php";
		string text2 = Utils.MD5(heroName + saveFileId + inputSalt);
		WWWForm wWWForm = new WWWForm();
		wWWForm.AddField("name", heroName);
		wWWForm.AddField("save_id", saveFileId);
		wWWForm.AddField("device", deviceId);
		wWWForm.AddField("valid", text2);
		Utils.LogIfEditor(text + "?name=" + heroName + "&save_id=" + saveFileId + "&device=" + deviceId + "&valid=" + text2);
		using UnityWebRequest webRequest = UnityWebRequest.Post(text, wWWForm);
		yield return webRequest.SendWebRequest();
		if (webRequest.result != UnityWebRequest.Result.Success)
		{
			Utils.LogErrorIfEditor(webRequest.error);
			callback(null, 0);
			yield break;
		}
		string text3 = webRequest.downloadHandler.text;
		string text4 = SlimJson.Parse(text3, "key");
		int arg = SlimJson.ParseInt(text3, "rs");
		text2 = SlimJson.Parse(text3, "valid");
		if (text2 != Utils.MD5(text4 + arg + outputSalt))
		{
			Utils.LogErrorIfEditor("Key request failed validation");
			callback(null, 0);
		}
		else
		{
			callback(text4, arg);
		}
	}

	private IEnumerator _RedeemKey(string referralKey, string saveFileId, string deviceId, Action<bool, string> callback)
	{
		if (lastRedeemedKeys != null && lastRedeemedKeys.Contains(referralKey))
		{
			Utils.LogIfEditor("Key " + referralKey + " already redeemed");
			callback(arg1: false, null);
			yield break;
		}
		string text = "https://stonestoryrpg.com/ref/redeem.php";
		string text2 = Utils.MD5(referralKey + saveFileId + inputSalt);
		WWWForm wWWForm = new WWWForm();
		wWWForm.AddField("key", referralKey);
		wWWForm.AddField("save_id", saveFileId);
		wWWForm.AddField("device", deviceId);
		wWWForm.AddField("valid", text2);
		Utils.LogIfEditor(text + "?key=" + referralKey + "&save_id=" + saveFileId + "&device=" + deviceId + "&valid=" + text2);
		using UnityWebRequest webRequest = UnityWebRequest.Post(text, wWWForm);
		yield return webRequest.SendWebRequest();
		if (webRequest.result != UnityWebRequest.Result.Success)
		{
			Utils.LogErrorIfEditor(webRequest.error);
			callback(arg1: false, null);
			yield break;
		}
		string text3 = webRequest.downloadHandler.text;
		text2 = SlimJson.Parse(text3, "valid");
		if (text2 != Utils.MD5(referralKey + outputSalt))
		{
			Utils.LogIfEditor("Reply: " + text3);
			Utils.LogErrorIfEditor("Key redemption failed validation");
			callback(arg1: false, null);
		}
		else
		{
			currentRedeemingKey = referralKey;
			string arg = SlimJson.Parse(text3, "friendName");
			callback(arg1: true, arg);
		}
	}

	public void ReportCurrentRedeemTransactionComplete()
	{
		if (lastRedeemedKeys == null)
		{
			lastRedeemedKeys = new List<string>();
		}
		lastRedeemedKeys.Add(currentRedeemingKey);
		if (lastRedeemedKeys.Count > 5)
		{
			lastRedeemedKeys.RemoveAt(0);
		}
		++totalRedeemedKeys;
		currentRedeemingKey = null;
		AnalyticsMacros.ReferralKeyRedeemed();
	}

	public void ClearProgress()
	{
		if (data != null)
		{
			data = null;
			hasSeenScottyQuestion = false;
			scottyExplainsExhaustion = true;
			lastRedeemedKeys = null;
			totalRedeemedKeys = new SafeInt(0);
			if (OnReferralDataChanged != null)
			{
				OnReferralDataChanged(data);
			}
		}
	}

	public void Parse(string sjson)
	{
		ClearProgress();
		string text = SlimJson.Parse(sjson, "referral");
		if (text != null)
		{
			data = ReferralDataModel.FromString(text);
			UpdateReferralQuestData();
		}
		hasSeenScottyQuestion = SlimJson.ParseBool(sjson, "scotRef");
		scottyExplainsExhaustion = SlimJson.ParseBool(sjson, "scotExh", defaultValue: true);
		string[] array = SlimJson.ParseArray(sjson, "lrk");
		if (array != null && array.Length != 0)
		{
			lastRedeemedKeys = new List<string>(array);
		}
		int num = SlimJson.ParseInt(sjson, "trk");
		if (lastRedeemedKeys == null)
		{
			num = 0;
		}
		else if (num < lastRedeemedKeys.Count)
		{
			num = lastRedeemedKeys.Count;
		}
		totalRedeemedKeys = new SafeInt(num);
	}

	public void Serialize()
	{
		if (data != null)
		{
			SlimJson.AddProperty("referral", data.ToString());
		}
		if (hasSeenScottyQuestion)
		{
			SlimJson.AddProperty("scotRef", property: true);
		}
		if (!scottyExplainsExhaustion)
		{
			SlimJson.AddProperty("scotExh", property: false);
		}
		if (lastRedeemedKeys != null && lastRedeemedKeys.Count > 0)
		{
			SlimJson.AddProperty("lrk", lastRedeemedKeys.ToArray());
		}
		if (totalRedeemedKeys.GetValue() > 0)
		{
			SlimJson.AddProperty("trk", totalRedeemedKeys.GetValue());
		}
	}

	private void Awake()
	{
		singleton = this;
	}
}
