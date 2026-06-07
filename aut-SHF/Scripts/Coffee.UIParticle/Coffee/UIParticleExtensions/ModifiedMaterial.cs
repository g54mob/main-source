using System.Collections.Generic;
using UnityEngine;

namespace Coffee.UIParticleExtensions
{
	internal class ModifiedMaterial
	{
		private class MatEntry
		{
			public Material baseMat;

			public Material customMat;

			public int count;

			public Texture texture;

			public int id;
		}

		private static readonly List<MatEntry> s_Entries;

		public static Material Add(Material baseMat, Texture texture, int id)
		{
			return null;
		}

		public static void Remove(Material customMat)
		{
		}

		private static void DestroyImmediate(Object obj)
		{
		}
	}
}
