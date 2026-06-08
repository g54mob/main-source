using System.Collections.Generic;
using UnityEngine;

namespace Dorfromantik
{
	public class Instanceable : MonoBehaviour, IRecyclable
	{
		[SerializeField]
		private RecyclableType recyclableType;

		[SerializeField]
		private MeshRenderer meshRenderer;

		[SerializeField]
		private Mesh mesh;

		[SerializeField]
		private Mesh lowQualityMesh;

		public bool instancingEnabled = true;

		public bool setSizeSeed;

		public SpawnBasedOnSeed spawnBasedOnSeed;

		public bool useUniformScale;

		public Vector3 minScale = Vector3.one;

		public Vector3 maxScale = Vector3.one;

		public List<CustomInstanceTexture> customTextures;

		public RecyclableType RecyclableId
		{
			get
			{
				return recyclableType;
			}
			set
			{
				recyclableType = value;
			}
		}

		public MeshRenderer MeshRenderer => meshRenderer;

		public GameObject GameObject => base.gameObject;

		private void OnValidate()
		{
			meshRenderer = GetComponent<MeshRenderer>();
			mesh = GetComponent<MeshFilter>().sharedMesh;
		}

		private void SetupBasedOn(ElementVisual elementVisual)
		{
			instancingEnabled = elementVisual.instancingEnabled;
			setSizeSeed = elementVisual.setSizeSeed;
			spawnBasedOnSeed = elementVisual.GetComponentInChildren<SpawnBasedOnSeed>();
			useUniformScale = elementVisual.useUniformScale;
			minScale = elementVisual.randomMinScale;
			maxScale = elementVisual.randomMaxScale;
			customTextures = elementVisual.CustomTextures;
		}

		public Mesh GetMesh(int meshQualityLevel)
		{
			if (!lowQualityMesh)
			{
				return mesh;
			}
			if (meshQualityLevel == 1)
			{
				return lowQualityMesh;
			}
			return mesh;
		}
	}
}
