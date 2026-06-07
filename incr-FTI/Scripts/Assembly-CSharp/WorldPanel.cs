using System.Collections.Generic;
using UnityEngine;

public class WorldPanel : MenuListPanel
{
	private readonly List<WorldListItem> listItems = new List<WorldListItem>();

	public GameObject worldListItemPrefab;

	public bool isCostInfoStale;

	public bool areValuesStale;

	public bool areCountsStale;

	public bool areTownsStale;

	public bool isActiveTownStale;

	public bool areBiomeDetailsStale;

	public override void Show()
	{
		if (areBiomeDetailsStale)
		{
			foreach (WorldListItem listItem in listItems)
			{
				Object.Destroy(listItem.gameObject);
			}
			listItems.Clear();
			for (int i = 0; i < Data.BiomeIndex.Length; i++)
			{
				AddItem(Data.BiomeIndex[i]);
			}
			areBiomeDetailsStale = false;
			areTownsStale = true;
		}
		base.Show();
	}

	public override void Hide()
	{
		base.Hide();
		foreach (WorldListItem listItem in listItems)
		{
			listItem.ResetPointerAndHighlightState();
		}
	}

	protected override void UpdateItemAvailability()
	{
		base.UpdateItemAvailability();
		foreach (WorldListItem listItem in listItems)
		{
			listItem.UpdateAvailability();
		}
	}

	private void AddItem(int townIndex)
	{
		WorldListItem component = MenuManager.GetMenuObject(worldListItemPrefab, layoutGroup.transform).GetComponent<WorldListItem>();
		component.Initialize();
		component.InitializeBiome(GameManager.DefaultBiomeForIndex(townIndex));
		listItems.Add(component);
		component.townIndex = townIndex;
	}

	public override void ResetPanel()
	{
		base.ResetPanel();
		foreach (WorldListItem listItem in listItems)
		{
			listItem.gameObject.SetActive(value: false);
		}
		areBiomeDetailsStale = true;
	}

	public override void CreateItems()
	{
		base.CreateItems();
	}

	protected override void UpdateSimulationDisplay()
	{
		base.UpdateSimulationDisplay();
		foreach (WorldListItem listItem in listItems)
		{
			listItem.UpdateSimulationDisplay();
		}
	}

	protected override void UpdateDynamicDisplay()
	{
		base.UpdateDynamicDisplay();
		if (isCostInfoStale)
		{
			UpdateCosts();
		}
		if (isActiveTownStale)
		{
			if (MenuPanel.gm.activeTownIndex < listItems.Count)
			{
				listItems[MenuPanel.gm.activeTownIndex].UpdateTownDisplay();
			}
			isActiveTownStale = false;
		}
		if (areTownsStale)
		{
			foreach (WorldListItem listItem in listItems)
			{
				listItem.gameObject.SetActive(value: true);
				listItem.UpdateTownDisplay();
			}
			areTownsStale = false;
		}
		if (areCountsStale)
		{
			UpdateCounts();
		}
		if (areValuesStale)
		{
			ReloadLabels();
		}
		foreach (WorldListItem listItem2 in listItems)
		{
			listItem2.UpdateDynamicDisplay();
		}
	}

	public override void UpdateStaticDisplay()
	{
		base.UpdateStaticDisplay();
		UpdateCosts();
		UpdateCounts();
		areTownsStale = true;
	}

	public void UpdateCounts()
	{
		areCountsStale = false;
	}

	public void SwitchTown()
	{
	}

	public void UpdateCosts()
	{
		isCostInfoStale = false;
	}

	public override bool ShouldBeAvailable()
	{
		if (MenuPanel.gm.gameModifierBiomes == GameModifier.ExtremeBiomes || MenuPanel.gm.gameModifierBiomes == GameModifier.MildBiomes)
		{
			return true;
		}
		if (MenuPanel.gm.gameModifierBiomes == GameModifier.NoBiomes)
		{
			return false;
		}
		if (MenuPanel.gm.isUnlockedBiomesMode)
		{
			return true;
		}
		return GameManager.IsGlobalQuestComplete(Quest.UnlockWorldPanel);
	}
}
