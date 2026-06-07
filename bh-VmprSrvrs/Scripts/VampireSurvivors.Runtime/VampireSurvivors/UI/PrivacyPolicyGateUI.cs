using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace VampireSurvivors.UI
{
	public class PrivacyPolicyGateUI : MonoBehaviour, ISelectableUI, IUIObject
	{
		[SerializeField]
		private TextMeshProUGUI _WarningMessage;

		[SerializeField]
		private TextMeshProUGUI _CenterButtonLabel;

		[SerializeField]
		private Button _CenterButton;

		public void SetWarningMessage(string text)
		{
		}

		public void SetCenterButtonLabel(string text)
		{
		}

		public void SetCenterButtonCallback(Action cb)
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
