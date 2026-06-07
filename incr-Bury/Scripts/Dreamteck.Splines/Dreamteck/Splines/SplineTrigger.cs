using System;
using UnityEngine;
using UnityEngine.Events;

namespace Dreamteck.Splines
{
	[Serializable]
	public class SplineTrigger
	{
		public enum Type
		{
			Double = 0,
			Forward = 1,
			Backward = 2
		}

		[Serializable]
		public class TriggerEvent : UnityEvent<SplineUser>
		{
		}

		public string name = "Trigger";

		[SerializeField]
		public Type type;

		public bool workOnce;

		private bool worked;

		[Range(0f, 1f)]
		public double position = 0.5;

		[SerializeField]
		public bool enabled = true;

		[SerializeField]
		public Color color = Color.white;

		[SerializeField]
		[HideInInspector]
		public TriggerEvent onCross = new TriggerEvent();

		public SplineTrigger(Type t)
		{
			type = t;
			enabled = true;
			onCross = new TriggerEvent();
		}

		public void AddListener(UnityAction<SplineUser> action)
		{
			onCross.AddListener(action);
		}

		public void AddListener(UnityAction action)
		{
			UnityAction<SplineUser> call = delegate
			{
				action();
			};
			onCross.AddListener(call);
		}

		public void RemoveListener(UnityAction<SplineUser> action)
		{
			onCross.RemoveListener(action);
		}

		public void RemoveAllListeners()
		{
			onCross.RemoveAllListeners();
		}

		public void Reset()
		{
			worked = false;
		}

		public bool Check(double previousPercent, double currentPercent)
		{
			if (!enabled)
			{
				return false;
			}
			if (workOnce && worked)
			{
				return false;
			}
			bool flag = false;
			switch (type)
			{
			case Type.Double:
				flag = (previousPercent <= position && currentPercent >= position) || (currentPercent <= position && previousPercent >= position);
				break;
			case Type.Forward:
				flag = previousPercent <= position && currentPercent >= position;
				break;
			case Type.Backward:
				flag = currentPercent <= position && previousPercent >= position;
				break;
			}
			if (flag)
			{
				worked = true;
			}
			return flag;
		}

		public void Invoke(SplineUser user = null)
		{
			onCross.Invoke(user);
		}
	}
}
