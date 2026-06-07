using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Scr_GuiCollider : MonoBehaviour
{
	public string colliderTag = "GuiCollider";

	public bool canConstructionBePlaced = true;

	private List<GameObject> collidedObjects = new List<GameObject>();

	private List<Renderer> colliderMaterials = new List<Renderer>();

	private void Start()
	{
		InitializeReferences();
		if (canConstructionBePlaced)
		{
			SetColor(Color.green);
		}
		else
		{
			SetColor(Color.red);
		}
		GetComponent<Renderer>().material.mainTextureScale = new Vector2(base.gameObject.transform.localScale.x, base.gameObject.transform.localScale.y);
	}

	private void InitializeReferences()
	{
		colliderMaterials.Add(GetComponent<Renderer>());
		colliderMaterials.AddRange(GetComponentsInChildren<Renderer>().ToList());
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.tag == colliderTag)
		{
			SetColor(Color.red);
			canConstructionBePlaced = false;
			if (!collidedObjects.Contains(other.gameObject))
			{
				collidedObjects.Add(other.gameObject);
			}
		}
	}

	private void OnTriggerExit(Collider other)
	{
		if (other.tag == colliderTag && collidedObjects.Contains(other.gameObject))
		{
			collidedObjects.Remove(other.gameObject);
		}
		if (collidedObjects.Count == 0)
		{
			SetColor(Color.green);
			canConstructionBePlaced = true;
		}
	}

	private void SetColor(Color newColor)
	{
		Color color = new Color(newColor.r, newColor.g, newColor.b, 1f);
		for (int i = 0; i < colliderMaterials.Count; i++)
		{
			colliderMaterials[i].material.color = color;
		}
	}
}
