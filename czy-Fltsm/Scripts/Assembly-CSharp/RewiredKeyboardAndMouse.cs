using System;
using System.Collections.Generic;
using I2.Loc;
using Rewired;
using UnityEngine;
using UnityEngine.PajamaLlama;

[CreateAssetMenu(menuName = "Pajama Llama/Rewired/KeyboardAndMouse")]
public class RewiredKeyboardAndMouse : RewiredControllerGlyphs
{
	public enum MouseButtonElementIds
	{
		None = -1,
		MouseHorizontal = 0,
		MouseVertical = 1,
		MouseWheel = 2,
		LeftMouseButton = 3,
		RightMouseButton = 4,
		MouseButton3 = 5,
		MouseButton4 = 6,
		MouseButton5 = 7
	}

	[Serializable]
	public struct KeyboardGlyph
	{
		public KeyboardKeyCode KeyCode;

		public Sprite Glyph;
	}

	[Serializable]
	public struct MouseGlyph
	{
		public MouseButtonElementIds[] ElementIds;

		public LocalizedString Description;

		public Sprite Glyph;

		public bool IsMatch(ActionElementMap aem)
		{
			if (ElementIds.Length == 1)
			{
				return ElementIds[0] == (MouseButtonElementIds)aem.elementIdentifierId;
			}
			return false;
		}

		public bool IsMatch(List<ActionElementMap> aems)
		{
			try
			{
				if (aems.Count == ElementIds.Length)
				{
					foreach (ActionElementMap aem in aems)
					{
						if (!HasElementId(aem))
						{
							return false;
						}
					}
					return true;
				}
			}
			catch (Exception exception)
			{
				Debug.LogException(exception);
			}
			return false;
		}

		private bool HasElementId(ActionElementMap aem)
		{
			for (int i = 0; i < ElementIds.Length; i++)
			{
				if (ElementIds[i] == (MouseButtonElementIds)aem.elementIdentifierId)
				{
					return true;
				}
			}
			return false;
		}
	}

	public static readonly Guid KEYBOARD_GUID = new Guid("ae4830f9-63db-4d4c-90b3-1beb46ecaf49");

	public static readonly Guid MOUSE_GUID = new Guid("ad60107c-ea39-4d9c-b906-56d39d07be95");

	[SerializeField]
	[NamedArrayElement(new string[] { "Glyph" })]
	private MouseGlyph[] _mouseGlyphs;

	[SerializeField]
	[NamedArrayElement(new string[] { "KeyCode" })]
	private KeyboardGlyph[] _keyboardGlyphs;

	public override bool SupportsGuid(Guid guid)
	{
		if (!(guid == KEYBOARD_GUID))
		{
			return guid == MOUSE_GUID;
		}
		return true;
	}

	public override bool TryGetActionNameAndIcon(Controller controller, int actionId, out string name, out Sprite icon, bool skipDisabledMaps)
	{
		if (!TryGetMouseAction(actionId, out name, out icon, skipDisabledMaps))
		{
			return TryGetKeyboardAction(actionId, out name, out icon, skipDisabledMaps);
		}
		return true;
	}

	private bool TryGetMouseAction(int actionId, out string name, out Sprite icon, bool skipDisabledMaps)
	{
		ActionElementMap firstMouseMapWithAction = FlotsamInputManager.GetFirstMouseMapWithAction(actionId, skipDisabledMaps);
		if (firstMouseMapWithAction != null && TryGetSingleActionMouseGlyph(firstMouseMapWithAction, out var mouseGlyph))
		{
			name = firstMouseMapWithAction.actionDescriptiveName;
			icon = mouseGlyph.Glyph;
			return true;
		}
		name = null;
		icon = null;
		return false;
	}

	private bool TryGetKeyboardAction(int actionId, out string name, out Sprite icon, bool skipDisabledMaps)
	{
		ActionElementMap firstKeyboardMapWithAction = FlotsamInputManager.GetFirstKeyboardMapWithAction(actionId, skipDisabledMaps);
		if (firstKeyboardMapWithAction != null)
		{
			KeyboardGlyph[] keyboardGlyphs = _keyboardGlyphs;
			for (int i = 0; i < keyboardGlyphs.Length; i++)
			{
				KeyboardGlyph keyboardGlyph = keyboardGlyphs[i];
				if (keyboardGlyph.KeyCode == firstKeyboardMapWithAction.keyboardKeyCode)
				{
					name = firstKeyboardMapWithAction.actionDescriptiveName;
					icon = keyboardGlyph.Glyph;
					return true;
				}
			}
		}
		name = null;
		icon = null;
		return false;
	}

	public override bool TryGetActionsParameterValue(Controller controller, List<int> actionIds, out string value, bool skipDisabledMaps)
	{
		value = GetMouseParameterValue(actionIds, skipDisabledMaps);
		foreach (int actionId in actionIds)
		{
			if (TryGetKeyboardActionString(actionId, out var action, skipDisabledMaps))
			{
				value += action;
			}
		}
		if (string.IsNullOrEmpty(value))
		{
			return false;
		}
		return !string.IsNullOrEmpty(value);
	}

	private string GetMouseParameterValue(List<int> actionIds, bool skipDisabledMaps)
	{
		using ListPool<ActionElementMap>.List list = ListPool<ActionElementMap>.Get();
		bool flag = true;
		string text = string.Empty;
		int count = actionIds.Count;
		while (0 < count--)
		{
			ActionElementMap firstMouseMapWithAction = FlotsamInputManager.GetFirstMouseMapWithAction(actionIds[count], skipDisabledMaps);
			if (firstMouseMapWithAction != null)
			{
				actionIds.RemoveAt(count);
				list.Insert(0, firstMouseMapWithAction);
			}
		}
		if (TryGetMultipleActionMouseGlyph(list, out var mouseGlyph))
		{
			flag = false;
			text += GetTextGlyph(mouseGlyph.Glyph);
		}
		foreach (ActionElementMap item in list)
		{
			if (TryGetSingleActionMouseGlyph(item, out mouseGlyph))
			{
				if (flag)
				{
					text += GetTextGlyph(mouseGlyph.Glyph);
				}
				if (!string.IsNullOrEmpty(mouseGlyph.Description.mTerm))
				{
					text += $"[{mouseGlyph.Description}]";
					continue;
				}
			}
			text = text + "[" + item.elementIdentifierName + "]";
		}
		return text;
	}

	private bool TryGetMultipleActionMouseGlyph(List<ActionElementMap> aems, out MouseGlyph mouseGlyph)
	{
		mouseGlyph = default(MouseGlyph);
		for (int i = 0; i < _mouseGlyphs.Length; i++)
		{
			mouseGlyph = _mouseGlyphs[i];
			if (mouseGlyph.IsMatch(aems))
			{
				return true;
			}
		}
		return false;
	}

	private bool TryGetSingleActionMouseGlyph(ActionElementMap aem, out MouseGlyph mouseGlyph)
	{
		mouseGlyph = default(MouseGlyph);
		for (int i = 0; i < _mouseGlyphs.Length; i++)
		{
			mouseGlyph = _mouseGlyphs[i];
			if (mouseGlyph.IsMatch(aem))
			{
				return true;
			}
		}
		return false;
	}

	private bool TryGetKeyboardActionString(int actionId, out string action, bool skipDisabledMaps)
	{
		ActionElementMap firstKeyboardMapWithAction = FlotsamInputManager.GetFirstKeyboardMapWithAction(actionId, skipDisabledMaps);
		if (firstKeyboardMapWithAction != null)
		{
			if (TryGetKeyboardGlyph(firstKeyboardMapWithAction, out var keyboardGlyph))
			{
				action = GetTextGlyph(keyboardGlyph.Glyph);
			}
			else
			{
				action = $"[{firstKeyboardMapWithAction.keyCode}]";
			}
			return true;
		}
		action = null;
		return false;
	}

	private bool TryGetKeyboardGlyph(ActionElementMap aem, out KeyboardGlyph keyboardGlyph)
	{
		keyboardGlyph = default(KeyboardGlyph);
		for (int i = 0; i < _keyboardGlyphs.Length; i++)
		{
			keyboardGlyph = _keyboardGlyphs[i];
			if (keyboardGlyph.KeyCode == aem.keyboardKeyCode)
			{
				return true;
			}
		}
		return false;
	}

	private string GetTextGlyph(Sprite glyph)
	{
		return $"<sprite=\"{glyph.texture.name}\" sprite name=\"{glyph.name}\">";
	}
}
