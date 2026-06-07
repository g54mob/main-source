using System.Collections.Generic;
using UnityEngine;

namespace DV.HUD
{
	public class ScrollableTimerUtil : MonoBehaviour
	{
		public class FloatHolder
		{
			public float value;
		}

		public Dictionary<IScrollable, FloatHolder> timerDictionary = new Dictionary<IScrollable, FloatHolder>();

		private Queue<IScrollable> removeQueue = new Queue<IScrollable>();

		private void Update()
		{
			foreach (KeyValuePair<IScrollable, FloatHolder> item in timerDictionary)
			{
				if (item.Key == null)
				{
					removeQueue.Enqueue(item.Key);
					continue;
				}
				item.Value.value -= Time.deltaTime;
				if (item.Value.value < 0f)
				{
					item.Key.Scroll(ScrollAction.Release, ScrollSource.HUD);
					removeQueue.Enqueue(item.Key);
				}
			}
			while (removeQueue.Count > 0)
			{
				timerDictionary.Remove(removeQueue.Dequeue());
			}
		}

		public void MoveScrollable(IScrollable scrollable, int notches)
		{
			if (notches == 0)
			{
				return;
			}
			for (int i = 0; i < Mathf.Abs(notches); i++)
			{
				if (notches > 0)
				{
					scrollable.Scroll(ScrollAction.ScrollUp, ScrollSource.HUD);
				}
				else
				{
					scrollable.Scroll(ScrollAction.ScrollDown, ScrollSource.HUD);
				}
			}
			if (!timerDictionary.TryGetValue(scrollable, out var value))
			{
				value = (timerDictionary[scrollable] = new FloatHolder());
			}
			value.value = 0.3f;
		}
	}
}
