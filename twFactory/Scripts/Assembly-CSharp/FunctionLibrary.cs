using System;
using System.Collections.Generic;
using System.Text;
using Unity.AI.Navigation;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.EventSystems;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class FunctionLibrary
{
	public static List<GameObject> OverlapBoxIgnoringObjects(Vector3 center, Vector3 halfExtents, Quaternion rotation, int layerMask = -1, GameObject[] ignoredObjects = null)
	{
		Collider[] array = Physics.OverlapBox(center, halfExtents, rotation, layerMask);
		List<GameObject> list = new List<GameObject>();
		for (int i = 0; i < array.Length; i++)
		{
			if (ignoredObjects == null || !ignoredObjects.Contains(array[i].gameObject))
			{
				list.Add(array[i].gameObject);
			}
		}
		return list;
	}

	public static bool SpehereCastAllIgnoringObjects(Ray ray, float radius, float maxDistance, int layerMask, GameObject[] ignoredObjects)
	{
		RaycastHit[] array = Physics.SphereCastAll(ray, radius, maxDistance, layerMask);
		GameObject[] array2 = new GameObject[array.Length];
		for (int i = 0; i < array.Length; i++)
		{
			array2[i] = array[i].collider.gameObject;
		}
		return !ignoredObjects.ContainsAll(array2);
	}

	public static List<GameObject> OverlapSphereIgnoringObjects(Vector3 origin, float radius, int layerMask, GameObject[] ignoredObjects)
	{
		Collider[] array = Physics.OverlapSphere(origin, radius, layerMask);
		List<GameObject> list = new List<GameObject>();
		for (int i = 0; i < array.Length; i++)
		{
			if (ignoredObjects == null || !ignoredObjects.Contains(array[i].gameObject))
			{
				list.Add(array[i].gameObject);
			}
		}
		return list;
	}

	public static List<Collider> OverlapSphereCheckingTag(Vector3 origin, float radius, int layerMask, string tagToCheck)
	{
		Collider[] array = Physics.OverlapSphere(origin, radius, layerMask);
		List<Collider> list = new List<Collider>();
		for (int i = 0; i < array.Length; i++)
		{
			if (array[i].gameObject.CompareTag(tagToCheck))
			{
				list.Add(array[i]);
			}
		}
		return list;
	}

	public static bool IsInLayerMask(GameObject obj, LayerMask layerMask)
	{
		return (layerMask.value & (1 << obj.layer)) > 0;
	}

	public static float GetObjectRadius(GameObject go)
	{
		CharacterController component = go.GetComponent<CharacterController>();
		if ((bool)component)
		{
			return component.radius;
		}
		NavMeshAgent component2 = go.GetComponent<NavMeshAgent>();
		if ((bool)component2)
		{
			return component2.radius;
		}
		CapsuleCollider component3 = go.GetComponent<CapsuleCollider>();
		if ((bool)component3)
		{
			return component3.radius;
		}
		SphereCollider component4 = go.GetComponent<SphereCollider>();
		if ((bool)component4)
		{
			return component4.radius;
		}
		BoxCollider component5 = go.GetComponent<BoxCollider>();
		if ((bool)component5)
		{
			return Mathf.Max(component5.size.x, component5.size.z);
		}
		return 0f;
	}

	public static float GetObjectHeight(GameObject go)
	{
		if (go.TryGetComponent<CapsuleCollider>(out var component))
		{
			return component.height + component.center.y;
		}
		if (go.TryGetComponent<BoxCollider>(out var component2))
		{
			return component2.size.y;
		}
		if (go.TryGetComponent<CharacterController>(out var component3))
		{
			return component3.height;
		}
		if (go.TryGetComponent<NavMeshAgent>(out var component4))
		{
			return component4.height;
		}
		if (go.TryGetComponent<MeshCollider>(out var component5))
		{
			return component5.bounds.size.y;
		}
		return 0f;
	}

	public static float SqrDistanceBetweenObjects(GameObject go1, GameObject go2)
	{
		float objectRadius = GetObjectRadius(go1);
		float objectRadius2 = GetObjectRadius(go2);
		Vector3 vector = go2.transform.position - go1.transform.position;
		return Vector3.SqrMagnitude(vector - vector.normalized * objectRadius - vector.normalized * objectRadius2);
	}

	public static float SqrDistanceBetweenObjectAndPosition(GameObject go, Vector3 position)
	{
		float objectRadius = GetObjectRadius(go);
		Vector3 vector = position - go.transform.position;
		return Vector3.SqrMagnitude(vector - vector.normalized * objectRadius);
	}

	public static float GetNavMeshDistance(Vector3 startPosition, Vector3 endPosition)
	{
		float num = 0f;
		NavMeshPath navMeshPath = new NavMeshPath();
		if (NavMesh.SamplePosition(startPosition, out var hit, 2f, -1))
		{
			startPosition = hit.position;
		}
		if (NavMesh.SamplePosition(endPosition, out hit, 2f, -1))
		{
			endPosition = hit.position;
		}
		navMeshPath.ClearCorners();
		NavMesh.CalculatePath(startPosition, endPosition, -1, navMeshPath);
		if (navMeshPath.status == NavMeshPathStatus.PathComplete)
		{
			for (int i = 0; i < navMeshPath.corners.Length - 1; i++)
			{
				num += Vector3.Distance(navMeshPath.corners[i], navMeshPath.corners[i + 1]);
			}
			return num;
		}
		return -1f;
	}

	public static Vector3[] GetPositionsAroundPosition(Vector3 targetPosition, float range, float checkRadius, Vector3 startDirection)
	{
		Vector3 vector = startDirection.normalized;
		if (startDirection.sqrMagnitude == 0f)
		{
			startDirection = Vector3.forward;
		}
		float num = checkRadius + range;
		int num2 = (int)(MathF.PI * 2f * num / (checkRadius * 2f));
		float y = 360f / (float)num2;
		vector *= num;
		Vector3[] array = new Vector3[num2];
		for (int i = 0; i < num2; i++)
		{
			array[i] = targetPosition + vector;
			vector = Quaternion.Euler(0f, y, 0f) * vector;
		}
		return array;
	}

	public static Vector3[] GetPositionsAroundBox(Vector3 centerPosition, BoxCollider box, Quaternion boxRotation, float range, float checkRadius)
	{
		Vector3 zero = Vector3.zero;
		float num = checkRadius * 2f;
		int num2 = (int)Mathf.Floor(box.size.z / num);
		float num3 = num + (box.size.z / num - (float)num2) / (float)Mathf.Max(num2 - 1, 1);
		int num4 = (int)Mathf.Floor(box.size.x / num);
		float num5 = num + (box.size.x / num - (float)num4) / (float)Mathf.Max(num4 - 1, 1);
		Vector3[] array = new Vector3[(num2 + num4) * 2];
		for (int i = 0; i < num2 * 2; i += 2)
		{
			zero.x = box.size.x * 0.5f + range + checkRadius;
			zero.z = box.size.z * 0.5f - checkRadius - num3 * (float)i / 2f;
			array[i] = centerPosition + boxRotation * zero;
			zero.x *= -1f;
			array[i + 1] = centerPosition + boxRotation * zero;
		}
		for (int j = 0; j < num4 * 2; j += 2)
		{
			zero.z = box.size.z * 0.5f + range + checkRadius;
			zero.x = box.size.x * 0.5f - checkRadius - num5 * (float)j / 2f;
			array[num2 * 2 + j] = centerPosition + boxRotation * zero;
			zero.z *= -1f;
			array[num2 * 2 + j + 1] = centerPosition + boxRotation * zero;
		}
		return array;
	}

	public static bool IsPositionFree(Vector3 position, float radius, bool ignoreIfMoving = true, int layerMask = 0, GameObject[] objectsToIgnore = null)
	{
		List<GameObject> list = OverlapSphereIgnoringObjects(position, radius, layerMask, objectsToIgnore);
		if (list.Count == 0)
		{
			return true;
		}
		for (int i = 0; i < list.Count && !(list[i] == null); i++)
		{
			if (!ignoreIfMoving || !list[i].GetComponent<MovementComponent>() || !list[i].GetComponent<MovementComponent>().IsMoving())
			{
				return false;
			}
		}
		return true;
	}

	public static bool IsPositionReachable(Vector3 startPosition, Vector3 targetPosition, out NavMeshPath path)
	{
		path = new NavMeshPath();
		NavMesh.CalculatePath(startPosition, targetPosition, -1, path);
		return path.status == NavMeshPathStatus.PathComplete;
	}

	public static bool IsPositionFreeAndReachable(Vector3 targetPosition, Vector3 startPosition, float checkRadius, int collisionLayer = 0, GameObject[] ignoredObjects = null, bool ignoreIfMoving = true)
	{
		if (!IsPositionReachable(startPosition, targetPosition, out var _))
		{
			return false;
		}
		if (!IsPositionFree(targetPosition, checkRadius, ignoreIfMoving, collisionLayer, ignoredObjects))
		{
			return false;
		}
		return true;
	}

	public static bool GetFreeAndReachablePositionAroundPosition(Vector3 targetPosition, Vector3 startPosition, float checkRadius, float range, out Vector3 resultPosition, int collisionLayer = 0, GameObject[] ignoredObjects = null, bool ignoreIfMoving = true)
	{
		Vector3[] positionsAroundPosition = GetPositionsAroundPosition(targetPosition, range, checkRadius, startPosition - targetPosition);
		positionsAroundPosition = positionsAroundPosition.PingPongSort();
		for (int i = 0; i < positionsAroundPosition.Length; i++)
		{
			if (IsPositionFreeAndReachable(positionsAroundPosition[i], startPosition, checkRadius, collisionLayer, ignoredObjects, ignoreIfMoving))
			{
				resultPosition = positionsAroundPosition[i];
				return true;
			}
		}
		resultPosition = Vector3.zero;
		return false;
	}

	public static bool GetFreeAndReachablePositionAroundBox(Vector3 centerPosition, BoxCollider box, Quaternion boxRotation, Vector3 startPosition, float checkRadius, float range, out Vector3 resultPosition, int collisionLayer = 0, GameObject[] ignoredObjects = null, bool ignoreIfMoving = true)
	{
		Vector3[] positionsAroundBox = GetPositionsAroundBox(centerPosition, box, boxRotation, range, checkRadius);
		Array.Sort(positionsAroundBox, (Vector3 a, Vector3 b) => Vector3.SqrMagnitude(a - startPosition).CompareTo(Vector3.SqrMagnitude(b - startPosition)));
		for (int num = 0; num < positionsAroundBox.Length; num++)
		{
			if (IsPositionFreeAndReachable(positionsAroundBox[num], startPosition, checkRadius, collisionLayer, ignoredObjects, ignoreIfMoving))
			{
				resultPosition = positionsAroundBox[num];
				return true;
			}
		}
		resultPosition = Vector3.zero;
		return false;
	}

	public static bool Check2SpheresOverlap(Vector3 sp1Pos, Vector3 sp2Pos, float sp1Radius, float sp2Radius)
	{
		return (sp1Pos - sp2Pos).sqrMagnitude <= Mathf.Pow(sp1Radius + sp2Radius, 2f);
	}

	public static string FormatText(string textToFormat, int maxCharactersPerLine)
	{
		string text = "";
		string[] array = textToFormat.Split('\n');
		string[] array2 = array;
		foreach (string text2 in array2)
		{
			List<string> list = ExtractWords(text2);
			int num = 0;
			for (int j = 0; j < list.Count; j++)
			{
				string text3 = list[j];
				int num2 = CalculateEffectiveLength(text3);
				if (num + ((num > 0) ? 1 : 0) + num2 > maxCharactersPerLine)
				{
					text += "\n";
					num = 0;
				}
				if (num > 0 && (text3.Length != 1 || (text3[0] != ',' && text3[0] != '.')))
				{
					text += " ";
					num++;
				}
				text += text3;
				num += num2;
			}
			if (!text2.Equals(array[^1]))
			{
				text += "\n";
			}
		}
		return text;
	}

	private static List<string> ExtractWords(string line)
	{
		List<string> list = new List<string>();
		StringBuilder stringBuilder = new StringBuilder();
		bool flag = false;
		bool flag2 = false;
		for (int i = 0; i < line.Length; i++)
		{
			char c = line[i];
			switch (c)
			{
			case '<':
				if (i + 1 < line.Length && line[i + 1] == '/')
				{
					flag2 = true;
				}
				else if (stringBuilder.Length > 0 && !flag)
				{
					list.Add(stringBuilder.ToString());
					stringBuilder.Clear();
				}
				flag = true;
				break;
			case '>':
				if (flag2)
				{
					flag = false;
					flag2 = false;
					stringBuilder.Append(c);
					list.Add(stringBuilder.ToString().Trim());
					stringBuilder.Clear();
					continue;
				}
				flag = false;
				break;
			}
			stringBuilder.Append(c);
			if (c == ' ' && stringBuilder.Length > 1 && !flag)
			{
				list.Add(stringBuilder.ToString().Trim());
				stringBuilder.Clear();
			}
		}
		if (stringBuilder.Length > 0)
		{
			list.Add(stringBuilder.ToString().Trim());
		}
		return list;
	}

	private static int CalculateEffectiveLength(string word)
	{
		bool flag = false;
		int num = 0;
		for (int i = 0; i < word.Length; i++)
		{
			switch (word[i])
			{
			case '<':
				flag = true;
				continue;
			case '>':
				flag = false;
				continue;
			}
			if (!flag)
			{
				num++;
			}
		}
		return num;
	}

	public static string MillisecondsToHourMinuteSeconds(int timeInMilliseconds, bool removeZeroHours = true)
	{
		TimeSpan timeSpan = TimeSpan.FromMilliseconds(timeInMilliseconds);
		string text = $"{timeSpan.Hours:D2}:{timeSpan.Minutes:D2}:{timeSpan.Seconds:D2}";
		if (removeZeroHours && int.Parse(text.Split(':')[0]) <= 0)
		{
			text = text.Substring(3);
		}
		return text;
	}

	public static float RoundToDecimals(float number, int decimalsAmount)
	{
		return Mathf.Round(number * Mathf.Pow(10f, decimalsAmount)) / Mathf.Pow(10f, decimalsAmount);
	}

	public static bool IsPositionInsideCircle(Vector2 position, Vector2 circleCenter, float circleRadius)
	{
		return (position - circleCenter).sqrMagnitude <= circleRadius * circleRadius;
	}

	public static float[] DistributePercentage(int count)
	{
		float[] array = new float[count];
		float num = 0.01f;
		float num2 = num * (float)count;
		if (num2 > 1f)
		{
			Debug.LogError("Not possible to distribute percentages with the given constraints.");
			return array;
		}
		float num3 = 1f - num2;
		float num4 = 0f;
		for (int i = 0; i < count; i++)
		{
			array[i] = UnityEngine.Random.value;
			num4 += array[i];
		}
		for (int j = 0; j < count; j++)
		{
			array[j] = array[j] / num4 * num3 + num;
		}
		return array;
	}

	public static T TryToGetObjectUnderCursor<T>(EventSystem evenSys, GraphicRaycaster graphicRaycaster = null) where T : MonoBehaviour
	{
		List<RaycastResult> list = new List<RaycastResult>();
		PointerEventData pointerEventData = new PointerEventData(evenSys);
		pointerEventData.position = Input.mousePosition;
		if ((bool)graphicRaycaster)
		{
			graphicRaycaster.Raycast(pointerEventData, list);
		}
		else
		{
			evenSys.RaycastAll(pointerEventData, list);
		}
		if (list.Count > 0)
		{
			foreach (RaycastResult item in list)
			{
				T componentInParent = item.gameObject.GetComponentInParent<T>();
				if (componentInParent != null)
				{
					return componentInParent;
				}
			}
		}
		return null;
	}

	public static List<Mesh> GetMeshes(GameObject go)
	{
		List<Mesh> list = new List<Mesh>();
		MeshFilter[] componentsInChildren = go.GetComponentsInChildren<MeshFilter>();
		foreach (MeshFilter meshFilter in componentsInChildren)
		{
			list.Add(meshFilter.sharedMesh);
		}
		SkinnedMeshRenderer[] componentsInChildren2 = go.GetComponentsInChildren<SkinnedMeshRenderer>();
		foreach (SkinnedMeshRenderer skinnedMeshRenderer in componentsInChildren2)
		{
			list.Add(skinnedMeshRenderer.sharedMesh);
		}
		return list;
	}

	public static List<Renderer> GetMeshRenderers(GameObject go, bool searchInChildren = true)
	{
		List<Renderer> list = new List<Renderer>();
		MeshRenderer[] array = (searchInChildren ? go.GetComponentsInChildren<MeshRenderer>() : go.GetComponents<MeshRenderer>());
		foreach (MeshRenderer item in array)
		{
			list.Add(item);
		}
		SkinnedMeshRenderer[] array2 = (searchInChildren ? go.GetComponentsInChildren<SkinnedMeshRenderer>() : go.GetComponents<SkinnedMeshRenderer>());
		foreach (SkinnedMeshRenderer item2 in array2)
		{
			list.Add(item2);
		}
		return list;
	}

	public static Bounds GetTotalBounds(GameObject go, bool includeInactive = true)
	{
		Bounds result = default(Bounds);
		MeshFilter[] componentsInChildren = go.GetComponentsInChildren<MeshFilter>();
		foreach (MeshFilter meshFilter in componentsInChildren)
		{
			if ((includeInactive || meshFilter.gameObject.activeSelf) && (bool)meshFilter.sharedMesh)
			{
				Bounds bounds = meshFilter.sharedMesh.bounds;
				bounds.size.Scale(meshFilter.transform.localScale);
				if (result.extents == Vector3.zero)
				{
					result = bounds;
				}
				else
				{
					result.Encapsulate(bounds);
				}
			}
		}
		SkinnedMeshRenderer[] componentsInChildren2 = go.GetComponentsInChildren<SkinnedMeshRenderer>();
		foreach (SkinnedMeshRenderer skinnedMeshRenderer in componentsInChildren2)
		{
			if (includeInactive || skinnedMeshRenderer.gameObject.activeSelf)
			{
				Bounds bounds = skinnedMeshRenderer.sharedMesh.bounds;
				bounds.size.Scale(skinnedMeshRenderer.transform.localScale);
				if (result.extents == Vector3.zero)
				{
					result = bounds;
				}
				else
				{
					result.Encapsulate(bounds);
				}
			}
		}
		result.min.Set(result.min.x, 0f, result.min.z);
		return result;
	}

	public static Bounds GetTotalColliderBounds(GameObject go)
	{
		Bounds bounds = default(Bounds);
		Bounds bounds2 = bounds;
		Collider[] componentsInChildren = go.GetComponentsInChildren<Collider>();
		foreach (Collider collider in componentsInChildren)
		{
			if (collider is BoxCollider)
			{
				BoxCollider boxCollider = (BoxCollider)collider;
				bounds2 = new Bounds(boxCollider.center, boxCollider.size);
				bounds2.size.Scale(collider.transform.localScale);
			}
			else if (collider is SphereCollider)
			{
				SphereCollider sphereCollider = (SphereCollider)collider;
				bounds2 = new Bounds(sphereCollider.center, Vector3.one * sphereCollider.radius);
			}
			else if (collider is MeshCollider)
			{
				bounds2 = ((MeshCollider)collider).bounds;
			}
			if (bounds.extents == Vector3.zero)
			{
				bounds = bounds2;
			}
			else
			{
				bounds.Encapsulate(bounds2);
			}
		}
		bounds.min.Set(bounds.min.x, 0f, bounds.min.z);
		return bounds;
	}

	public static void SetGameObjectListActive(List<GameObject> goList, bool active = true)
	{
		foreach (GameObject go in goList)
		{
			go.SetActive(active);
		}
	}

	public static void SetRenderersShadowsOnly(List<GameObject> goList, bool shadowsOnly = true)
	{
		foreach (GameObject go in goList)
		{
			Renderer[] componentsInChildren = go.GetComponentsInChildren<Renderer>();
			for (int i = 0; i < componentsInChildren.Length; i++)
			{
				componentsInChildren[i].shadowCastingMode = ((!shadowsOnly) ? ShadowCastingMode.On : ShadowCastingMode.ShadowsOnly);
			}
		}
	}

	public static void RebuildAllNavMesh()
	{
		foreach (NavMeshSurface activeSurface in NavMeshSurface.activeSurfaces)
		{
			activeSurface.BuildNavMesh();
		}
	}

	public static bool Compare(int ownNumber, int otherNumber, EComparison comparison)
	{
		return Compare((float)ownNumber, (float)otherNumber, comparison);
	}

	public static bool Compare(float ownNumber, float otherNumber, EComparison comparison)
	{
		return comparison switch
		{
			EComparison.Equals => ownNumber == otherNumber, 
			EComparison.NotEquals => ownNumber != otherNumber, 
			EComparison.Greater => ownNumber > otherNumber, 
			EComparison.Lesser => ownNumber < otherNumber, 
			EComparison.GreaterEquals => ownNumber >= otherNumber, 
			EComparison.LesserEquals => ownNumber <= otherNumber, 
			_ => false, 
		};
	}
}
