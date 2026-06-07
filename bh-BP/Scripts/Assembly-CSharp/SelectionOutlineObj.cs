using UnityEngine;

[ExecuteInEditMode]
[RequireComponent(typeof(Renderer))]
public class SelectionOutlineObj : MonoBehaviour
{
	public Mesh Mesh;

	public Material Material;

	public MeshRenderer Renderer { get; private set; }

	private void OnEnable()
	{
	}

	private void OnDisable()
	{
	}

	public void SetOutline(Color c)
	{
	}

	public void ClearOutline()
	{
	}
}
