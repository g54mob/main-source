using System;
using Commands;
using Data.Variables;
using Presentation.UI.Buttons;
using UnityEngine;

namespace Presentation.UI.HUD
{
	public class UndoRedoButton : MonoBehaviour
	{
		[SerializeField]
		private CommandManager _commandManager;

		[SerializeField]
		private ButtonEnabler _button;

		[SerializeField]
		private BoolVariableSO _factoryFloorActionsEnabled;

		[SerializeField]
		private bool _isRedo;

		private CommandManagerUndoStack _stack;

		private void Awake()
		{
			_stack = (_isRedo ? _commandManager.UnDoneCommands : _commandManager.Commands);
		}

		private void OnEnable()
		{
			CommandManagerUndoStack stack = _stack;
			stack.OnStackSizeUpdated = (Action<int>)Delegate.Combine(stack.OnStackSizeUpdated, new Action<int>(OnStackSizeUpdated));
			_factoryFloorActionsEnabled.ValueChanged += OnFactoryActionsChanged;
			_button.Button.onClick.AddListener(OnButtonClicked);
			UpdateButtonInteractable();
		}

		private void OnDisable()
		{
			CommandManagerUndoStack stack = _stack;
			stack.OnStackSizeUpdated = (Action<int>)Delegate.Remove(stack.OnStackSizeUpdated, new Action<int>(OnStackSizeUpdated));
			_factoryFloorActionsEnabled.ValueChanged -= OnFactoryActionsChanged;
			_button.Button.onClick.RemoveListener(OnButtonClicked);
		}

		private void UpdateButtonInteractable()
		{
			_button.Interactable = _stack.Count > 0 && _factoryFloorActionsEnabled.Value;
		}

		private void OnStackSizeUpdated(int _)
		{
			UpdateButtonInteractable();
		}

		private void OnFactoryActionsChanged(bool _)
		{
			UpdateButtonInteractable();
		}

		private void OnButtonClicked()
		{
			if (_isRedo)
			{
				_commandManager.ReDoLastCommand();
			}
			else
			{
				_commandManager.UnDoLastCommand();
			}
		}
	}
}
