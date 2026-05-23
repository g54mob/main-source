using System.Collections.Generic;
using UnityEngine;

public class DeskBoxFinder
{
	public DeskBox found;

	private Camera playerCamera;

	private List<DeskBox> deskBoxes;

	private Rect kFocusRect = new Rect(0.4f, 0.3f, 0.19999999f, 0.29999998f);

	public DeskBoxFinder(Camera playerCamera_, List<DeskBox> deskBoxes_)
	{
		playerCamera = playerCamera_;
		deskBoxes = deskBoxes_;
	}

	public bool Search()
	{
		Ray ray = new Ray(playerCamera.transform.position, playerCamera.transform.forward);
		float num = float.MaxValue;
		DeskBox deskBox = null;
		foreach (DeskBox deskBox2 in deskBoxes)
		{
			float distance = 0f;
			if (!deskBox2.gameObject.activeInHierarchy)
			{
				continue;
			}
			Ray ray2 = new Ray(deskBox2.transform.worldToLocalMatrix.MultiplyPoint(ray.origin), deskBox2.transform.worldToLocalMatrix.MultiplyVector(ray.direction));
			if (!deskBox2.localBounds.IntersectRay(ray2, out distance))
			{
				continue;
			}
			Vector3 point = ray2.GetPoint(distance);
			Vector3 vector = deskBox2.transform.localToWorldMatrix.MultiplyPoint(point);
			distance = (ray.origin - vector).magnitude;
			if (!(distance > num))
			{
				Vector3 vector2 = playerCamera.WorldToViewportPoint(vector);
				if (!(vector2.x < kFocusRect.xMin) && !(vector2.x > kFocusRect.xMax) && !(vector2.y < kFocusRect.yMin) && !(vector2.y > kFocusRect.yMax))
				{
					num = distance;
					deskBox = deskBox2;
				}
			}
		}
		found = deskBox;
		return found != null;
	}
}
