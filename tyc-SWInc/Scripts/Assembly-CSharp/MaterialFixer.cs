using System.Collections.Generic;
using UnityEngine;

public class MaterialFixer : MonoBehaviour
{
	public static Dictionary<Material, Material> MaterialInstance = new Dictionary<Material, Material>();

	public static Material Get(Material mat)
	{
		return MaterialInstance.GetOrAdd(mat, (Material x) => new Material(x));
	}

	private void Awake()
	{
		MeshRenderer component = GetComponent<MeshRenderer>();
		component.sharedMaterial = Get(component.sharedMaterial);
	}
}
