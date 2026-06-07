using System;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Assets.Packages.SocialPlatforms.Steam
{
	public class SteamVirtualKeyboardManager : MonoBehaviour
	{
		private static Vector3[] _getWorldCornersArray = new Vector3[4];

		private bool _inputFieldSelected;

		private WeakReference _lastSelectedObject;

		private void OnInputFieldSelected(InputField input)
		{
			OnInputFieldSelected(input, input.multiLine, input.keyboardType);
		}

		private void OnInputFieldSelected(TMP_InputField input)
		{
			OnInputFieldSelected(input, input.multiLine, input.keyboardType);
		}

		private void OnInputFieldSelected(Selectable input, bool multiLine, TouchScreenKeyboardType keyboardType)
		{
			if (SocialExt.Active is SteamPlatform steamPlatform)
			{
				FloatingGamepadTextInputMode mode = (multiLine ? FloatingGamepadTextInputMode.MultipleLines : FloatingGamepadTextInputMode.SingleLine);
				switch (keyboardType)
				{
				case TouchScreenKeyboardType.NumberPad:
				case TouchScreenKeyboardType.PhonePad:
				case TouchScreenKeyboardType.DecimalPad:
				case TouchScreenKeyboardType.OneTimeCode:
					mode = FloatingGamepadTextInputMode.Numeric;
					break;
				case TouchScreenKeyboardType.EmailAddress:
					mode = FloatingGamepadTextInputMode.Email;
					break;
				}
				Rect inputFieldPosition = default(Rect);
				if (input.TryGetComponent<RectTransform>(out var component))
				{
					Vector3[] getWorldCornersArray = _getWorldCornersArray;
					component.GetWorldCorners(getWorldCornersArray);
					inputFieldPosition = new Rect(getWorldCornersArray[0].x, getWorldCornersArray[0].y, getWorldCornersArray[2].x - getWorldCornersArray[0].x, getWorldCornersArray[2].y - getWorldCornersArray[0].y);
				}
				steamPlatform.ShowFloatingGamepadTextInput(mode, inputFieldPosition);
			}
		}

		private void Update()
		{
			EventSystem current = EventSystem.current;
			if (current == null)
			{
				return;
			}
			WeakReference lastSelectedObject = _lastSelectedObject;
			GameObject obj = ((lastSelectedObject != null && lastSelectedObject.IsAlive) ? (_lastSelectedObject.Target as GameObject) : null);
			GameObject currentSelectedGameObject = current.currentSelectedGameObject;
			if ((object)obj == currentSelectedGameObject && (!_inputFieldSelected || !Input.GetMouseButtonDown(0)))
			{
				return;
			}
			_inputFieldSelected = false;
			if ((object)currentSelectedGameObject == null)
			{
				_lastSelectedObject = null;
				return;
			}
			_lastSelectedObject = new WeakReference(currentSelectedGameObject);
			TMP_InputField component2;
			if (currentSelectedGameObject.TryGetComponent<InputField>(out var component))
			{
				_inputFieldSelected = true;
				OnInputFieldSelected(component);
			}
			else if (currentSelectedGameObject.TryGetComponent<TMP_InputField>(out component2))
			{
				_inputFieldSelected = true;
				OnInputFieldSelected(component2);
			}
		}
	}
}
