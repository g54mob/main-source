using System;
using System.Collections.Generic;
using UnityEngine;

namespace FluffyUnderware.Curvy.Generator
{
	[Serializable]
	public class CGGameObjectResourceCollection : ICGResourceCollection
	{
		public List<Transform> Items;

		public List<string> PoolNames;

		public int Count => 0;

		public Component[] ItemsArray => null;
	}
}
