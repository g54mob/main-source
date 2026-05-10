using System.Runtime.InteropServices;
using CTS.Core;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace CTS
{
	public static class UIUtility
	{
		[StructLayout(LayoutKind.Sequential, Size = 1)]
		private struct InputFieldEvent
		{
		}

		private static bool _inInputField;

		public static bool InInputField()
		{
			if (!RuntimeFrameTrigger<InputFieldEvent>.TryUse())
			{
				return _inInputField;
			}
			EventSystem current = EventSystem.current;
			if (current == null)
			{
				return false;
			}
			GameObject currentSelectedGameObject = current.currentSelectedGameObject;
			_inInputField = currentSelectedGameObject != null && (currentSelectedGameObject.TryGetComponent<InputField>(out var _) || currentSelectedGameObject.TryGetComponent<TMP_InputField>(out var _));
			return _inInputField;
		}
	}
}
