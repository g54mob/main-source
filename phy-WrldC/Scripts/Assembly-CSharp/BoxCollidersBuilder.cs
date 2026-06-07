using System.Collections.Generic;
using UnityEngine;

public class BoxCollidersBuilder : MonoBehaviour
{
	[SerializeField]
	private List<Mesh> meshes = new List<Mesh>();

	public void CreateBoxColliders()
	{
		if (meshes == null || meshes.Count == 0)
		{
			return;
		}
		BoxCollider[] components = GetComponents<BoxCollider>();
		if (components != null)
		{
			BoxCollider[] array = components;
			for (int i = 0; i < array.Length; i++)
			{
				Object.DestroyImmediate(array[i]);
			}
		}
		foreach (Mesh mesh in meshes)
		{
			BoxCollider boxCollider = base.gameObject.AddComponent<BoxCollider>();
			boxCollider.center = mesh.bounds.center;
			boxCollider.size = mesh.bounds.size;
		}
	}
}
