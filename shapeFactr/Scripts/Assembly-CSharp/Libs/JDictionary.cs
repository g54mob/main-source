using System;
using System.Collections.Generic;
using UnityEngine;

namespace Libs
{
	[Serializable]
	public class JDictionary<TKey, TValue> : Dictionary<TKey, TValue>
	{
		[SerializeField]
		private List<TKey> keys;

		[SerializeField]
		private List<TValue> values;

		public string ToJson()
		{
			return null;
		}

		public void FromJson()
		{
		}
	}
}
