using System;
using AwesomeTechnologies.VegetationSystem;
using UnityEngine.Rendering.PostProcessing;

namespace AwesomeTechnologies.VegetationStudio
{
	[Serializable]
	public class PostProcessProfileInfo
	{
		public bool Enabled = true;

		public PostProcessProfile PostProcessProfile;

		public BiomeType BiomeType = BiomeType.Biome1;

		public float BlendDistance;

		public float Weight = 1f;

		public float VolumeHeight = 20f;

		public float Priority;
	}
}
