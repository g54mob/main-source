using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using PajamaLlama.Debugs;
using UnityEngine;

public class FlotsamGame : MonoBehaviour
{
	public static void CleanList<T>(List<T> inputList)
	{
		for (int num = inputList.Count - 1; num >= 0; num--)
		{
			if (inputList[num] == null)
			{
				inputList.RemoveAt(num);
			}
		}
	}

	public static bool ListsMatch<T>(List<T> firstList, List<T> secondList)
	{
		if (firstList.Count != secondList.Count)
		{
			return false;
		}
		for (int i = 0; i < firstList.Count; i++)
		{
			if (!EqualityComparer<T>.Default.Equals(firstList[i], secondList[i]))
			{
				return false;
			}
		}
		return true;
	}

	public static bool IsCloser(Vector3 referencePosition, Vector3 newPosition, Vector3 formerClosestPosition)
	{
		return Vector3.Distance(referencePosition, newPosition) < Vector3.Distance(referencePosition, formerClosestPosition);
	}

	public static List<T> ReturnClosest<T>(Vector3 referencePosition, List<T> inputList, int amount) where T : MonoBehaviour
	{
		List<T> list = inputList.OrderBy((T element) => Vector3.Distance(referencePosition, element.transform.position)).ToList();
		if (list.Count > amount)
		{
			return list.GetRange(0, amount);
		}
		return list;
	}

	public static T ReturnClosest<T>(Vector3 referencePosition, List<T> inputList) where T : MonoBehaviour
	{
		return inputList.OrderBy((T element) => Vector3.Distance(referencePosition, element.transform.position)).FirstOrDefault();
	}

	public static Vector3 SetX(Vector3 vector, float x)
	{
		return new Vector3(x, vector.y, vector.z);
	}

	public static Vector3 SetY(Vector3 vector, float y)
	{
		return new Vector3(vector.x, y, vector.z);
	}

	public static Vector3 SetZ(Vector3 vector, float z)
	{
		return new Vector3(vector.x, vector.y, z);
	}

	public static Vector2 RemapVector(Vector2 value, Vector2 originalRangeMin, Vector2 originalRangeMax, Vector2 targetRangeMin, Vector2 targetRangeMax)
	{
		float x = RemapRange(value.x, originalRangeMin.x, originalRangeMax.x, targetRangeMin.x, targetRangeMax.x);
		float y = RemapRange(value.y, originalRangeMin.y, originalRangeMax.y, targetRangeMin.y, targetRangeMax.y);
		return new Vector2(x, y);
	}

	public static Vector3 RemapVector(Vector3 value, Vector3 originalRangeMin, Vector3 originalRangeMax, Vector3 targetRangeMin, Vector3 targetRangeMax)
	{
		float x = RemapRange(value.x, originalRangeMin.x, originalRangeMax.x, targetRangeMin.x, targetRangeMax.x);
		float y = RemapRange(value.y, originalRangeMin.y, originalRangeMax.y, targetRangeMin.y, targetRangeMax.y);
		float z = RemapRange(value.z, originalRangeMin.z, originalRangeMax.z, targetRangeMin.z, targetRangeMax.z);
		return new Vector3(x, y, z);
	}

	public static void SetWorldScale(Transform targetTransform, Vector3 targetScale)
	{
		Vector3 vector = Vector3.one;
		Transform parent = targetTransform.parent;
		while (parent != null)
		{
			vector = new Vector3(vector.x * parent.localScale.x, vector.y * parent.localScale.y, vector.z * parent.localScale.z);
			parent = parent.parent;
		}
		Vector3 localScale = new Vector3(targetScale.x / vector.x, targetScale.y / vector.y, targetScale.z / vector.z);
		Debugger.Log("Converted scale: " + localScale);
		targetTransform.localScale = localScale;
	}

	public static Vector2 MultiplyVectors(Vector2 firstVector, Vector2 secondVector)
	{
		return new Vector2(firstVector.x * secondVector.x, firstVector.y * secondVector.y);
	}

	public static Vector3 MultiplyVectors(Vector3 firstVector, Vector3 secondVector)
	{
		return new Vector3(firstVector.x * secondVector.x, firstVector.y * secondVector.y, firstVector.z * secondVector.z);
	}

	public static T CopyComponent<T>(T original, GameObject destination) where T : Component
	{
		Type type = original.GetType();
		Component component = destination.AddComponent(type);
		FieldInfo[] fields = type.GetFields();
		foreach (FieldInfo fieldInfo in fields)
		{
			fieldInfo.SetValue(component, fieldInfo.GetValue(original));
		}
		return component as T;
	}

	public static Collider CopyCollider(GameObject inputObject, GameObject outputObject, bool disableInputCollider = true)
	{
		Collider component = inputObject.GetComponent<Collider>();
		Collider collider = CopyComponent(component, outputObject);
		if (collider is BoxCollider)
		{
			BoxCollider component2 = inputObject.GetComponent<BoxCollider>();
			BoxCollider obj = collider as BoxCollider;
			obj.size = component2.size;
			obj.center = component2.center;
		}
		else if (collider is CapsuleCollider)
		{
			CapsuleCollider component3 = inputObject.GetComponent<CapsuleCollider>();
			CapsuleCollider obj2 = collider as CapsuleCollider;
			obj2.center = component3.center;
			obj2.radius = component3.radius;
			obj2.height = component3.height;
			obj2.direction = component3.direction;
		}
		else if (collider is SphereCollider)
		{
			SphereCollider component4 = inputObject.GetComponent<SphereCollider>();
			SphereCollider obj3 = collider as SphereCollider;
			obj3.radius = component4.radius;
			obj3.center = component4.center;
		}
		else if (collider is MeshCollider)
		{
			MeshCollider component5 = inputObject.GetComponent<MeshCollider>();
			MeshCollider obj4 = collider as MeshCollider;
			obj4.convex = component5.convex;
			obj4.sharedMesh = component5.sharedMesh;
		}
		if (disableInputCollider)
		{
			component.enabled = false;
		}
		return collider;
	}

	public static T Random<T>(IReadOnlyList<T> inputList)
	{
		if (inputList == null)
		{
			Debugger.Warning($"Given list for random {typeof(T).FullName} is null.");
			return default(T);
		}
		if (inputList.Count == 0)
		{
			Debugger.Warning($"Given list for random {typeof(T).FullName} is empty.");
			return default(T);
		}
		return inputList[UnityEngine.Random.Range(0, inputList.Count)];
	}

	public static T Random<T>(T[] inputArray)
	{
		if (inputArray == null)
		{
			Debugger.Warning($"Given array for random {typeof(T).FullName} is null.");
			return default(T);
		}
		if (inputArray.Length == 0)
		{
			Debugger.Warning($"Given array for random {typeof(T).FullName} is empty.");
			return default(T);
		}
		return inputArray[UnityEngine.Random.Range(0, inputArray.Length)];
	}

	public static T RandomEnum<T>() where T : IConvertible
	{
		if (!typeof(T).IsEnum)
		{
			throw new ArgumentException("Random Enum method requires input type enum.");
		}
		Array values = Enum.GetValues(typeof(T));
		if (values.Length == 0)
		{
			Debugger.Warning($"Given array for random {typeof(T).FullName} is empty.");
			return default(T);
		}
		return (T)values.GetValue(UnityEngine.Random.Range(0, values.Length));
	}

	public static T Random<T>(List<T> inputList, out int index)
	{
		index = -1;
		if (inputList == null)
		{
			Debugger.Warning($"Given list for random {typeof(T).FullName} is null.");
			return default(T);
		}
		if (inputList.Count == 0)
		{
			Debugger.Warning($"Given list for random {typeof(T).FullName} is empty.");
			return default(T);
		}
		index = UnityEngine.Random.Range(0, inputList.Count);
		return inputList[index];
	}

	public static Vector3 RandomPosition(Vector3 centerPosition, float range, bool useGaussian, float clearRadius = 0f)
	{
		if (range < clearRadius)
		{
			Debugger.Error("Clear center can't be bigger than the range!");
			return Vector3.zero;
		}
		Vector3 vector;
		if (useGaussian)
		{
			float x = RandomFromDistribution.RandomRangeNormalDistribution(0f - range, range, RandomFromDistribution.ConfidenceLevel_e._99);
			float z = RandomFromDistribution.RandomRangeNormalDistribution(0f - range, range, RandomFromDistribution.ConfidenceLevel_e._99);
			vector = new Vector3(x, 0f, z);
		}
		else
		{
			vector = SetY(UnityEngine.Random.insideUnitSphere * range, 0f);
		}
		if (Vector3.Distance(Vector3.zero, vector) < clearRadius)
		{
			float num = (float)UnityEngine.Random.Range(0, 1) * (range - clearRadius) + clearRadius;
			vector += (vector - Vector3.zero).normalized * num;
		}
		return vector + centerPosition;
	}

	public static Quaternion PointsToRotation(Vector3 firstPoint, Vector3 secondPoint, bool level)
	{
		if (level)
		{
			firstPoint.y = 0f;
			secondPoint.y = 0f;
		}
		return Quaternion.LookRotation((secondPoint - firstPoint).normalized);
	}

	public static float RemapRange(float value, float originalRangeMin, float originalRangeMax, float targetRangeMin, float targetRangeMax)
	{
		return Mathf.Lerp(targetRangeMin, targetRangeMax, Mathf.InverseLerp(originalRangeMin, originalRangeMax, value));
	}

	public static float RemapRange(float value, float originalRangeMax, float targetRangeMax)
	{
		return Mathf.Lerp(0f, targetRangeMax, Mathf.InverseLerp(0f, originalRangeMax, value));
	}
}
