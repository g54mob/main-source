using System;
using System.Collections.Generic;
using UnityEngine;

namespace Coffee.UISoftMask
{
	internal static class MaterialCache
	{
		private static readonly Dictionary<Hash128, MaterialEntry> s_MaterialMap;

		public static Material Register(Material material, Hash128 hash, Action<Material> onModify)
		{
			return null;
		}

		public static void Unregister(Hash128 hash)
		{
		}
	}
}
