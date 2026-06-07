using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace VampireSurvivors.UI
{
	public class SaveSlotContainerUI : MonoBehaviour, IUIObject, ISelectableUI
	{
		[SerializeField]
		private TextMeshProUGUI _Title;

		[SerializeField]
		private TextMeshProUGUI _SaveData;

		[SerializeField]
		private TextMeshProUGUI _ButtonLabel;

		[SerializeField]
		private Button _Button;

		public void SetLabel(string title)
		{
		}

		public void SetSaveData(string text)
		{
		}

		public void RemoveButton()
		{
		}

		public void SetButtonLabel(string text)
		{
		}

		public void SetButtonCallback(Action cb)
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
