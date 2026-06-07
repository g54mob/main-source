using UnityEngine;

public class Line : MonoBehaviour
{
	public Transform S;

	public Transform E;

	public float Offset;

	public virtual void Refresh()
	{
	}

	public virtual void SetMaterial(Material m)
	{
	}

	protected void SetMaterial(GameObject go, Material m)
	{
		MeshRenderer[] componentsInChildren = go.GetComponentsInChildren<MeshRenderer>();
		foreach (MeshRenderer meshRenderer in componentsInChildren)
		{
			if (meshRenderer != null)
			{
				meshRenderer.material = m;
			}
		}
	}
}
