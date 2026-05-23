using UnityEngine;

public class GPUInstanced : MonoBehaviour
{
	private MeshRenderer mr;

	private GPUInstancingManager gpui;

	private bool started;

	private bool eenabled;

	private Mesh mesh;

	private Material mat;

	private void Start()
	{
		if (mr == null)
		{
			mr = GetComponent<MeshRenderer>();
		}
		if (mr == null)
		{
			Object.Destroy(this);
			return;
		}
		if (gpui == null)
		{
			gpui = GPUInstancingManager.Instance;
		}
		if (gpui == null)
		{
			Object.Destroy(this);
			return;
		}
		mesh = mr.GetComponent<MeshFilter>().sharedMesh;
		mat = mr.sharedMaterial;
		if (eenabled)
		{
			mr.enabled = false;
			gpui.AddVirtualMeshRenderer(mesh, mat, base.transform);
		}
		started = true;
	}

	private void OnEnable()
	{
		eenabled = true;
		if (started)
		{
			mr.enabled = false;
			gpui.AddVirtualMeshRenderer(mesh, mat, base.transform);
		}
	}

	private void OnDisable()
	{
		eenabled = false;
		if (started)
		{
			gpui.RemoveVirtualMeshRenderer(mesh, mat, base.transform);
		}
	}

	public void OnMeshOrMaterialUpdate(Mesh newMesh, Material newMat)
	{
		if (newMesh != mesh || newMat != mat)
		{
			gpui.UpdateVirtualMeshRenderer(mesh, mat, newMesh, newMat, base.transform);
			mesh = newMesh;
			mat = newMat;
		}
	}

	private void Update()
	{
		OnMeshOrMaterialUpdate(mesh, mr.sharedMaterial);
	}
}
