using UnityEngine;

public class SimpleGPUInstancingExample : MonoBehaviour
{
	public Transform Prefab;

	public Material InstancedMaterial;

	private void Awake()
	{
		InstancedMaterial.enableInstancing = true;
		int num = 5;
		for (int i = 0; i < 1000; i++)
		{
			Transform obj = Object.Instantiate(Prefab, new Vector3(Random.Range(-num, num), num + Random.Range(-num, num), Random.Range(-num, num)), Quaternion.identity);
			MaterialPropertyBlock materialPropertyBlock = new MaterialPropertyBlock();
			Color value = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
			materialPropertyBlock.SetColor("_Color", value);
			obj.GetComponent<MeshRenderer>().SetPropertyBlock(materialPropertyBlock);
		}
	}
}
