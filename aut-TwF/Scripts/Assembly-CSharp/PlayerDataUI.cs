using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Localization;

public class PlayerDataUI : MonoBehaviour
{
	private const string ENEMY_ESSENCE_ID = "enemyEssence";

	private const string LIGHT_CRYSTAL_ID = "lightCrystal";

	[SerializeField]
	private TextMeshProUGUI maxTowersAmountText;

	[SerializeField]
	private TextMeshProUGUI enemyEssenceText;

	[SerializeField]
	private TextMeshProUGUI lightCrystalsText;

	[SerializeField]
	private Color maxTowersColor = Color.red;

	[SerializeField]
	private Color towerTaxesColor = Color.yellow;

	[SerializeField]
	private TooltipComponent_text maxTowersTooltip;

	private Color defaultMaxTowersColor;

	private void Awake()
	{
		defaultMaxTowersColor = maxTowersAmountText.color;
		Dictionary<string, object> dictionary = new Dictionary<string, object>
		{
			{
				"can-build-over-limit",
				LTFunctionLibrary.GetPlayerData().CanBuildTowersOverLimit
			},
			{
				"taxes",
				FunctionLibrary.RoundToDecimals(LTFunctionLibrary.GetPlayerStatsComponent().GetStat(EStats.MaxTowersTaxes) * 100f, 2)
			}
		};
		maxTowersTooltip.TooltipText = new LocalizedString("UI_InGame", "UI_InGame_main_tooltip_maxTowers").GetLocalizedString(dictionary);
	}

	private void Start()
	{
		LTFunctionLibrary.GetPlayerData().onPlayerTowerAdded += delegate
		{
			UpdateMaxTowersAmountText();
		};
		LTFunctionLibrary.GetPlayerData().onPlayerTowerRemoved += delegate
		{
			UpdateMaxTowersAmountText();
		};
		LTFunctionLibrary.GetPlayerData().Inventory.onStoreObject += delegate(Storage<ResourceData>.StoredObjectData x, int y, string z)
		{
			OnStoreObject(x, y, z);
		};
		LTFunctionLibrary.GetPlayerData().Inventory.onRemoveObject += delegate(Storage<ResourceData>.StoredObjectData x, int y)
		{
			OnRemoveObject(x, y);
		};
		LTFunctionLibrary.GetPlayerStatsComponent().onStatChanged += delegate(EStats stat, float newValue, float oldValue)
		{
			if (stat == EStats.MaxTowersAmount)
			{
				UpdateMaxTowersAmountText();
			}
		};
		UpdateMaxTowersAmountText();
		UpdateEnemyEssenceText();
		UpdateLightCrystalsText();
	}

	private void UpdateMaxTowersAmountText()
	{
		maxTowersAmountText.text = LTFunctionLibrary.GetPlayerData().PlayerTowers.Count + "/" + LTFunctionLibrary.GetPlayerStatsComponent().GetStat(EStats.MaxTowersAmount);
		if (LTFunctionLibrary.GetPlayerData().HasReachedTowerLimit())
		{
			if (LTFunctionLibrary.GetPlayerData().CanBuildTowersOverLimit)
			{
				maxTowersAmountText.text = "<size=30%> \n</size>" + maxTowersAmountText.text;
				TextMeshProUGUI textMeshProUGUI = maxTowersAmountText;
				textMeshProUGUI.text = textMeshProUGUI.text + "!<size=60%>\n(x" + LTFunctionLibrary.GetPlayerData().GetCurrentTowersTaxesMultiplier() + ")";
				maxTowersAmountText.color = towerTaxesColor;
			}
			else
			{
				maxTowersAmountText.color = maxTowersColor;
			}
		}
		else
		{
			maxTowersAmountText.color = defaultMaxTowersColor;
		}
	}

	private void UpdateEnemyEssenceText()
	{
		enemyEssenceText.text = LTFunctionLibrary.GetPlayerInventory().GetStoredObjectAmount("enemyEssence").ToString();
	}

	private void UpdateLightCrystalsText()
	{
		lightCrystalsText.text = LTFunctionLibrary.GetPlayerInventory().GetStoredObjectAmount("lightCrystal").ToString();
	}

	private void OnRemoveObject(Storage<ResourceData>.StoredObjectData removingObject, int removedAmount)
	{
		if (removingObject.id == "enemyEssence")
		{
			UpdateEnemyEssenceText();
		}
		else if (removingObject.id == "lightCrystal")
		{
			UpdateLightCrystalsText();
		}
	}

	private void OnStoreObject(Storage<ResourceData>.StoredObjectData storingObject, int storedAmount, string storeSourceID)
	{
		if (storingObject.id == "enemyEssence")
		{
			UpdateEnemyEssenceText();
		}
		else if (storingObject.id == "lightCrystal")
		{
			UpdateLightCrystalsText();
		}
	}
}
