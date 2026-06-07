using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace Aux
{
	internal static class Helper
	{
		public enum Visibility
		{
			Show = 0,
			Hide = 1,
			Toggle = 2
		}

		private static Dictionary<string, UnityEngine.Object> loadedObjects = new Dictionary<string, UnityEngine.Object>();

		public static int VersionStringToInt(string version)
		{
			if (version == null || version.Length == 0)
			{
				return 0;
			}
			string[] array = version.Split('.');
			int num = Convert.ToInt32(array[0]);
			int num2 = Convert.ToInt32(array[1]);
			int num3 = Convert.ToInt32(array[2]);
			return num * 100000 + num2 * 1000 + num3;
		}

		public static UnityEngine.Object GetObjFromResources(string path)
		{
			if (!loadedObjects.ContainsKey(path))
			{
				loadedObjects.Add(path, Resources.Load(path));
			}
			return loadedObjects[path];
		}

		public static Vector3 TouchToWorldPoint(Touch touch, Camera cam)
		{
			return cam.ScreenToWorldPoint(touch.position);
		}

		public static GameObject Find(string name, bool findHidden = true)
		{
			GameObject gameObject = GameObject.Find(name);
			if (!gameObject && findHidden)
			{
				return Resources.FindObjectsOfTypeAll<GameObject>().ToList().Find((GameObject i) => i.name == name);
			}
			return gameObject;
		}

		public static void SetVisibility(GameObject go, Visibility visibility)
		{
			switch (visibility)
			{
			case Visibility.Show:
				go.SetActive(value: true);
				break;
			case Visibility.Hide:
				go.SetActive(value: false);
				break;
			default:
				go.SetActive(!go.activeSelf);
				break;
			}
		}

		public static GameObject SetVisibility(string name, Visibility visibility)
		{
			GameObject gameObject = Find(name);
			if ((bool)gameObject)
			{
				SetVisibility(gameObject, visibility);
			}
			return gameObject;
		}

		public static Vector3[] GetWorldCorners(RectTransform rt)
		{
			Vector3[] array = new Vector3[4];
			rt.GetWorldCorners(array);
			return array;
		}

		public static void Rotate(Vector3 start, Vector3 end, Transform rotate)
		{
			rotate.rotation = Quaternion.identity;
			rotate.Rotate(0f, 0f, -57.29578f * Mathf.Atan2(end.x - start.x, end.y - start.y));
		}

		public static Rect GetWorldRect(RectTransform rt)
		{
			Vector3[] worldCorners = GetWorldCorners(rt);
			Rect result = Rect.MinMaxRect(0f, 0f, 0f, 0f);
			result.position = worldCorners[0];
			result.size = worldCorners[2] - worldCorners[0];
			return result;
		}

		public static void SetVisibility(GameObject[] objs, Visibility visibility)
		{
			for (int i = 0; i < objs.Length; i++)
			{
				SetVisibility(objs[i], visibility);
			}
		}

		public static void SetVisibility(string[] names, Visibility visibility)
		{
			for (int i = 0; i < names.Length; i++)
			{
				SetVisibility(names[i], visibility);
			}
		}

		public static T GetChild<T>(GameObject obj, int i)
		{
			if ((bool)obj)
			{
				return obj.transform.GetChild(i).gameObject.GetComponent<T>();
			}
			return default(T);
		}

		public static T GetChild<T>(GameObject obj, string name)
		{
			if ((bool)obj)
			{
				Transform transform = obj.transform.Find(name);
				if ((bool)transform)
				{
					return transform.gameObject.GetComponent<T>();
				}
			}
			return default(T);
		}

		public static void ButtonInteractible(Button button, bool interactible, Color activeColor, Color inactiveColor)
		{
			button.interactable = interactible;
			button.GetComponent<Image>().color = (interactible ? activeColor : inactiveColor);
		}

		public static void ButtonInteractible(Button button, bool interactible, Sprite activeSprite, Sprite inactiveSprite)
		{
			button.interactable = interactible;
			button.GetComponent<Image>().sprite = (interactible ? activeSprite : inactiveSprite);
		}

		public static Vector2 GetSnapToPositionToBringChildIntoView(ScrollRect instance, RectTransform child)
		{
			Canvas.ForceUpdateCanvases();
			Vector2 vector = instance.viewport.localPosition;
			Vector2 vector2 = child.localPosition;
			return new Vector2(0f, 0f - (vector.y + vector2.y));
		}

		public static bool IsVector2InWorldRect(RectTransform rectTransform, Vector2 vec2)
		{
			return GetWorldRect(rectTransform).Contains(vec2);
		}

		public static bool IsVector2InFrame(Vector2 point, Rect outerRect, Rect innerRect)
		{
			if (outerRect.Contains(point))
			{
				return !innerRect.Contains(point);
			}
			return false;
		}

		public static bool IsRectVector2InFrame(Rect rect, Rect outerRect, Rect innerRect)
		{
			if (!IsVector2InFrame(new Vector2(rect.xMin, rect.yMin), outerRect, innerRect) && !IsVector2InFrame(new Vector2(rect.xMax, rect.yMin), outerRect, innerRect) && !IsVector2InFrame(new Vector2(rect.xMin, rect.yMax), outerRect, innerRect))
			{
				return IsVector2InFrame(new Vector2(rect.xMax, rect.yMax), outerRect, innerRect);
			}
			return true;
		}

		public static List<Vector2> GetRectVector2sInFrame(Rect rect, Rect outerRect, Rect innerRect)
		{
			List<Vector2> list = new List<Vector2>();
			Vector2 one = Vector2.one;
			one.Set(rect.xMin, rect.yMin);
			if (IsVector2InFrame(one, outerRect, innerRect))
			{
				list.Add(one);
			}
			one.Set(rect.xMax, rect.yMin);
			if (IsVector2InFrame(one, outerRect, innerRect))
			{
				list.Add(one);
			}
			one.Set(rect.xMin, rect.yMax);
			if (IsVector2InFrame(one, outerRect, innerRect))
			{
				list.Add(one);
			}
			one.Set(rect.xMax, rect.yMax);
			if (IsVector2InFrame(one, outerRect, innerRect))
			{
				list.Add(one);
			}
			return list;
		}

		public static List<Vector2> GetRectVector2s(Rect rect)
		{
			Vector2 one = Vector2.one;
			List<Vector2> list = new List<Vector2>();
			one.Set(rect.xMin, rect.yMin);
			list.Add(one);
			one.Set(rect.xMax, rect.yMin);
			list.Add(one);
			one.Set(rect.xMax, rect.yMax);
			list.Add(one);
			one.Set(rect.xMin, rect.yMax);
			list.Add(one);
			return list;
		}

		public static bool RectContainsRect(Rect mainRect, Rect innerRect)
		{
			foreach (Vector2 rectVector in GetRectVector2s(innerRect))
			{
				if (!mainRect.Contains(rectVector))
				{
					return false;
				}
			}
			return true;
		}

		public static Rect ExpandRect(Rect rect, float units)
		{
			Rect result = default(Rect);
			Vector2 max = rect.max;
			Vector2 min = rect.min;
			max.x += units;
			max.y += units;
			min.x -= units;
			min.y -= units;
			result.max = max;
			result.min = min;
			return result;
		}
	}
}
