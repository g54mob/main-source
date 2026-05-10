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

		public string name;

		[SerializeField]
		public Type type;

		public bool workOnce;

		private bool worked;

		[Range(0f, 1f)]
		public double position;

		[SerializeField]
		public bool enabled;

		[SerializeField]
		public Color color;

		[SerializeField]
		[HideInInspector]
		public TriggerEvent onCross;

		public SplineTrigger(Type t)
		{
		}

		public void AddListener(UnityAction<SplineUser> action)
		{
		}

		public void AddListener(UnityAction action)
		{
		}

		public void RemoveListener(UnityAction<SplineUser> action)
		{
		}

		public void RemoveAllListeners()
		{
		}

		public void Reset()
		{
		}

		public bool Check(double previousPercent, double currentPercent)
		{
			return false;
		}

		public void Invoke(SplineUser user = null)
		{
		}
	}
}
