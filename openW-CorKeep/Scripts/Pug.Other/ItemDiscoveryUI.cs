using System.Collections.Generic;
using I2.Loc;
using UnityEngine;

public class ItemDiscoveryUI : MonoBehaviour
{
	public List<ItemDiscoveryTextUI> discoveryTexts;

	public ItemDiscoveryTextUI discoveryTextPrefab;

	public Transform container;

	public List<ItemDiscoveryTextUI> activeTexts = new List<ItemDiscoveryTextUI>();

	public void ShowDiscoveredItem(List<string> texts, Rarity rarity)
	{
		if (texts == null)
		{
			return;
		}
		string text = "";
		foreach (string text2 in texts)
		{
			text = text + LocalizationManager.GetTranslation(text2) + " ";
		}
		int i;
		for (i = 0; i < discoveryTexts.Count; i++)
		{
			if (!discoveryTexts[i].gameObject.activeSelf)
			{
				discoveryTexts[i].Activate(text, rarity, this);
				break;
			}
		}
		if (i == discoveryTexts.Count)
		{
			ItemDiscoveryTextUI itemDiscoveryTextUI = Object.Instantiate(discoveryTextPrefab, container);
			discoveryTexts.Add(itemDiscoveryTextUI);
			itemDiscoveryTextUI.Activate(text, rarity, this);
		}
		Vector3 zero = Vector3.zero;
		for (int num = activeTexts.Count - 1; num >= 0; num--)
		{
			if (activeTexts[num].gameObject.activeSelf)
			{
				activeTexts[num].transform.localPosition = zero;
				zero += new Vector3(0f, activeTexts[num].pugText.dimensions.height, 0f);
			}
		}
	}

	private void LateUpdate()
	{
		container.transform.localScale = Manager.ui.CalcGameplayUITargetScaleMultiplier();
	}
}
