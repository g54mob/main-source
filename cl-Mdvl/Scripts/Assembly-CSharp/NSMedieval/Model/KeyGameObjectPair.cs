using System;
using NSEipix.Model;
using UnityEngine;

namespace NSMedieval.Model
{
	[Serializable]
	public class KeyGameObjectPair : Pair<GameObject>
	{
		public KeyGameObjectPair(string id, GameObject value)
			: base(id, value)
		{
		}
	}
}
