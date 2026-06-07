using UnityEngine;

namespace UI.Elements
{
	public class UIButtonInListModule : MonoBehaviour, IUIButtonModule
	{
		private UIButton uiButton;

		[SerializeField]
		private bool isSelectedInList;

		public void Init(UIButton uibutton)
		{
		}

		private void SelectInList()
		{
		}

		public void OnSelected()
		{
		}

		public void OnUnselected()
		{
		}

		public void OnEnabled()
		{
		}

		public void OnDisabled()
		{
		}

		public void ResetButton()
		{
		}
	}
}
