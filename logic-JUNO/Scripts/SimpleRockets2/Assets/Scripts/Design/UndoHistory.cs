using System.Collections.Generic;
using System.Xml.Linq;

namespace Assets.Scripts.Design
{
	public class UndoHistory
	{
		private const int MaxUndoSteps = 100;

		private static List<UndoStep> _history = new List<UndoStep>();

		private static string _lastIgnoreKey = null;

		private static int _undoPosition = -1;

		public bool Enabled { get; set; }

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

		public UndoHistory()
		{
			Enabled = true;
		}

		public UndoStep GetNextRedoStep()
		{
			_lastIgnoreKey = null;
			if (_undoPosition < _history.Count - 1)
			{
				_undoPosition++;
				return _history[_undoPosition];
			}
			return null;
		}

		public UndoStep GetNextUndoStep()
		{
			_lastIgnoreKey = null;
			if (_undoPosition > 0)
			{
				_undoPosition--;
				return _history[_undoPosition];
			}
			return null;
		}

		public void PushUndo(UndoStep undoStep, string ignoreKey = null)
		{
			if (!Enabled || (ignoreKey != null && ignoreKey == _lastIgnoreKey))
			{
				return;
			}
			_lastIgnoreKey = ignoreKey;
			PruneUndoHistoryAtCurrentPosition();
			if (_history.Count > 0 && _undoPosition >= 0)
			{
				UndoStep undoStep2 = _history[_undoPosition];
				if (XNode.DeepEquals(undoStep2.Xml, undoStep.Xml))
				{
					return;
				}
				if (undoStep2.IsHead && undoStep.IsHead)
				{
					_history[_undoPosition] = undoStep;
					return;
				}
			}
			if (_undoPosition >= 100)
			{
				_history.RemoveAt(0);
				_history.Add(undoStep);
			}
			else
			{
				_undoPosition++;
				_history.Add(undoStep);
			}
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
				int count = _history.Count - num;
				_history.RemoveRange(num, count);
			}
		}
	}
}
