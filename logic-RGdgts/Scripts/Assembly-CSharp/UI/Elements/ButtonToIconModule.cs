using UnityEngine;

namespace UI.Elements
{
	public class ButtonToIconModule : MonoBehaviour, IUIButtonModule
	{
		private UIButton uiButton;

		[SerializeField]
		private int expandedSize;

		[SerializeField]
		private int iconSize;

		public void Init(UIButton uibutton)
		{
		}

		public void AddPointerEnter()
		{
		}

		public void AddPointerExit()
		{
		}

		public void ExpandToText()
		{
		}

		public void OnSelected()
		{
		}

		public void OnEnabled()
		{
		}

		public void OnDisabled()
		{
		}

		public void OnUnselected()
		{
		}

		public void ResetButton()
		{
		}

		public void OnPointerDown()
		{
		}
	}
}
