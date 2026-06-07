using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Coffee.UIEffects
{
	public class MaterialCache
	{
		private class MaterialEntry
		{
			public Material material;

			public int referenceCount;

			public void Release()
			{
			}
		}

		private static Dictionary<Hash128, MaterialEntry> materialMap;

		public static Material Register(Material baseMaterial, Hash128 hash, Action<Material, Graphic> onModifyMaterial, Graphic graphic)
		{
			return null;
		}

		public static void Unregister(Hash128 hash)
		{
		}
	}
}
