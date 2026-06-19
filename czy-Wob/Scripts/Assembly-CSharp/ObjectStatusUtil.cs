using System.Collections.Generic;
using UnityEngine;

public static class ObjectStatusUtil
{
	private static bool result;

	private static Color lineColor;

	private static RaycastHit reusableHit = default(RaycastHit);

	private static RaycastHit[] results = new RaycastHit[100];

	private static Vector3 customExtents;

	public static bool CheckObjectGrounded(GameObject obj, float lengthOffset = 0.01f, float sizeMod = 1f, bool debugVis = false)
	{
		lengthOffset *= sizeMod;
		bool flag = RaycastHitInternal(obj.transform.position, -obj.transform.up, obj.GetComponent<Collider>().bounds.extents.y + lengthOffset, out reusableHit, debugVis);
		if (flag && reusableHit.normal.y <= 0f)
		{
			flag = false;
		}
		return flag;
	}

	public static bool CheckTopCollision(GameObject obj, ref List<GameObject> objectsToIgnore, ref bool collisionIsStageLayer, float additionalOffset = 0.01f, float sizeMod = 1f, bool checkPhysicsPlants = true, bool checkStage = true, bool checkDogs = true)
	{
		additionalOffset *= sizeMod;
		customExtents = obj.GetComponent<Collider>().bounds.extents / 2f;
		GhostEatBehavior component = obj.transform.root.GetComponent<GhostEatBehavior>();
		int num = RaycastUtil.GoodBoxCastAllNonAlloc(obj.transform.position, customExtents, obj.transform.up, obj.transform.rotation, additionalOffset + customExtents.y, results);
		for (int i = 0; i < num; i++)
		{
			if ((!(component != null) || !(component.GetCurrentlyEatenObject() == results[i].transform.root.gameObject)) && results[i].transform.root.gameObject != obj.transform.root.gameObject && (objectsToIgnore == null || !objectsToIgnore.Contains(results[i].transform.gameObject)) && (checkPhysicsPlants || !results[i].transform.root.gameObject.CompareTag(Tags.PHYSICS_PLANT)) && (checkDogs || !results[i].transform.root.gameObject.CompareTag(Tags.DOG)))
			{
				collisionIsStageLayer = results[i].transform.root.gameObject.layer == RaycastUtil.stageLayer;
				if (!collisionIsStageLayer || checkStage)
				{
					return true;
				}
			}
		}
		collisionIsStageLayer = false;
		return false;
	}

	public static bool CheckBotCollision(GameObject obj, ref List<GameObject> objectsToIgnore, ref bool collisionIsStageLayer, float additionalOffset = 0.01f, float sizeMod = 1f, bool checkPhysicsPlants = true, bool checkStage = true, bool checkDogs = true)
	{
		additionalOffset *= sizeMod;
		customExtents = obj.GetComponent<Collider>().bounds.extents / 2f;
		GhostEatBehavior component = obj.transform.root.GetComponent<GhostEatBehavior>();
		int num = RaycastUtil.GoodBoxCastAllNonAlloc(obj.transform.position, customExtents, -obj.transform.up, obj.transform.rotation, additionalOffset + customExtents.y, results);
		for (int i = 0; i < num; i++)
		{
			if ((!(component != null) || !(component.GetCurrentlyEatenObject() == results[i].transform.root.gameObject)) && results[i].transform.root.gameObject != obj.transform.root.gameObject && (objectsToIgnore == null || !objectsToIgnore.Contains(results[i].transform.gameObject)) && (checkPhysicsPlants || !results[i].transform.root.gameObject.CompareTag(Tags.PHYSICS_PLANT)) && (checkDogs || !results[i].transform.root.gameObject.CompareTag(Tags.DOG)))
			{
				collisionIsStageLayer = results[i].transform.root.gameObject.layer == RaycastUtil.stageLayer;
				if (!collisionIsStageLayer || checkStage)
				{
					return true;
				}
			}
		}
		collisionIsStageLayer = false;
		return false;
	}

	public static bool CheckCustomPositionCollision(GameObject obj, Vector3 dir, Vector3 posOffset, float lengthOffset = 0.01f, bool debugVis = false)
	{
		return RaycastHitInternal(obj.transform.position + posOffset, dir, obj.GetComponent<Collider>().bounds.extents.y + lengthOffset, debugVis);
	}

	private static bool RaycastHitInternal(Vector3 startPos, Vector3 dir, float dist, bool debugVis = false)
	{
		result = RaycastUtil.GoodRaycast(startPos, dir, dist);
		if (debugVis)
		{
			VisualizeRay(startPos, dir, dist);
		}
		return result;
	}

	private static bool RaycastHitInternal(Vector3 startPos, Vector3 dir, float dist, out RaycastHit hitInfo, bool debugVis = false)
	{
		result = RaycastUtil.GoodRaycast(startPos, dir, out hitInfo, dist);
		if (debugVis)
		{
			VisualizeRay(startPos, dir, dist);
		}
		return result;
	}

	private static void VisualizeRay(Vector3 startPos, Vector3 dir, float dist)
	{
		lineColor = Color.green;
		if (!result)
		{
			lineColor = Color.red;
		}
		Debug.DrawLine(startPos, startPos + dir * dist, lineColor, 5f);
	}
}
