using System;
using System.Collections.Generic;
using UnityEngine;

public class VisRegion : MonoBehaviour
{
	[Serializable]
	public class ImportSpec
	{
		public bool useOcclusionPortals;

		public string onlyComponentType;

		public string externalTargetName;
	}

	[Serializable]
	public class Box
	{
		public Bounds localBounds;

		public Transform transform;

		public bool Contains(Vector3 point)
		{
			return localBounds.Contains(transform.worldToLocalMatrix.MultiplyPoint(point));
		}
	}

	public ImportSpec importSpec;

	public bool attachLightDimmerToTargets = true;

	[Space]
	public List<Box> boxes = new List<Box>();

	public List<GameObject> targetGos = new List<GameObject>();

	public List<OcclusionPortal> occlusionPortals = new List<OcclusionPortal>();

	public bool Contains(Vector3 point)
	{
		foreach (Box box in boxes)
		{
			if (box.Contains(point))
			{
				return true;
			}
		}
		return false;
	}
}
