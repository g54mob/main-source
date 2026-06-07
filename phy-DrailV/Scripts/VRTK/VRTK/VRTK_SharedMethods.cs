using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR;

namespace VRTK
{
	public static class VRTK_SharedMethods
	{
		public static Bounds GetBounds(Transform transform, Transform excludeRotation = null, Transform excludeTransform = null)
		{
			Quaternion rotation = Quaternion.identity;
			if (excludeRotation != null)
			{
				rotation = excludeRotation.rotation;
				excludeRotation.rotation = Quaternion.identity;
			}
			bool flag = false;
			Bounds result = new Bounds(transform.position, Vector3.zero);
			Renderer[] componentsInChildren = transform.GetComponentsInChildren<Renderer>();
			foreach (Renderer renderer in componentsInChildren)
			{
				if (!(excludeTransform != null) || !renderer.transform.IsChildOf(excludeTransform))
				{
					if (!flag)
					{
						result = new Bounds(renderer.transform.position, Vector3.zero);
						flag = true;
					}
					result.Encapsulate(renderer.bounds);
				}
			}
			if (result.size.magnitude == 0f)
			{
				BoxCollider[] componentsInChildren2 = transform.GetComponentsInChildren<BoxCollider>();
				foreach (BoxCollider boxCollider in componentsInChildren2)
				{
					if (!(excludeTransform != null) || !boxCollider.transform.IsChildOf(excludeTransform))
					{
						if (!flag)
						{
							result = new Bounds(boxCollider.transform.position, Vector3.zero);
							flag = true;
						}
						result.Encapsulate(boxCollider.bounds);
					}
				}
			}
			if (excludeRotation != null)
			{
				excludeRotation.rotation = rotation;
			}
			return result;
		}

		public static bool IsLowest(float value, float[] others)
		{
			for (int i = 0; i < others.Length; i++)
			{
				if (others[i] <= value)
				{
					return false;
				}
			}
			return true;
		}

		public static Transform AddCameraFade()
		{
			Transform transform = VRTK_DeviceFinder.HeadsetCamera();
			VRTK_SDK_Bridge.AddHeadsetFade(transform);
			return transform;
		}

		public static void CreateColliders(GameObject obj)
		{
			Renderer[] componentsInChildren = obj.GetComponentsInChildren<Renderer>();
			foreach (Renderer renderer in componentsInChildren)
			{
				if (renderer.gameObject.GetComponent<Collider>() == null)
				{
					renderer.gameObject.AddComponent<BoxCollider>();
				}
			}
		}

		public static Collider[] ColliderExclude(Collider[] setA, Collider[] setB)
		{
			return setA.Except(setB).ToArray();
		}

		public static Collider[] GetCollidersInGameObjects(GameObject[] gameObjects, bool searchChildren, bool includeInactive)
		{
			HashSet<Collider> hashSet = new HashSet<Collider>();
			for (int i = 0; i < gameObjects.Length; i++)
			{
				Collider[] array = (searchChildren ? gameObjects[i].GetComponentsInChildren<Collider>(includeInactive) : gameObjects[i].GetComponents<Collider>());
				for (int j = 0; j < array.Length; j++)
				{
					hashSet.Add(array[j]);
				}
			}
			return hashSet.ToArray();
		}

		public static Component CloneComponent(Component source, GameObject destination, bool copyProperties = false)
		{
			Component component = destination.gameObject.AddComponent(source.GetType());
			if (copyProperties)
			{
				PropertyInfo[] properties = source.GetType().GetProperties();
				foreach (PropertyInfo propertyInfo in properties)
				{
					if (propertyInfo.CanWrite)
					{
						propertyInfo.SetValue(component, propertyInfo.GetValue(source, null), null);
					}
				}
			}
			FieldInfo[] fields = source.GetType().GetFields();
			foreach (FieldInfo fieldInfo in fields)
			{
				fieldInfo.SetValue(component, fieldInfo.GetValue(source));
			}
			return component;
		}

		public static Color ColorDarken(Color color, float percent)
		{
			return new Color(NumberPercent(color.r, percent), NumberPercent(color.g, percent), NumberPercent(color.b, percent), color.a);
		}

		public static float RoundFloat(float givenFloat, int decimalPlaces, bool rawFidelity = false)
		{
			float num = (rawFidelity ? ((float)decimalPlaces) : Mathf.Pow(10f, decimalPlaces));
			return Mathf.Round(givenFloat * num) / num;
		}

		public static bool IsEditTime()
		{
			return false;
		}

		public static float Mod(float a, float b)
		{
			return a - b * Mathf.Floor(a / b);
		}

		public static GameObject FindEvenInactiveGameObject<T>(string gameObjectName = null, bool searchAllScenes = false) where T : Component
		{
			if (string.IsNullOrEmpty(gameObjectName))
			{
				T val = FindEvenInactiveComponentsInValidScenes<T>(searchAllScenes, stopOnMatch: true).FirstOrDefault();
				if (!(val == null))
				{
					return val.gameObject;
				}
				return null;
			}
			return FindEvenInactiveComponentsInValidScenes<T>(searchAllScenes).Select(delegate(T component)
			{
				Transform transform = component.gameObject.transform.Find(gameObjectName);
				return (!(transform == null)) ? transform.gameObject : null;
			}).FirstOrDefault((GameObject gameObject) => gameObject != null);
		}

		public static T[] FindEvenInactiveComponents<T>(bool searchAllScenes = false) where T : Component
		{
			return FindEvenInactiveComponentsInValidScenes<T>(searchAllScenes).ToArray();
		}

		public static T FindEvenInactiveComponent<T>(bool searchAllScenes = false) where T : Component
		{
			return FindEvenInactiveComponentsInValidScenes<T>(searchAllScenes, stopOnMatch: true).FirstOrDefault();
		}

		public static string GenerateVRTKObjectName(bool autoGen, params object[] replacements)
		{
			string text = "[VRTK]";
			if (autoGen)
			{
				text += "[AUTOGEN]";
			}
			for (int i = 0; i < replacements.Length; i++)
			{
				text = text + "[{" + i + "}]";
			}
			return string.Format(text, replacements);
		}

		public static float GetGPUTimeLastFrame()
		{
			if (!XRStats.TryGetGPUTimeLastFrame(out var gpuTimeLastFrame))
			{
				return 0f;
			}
			return gpuTimeLastFrame;
		}

		public static bool Vector2ShallowCompare(Vector2 vectorA, Vector2 vectorB, int compareFidelity)
		{
			Vector2 vector = vectorA - vectorB;
			if (Math.Round(Mathf.Abs(vector.x), compareFidelity, MidpointRounding.AwayFromZero) < 1.401298464324817E-45)
			{
				return Math.Round(Mathf.Abs(vector.y), compareFidelity, MidpointRounding.AwayFromZero) < 1.401298464324817E-45;
			}
			return false;
		}

		public static bool Vector3ShallowCompare(Vector3 vectorA, Vector3 vectorB, float threshold)
		{
			return Vector3.Distance(vectorA, vectorB) < threshold;
		}

		public static float NumberPercent(float value, float percent)
		{
			percent = Mathf.Clamp(percent, 0f, 100f);
			if (percent != 0f)
			{
				return value - percent / 100f;
			}
			return value;
		}

		public static void SetGlobalScale(this Transform transform, Vector3 globalScale)
		{
			transform.localScale = Vector3.one;
			transform.localScale = new Vector3(globalScale.x / transform.lossyScale.x, globalScale.y / transform.lossyScale.y, globalScale.z / transform.lossyScale.z);
		}

		public static Vector3 VectorHeading(Vector3 originPosition, Vector3 targetPosition)
		{
			return targetPosition - originPosition;
		}

		public static Vector3 VectorDirection(Vector3 originPosition, Vector3 targetPosition)
		{
			Vector3 vector = VectorHeading(originPosition, targetPosition);
			return vector * DividerToMultiplier(vector.magnitude);
		}

		public static float DividerToMultiplier(float value)
		{
			if (value == 0f)
			{
				return 1f;
			}
			return 1f / value;
		}

		public static float NormalizeValue(float value, float minValue, float maxValue, float threshold = 0f)
		{
			float num = maxValue - minValue;
			float num2 = (num - (maxValue - value)) * DividerToMultiplier(num);
			num2 = ((num2 < threshold) ? 0f : num2);
			num2 = ((num2 > 1f - threshold) ? 1f : num2);
			return Mathf.Clamp(num2, 0f, 1f);
		}

		public static Vector3 AxisDirection(int axisIndex, Transform givenTransform = null)
		{
			Vector3[] array = ((!(givenTransform != null)) ? new Vector3[3]
			{
				Vector3.right,
				Vector3.up,
				Vector3.forward
			} : new Vector3[3] { givenTransform.right, givenTransform.up, givenTransform.forward });
			return array[(int)Mathf.Clamp(axisIndex, 0f, array.Length)];
		}

		public static bool AddListValue<TValue>(List<TValue> list, TValue value, bool preventDuplicates = false)
		{
			if (list != null && (!preventDuplicates || !list.Contains(value)))
			{
				list.Add(value);
				return true;
			}
			return false;
		}

		public static TValue GetDictionaryValue<TKey, TValue>(Dictionary<TKey, TValue> dictionary, TKey key, TValue defaultValue = default(TValue), bool setMissingKey = false)
		{
			bool keyExists;
			return GetDictionaryValue(dictionary, key, out keyExists, defaultValue, setMissingKey);
		}

		public static TValue GetDictionaryValue<TKey, TValue>(Dictionary<TKey, TValue> dictionary, TKey key, out bool keyExists, TValue defaultValue = default(TValue), bool setMissingKey = false)
		{
			keyExists = false;
			if (dictionary == null)
			{
				return defaultValue;
			}
			if (dictionary.TryGetValue(key, out var value))
			{
				keyExists = true;
				return value;
			}
			if (setMissingKey)
			{
				dictionary.Add(key, defaultValue);
			}
			return defaultValue;
		}

		public static bool AddDictionaryValue<TKey, TValue>(Dictionary<TKey, TValue> dictionary, TKey key, TValue value, bool overwriteExisting = false)
		{
			if (dictionary != null)
			{
				if (overwriteExisting)
				{
					dictionary[key] = value;
					return true;
				}
				GetDictionaryValue(dictionary, key, out var keyExists, value, setMissingKey: true);
				return !keyExists;
			}
			return false;
		}

		public static Type GetTypeUnknownAssembly(string typeName)
		{
			Type type = Type.GetType(typeName);
			if (type != null)
			{
				return type;
			}
			Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies();
			for (int i = 0; i < assemblies.Length; i++)
			{
				type = assemblies[i].GetType(typeName);
				if (type != null)
				{
					return type;
				}
			}
			return null;
		}

		public static float GetEyeTextureResolutionScale()
		{
			return XRSettings.eyeTextureResolutionScale;
		}

		public static void SetEyeTextureResolutionScale(float value)
		{
			XRSettings.eyeTextureResolutionScale = value;
		}

		public static bool IsTypeSubclassOf(Type givenType, Type givenBaseType)
		{
			return givenType.IsSubclassOf(givenBaseType);
		}

		public static object[] GetTypeCustomAttributes(Type givenType, Type attributeType, bool inherit)
		{
			return givenType.GetCustomAttributes(attributeType, inherit);
		}

		public static Type GetBaseType(Type givenType)
		{
			return givenType.BaseType;
		}

		public static bool IsTypeAssignableFrom(Type givenType, Type sourceType)
		{
			return givenType.IsAssignableFrom(sourceType);
		}

		public static Type GetNestedType(Type givenType, string name)
		{
			return givenType.GetNestedType(name);
		}

		public static string GetPropertyFirstName<T>()
		{
			return typeof(T).GetProperties()[0].Name;
		}

		public static string[] GetCommandLineArguements()
		{
			return Environment.GetCommandLineArgs();
		}

		public static Type[] GetTypesOfType(Type givenType)
		{
			return givenType.Assembly.GetTypes();
		}

		public static Type[] GetExportedTypesOfType(Type givenType)
		{
			return givenType.Assembly.GetExportedTypes();
		}

		public static bool IsTypeAbstract(Type givenType)
		{
			return givenType.IsAbstract;
		}

		private static IEnumerable<T> FindEvenInactiveComponentsInValidScenes<T>(bool searchAllScenes, bool stopOnMatch = false) where T : Component
		{
			if (searchAllScenes)
			{
				List<T> list = new List<T>();
				for (int i = 0; i < SceneManager.sceneCount; i++)
				{
					list.AddRange(FindEvenInactiveComponentsInScene<T>(SceneManager.GetSceneAt(i), stopOnMatch));
				}
				return list;
			}
			return FindEvenInactiveComponentsInScene<T>(SceneManager.GetActiveScene(), stopOnMatch);
		}

		private static IEnumerable<T> FindEvenInactiveComponentsInScene<T>(Scene scene, bool stopOnMatch = false)
		{
			List<T> list = new List<T>();
			if (!scene.isLoaded)
			{
				return list;
			}
			GameObject[] rootGameObjects = scene.GetRootGameObjects();
			foreach (GameObject gameObject in rootGameObjects)
			{
				if (stopOnMatch)
				{
					T componentInChildren = gameObject.GetComponentInChildren<T>(includeInactive: true);
					if (componentInChildren != null)
					{
						list.Add(componentInChildren);
						return list;
					}
				}
				else
				{
					list.AddRange(gameObject.GetComponentsInChildren<T>(includeInactive: true));
				}
			}
			return list;
		}
	}
}
