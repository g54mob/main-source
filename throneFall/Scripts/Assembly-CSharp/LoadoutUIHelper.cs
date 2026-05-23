using System.Collections.Generic;
using I2.Loc;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadoutUIHelper : MonoBehaviour
{
	public bool inMatch;

	public bool autoSelectPlay;

	public bool bufferLastLoadoutOnShow;

	public LocalGamestate.GameMode mode;

	public UIFrame frame;

	public TextMeshProUGUI perksText;

	public TextMeshProUGUI mutatorBonusText;

	public TextMeshProUGUI currentEternalTrialBalanceText;

	public ThronefallUIElement playButton;

	public GridLayoutGroup weaponsParent;

	public GridLayoutGroup perksParent;

	public GridLayoutGroup mutatorsParent;

	public TFUIEquippable equippableButtonPrefab;

	public Transform questsParent;

	public QuestEntry questEntryPrefab;

	public GameObject fixedLoadoutWarning;

	private List<TFUIEquippable> weapons = new List<TFUIEquippable>();

	private List<TFUIEquippable> perks = new List<TFUIEquippable>();

	private List<TFUIEquippable> mutators = new List<TFUIEquippable>();

	private List<TFUIEquippable> equippedWeapons = new List<TFUIEquippable>();

	private List<TFUIEquippable> equippedPerks = new List<TFUIEquippable>();

	private List<TFUIEquippable> equippedMutators = new List<TFUIEquippable>();

	private readonly int numberOfWeaponsAllowedToEquip = 1;

	private readonly int numberOfMutatiomsAllowedToEquip = 1000;

	private LevelData levelData;

	private LevelInfo levelInfo;

	private List<Equippable> lastLoadout = new List<Equippable>();

	private bool GetLevelData => mode == LocalGamestate.GameMode.Classic;

	private bool DrawQuests => mode == LocalGamestate.GameMode.Classic;

	private bool DrawMutators => mode == LocalGamestate.GameMode.Classic;

	private bool HasFixedLoadout
	{
		get
		{
			if (GetLevelData && levelInfo != null)
			{
				return levelInfo.HasFixedLoadout;
			}
			return false;
		}
	}

	private bool UnequipAllBesidesWeaponsOnStart => mode == LocalGamestate.GameMode.EternalTrial;

	public int LoadoutWorth => equippedPerks.Count;

	public void OnShow()
	{
		if (inMatch && MatchSaveLoadHandler.SaveLoadForbidden)
		{
			SceneTransitionManager.instance.RestartCurrentLevel();
			base.gameObject.SetActive(value: false);
			return;
		}
		if (GetLevelData)
		{
			if (inMatch)
			{
				levelData = LevelProgressManager.instance.GetLevelDataForActiveScene();
				levelInfo = LevelProgressManager.instance.GetLevelInfoFromCurrentSceneName();
			}
			else
			{
				levelData = LevelProgressManager.instance.GetLevelDataForScene(LevelInteractor.lastActiveLevelInfo.sceneName);
				levelInfo = LevelProgressManager.instance.GetLevelInfoFromSceneName(LevelInteractor.lastActiveLevelInfo.sceneName);
			}
		}
		if (fixedLoadoutWarning != null)
		{
			fixedLoadoutWarning.SetActive(levelInfo.HasFixedLoadout);
		}
		if (bufferLastLoadoutOnShow)
		{
			lastLoadout = new List<Equippable>(PerkManager.instance.CurrentlyEquipped.ToArray());
		}
		weapons.Clear();
		perks.Clear();
		mutators.Clear();
		equippedWeapons.Clear();
		equippedPerks.Clear();
		equippedMutators.Clear();
		foreach (Transform item in weaponsParent.transform)
		{
			Object.Destroy(item.gameObject);
		}
		foreach (Transform item2 in perksParent.transform)
		{
			Object.Destroy(item2.gameObject);
		}
		if (DrawMutators)
		{
			foreach (Transform item3 in mutatorsParent.transform)
			{
				Object.Destroy(item3.gameObject);
			}
		}
		foreach (Equippable allEquippable in PerkManager.instance.allEquippables)
		{
			if (allEquippable.IsUnlocked)
			{
				if (!DrawMutators && UnequipAllBesidesWeaponsOnStart && allEquippable is EquippableMutation)
				{
					PerkManager.SetEquipped(allEquippable, _equipped: false);
				}
				if (allEquippable is EquippableWeapon)
				{
					AddTFUIEquippable(weaponsParent, allEquippable);
				}
				else if (allEquippable is EquippablePerk)
				{
					AddTFUIEquippable(perksParent, allEquippable);
				}
				else if (allEquippable is EquippableMutation && DrawMutators)
				{
					AddTFUIEquippable(mutatorsParent, allEquippable);
				}
			}
		}
		foreach (Equippable allEquippable2 in PerkManager.instance.allEquippables)
		{
			if (!DrawMutators && UnequipAllBesidesWeaponsOnStart && allEquippable2 is EquippableMutation)
			{
				PerkManager.SetEquipped(allEquippable2, _equipped: false);
			}
			if (!allEquippable2.IsUnlocked)
			{
				if (PerkManager.IsEquipped(allEquippable2) && !levelInfo.fixedLoadout.Contains(allEquippable2))
				{
					PerkManager.SetEquipped(allEquippable2, _equipped: false);
				}
				if (allEquippable2 is EquippableWeapon)
				{
					AddTFUIEquippable(weaponsParent, allEquippable2);
				}
				else if (allEquippable2 is EquippablePerk)
				{
					AddTFUIEquippable(perksParent, allEquippable2);
				}
				else if (allEquippable2 is EquippableMutation && DrawMutators)
				{
					AddTFUIEquippable(mutatorsParent, allEquippable2);
				}
			}
		}
		if (equippedPerks.Count > levelInfo.maxPerkCount)
		{
			int num = equippedPerks.Count - levelInfo.maxPerkCount;
			int num2 = 0;
			for (int num3 = equippedPerks.Count - 1; num3 >= 0; num3--)
			{
				if (num2 < num)
				{
					TFUIEquippable tFUIEquippable = equippedPerks[num3];
					if (!HasFixedLoadout || !levelInfo.fixedLoadout.Contains(tFUIEquippable.Data))
					{
						PerkManager.SetEquipped(tFUIEquippable.Data, _equipped: false);
						tFUIEquippable.UnPick();
						equippedPerks.Remove(tFUIEquippable);
						num2++;
					}
				}
			}
			Debug.Log("Unequipped " + num2 + " excess perks.");
		}
		if (equippedWeapons.Count < 1 && !HasFixedLoadout)
		{
			PerkManager.SetEquipped(weapons[0].Data, _equipped: true);
			weapons[0].Pick();
			equippedWeapons.Add(weapons[0]);
		}
		RecomputeNavigation();
		UpdatePerkPointsRemainingText();
		if (DrawQuests)
		{
			RewriteQuestTexts();
		}
		if (DrawMutators)
		{
			UpdateMutatorBonusText();
		}
	}

	private void AddTFUIEquippable(GridLayoutGroup parent, Equippable e)
	{
		TFUIEquippable component = Object.Instantiate(equippableButtonPrefab, parent.transform).GetComponent<TFUIEquippable>();
		component.SetData(e, HasFixedLoadout, overrideShow: false, levelInfo);
		if (PerkManager.IsEquipped(e))
		{
			bool flag = HasFixedLoadout && !levelInfo.fixedLoadout.Contains(e);
			if (UnequipAllBesidesWeaponsOnStart && !(e is EquippableWeapon))
			{
				flag = true;
			}
			if (flag)
			{
				PerkManager.SetEquipped(e, _equipped: false);
			}
			else
			{
				component.Pick();
				if (e is EquippableWeapon)
				{
					equippedWeapons.Add(component);
				}
				if (e is EquippablePerk)
				{
					equippedPerks.Add(component);
				}
				if (e is EquippableMutation)
				{
					equippedMutators.Add(component);
				}
			}
		}
		else if (HasFixedLoadout && levelInfo.fixedLoadout.Contains(e))
		{
			PerkManager.SetEquipped(e, _equipped: true);
			component.Pick();
			if (e is EquippableWeapon)
			{
				equippedWeapons.Add(component);
			}
			if (e is EquippablePerk)
			{
				equippedPerks.Add(component);
			}
			if (e is EquippableMutation)
			{
				equippedMutators.Add(component);
			}
		}
		if (parent == weaponsParent)
		{
			weapons.Add(component);
		}
		else if (parent == perksParent)
		{
			perks.Add(component);
		}
		else if (parent == mutatorsParent)
		{
			mutators.Add(component);
		}
	}

	public void TrySelectEquippableForLoadout()
	{
		TFUIEquippable tFUIEquippable = frame.LastApplied as TFUIEquippable;
		if (tFUIEquippable == null || tFUIEquippable.Locked || HasFixedLoadout)
		{
			return;
		}
		if (tFUIEquippable.Data is EquippableWeapon)
		{
			for (int num = equippedWeapons.Count - 1; num >= 0; num--)
			{
				PerkManager.SetEquipped(equippedWeapons[num].Data, _equipped: false);
				equippedWeapons[num].UnPick();
				equippedWeapons.Remove(equippedWeapons[num]);
			}
			tFUIEquippable.Pick();
			PerkManager.SetEquipped(tFUIEquippable.Data, _equipped: true);
			equippedWeapons.Add(tFUIEquippable);
		}
		if (tFUIEquippable.Data is EquippablePerk)
		{
			List<TFUIEquippable> list = new List<TFUIEquippable>();
			int num2 = 0;
			for (int num3 = equippedPerks.Count - 1; num3 >= 0; num3--)
			{
				if (equippedPerks[num3] != tFUIEquippable)
				{
					num2++;
				}
				if (num2 >= levelInfo.maxPerkCount)
				{
					list.Add(equippedPerks[num3]);
				}
			}
			foreach (TFUIEquippable item in list)
			{
				PerkManager.SetEquipped(item.Data, _equipped: false);
				item.UnPick();
				equippedPerks.Remove(item);
			}
			if (equippedPerks.Contains(tFUIEquippable))
			{
				tFUIEquippable.UnPick();
				PerkManager.SetEquipped(tFUIEquippable.Data, _equipped: false);
				equippedPerks.Remove(tFUIEquippable);
			}
			else
			{
				tFUIEquippable.Pick();
				PerkManager.SetEquipped(tFUIEquippable.Data, _equipped: true);
				equippedPerks.Add(tFUIEquippable);
			}
		}
		if (tFUIEquippable.Data is EquippableMutation)
		{
			if (equippedMutators.Contains(tFUIEquippable))
			{
				tFUIEquippable.UnPick();
				PerkManager.SetEquipped(tFUIEquippable.Data, _equipped: false);
				equippedMutators.Remove(tFUIEquippable);
			}
			else
			{
				tFUIEquippable.Pick();
				PerkManager.SetEquipped(tFUIEquippable.Data, _equipped: true);
				equippedMutators.Add(tFUIEquippable);
			}
		}
		UpdatePerkPointsRemainingText();
		if (DrawMutators)
		{
			UpdateMutatorBonusText();
		}
	}

	private void RecomputeNavigation()
	{
		int constraintCount = weaponsParent.constraintCount;
		if (DrawMutators)
		{
			AssignNavigationTargets(weapons, playButton, null, null, perks, constraintCount);
			AssignNavigationTargets(perks, null, weapons, null, mutators, constraintCount);
			AssignNavigationTargets(mutators, null, perks, playButton, null, constraintCount);
			playButton.topNav = mutators[mutators.Count - 1];
			playButton.leftNav = mutators[mutators.Count - 1];
		}
		else
		{
			AssignNavigationTargets(weapons, playButton, null, null, perks, constraintCount);
			AssignNavigationTargets(perks, null, weapons, playButton, null, constraintCount);
			playButton.topNav = perks[perks.Count - 1];
			playButton.leftNav = perks[perks.Count - 1];
		}
		playButton.botNav = weapons[0];
		playButton.rightNav = weapons[0];
		if (!autoSelectPlay)
		{
			GetComponent<UIFrame>().firstSelected = weapons[0];
		}
	}

	private void RewriteQuestTexts()
	{
		if (!DrawQuests)
		{
			return;
		}
		for (int num = questsParent.childCount - 1; num >= 0; num--)
		{
			Object.Destroy(questsParent.GetChild(num).gameObject);
		}
		int num2 = 0;
		LevelInfo levelInfo = null;
		if (LevelInteractor.lastActiveLevelInfo != null)
		{
			levelInfo = LevelInteractor.lastActiveLevelInfo;
		}
		if (levelInfo == null)
		{
			levelInfo = LevelProgressManager.instance.GetLevelInfoFromSceneName(SceneManager.GetActiveScene().name);
		}
		if (!(levelInfo != null))
		{
			return;
		}
		foreach (Quest quest in levelInfo.quests)
		{
			Object.Instantiate(questEntryPrefab, questsParent).Init(quest, num2, quest.CheckBeaten(levelInfo.LevelData));
			num2++;
		}
	}

	private void UpdatePerkPointsRemainingText()
	{
		if (HasFixedLoadout || mode == LocalGamestate.GameMode.EternalTrial)
		{
			perksText.text = TextTranslator.Translate("Menu/Perks");
		}
		else
		{
			perksText.text = TextTranslator.Translate("Menu/Perks") + " (" + equippedPerks.Count + "/" + levelInfo.maxPerkCount + ")";
		}
		if (mode == LocalGamestate.GameMode.EternalTrial)
		{
			currentEternalTrialBalanceText.gameObject.SetActive(value: true);
		}
		else if (currentEternalTrialBalanceText != null)
		{
			currentEternalTrialBalanceText.gameObject.SetActive(value: false);
		}
	}

	private void UpdateMutatorBonusText()
	{
		if (!DrawMutators)
		{
			return;
		}
		if (equippedMutators.Count > 0)
		{
			mutatorBonusText.gameObject.SetActive(value: true);
			float num = 1f;
			foreach (TFUIEquippable equippedMutator in equippedMutators)
			{
				EquippableMutation equippableMutation = equippedMutator.Data as EquippableMutation;
				if (!(equippableMutation == null))
				{
					num *= equippableMutation.scoreMultiplyerOnWin;
				}
			}
			num -= 1f;
			num *= 100f;
			string text = "";
			if (num >= 0f)
			{
				text += "+";
			}
			text = text + num.ToString("F0") + "%";
			mutatorBonusText.text = LocalizationManager.GetTermTranslation("Menu/Mutator Bonus Preview") + ": <style=Body Bold>" + text;
		}
		else
		{
			mutatorBonusText.gameObject.SetActive(value: false);
		}
	}

	private void AssignNavigationTargets(List<TFUIEquippable> targetElements, ThronefallUIElement aboveElement, List<TFUIEquippable> aboveList, ThronefallUIElement belowElement, List<TFUIEquippable> belowList, int maxColumns)
	{
		for (int i = 0; i < targetElements.Count; i++)
		{
			TFUIEquippable tFUIEquippable = targetElements[i];
			int num = i - 1;
			int num2 = i + 1;
			int num3 = i + maxColumns;
			int num4 = i - maxColumns;
			if (num < 0)
			{
				if (aboveElement != null)
				{
					tFUIEquippable.leftNav = aboveElement;
				}
				else
				{
					tFUIEquippable.leftNav = aboveList[aboveList.Count - 1];
				}
			}
			else
			{
				tFUIEquippable.leftNav = targetElements[num];
			}
			if (num2 >= targetElements.Count)
			{
				if (belowElement != null)
				{
					tFUIEquippable.rightNav = belowElement;
				}
				else
				{
					tFUIEquippable.rightNav = belowList[0];
				}
			}
			else
			{
				tFUIEquippable.rightNav = targetElements[num2];
			}
			if (num3 >= targetElements.Count)
			{
				if ((targetElements.Count % maxColumns != 0 || targetElements.Count - i > maxColumns) && targetElements.Count - i > targetElements.Count % maxColumns)
				{
					tFUIEquippable.botNav = targetElements[targetElements.Count - 1];
				}
				else if (belowElement != null)
				{
					tFUIEquippable.botNav = belowElement;
				}
				else
				{
					int num5 = i % maxColumns;
					if (belowList.Count < num5)
					{
						tFUIEquippable.botNav = belowList[belowList.Count - 1];
					}
					else
					{
						tFUIEquippable.botNav = belowList[num5];
					}
				}
			}
			else
			{
				tFUIEquippable.botNav = targetElements[num3];
			}
			if (num4 < 0)
			{
				if (aboveElement != null)
				{
					tFUIEquippable.topNav = aboveElement;
					continue;
				}
				int num6 = i % maxColumns;
				int num7 = aboveList.Count % maxColumns;
				if (num6 > num7)
				{
					tFUIEquippable.topNav = aboveList[aboveList.Count - 1];
					continue;
				}
				int value = aboveList.Count - num7 + num6;
				value = Mathf.Clamp(value, 0, aboveList.Count - 1);
				tFUIEquippable.topNav = aboveList[value];
			}
			else
			{
				tFUIEquippable.topNav = targetElements[num4];
			}
		}
	}

	public void ResetToBufferedLoadout()
	{
		foreach (Equippable item in new List<Equippable>(PerkManager.instance.CurrentlyEquipped.ToArray()))
		{
			PerkManager.SetEquipped(item, _equipped: false);
		}
		foreach (Equippable item2 in lastLoadout)
		{
			PerkManager.SetEquipped(item2, _equipped: true);
		}
	}
}
