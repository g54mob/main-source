using System;
using System.Collections.Generic;
using ModApi.Craft;
using UnityEngine;

namespace Assets.Scripts.Craft
{
	public class DragQueue
	{
		private DragCalculatorScript _dragCalculator;

		private bool _processing;

		private List<IBodyScript> _queue;

		public DragQueue(DragCalculatorScript dragCalculator)
		{
			_dragCalculator = dragCalculator;
			_queue = new List<IBodyScript>();
		}

		public void AddBody(IBodyScript bodyScript)
		{
			bodyScript.UnloadedFromGameView += OnBodyScriptUnloaded;
			_queue.Add(bodyScript);
		}

		public void Update()
		{
			if (_processing || _queue.Count <= 0)
			{
				return;
			}
			_processing = true;
			IBodyScript bodyScript = _queue[0];
			_queue.RemoveAt(0);
			if (!bodyScript.Data.IsDestroyed)
			{
				try
				{
					_dragCalculator.CalculateDrag(bodyScript, delegate(DragCalculatorScript.DragResult r)
					{
						OnComplete(bodyScript, r);
					});
					return;
				}
				catch (Exception message)
				{
					_processing = false;
					Debug.LogError(message);
					return;
				}
			}
			_processing = false;
		}

		private void OnBodyScriptUnloaded(IBodyScript bodyScript)
		{
			bodyScript.UnloadedFromGameView -= OnBodyScriptUnloaded;
			_queue.Remove(bodyScript);
		}

		private void OnComplete(IBodyScript bodyScript, DragCalculatorScript.DragResult result)
		{
			try
			{
				BodyScript bodyScript2 = bodyScript as BodyScript;
				if (bodyScript2 != null)
				{
					if (result != null)
					{
						bodyScript2.CalculateDrag();
					}
					bodyScript2.UnloadedFromGameView -= OnBodyScriptUnloaded;
				}
			}
			finally
			{
				_processing = false;
			}
		}
	}
}
