using UnityEngine;

[RequireComponent(typeof(MeshRenderer))]
public class GpuInctancing : MonoBehaviour
{
	private void Awake()
	{
		MaterialPropertyBlock propertyBlock = new MaterialPropertyBlock();
		GetComponent<MeshRenderer>().SetPropertyBlock(propertyBlock);
	}
}
