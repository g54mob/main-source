using System.Collections.Generic;
using UnityEngine;

public class Reparenter : MonoBehaviour
{
	public Transform referenceTransform;

	private Vector3 originalPosOffset;

	private Vector3 originalRotOffset;

	private void Start()
	{
		originalPosOffset = base.transform.position - referenceTransform.position;
		originalRotOffset = base.transform.eulerAngles - referenceTransform.eulerAngles;
	}

	private void FixedUpdate()
	{
		ReparentChildren();
	}

	private void ReparentChildren()
	{
		List<Transform> list = new List<Transform>();
		for (int i = 0; i < base.transform.childCount; i++)
		{
			list.Add(base.transform.GetChild(i));
		}
		while (base.transform.childCount > 0)
		{
			base.transform.GetChild(0).SetParent(null);
		}
		base.transform.position = referenceTransform.position + originalPosOffset;
		base.transform.eulerAngles = referenceTransform.eulerAngles + originalRotOffset;
		for (int j = 0; j < list.Count; j++)
		{
			list[j].SetParent(base.transform);
		}
	}
}
