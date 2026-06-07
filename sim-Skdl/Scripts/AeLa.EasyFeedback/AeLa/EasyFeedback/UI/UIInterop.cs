using System;
using AeLa.EasyFeedback.UI.Interfaces;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace AeLa.EasyFeedback.UI
{
	internal static class UIInterop
	{
		public static IText GetText(GameObject go)
		{
			return null;
		}

		internal static IDropdown GetDropdown(GameObject gameObject)
		{
			return null;
		}

		internal static IInputField GetInputField(GameObject gameObject, bool soft = false)
		{
			return null;
		}

		internal static IText GetText(Text unityText, TMP_Text tmpText)
		{
			return null;
		}

		private static Exception GetNonCompatibleException(string elementType, GameObject go)
		{
			return null;
		}
	}
}
