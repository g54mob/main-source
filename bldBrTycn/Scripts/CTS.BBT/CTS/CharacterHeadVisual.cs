using UnityEngine;

namespace CTS
{
	public class CharacterHeadVisual : MonoBehaviour
	{
		[SerializeField]
		private MeshRenderer _hairRenderer;

		[SerializeField]
		private MeshFilter _hairFilter;

		[SerializeField]
		private SkinnedMeshRenderer _skinnedMesh;

		public void SetHair(MeshAndMaterial meshAndMaterial)
		{
			if (Application.isPlaying)
			{
				_hairRenderer.material = meshAndMaterial.material;
				_hairFilter.mesh = meshAndMaterial.mesh;
			}
			else
			{
				_hairRenderer.sharedMaterial = meshAndMaterial.material;
				_hairFilter.sharedMesh = meshAndMaterial.mesh;
			}
			SetMaterial(2, meshAndMaterial.material);
		}

		public void SetSkinMaterial(Material material)
		{
			SetMaterial(0, material);
		}

		public void SetEyesMaterial(Material material)
		{
			SetMaterial(1, material);
		}

		private void SetMaterial(int index, Material material)
		{
			Material[] array = ((!Application.isPlaying) ? _skinnedMesh.sharedMaterials : _skinnedMesh.materials);
			array[index] = material;
			if (Application.isPlaying)
			{
				_skinnedMesh.materials = array;
			}
			else
			{
				_skinnedMesh.sharedMaterials = array;
			}
		}

		public void SetBlendshape(MeshBlendShape blendshape)
		{
			for (int i = 0; i < blendshape.blendshapes.Length; i++)
			{
				if (blendshape.blendshapes[i].key == "VampTeethOff")
				{
					_skinnedMesh.SetBlendShapeWeight(4, blendshape.blendshapes[i].value);
				}
				else if (blendshape.blendshapes[i].key == "VampEars")
				{
					_skinnedMesh.SetBlendShapeWeight(5, blendshape.blendshapes[i].value);
				}
			}
		}

		public void ClearHair()
		{
			_hairRenderer.material = null;
			_hairFilter.mesh = null;
		}
	}
}
