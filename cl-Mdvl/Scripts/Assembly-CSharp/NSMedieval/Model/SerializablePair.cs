using System;
using NSEipix.Base;
using UnityEngine;

namespace NSMedieval.Model
{
	[Serializable]
	public class SerializablePair<T, TK> : NSEipix.Base.Model
	{
		[SerializeField]
		private T key;

		[SerializeField]
		private TK value;

		public T Key => key;

		public TK Value => value;

		public SerializablePair()
		{
		}

		public SerializablePair(T key, TK value)
		{
			this.key = key;
			this.value = value;
		}

		public void SetValue(TK value)
		{
			this.value = value;
		}

		public override string GetID()
		{
			return key.ToString();
		}
	}
}
