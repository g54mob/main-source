using System;
using System.Collections.Generic;
using CTS.Core;
using CTS.UI;
using UnityEngine;

namespace CTS
{
	public static class HighlightButton
	{
		private class HighlightMachine
		{
			private ISelectable _selectable;

			public void Setup(ISelectable selectable)
			{
				_selectable = selectable;
				RectTransform rectTransform = (RectTransform)_selectable.Transform;
				_currentMachines[rectTransform] = this;
				_selectable.Pressed += OnSelectablePressed;
				CTSSingleton<Highlighter>.Instance.Highlight(rectTransform);
			}

			public void Reset()
			{
				_selectable.Pressed -= OnSelectablePressed;
				RectTransform rectTransform = (RectTransform)_selectable.Transform;
				_currentMachines.Remove(rectTransform);
				CTSSingleton<Highlighter>.Instance.StopHighlight(rectTransform);
				_selectable = null;
				_machinePool.Push(this);
			}

			private void OnSelectablePressed()
			{
				Reset();
			}
		}

		private static readonly Dictionary<RectTransform, HighlightMachine> _currentMachines;

		private static readonly Stack<HighlightMachine> _machinePool;

		static HighlightButton()
		{
			_currentMachines = new Dictionary<RectTransform, HighlightMachine>();
			_machinePool = new Stack<HighlightMachine>();
			Highlighter.StoppedHighlighting -= OnObjectStoppedHighlight;
			Highlighter.StoppedHighlighting += OnObjectStoppedHighlight;
		}

		private static void OnObjectStoppedHighlight(RectTransform obj)
		{
			if (_currentMachines.TryGetValue(obj, out var value))
			{
				value.Reset();
			}
		}

		private static HighlightMachine GetMachine()
		{
			if (_machinePool.Count > 0)
			{
				return _machinePool.Pop();
			}
			return new HighlightMachine();
		}

		public static void Highlight(StringKey buttonKey)
		{
			if (!buttonKey.IsValid())
			{
				throw new Exception("String key isn't valid");
			}
			if (CTSSelectable.TryGet(buttonKey, out var controller))
			{
				RectTransform rectTransform = (RectTransform)controller.Transform;
				if (!CTSSingleton<Highlighter>.Instance.IsHighlighted(rectTransform))
				{
					GetMachine().Setup(controller);
				}
			}
		}
	}
}
