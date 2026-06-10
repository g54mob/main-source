using System;
using NSEipix.Model;
using UnityEngine;

namespace NSMedieval.Model
{
	[Serializable]
	public class KeyObjectPair : Pair<UnityEngine.Object>
	{
		public KeyObjectPair(string id, UnityEngine.Object value)
			: base(id, value)
		{
		}
	}
}
