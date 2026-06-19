using System.Collections.Generic;
using Pug.UnityExtensions;
using UnityEngine;

public class CharacterWindowUI : MonoBehaviour
{
	public GameObject root;

	public EquipmentInventoryUI equipmentInventory;

	public PlayerController playerPreview;

	public SkillsWindow skillsWindow;

	public List<CharacterWindowTab> windowTabs;

	public List<CharacterWindowTab> presetTabs;

	public SoulsUI soulsWindow;

	public CharacterStatsWindow statsWindow;

	public ButtonUIElement statsButton;

	public bool isShowing => root.activeInHierarchy;

	private void Awake()
	{
		equipmentInventory.Init();
		HideStatsWindow();
		Hide();
	}

	public void UpdateCharacterCustomization()
	{
		playerPreview.activeCustomization = Manager.main.player.activeCustomization;
		playerPreview.RefreshCustomization();
	}

	public void Show()
	{
		UpdateCharacterCustomization();
		Update();
		root.SetActive(value: true);
		ShowEquipmentWindow(dontPlaySound: true);
		UpdatePresetTabs();
	}

	private void Update()
	{
		if (Manager.main.player != null && root.activeSelf)
		{
			playerPreview.animator.SetFloat(898384463, Direction.back.vec2.x);
			playerPreview.animator.SetFloat(1116435161, Direction.back.vec2.y);
			windowTabs[2].gameObject.SetActive(Manager.saves.HasUnlockedSouls());
			UpdatePresetTabs();
		}
	}

	private void LateUpdate()
	{
		root.transform.localScale = Manager.ui.CalcGameplayUITargetScaleMultiplier();
	}

	public void Hide()
	{
		root.SetActive(value: false);
	}

	private void SetActiveTab(int tabIndex)
	{
		for (int i = 0; i < windowTabs.Count; i++)
		{
			windowTabs[i].SetActive(i == tabIndex);
		}
	}

	public void SetActivePreset(int tabIndex)
	{
		PlayerController player = Manager.main.player;
		if (!(player != null) || player.activeEquipmentPreset == tabIndex)
		{
			return;
		}
		player.SetActiveEquipmentPreset(tabIndex);
		for (int i = 0; i < presetTabs.Count; i++)
		{
			presetTabs[i].SetActive(i == tabIndex);
			if (i == tabIndex)
			{
				AudioManager.Sfx(SfxTableID.inventorySFXEquipmentTab, base.transform.position);
			}
		}
	}

	private void UpdatePresetTabs()
	{
		PlayerController player = Manager.main.player;
		if (player != null)
		{
			for (int i = 0; i < presetTabs.Count; i++)
			{
				presetTabs[i].SetActive(player.activeEquipmentPreset == i);
			}
		}
	}

	private void HideAllWindows()
	{
		equipmentInventory.gameObject.SetActive(value: false);
		skillsWindow.gameObject.SetActive(value: false);
		soulsWindow.gameObject.SetActive(value: false);
	}

	public void ShowEquipmentWindow(bool dontPlaySound = false)
	{
		if (!dontPlaySound)
		{
			AudioManager.Sfx(SfxTableID.inventorySFXCharacterTab, base.transform.position);
		}
		SetActiveTab(0);
		HideAllWindows();
		equipmentInventory.gameObject.SetActive(value: true);
	}

	public void ShowSkillsWindow()
	{
		SetActiveTab(1);
		HideAllWindows();
		skillsWindow.gameObject.SetActive(value: true);
		AudioManager.Sfx(SfxTableID.inventorySFXCharacterTab, Manager.main.player.transform.position);
	}

	public void ShowSoulsWindow()
	{
		SetActiveTab(2);
		HideAllWindows();
		soulsWindow.gameObject.SetActive(value: true);
		AudioManager.Sfx(SfxTableID.inventorySFXCharacterTab, Manager.main.player.transform.position);
	}

	public void ToggleStatsWindow()
	{
		statsWindow.gameObject.SetActive(!statsWindow.gameObject.activeSelf);
		AudioManager.Sfx(SfxTableID.inventorySFXInfoTab, Manager.main.player.transform.position);
	}

	public void HideStatsWindow()
	{
		statsWindow.gameObject.SetActive(value: false);
	}
}
