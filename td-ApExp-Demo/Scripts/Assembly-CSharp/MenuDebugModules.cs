using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MenuDebugModules : Menu
{
	[SerializeField]
	private GameObject buttonPrefab;

	[SerializeField]
	private GameObject content;

	[SerializeField]
	private TMP_InputField inputField;

	public override void Init()
	{
		base.Init();
		Populate();
	}

	private void Populate()
	{
		EnhancementModule[] array = UpgradeManager.Instance.Modules.ToArray();
		for (int i = 0; i < array.Length; i++)
		{
			int num = i;
			EnhancementModule module = array[num];
			GameObject obj = Object.Instantiate(buttonPrefab, Vector3.zero, Quaternion.identity, content.transform);
			obj.GetComponent<Button>().onClick.AddListener(delegate
			{
				UpgradeManager.Instance.AddModule(module);
			});
			obj.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = module.Name;
		}
	}

	public void AddRandomModulesFromInput()
	{
		if (!int.TryParse(inputField.text, out var result) || result <= 0)
		{
			Debug.LogWarning("Invalid input: Must be a positive number.");
			return;
		}
		List<EnhancementModule> list = UpgradeManager.Instance.Modules.Except(UpgradeManager.Instance.StartingModules).ToList();
		for (int i = 0; i < list.Count; i++)
		{
			int num = DRNG.Instance.NextInt(i, list.Count);
			int index = i;
			List<EnhancementModule> list2 = list;
			int index2 = num;
			EnhancementModule enhancementModule = list[num];
			EnhancementModule enhancementModule2 = list[i];
			EnhancementModule enhancementModule3 = (list[index] = enhancementModule);
			enhancementModule3 = (list2[index2] = enhancementModule2);
		}
		for (int j = 0; j < Mathf.Min(result, list.Count); j++)
		{
			UpgradeManager.Instance.AddModule(list[j]);
		}
	}
}
