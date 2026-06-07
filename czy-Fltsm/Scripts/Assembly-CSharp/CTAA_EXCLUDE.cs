using UnityEngine;

public class CTAA_EXCLUDE : MonoBehaviour
{
	public bool useAlpha;

	private Material[] mats;

	public bool m_IncludeChildren;

	public bool UI;

	private void Start()
	{
		if (GetComponent<Renderer>() != null)
		{
			mats = GetComponent<Renderer>().materials;
			if (mats.Length != 0)
			{
				Material[] array = mats;
				foreach (Material obj in array)
				{
					obj.SetFloat("rtmask", 1f);
					obj.SetInt("_useAlpha", useAlpha ? 1 : 0);
				}
			}
		}
		Material material = null;
		if (GetComponent<CanvasRenderer>() != null)
		{
			material = GetComponent<CanvasRenderer>().GetMaterial();
		}
		else if (GetComponent<Renderer>() != null)
		{
			material = GetComponent<Renderer>().material;
		}
		if (material != null)
		{
			material.SetFloat("rtmask", 1f);
			material.SetInt("_useAlpha", useAlpha ? 1 : 0);
		}
		if (!m_IncludeChildren)
		{
			return;
		}
		Transform[] componentsInChildren = base.gameObject.GetComponentsInChildren<Transform>();
		foreach (Transform transform in componentsInChildren)
		{
			if (!(transform.gameObject.GetComponent<Renderer>() != null))
			{
				continue;
			}
			mats = transform.gameObject.GetComponent<Renderer>().materials;
			if (mats.Length != 0)
			{
				Material[] array = mats;
				foreach (Material obj2 in array)
				{
					obj2.SetFloat("rtmask", 1f);
					obj2.SetInt("_useAlpha", useAlpha ? 1 : 0);
				}
			}
			Material material2 = ((!(transform.gameObject.GetComponent<CanvasRenderer>() != null)) ? transform.gameObject.GetComponent<Renderer>().material : transform.gameObject.GetComponent<CanvasRenderer>().GetMaterial());
			if (material2 != null)
			{
				material2.SetFloat("rtmask", 1f);
				material2.SetInt("_useAlpha", useAlpha ? 1 : 0);
			}
		}
	}

	private void Update()
	{
		if (UI)
		{
			Material material = null;
			if (GetComponent<CanvasRenderer>() != null)
			{
				material = GetComponent<CanvasRenderer>().GetMaterial();
			}
			if (material != null)
			{
				material.SetFloat("rtmask", 1f);
				material.SetInt("_useAlpha", useAlpha ? 1 : 0);
			}
		}
	}
}
