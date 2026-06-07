using UnityEngine;

public class LockWorldSpaceUVsOnSpawn : MonoBehaviour
{
	private void Awake()
	{
		Renderer component = GetComponent<Renderer>();
		MaterialPropertyBlock materialPropertyBlock = new MaterialPropertyBlock();
		component.GetPropertyBlock(materialPropertyBlock);
		materialPropertyBlock.SetVector("_WorldOffset", base.transform.position);
		component.SetPropertyBlock(materialPropertyBlock);
	}
}
