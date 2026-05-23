using System.Collections.Generic;
using System.Linq;
using Rewired;
using TMPro;
using UnityEngine;

public static class InputActionGlyph
{
	public enum InputPriority
	{
		PrioritizeController = 0,
		PrioritizeKeyboardAndMouse = 1
	}

	public const string highlight_color = "FFE7C4";

	public const string default_color = "C8A674";

	public static readonly string[] playstation_controllers;

	public static readonly string[] xbox_controllers;

	public static readonly string[] switch_controllers;

	public const string open_voffset = "<voffset=-0.1em>";

	public const string close_voffset = "</voffset>";

	private static Player player;

	static InputActionGlyph()
	{
		playstation_controllers = new string[4] { "c3ad3cad-c7cf-4ca8-8c2e-e3df8d9960bb", "71dfe6c8-9e81-428f-a58e-c7e664b7fbed", "cd9718bf-a87a-44bc-8716-60a0def28a9f", "5286706d-19b4-4a45-b635-207ce78d8394" };
		xbox_controllers = new string[2] { "d74a350e-fe8b-4e9e-bbcd-efff16d34115", "19002688-7406-4f4a-8340-8d25335406c8" };
		switch_controllers = new string[2] { "521b808c-0248-4526-bc10-f1d16ee76bf1", "1fbdd13b-0795-4173-8a95-a2a75de9d204" };
		player = ReInput.players.GetPlayer(0);
	}

	public static string GetActionGlyph(string actionName, InputPriority inputPriority, bool showBothPolesIfAxis = false)
	{
		string text = "";
		InputAction action = ReInput.mapping.GetAction(actionName);
		List<ActionElementMap> list = new List<ActionElementMap>();
		player.controllers.maps.GetElementMapsWithAction(action.id, skipDisabledMaps: true, list);
		List<ActionElementMap> list2 = new List<ActionElementMap>();
		for (int num = list.Count - 1; num >= 0; num--)
		{
			if (ReInput.mapping.GetMapCategory(list[num].controllerMap.categoryId).name.Contains("No Glyphs"))
			{
				list2.Add(list[num]);
				list.RemoveAt(num);
			}
		}
		switch (inputPriority)
		{
		case InputPriority.PrioritizeKeyboardAndMouse:
			list = list.OrderBy((ActionElementMap map) => map.controllerMap.controllerType != ControllerType.Keyboard && map.controllerMap.controllerType != ControllerType.Mouse).ToList();
			list2 = list2.OrderBy((ActionElementMap map) => map.controllerMap.controllerType != ControllerType.Keyboard && map.controllerMap.controllerType != ControllerType.Mouse).ToList();
			break;
		case InputPriority.PrioritizeController:
			list = list.OrderBy((ActionElementMap map) => map.controllerMap.controllerType != ControllerType.Joystick).ToList();
			list2 = list2.OrderBy((ActionElementMap map) => map.controllerMap.controllerType != ControllerType.Joystick).ToList();
			break;
		}
		if (action.type == InputActionType.Axis)
		{
			ActionElementMap actionElementMap = null;
			ActionElementMap actionElementMap2 = null;
			foreach (ActionElementMap item in list)
			{
				if (item.axisContribution == Pole.Positive && actionElementMap == null)
				{
					actionElementMap = item;
				}
				else if (item.axisContribution == Pole.Negative && actionElementMap2 == null)
				{
					actionElementMap2 = item;
				}
				if (actionElementMap != null && actionElementMap2 != null)
				{
					break;
				}
			}
			if (actionElementMap2 == null || actionElementMap == null)
			{
				foreach (ActionElementMap item2 in list2)
				{
					if (item2.axisContribution == Pole.Positive && actionElementMap == null)
					{
						actionElementMap = item2;
					}
					else if (item2.axisContribution == Pole.Negative && actionElementMap2 == null)
					{
						actionElementMap2 = item2;
					}
					if (actionElementMap != null && actionElementMap2 != null)
					{
						break;
					}
				}
			}
			if (actionElementMap2 != null)
			{
				text += GetGlyphFromElementMap(actionElementMap2, useHighlightColor: true);
			}
			if (actionElementMap != null)
			{
				if (text.Length > 0)
				{
					text += " <color=#FFE7C4>/</color> ";
				}
				text += GetGlyphFromElementMap(actionElementMap, useHighlightColor: true);
			}
		}
		else if (list.Count > 0)
		{
			text = GetGlyphFromElementMap(list[0], useHighlightColor: true);
		}
		else if (list2.Count > 0)
		{
			text = GetGlyphFromElementMap(list2[0], useHighlightColor: true);
		}
		return text;
	}

	public static string GetGlyphFromElementMap(ActionElementMap targetMap, bool useHighlightColor = false)
	{
		string text = (useHighlightColor ? "FFE7C4" : "C8A674");
		ReInput.mapping.GetAction(targetMap.actionId);
		switch (targetMap.controllerMap.controllerType)
		{
		case ControllerType.Keyboard:
		{
			string text2 = "keyboard_glyphs";
			TMP_SpriteAsset tMP_SpriteAsset = Resources.Load<TMP_SpriteAsset>("Sprite Assets/" + text2);
			if (tMP_SpriteAsset.GetSpriteIndexFromName(targetMap.elementIdentifierName) < 0)
			{
				return "<color=#" + text + ">" + targetMap.elementIdentifierName + "</color>";
			}
			return PutIntoVoffset("<sprite=\"" + text2 + "\" name=\"" + targetMap.elementIdentifierName + "\" color=#" + text + ">");
		}
		case ControllerType.Mouse:
		{
			string text2 = "mouse_glyphs";
			TMP_SpriteAsset tMP_SpriteAsset = Resources.Load<TMP_SpriteAsset>("Sprite Assets/" + text2);
			string elementIdentifierName = targetMap.elementIdentifierName;
			string text4 = "";
			switch (elementIdentifierName)
			{
			case "Left Mouse Button":
				text4 = "click_l";
				break;
			case "Right Mouse Button":
				text4 = "click_r";
				break;
			case "Mouse Button 3":
				text4 = "click_m";
				break;
			case "Mouse Wheel":
				text4 = "scroll";
				break;
			case "Mouse Wheel Up":
				text4 = "scroll+";
				break;
			case "Mouse Wheel Down":
				text4 = "scroll-";
				break;
			}
			if (text4.Length > 0)
			{
				return PutIntoVoffset("<sprite=\"" + text2 + "\" name=\"" + text4 + "\" color=#" + text + ">");
			}
			return "<color=#" + text + ">" + targetMap.elementIdentifierName + "</color>";
		}
		case ControllerType.Joystick:
		{
			string value = targetMap.controllerMap.hardwareGuid.ToString();
			string text2 = "";
			text2 = (xbox_controllers.Contains(value) ? "xbox_glyphs" : (playstation_controllers.Contains(value) ? "playstation_glyphs" : ((!switch_controllers.Contains(value)) ? "generic_glyphs" : "switch_default_glyphs")));
			TMP_SpriteAsset tMP_SpriteAsset = Resources.Load<TMP_SpriteAsset>("Sprite Assets/" + text2);
			if (text2 != "generic_glyphs")
			{
				string text3 = "";
				if (targetMap.axisRange != AxisRange.Full)
				{
					if (targetMap.axisRange == AxisRange.Positive)
					{
						text3 = "+";
					}
					else if (targetMap.axisRange == AxisRange.Negative)
					{
						text3 = "-";
					}
					if (tMP_SpriteAsset.GetSpriteIndexFromName(targetMap.elementIdentifierId + text3) < 0)
					{
						text3 = "";
					}
				}
				if (tMP_SpriteAsset.GetSpriteIndexFromName(targetMap.elementIdentifierId + text3) < 0)
				{
					return "<color=#" + text + ">" + targetMap.elementIdentifierName + "</color>";
				}
				return PutIntoVoffset("<sprite=\"" + text2 + "\" name=\"" + targetMap.elementIdentifierId + text3 + "\" color=#" + text + ">");
			}
			if (tMP_SpriteAsset.GetSpriteIndexFromName(targetMap.elementIdentifierName) < 0)
			{
				return "<color=#" + text + ">" + targetMap.elementIdentifierName + "</color>";
			}
			return PutIntoVoffset("<sprite=\"" + text2 + "\" name=\"" + targetMap.elementIdentifierName + "\" color=#" + text + ">");
		}
		default:
			return "NOT SUPPORTED YED";
		}
	}

	public static string PutIntoVoffset(string s)
	{
		return "<voffset=-0.1em>" + s + "</voffset>";
	}
}
