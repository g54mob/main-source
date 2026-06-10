using System;
using NSEipix.Base;
using UnityEngine;

namespace NSEipix.Model
{
	[Serializable]
	public class Pair<T> : NSEipix.Base.Model
	{
		[SerializeField]
		private string id;

		[SerializeField]
		private T value;

		[SerializeField]
		private string key;

		public T Value => value;

		public Pair()
		{
		}

		public Pair(string id, T value)
		{
			this.id = id;
			this.value = value;
		}

		public void Reset(string id, T value)
		{
			this.id = id;
			this.value = value;
		}

		public override string GetID()
		{
			if (string.IsNullOrEmpty(id))
			{
				id = key;
			}
			return (id ?? string.Empty).ToString();
		}
	}
}
