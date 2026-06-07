using System;
using System.Collections.Generic;

namespace Assets.Scripts.Ui
{
	public class UndoHistory<T> where T : class, IUndoStep
	{
		private List<T> _history = new List<T>();

		private string _lastIgnoreKey;

		private int _undoPosition = -1;

		public T CurrentUndoStep
		{
			get
			{
				if (_undoPosition >= 0 && _undoPosition < _history.Count)
				{
					return _history[_undoPosition];
				}
				return null;
			}
			set
			{
				int num = _history.IndexOf(value);
				if (num >= 0 && num < _history.Count)
				{
					_undoPosition = num;
					RaiseChangedEvent();
					return;
				}
				throw new InvalidOperationException("Unable to find specified undo step in undo history.");
			}
		}

		public bool Enabled { get; set; }

		public int MaxUndoSteps { get; }

		public int NumUndoSteps => _history.Count;

		public bool RedoStepsAvailable
		{
			get
			{
				if (Enabled)
				{
					return _undoPosition < _history.Count - 1;
				}
				return false;
			}
		}

		public IReadOnlyList<T> UndoSteps => _history;

		public bool UndoStepsAvailable
		{
			get
			{
				if (Enabled)
				{
					return _undoPosition > 0;
				}
				return false;
			}
		}

		public event EventHandler Changed;

		public UndoHistory(int maxUndoSteps)
		{
			MaxUndoSteps = maxUndoSteps;
			Enabled = true;
		}

		public void Clear()
		{
			_history.Clear();
			_undoPosition = -1;
			RaiseChangedEvent();
		}

		public T GetNextRedoStep()
		{
			_lastIgnoreKey = null;
			if (_undoPosition < _history.Count - 1)
			{
				_undoPosition++;
				return _history[_undoPosition];
			}
			return null;
		}

		public T GetNextUndoStep()
		{
			_lastIgnoreKey = null;
			if (_undoPosition > 0)
			{
				_undoPosition--;
				return _history[_undoPosition];
			}
			return null;
		}

		public void PushUndo(T undoStep, string ignoreKey = null)
		{
			if (!Enabled || (ignoreKey != null && ignoreKey == _lastIgnoreKey))
			{
				return;
			}
			_lastIgnoreKey = ignoreKey;
			PruneUndoHistoryAtCurrentPosition();
			if (_history.Count > 0 && _undoPosition >= 0)
			{
				T val = _history[_undoPosition];
				if (val.DeepEquals(undoStep))
				{
					return;
				}
				if (val.IsHead && undoStep.IsHead)
				{
					_history[_undoPosition] = undoStep;
					RaiseChangedEvent();
					return;
				}
			}
			if (_undoPosition >= MaxUndoSteps)
			{
				_history.RemoveAt(0);
				_history.Add(undoStep);
			}
			else
			{
				_undoPosition++;
				_history.Add(undoStep);
			}
			RaiseChangedEvent();
		}

		public bool ShouldPushUndo(string ignoreKey)
		{
			if (Enabled)
			{
				if (ignoreKey != null)
				{
					return ignoreKey != _lastIgnoreKey;
				}
				return true;
			}
			return false;
		}

		private void PruneUndoHistoryAtCurrentPosition()
		{
			if (_undoPosition >= 0)
			{
				int num = _undoPosition + 1;
				int num2 = _history.Count - num;
				_history.RemoveRange(num, num2);
				if (num2 > 0)
				{
					RaiseChangedEvent();
				}
			}
		}

		private void RaiseChangedEvent()
		{
			this.Changed?.Invoke(this, new EventArgs());
		}
	}
}
