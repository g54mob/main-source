using UnityEngine;

namespace Rowlan.Yapp
{
	public class MeshUtils
	{
		public static void RenderGameObject(GameObject gameObject, int sourceLODLevel)
		{
			GameObject[] array = new GameObject[1] { gameObject };
			LODGroup component = gameObject.GetComponent<LODGroup>();
			if ((bool)component && component.lodCount > 0)
			{
				array = new GameObject[component.GetLODs()[sourceLODLevel].renderers.Length];
				for (int i = 0; i < array.Length; i++)
				{
					array[i] = component.GetLODs()[sourceLODLevel].renderers[i].gameObject;
				}
			}
			GameObject[] array2 = array;
			for (int j = 0; j < array2.Length; j++)
			{
				MeshRenderer[] componentsInChildren = array2[j].GetComponentsInChildren<MeshRenderer>();
				for (int k = 0; k < componentsInChildren.Length; k++)
				{
					MeshFilter component2 = componentsInChildren[k].gameObject.GetComponent<MeshFilter>();
					if ((bool)component2)
					{
						Matrix4x4 matrix = Matrix4x4.TRS(componentsInChildren[k].transform.position, componentsInChildren[k].transform.rotation, componentsInChildren[k].transform.lossyScale);
						Mesh sharedMesh = component2.sharedMesh;
						for (int l = 0; l < componentsInChildren[k].sharedMaterials.Length; l++)
						{
							Material material = componentsInChildren[k].sharedMaterials[l];
							material.SetPass(0);
							Graphics.DrawMesh(sharedMesh, matrix, material, 0);
						}
					}
				}
			}
		}
	}
}
