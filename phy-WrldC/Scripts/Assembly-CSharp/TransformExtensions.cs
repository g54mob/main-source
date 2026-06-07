using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class TransformExtensions
{
	public static Transform FindChildRecursively(this Transform transform, string name)
	{
		Transform[] componentsInChildren = transform.GetComponentsInChildren<Transform>(includeInactive: true);
		foreach (Transform transform2 in componentsInChildren)
		{
			if (transform2.name == name)
			{
				return transform2;
			}
		}
		return null;
	}

	public static T FindComponent<T>(this Transform transform, string name, bool isRecursively = false)
	{
		Transform transform2 = (isRecursively ? transform.FindChildRecursively(name) : transform.Find(name));
		if (transform2 == null)
		{
			Debug.LogWarning("Não foi possivel achar o GameObject com o nome: " + name);
			return default(T);
		}
		T component = transform2.GetComponent<T>();
		if (component == null)
		{
			Debug.LogWarning("Não foi possivel achar o Component do tipo: " + typeof(T));
			return default(T);
		}
		return component;
	}

	public static void RemoveAllChildren(this Transform transform, MonoBehaviour monoBehaviour = null)
	{
		List<GameObject> list = new List<GameObject>();
		bool flag = false;
		if (monoBehaviour != null)
		{
			flag = true;
		}
		for (int num = transform.childCount - 1; num >= 0; num--)
		{
			if (!flag)
			{
				Object.Destroy(transform.GetChild(num).gameObject);
			}
			else
			{
				transform.GetChild(num).gameObject.SetActive(value: false);
				list.Add(transform.GetChild(num).gameObject);
			}
		}
		transform.DetachChildren();
		if (flag)
		{
			monoBehaviour.StartCoroutine(RemovingAllChildren(list));
		}
	}

	private static IEnumerator RemovingAllChildren(List<GameObject> objectToRemove)
	{
		int i = objectToRemove.Count - 1;
		while (i >= 0)
		{
			Object.Destroy(objectToRemove[i]);
			yield return new WaitForEndOfFrame();
			int num = i - 1;
			i = num;
		}
	}

	public static void RemoveAllChildren(this Transform transform, int skipChildIndex)
	{
		List<Transform> list = new List<Transform>();
		int num = -1;
		foreach (Transform item in transform)
		{
			num++;
			if (num != skipChildIndex)
			{
				list.Add(item);
			}
		}
		foreach (Transform item2 in list)
		{
			Object.Destroy(item2.gameObject);
		}
	}

	public static void SetPositionX(this Transform transform, float x)
	{
		Vector3 position = transform.position;
		transform.position = new Vector3(x, position.y, position.z);
	}

	public static void SetPositionY(this Transform transform, float y)
	{
		Vector3 position = transform.position;
		transform.position = new Vector3(position.x, y, position.z);
	}

	public static void SetPositionZ(this Transform transform, float z)
	{
		Vector3 position = transform.position;
		transform.position = new Vector3(position.x, position.y, z);
	}

	public static void SetLocalPositionX(this Transform transform, float x)
	{
		Vector3 localPosition = transform.localPosition;
		transform.localPosition = new Vector3(x, localPosition.y, localPosition.z);
	}

	public static void SetLocalPositionY(this Transform transform, float y)
	{
		Vector3 localPosition = transform.localPosition;
		transform.localPosition = new Vector3(localPosition.x, y, localPosition.z);
	}

	public static void SetLocalPositionZ(this Transform transform, float z)
	{
		Vector3 localPosition = transform.localPosition;
		transform.localPosition = new Vector3(localPosition.x, localPosition.y, z);
	}

	public static void SetLocalScaleX(this Transform transform, float x)
	{
		Vector3 localScale = transform.localScale;
		transform.localScale = new Vector3(x, localScale.y, localScale.z);
	}

	public static void SetLocalScaleY(this Transform transform, float y)
	{
		Vector3 localScale = transform.localScale;
		transform.localScale = new Vector3(localScale.x, y, localScale.z);
	}

	public static void SetLocalScaleZ(this Transform transform, float z)
	{
		Vector3 localScale = transform.localScale;
		transform.localScale = new Vector3(localScale.x, localScale.y, z);
	}

	public static void SetEulerRotationX(this Transform transform, float x)
	{
		Vector3 eulerAngles = transform.rotation.eulerAngles;
		transform.rotation = Quaternion.Euler(x, eulerAngles.y, eulerAngles.z);
	}

	public static void SetEulerRotationY(this Transform transform, float y)
	{
		Vector3 eulerAngles = transform.rotation.eulerAngles;
		transform.rotation = Quaternion.Euler(eulerAngles.x, y, eulerAngles.z);
	}

	public static void SetEulerRotationZ(this Transform transform, float z)
	{
		Vector3 eulerAngles = transform.rotation.eulerAngles;
		transform.rotation = Quaternion.Euler(eulerAngles.x, eulerAngles.y, z);
	}

	public static void SetLocalEulerRotationX(this Transform transform, float x)
	{
		Vector3 eulerAngles = transform.localRotation.eulerAngles;
		transform.localRotation = Quaternion.Euler(x, eulerAngles.y, eulerAngles.z);
	}

	public static void SetLocalEulerRotationY(this Transform transform, float y)
	{
		Vector3 eulerAngles = transform.localRotation.eulerAngles;
		transform.localRotation = Quaternion.Euler(eulerAngles.x, y, eulerAngles.z);
	}

	public static void SetLocalEulerRotationZ(this Transform transform, float z)
	{
		Vector3 eulerAngles = transform.localRotation.eulerAngles;
		transform.localRotation = Quaternion.Euler(eulerAngles.x, eulerAngles.y, z);
	}
}
