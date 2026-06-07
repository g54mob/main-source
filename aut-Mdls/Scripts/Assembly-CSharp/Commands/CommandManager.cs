#define ENABLE_DEBUG_ERRORS
using Data.FeatureFlags.Validators;
using Data.Variables;
using Events;
using Presentation.Locators;
using UnityEngine;
using Utils;

namespace Commands
{
	[CreateAssetMenu(menuName = "General/CommandManager", fileName = "CommandManager", order = 0)]
	public class CommandManager : ScriptableObject
	{
		[SerializeField]
		private BaseEvent _selectToolButtonPressedEvent;

		[SerializeField]
		private CameraViewLocator _cameraViewLocator;

		[SerializeField]
		private AudioManagerLocator _audioManagerLocator;

		[SerializeField]
		private EnableUndoRedoValidator _undoRedoValidator;

		[SerializeField]
		private BaseEvent _onUndoEvent;

		[SerializeField]
		private BaseEvent _onRedoEvent;

		[SerializeField]
		private BoolVariableSO _undoRedoUnlockedSO;

		private readonly CommandManagerUndoStack _commands = new CommandManagerUndoStack();

		private readonly CommandManagerUndoStack _unDoneCommands = new CommandManagerUndoStack();

		public CommandManagerUndoStack Commands => _commands;

		public CommandManagerUndoStack UnDoneCommands => _unDoneCommands;

		private void OnEnable()
		{
			ResetStack();
		}

		public bool DoCommand(ICommand command)
		{
			if (!command.TryDo())
			{
				return false;
			}
			if (command is ICommandUndo command2)
			{
				_commands.Push(new CommandManagerUndoStack.Value(command2, _cameraViewLocator.CameraView));
			}
			_unDoneCommands.Clear();
			return true;
		}

		public void UnDoLastCommand()
		{
			if (!_undoRedoValidator.IsEnabledFeatureFlag() || !_undoRedoUnlockedSO.Value)
			{
				return;
			}
			if (_commands.Count <= 0)
			{
				_audioManagerLocator.AudioManager.PlayCantDoThat();
				return;
			}
			_audioManagerLocator.AudioManager.PlayUndo();
			CommandManagerUndoStack.Value value = _commands.Peek();
			if (!value.Command.TryUnDo())
			{
				this.LogError($"TryUnDo Failed: {value}", "UnDoLastCommand", 71);
				return;
			}
			_unDoneCommands.Push(_commands.Pop());
			_selectToolButtonPressedEvent.Fire();
			MoveCamera(value);
			_onUndoEvent.Fire();
		}

		public void ReDoLastCommand()
		{
			if (!_undoRedoValidator.IsEnabledFeatureFlag() || !_undoRedoUnlockedSO.Value)
			{
				return;
			}
			if (_unDoneCommands.Count <= 0)
			{
				_audioManagerLocator.AudioManager.PlayCantDoThat();
				return;
			}
			_audioManagerLocator.AudioManager.PlayRedo();
			CommandManagerUndoStack.Value value = _unDoneCommands.Peek();
			if (!value.Command.TryReDo())
			{
				this.LogError($"TryReDo Failed: {value}", "ReDoLastCommand", 103);
				return;
			}
			_commands.Push(_unDoneCommands.Pop());
			_selectToolButtonPressedEvent.Fire();
			MoveCamera(value);
			_onRedoEvent.Fire();
		}

		public void MoveCamera(CommandManagerUndoStack.Value value)
		{
			if (_cameraViewLocator.CameraView != null)
			{
				_cameraViewLocator.CameraView.LerpToTarget(value.CameraPosition, value.CameraZoomPercentage, value.CameraTargetYaw, value.CameraTargetPitch, blockInput: false);
			}
		}

		public void ResetStack()
		{
			_commands.Clear();
			_unDoneCommands.Clear();
		}
	}
}
