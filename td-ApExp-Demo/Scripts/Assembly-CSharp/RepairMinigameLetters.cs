using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class RepairMinigameLetters : RepairMinigame
{
	private int lettersRemaining;

	private Hotkey[] hotkeys;

	[SerializeField]
	private int maxLetterCount = 4;

	[SerializeField]
	private Sprite keyUp;

	[SerializeField]
	private Sprite keyDown;

	[NonSerialized]
	[HideInInspector]
	public int currentLetterCount;

	private HorizontalLayoutGroup layout;

	public override void Initialize()
	{
		layout = GetComponent<HorizontalLayoutGroup>();
		currentLetterCount = maxLetterCount;
		hotkeys = new Hotkey[maxLetterCount];
		for (int i = 0; i < base.transform.childCount; i++)
		{
			hotkeys[i] = base.transform.GetChild(i).GetComponent<Hotkey>();
		}
	}

	private void Update()
	{
	}

	private void ResetLetters(PlayerController player)
	{
		for (int i = 0; i < maxLetterCount; i++)
		{
			if (i >= currentLetterCount)
			{
				hotkeys[i].gameObject.SetActive(value: false);
				continue;
			}
			hotkeys[i].gameObject.SetActive(value: true);
			int num = UnityEngine.Random.Range(0, 4);
			hotkeys[i].InputActionRef = player.repairInputActionRefs[num];
			if (i == 0)
			{
				hotkeys[i].GetComponent<Outline>().SetOutline(isActive: true, Color.green);
			}
			else
			{
				hotkeys[i].GetComponent<Outline>().SetOutline(isActive: false, Color.white);
			}
			hotkeys[i].GetComponent<Image>().sprite = keyUp;
			hotkeys[i].arrowDirectionImg.enabled = true;
		}
	}

	public override void ResetMinigame(Interactor interactor)
	{
		base.ResetMinigame(interactor);
		lettersRemaining = 0;
		ResetLetters(interactor.playerController);
	}

	public override void SequencePress(Interactor interactor, InputActionReference inputActionRef)
	{
		if (Time.timeScale == 0f)
		{
			return;
		}
		Hotkey hotkey = hotkeys[lettersRemaining];
		if (lettersRemaining < currentLetterCount && inputActionRef == hotkey.InputActionRef)
		{
			hotkey.GetComponent<Outline>().SetOutline(isActive: false, Color.white);
			hotkey.GetComponent<Image>().sprite = keyDown;
			hotkey.arrowDirectionImg.enabled = false;
			if (lettersRemaining < currentLetterCount - 1)
			{
				hotkeys[lettersRemaining + 1].GetComponent<Outline>().SetOutline(isActive: true, Color.green);
			}
			lettersRemaining++;
			if (lettersRemaining == currentLetterCount)
			{
				MinigameComplete(interactor);
			}
		}
	}

	public override void OnMinigameUpgrade()
	{
		currentLetterCount = 3;
	}
}
