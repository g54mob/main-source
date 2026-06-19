using System.Collections.Generic;
using InControl;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public static class RaycastUtil
{
	public static int defaultLayer = 0;

	public static int ignoreRaycastLayer = 2;

	public static int GUILayer = 5;

	public static int collisionHelperLayer = 10;

	public static int stageLayer = 11;

	public static int placedPhysicsObjectLayer = 12;

	public static int flyzoneLayer = 13;

	public static int collisionHelperBodyLayer = 14;

	public static int triggerLayer = 15;

	public static int collideAndIgnoreRaycastsAndRouting = 19;

	public static int buildNodeLayer = 20;

	public static int collideAndIgnoreRaycasts = 22;

	public static int navmeshObjectLayer = 23;

	public static int navmeshBlockerLayer = 24;

	public static int displacementLayer = 25;

	public static int worldspaceUILayer = 26;

	public static int denInteriorLayer = 29;

	public static int raycastBlockerLayer = 31;

	private static LayerMask generalCastMask = ~((1 << collisionHelperLayer) | (1 << collisionHelperBodyLayer) | (1 << flyzoneLayer) | (1 << triggerLayer) | (1 << GUILayer) | (1 << navmeshBlockerLayer) | (1 << buildNodeLayer) | (1 << collideAndIgnoreRaycasts) | (1 << collideAndIgnoreRaycastsAndRouting));

	private static LayerMask dogGrabberMask = ~((1 << collisionHelperLayer) | (1 << collisionHelperBodyLayer) | (1 << flyzoneLayer) | (1 << triggerLayer) | (1 << GUILayer) | (1 << navmeshBlockerLayer) | (1 << buildNodeLayer) | (1 << collideAndIgnoreRaycasts) | (1 << collideAndIgnoreRaycastsAndRouting) | (1 << denInteriorLayer));

	private static LayerMask guiMask = 1 << GUILayer;

	public static LayerMask navmeshPipeMask = (1 << stageLayer) | (1 << placedPhysicsObjectLayer) | (1 << navmeshObjectLayer) | (1 << raycastBlockerLayer);

	private static LayerMask buildNodeCastMask = (1 << buildNodeLayer) | (1 << stageLayer);

	private static LayerMask stageCastMask = 1 << stageLayer;

	private static LayerMask objectDraggingMask = (1 << stageLayer) | (1 << navmeshObjectLayer) | (1 << placedPhysicsObjectLayer) | (1 << raycastBlockerLayer) | (1 << denInteriorLayer);

	private static LayerMask navmeshMask = (1 << stageLayer) | (1 << navmeshObjectLayer) | (1 << placedPhysicsObjectLayer) | (1 << navmeshBlockerLayer) | (1 << raycastBlockerLayer) | (1 << denInteriorLayer);

	private static Camera uiCamRef;

	private static Camera mainCamRef;

	private static bool GUIHit = false;

	private static float GUICastDist = 1000f;

	private static int lastGUICheckFrame = -1;

	private static List<GameObject> reusableObjList = new List<GameObject>();

	public static RaycastResult ReturnClosestRaycastResult(List<RaycastResult> results)
	{
		if (results.Count == 0)
		{
			return default(RaycastResult);
		}
		RaycastResult raycastResult = results[0];
		for (int i = 1; i < results.Count; i++)
		{
			if (RaycastComparer(raycastResult, results[i]) > 0)
			{
				raycastResult = results[i];
			}
		}
		return raycastResult;
	}

	public static int RaycastComparer(RaycastResult lhs, RaycastResult rhs)
	{
		if (lhs.module != rhs.module)
		{
			Camera eventCamera = lhs.module.eventCamera;
			Camera eventCamera2 = rhs.module.eventCamera;
			if (eventCamera != null && eventCamera2 != null && eventCamera.depth != eventCamera2.depth)
			{
				if (eventCamera.depth < eventCamera2.depth)
				{
					return 1;
				}
				if (eventCamera.depth == eventCamera2.depth)
				{
					return 0;
				}
				return -1;
			}
			if (lhs.module.sortOrderPriority != rhs.module.sortOrderPriority)
			{
				return rhs.module.sortOrderPriority.CompareTo(lhs.module.sortOrderPriority);
			}
			if (lhs.module.renderOrderPriority != rhs.module.renderOrderPriority)
			{
				return rhs.module.renderOrderPriority.CompareTo(lhs.module.renderOrderPriority);
			}
		}
		if (lhs.sortingLayer != rhs.sortingLayer)
		{
			int layerValueFromID = SortingLayer.GetLayerValueFromID(rhs.sortingLayer);
			int layerValueFromID2 = SortingLayer.GetLayerValueFromID(lhs.sortingLayer);
			return layerValueFromID.CompareTo(layerValueFromID2);
		}
		if (lhs.sortingOrder != rhs.sortingOrder)
		{
			return rhs.sortingOrder.CompareTo(lhs.sortingOrder);
		}
		if (lhs.depth != rhs.depth && lhs.module.rootRaycaster == rhs.module.rootRaycaster)
		{
			return rhs.depth.CompareTo(lhs.depth);
		}
		if (lhs.distance != rhs.distance)
		{
			return lhs.distance.CompareTo(rhs.distance);
		}
		return lhs.index.CompareTo(rhs.index);
	}

	public static GameObject GivenUIRaycastHitReturnUIElementGameObject(GameObject hit)
	{
		if ((bool)hit.GetComponent<CoreButtonUnityGUI>())
		{
			return hit;
		}
		if ((bool)hit.GetComponent<CoreSliderUnityGUI>())
		{
			return hit;
		}
		if ((bool)hit.GetComponent<CoreScrollbarUnityGUI>())
		{
			return hit;
		}
		if ((bool)hit.GetComponent<ScrollRect>())
		{
			return hit;
		}
		if ((bool)hit.GetComponent<EventSenderUnityGUI>())
		{
			return hit;
		}
		if ((bool)hit.GetComponent<CursorUpdateArea>())
		{
			return hit;
		}
		if ((bool)hit.GetComponent<EventTrigger>())
		{
			return hit;
		}
		if (hit.transform.parent == null)
		{
			return null;
		}
		return GivenUIRaycastHitReturnUIElementGameObject(hit.transform.parent.gameObject);
	}

	public static RaycastHit GetClosestHitIgnoringObject(int hitNum, Vector3 refPos, RaycastHit[] results, GameObject objToIgnore, bool allowDisabledRenderers = true, bool allowPipes = true)
	{
		reusableObjList.Clear();
		if (objToIgnore != null)
		{
			reusableObjList.Add(objToIgnore);
		}
		return GetClosestHitIgnoringObjects(hitNum, refPos, results, reusableObjList, allowDisabledRenderers, allowPipes);
	}

	public static RaycastHit GetClosestHitIgnoringObjects(int hitNum, Vector3 refPos, RaycastHit[] results, List<GameObject> objsToIgnore, bool allowDisabledRenderers = true, bool allowPipes = true)
	{
		RaycastHit result = default(RaycastHit);
		float num = float.PositiveInfinity;
		for (int i = 0; i < hitNum; i++)
		{
			if (objsToIgnore != null)
			{
				bool flag = false;
				for (int j = 0; j < objsToIgnore.Count; j++)
				{
					if (objsToIgnore[j].transform.root == results[i].transform.root)
					{
						flag = true;
						break;
					}
				}
				if (flag)
				{
					continue;
				}
			}
			if (!allowPipes && (results[i].transform.root.gameObject.layer == buildNodeLayer || results[i].transform.root.gameObject.GetComponent<Pipe>() != null))
			{
				continue;
			}
			Renderer component = results[i].transform.GetComponent<Renderer>();
			if (!allowDisabledRenderers && component != null && !component.enabled)
			{
				Renderer renderer = null;
				if (component.transform.parent != null)
				{
					renderer = component.transform.parent.GetComponent<Renderer>();
				}
				if (renderer == null || !renderer.enabled)
				{
					continue;
				}
			}
			float num2 = Vector3.Distance(refPos, results[i].point);
			if (num2 < num)
			{
				num = num2;
				result = results[i];
			}
		}
		return result;
	}

	public static bool ObjectDraggingCheckBox(Vector3 center, Vector3 halfExtents, Quaternion rotation)
	{
		return Physics.CheckBox(center, halfExtents, rotation, objectDraggingMask);
	}

	public static bool GoodRaycast(Ray ray, out RaycastHit hitInfo, float dist)
	{
		return Physics.Raycast(ray, out hitInfo, dist, generalCastMask);
	}

	public static bool GoodRaycast(Vector3 origin, Vector3 direction, float dist)
	{
		return Physics.Raycast(origin, direction, dist, generalCastMask);
	}

	public static bool GoodRaycast(Vector3 origin, Vector3 direction, out RaycastHit hitInfo, float dist)
	{
		return Physics.Raycast(origin, direction, out hitInfo, dist, generalCastMask);
	}

	public static int GoodRaycastAllNonAlloc(Vector3 origin, Vector3 direction, float dist, RaycastHit[] results)
	{
		return Physics.RaycastNonAlloc(origin, direction, results, dist, generalCastMask);
	}

	public static int GoodRaycastAllNonAlloc(Ray ray, RaycastHit[] results)
	{
		return Physics.RaycastNonAlloc(ray, results);
	}

	public static int DogGrabberCastAllNonAlloc(Vector3 origin, Vector3 direction, RaycastHit[] results, float dist)
	{
		if (GlobalGUICheck())
		{
			return 0;
		}
		return Physics.RaycastNonAlloc(origin, direction, results, dist, dogGrabberMask);
	}

	public static bool GlobalGUICheck()
	{
		if (lastGUICheckFrame == Time.frameCount)
		{
			return GUIHit;
		}
		PointerEventData pointerEventData = new PointerEventData(EventSystem.current);
		pointerEventData.position = InputManager.MouseProvider.GetPosition();
		List<RaycastResult> list = new List<RaycastResult>();
		EventSystem.current.RaycastAll(pointerEventData, list);
		if (list.Count > 0)
		{
			GUIHit = true;
			return true;
		}
		if (uiCamRef == null)
		{
			uiCamRef = ObjectRegistration.GetRegistrationScript().GetGlobalComponent<Camera>(GlobalObject.UI_CAMERA);
		}
		if (mainCamRef == null)
		{
			mainCamRef = Camera.main;
		}
		lastGUICheckFrame = Time.frameCount;
		Ray ray = uiCamRef.ScreenPointToRay(InputManager.MouseProvider.GetPosition());
		GUIHit = Physics2D.Raycast(ray.origin, ray.direction, GUICastDist, guiMask);
		return GUIHit;
	}

	public static int BuildNodeCastAllNonAlloc(Ray ray, float dist, RaycastHit[] results)
	{
		return Physics.RaycastNonAlloc(ray, results, dist, buildNodeCastMask);
	}

	public static bool NavmeshCast(Vector3 pos, Vector3 dir, float dist)
	{
		return Physics.Raycast(pos, dir, dist, navmeshMask);
	}

	public static bool NavmeshCast(Vector3 pos, Vector3 dir, out RaycastHit hitInfo, float dist)
	{
		return Physics.Raycast(pos, dir, out hitInfo, dist, navmeshMask);
	}

	public static bool NavmeshBoxcast(Vector3 center, Vector3 halfExtents, Vector3 direction, Quaternion orient, float dist)
	{
		return Physics.BoxCast(center, halfExtents, direction, orient, dist, navmeshMask);
	}

	public static bool NavmeshPipeCast(Vector3 pos, Vector3 dir, float dist)
	{
		return Physics.Raycast(pos, dir, dist, navmeshPipeMask);
	}

	public static int NavmeshPipeCastAllNonAlloc(Vector3 origin, Vector3 dir, float dist, RaycastHit[] results)
	{
		dir = Vector3.Normalize(dir);
		return Physics.RaycastNonAlloc(origin, dir, results, dist, navmeshPipeMask);
	}

	public static bool NavmeshBoxcast(Vector3 center, Vector3 halfExtents, Vector3 direction, Quaternion orient, out RaycastHit hitInfo, float dist)
	{
		return Physics.BoxCast(center, halfExtents, direction, out hitInfo, orient, dist, navmeshMask);
	}

	public static int NavmeshBoxcastAllNonAlloc(Vector3 center, Vector3 halfExtents, Vector3 dir, Quaternion orient, float dist, RaycastHit[] results)
	{
		dir = Vector3.Normalize(dir);
		return Physics.BoxCastNonAlloc(center, halfExtents, dir, results, orient, dist, navmeshMask);
	}

	public static int NavmeshCastAllNonAlloc(Vector3 origin, Vector3 dir, float dist, RaycastHit[] results)
	{
		dir = Vector3.Normalize(dir);
		return Physics.RaycastNonAlloc(origin, dir, results, dist, navmeshMask);
	}

	public static bool StageRaycast(Vector3 origin, Vector3 direction, float dist)
	{
		return Physics.Raycast(origin, direction, dist, stageCastMask);
	}

	public static bool StageRaycast(Vector3 origin, Vector3 direction, out RaycastHit hitInfo, float dist)
	{
		return Physics.Raycast(origin, direction, out hitInfo, dist, stageCastMask);
	}

	public static bool StageRaycast(Ray ray, out RaycastHit hitInfo, float dist)
	{
		return Physics.Raycast(ray, out hitInfo, dist, stageCastMask);
	}

	public static int StageRaycastAllNonAlloc(Ray ray, float dist, RaycastHit[] results)
	{
		return Physics.RaycastNonAlloc(ray, results, dist, stageCastMask);
	}

	public static int StageRaycastAllNonAlloc(Vector3 origin, Vector3 direction, RaycastHit[] results, float dist)
	{
		return Physics.RaycastNonAlloc(origin, direction, results, dist, stageCastMask);
	}

	public static bool GoodBoxcast(Vector3 center, Vector3 halfExtents, Vector3 dir, Quaternion orient, float dist, out RaycastHit hitInfo)
	{
		return Physics.BoxCast(center, halfExtents, dir, out hitInfo, orient, (int)generalCastMask);
	}

	public static RaycastHit[] GoodBoxCastAll(Vector3 center, Vector3 halfExtents, Vector3 dir, Quaternion orient, float dist)
	{
		return Physics.BoxCastAll(center, halfExtents, dir, orient, dist, generalCastMask);
	}

	public static int GoodBoxCastAllNonAlloc(Vector3 center, Vector3 halfExtents, Vector3 dir, Quaternion orient, float dist, RaycastHit[] results)
	{
		dir = Vector3.Normalize(dir);
		return Physics.BoxCastNonAlloc(center, halfExtents, dir, results, orient, dist, generalCastMask);
	}

	public static int GoodBoxCastStageAllNonAlloc(Vector3 center, Vector3 halfExtents, Vector3 dir, Quaternion orient, float dist, RaycastHit[] results)
	{
		return Physics.BoxCastNonAlloc(center, halfExtents, dir, results, orient, dist, stageCastMask);
	}
}
