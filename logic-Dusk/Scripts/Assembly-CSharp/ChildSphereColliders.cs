using System.Collections.Generic;
using UnityEngine;

public class ChildSphereColliders : MonoBehaviour
{
	private const int MaxChildColliders = 7;

	public SphereCollider[] ChildColliders;

	private void Awake()
	{
		Transform transform = base.transform.FindChild("childColliders");
		if (transform != null)
		{
			List<SphereCollider> list = new List<SphereCollider>();
			for (int i = 1; i <= 7; i++)
			{
				Transform transform2 = transform.FindChild("sphere" + i);
				if (transform2 == null)
				{
					break;
				}
				SphereCollider component = transform2.gameObject.GetComponent<SphereCollider>();
				if (component != null)
				{
					list.Add(component);
				}
			}
			if (list.Count > 0)
			{
				ChildColliders = list.ToArray();
			}
		}
		if (ChildColliders == null)
		{
			Debug.LogWarning("ChildColliders is null");
		}
	}
}
