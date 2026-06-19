using System.Collections.Generic;
using UnityEngine;

public class BuildObjectInfo : MonoBehaviour
{
	private string resourceString;

	private ulong? UID;

	private ulong? parentObject;

	private List<ulong> childObjects = new List<ulong>();

	private bool ghosted;

	private ClickableObject clickableRef;

	private List<Renderer> renderers = new List<Renderer>();

	private List<Material> originalMaterials = new List<Material>();

	private void Awake()
	{
		StoreRenderers();
		clickableRef = base.transform.root.GetComponent<ClickableObject>();
	}

	public void SetUID(ulong newID)
	{
		if (UID.HasValue)
		{
			Debug.LogError("Object: " + base.gameObject.name + " already has a UID. Cannot assign it a second time.");
		}
		else
		{
			UID = newID;
		}
	}

	public bool CanHighlight()
	{
		return !ghosted;
	}

	public void SetGhostedStatus(bool val)
	{
		ghosted = val;
		if (clickableRef != null)
		{
			clickableRef.SetGhostedStatus(val);
		}
	}

	public ulong GetUID()
	{
		if (!UID.HasValue)
		{
			Debug.LogError("Object: " + base.gameObject.name + " does not have a UID. Cannot view it.");
			return 0uL;
		}
		return UID.Value;
	}

	public ulong GetParentUID()
	{
		return parentObject.Value;
	}

	public void SetResourceString(string newString)
	{
		resourceString = newString;
	}

	public string GetResourceString()
	{
		return resourceString;
	}

	public GameObject GetParentObject(ConstructionManager constructionRef)
	{
		if (!parentObject.HasValue)
		{
			return null;
		}
		return constructionRef.GetObjectForUID(parentObject.Value);
	}

	public List<GameObject> GetChildObjects(ConstructionManager constructionRef)
	{
		List<GameObject> list = new List<GameObject>();
		for (int i = 0; i < childObjects.Count; i++)
		{
			list.Add(constructionRef.GetObjectForUID(childObjects[i]));
		}
		return list;
	}

	public void SetMaterialState(Material newMat)
	{
		RestoreMaterialState();
		for (int i = 0; i < renderers.Count; i++)
		{
			originalMaterials.Add(renderers[i].material);
			renderers[i].material = newMat;
		}
	}

	public void RestoreMaterialState()
	{
		for (int i = 0; i < originalMaterials.Count; i++)
		{
			if (renderers[i] != null)
			{
				renderers[i].material = originalMaterials[i];
			}
		}
		originalMaterials.Clear();
	}

	private void StoreRenderers()
	{
		renderers.Clear();
		Renderer component = GetComponent<Renderer>();
		if (component != null)
		{
			renderers.Add(component);
		}
		Renderer[] componentsInChildren = GetComponentsInChildren<Renderer>();
		foreach (Renderer item in componentsInChildren)
		{
			renderers.Add(item);
		}
	}
}
