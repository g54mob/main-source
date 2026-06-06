using System;
using System.Collections.Generic;
using Rewired;
using UnityEngine;
using UnityEngine.PajamaLlama;

public abstract class RewiredJoystickGlyphs<T> : RewiredControllerGlyphs where T : Enum
{
	[Serializable]
	private struct ElementSprite
	{
		[JoystickElement]
		public int Element;

		[HideInInspector]
		public string ElementName;

		public Sprite Sprite;
	}

	[SerializeField]
	private RewiredJoystickStick[] _sticks;

	[SerializeField]
	[NamedArrayElement(new string[] { "ElementName" })]
	private ElementSprite[] _buttons;

	public abstract Guid Guid { get; }

	public override bool SupportsGuid(Guid guid)
	{
		return Guid == guid;
	}

	public override bool TryGetActionNameAndIcon(Controller controller, int actionId, out string name, out Sprite icon, bool skipDisabledMaps = true)
	{
		ActionElementMap firstElementMapWithAction = FlotsamInputManager.GetFirstElementMapWithAction(controller, actionId, skipDisabledMaps);
		if (firstElementMapWithAction != null && TryGetElementGlyph(firstElementMapWithAction, out var glyph))
		{
			name = firstElementMapWithAction.actionDescriptiveName;
			icon = glyph;
			return true;
		}
		name = null;
		icon = null;
		return false;
	}

	public override bool TryGetActionsParameterValue(Controller controller, List<int> actionIds, out string value, bool skipDisabledMaps)
	{
		using ListPool<object>.List list = ListPool<object>.Get();
		foreach (int actionId in actionIds)
		{
			ActionElementMap firstElementMapWithAction = FlotsamInputManager.GetFirstElementMapWithAction(controller, actionId, skipDisabledMaps);
			if (firstElementMapWithAction != null && !TryAddStick(firstElementMapWithAction, list) && TryGetElementGlyph(firstElementMapWithAction, out var glyph))
			{
				list.Add($"<sprite=\"{glyph.texture.name}\" sprite name=\"{glyph.name}\">");
			}
		}
		value = (list.IsNullOrEmpty() ? null : (value = string.Concat(list)));
		ResetSticks();
		return !string.IsNullOrEmpty(value);
	}

	private bool TryGetElementGlyph(ActionElementMap aem, out Sprite glyph)
	{
		ElementSprite[] buttons = _buttons;
		for (int i = 0; i < buttons.Length; i++)
		{
			ElementSprite elementSprite = buttons[i];
			if (elementSprite.Element == aem.elementIdentifierId)
			{
				glyph = elementSprite.Sprite;
				return true;
			}
		}
		glyph = null;
		return false;
	}

	private bool TryAddStick(ActionElementMap aem, List<object> actions)
	{
		RewiredJoystickStick[] sticks = _sticks;
		foreach (RewiredJoystickStick rewiredJoystickStick in sticks)
		{
			if (rewiredJoystickStick.TryAddAction(aem))
			{
				actions.AddUnique(rewiredJoystickStick);
				return true;
			}
		}
		return false;
	}

	private void ResetSticks()
	{
		RewiredJoystickStick[] sticks = _sticks;
		for (int i = 0; i < sticks.Length; i++)
		{
			sticks[i].Reset();
		}
	}
}
