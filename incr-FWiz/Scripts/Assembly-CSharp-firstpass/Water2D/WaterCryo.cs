using System;
using UnityEngine;
using UnityEngine.Events;

namespace Water2D
{
	[Serializable]
	public class WaterCryo<T> where T : IEquatable<T>
	{
		[SerializeField]
		private T _value;

		public UnityAction onValueChanged;

		[SerializeField]
		public T value
		{
			get
			{
				return default(T);
			}
			set
			{
			}
		}

		public WaterCryo(T value, UnityAction onValueChanged)
		{
		}

		public WaterCryo(T value)
		{
		}

		public WaterCryo()
		{
		}
	}
}
