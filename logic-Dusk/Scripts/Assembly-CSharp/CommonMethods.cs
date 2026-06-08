using System;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public static class CommonMethods
{
	public static TypeFilter SystemTypeFilter = InterfaceFilter;

	public static Rect KeepWindowVisible(Rect rect)
	{
		if (rect.x < 2f)
		{
			rect.x = 2f;
		}
		else if (rect.x >= (float)Screen.width - rect.width - 2f)
		{
			rect.x = (float)Screen.width - rect.width - 2f;
		}
		if (rect.y < 2f)
		{
			rect.y = 2f;
		}
		else if (rect.y >= (float)Screen.height - rect.height - 2f)
		{
			rect.y = (float)Screen.height - rect.height - 2f;
		}
		return rect;
	}

	public static bool AnyModifierKeysPressed()
	{
		return ControlKeyIsBeingPressed() || Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift) || Input.GetKey(KeyCode.LeftAlt) || Input.GetKey(KeyCode.RightAlt);
	}

	public static bool ControlKeyIsBeingPressed()
	{
		return Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.RightControl);
	}

	public static bool ControlKeyIsDown()
	{
		return Input.GetKeyDown(KeyCode.LeftControl) || Input.GetKeyDown(KeyCode.RightControl);
	}

	public static bool InterfaceFilter(Type typeObj, object criteriaObj)
	{
		if (typeObj.ToString() == criteriaObj.ToString())
		{
			return true;
		}
		return false;
	}

	public static float SplashDamage(float baseDamage, Vector3 sourceDamage, Vector3 targetDamage)
	{
		float num = Vector3.Distance(sourceDamage, targetDamage);
		float num2 = 1f / (num * num);
		return baseDamage * num2;
	}

	public static T PickRandomItem<T>(List<T> sourceList)
	{
		if (sourceList == null || sourceList.Count == 0)
		{
			return default(T);
		}
		if (sourceList.Count == 1)
		{
			return sourceList[0];
		}
		int index = UnityEngine.Random.Range(0, sourceList.Count);
		return sourceList[index];
	}

	public static T PickRandomItem<T>(T[] sourceArray)
	{
		if (sourceArray == null || sourceArray.Length == 0)
		{
			return default(T);
		}
		if (sourceArray.Length == 1)
		{
			return sourceArray[0];
		}
		int num = UnityEngine.Random.Range(0, sourceArray.Length);
		return sourceArray[num];
	}

	public static T PickRandomItem<T>(List<T> sourceList, System.Random randomGenerator)
	{
		if (sourceList == null || sourceList.Count == 0)
		{
			return default(T);
		}
		if (sourceList.Count == 1)
		{
			return sourceList[0];
		}
		int index = randomGenerator.Next(0, sourceList.Count);
		return sourceList[index];
	}

	public static T GetEnumFromString<T>(string stringEnumValue, T defaultValue)
	{
		try
		{
			return (T)Enum.Parse(typeof(T), stringEnumValue, true);
		}
		catch
		{
			Debug.Log("Error parsing enum value: " + stringEnumValue);
			return defaultValue;
		}
	}

	public static GameObject GetChildGameObject(GameObject fromGameObject, string withName)
	{
		Transform[] componentsInChildren = fromGameObject.transform.GetComponentsInChildren<Transform>();
		Transform[] array = componentsInChildren;
		foreach (Transform transform in array)
		{
			if (transform.gameObject.name == withName)
			{
				return transform.gameObject;
			}
		}
		return null;
	}

	public static float NextFloat(this System.Random random, float min, float max)
	{
		return min + (float)random.NextDouble() * (max - min);
	}

	public static string GetRevealedRoomDescription(RevealedRoomType revealedRoomType)
	{
		switch (revealedRoomType)
		{
		case RevealedRoomType.DeadDrone:
			return "Dormant drone";
		case RevealedRoomType.Loot:
			return "Scrap";
		default:
			return string.Empty;
		}
	}

	public static float CurveAngle(float from, float to, float step)
	{
		while (from < 0f)
		{
			from += (float)Math.PI;
		}
		while (from >= (float)Math.PI * 2f)
		{
			from -= (float)Math.PI * 2f;
		}
		while (to < 0f)
		{
			to += (float)Math.PI * 2f;
		}
		while (to >= (float)Math.PI * 2f)
		{
			to -= (float)Math.PI * 2f;
		}
		if (Math.Abs(from - to) < (float)Math.PI)
		{
			return Mathf.Lerp(from, to, step);
		}
		if (from < to)
		{
			from += (float)Math.PI * 2f;
		}
		else
		{
			to += (float)Math.PI * 2f;
		}
		float num = Mathf.Lerp(from, to, step);
		if (num >= (float)Math.PI * 2f)
		{
			num -= (float)Math.PI * 2f;
		}
		return num;
	}
}
