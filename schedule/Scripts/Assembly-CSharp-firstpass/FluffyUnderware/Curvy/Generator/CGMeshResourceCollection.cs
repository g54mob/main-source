using System;
using System.Collections.Generic;
using UnityEngine;

namespace FluffyUnderware.Curvy.Generator
{
	[Serializable]
	public class CGMeshResourceCollection : ICGResourceCollection
	{
		public List<CGMeshResource> Items;

		public int Count => 0;

		public Component[] ItemsArray => null;
	}
}
