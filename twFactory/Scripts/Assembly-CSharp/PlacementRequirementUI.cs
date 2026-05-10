using TMPro;
using UnityEngine;
using UnityEngine.Localization.Settings;

public class PlacementRequirementUI : MonoBehaviour
{
	[SerializeField]
	private GameObject costGO;

	[SerializeField]
	private GameObject towerLimitGO;

	private TextMeshProUGUI towerLimitText;

	private WorldObjectUI worldObjectUI;

	private void Awake()
	{
		worldObjectUI = GetComponent<WorldObjectUI>();
		towerLimitText = towerLimitGO.GetComponent<TextMeshProUGUI>();
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
		UpdateMaxTowersAmountText();
	}

	private void OnDestroy()
	{
		LTFunctionLibrary.GetPlayerData().onPlayerTowerAdded -= delegate
		{
			UpdateMaxTowersAmountText();
		};
		LTFunctionLibrary.GetPlayerData().onPlayerTowerRemoved -= delegate
		{
			UpdateMaxTowersAmountText();
		};
	}

	private void OnEnable()
	{
		ShowCostGO(show: false);
		ShowTowerLimitGO(show: false);
	}

	public void SetFollowTarget(GameObject target)
	{
		worldObjectUI.SetFollowTarget(target);
	}

	public void ShowCostGO(bool show)
	{
		costGO.SetActive(show);
	}

	public void ShowTowerLimitGO(bool show)
	{
		towerLimitGO.SetActive(show);
	}

	private void UpdateMaxTowersAmountText()
	{
		towerLimitText.text = LocalizationSettings.StringDatabase.GetLocalizedString("UI_InGame", "UI_InGame_placementRequirements_maxTowers", null, FallbackBehavior.UseProjectSettings);
		if (LTFunctionLibrary.GetPlayerData().CanBuildTowersOverLimit)
		{
			TextMeshProUGUI textMeshProUGUI = towerLimitText;
			textMeshProUGUI.text = textMeshProUGUI.text + "<size=75%> (x" + LTFunctionLibrary.GetPlayerData().GetCurrentTowersTaxesMultiplier() + ")";
		}
	}
}
