using System.Collections.Generic;
using UnityEngine;

namespace Coffee.UIParticleExtensions
{
	internal class ModifiedMaterial
	{
		private class MatEntry
		{
			public Material baseMat;

			public int count;

			public Material customMat;

			public int id;

			public Texture texture;
		}

		private static readonly List<MatEntry> s_Entries = new List<MatEntry>();

		public static Material Add(Material baseMat, Texture texture, int id)
		{
			MatEntry matEntry;
			for (int i = 0; i < s_Entries.Count; i++)
			{
				matEntry = s_Entries[i];
				if (!(matEntry.baseMat != baseMat) && !(matEntry.texture != texture) && matEntry.id == id)
				{
					matEntry.count++;
					return matEntry.customMat;
				}
			}
			matEntry = new MatEntry
			{
				count = 1,
				baseMat = baseMat,
				texture = texture,
				id = id,
				customMat = new Material(baseMat)
				{
					name = $"{baseMat.name}_{id}",
					hideFlags = HideFlags.HideAndDontSave,
					mainTexture = (texture ? texture : null)
				}
			};
			s_Entries.Add(matEntry);
			return matEntry.customMat;
		}

		public static void Remove(Material customMat)
		{
			if (!customMat)
			{
				return;
			}
			for (int i = 0; i < s_Entries.Count; i++)
			{
				MatEntry matEntry = s_Entries[i];
				if (!(matEntry.customMat != customMat))
				{
					if (--matEntry.count == 0)
					{
						Misc.DestroyImmediate(matEntry.customMat);
						matEntry.customMat = null;
						matEntry.baseMat = null;
						matEntry.texture = null;
						s_Entries.RemoveAt(i);
					}
					break;
				}
			}
		}
	}
}
