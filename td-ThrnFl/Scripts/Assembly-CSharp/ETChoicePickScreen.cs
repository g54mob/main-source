using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ETChoicePickScreen : MonoBehaviour
{
	public UIFrame targetFrame;

	public ETMapChoiceDisplay displayPrefab;

	public EternalTrialsMapPreview mapPreviewTT;

	public GameObject tooltipObject;

	public Transform choicesParent;

	public Transform currentLoadoutParent;

	public GameObject noLoadoutYet;

	public TextMeshProUGUI currentLevelDisplay;

	public TFUIEquippable perkTFUIPrefab;

	private ETMapChoiceDisplay selectedChoice;

	private ETMapChoiceDisplay[] choicesUIDisplays;

	private TFUIEquippable[] currentLoadoutTFUIs;

	private void Start()
	{
		targetFrame.onNewFocus.AddListener(OnTargetFrameFocusChange);
		targetFrame.onNewSelection.AddListener(OnTargetFrameSelectionChange);
	}

	private void Update()
	{
	}

	public void CheckForPerkDisable()
	{
		if (targetFrame.CurrentSelection == null)
		{
			return;
		}
		TFUIEquippable component = targetFrame.CurrentSelection.GetComponent<TFUIEquippable>();
		if (!component)
		{
			return;
		}
		EquippablePerk equippablePerk = component.Data as EquippablePerk;
		if ((bool)equippablePerk)
		{
			if (EternalTrialsRunManager.CurrentRun.disabledPerks.Contains(equippablePerk))
			{
				EternalTrialsRunManager.CurrentRun.disabledPerks.Remove(equippablePerk);
			}
			else
			{
				EternalTrialsRunManager.CurrentRun.disabledPerks.Add(equippablePerk);
			}
			component.SetDataEternalTrials(equippablePerk);
			component.HardStateSet(ThronefallUIElement.SelectionState.Selected);
			component.Pick();
		}
	}

	public void Activate()
	{
		foreach (Transform item in choicesParent)
		{
			Object.Destroy(item.gameObject);
		}
		MapChoice[] mapChoices = EternalTrialsRunManager.GetMapChoices();
		choicesUIDisplays = new ETMapChoiceDisplay[mapChoices.Length];
		for (int i = 0; i < mapChoices.Length; i++)
		{
			ETMapChoiceDisplay eTMapChoiceDisplay = Object.Instantiate(displayPrefab, choicesParent);
			eTMapChoiceDisplay.SetData(mapChoices[i], this);
			choicesUIDisplays[i] = eTMapChoiceDisplay;
		}
		InitializeChoiceSelection();
		string text = "<style=Body Bold>" + TextTranslator.Translate("Menu/Stage") + "<style=Body Numerals> " + (EternalTrialsRunManager.CurrentRun.stage + 1);
		currentLevelDisplay.text = text;
		foreach (Transform item2 in currentLoadoutParent)
		{
			Object.Destroy(item2.gameObject);
		}
		EquippablePerk[] array = EternalTrialsRunManager.CurrentRun.acquiredPerks.ToArray();
		currentLoadoutTFUIs = new TFUIEquippable[array.Length];
		noLoadoutYet.SetActive(array.Length == 0);
		for (int j = 0; j < array.Length; j++)
		{
			currentLoadoutTFUIs[j] = Object.Instantiate(perkTFUIPrefab, currentLoadoutParent);
			currentLoadoutTFUIs[j].SetDataEternalTrials(array[j]);
			currentLoadoutTFUIs[j].Pick();
		}
		RecomputeAllNavigation();
	}

	public void ConfirmChoice(MapChoice choice)
	{
		EternalTrialsRunManager.ConfirmChoice(choice);
		EternalTrialsRunManager.LoadNextMap();
	}

	private void InitializeChoiceSelection()
	{
		if (choicesUIDisplays.Length == 3)
		{
			SelectNewChoice(choicesUIDisplays[1], autoSelectPlayButton: false, makePlayButtonUIFrameDefaultSelection: true);
		}
		else
		{
			SelectNewChoice(choicesUIDisplays[0], autoSelectPlayButton: false, makePlayButtonUIFrameDefaultSelection: true);
		}
	}

	private void SelectNewChoice(ETMapChoiceDisplay newChoice, bool autoSelectPlayButton, bool makePlayButtonUIFrameDefaultSelection = false)
	{
		selectedChoice = newChoice;
		ETMapChoiceDisplay[] array = choicesUIDisplays;
		foreach (ETMapChoiceDisplay eTMapChoiceDisplay in array)
		{
			if (eTMapChoiceDisplay != selectedChoice)
			{
				eTMapChoiceDisplay.Unselect();
			}
		}
		selectedChoice.Select();
		if (autoSelectPlayButton)
		{
			targetFrame.Select(selectedChoice.confirmButton);
		}
		if (makePlayButtonUIFrameDefaultSelection)
		{
			targetFrame.firstSelected = selectedChoice.confirmButton;
		}
		RecomputeCurrentLoadoutTFUINavigation();
		mapPreviewTT.SetData(newChoice.Data.waveInfos, newChoice.Data.goldAtStart);
		targetFrame.RefetchManagedElements();
	}

	private void OnTargetFrameFocusChange()
	{
		if (!(targetFrame.CurrentFocus == null))
		{
			ETMapChoiceDisplay componentInParent = targetFrame.CurrentFocus.GetComponentInParent<ETMapChoiceDisplay>();
			if (!(componentInParent == null) && componentInParent != selectedChoice)
			{
				SelectNewChoice(componentInParent, !(targetFrame.CurrentFocus is TFUIEquippable));
			}
		}
	}

	private void OnTargetFrameSelectionChange()
	{
		if (!(targetFrame.CurrentSelection == null))
		{
			ETMapChoiceDisplay componentInParent = targetFrame.CurrentSelection.GetComponentInParent<ETMapChoiceDisplay>();
			if (!(componentInParent == null) && componentInParent != selectedChoice)
			{
				SelectNewChoice(componentInParent, !(targetFrame.CurrentSelection is TFUIEquippable));
			}
		}
	}

	private void RecomputeAllNavigation()
	{
		List<ETMapChoiceDisplay> list = new List<ETMapChoiceDisplay>();
		ETMapChoiceDisplay[] array = choicesUIDisplays;
		foreach (ETMapChoiceDisplay eTMapChoiceDisplay in array)
		{
			if (eTMapChoiceDisplay.currentPerkTFUIs.Length != 0)
			{
				list.Add(eTMapChoiceDisplay);
			}
		}
		for (int j = 0; j < choicesUIDisplays.Length; j++)
		{
			ETMapChoiceDisplay eTMapChoiceDisplay2 = choicesUIDisplays[j];
			for (int k = 0; k < eTMapChoiceDisplay2.currentPerkTFUIs.Length; k++)
			{
				if (eTMapChoiceDisplay2.currentPerkTFUIs.Length == 0)
				{
					break;
				}
				eTMapChoiceDisplay2.currentPerkTFUIs[k].leftNav = eTMapChoiceDisplay2.weapon;
				eTMapChoiceDisplay2.currentPerkTFUIs[k].rightNav = eTMapChoiceDisplay2.confirmButton;
				if (k == 0)
				{
					if (j == 0)
					{
						if (currentLoadoutTFUIs.Length != 0)
						{
							eTMapChoiceDisplay2.currentPerkTFUIs[k].topNav = currentLoadoutTFUIs[currentLoadoutTFUIs.Length - 1];
						}
						else
						{
							eTMapChoiceDisplay2.currentPerkTFUIs[k].topNav = choicesUIDisplays[choicesUIDisplays.Length - 1].currentPerkTFUIs[choicesUIDisplays[choicesUIDisplays.Length - 1].currentPerkTFUIs.Length - 1];
						}
					}
					else
					{
						eTMapChoiceDisplay2.currentPerkTFUIs[k].topNav = choicesUIDisplays[j - 1].currentPerkTFUIs[choicesUIDisplays[j - 1].currentPerkTFUIs.Length - 1];
					}
				}
				else
				{
					eTMapChoiceDisplay2.currentPerkTFUIs[k].topNav = eTMapChoiceDisplay2.currentPerkTFUIs[k - 1];
				}
				if (k == eTMapChoiceDisplay2.currentPerkTFUIs.Length - 1)
				{
					if (j == choicesUIDisplays.Length - 1)
					{
						if (currentLoadoutTFUIs.Length != 0)
						{
							eTMapChoiceDisplay2.currentPerkTFUIs[k].botNav = currentLoadoutTFUIs[currentLoadoutTFUIs.Length - 1];
						}
						else
						{
							eTMapChoiceDisplay2.currentPerkTFUIs[k].botNav = choicesUIDisplays[0].currentPerkTFUIs[0];
						}
					}
					else
					{
						eTMapChoiceDisplay2.currentPerkTFUIs[k].botNav = choicesUIDisplays[j + 1].currentPerkTFUIs[0];
					}
				}
				else
				{
					eTMapChoiceDisplay2.currentPerkTFUIs[k].botNav = eTMapChoiceDisplay2.currentPerkTFUIs[k + 1];
				}
				eTMapChoiceDisplay2.currentPerkTFUIs[k].forceNavigateToDisabledElements = true;
			}
			if (j == 0)
			{
				if (currentLoadoutTFUIs.Length != 0)
				{
					eTMapChoiceDisplay2.weapon.topNav = currentLoadoutTFUIs[currentLoadoutTFUIs.Length - 1];
				}
				else
				{
					eTMapChoiceDisplay2.weapon.topNav = choicesUIDisplays[choicesUIDisplays.Length - 1].weapon;
				}
				eTMapChoiceDisplay2.weapon.botNav = choicesUIDisplays[j + 1].weapon;
			}
			else if (j == choicesUIDisplays.Length - 1)
			{
				if (currentLoadoutTFUIs.Length != 0)
				{
					eTMapChoiceDisplay2.weapon.botNav = currentLoadoutTFUIs[currentLoadoutTFUIs.Length - 1];
				}
				else
				{
					eTMapChoiceDisplay2.weapon.botNav = choicesUIDisplays[0].weapon;
				}
				eTMapChoiceDisplay2.weapon.topNav = choicesUIDisplays[j - 1].weapon;
			}
			else
			{
				eTMapChoiceDisplay2.weapon.topNav = choicesUIDisplays[j - 1].weapon;
				eTMapChoiceDisplay2.weapon.botNav = choicesUIDisplays[j + 1].weapon;
			}
			if (eTMapChoiceDisplay2.currentPerkTFUIs.Length != 0)
			{
				eTMapChoiceDisplay2.weapon.leftNav = eTMapChoiceDisplay2.confirmButton;
				eTMapChoiceDisplay2.weapon.rightNav = eTMapChoiceDisplay2.currentPerkTFUIs[eTMapChoiceDisplay2.currentPerkTFUIs.Length - 1];
			}
			else
			{
				eTMapChoiceDisplay2.weapon.rightNav = eTMapChoiceDisplay2.confirmButton;
				eTMapChoiceDisplay2.weapon.leftNav = eTMapChoiceDisplay2.confirmButton;
			}
			if (j == 0)
			{
				if (currentLoadoutTFUIs.Length != 0)
				{
					eTMapChoiceDisplay2.confirmButton.topNav = currentLoadoutTFUIs[currentLoadoutTFUIs.Length - 1];
				}
				else
				{
					eTMapChoiceDisplay2.confirmButton.topNav = choicesUIDisplays[choicesUIDisplays.Length - 1].confirmButton;
				}
			}
			else
			{
				eTMapChoiceDisplay2.confirmButton.topNav = choicesUIDisplays[j - 1].confirmButton;
			}
			if (j == choicesUIDisplays.Length - 1)
			{
				if (currentLoadoutTFUIs.Length != 0)
				{
					eTMapChoiceDisplay2.confirmButton.botNav = currentLoadoutTFUIs[currentLoadoutTFUIs.Length - 1];
				}
				else
				{
					eTMapChoiceDisplay2.confirmButton.botNav = choicesUIDisplays[0].confirmButton;
				}
			}
			else
			{
				eTMapChoiceDisplay2.confirmButton.botNav = choicesUIDisplays[j + 1].confirmButton;
			}
			if (eTMapChoiceDisplay2.currentPerkTFUIs.Length != 0)
			{
				eTMapChoiceDisplay2.confirmButton.leftNav = eTMapChoiceDisplay2.currentPerkTFUIs[0];
			}
			else
			{
				eTMapChoiceDisplay2.confirmButton.leftNav = eTMapChoiceDisplay2.weapon;
			}
			eTMapChoiceDisplay2.confirmButton.rightNav = eTMapChoiceDisplay2.weapon;
			eTMapChoiceDisplay2.weapon.forceNavigateToDisabledElements = true;
			eTMapChoiceDisplay2.confirmButton.forceNavigateToDisabledElements = true;
		}
		RecomputeCurrentLoadoutTFUINavigation();
	}

	private void RecomputeCurrentLoadoutTFUINavigation()
	{
		if (currentLoadoutTFUIs == null || currentLoadoutTFUIs.Length == 0)
		{
			return;
		}
		for (int i = 0; i < currentLoadoutTFUIs.Length; i++)
		{
			if (i == 0)
			{
				currentLoadoutTFUIs[i].rightNav = currentLoadoutTFUIs[currentLoadoutTFUIs.Length - 1];
			}
			else
			{
				currentLoadoutTFUIs[i].rightNav = currentLoadoutTFUIs[i - 1];
			}
			if (i == currentLoadoutTFUIs.Length - 1)
			{
				currentLoadoutTFUIs[i].leftNav = currentLoadoutTFUIs[0];
			}
			else
			{
				currentLoadoutTFUIs[i].leftNav = currentLoadoutTFUIs[i + 1];
			}
			currentLoadoutTFUIs[i].topNav = choicesUIDisplays[choicesUIDisplays.Length - 1].confirmButton;
			currentLoadoutTFUIs[i].botNav = choicesUIDisplays[0].confirmButton;
			currentLoadoutTFUIs[i].forceNavigateToDisabledElements = true;
		}
	}
}
