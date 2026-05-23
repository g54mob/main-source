using Data.FactoryFloor.FactoryObjectBehaviours;
using Presentation.UI.Menus;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

namespace Presentation.UI.OperatorUIs.OperatorPanelUIs.TextBlock
{
	public class TextBlockUI : FactoryPanelUIMenu
	{
		[Header("Text Block UI")]
		[SerializeField]
		private TMP_InputField _inputField;

		[SerializeField]
		private Button _leftAlignButton;

		[SerializeField]
		private Button _middleAlignButton;

		[SerializeField]
		private Button _rightAlignButton;

		[SerializeField]
		private GameObject _leftAlignSelected;

		[SerializeField]
		private GameObject _middleAlignSelected;

		[SerializeField]
		private GameObject _rightAlignSelected;

		private TextBlockBehaviour _behaviour;

		protected override void HandleOnAwake()
		{
			base.HandleOnAwake();
			_inputField.onSelect.AddListener(OnTextSelected);
			_inputField.onDeselect.AddListener(OnTextDeselected);
			_inputField.onValueChanged.AddListener(OnTextChanged);
			_leftAlignButton.onClick.AddListener(OnLeftAlignClicked);
			_middleAlignButton.onClick.AddListener(OnMiddleAlignClicked);
			_rightAlignButton.onClick.AddListener(OnRightAlignClicked);
		}

		protected override void HandleOnDestroy()
		{
			_inputField.onSelect.AddListener(OnTextSelected);
			_inputField.onDeselect.AddListener(OnTextDeselected);
			_inputField.onValueChanged.AddListener(OnTextChanged);
			base.HandleOnDestroy();
		}

		protected override void Initialized()
		{
			_behaviour = _factoryObjectBehaviour as TextBlockBehaviour;
			_inputField.SetTextWithoutNotify(_behaviour.Configuration.Text);
			UpdateAlignmentSelected();
		}

		private void UpdateAlignmentSelected()
		{
			_leftAlignSelected.SetActive(_behaviour.Configuration.Alignment == TextAlignmentOptions.MidlineLeft);
			_middleAlignSelected.SetActive(_behaviour.Configuration.Alignment == TextAlignmentOptions.Midline);
			_rightAlignSelected.SetActive(_behaviour.Configuration.Alignment == TextAlignmentOptions.MidlineRight);
		}

		public override void HideMenu()
		{
			InputSystem.EnableDevice(Keyboard.current);
			base.HideMenu();
		}

		private void SetAlignment(TextAlignmentOptions alignment)
		{
			_behaviour.Configuration.Alignment = alignment;
			_behaviour.NotifyConfigurationChanged();
			UpdateAlignmentSelected();
		}

		private void OnLeftAlignClicked()
		{
			SetAlignment(TextAlignmentOptions.MidlineLeft);
		}

		private void OnMiddleAlignClicked()
		{
			SetAlignment(TextAlignmentOptions.Midline);
		}

		private void OnRightAlignClicked()
		{
			SetAlignment(TextAlignmentOptions.MidlineRight);
		}

		private void OnTextChanged(string text)
		{
			_behaviour.Configuration.Text = text;
			_behaviour.NotifyConfigurationChanged();
		}

		private void OnTextSelected(string _)
		{
			InputSystem.DisableDevice(Keyboard.current);
		}

		private void OnTextDeselected(string _)
		{
			InputSystem.EnableDevice(Keyboard.current);
		}
	}
}
