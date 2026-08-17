using System;
using Assets.Scripts.Managers;
using UnityEngine;

public class ObjectStageMaterial : MonoBehaviour
{
	[Serializable]
	public class StageMaterial
	{
		public int stageIndex;

		public Material material;
	}

	public StageMaterial[] stageMaterials;

	public MeshRenderer meshRenderer;

	private void Start()
	{
		//IL_0022: Expected O, but got I4
		//IL_002b: Expected O, but got I4
		//IL_0071: Unknown result type (might be due to invalid IL or missing references)
		//IL_0076: Expected O, but got Unknown
		StageMaterial[] array = stageMaterials;
		object obj = 0;
		object obj2 = 0;
		while ((nint)obj < array.Length)
		{
			StageMaterial stageMaterial = array[obj2];
			if (stageMaterial.stageIndex != MapController.index)
			{
				obj2++;
				obj = obj2;
				continue;
			}
			((Renderer)meshRenderer).SetMaterial(stageMaterial.material);
			break;
		}
	}

	private void OnValidate()
	{
		if (meshRenderer == null)
		{
			MeshRenderer component = GetComponent<MeshRenderer>();
			meshRenderer = component;
		}
	}
}
