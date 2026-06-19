using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class SerializableGameObject
{
	public string objectName;

	public SerializableTransform transform;

	public SerializableRigidbody rigidbody;

	public List<SerializableGameObject> children = new List<SerializableGameObject>();

	public SerializableGameObject()
	{
	}

	public SerializableGameObject(GameObject obj, InventoryItem alternativeObj = null)
	{
		Save(obj, alternativeObj);
	}

	public void Save(GameObject obj, InventoryItem alternativeObj = null)
	{
		if (alternativeObj != null)
		{
			objectName = alternativeObj.itemName;
		}
		else
		{
			objectName = obj.name;
		}
		transform = new SerializableTransform(obj.transform);
		if (alternativeObj == null)
		{
			Rigidbody component = obj.GetComponent<Rigidbody>();
			if (component != null)
			{
				rigidbody = new SerializableRigidbody(component);
			}
			for (int i = 0; i < obj.transform.childCount; i++)
			{
				SerializableGameObject item = new SerializableGameObject(obj.transform.GetChild(i).gameObject);
				children.Add(item);
			}
		}
	}

	public void Load(GameObject obj)
	{
		obj.name = objectName;
		Rigidbody component = obj.GetComponent<Rigidbody>();
		if (component != null)
		{
			rigidbody.Load(component);
		}
		this.transform.Load(obj);
		for (int i = 0; i < children.Count; i++)
		{
			Transform transform = obj.transform.Find(children[i].objectName);
			if (!(transform == null))
			{
				children[i].Load(transform.gameObject);
			}
		}
	}

	public SerializableGameObject GetCopy()
	{
		SerializableGameObject serializableGameObject = new SerializableGameObject();
		serializableGameObject.objectName = objectName;
		if (transform != null)
		{
			serializableGameObject.transform = transform.GetCopy();
		}
		if (rigidbody != null)
		{
			serializableGameObject.rigidbody = rigidbody.GetCopy();
		}
		serializableGameObject.children.Clear();
		for (int i = 0; i < children.Count; i++)
		{
			if (children[i] != null)
			{
				serializableGameObject.children.Add(children[i].GetCopy());
			}
		}
		return serializableGameObject;
	}
}
