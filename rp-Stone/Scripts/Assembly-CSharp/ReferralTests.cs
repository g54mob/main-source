using SafeTypes;
using UnityEngine;

public class ReferralTests : MonoBehaviour
{
	private const string HERO_NAME = "standardcombo";

	private const string SAVE_ID = "ABCDEF";

	private string keyToRedeem = "";

	private void OnGUI()
	{
		float x = 100f;
		float num = 100f;
		float width = 150f;
		float height = 20f;
		GUI.Label(new Rect(x, num, width, height), "Hero Name");
		num += 25f;
		HeroSettings.name = GUI.TextField(new Rect(x, num, width, height), HeroSettings.name);
		num += 30f;
		GUI.Label(new Rect(x, num, width, height), "Save File ID");
		num += 25f;
		GameSave.activeSaveFile.uniqueId = GUI.TextField(new Rect(x, num, width, height), GameSave.activeSaveFile.uniqueId);
		num += 40f;
		if (GUI.Button(new Rect(x, num, width, height), "Is Enabled?"))
		{
			ReferralController.singleton.IsSystemEnabled(delegate(bool isEnabled)
			{
				Debug.Log("Is Enabled: " + isEnabled);
			});
		}
		num += 40f;
		if (GUI.Button(new Rect(x, num, width, height), "Get Key"))
		{
			ReferralController.singleton.GetKey(delegate(string key, int redeemCount)
			{
				if (key != null)
				{
					Debug.Log("Key: " + key + ", redeemCount: " + redeemCount);
				}
				else
				{
					Debug.Log("Get Key failed. Key is null.");
				}
			});
		}
		num += 40f;
		if (GUI.Button(new Rect(x, num, width, height), "Send Heartbeat"))
		{
			ReferralController.singleton.SendHeartbeat();
		}
		num += 40f;
		keyToRedeem = GUI.TextField(new Rect(x, num, width, height), keyToRedeem);
		num += 25f;
		if (GUI.Button(new Rect(x, num, width, height), "Redeem Key"))
		{
			ReferralController.singleton.RedeemKey(keyToRedeem, delegate(bool success, string friendName)
			{
				Debug.Log("Redeemed: " + keyToRedeem + ", success: " + success + ", friendName: " + friendName);
			});
		}
		num += 40f;
	}

	private void TestDataModelProgressValues()
	{
		TestProgress(0, 0);
		TestProgress(0, 3);
		TestProgress(0, 10);
		TestProgress(0, 40);
		TestProgress(0, 1);
		TestProgress(1, 1);
		TestProgress(1, 2);
		TestProgress(1, 3);
		TestProgress(1, 4);
		TestProgress(2, 4);
		TestProgress(1, 5);
		TestProgress(2, 5);
		TestProgress(2, 8);
		TestProgress(2, 9);
		TestProgress(3, 9);
		TestProgress(3, 10);
		TestProgress(3, 40);
		TestProgress(4, 40);
		TestProgress(5, 40);
		TestProgress(6, 40);
		TestProgress(7, 40);
		TestProgress(8, 40);
	}

	private void TestProgress(int collectedCount, int redemptionCount)
	{
		ReferralDataModel referralDataModel = new ReferralDataModel();
		referralDataModel.collectedTreasureCount = new SafeInt(collectedCount);
		referralDataModel.redemptionCount = new SafeInt(redemptionCount);
		referralDataModel.UpdateProgressValues();
		string[] obj = new string[10]
		{
			"___________\nRedemptions: ",
			referralDataModel.redemptionCount.GetValue().ToString(),
			"\nCollected:   ",
			referralDataModel.collectedTreasureCount.GetValue().ToString(),
			"\nProgress:    ",
			referralDataModel.progressValue.ToString(),
			" / ",
			referralDataModel.progressGoal.ToString(),
			"\nTreasures:   ",
			null
		};
		SafeInt totalTreasureCount = referralDataModel.totalTreasureCount;
		obj[9] = totalTreasureCount.ToString();
		Debug.Log(string.Concat(obj));
	}

	private void Awake()
	{
		HeroSettings.name = "standardcombo";
		GameSave.activeSaveFile = new SaveFiles.SaveFileMeta();
		GameSave.activeSaveFile.uniqueId = "ABCDEF";
		TestDataModelProgressValues();
	}
}
