using System.Linq;
using UnityEngine;

namespace Assets.Scripts.Terrain
{
	public static class PlanetMeshes
	{
		public enum PlanetMeshQuality
		{
			Low = 0,
			Medium = 1,
			High = 2,
			Ultra = 3
		}

		private static bool _initialized;

		private static Mesh[] _meshes;

		public static Mesh MeshQualityUltra { get; private set; }

		public static Mesh MeshQualityHigh { get; private set; }

		public static Mesh MeshQualityLow { get; private set; }

		public static Mesh MeshQualityMedium { get; private set; }

		public static Mesh GetMesh(PlanetMeshQuality quality)
		{
			return _meshes[(int)quality];
		}

		public static void Initialize()
		{
			if (!_initialized)
			{
				_initialized = true;
				MeshQualityUltra = Resources.LoadAll<Mesh>("Planets/AtmosphereMeshUltra").FirstOrDefault();
				Mesh[] source = Resources.LoadAll<Mesh>("Planets/PlanetMesh");
				MeshQualityHigh = source.First((Mesh m) => m.name == "Icosphere");
				MeshQualityMedium = source.First((Mesh m) => m.name == "Icosphere.Medium");
				MeshQualityLow = source.First((Mesh m) => m.name == "Icosphere.Low");
				_meshes = new Mesh[4] { MeshQualityLow, MeshQualityMedium, MeshQualityHigh, MeshQualityUltra };
			}
		}
	}
}
