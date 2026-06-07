using System;
using UnityEngine;

namespace PajamaLlama.Flotsam.World
{
	[Serializable]
	public class WorldRegionProperties
	{
		public WorldRegionType Region;

		[Header("Visual")]
		public Material LandmarkMaterial;
	}
}
