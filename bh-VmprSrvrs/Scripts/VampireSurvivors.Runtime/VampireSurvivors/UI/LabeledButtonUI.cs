using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace VampireSurvivors.UI
{
	public class LabeledButtonUI : MonoBehaviour, ISelectableUI, IUIObject
	{
		[SerializeField]
		private TextMeshProUGUI _Label;

		[SerializeField]
		private TextMeshProUGUI _ButtonLabel;

		[SerializeField]
		private Button _Button;

		public void SetLabel(string text)
		{
		}

		public void SetButtonLabel(string text)
		{
		}

		public void SetButtonCallback(Action cb)
		{
		}

		public Selectable GetSelectable()
		{
			return null;
		}

		public GameObject GetGameObject()
		{
			return null;
		}

		public void UpdateNavigation(Selectable up, Selectable down, Selectable left, Selectable right)
		{
		}
	}
}
