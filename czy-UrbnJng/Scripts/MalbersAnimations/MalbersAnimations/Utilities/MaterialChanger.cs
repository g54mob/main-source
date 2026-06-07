using System.Collections.Generic;
using UnityEngine;

namespace MalbersAnimations.Utilities
{
	[AddComponentMenu("Malbers/Utilities/Mesh/Material Changer")]
	public class MaterialChanger : MonoBehaviour
	{
		public List<MaterialItem> materialList = new List<MaterialItem>();

		public bool showMeshesList = true;

		public bool changeHidden;

		public bool random;

		public string AllIndex
		{
			get
			{
				string text = "";
				for (int i = 0; i < materialList.Count; i++)
				{
					MaterialItem materialItem = materialList[i];
					if (materialItem != null)
					{
						text = text + materialItem.current + " ";
					}
				}
				text.Remove(text.Length - 1);
				return text;
			}
			set
			{
				string[] array = value.Split(' ');
				for (int i = 0; i < materialList.Count; i++)
				{
					if (array.Length > i && int.TryParse(array[i], out var result) && result != -1)
					{
						materialList[i].ChangeMaterial(result);
					}
				}
			}
		}

		public MaterialItem this[int index]
		{
			get
			{
				return materialList[index];
			}
			set
			{
				materialList[index] = value;
			}
		}

		public int Count => materialList.Count;

		private void OnEnable()
		{
			foreach (MaterialItem material in materialList)
			{
				if (material.Linked && material.Master >= 0 && material.Master < Count)
				{
					materialList[material.Master].OnMaterialChanged.AddListener(material.ChangeMaterial);
				}
			}
			if (random)
			{
				Randomize();
			}
		}

		private void OnDisable()
		{
			foreach (MaterialItem material in materialList)
			{
				if (material.Linked && material.Master >= 0 && material.Master < Count)
				{
					materialList[material.Master].OnMaterialChanged.RemoveListener(material.ChangeMaterial);
				}
			}
		}

		public virtual void Randomize()
		{
			foreach (MaterialItem material in materialList)
			{
				if (!material.Linked)
				{
					material.ChangeMaterial(Random.Range(0, material.materials.Length));
				}
			}
		}

		public virtual void SetAllMaterials(bool Next = true)
		{
			foreach (MaterialItem material in materialList)
			{
				material.ChangeMaterial(Next);
			}
		}

		public virtual void SetAllMaterials(int index)
		{
			foreach (MaterialItem material in materialList)
			{
				material.ChangeMaterial(index);
			}
		}

		public virtual void SetMaterial(int indexList, int nextIndex)
		{
			if (indexList < 0)
			{
				indexList = 0;
			}
			indexList %= Count;
			if (materialList[indexList] != null)
			{
				materialList[indexList].ChangeMaterial(nextIndex);
			}
		}

		public virtual void SetMaterial(int index, bool next = true)
		{
			if (index < 0)
			{
				index = 0;
			}
			index %= Count;
			if (materialList[index] != null)
			{
				materialList[index].ChangeMaterial(next);
			}
		}

		public virtual void SetMaterial(string name, int Index)
		{
			MaterialItem materialItem = materialList.Find((MaterialItem item) => item.Name == name);
			if (materialItem != null)
			{
				materialItem.ChangeMaterial(Index);
			}
			else
			{
				Debug.LogWarning("No material Item Found with the name: " + name);
			}
		}

		public virtual void SetMaterial(string name, bool next = true)
		{
			MaterialItem materialItem = materialList.Find((MaterialItem item) => item.Name == name);
			if (materialItem != null)
			{
				materialItem.ChangeMaterial(next);
			}
			else
			{
				Debug.LogWarning("No material Item Found with the name: " + name);
			}
		}

		public virtual void SetAllMaterials(Material mat)
		{
			foreach (MaterialItem material in materialList)
			{
				material.ChangeMaterial(mat);
			}
		}

		public virtual void NextMaterialItem(int index)
		{
			if (index < 0)
			{
				index = 0;
			}
			index %= Count;
			materialList[index].NextMaterial();
		}

		public virtual void NextMaterialItem(string name)
		{
			materialList.Find((MaterialItem item) => item.Name.ToUpper() == name.ToUpper())?.NextMaterial();
		}

		public virtual int CurrentMaterialIndex(int index)
		{
			return materialList[index].current;
		}

		public virtual int CurrentMaterialIndex(string name)
		{
			int index = materialList.FindIndex((MaterialItem item) => item.Name == name);
			return materialList[index].current;
		}
	}
}
