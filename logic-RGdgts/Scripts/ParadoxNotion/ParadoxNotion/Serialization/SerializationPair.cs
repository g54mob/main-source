using System;
using System.Collections.Generic;
using UnityEngine;

namespace ParadoxNotion.Serialization
{
	[Serializable]
	public sealed class SerializationPair
	{
		public string _json;

		public List<UnityEngine.Object> _references;
	}
}
