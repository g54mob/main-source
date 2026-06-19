using System;
using UnityEngine;

namespace OUSystems.Basics.DataStructures
{
	[Serializable]
	public class ValueContainer<T> where T : IEquatable<T>
	{
		[SerializeField]
		protected T _value;

		[NonSerialized]
		public Action<ValueUpdateData<T>> AnnounceUpdate;

		[NonSerialized]
		public Action<T> AnnounceValue;

		public virtual T Value
		{
			get
			{
				return default(T);
			}
			set
			{
			}
		}

		protected void SetValueToExact(T value)
		{
		}

		public ValueContainer()
		{
		}

		public ValueContainer(T value)
		{
		}

		public void Set(T value)
		{
		}

		public T Get()
		{
			return default(T);
		}

		public override string ToString()
		{
			return null;
		}
	}
}
