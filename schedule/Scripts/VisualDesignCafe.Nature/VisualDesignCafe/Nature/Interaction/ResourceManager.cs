using System.Collections.Generic;
using UnityEngine;

namespace VisualDesignCafe.Nature.Interaction
{
	internal class ResourceManager
	{
		private static List<Object> _objectsToDestroy;

		private static Dictionary<PrimitiveType, Mesh> _meshLookup;

		public static Mesh GetPrimitiveMesh(PrimitiveType type)
		{
			return null;
		}

		public static void Destroy(Object obj)
		{
		}

		internal static void DestroyPending()
		{
		}
	}
}
