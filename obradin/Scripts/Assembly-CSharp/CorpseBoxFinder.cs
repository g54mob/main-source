using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class CorpseBoxFinder
{
	public enum Filter
	{
		All = 0,
		OnlyUnlocked = 1,
		OnlyLocked = 2,
		OnlyCanVisit = 3
	}

	public Camera playerCamera;

	public List<CorpseBox> allCorpseBoxesInLevel;

	[NonSerialized]
	public CorpseBox found;

	[NonSerialized]
	public bool drawDebug;

	private const float kReachDistMin = 0.5f;

	private const float kReachDistMax = 1.9f;

	private static Rect kFocusRectAtReachDistMin = new Rect(0.3f, 0.1f, 0.39999998f, 0.7f);

	private static Rect kFocusRectAtReachDistMax = new Rect(0.4f, 0.3f, 0.19999999f, 0.5f);

	private static RaycastHit[] raycastHits = new RaycastHit[1] { default(RaycastHit) };

	public CorpseBoxFinder(Camera playerCamera_)
	{
		playerCamera = playerCamera_;
		allCorpseBoxesInLevel = new List<CorpseBox>(UnityEngine.Object.FindObjectsOfType<CorpseBox>());
	}

	public bool Search(Filter filter = Filter.All)
	{
		Ray ray = new Ray(playerCamera.transform.position, playerCamera.transform.forward);
		float num = 0.01f;
		int num2 = (1 << LayerMask.NameToLayer("Player")) | (1 << LayerMask.NameToLayer("Glass"));
		float num3 = float.MaxValue;
		CorpseBox corpseBox = null;
		foreach (CorpseBox item in allCorpseBoxesInLevel)
		{
			if ((filter == Filter.OnlyUnlocked && !item.alreadyUnlocked) || (filter == Filter.OnlyLocked && item.alreadyUnlocked) || (filter == Filter.OnlyCanVisit && !item.canVisit) || !item.gameObject.activeInHierarchy)
			{
				if (drawDebug)
				{
					item.debugColor = new Color(0.5f, 0.5f, 0.5f);
				}
				continue;
			}
			float distance = 0f;
			if (!item.worldBounds.IntersectRay(ray, out distance))
			{
				if (drawDebug)
				{
					item.debugColor = Color.red;
				}
				continue;
			}
			if (distance > 1.9f)
			{
				if (drawDebug)
				{
					item.debugColor = Color.blue;
				}
				continue;
			}
			Ray ray2 = new Ray(item.transform.worldToLocalMatrix.MultiplyPoint(ray.origin), item.transform.worldToLocalMatrix.MultiplyVector(ray.direction));
			if (!item.localBounds.IntersectRay(ray2, out distance))
			{
				if (drawDebug)
				{
					item.debugColor = Color.cyan;
				}
				continue;
			}
			Vector3 point = ray2.GetPoint(distance);
			Vector3 vector = item.transform.localToWorldMatrix.MultiplyPoint(point);
			distance = (ray.origin - vector).magnitude;
			if (distance > num3 || distance > 1.9f)
			{
				if (drawDebug)
				{
					item.debugColor = new Color(0.5f, 0f, 1f, 1f);
				}
				continue;
			}
			Vector3 vector2 = playerCamera.WorldToViewportPoint(vector);
			float t = Util.LerpScale(vector2.z, 0.5f, 1.9f, 0f, 1f);
			if (vector2.x < Mathf.Lerp(kFocusRectAtReachDistMin.xMin, kFocusRectAtReachDistMax.xMin, t) || vector2.x > Mathf.Lerp(kFocusRectAtReachDistMin.xMax, kFocusRectAtReachDistMax.xMax, t) || vector2.y < Mathf.Lerp(kFocusRectAtReachDistMin.yMin, kFocusRectAtReachDistMax.yMin, t) || vector2.y > Mathf.Lerp(kFocusRectAtReachDistMin.yMax, kFocusRectAtReachDistMax.yMax, t))
			{
				if (drawDebug)
				{
					item.debugColor = Color.yellow;
				}
				continue;
			}
			if (Physics.SphereCastNonAlloc(ray.origin, num, ray.direction, raycastHits, distance - num, ~num2) != 0)
			{
				if (drawDebug)
				{
					item.debugColor = new Color(1f, 0.5f, 0f, 1f);
				}
				continue;
			}
			num3 = distance;
			corpseBox = item;
			if (drawDebug)
			{
				item.debugColor = Color.green;
			}
		}
		found = corpseBox;
		return found != null;
	}

	public void DrawDebug()
	{
		drawDebug = true;
		DebugDrawer.World(delegate(DebugDrawer dd)
		{
			foreach (CorpseBox item in allCorpseBoxesInLevel)
			{
				dd.DrawBounds(item.debugColor, item.localBounds, item.transform.localToWorldMatrix);
			}
		});
	}
}
