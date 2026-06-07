using Gh.Tk.UI.Dialogs;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Gh.Tk
{
	public class EditGoxNameElement : FormElementInput
	{
		private GameObjectX _gox;

		[SerializeField]
		private TMP_InputField _inputField;

		private void Awake()
		{
		}

		private void OnInputDeselected(string arg0)
		{
		}

		private void EnsureTextVisibility()
		{
		}

		private void OnInputSelected(string arg0)
		{
		}

		public void SetGox(GameObjectX gox)
		{
		}

		private void UpdateNameInputText()
		{
		}

		public void SetTextWithoutNotify(string text, string gender = null)
		{
		}

		private void ApplyNameToGox()
		{
		}

		public override void OnDeselect(BaseEventData eventData)
		{
		}
	}
}
