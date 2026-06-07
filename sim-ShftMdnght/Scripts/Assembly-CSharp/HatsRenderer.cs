using UnityEngine;

public class HatsRenderer : MonoBehaviour
{
	public GameObject[] hatObjs;

	public Material[] headMaterials;

	public SkinnedMeshRenderer headRenderer;

	public static HatsRenderer Instance { get; private set; }

	public void SelectHat(int index)
	{
		GameObject[] array = hatObjs;
		foreach (GameObject gameObject in array)
		{
			if ((bool)gameObject)
			{
				gameObject.SetActive(value: false);
			}
		}
		if ((bool)hatObjs[index])
		{
			hatObjs[index].SetActive(value: true);
		}
		if (headRenderer != null && headMaterials != null && index < headMaterials.Length)
		{
			Material[] materials = headRenderer.materials;
			materials[0] = headMaterials[index];
			headRenderer.materials = materials;
		}
	}

	private void Awake()
	{
		Instance = this;
	}
}
