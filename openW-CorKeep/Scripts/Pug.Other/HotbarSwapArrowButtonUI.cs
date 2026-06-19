using System.Collections.Generic;
using Rewired;
using UnityEngine;

public class HotbarSwapArrowButtonUI : ButtonUIElement
{
	public bool isUpArrow;

	private const string SWAP_NEXT_HOTBAR_STRING = "SwapNextHotbarPC";

	private const string SWAP_PREVIOUS_HOTBAR_STRING = "SwapPreviousHotbarPC";

	private const string SWAP_HOTBAR_SHORTCUT_STRING = "SwapHotbarShortCutPC";

	private const string SHORTCUT_STRING = "ShortCutPC";

	private const string SWAP_HOTBAR_BUTTON_MODIFIER_STRING = "HotbarSwapModifier";

	private const string NEXT_SLOT_BUTTON_STRING = "SwapNextHotbar";

	private const string PREVIOUS_SLOT_BUTTON_STRING = "SwapPreviousHotbar";

	public override bool keepMouseActiveButHiddenOnHoverWhenUsingController => true;

	public override TextAndFormatFields GetHoverTitle()
	{
		return new TextAndFormatFields
		{
			text = (isUpArrow ? "SwapNextHotbarPC" : "SwapPreviousHotbarPC")
		};
	}

	public override List<TextAndFormatFields> GetHoverDescription()
	{
		bool flag = Manager.input.IsAnyGamepadConnected() && !Manager.input.singleplayerInputModule.PrefersKeyboardAndMouse();
		string text;
		string[] formatFields;
		if (Manager.input.singleplayerInputModule.rewiredPlayer.controllers.maps.GetFirstElementMapWithAction(flag ? ControllerType.Joystick : ControllerType.Keyboard, 225, skipDisabledMaps: true) != null)
		{
			text = PugText.ProcessText("SwapHotbarShortCutPC", null, shouldLocalize: false, shouldLocalizeFormatFields: false);
			formatFields = new string[2]
			{
				PugText.GetButtonStringForThai(Manager.ui.GetShortCutString("HotbarSwapModifier", flag)),
				PugText.GetButtonStringForThai(Manager.ui.GetShortCutString(isUpArrow ? "SwapNextHotbar" : "SwapPreviousHotbar", flag))
			};
		}
		else
		{
			text = PugText.ProcessText("ShortCutPC", null, shouldLocalize: false, shouldLocalizeFormatFields: false);
			formatFields = new string[1] { PugText.GetButtonStringForThai(Manager.ui.GetShortCutString(isUpArrow ? "SwapNextHotbar" : "SwapPreviousHotbar", flag)) };
		}
		return new List<TextAndFormatFields>
		{
			new TextAndFormatFields
			{
				text = text,
				color = Color.white * 0.95f,
				dontLocalize = false,
				paddingBeneath = 0.125f,
				formatFields = formatFields,
				dontLocalizeFormatFields = true
			}
		};
	}
}
