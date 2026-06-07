using UnityEngine;

public class UVScroller_water : MonoBehaviour
{
	private Material mat;

	public float scrollSpeed = 0.02f;

	private Transform lightDir;

	private void Start()
	{
		mat = base.gameObject.GetComponent<MeshRenderer>().material;
		Light[] array = Object.FindObjectsByType(typeof(Light), FindObjectsSortMode.None) as Light[];
		foreach (Light light in array)
		{
			if (light.type == LightType.Directional)
			{
				lightDir = light.transform;
				break;
			}
		}
	}

	private void Update()
	{
		float num = Time.time * scrollSpeed;
		mat.SetTextureOffset("_MainTex", new Vector2(num * 0.5f, num * 1f));
		mat.SetTextureOffset("_HeightTex", new Vector2(num / 2f, num));
		mat.SetTextureOffset("_FoamTex", new Vector2(num / 4f, num * 1f));
		if ((bool)lightDir)
		{
			mat.SetVector("_WorldLightDir", lightDir.forward);
		}
		else
		{
			mat.SetVector("_WorldLightDir", new Vector3(0.7f, 0.7f, 0f));
		}
	}
}
