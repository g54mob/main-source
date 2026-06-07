using System;
using UnityEngine;
using UnityEngine.UI;

namespace Simulator.GameWorld
{
	public class UI_SearchBar : NavInputField
	{
		[SerializeField]
		private Button m_searchValidateButton;

		private string m_searchString;

		public event Action<string> AnyChange;

		public event Action Validate;

		protected override void OnEnable()
		{
			base.OnEnable();
			base.InputField.onSelect.AddListener(OnInputFieldSelected);
			base.InputField.onDeselect.AddListener(OnInputFieldDeselected);
			base.InputField.onValueChanged.AddListener(OnSearchStringValueChanged);
			base.InputField.onSubmit.AddListener(OnValidateSearch);
			m_searchValidateButton.onClick.AddListener(OnButtonSearch);
		}

		protected override void OnDisable()
		{
			base.OnDisable();
			base.InputField.onSelect.RemoveListener(OnInputFieldSelected);
			base.InputField.onDeselect.RemoveListener(OnInputFieldDeselected);
			base.InputField.onValueChanged.RemoveListener(OnSearchStringValueChanged);
			base.InputField.onSubmit.RemoveListener(OnValidateSearch);
			m_searchValidateButton.onClick.RemoveListener(OnButtonSearch);
		}

		protected virtual void OnSearchStringValueChanged(string content)
		{
			m_searchString = content;
			this.AnyChange?.Invoke(m_searchString);
		}

		protected virtual void OnValidateSearch(string content)
		{
			this.Validate?.Invoke();
		}

		protected virtual void OnButtonSearch()
		{
			this.Validate?.Invoke();
		}

		protected virtual void OnInputFieldSelected(string str)
		{
			InputManager.InputFieldFocused = true;
		}

		protected virtual void OnInputFieldDeselected(string str)
		{
			InputManager.InputFieldFocused = false;
		}
	}
}
