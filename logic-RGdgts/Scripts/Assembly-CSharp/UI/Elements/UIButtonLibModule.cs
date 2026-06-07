using UnityEngine;

namespace UI.Elements
{
	public class UIButtonLibModule : MonoBehaviour, IUIButtonModule
	{
		private UIButton uiButton;

		public UIButton additionalButton;

		private string url;

		public void Init(UIButton uibutton)
		{
		}

		public void SetUrl(string url)
		{
		}

		public void OnAdditionalButtonPointerEnter()
		{
		}

		public void OnAdditionalButtonPointerExit()
		{
		}

		private void OpenDocumentation()
		{
		}

		private void OpenDocumentationConfirm(bool confirm)
		{
		}

		public void OnDisabled()
		{
		}

		public void OnEnabled()
		{
		}

		public void OnSelected()
		{
		}

		public void OnUnselected()
		{
		}

		public void ResetButton()
		{
		}
	}
}
