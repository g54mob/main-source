using System;
using System.Runtime.CompilerServices;
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
		public UnityEvent onCross;

		public event Action<SplineUser> onUserCross
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public SplineTrigger(Type t)
		{
		}

		public void AddListener(UnityAction action)
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
