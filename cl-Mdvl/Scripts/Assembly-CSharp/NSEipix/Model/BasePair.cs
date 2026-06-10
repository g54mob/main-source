using System;
using UnityEngine;

namespace NSEipix.Model
{
	[Serializable]
	public class BasePair<T, M>
	{
		[SerializeField]
		private T key;

		[SerializeField]
		private M value;

		public T Key => key;

		public M Value => value;

		public BasePair()
		{
		}

		public BasePair(T key, M value)
		{
			this.key = key;
			this.value = value;
		}
	}
}
