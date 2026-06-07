using UnityEngine;

namespace Gh
{
	public class ScrollUvs : MonoBehaviour
	{
		public enum MaterialPropertyType
		{
			TextureOffset = 0,
			Vector = 1
		}

		public MaterialPropertyType propertyType;

		public Vector2 uvAnimationRate;

		public string textureName;

		public MeshRenderer mr;

		public LineRenderer lr;

		public bool unscaledTime;

		public Material directMat;

		private Vector2 _uvOffset;

		public bool useSharedMat;

		public bool useMaterialPropertyBlockForNonSharedMats;

		private MaterialPropertyBlock _mpb;

		private void Start()
		{
		}

		private void LateUpdate()
		{
		}

		private void UpdateRenderer(Renderer renderer)
		{
		}

		public void UpdateMaterialProperty(Renderer renderer, string propertyName, MaterialPropertyType propertyType, Vector2 value)
		{
		}

		private void UpdateMaterialProperty(Material material, string propertyName, MaterialPropertyType propertyType, Vector2 value)
		{
		}
	}
}
