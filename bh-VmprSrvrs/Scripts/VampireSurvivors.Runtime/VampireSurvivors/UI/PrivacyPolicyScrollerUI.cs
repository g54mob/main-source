using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace VampireSurvivors.UI
{
	public class PrivacyPolicyScrollerUI : MonoBehaviour, ISelectableUI, IUIObject
	{
		[SerializeField]
		private TextMeshProUGUI _Text;

		[SerializeField]
		private TextMeshProUGUI _LeftButtonLabel;

		[SerializeField]
		private TextMeshProUGUI _RightButtonLabel;

		[SerializeField]
		private Button _LeftButton;

		[SerializeField]
		private Button _RightButton;

		[SerializeField]
		private FakeSliderHandleController _SliderHandle;

		public void SetLeftButtonLabel(string text)
		{
		}

		public void SetLeftButtonCallback(Action cb)
		{
		}

		public void SetRightButtonLabel(string text)
		{
		}

		public void SetRightButtonCallback(Action cb)
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
