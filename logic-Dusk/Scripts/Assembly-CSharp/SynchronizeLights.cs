using UnityEngine;

public class SynchronizeLights : MonoBehaviour
{
	public Light light0;

	public Light light1;

	private Material mat;

	private void Awake()
	{
		mat = GetComponent<Renderer>().material;
	}

	private void OnDestroy()
	{
		Object.DestroyImmediate(mat);
	}

	private void LateUpdate()
	{
		if ((bool)light0)
		{
			Vector3 vector = light0.transform.rotation * new Vector3(0f, 0f, -1f);
			mat.SetVector("_LightDirection0", new Vector4(vector.x, vector.y, vector.z, 0f));
			mat.SetColor("_MyLightColor0", light0.color);
		}
		if ((bool)light1)
		{
			Vector3 vector2 = light1.transform.rotation * new Vector3(0f, 0f, -1f);
			mat.SetVector("_LightDirection1", new Vector4(vector2.x, vector2.y, vector2.z, 0f));
			mat.SetColor("_MyLightColor1", light1.color);
		}
	}
}
