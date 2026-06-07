using System;
using UnityEngine;
using UnityEngine.Events;

namespace Dreamteck.Splines
{
	[AddComponentMenu("Dreamteck/Splines/Users/Length Calculator")]
	public class LengthCalculator : SplineUser
	{
		[Serializable]
		public class LengthEvent
		{
			public enum Type
			{
				Growing = 0,
				Shrinking = 1,
				Both = 2
			}

			public bool enabled;

			public float targetLength;

			public UnityEvent onChange;

			public Type type;

			public LengthEvent()
			{
			}

			public LengthEvent(Type t)
			{
			}

			public void Check(float fromLength, float toLength)
			{
			}
		}

		[HideInInspector]
		public LengthEvent[] lengthEvents;

		[HideInInspector]
		public float idealLength;

		private float _length;

		private float lastLength;

		public float length => 0f;

		protected override void Awake()
		{
		}

		protected override void Build()
		{
		}

		public void AddEvent(LengthEvent lengthEvent)
		{
		}
	}
}
