using UnityEngine;

namespace UMA.Examples
{
	[ExecuteInEditMode]
	public class EnvPreset : MonoBehaviour
	{
		public Material skyboxMaterial;

		public float ambientIntensity;

		public float growthIndirectScale;

		public float growthIndirectDirection;

		public float growthDirectOcclusionBoost;

		public bool forceProbes;

		private void OnEnable()
		{
		}
	}
}
