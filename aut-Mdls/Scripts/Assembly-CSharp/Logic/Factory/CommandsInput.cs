using Commands;
using Events;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Logic.Factory
{
	public class CommandsInput : MonoBehaviour
	{
		[SerializeField]
		private InputActionReference _unDo;

		[SerializeField]
		private InputActionReference _reDo;

		[SerializeField]
		private CommandManager _commandManager;

		[SerializeField]
		private BaseEvent _startLoadingSaveEvent;

		private void Start()
		{
			_startLoadingSaveEvent.Register(ResetUndoRedoStack);
		}

		private void OnDestroy()
		{
			_startLoadingSaveEvent.UnRegister(ResetUndoRedoStack);
		}

		private void ResetUndoRedoStack()
		{
			_commandManager.ResetStack();
		}
	}
}
