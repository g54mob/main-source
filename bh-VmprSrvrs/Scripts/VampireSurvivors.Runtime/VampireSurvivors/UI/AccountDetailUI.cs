using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace VampireSurvivors.UI
{
	public class AccountDetailUI : MonoBehaviour, IUIObject, ISelectableUI
	{
		[SerializeField]
		private Image _Icon;

		[SerializeField]
		private TextMeshProUGUI _Account;

		[SerializeField]
		private TextMeshProUGUI _Detail;

		[SerializeField]
		private TextMeshProUGUI _ButtonLabel;

		[SerializeField]
		private Button _Button;

		public void SetAccountText(string text)
		{
		}

		public void SetDetailText(string text)
		{
		}

		public void SetButtonLabel(string text)
		{
		}

		public void SetButtonCallback(Action cb)
		{
		}

		public void SetLinkedIcon(bool linked)
		{
		}

		public void RemoveButton()
		{
		}

		public GameObject GetGameObject()
		{
			return null;
		}

		public Selectable GetSelectable()
		{
			return null;
		}

		public void UpdateNavigation(Selectable above, Selectable below, Selectable left, Selectable right)
		{
		}
	}
}
