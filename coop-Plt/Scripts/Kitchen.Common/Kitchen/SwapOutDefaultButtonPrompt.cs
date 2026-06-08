using System;
using Controllers;
using KitchenData;
using Platforms;
using TMPro;
using UnityEngine;

namespace Kitchen
{
	[Serializable]
	public class SwapOutDefaultButtonPrompt : MonoBehaviour
	{
		[SerializeField]
		private TMP_Text textComponent;

		[SerializeField]
		private string textToReplace;

		[SerializeField]
		public Button Button;

		[SerializeField]
		private bool RunEachFrame;

		[SerializeField]
		public int TargetPlayerIndex;

		private void Start()
		{
			UpdateIcon();
		}

		private void Update()
		{
			if (RunEachFrame)
			{
				UpdateIcon();
			}
		}

		public void UpdateIcon()
		{
			if (InputSourceIdentifier.DefaultInputSource != null)
			{
				ControllerType currentController = InputSourceIdentifier.DefaultInputSource.GetCurrentController(TargetPlayerIndex);
				string bindingName = InputSourceIdentifier.DefaultInputSource.GetBindingName(TargetPlayerIndex, Button.ToString());
				string text = GameData.Main.GlobalLocalisation.ControllerIcons.GetTMPIcon(currentController, bindingName);
				if (text == "<sprite=\"Joy-Con-Filled\" name=\"?\">")
				{
					text = "<sprite=\"Joy-Con-Filled\" name=\"Shoulder-Left\"> / <sprite=\"Joy-Con-Filled\" name=\"Shoulder-Right\">";
				}
				textComponent.text = textComponent.text.Replace(textToReplace, text);
			}
		}
	}
}
