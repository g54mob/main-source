using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MenuDebugRelics : Menu
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
		List<EnhancementUpgrade> list = (from u in UpgradeManager.Instance.Relics
			where u.name.ToLower().Contains(search.ToLower()) && !UpgradeManager.Instance.RelicsInInventory.Contains(u) && !LootUtils.UpgradeExclusiveMet(u)
			orderby u.name
			select u).ToList();
		for (int num = 0; num < list.Count; num++)
		{
			EnhancementUpgrade relic = list[num];
			GameObject obj = Object.Instantiate(buttonPrefab, Vector3.zero, Quaternion.identity, content.transform);
			Button component = obj.GetComponent<Button>();
			component.onClick.AddListener(delegate
			{
				UpgradeManager.Instance.AddRelic(relic);
			});
			component.onClick.AddListener(delegate
			{
				Repopulate(input.text);
			});
			obj.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = relic.name;
		}
	}

	public void AddRandomRelicsFromInput()
	{
		if (!int.TryParse(inputField.text, out var result) || result <= 0)
		{
			Debug.LogWarning("Invalid input: '" + inputField.text + "' — Must be a positive number.");
			return;
		}
		List<EnhancementUpgrade> list = UpgradeManager.Instance.Relics.Where((EnhancementUpgrade r) => !UpgradeManager.Instance.RelicsInInventory.Contains(r)).ToList();
		if (list.Count == 0)
		{
			Debug.LogWarning("No available relics to add.");
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
			UpgradeManager.Instance.AddRelic(list[num3]);
		}
		Repopulate(input.text);
	}
}
