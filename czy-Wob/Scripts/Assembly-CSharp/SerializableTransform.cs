using System;
using UnityEngine;

[Serializable]
public class SerializableTransform
{
	public SerializableVector3 position;

	public SerializableVector3 localScale;

	public SerializableQuaternion rotation;

	public SerializableTransform()
	{
	}

	public SerializableTransform(Transform t)
	{
		Save(t);
	}

	public void Save(Transform t)
	{
		position = new SerializableVector3(t.position);
		rotation = new SerializableQuaternion(t.rotation);
		localScale = new SerializableVector3(t.localScale);
	}

	public void Load(GameObject obj)
	{
		bool isKinematic = false;
		Rigidbody component = obj.GetComponent<Rigidbody>();
		if (component != null)
		{
			isKinematic = component.isKinematic;
			component.isKinematic = true;
		}
		obj.transform.localScale = localScale.Load();
		obj.transform.position = position.Load();
		obj.transform.rotation = rotation.Load();
		if (component != null)
		{
			component.isKinematic = isKinematic;
		}
	}

	public SerializableTransform GetCopy()
	{
		return new SerializableTransform
		{
			position = position.GetCopy(),
			localScale = localScale.GetCopy(),
			rotation = rotation.GetCopy()
		};
	}
}
