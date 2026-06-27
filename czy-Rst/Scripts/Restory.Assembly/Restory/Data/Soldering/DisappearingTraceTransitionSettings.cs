using System;
using UnityEngine;

namespace Restory.Data.Soldering
{
	[Serializable]
	public class DisappearingTraceTransitionSettings
	{
		[SerializeField]
		[Range(0f, 3f)]
		private float transformationDurationInSeconds = 1f;

		[SerializeField]
		[Range(0.5f, 3f)]
		private float disappearingDurationInSeconds = 2f;

		[SerializeField]
		private Material disappearingMaterial;

		[SerializeField]
		private string baseColorPropertyName = "_BaseColor";

		[Space]
		[SerializeField]
		private string metallicPropertyName = "_Metallic";

		[SerializeField]
		private float metallicTarget = 0.05f;

		[Space]
		[SerializeField]
		private string noiseOpacityPropertyName = "_NoiseOpacity";

		[SerializeField]
		private float noiseOpacityTarget;

		[Space]
		[SerializeField]
		private string noiseTilePropertyName = "_NoiseTile";

		[SerializeField]
		private float noiseTileTarget;

		[Space]
		[SerializeField]
		private string normalTilePropertyName = "_NormalTile";

		[SerializeField]
		private float normalTileTarget = 0.2f;

		[Space]
		[SerializeField]
		private string normalSpeedPropertyName = "_NormalSpeed";

		[SerializeField]
		private float normalSpeedTarget;

		public float TransformationDurationInSeconds => transformationDurationInSeconds;

		public float DisappearingDurationInSeconds => disappearingDurationInSeconds;

		public Material DisappearingMaterial => disappearingMaterial;

		public int BaseColorProperty => Shader.PropertyToID(baseColorPropertyName);

		public int MetallicProperty => Shader.PropertyToID(metallicPropertyName);

		public float MetallicTarget => metallicTarget;

		public int NoiseOpacityProperty => Shader.PropertyToID(noiseOpacityPropertyName);

		public float NoiseOpacityTarget => noiseOpacityTarget;

		public int NoiseTileProperty => Shader.PropertyToID(noiseTilePropertyName);

		public float NoiseTileTarget => noiseTileTarget;

		public int NormalTileProperty => Shader.PropertyToID(normalTilePropertyName);

		public float NormalTileTarget => normalTileTarget;

		public int NormalSpeedProperty => Shader.PropertyToID(normalSpeedPropertyName);

		public float NormalSpeedTarget => normalSpeedTarget;
	}
}
