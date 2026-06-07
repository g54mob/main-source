using UnityEngine;

public class InspectorRenderer : MonoBehaviour
{
	private static InspectorRenderer _instance;

	public Transform Pivot;

	public MeshFilter MeshObject;

	public MeshRenderer Renderer;

	public Camera Cam;

	public static InspectorRenderer GetInstance(InspectorRenderer prefab)
	{
		if (_instance == null)
		{
			return Object.Instantiate(prefab);
		}
		return _instance;
	}

	private void Awake()
	{
		if (_instance != null)
		{
			Object.Destroy(base.gameObject);
		}
		else
		{
			_instance = this;
		}
	}

	private void OnDestroy()
	{
		if (_instance == this)
		{
			_instance = null;
		}
	}

	public void StartRendering(Mesh mesh, Material mat)
	{
		Pivot.rotation = Quaternion.identity;
		MeshObject.sharedMesh = mesh;
		Renderer.sharedMaterial = mat;
		Bounds bounds = mesh.bounds;
		float num = Mathf.Max(bounds.size.x, bounds.size.y, bounds.size.z);
		float num2 = 1f / num;
		MeshObject.transform.localScale = Vector3.one * num2;
		MeshObject.transform.localRotation = Quaternion.identity;
		MeshObject.transform.localPosition = -bounds.center * num2;
		Cam.enabled = true;
		base.gameObject.SetActive(true);
	}

	public void StopRendering()
	{
		Cam.enabled = false;
		base.gameObject.SetActive(false);
	}
}
