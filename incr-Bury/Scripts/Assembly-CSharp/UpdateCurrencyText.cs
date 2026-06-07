using System;
using MoreMountains.Feedbacks;
using TMPro;
using UnityEngine;

public class UpdateCurrencyText : MonoBehaviour
{
	private TMP_Text currencyText;

	public bool isMoney;

	public bool isMoney_Held;

	public bool isStarOrbs;

	public bool isCultist;

	public bool isStarOrbCanUpgradeBerryBoyReminder;

	public bool isGrowthRate;

	[Header("Can Upgrade Berry Reminders")]
	[SerializeField]
	private MMF_Player canUpgradeBerryBoy_Feedback;

	[SerializeField]
	private GameObject canUpgradeBerryBoy_Backer;

	[Header("Colors")]
	[SerializeField]
	private Color textColor_GrowthRate_Normal;

	[SerializeField]
	private Color textColor_GrowthRate_Boosted;

	private void Awake()
	{
		currencyText = GetComponent<TMP_Text>();
	}

	private void Start()
	{
		if (isStarOrbCanUpgradeBerryBoyReminder)
		{
			PlayerStats singleton = PlayerStats.Singleton;
			singleton.OnStarOrbsChanged_Action = (Action)Delegate.Combine(singleton.OnStarOrbsChanged_Action, new Action(StarOrbsAmt_OnChanged));
			GameManager singleton2 = GameManager.Singleton;
			singleton2.OnRoundStart_Action = (Action)Delegate.Combine(singleton2.OnRoundStart_Action, new Action(OnRoundStart));
			Cannot_AffordABerryBoyUpgrade();
		}
	}

	private void OnDestroy()
	{
		if (isStarOrbCanUpgradeBerryBoyReminder)
		{
			PlayerStats singleton = PlayerStats.Singleton;
			singleton.OnStarOrbsChanged_Action = (Action)Delegate.Remove(singleton.OnStarOrbsChanged_Action, new Action(StarOrbsAmt_OnChanged));
			GameManager singleton2 = GameManager.Singleton;
			singleton2.OnRoundStart_Action = (Action)Delegate.Remove(singleton2.OnRoundStart_Action, new Action(OnRoundStart));
		}
	}

	private void Update()
	{
		if (isMoney)
		{
			currencyText.text = "$" + FormatHelper.FormatNumberWithCommmas(PlayerStats.Singleton.money);
		}
		else if (isStarOrbs)
		{
			currencyText.text = "*" + FormatHelper.FormatNumberWithCommmas(PlayerStats.Singleton.starOrbs);
		}
		else if (isCultist)
		{
			currencyText.text = GameManager.Singleton.spawnedCultists.Count + "/" + PlayerStats.Singleton.cultistCapacity_Curr;
		}
		else if (isMoney_Held)
		{
			if (PlayerStats.Singleton.money_Held > 0 && GameManager.Singleton.gameState == GameManager.GameState.Playing)
			{
				currencyText.text = "$" + FormatHelper.FormatNumberWithCommmas(PlayerStats.Singleton.money_Held);
			}
			else
			{
				currencyText.text = "";
			}
		}
		else
		{
			if (!isGrowthRate)
			{
				return;
			}
			if (GameManager.Singleton.gameState == GameManager.GameState.Playing || GameManager.Singleton.gameState == GameManager.GameState.RoundOverShop)
			{
				if (PlayerStats.Singleton.blenderBot_Unlocked || PlayerStats.Singleton.rewind_TimesUsed > 0 || PlayerStats.Singleton.berryGrowthRate_Multiplier > 1f)
				{
					if (GameManager.Singleton.globalBerryGrowthRate <= PlayerStats.Singleton.berryGrowthRate_Multiplier)
					{
						currencyText.text = GameManager.Singleton.globalBerryGrowthRate.ToString("F2") + "x";
						currencyText.color = textColor_GrowthRate_Normal;
					}
					else
					{
						currencyText.text = GameManager.Singleton.globalBerryGrowthRate.ToString("F2") + "x";
						currencyText.color = textColor_GrowthRate_Boosted;
					}
				}
				else
				{
					currencyText.text = "";
				}
			}
			else
			{
				currencyText.text = "";
			}
		}
	}

	private void StarOrbsAmt_OnChanged()
	{
		if (!PlayerStats.Singleton.StarWand_Unlocked || GameManager.Singleton.spawnedCultists.Count <= 0)
		{
			Cannot_AffordABerryBoyUpgrade();
			return;
		}
		bool flag = false;
		foreach (BerryCultist_AI spawnedCultist in GameManager.Singleton.spawnedCultists)
		{
			if (spawnedCultist.HasEnoughStarsToUpgrade())
			{
				flag = true;
				break;
			}
		}
		if (flag)
		{
			Can_AffordABerryBoyUpgrade();
		}
		else
		{
			Cannot_AffordABerryBoyUpgrade();
		}
	}

	private void Can_AffordABerryBoyUpgrade()
	{
		canUpgradeBerryBoy_Backer.SetActive(value: true);
		currencyText.gameObject.SetActive(value: true);
		canUpgradeBerryBoy_Feedback?.PlayFeedbacks();
	}

	private void Cannot_AffordABerryBoyUpgrade()
	{
		canUpgradeBerryBoy_Backer.SetActive(value: false);
		currencyText.gameObject.SetActive(value: false);
	}

	private void OnRoundStart()
	{
		StarOrbsAmt_OnChanged();
	}
}
