using System;
using System.Collections.Generic;
using UnityEngine;

public class BoundingBoxComponent : MonoBehaviour
{
	public bool markDogPosition;

	public bool allowTriggers;

	public List<Collider> collidersToIgnore = new List<Collider>();

	public bool debugVisIndividual;

	public int lastUpdateTime = -1;

	public Vector3 containmentOffset;

	public Vector3 containmentCenterOffset;

	private bool debugVis;

	private int collidersToIgnoreCount;

	private int sigDigs = 3;

	private int posTries = 20;

	private float goodLocationMax = 10f;

	private float maxIncrement = 2f;

	private RaycastHit[] hits = new RaycastHit[100];

	private Vector3 boxSize;

	private Vector3 boxCenter;

	private float debugDuration;

	private Color debugColor = Color.blue;

	private float defaultDebugDuration;

	private Color defaultDebugColor = Color.blue;

	private float maxUp = float.PositiveInfinity;

	private float minUp = float.NegativeInfinity;

	private float maxLeft = float.PositiveInfinity;

	private float minLeft = float.NegativeInfinity;

	private float maxForwards = float.PositiveInfinity;

	private float minForwards = float.NegativeInfinity;

	private bool hasCachedColliders;

	private Type sphereColliderType = typeof(SphereCollider);

	private int colliderCount;

	private Collider[] colliderCache;

	private Type[] colliderTypeCache;

	private DogHome dogHomeRef;

	private ObjectRegistration regRef;

	private void Awake()
	{
		regRef = ObjectRegistration.GetRegistrationScript();
	}

	private void Update()
	{
		if (debugVis || debugVisIndividual)
		{
			UpdateBoundingBox();
		}
		if (markDogPosition)
		{
			UpdateDogPositionGrid();
		}
	}

	public Vector3 GetBoxSize(bool checkDisabledColliders = false)
	{
		UpdateBoundingBox(forceCheck: false, checkDisabledColliders);
		return boxSize;
	}

	public float GetMaxBound(bool checkDisabledColliders = false)
	{
		UpdateBoundingBox(forceCheck: false, checkDisabledColliders);
		return Mathf.Max(boxSize.x, Mathf.Max(boxSize.y, boxSize.z));
	}

	public float GetMinBound(bool checkDisabledColliders = false)
	{
		UpdateBoundingBox(forceCheck: false, checkDisabledColliders);
		return Mathf.Min(boxSize.x, Mathf.Min(boxSize.y, boxSize.z));
	}

	public Vector3 GetBoxCenter(bool checkDisabledColliders = false)
	{
		UpdateBoundingBox(forceCheck: false, checkDisabledColliders);
		return boxCenter;
	}

	public bool CheckStageIntersect(bool forceCheck = false)
	{
		UpdateBoundingBox(forceCheck);
		int num = RaycastUtil.GoodBoxCastStageAllNonAlloc(boxCenter, boxSize, Vector3.up, Quaternion.identity, 0f, hits);
		for (int i = 0; i < num; i++)
		{
			if (!(hits[i].transform.root == base.transform.root))
			{
				return true;
			}
		}
		return false;
	}

	public bool CheckGlobalIntersect(bool allowDogIntersection = false, bool forceCheck = false, List<GameObject> toIgnore = null)
	{
		UpdateBoundingBox(forceCheck);
		int num = RaycastUtil.GoodBoxCastAllNonAlloc(boxCenter, boxSize, Vector3.up, Quaternion.identity, 0f, hits);
		for (int i = 0; i < num; i++)
		{
			if (!(hits[i].transform.root == base.transform.root) && (!allowDogIntersection || !hits[i].transform.root.CompareTag(Tags.DOG)) && (toIgnore == null || (!toIgnore.Contains(hits[i].transform.gameObject) && !toIgnore.Contains(hits[i].transform.root.gameObject))))
			{
				return true;
			}
		}
		return false;
	}

	public List<RaycastHit> GetGlobalIntersections(bool allowDogIntersection = false, bool forceCheck = false, List<GameObject> toIgnore = null, bool updateBoundingBox = true)
	{
		List<RaycastHit> list = new List<RaycastHit>();
		if (updateBoundingBox)
		{
			UpdateBoundingBox(forceCheck);
		}
		int num = RaycastUtil.GoodBoxCastAllNonAlloc(boxCenter, boxSize, Vector3.up, Quaternion.identity, 0f, hits);
		for (int i = 0; i < num; i++)
		{
			if (!(hits[i].transform.root == base.transform.root) && (!allowDogIntersection || !hits[i].transform.root.CompareTag(Tags.DOG)) && (toIgnore == null || (!toIgnore.Contains(hits[i].transform.gameObject) && !toIgnore.Contains(hits[i].transform.root.gameObject))))
			{
				list.Add(hits[i]);
			}
		}
		return list;
	}

	public bool CheckBoxContained(BoundingBoxComponent b2)
	{
		b2.UpdateBoundingBox();
		return CheckBoxContained(b2.boxCenter + b2.containmentCenterOffset, b2.boxSize + b2.containmentOffset);
	}

	public bool CheckBoxContained(Vector3 otherCenter, Vector3 otherSize)
	{
		UpdateBoundingBox();
		debugDuration = 4f;
		DebugDrawBox(boxCenter, boxSize);
		DebugDrawBox(otherCenter, otherSize);
		debugDuration = defaultDebugDuration;
		return DoesAContainB(otherCenter, otherSize, boxCenter, boxSize);
	}

	public static bool DoesAContainB(Vector3 aCenter, Vector3 aSize, Vector3 bCenter, Vector3 bSize)
	{
		if (Mathf.Abs(bCenter.x - aCenter.x) <= aSize.x - bSize.x && Mathf.Abs(bCenter.y - aCenter.y) <= aSize.y - bSize.y && Mathf.Abs(bCenter.z - aCenter.z) <= aSize.z - bSize.z)
		{
			return true;
		}
		return false;
	}

	public bool DoesThisBoxContainOther(Vector3 otherCenter, Vector3 otherSize)
	{
		UpdateBoundingBox();
		debugDuration = 4f;
		DebugDrawBox(boxCenter, boxSize);
		DebugDrawBox(otherCenter, otherSize);
		debugDuration = defaultDebugDuration;
		return DoesAContainB(boxCenter, boxSize, otherCenter, otherSize);
	}

	public bool IsPointInsideBox(Vector3 point)
	{
		return DoesThisBoxContainOther(point, new Vector3(0.01f, 0.01f, 0.01f));
	}

	public bool CheckBoxIntersect(BoundingBoxComponent b2)
	{
		if (b2 == null)
		{
			return false;
		}
		b2.UpdateBoundingBox();
		return CheckBoxIntersect(b2.boxCenter, b2.boxSize);
	}

	public static bool CheckBoxBoxIntersect(Vector3 aC, Vector3 aS, Vector3 bC, Vector3 bS)
	{
		float num = aS.x + bS.x;
		float num2 = Mathf.Abs(aC.x - bC.x);
		if (num2 < num && !MathUtil.AlmostEqual(num2, num))
		{
			float num3 = aS.y + bS.y;
			float num4 = Mathf.Abs(aC.y - bC.y);
			if (num4 < num3 && !MathUtil.AlmostEqual(num4, num3))
			{
				float num5 = aS.z + bS.z;
				float num6 = Mathf.Abs(aC.z - bC.z);
				if (num6 < num5 && !MathUtil.AlmostEqual(num6, num5))
				{
					return true;
				}
			}
		}
		return false;
	}

	public bool CheckBoxIntersect(Vector3 otherCenter, Vector3 otherSize)
	{
		UpdateBoundingBox();
		debugDuration = 4f;
		DebugDrawBox(boxCenter, boxSize);
		DebugDrawBox(otherCenter, otherSize);
		debugDuration = defaultDebugDuration;
		return CheckBoxBoxIntersect(boxCenter, boxSize, otherCenter, otherSize);
	}

	private void ClearCheckVars()
	{
		maxUp = float.PositiveInfinity;
		minUp = float.NegativeInfinity;
		maxLeft = float.PositiveInfinity;
		minLeft = float.NegativeInfinity;
		maxForwards = float.PositiveInfinity;
		minForwards = float.NegativeInfinity;
	}

	private void StoreDogHomeRef()
	{
		if (!(dogHomeRef != null))
		{
			dogHomeRef = regRef.GetGlobalComponent<DogHome>(GlobalObject.DOG_HOME, nullAllowed: true);
		}
	}

	public RoomBase GetCurrentRoom(bool requireInRoom = false, bool requireIntersectInstead = false)
	{
		ulong? roomUID = GetRoomUID(requireInRoom, requireIntersectInstead);
		if (!roomUID.HasValue)
		{
			return null;
		}
		StoreDogHomeRef();
		return dogHomeRef.GetRoomForUID(roomUID.Value);
	}

	public ulong? GetRoomUID(bool requireInRoom = false, bool requireIntersectInstead = false)
	{
		if (dogHomeRef == null)
		{
			StoreDogHomeRef();
			if (dogHomeRef == null)
			{
				return null;
			}
		}
		ulong? uIDForDenBBCIsInsideOf = DenInteriorManager.GetUIDForDenBBCIsInsideOf(this);
		if (uIDForDenBBCIsInsideOf.HasValue)
		{
			GameObject placeableObjectForUID = regRef.GetPlaceableObjectForUID(uIDForDenBBCIsInsideOf.Value);
			if (placeableObjectForUID == null)
			{
				return null;
			}
			return dogHomeRef.GetRoomUIDForBoundingBox(placeableObjectForUID.GetComponent<BoundingBoxComponent>(), requireInRoom, requireIntersectInstead);
		}
		return dogHomeRef.GetRoomUIDForBoundingBox(this, requireInRoom, requireIntersectInstead);
	}

	private bool IsGoodLocationValid(Vector3 originalPosition, BoundingBoxComponent bbc, Vector3 inc, int up = 0, int left = 0, int forwards = 0, bool requireInRoom = false, List<GameObject> toIgnore = null, bool allowDogIntersection = true)
	{
		if ((float)up >= maxUp || (float)up <= minUp)
		{
			return false;
		}
		if ((float)left >= maxLeft || (float)left <= minLeft)
		{
			return false;
		}
		if ((float)forwards >= maxForwards || (float)forwards <= minForwards)
		{
			return false;
		}
		base.transform.position = originalPosition + Vector3.up * inc.y * up + Vector3.left * inc.x * left + Vector3.forward * inc.z * forwards;
		UpdateBoundingBox(forceCheck: true);
		if ((requireInRoom && CheckBoxContained(bbc)) || (!requireInRoom && CheckBoxIntersect(bbc)))
		{
			if (!CheckGlobalIntersect(allowDogIntersection, forceCheck: false, toIgnore))
			{
				return true;
			}
		}
		else if (up > 0 && left == 0 && forwards == 0)
		{
			maxUp = up;
		}
		else if (up < 0 && left == 0 && forwards == 0)
		{
			minUp = up;
		}
		else if (left > 0 && up == 0 && forwards == 0)
		{
			maxLeft = left;
		}
		else if (left < 0 && up == 0 && forwards == 0)
		{
			minLeft = left;
		}
		else if (forwards > 0 && up == 0 && left == 0)
		{
			maxForwards = forwards;
		}
		else if (forwards < 0 && up == 0 && left == 0)
		{
			minForwards = forwards;
		}
		return false;
	}

	public bool MoveToGoodLocation(ulong? expectedRoom = null, List<GameObject> toIgnore = null, GameObject denInterior = null, bool allowDogIntersection = true)
	{
		try
		{
			debugDuration = 4f;
			debugColor = Color.red;
			return MoveToGoodLocationInternal(expectedRoom, toIgnore, denInterior, allowDogIntersection);
		}
		finally
		{
			debugColor = defaultDebugColor;
			debugDuration = defaultDebugDuration;
		}
	}

	private bool CheckAllLocations(Vector3 originalPos, BoundingBoxComponent bbc, Vector3 inc, int posTries, List<GameObject> toIgnore = null, bool allowDogIntersection = true)
	{
		ClearCheckVars();
		Vector3 zero = Vector3.zero;
		for (int i = 0; i < posTries; i++)
		{
			zero.y = -i;
			for (int j = -i; j <= i; j++)
			{
				for (int k = -i; k <= i; k++)
				{
					for (int l = -i; l <= i; l++)
					{
						if (j >= i || j <= -i || k >= i || k <= -i || l >= i || l <= -i)
						{
							zero.x = k;
							zero.y = j;
							zero.z = l;
							if (IsGoodLocationValid(originalPos, bbc, inc, left: (int)zero.x, up: (int)zero.y, forwards: (int)zero.z, requireInRoom: true, toIgnore: toIgnore, allowDogIntersection: allowDogIntersection))
							{
								return true;
							}
						}
					}
				}
			}
		}
		return false;
	}

	private bool MoveToGoodLocationInternal(ulong? expectedRoom, List<GameObject> toIgnore = null, GameObject denInterior = null, bool allowDogIntersection = true)
	{
		UpdateBoundingBox();
		if (!CheckGlobalIntersect(allowDogIntersection, forceCheck: true))
		{
			return true;
		}
		BoundingBoxComponent boundingBoxComponent = null;
		if (denInterior != null)
		{
			boundingBoxComponent = denInterior.GetComponent<BoundingBoxComponent>();
			MoveInsideObject(boundingBoxComponent.GetBoxSize() + boundingBoxComponent.containmentOffset, boundingBoxComponent.GetBoxCenter() + boundingBoxComponent.containmentCenterOffset, denInterior.ToString());
		}
		else if (expectedRoom.HasValue)
		{
			if (dogHomeRef == null)
			{
				StoreDogHomeRef();
				if (dogHomeRef == null)
				{
					return false;
				}
			}
			boundingBoxComponent = dogHomeRef.GetRoomForUID(expectedRoom.Value).GetComponent<BoundingBoxComponent>();
		}
		ulong? num = expectedRoom;
		if (!num.HasValue && denInterior == null)
		{
			num = GetRoomUID();
			if (!num.HasValue && denInterior == null)
			{
				return false;
			}
			if (num.HasValue)
			{
				boundingBoxComponent = dogHomeRef.GetRoomForUID(num.Value).GetComponent<BoundingBoxComponent>();
			}
		}
		if (boundingBoxComponent == null)
		{
			return false;
		}
		if (num.HasValue && num != GetRoomUID(requireInRoom: true))
		{
			MoveInsideRoom(num.Value);
		}
		float x = Mathf.Min(boxSize.x * 2f * goodLocationMax / (float)posTries, maxIncrement);
		float y = Mathf.Min(boxSize.y * 2f * goodLocationMax / (float)posTries, maxIncrement);
		float z = Mathf.Min(boxSize.z * 2f * goodLocationMax / (float)posTries, maxIncrement);
		Vector3 inc = new Vector3(x, y, z);
		Vector3 position = base.transform.position;
		if (CheckAllLocations(position, boundingBoxComponent, inc, posTries, toIgnore, allowDogIntersection))
		{
			if (base.gameObject != null)
			{
				ObjectConnectionsManager.OnObjectTeleported(base.gameObject, (position - base.transform.position) * -1f);
			}
			return true;
		}
		base.transform.position = position;
		return false;
	}

	public void MoveInsideRoom(ulong roomUID)
	{
		BoundingBoxComponent bBCForRoomUID = dogHomeRef.GetBBCForRoomUID(roomUID);
		Vector3 objectSize = bBCForRoomUID.GetBoxSize() + bBCForRoomUID.containmentOffset;
		Vector3 objectCenter = bBCForRoomUID.GetBoxCenter() + bBCForRoomUID.containmentCenterOffset;
		MoveInsideObject(objectSize, objectCenter, bBCForRoomUID.gameObject.ToString());
	}

	public void MoveInsideObject(Vector3 objectSize, Vector3 objectCenter, string debugName = "NoDebugName")
	{
		if (boxSize.x > objectSize.x || boxSize.y > objectSize.y || boxSize.z > objectSize.z)
		{
			Debug.LogError(string.Concat("Cannot move object: ", base.gameObject, " inside object: ", debugName, " because it is larger than it."));
			return;
		}
		float num = 0.1f;
		Vector3 vector = boxCenter;
		float num2 = objectCenter.x - objectSize.x + boxSize.x + num;
		float num3 = objectCenter.x + objectSize.x - boxSize.x - num;
		if (boxCenter.x < num2)
		{
			vector.x = num2;
		}
		else if (boxCenter.x > num3)
		{
			vector.x = num3;
		}
		float num4 = objectCenter.y - objectSize.y + boxSize.y + num;
		float num5 = objectCenter.y + objectSize.y - boxSize.y - num;
		if (boxCenter.y < num4)
		{
			vector.y = num4;
		}
		else if (boxCenter.y > num5)
		{
			vector.y = num5;
		}
		float num6 = objectCenter.z - objectSize.z + boxSize.z + num;
		float num7 = objectCenter.z + objectSize.z - boxSize.z - num;
		if (boxCenter.z < num6)
		{
			vector.z = num6;
		}
		else if (boxCenter.z > num7)
		{
			vector.z = num7;
		}
		if (base.transform.position != vector)
		{
			Vector3 position = base.transform.position;
			Vector3 vector2 = boxCenter - base.transform.position;
			base.transform.position = vector - vector2;
			if (base.gameObject != null)
			{
				ObjectConnectionsManager.OnObjectTeleported(base.gameObject, (position - base.transform.position) * -1f);
			}
			UpdateBoundingBox(forceCheck: true);
		}
	}

	private void UpdateDogPositionGrid()
	{
		UpdateBoundingBox();
		ulong? roomUID = GetRoomUID();
		if (roomUID.HasValue)
		{
			dogHomeRef.GetRoomForUID(roomUID.Value).ReportDogPositions(this);
		}
	}

	public void ForceUpdateBoundingBox(bool checkDisabledColliders = false)
	{
		UpdateBoundingBox(forceCheck: true, checkDisabledColliders);
	}

	private void UpdateBoundingBox(bool forceCheck = false, bool checkDisabledColliders = false)
	{
		if (lastUpdateTime != Time.frameCount || forceCheck)
		{
			lastUpdateTime = Time.frameCount;
			Vector3 negMax = new Vector3(float.PositiveInfinity, float.PositiveInfinity, float.PositiveInfinity);
			Vector3 posMax = new Vector3(float.NegativeInfinity, float.NegativeInfinity, float.NegativeInfinity);
			UpdateMaximumsForTransform(ref negMax, ref posMax, base.transform, checkDisabledColliders);
			float x = MathUtil.Round(Mathf.Abs(negMax.x - posMax.x), sigDigs);
			float y = MathUtil.Round(Mathf.Abs(negMax.y - posMax.y), sigDigs);
			float z = MathUtil.Round(Mathf.Abs(negMax.z - posMax.z), sigDigs);
			boxSize = new Vector3(x, y, z) / 2f;
			DebugDrawBox(boxCenter = new Vector3(negMax.x + boxSize.x, negMax.y + boxSize.y, negMax.z + boxSize.z), boxSize);
		}
	}

	private void DebugDrawBox(Vector3 debugCenter, Vector3 debugSize, Color? colorOverride = null, bool force = false)
	{
		if (debugVis || debugVisIndividual || force)
		{
			Color value = debugColor;
			if (colorOverride.HasValue)
			{
				value = colorOverride.Value;
			}
			DebugUtil.DrawBox(debugCenter, debugSize, value, debugDuration);
			if (containmentOffset != Vector3.zero || containmentCenterOffset != Vector3.zero)
			{
				DebugUtil.DrawBox(debugCenter + containmentCenterOffset, debugSize + containmentOffset, value, debugDuration);
			}
		}
	}

	public void ClearColliderCache()
	{
		hasCachedColliders = false;
	}

	private void CacheColliders()
	{
		hasCachedColliders = true;
		collidersToIgnoreCount = collidersToIgnore.Count;
		colliderCache = GetComponentsInChildren<Collider>();
		colliderCount = colliderCache.Length;
		colliderTypeCache = new Type[colliderCount];
		for (int i = 0; i < colliderCount; i++)
		{
			colliderTypeCache[i] = colliderCache[i].GetType();
		}
	}

	private void UpdateMaximumsForTransform(ref Vector3 negMax, ref Vector3 posMax, Transform t, bool checkDisabledColliders = false)
	{
		if (t.localScale == Vector3.zero)
		{
			return;
		}
		if (!hasCachedColliders)
		{
			CacheColliders();
		}
		for (int i = 0; i < colliderCount; i++)
		{
			Collider collider = colliderCache[i];
			if (!(collider == null) && collider.gameObject.activeSelf && !(collider.transform.localScale == Vector3.zero) && (collidersToIgnoreCount <= 0 || !collidersToIgnore.Contains(collider)))
			{
				UpdateMaximumsForCollider(ref negMax, ref posMax, collider, colliderTypeCache[i]);
			}
		}
	}

	private void UpdateMaximumsForCollider(ref Vector3 negMax, ref Vector3 posMax, Collider col, Type colliderType)
	{
		if (!col.isTrigger || allowTriggers)
		{
			bool flag = false;
			if (!col.enabled)
			{
				col.enabled = true;
				flag = true;
			}
			Vector3 vector = col.bounds.min;
			Vector3 vector2 = col.bounds.max;
			if (colliderType == sphereColliderType)
			{
				Vector3 vector3 = col.transform.TransformPoint(((SphereCollider)col).center);
				Vector3 vector4 = ((SphereCollider)col).radius * col.transform.lossyScale;
				vector = vector3 - vector4;
				vector2 = vector3 + vector4;
			}
			if (vector.x < negMax.x)
			{
				negMax.x = vector.x;
			}
			if (vector.y < negMax.y)
			{
				negMax.y = vector.y;
			}
			if (vector.z < negMax.z)
			{
				negMax.z = vector.z;
			}
			if (vector2.x > posMax.x)
			{
				posMax.x = vector2.x;
			}
			if (vector2.y > posMax.y)
			{
				posMax.y = vector2.y;
			}
			if (vector2.z > posMax.z)
			{
				posMax.z = vector2.z;
			}
			if (flag)
			{
				col.enabled = false;
			}
		}
	}
}
