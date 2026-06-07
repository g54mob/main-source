using System;
using MalbersAnimations.Events;
using UnityEngine;

namespace MalbersAnimations.Utilities
{
	[Serializable]
	public class MaterialItem
	{
		public string Name;

		public Renderer mesh;

		public Material[] materials;

		public bool Linked;

		public int Master;

		public int current;

		public bool HasLODs;

		public Renderer[] LODs;

		[Tooltip("Material ID (Used when a mesh have multiple materials) Default 0")]
		public int indexM;

		public IntEvent OnMaterialChanged = new IntEvent();

		public MaterialItem()
		{
			Name = "NameHere";
			mesh = null;
			materials = new Material[0];
		}

		public MaterialItem(MeshRenderer MR)
		{
			Name = "NameHere";
			mesh = MR;
			materials = new Material[0];
		}

		public MaterialItem(string name, MeshRenderer MR, Material[] mats)
		{
			Name = name;
			mesh = MR;
			materials = mats;
		}

		public MaterialItem(string name, MeshRenderer MR)
		{
			Name = name;
			mesh = MR;
			materials = new Material[0];
		}

		public virtual void ChangeMaterial()
		{
			current++;
			if (current < 0)
			{
				current = 0;
			}
			current %= materials.Length;
			Material[] sharedMaterials = mesh.sharedMaterials;
			if (materials[current] != null)
			{
				sharedMaterials[indexM] = materials[current];
				mesh.sharedMaterials = sharedMaterials;
				ChangeLOD(current);
				OnMaterialChanged.Invoke(current);
			}
			else
			{
				Debug.LogWarning("The Material on the Slot: " + current + " is empty");
			}
		}

		public virtual void Set_by_BinaryIndex(int binaryCurrent)
		{
			int index = 0;
			for (int i = 0; i < materials.Length; i++)
			{
				if (MTools.IsBitActive(binaryCurrent, i))
				{
					index = i;
					break;
				}
			}
			ChangeMaterial(index);
		}

		internal void ChangeLOD(int index)
		{
			if (!HasLODs)
			{
				return;
			}
			Renderer[] lODs = LODs;
			foreach (Renderer renderer in lODs)
			{
				if (!(renderer == null))
				{
					Material[] sharedMaterials = renderer.sharedMaterials;
					sharedMaterials[indexM] = materials[current];
					if (materials[current] != null)
					{
						renderer.sharedMaterials = sharedMaterials;
					}
					continue;
				}
				break;
			}
		}

		internal void ChangeLOD(Material mat)
		{
			if (HasLODs)
			{
				Material[] sharedMaterials = mesh.sharedMaterials;
				sharedMaterials[indexM] = mat;
				Renderer[] lODs = LODs;
				for (int i = 0; i < lODs.Length; i++)
				{
					lODs[i].sharedMaterials = sharedMaterials;
				}
			}
		}

		public virtual void NextMaterial()
		{
			ChangeMaterial();
		}

		public virtual void ChangeMaterial(int index)
		{
			if (materials.Length == 0)
			{
				return;
			}
			index = Mathf.Clamp(index, 0, materials.Length);
			Material material = materials[index];
			if (material != null && mesh != null)
			{
				Material[] sharedMaterials = mesh.sharedMaterials;
				if (sharedMaterials.Length - 1 < indexM)
				{
					Debug.LogWarning("The Meshes on the " + Name + " Material Item, does not have " + (indexM + 1) + " Materials, please change the ID parameter to value lower than " + sharedMaterials.Length);
				}
				else
				{
					sharedMaterials[indexM] = material;
					mesh.sharedMaterials = sharedMaterials;
					current = index;
					ChangeLOD(index);
					OnMaterialChanged.Invoke(current);
				}
			}
			else
			{
				Debug.LogWarning("The material on the Slot: " + index + "  is empty");
			}
		}

		public virtual void PreviousMaterial()
		{
			current--;
			if (current < 0)
			{
				current = materials.Length - 1;
			}
			if (materials[current] != null)
			{
				Material[] sharedMaterials = mesh.sharedMaterials;
				sharedMaterials[indexM] = materials[current];
				mesh.sharedMaterials = sharedMaterials;
				ChangeLOD(current);
				OnMaterialChanged.Invoke(current);
			}
			else
			{
				Debug.LogWarning("The Material on the Slot: " + current + " is empty");
			}
		}

		public virtual void ChangeMaterial(Material mat)
		{
			Material[] sharedMaterials = mesh.sharedMaterials;
			sharedMaterials[indexM] = mat;
			mesh.sharedMaterials = sharedMaterials;
			ChangeLOD(mat);
		}

		public virtual void ChangeMaterial(bool Next)
		{
			if (Next)
			{
				ChangeMaterial();
			}
			else
			{
				PreviousMaterial();
			}
		}
	}
}
