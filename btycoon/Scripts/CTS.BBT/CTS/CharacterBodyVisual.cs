using UnityEngine;

namespace CTS
{
	public class CharacterBodyVisual : MonoBehaviour
	{
		[SerializeField]
		private SkinnedMeshRenderer _skinnedMesh;

		public Mesh GetCurrentMesh => _skinnedMesh.sharedMesh;

		public Material[] GetCurrentMaterials => _skinnedMesh.materials;

		public void SetBodySet(BodySet bodySet)
		{
			_skinnedMesh.sharedMesh = bodySet.mesh;
			for (int i = 0; i < bodySet.materialBodySets.Length; i++)
			{
				switch (bodySet.materialBodySets[i].bodyPart)
				{
				case EBodyMaterial.Top:
					SetMaterial(1, bodySet.materialBodySets[i].material);
					break;
				case EBodyMaterial.Bottom:
					SetMaterial(2, bodySet.materialBodySets[i].material);
					break;
				case EBodyMaterial.Shoes:
					SetMaterial(3, bodySet.materialBodySets[i].material);
					break;
				case EBodyMaterial.FullBody:
					SetMaterial(1, bodySet.materialBodySets[i].material);
					SetMaterial(2, bodySet.materialBodySets[i].material);
					break;
				}
			}
		}

		public void SetSkinMaterial(Material material)
		{
			SetMaterial(0, material);
		}

		public void SetTopMaterial(Material material)
		{
			SetMaterial(1, material);
		}

		public void SetBottomMaterial(Material material)
		{
			SetMaterial(2, material);
		}

		public void SetShoesMaterial(Material material)
		{
			SetMaterial(3, material);
		}

		public void SetFullBodyMaterial(Material material)
		{
			SetMaterial(1, material);
			SetMaterial(2, material);
		}

		public void SetShoesNBottomMaterial(Material material)
		{
			SetMaterial(2, material);
			SetMaterial(3, material);
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
	}
}
