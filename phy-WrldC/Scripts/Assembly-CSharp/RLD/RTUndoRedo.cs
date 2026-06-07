using System;
using System.Collections.Generic;
using UnityEngine;

namespace RLD
{
	public class RTUndoRedo : MonoSingleton<RTUndoRedo>
	{
		private class ActionGroup
		{
			public List<IUndoRedoAction> Actions = new List<IUndoRedoAction>();

			public ActionGroup(IUndoRedoAction action)
			{
				Actions.Add(action);
			}
		}

		[SerializeField]
		private bool _isEnabled = true;

		[SerializeField]
		private int _actionLimit = 50;

		private List<ActionGroup> _actionGroupStack = new List<ActionGroup>();

		private int _stackPointer = -1;

		public bool IsEnabled => _isEnabled;

		public int ActionLimit
		{
			get
			{
				return _actionLimit;
			}
			set
			{
				ClearActions();
				_actionLimit = Mathf.Max(value, 1);
			}
		}

		public event Action<int, int> OnStackChanged;

		public event UndoStartHandler UndoStart;

		public event UndoEndHandler UndoEnd;

		public event RedoStartHandler RedoStart;

		public event RedoEndHandler RedoEnd;

		public event CanUndoRedoHandler CanUndoRedo;

		public void SetEnabled(bool isEnabled)
		{
			_isEnabled = isEnabled;
		}

		public void ClearActions()
		{
			RemoveGroups(0, _actionGroupStack.Count);
			_stackPointer = -1;
			this.OnStackChanged?.Invoke(0, 0);
		}

		public void RecordAction(IUndoRedoAction action)
		{
			if (_isEnabled)
			{
				if (_actionGroupStack.Count != 0 && _stackPointer < _actionGroupStack.Count - 1)
				{
					int num = _stackPointer + 1;
					int count = _actionGroupStack.Count - num;
					RemoveGroups(num, count);
				}
				_actionGroupStack.Add(new ActionGroup(action));
				if (_actionGroupStack.Count > _actionLimit)
				{
					RemoveGroups(0, 1);
				}
				_stackPointer = _actionGroupStack.Count - 1;
				this.OnStackChanged?.Invoke(_stackPointer + 1, _actionGroupStack.Count - (_stackPointer + 1));
			}
		}

		public void Update_SystemCall()
		{
			if (!_isEnabled)
			{
				return;
			}
			if (!Application.isEditor)
			{
				if (Input.GetKeyDown(KeyCode.Z) && Input.GetKey(KeyCode.LeftControl))
				{
					Undo();
				}
				else if (Input.GetKeyDown(KeyCode.Y) && Input.GetKey(KeyCode.LeftControl))
				{
					Redo();
				}
			}
			else if (Input.GetKeyDown(KeyCode.Z) && Input.GetKey(KeyCode.LeftControl) && Input.GetKey(KeyCode.LeftShift))
			{
				Undo();
			}
			else if (Input.GetKeyDown(KeyCode.Y) && Input.GetKey(KeyCode.LeftControl) && Input.GetKey(KeyCode.LeftShift))
			{
				Redo();
			}
		}

		public void Undo()
		{
			if (!_isEnabled || _stackPointer < 0)
			{
				return;
			}
			ActionGroup actionGroup = _actionGroupStack[_stackPointer];
			YesNoAnswer yesNoAnswer = new YesNoAnswer();
			if (this.CanUndoRedo != null)
			{
				this.CanUndoRedo(UndoRedoOpType.Undo, yesNoAnswer);
			}
			if (yesNoAnswer.HasNo)
			{
				return;
			}
			_stackPointer--;
			foreach (IUndoRedoAction action in actionGroup.Actions)
			{
				if (this.UndoStart != null)
				{
					this.UndoStart(action);
				}
				action.Undo();
				if (this.UndoEnd != null)
				{
					this.UndoEnd(action);
				}
			}
			this.OnStackChanged?.Invoke(_stackPointer + 1, _actionGroupStack.Count - (_stackPointer + 1));
		}

		public void Redo()
		{
			if (!_isEnabled || _actionGroupStack.Count == 0 || _stackPointer == _actionGroupStack.Count - 1)
			{
				return;
			}
			ActionGroup actionGroup = _actionGroupStack[_stackPointer + 1];
			YesNoAnswer yesNoAnswer = new YesNoAnswer();
			if (this.CanUndoRedo != null)
			{
				this.CanUndoRedo(UndoRedoOpType.Redo, yesNoAnswer);
			}
			if (yesNoAnswer.HasNo)
			{
				return;
			}
			_stackPointer++;
			foreach (IUndoRedoAction action in actionGroup.Actions)
			{
				if (this.RedoStart != null)
				{
					this.RedoStart(action);
				}
				action.Redo();
				if (this.RedoEnd != null)
				{
					this.RedoEnd(action);
				}
			}
			this.OnStackChanged?.Invoke(_stackPointer + 1, _actionGroupStack.Count - (_stackPointer + 1));
		}

		private void RemoveGroups(int startIndex, int count)
		{
			List<ActionGroup> range = _actionGroupStack.GetRange(startIndex, count);
			_actionGroupStack.RemoveRange(startIndex, count);
			foreach (ActionGroup item in range)
			{
				foreach (IUndoRedoAction action in item.Actions)
				{
					action.OnRemovedFromUndoRedoStack();
				}
			}
		}

		private void OnValidate()
		{
			ActionLimit = ActionLimit;
		}
	}
}
