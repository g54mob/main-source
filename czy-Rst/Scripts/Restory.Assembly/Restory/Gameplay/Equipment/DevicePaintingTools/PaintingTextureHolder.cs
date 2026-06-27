using Mandragora.PWS;
using Restory.Data.Elements;
using UnityEngine;

namespace Restory.Gameplay.Equipment.DevicePaintingTools
{
	public class PaintingTextureHolder : MonoBehaviour
	{
		[SerializeField]
		private MeshFilter meshFilter;

		[SerializeField]
		private MeshRendererMaterialsInstantiator materialsInstantiator;

		[SerializeField]
		private PaintingTextureHolderSettings settings;

		private Texture2D paintingTexture;

		private Texture2D paintableAreaMaskTexture;

		private int textureShaderPropertyIndex;

		private Mesh sharedMesh;

		public Mesh SharedMesh => sharedMesh;

		public Texture2D PaintingTexture => paintingTexture;

		public Texture2D PaintableAreaMaskTexture => paintableAreaMaskTexture;

		private void Reset()
		{
			TryGetComponent<MeshRendererMaterialsInstantiator>(out materialsInstantiator);
			TryGetComponent<MeshFilter>(out meshFilter);
		}

		private void Awake()
		{
			SetShaderTexturePropertyIndex();
			sharedMesh = meshFilter.sharedMesh;
		}

		public void SetNewMaskTexture(Texture2D newTexture)
		{
			paintableAreaMaskTexture = newTexture;
		}

		public void SetNewWorkTexture(Texture2D newTexture)
		{
			paintingTexture = newTexture;
			foreach (Material materialInstance in materialsInstantiator.MaterialInstances)
			{
				if (!(materialInstance.shader != settings.ShaderToPaint))
				{
					materialInstance.SetTexture(textureShaderPropertyIndex, newTexture);
				}
			}
		}

		private void SetShaderTexturePropertyIndex()
		{
			textureShaderPropertyIndex = Shader.PropertyToID(settings.PaintingTextureShaderProperty);
		}
	}
}
