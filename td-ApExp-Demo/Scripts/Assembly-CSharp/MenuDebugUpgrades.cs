using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MenuDebugUpgrades : Menu
{
	[SerializeField]
	private GameObject buttonPrefab;

	[SerializeField]
	private GameObject content;

	[SerializeField]
	private TMP_InputField input;

	[SerializeField]
	private TMP_InputField inputField;

	protected override void OnOpen()
	{
		UpdateSearch();
	}

	public void UpdateSearch()
	{
		Repopulate(input.text);
	}

	private void Repopulate(string search)
	{
		foreach (Transform item in content.transform)
		{
			Object.Destroy(item.gameObject);
		}
		foreach (EnhancementUpgrade upgrade in (from u in UpgradeManager.Instance.Upgrades
			where u.name.ToLower().Contains(search.ToLower()) && LootUtils.UpgradeHasInstance(u) && LootUtils.UpgradePrerequisitesMet(u) && LootUtils.UpgradeRequiredModulesMet(u) && !LootUtils.IsUpgradeInGraveyard(u) && !LootUtils.UpgradeExclusiveMet(u) && !UpgradeManager.Instance.UpgradesInInventory.Contains(u)
			orderby u.name
			select u).ToList())
		{
			GameObject obj = Object.Instantiate(buttonPrefab, Vector3.zero, Quaternion.identity, content.transform);
			Button component = obj.GetComponent<Button>();
			component.onClick.AddListener(delegate
			{
				UpgradeManager.Instance.AddUpgrade(upgrade);
			});
			component.onClick.AddListener(delegate
			{
				Repopulate(input.text);
			});
			obj.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = upgrade.name;
		}
	}

	public void AddRandomUpgradesFromInput()
	{
		if (!int.TryParse(inputField.text, out var result) || result <= 0)
		{
			Debug.LogWarning("Invalid input: '" + inputField.text + "' — Must be a positive number.");
			return;
		}
		List<EnhancementUpgrade> list = UpgradeManager.Instance.Upgrades.Where((EnhancementUpgrade upgrade) => LootUtils.UpgradeHasInstance(upgrade) && LootUtils.UpgradePrerequisitesMet(upgrade) && LootUtils.UpgradeRequiredModulesMet(upgrade) && !LootUtils.IsUpgradeInGraveyard(upgrade) && !LootUtils.UpgradeExclusiveMet(upgrade) && !UpgradeManager.Instance.UpgradesInInventory.Contains(upgrade) && !upgrade.StatsObjectsToUpgrade.Contains(UpgradeManager.Instance.CannonStatsSO)).ToList();
		if (list.Count == 0)
		{
			Debug.LogWarning("No valid upgrades available.");
			return;
		}
		for (int num = 0; num < list.Count; num++)
		{
			int num2 = DRNG.Instance.NextInt(num, list.Count);
			int index = num;
			List<EnhancementUpgrade> list2 = list;
			int index2 = num2;
			EnhancementUpgrade enhancementUpgrade = list[num2];
			EnhancementUpgrade enhancementUpgrade2 = list[num];
			EnhancementUpgrade enhancementUpgrade3 = (list[index] = enhancementUpgrade);
			enhancementUpgrade3 = (list2[index2] = enhancementUpgrade2);
		}
		for (int num3 = 0; num3 < Mathf.Min(result, list.Count); num3++)
		{
			UpgradeManager.Instance.AddUpgrade(list[num3]);
		}
		Repopulate(input.text);
	}
}
