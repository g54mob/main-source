using System;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Localization.Settings;

public class SpeechBubbleConditionChecker : MonoBehaviour
{
	public enum SpeechBubbleType
	{
		SunBeams = 0,
		StarPipe = 1,
		StarWand = 2,
		Hammer = 3,
		Broom = 4,
		Vacuum = 5,
		Bubble = 6,
		BasicControls = 7,
		MiscIgnore = 8,
		Ability_BerryBlitz = 9,
		Ability_BigHole = 10,
		HoleMovement = 11,
		HoldEToPickUpMultipleCoins = 12,
		PopGun = 13,
		Chainsaw = 14
	}

	[SerializeField]
	private bool showAfterRewinds;

	[SerializeField]
	private bool hideAtNight;

	private TMP_Text bubbleText;

	public SpeechBubbleType speechBubbleType;

	private bool hasCheckedRequirement;

	private void Awake()
	{
		bubbleText = base.gameObject.GetComponentInChildren<TMP_Text>();
	}

	private void Start()
	{
		if (hideAtNight)
		{
			GameManager singleton = GameManager.Singleton;
			singleton.OnNightTime_Action = (Action)Delegate.Combine(singleton.OnNightTime_Action, new Action(HideAtNight));
		}
	}

	private void OnDestroy()
	{
		if (hideAtNight)
		{
			GameManager singleton = GameManager.Singleton;
			singleton.OnNightTime_Action = (Action)Delegate.Remove(singleton.OnNightTime_Action, new Action(HideAtNight));
		}
	}

	private void HideAtNight()
	{
		base.gameObject.SetActive(value: false);
	}

	private void Update()
	{
		if (!hasCheckedRequirement && GameManager.Singleton.gameState == GameManager.GameState.Playing)
		{
			CheckRequirementAndHideAccordingly();
			hasCheckedRequirement = true;
		}
	}

	public void CheckRequirementAndHideAccordingly()
	{
		if (PlayerStats.Singleton.rewind_TimesUsed > 0 && !showAfterRewinds)
		{
			try
			{
				GameManager.Singleton.SetMilestoneFlagToFalse(GetComponent<PickUppable>());
			}
			catch
			{
				Debug.Log("FAILED TO GET PICKUP SCRIPT FROM THIS SPEECHBUBBLE?");
			}
			base.gameObject.SetActive(value: false);
			return;
		}
		switch (speechBubbleType)
		{
		case SpeechBubbleType.SunBeams:
			if (PlayerStats.Singleton.totalRounds > 1)
			{
				return;
			}
			break;
		case SpeechBubbleType.StarPipe:
			if (PlayerStats.Singleton.starOrbGen_IsUnlocked)
			{
				return;
			}
			break;
		case SpeechBubbleType.StarWand:
			if (PlayerStats.Singleton.StarWand_Unlocked)
			{
				return;
			}
			break;
		case SpeechBubbleType.Hammer:
			if (PlayerStats.Singleton.SledgeHammer_Unlocked)
			{
				return;
			}
			break;
		case SpeechBubbleType.Broom:
		{
			string text5 = "";
			text5 = ((InputManager.Singleton.lastUsedControllerType != InputManager.ControllerType.keyboard) ? InputManager.Singleton.inputActions.PlayerActionMap.AirBlast.GetBindingDisplayString(1) : GetLocalizedBindingString_KeyboardOnly(InputManager.Singleton.inputActions.PlayerActionMap.AirBlast));
			string[] arguments = new string[1] { text5 };
			TMP_Text tMP_Text4 = bubbleText;
			string text2 = (bubbleText.text = LocalizationSettings.StringDatabase.GetLocalizedStringAsync("SpeechBubble_AirBlast", arguments).Result);
			tMP_Text4.text = text2;
			if (PlayerStats.Singleton.broom_Unlocked)
			{
				return;
			}
			break;
		}
		case SpeechBubbleType.Vacuum:
		{
			string text11 = "";
			text11 = ((InputManager.Singleton.lastUsedControllerType != InputManager.ControllerType.keyboard) ? InputManager.Singleton.inputActions.PlayerActionMap.PickUpAndUse.GetBindingDisplayString(1) : GetLocalizedBindingString_KeyboardOnly(InputManager.Singleton.inputActions.PlayerActionMap.PickUpAndUse));
			string text12 = "";
			text12 = ((InputManager.Singleton.lastUsedControllerType != InputManager.ControllerType.keyboard) ? InputManager.Singleton.inputActions.PlayerActionMap.Throw.GetBindingDisplayString(1) : GetLocalizedBindingString_KeyboardOnly(InputManager.Singleton.inputActions.PlayerActionMap.Throw));
			string[] arguments = new string[2] { text11, text12 };
			TMP_Text tMP_Text7 = bubbleText;
			string text2 = (bubbleText.text = LocalizationSettings.StringDatabase.GetLocalizedStringAsync("SpeechBubble_VacuumSuck", arguments).Result);
			tMP_Text7.text = text2;
			if (PlayerStats.Singleton.vacuum_Unlocked)
			{
				return;
			}
			break;
		}
		case SpeechBubbleType.Bubble:
		{
			string text3 = "";
			text3 = ((InputManager.Singleton.lastUsedControllerType != InputManager.ControllerType.keyboard) ? InputManager.Singleton.inputActions.PlayerActionMap.Jump.GetBindingDisplayString(1) : GetLocalizedBindingString_KeyboardOnly(InputManager.Singleton.inputActions.PlayerActionMap.Jump));
			string[] arguments = new string[1] { text3 };
			TMP_Text tMP_Text2 = bubbleText;
			string text2 = (bubbleText.text = LocalizationSettings.StringDatabase.GetLocalizedStringAsync("SpeechBubble_Bubble", arguments).Result);
			tMP_Text2.text = text2;
			if (PlayerStats.Singleton.bubbleJetpack_Unlocked)
			{
				return;
			}
			break;
		}
		case SpeechBubbleType.BasicControls:
		{
			string text8 = "";
			text8 = ((InputManager.Singleton.lastUsedControllerType != InputManager.ControllerType.keyboard) ? InputManager.Singleton.inputActions.PlayerActionMap.PickUpAndUse.GetBindingDisplayString(1) : GetLocalizedBindingString_KeyboardOnly(InputManager.Singleton.inputActions.PlayerActionMap.PickUpAndUse));
			string text9 = "";
			text9 = ((InputManager.Singleton.lastUsedControllerType != InputManager.ControllerType.keyboard) ? InputManager.Singleton.inputActions.PlayerActionMap.Throw.GetBindingDisplayString(1) : GetLocalizedBindingString_KeyboardOnly(InputManager.Singleton.inputActions.PlayerActionMap.Throw));
			string text10 = "";
			text10 = ((InputManager.Singleton.lastUsedControllerType != InputManager.ControllerType.keyboard) ? InputManager.Singleton.inputActions.PlayerActionMap.Drop.GetBindingDisplayString(1) : GetLocalizedBindingString_KeyboardOnly(InputManager.Singleton.inputActions.PlayerActionMap.Drop));
			string[] arguments = new string[3] { text8, text9, text10 };
			bubbleText.text = LocalizationSettings.StringDatabase.GetLocalizedStringAsync("SpeechBubble_PickUpAndThrow", arguments).Result;
			return;
		}
		case SpeechBubbleType.MiscIgnore:
			return;
		case SpeechBubbleType.Ability_BerryBlitz:
		{
			string text6 = "";
			text6 = ((InputManager.Singleton.lastUsedControllerType != InputManager.ControllerType.keyboard) ? InputManager.Singleton.inputActions.PlayerActionMap.BerryBlitz.GetBindingDisplayString(1) : GetLocalizedBindingString_KeyboardOnly(InputManager.Singleton.inputActions.PlayerActionMap.BerryBlitz));
			string[] arguments = new string[1] { text6 };
			TMP_Text tMP_Text5 = bubbleText;
			string text2 = (bubbleText.text = LocalizationSettings.StringDatabase.GetLocalizedStringAsync("SpeechBubble_BerryBlitz", arguments).Result);
			tMP_Text5.text = text2;
			if (PlayerStats.Singleton.goldRush_Unlocked)
			{
				return;
			}
			break;
		}
		case SpeechBubbleType.Ability_BigHole:
		{
			string text13 = "";
			text13 = ((InputManager.Singleton.lastUsedControllerType != InputManager.ControllerType.keyboard) ? InputManager.Singleton.inputActions.PlayerActionMap.GapingMaw.GetBindingDisplayString(1) : GetLocalizedBindingString_KeyboardOnly(InputManager.Singleton.inputActions.PlayerActionMap.GapingMaw));
			string[] arguments = new string[1] { text13 };
			TMP_Text tMP_Text8 = bubbleText;
			string text2 = (bubbleText.text = LocalizationSettings.StringDatabase.GetLocalizedStringAsync("SpeechBubble_BigHole", arguments).Result);
			tMP_Text8.text = text2;
			if (PlayerStats.Singleton.bigHole_Unlocked)
			{
				return;
			}
			break;
		}
		case SpeechBubbleType.HoleMovement:
		{
			string text7 = "";
			text7 = ((InputManager.Singleton.lastUsedControllerType != InputManager.ControllerType.keyboard) ? InputManager.Singleton.inputActions.PlayerActionMap.MoveHole.GetBindingDisplayString(1) : GetLocalizedBindingString_KeyboardOnly(InputManager.Singleton.inputActions.PlayerActionMap.MoveHole));
			string[] arguments = new string[1] { text7 };
			TMP_Text tMP_Text6 = bubbleText;
			string text2 = (bubbleText.text = LocalizationSettings.StringDatabase.GetLocalizedStringAsync("SpeechBubble_HoleMove", arguments).Result);
			tMP_Text6.text = text2;
			if (PlayerStats.Singleton.holeMove_IsUnlocked)
			{
				return;
			}
			break;
		}
		case SpeechBubbleType.HoldEToPickUpMultipleCoins:
		{
			string text4 = "";
			text4 = ((InputManager.Singleton.lastUsedControllerType != InputManager.ControllerType.keyboard) ? InputManager.Singleton.inputActions.PlayerActionMap.PickUpAndUse.GetBindingDisplayString(1) : GetLocalizedBindingString_KeyboardOnly(InputManager.Singleton.inputActions.PlayerActionMap.PickUpAndUse));
			string[] arguments = new string[1] { text4 };
			TMP_Text tMP_Text3 = bubbleText;
			string text2 = (bubbleText.text = LocalizationSettings.StringDatabase.GetLocalizedStringAsync("SpeechBubble_HoldEToPickUpMultipleCoins", arguments).Result);
			tMP_Text3.text = text2;
			return;
		}
		case SpeechBubbleType.PopGun:
		{
			string text = "";
			text = ((InputManager.Singleton.lastUsedControllerType != InputManager.ControllerType.keyboard) ? InputManager.Singleton.inputActions.PlayerActionMap.Throw.GetBindingDisplayString(1) : GetLocalizedBindingString_KeyboardOnly(InputManager.Singleton.inputActions.PlayerActionMap.Throw));
			string[] arguments = new string[1] { text };
			TMP_Text tMP_Text = bubbleText;
			string text2 = (bubbleText.text = LocalizationSettings.StringDatabase.GetLocalizedStringAsync("SpeechBubble_PopGun", arguments).Result);
			tMP_Text.text = text2;
			if (PlayerStats.Singleton.popgun_Unlocked)
			{
				return;
			}
			break;
		}
		case SpeechBubbleType.Chainsaw:
			if (PlayerStats.Singleton.blenderBot_Unlocked)
			{
				return;
			}
			break;
		}
		base.gameObject.SetActive(value: false);
	}

	public string GetLocalizedBindingString_KeyboardOnly(InputAction action)
	{
		string bindingDisplayString = action.GetBindingDisplayString(0);
		string stringFromTable = LocTableHelpers.GetStringFromTable("binding_" + bindingDisplayString.ToLower().Replace(" ", "_"));
		if (stringFromTable == "NOK")
		{
			return bindingDisplayString;
		}
		return stringFromTable;
	}
}
