using System;
using UnityEngine;

namespace Coffee.UIParticleInternal
{
	internal static class MaterialRepository
	{
		private static readonly ObjectRepository<Material> s_Repository;

		public static int count => 0;

		public static bool Valid(Hash128 hash, Material material)
		{
			return false;
		}

		public static void Get(Hash128 hash, ref Material material, Func<Material> onCreate)
		{
		}

		public static void Get(Hash128 hash, ref Material material, string shaderName)
		{
		}

		public static void Get(Hash128 hash, ref Material material, string shaderName, string[] keywords)
		{
		}

		public static void Get<T>(Hash128 hash, ref Material material, Func<T, Material> onCreate, T source)
		{
		}

		public static void Release(ref Material material)
		{
		}
	}
}
