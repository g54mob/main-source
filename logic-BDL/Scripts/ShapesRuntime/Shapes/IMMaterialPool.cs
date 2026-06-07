using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Shapes
{
	internal static class IMMaterialPool
	{
		public static Dictionary<RenderState, Material> pool;

		static IMMaterialPool()
		{
			pool = new Dictionary<RenderState, Material>();
			SceneManager.sceneUnloaded += delegate
			{
				FlushAllMaterials();
			};
		}

		internal static Material GetMaterial(ref RenderState state)
		{
			if (!pool.TryGetValue(state, out var value))
			{
				pool.Add(state, value = state.CreateMaterial());
			}
			return value;
		}

		private static void FlushAllMaterials()
		{
			foreach (Material value in pool.Values)
			{
				if (value != null)
				{
					value.DestroyBranched();
				}
			}
			pool.Clear();
		}
	}
}
