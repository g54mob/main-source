using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class UnityUtils
{
	public const string YELLOW = "#FFBD18FF";

	public const string GREEN = "#A9E216FF";

	public const string RED = "#F14247FF";

	public static void GetFullPath(Transform node, ref string result)
	{
		if (node.parent != null && node.parent.parent != null)
		{
			string result2 = string.Empty;
			GetFullPath(node.parent, ref result2);
			result = result2 + "/" + node.name;
		}
		else
		{
			result = node.name;
		}
	}

	public static IEnumerator MoveTransform(Transform o, Vector3 t, float time)
	{
		return MoveTransform(o, t, time, 0f, destroy: false);
	}

	public static IEnumerator MoveTransform(Transform o, Vector3 t, float time, bool destroy)
	{
		return MoveTransform(o, t, time, 0f, destroy);
	}

	public static IEnumerator MoveTransform(Transform o, Vector3 t, float time, float pause, bool destroy)
	{
		if (pause != 0f)
		{
			yield return new WaitForSeconds(pause);
		}
		float delta = Vector3.Distance(o.position, t);
		if (delta > 1E-05f)
		{
			if (time == 0f)
			{
				o.position = t;
			}
			else
			{
				while (Vector3.Distance(o.position, t) > 1E-05f)
				{
					o.position = Vector3.MoveTowards(o.position, t, delta / time * Time.deltaTime);
					yield return new WaitForEndOfFrame();
				}
			}
		}
		if (destroy)
		{
			UnityEngine.Object.Destroy(o.gameObject);
		}
	}

	public static IEnumerator RotateTransform(Transform o, Quaternion t, float time)
	{
		float delta = Quaternion.Angle(o.rotation, t);
		if (!(delta > 1E-05f))
		{
			yield break;
		}
		if (time == 0f)
		{
			o.rotation = t;
			yield break;
		}
		while (Quaternion.Angle(o.rotation, t) > 1E-05f)
		{
			o.rotation = Quaternion.RotateTowards(o.rotation, t, delta / time * Time.deltaTime);
			yield return new WaitForEndOfFrame();
		}
	}

	public static Vector3 GetBounds(GameObject g)
	{
		Vector3 result = Vector3.zero;
		MeshFilter[] componentsInChildren = g.GetComponentsInChildren<MeshFilter>();
		MeshFilter meshFilter = null;
		MeshFilter[] array = componentsInChildren;
		foreach (MeshFilter meshFilter2 in array)
		{
			if (meshFilter2 != null && (meshFilter == null || meshFilter2.mesh.bounds.size.magnitude > meshFilter.mesh.bounds.size.magnitude))
			{
				meshFilter = meshFilter2;
			}
		}
		if (meshFilter != null)
		{
			result = meshFilter.mesh.bounds.size;
		}
		return result;
	}

	public static Matrix4x4 MatrixFromAxisAngle(Vector3 a, float angle)
	{
		float num = Mathf.Cos(angle);
		float num2 = Mathf.Sin(angle);
		float num3 = 1f - num;
		Matrix4x4 result = new Matrix4x4
		{
			m00 = num + a.x * a.x * num3,
			m11 = num + a.y * a.y * num3,
			m22 = num + a.z * a.z * num3
		};
		float num4 = a.x * a.y * num3;
		float num5 = a.z * num2;
		result.m10 = num4 + num5;
		result.m01 = num4 - num5;
		num4 = a.x * a.z * num3;
		num5 = a.y * num2;
		result.m20 = num4 - num5;
		result.m02 = num4 + num5;
		num4 = a.y * a.z * num3;
		num5 = a.x * num2;
		result.m21 = num4 + num5;
		result.m12 = num4 - num5;
		return result;
	}

	public static Vector3 GetRandomVector3(float range, Vector3 mult)
	{
		return new Vector3((UnityEngine.Random.value - 0.5f) * range * mult.x, (UnityEngine.Random.value - 0.5f) * range * mult.y, (UnityEngine.Random.value - 0.5f) * range * mult.z);
	}

	public static int ClampCircle(int value, int minValue, int maxValue)
	{
		if (value <= maxValue && value >= minValue)
		{
			return value;
		}
		return value % maxValue - 1 + minValue;
	}

	public static Vector3 GetRandomVector3InRange(Vector3 range)
	{
		return new Vector3(UnityEngine.Random.value * range.x, UnityEngine.Random.value * range.y, UnityEngine.Random.value * range.z);
	}

	public static Vector3 GetRandomVector3(Vector3 range)
	{
		return new Vector3((UnityEngine.Random.value - 0.5f) * range.x, (UnityEngine.Random.value - 0.5f) * range.y, (UnityEngine.Random.value - 0.5f) * range.z);
	}

	public static Vector3 GetRandomVector3(float range)
	{
		return GetRandomVector3(range, Vector3.one);
	}

	public static Vector3 Vector3Division(Vector3 a, Vector3 b)
	{
		return new Vector3(a.x / b.x, a.y / b.y, a.z / b.z);
	}

	public static Vector3 Vector3Mult(Vector3 a, Vector3 b)
	{
		return new Vector3(a.x * b.x, a.y * b.y, a.z * b.z);
	}

	public static long MoveTowards(long current, long target, long delta)
	{
		return Math.Min(current + delta, target);
	}

	public static int HashOnLayer(string layerName, string stateName)
	{
		return Animator.StringToHash(layerName.Trim() + "." + stateName.Trim());
	}

	public static int HashOnBaseLayer(string stateName)
	{
		return Animator.StringToHash("Base Layer." + stateName.Trim());
	}

	public static Transform[] GetChildren(Transform root)
	{
		List<Transform> list = new List<Transform>();
		if (root != null)
		{
			Transform[] componentsInChildren = root.GetComponentsInChildren<Transform>(includeInactive: true);
			foreach (Transform transform in componentsInChildren)
			{
				if (!(transform == root))
				{
					list.Add(transform);
					list.AddRange(GetChildren(transform));
				}
			}
		}
		return list.ToArray();
	}

	public static GameObject CloneUIElement(GameObject original)
	{
		GameObject gameObject = UnityEngine.Object.Instantiate(original);
		gameObject.transform.SetParent(original.transform.parent, worldPositionStays: false);
		return gameObject;
	}

	public static Vector2 GetCanvasCoordinated(RectTransform canvasRect, Vector3 worldPosition, bool clampOnCanvas)
	{
		Camera main = Camera.main;
		Vector3 vector = main.WorldToScreenPoint(worldPosition);
		Vector2 localPoint = Vector2.zero;
		RectTransformUtility.ScreenPointToLocalPointInRectangle(canvasRect, vector, main, out localPoint);
		if (clampOnCanvas)
		{
			float width = canvasRect.rect.width;
			float height = canvasRect.rect.height;
			localPoint = new Vector2(Mathf.Clamp(localPoint.x, (0f - width) / 2f, width / 2f), Mathf.Clamp(localPoint.y, (0f - height) / 2f, height / 2f));
		}
		return localPoint;
	}

	public static void SortChildrenByParentDistanceR(Transform current)
	{
		List<Transform> list = new List<Transform>();
		foreach (Transform item in current)
		{
			list.Add(item);
			SortChildrenByParentDistanceR(item);
		}
		list.Sort((Transform t1, Transform t2) => string.Compare(t1.name, t2.name));
		list.Sort(CompareTransform);
		foreach (Transform item2 in list)
		{
			item2.parent = item2.parent;
		}
	}

	public static int CompareTransform(Transform t1, Transform t2)
	{
		if (t1.parent == null || t2.parent == null)
		{
			return 0;
		}
		float num = Vector3.Distance(t1.position, t1.parent.position);
		float num2 = Vector3.Distance(t2.position, t2.parent.position);
		return (int)num - (int)num2;
	}

	public static int CompareTransform(Component t1, Component t2)
	{
		float num = Vector3.Distance(t1.transform.position, t1.transform.parent.position);
		float num2 = Vector3.Distance(t2.transform.position, t2.transform.parent.position);
		return (int)num - (int)num2;
	}

	public static string GetDeltaString(int delta)
	{
		string arg = "white";
		if (delta < 0)
		{
			arg = "#F14247FF";
		}
		else if (delta > 0)
		{
			arg = "#A9E216FF";
		}
		string arg2 = "";
		if (delta > 0)
		{
			arg2 = "+";
		}
		else if (delta < 0)
		{
			arg2 = "-";
		}
		return $"<color={arg}>{arg2}{Math.Abs(delta)}</color>";
	}

	public static double MoveTowards(double current, double target, double maxDelta)
	{
		if (Math.Abs(target - current) <= maxDelta)
		{
			return target;
		}
		return current + (double)Math.Sign(target - current) * maxDelta;
	}
}
