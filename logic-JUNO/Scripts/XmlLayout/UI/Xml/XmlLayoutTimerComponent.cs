using System;
using System.Collections.Generic;
using UnityEngine;

namespace UI.Xml
{
	public class XmlLayoutTimerComponent : MonoBehaviour
	{
		public List<DelayedAction> delayedActions = new List<DelayedAction>();

		public bool IsFirstFrame { get; private set; }

		private void Awake()
		{
			IsFirstFrame = true;
		}

		public void DelayedCall(float delay, Action action, MonoBehaviour target, bool forceEvenIfTargetIsInactive)
		{
			delayedActions.Add(new DelayedAction
			{
				timeToExecute = Time.unscaledTime + delay,
				action = action,
				target = target,
				forceEvenIfTargetIsInactive = forceEvenIfTargetIsInactive
			});
		}

		private void Update()
		{
			List<DelayedAction> list = null;
			foreach (DelayedAction delayedAction in delayedActions)
			{
				if (Time.unscaledTime >= delayedAction.timeToExecute)
				{
					if (list == null)
					{
						list = new List<DelayedAction>();
					}
					list.Add(delayedAction);
				}
			}
			if (list == null || list.Count == 0)
			{
				return;
			}
			foreach (DelayedAction item in list)
			{
				try
				{
					if (item.forceEvenIfTargetIsInactive || (item.target != null && item.target.gameObject.activeInHierarchy))
					{
						item.action();
					}
				}
				finally
				{
					delayedActions.Remove(item);
				}
			}
			if (IsFirstFrame)
			{
				IsFirstFrame = false;
			}
		}
	}
}
