using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using VampireSurvivors.Data;
using Zenject;

namespace VampireSurvivors.Graphics
{
	[UsedImplicitly]
	public class MaterialManager : IInitializable
	{
		private static readonly Dictionary<MaterialType, Material> MaterialsCache;

		public void Initialize()
		{
		}

		public static Material GetMaterial(MaterialType type)
		{
			return null;
		}

		private static void LoadAllMaterials()
		{
		}
	}
}
