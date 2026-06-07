using UnityEngine;

namespace VLB
{
	public class Config : ScriptableObject
	{
		public bool geometryOverrideLayer;

		public int geometryLayerID;

		public string geometryTag;

		public int geometryRenderQueue;

		public bool forceSinglePass;

		[SerializeField]
		[HighlightNull]
		private Shader beamShader1Pass;

		[SerializeField]
		[HighlightNull]
		private Shader beamShader2Pass;

		public int sharedMeshSides;

		public int sharedMeshSegments;

		public float globalNoiseScale;

		public Vector3 globalNoiseVelocity;

		[HighlightNull]
		public TextAsset noise3DData;

		public int noise3DSize;

		[HighlightNull]
		public ParticleSystem dustParticlesPrefab;

		private static Config m_Instance;

		public Shader beamShader => null;

		public Vector4 globalNoiseParam => default(Vector4);

		public static Config Instance => null;

		public void Reset()
		{
		}

		public ParticleSystem NewVolumetricDustParticles()
		{
			return null;
		}
	}
}
