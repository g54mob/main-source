using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml.Linq;
using Jundroo.Common.Math;
using Jundroo.Common.Serialization.Xml;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Jundroo.Common.Utils
{
	public static class Utilities
	{
		public struct LeadPositionResult
		{
			public Vector3 Position;

			public float TimeToTarget;
		}

		public const double DefaultComparisonEpsilon = 1E-06;

		private static NumberFormatInfo[] _percentageFormats = new NumberFormatInfo[7]
		{
			CreatePercentageFormat(0),
			CreatePercentageFormat(1),
			CreatePercentageFormat(2),
			CreatePercentageFormat(3),
			CreatePercentageFormat(4),
			CreatePercentageFormat(5),
			CreatePercentageFormat(6)
		};

		public static Quaternion Abs(Quaternion quaternion)
		{
			return new Quaternion(Mathf.Abs(quaternion.x), Mathf.Abs(quaternion.y), Mathf.Abs(quaternion.z), Mathf.Abs(quaternion.w));
		}

		public static Vector3 Abs(Vector3 vector3)
		{
			return new Vector3(Mathf.Abs(vector3.x), Mathf.Abs(vector3.y), Mathf.Abs(vector3.z));
		}

		public static Vector2 Abs(Vector2 vector2)
		{
			return new Vector2(Mathf.Abs(vector2.x), Mathf.Abs(vector2.y));
		}

		public static bool Between(float value, float lhs, float rhs)
		{
			if (value >= lhs)
			{
				return value < rhs;
			}
			return false;
		}

		public static bool Between(double value, double lhs, double rhs)
		{
			if (value >= lhs)
			{
				return value < rhs;
			}
			return false;
		}

		public static Bounds CalculateColliderBounds(GameObject root)
		{
			Bounds bounds = new Bounds(root.transform.position, default(Vector3));
			Collider[] componentsInChildren = root.GetComponentsInChildren<Collider>();
			foreach (Collider collider in componentsInChildren)
			{
				bounds = ExpandBounds(bounds, collider.bounds);
			}
			return bounds;
		}

		public static Bounds CalculateRendererBounds(GameObject root)
		{
			Vector3 vector = new Vector3(float.MinValue, float.MinValue, float.MinValue);
			Vector3 vector2 = new Vector3(float.MaxValue, float.MaxValue, float.MaxValue);
			MeshRenderer[] componentsInChildren = root.GetComponentsInChildren<MeshRenderer>();
			foreach (MeshRenderer meshRenderer in componentsInChildren)
			{
				vector = Vector3.Max(vector, meshRenderer.bounds.max);
				vector2 = Vector3.Min(vector2, meshRenderer.bounds.min);
			}
			return new Bounds((vector + vector2) * 0.5f, vector - vector2);
		}

		public static bool CompareDoubles(double p1, double p2, double epsilon = 1E-06)
		{
			if (p1 == p2)
			{
				return true;
			}
			return System.Math.Abs(p1 - p2) <= epsilon;
		}

		public static bool CompareDoublesGte(double lhs, double rhs, double epsilon = 9.999999974752427E-07)
		{
			if (!(lhs > rhs))
			{
				return CompareDoubles(lhs, rhs, epsilon);
			}
			return true;
		}

		public static bool CompareDoublesLte(double lhs, double rhs, double epsilon = 9.999999974752427E-07)
		{
			if (!(lhs < rhs))
			{
				return CompareDoubles(lhs, rhs, epsilon);
			}
			return true;
		}

		public static bool CompareDoublesMany(double value, params double[] doubles)
		{
			for (int i = 0; i < doubles.Length; i++)
			{
				if (value != doubles[i])
				{
					return false;
				}
			}
			return true;
		}

		public static bool CompareDoublesNanEquiv(double p1, double p2, double epsilon = 9.999999974752427E-07)
		{
			if (double.IsNaN(p1) && double.IsNaN(p2))
			{
				return true;
			}
			return CompareDoubles(p1, p2, epsilon);
		}

		public static bool CompareFloats(float p1, float p2, float epsilon = 1E-06f)
		{
			return System.Math.Abs(p1 - p2) <= epsilon;
		}

		public static bool CompareQuaternions(Quaternion quat1, Quaternion quat2, float epsilon = 1E-06f)
		{
			if (CompareFloats(quat1.x, quat2.x, epsilon) && CompareFloats(quat1.y, quat2.y, epsilon) && CompareFloats(quat1.z, quat2.z, epsilon))
			{
				return CompareFloats(quat1.w, quat2.w, epsilon);
			}
			return false;
		}

		public static bool CompareVector2s(Vector2 vec1, Vector2 vec2, float epsilon = 1E-06f)
		{
			if (CompareFloats(vec1.x, vec2.x, epsilon))
			{
				return CompareFloats(vec1.y, vec2.y, epsilon);
			}
			return false;
		}

		public static bool CompareVector3ds(Vector3d vec1, Vector3d vec2, double epsilon = 9.999999974752427E-07)
		{
			if (CompareDoubles(vec1.x, vec2.x, epsilon) && CompareDoubles(vec1.y, vec2.y, epsilon))
			{
				return CompareDoubles(vec1.z, vec2.z, epsilon);
			}
			return false;
		}

		public static bool CompareVector3dsNanEquiv(Vector3d vec1, Vector3d vec2, double epsilon = 9.999999974752427E-07)
		{
			if (CompareDoublesNanEquiv(vec1.x, vec2.x, epsilon) && CompareDoublesNanEquiv(vec1.y, vec2.y, epsilon))
			{
				return CompareDoublesNanEquiv(vec1.z, vec2.z, epsilon);
			}
			return false;
		}

		public static bool CompareVector3s(Vector3 vec1, Vector3 vec2, float epsilon = 1E-06f)
		{
			if (CompareFloats(vec1.x, vec2.x, epsilon) && CompareFloats(vec1.y, vec2.y, epsilon))
			{
				return CompareFloats(vec1.z, vec2.z, epsilon);
			}
			return false;
		}

		public static Bounds ConvertWorldAabbToLocalAabb(Bounds bounds, Transform transform)
		{
			Vector3[] array = new Vector3[8]
			{
				new Vector3(bounds.min.x, bounds.min.y, bounds.min.z),
				new Vector3(bounds.min.x, bounds.min.y, bounds.max.z),
				new Vector3(bounds.min.x, bounds.max.y, bounds.min.z),
				new Vector3(bounds.min.x, bounds.max.y, bounds.max.z),
				new Vector3(bounds.max.x, bounds.min.y, bounds.min.z),
				new Vector3(bounds.max.x, bounds.min.y, bounds.max.z),
				new Vector3(bounds.max.x, bounds.max.y, bounds.min.z),
				new Vector3(bounds.max.x, bounds.max.y, bounds.max.z)
			};
			Bounds bounds2 = default(Bounds);
			for (int i = 0; i < 8; i++)
			{
				Vector3 vector = transform.InverseTransformPoint(array[i]);
				if (i == 0)
				{
					bounds2.SetMinMax(vector, vector);
				}
				else
				{
					bounds2 = ExpandBounds(bounds2, vector);
				}
			}
			return bounds2;
		}

		public static Bounds ExpandBounds(Bounds bounds, Vector3 point)
		{
			Vector3 min = bounds.min;
			Vector3 max = bounds.max;
			if (point.x < min.x)
			{
				min.x = point.x;
			}
			if (point.x > max.x)
			{
				max.x = point.x;
			}
			if (point.y < min.y)
			{
				min.y = point.y;
			}
			if (point.y > max.y)
			{
				max.y = point.y;
			}
			if (point.z < min.z)
			{
				min.z = point.z;
			}
			if (point.z > max.z)
			{
				max.z = point.z;
			}
			bounds.SetMinMax(min, max);
			return bounds;
		}

		public static Bounds ExpandBounds(Bounds bounds, Bounds bounds2)
		{
			Vector3 min = bounds.min;
			Vector3 max = bounds.max;
			Vector3 min2 = bounds2.min;
			Vector3 max2 = bounds2.max;
			if (min2.x < min.x)
			{
				min.x = min2.x;
			}
			if (max2.x > max.x)
			{
				max.x = max2.x;
			}
			if (min2.y < min.y)
			{
				min.y = min2.y;
			}
			if (max2.y > max.y)
			{
				max.y = max2.y;
			}
			if (min2.z < min.z)
			{
				min.z = min2.z;
			}
			if (max2.z > max.z)
			{
				max.z = max2.z;
			}
			bounds.SetMinMax(min, max);
			return bounds;
		}

		public static GameObject FindFirstGameObjectMyselfOrChildren(string name, GameObject gameObject)
		{
			if (gameObject != null)
			{
				if (gameObject.name == name)
				{
					return gameObject;
				}
				for (int i = 0; i < gameObject.transform.childCount; i++)
				{
					Transform child = gameObject.transform.GetChild(i);
					GameObject gameObject2 = FindFirstGameObjectMyselfOrChildren(name, child.gameObject);
					if (gameObject2 != null)
					{
						return gameObject2;
					}
				}
			}
			else
			{
				GameObject[] rootGameObjects = GetRootGameObjects();
				foreach (GameObject gameObject3 in rootGameObjects)
				{
					GameObject gameObject4 = FindFirstGameObjectMyselfOrChildren(name, gameObject3);
					if (gameObject4 != null)
					{
						return gameObject4;
					}
				}
			}
			return null;
		}

		public static GameObject FindGameObjectRelativeTo(GameObject gameObject, string path)
		{
			string[] array = path.Split('/');
			string text = array[0];
			if (array.Length > 1)
			{
				if (text.CompareTo("..") == 0)
				{
					return FindGameObjectRelativeTo(gameObject.transform.parent.gameObject, path.Substring(text.Length + 1));
				}
				if (text.CompareTo(".") == 0)
				{
					return FindGameObjectRelativeTo(gameObject, path.Substring(text.Length + 1));
				}
				return FindGameObjectRelativeTo(gameObject.transform.Find(text).gameObject, path.Substring(text.Length + 1));
			}
			if (text.CompareTo(".") == 0)
			{
				return gameObject;
			}
			try
			{
				return gameObject.transform.Find(text).gameObject;
			}
			catch (Exception)
			{
				throw;
			}
		}

		public static List<T> FindObjectsMyselfOrChildren<T>(string name, GameObject gameObject) where T : Component
		{
			List<T> list = new List<T>();
			if (gameObject != null)
			{
				if ((gameObject.name == name || name == null) && gameObject.TryGetComponent<T>(out var component))
				{
					list.Add(component);
				}
				for (int i = 0; i < gameObject.transform.childCount; i++)
				{
					Transform child = gameObject.transform.GetChild(i);
					List<T> list2 = FindObjectsMyselfOrChildren<T>(name, child.gameObject);
					if (list2 != null)
					{
						list.AddRange(list2);
					}
				}
			}
			if (list.Count > 0)
			{
				return list;
			}
			return null;
		}

		public static GameObject FindParentOfGameObject(string name, GameObject gameObject)
		{
			if (gameObject != null)
			{
				if (gameObject.name == name)
				{
					return gameObject;
				}
				if (gameObject.name == name)
				{
					return gameObject;
				}
				if (gameObject.transform.parent != null)
				{
					return FindParentOfGameObject(name, gameObject.transform.parent.gameObject);
				}
			}
			return null;
		}

		public static void FixUnityCanvasSortingBug(Canvas canvas)
		{
			bool enabled = canvas.enabled;
			canvas.enabled = true;
			canvas.enabled = false;
			canvas.enabled = enabled;
		}

		public static string FormatCodeToDisplayName(string fieldName)
		{
			if (fieldName.Length >= 2)
			{
				string text = Regex.Replace(fieldName.Replace("_", " "), "([A-Z]+|[0-9|\\.]+)", " $1").TrimStart();
				return char.ToUpper(text[0]) + text.Substring(1);
			}
			return fieldName;
		}

		public static string FormatMemorySize(long bytes)
		{
			if (bytes > 1048576)
			{
				float num = (float)bytes / 1048576f;
				return $"{num:n1} MB";
			}
			if (bytes > 1024)
			{
				float num2 = (float)bytes / 1024f;
				return $"{num2:n1} KB";
			}
			return $"{bytes} bytes";
		}

		public static string FormatPercentage(float x, int decimalPlaces = 0)
		{
			if (decimalPlaces >= _percentageFormats.Length)
			{
				return x.ToString("p" + decimalPlaces, _percentageFormats[0]);
			}
			return x.ToString("p", _percentageFormats[decimalPlaces]);
		}

		public static Version FormatVersion(string versionString, Version defaultVersion = null)
		{
			if (Version.TryParse(versionString, out var result))
			{
				return result;
			}
			return defaultVersion;
		}

		public static string FriendlyLargeNumber(long number)
		{
			if (number >= 1000000)
			{
				double num = (double)number / 1000000.0;
				if (number >= 100000000)
				{
					return string.Format($"{num:0}M", num);
				}
				if (number >= 10000000)
				{
					return string.Format($"{num:0.0}M", num);
				}
				return $"{num:0.00}M";
			}
			if (number >= 1000)
			{
				double num2 = (double)number / 1000.0;
				if (number >= 100000)
				{
					return string.Format($"{num2:0}k", num2);
				}
				if (number >= 10000)
				{
					return string.Format($"{num2:0.0}k", num2);
				}
				return $"{num2:0.00}k";
			}
			return number.ToString("n0");
		}

		public static T FromXElement<T>(this XElement xElement)
		{
			return new UnityXmlSerializer(new UnityXmlSerializerContext
			{
				IgnoreUnderscorePrefix = true
			}).Deserialize<T>(xElement);
		}

		public static List<T> GetChildren<T>(string name, GameObject gameObject) where T : Component
		{
			List<T> list = new List<T>();
			if (gameObject == null)
			{
				GameObject[] rootGameObjects = GetRootGameObjects();
				foreach (GameObject gameObject2 in rootGameObjects)
				{
					List<T> list2 = FindObjectsMyselfOrChildren<T>(name, gameObject2);
					if (list2 != null)
					{
						list.AddRange(list2);
					}
				}
			}
			else
			{
				list = FindObjectsMyselfOrChildren<T>(name, gameObject);
			}
			if (list != null && list.Count > 0)
			{
				return list;
			}
			return null;
		}

		public static T GetComponentInParent<T>(Transform transform) where T : MonoBehaviour
		{
			if (transform != null)
			{
				if (transform.TryGetComponent<T>(out var component))
				{
					return component;
				}
				return GetComponentInParent<T>(transform.parent);
			}
			return null;
		}

		public static bool GetComponentsInChildrenOrdered<T>(GameObject root, List<T> results, bool includeInactive = true) where T : Component
		{
			if (root == null)
			{
				UnityEngine.Debug.LogError("GetComponentsInChildrenOrdered: Root GameObject is null.");
				results?.Clear();
				return false;
			}
			if (results == null)
			{
				UnityEngine.Debug.LogError("GetComponentsInChildrenOrdered: Results list is null.");
				return false;
			}
			results.Clear();
			bool successFlag = true;
			List<T> reusableNodeComponentList = new List<T>();
			PerformDFSForComponents(root.transform, results, includeInactive, reusableNodeComponentList, ref successFlag);
			return successFlag;
		}

		public static List<T> GetComponentsInChildrenOrdered<T>(GameObject root, bool includeInactive = true) where T : Component
		{
			if (root == null)
			{
				return null;
			}
			List<T> list = new List<T>();
			GetComponentsInChildrenOrdered(root, list, includeInactive);
			return list;
		}

		public static T GetComponentWithInterface<T>(GameObject g) where T : class
		{
			if (g?.GetComponents<MonoBehaviour>().FirstOrDefault((MonoBehaviour x) => x is T) is T result)
			{
				return result;
			}
			return null;
		}

		public static T GetComponentWithInterfaceInParent<T>(GameObject g, Transform stop = null) where T : class
		{
			if (g?.GetComponents<MonoBehaviour>().FirstOrDefault((MonoBehaviour x) => x is T) is T result)
			{
				return result;
			}
			Transform parent = g.transform.parent;
			if (parent != null && parent != stop)
			{
				return GetComponentWithInterfaceInParent<T>(parent.gameObject, stop);
			}
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static string GetCurrentMethod()
		{
			return new StackTrace().GetFrame(1).GetMethod().Name;
		}

		public static FieldInfo GetField<TValue>(Expression<Func<TValue>> fieldSelector)
		{
			if (fieldSelector == null)
			{
				throw new ArgumentNullException("fieldSelector");
			}
			if (!(fieldSelector.Body is MemberExpression memberExpression))
			{
				UnityEngine.Debug.LogError("The field selector is using an invalid expression format. Use this format: () => this._myField");
				return null;
			}
			FieldInfo fieldInfo = memberExpression.Member as FieldInfo;
			if (fieldInfo == null)
			{
				UnityEngine.Debug.LogError("The field selector did not provide a field. Use this format: () => this._myField");
				return null;
			}
			return fieldInfo;
		}

		public static T GetFirstChild<T>(string name, MonoBehaviour script) where T : Component
		{
			if (script == null)
			{
				throw new ArgumentException("script cannot be null");
			}
			GameObject gameObject = FindFirstGameObjectMyselfOrChildren(name, script.gameObject);
			if (gameObject != null)
			{
				return gameObject.GetComponent<T>();
			}
			return null;
		}

		public static T GetFirstChild<T>(string name, GameObject rootGameObject) where T : Component
		{
			GameObject gameObject = FindFirstGameObjectMyselfOrChildren(name, rootGameObject);
			if (gameObject != null)
			{
				return gameObject.GetComponent<T>();
			}
			return null;
		}

		public static T GetFirstChildWithInterface<T>(GameObject g, bool includeInactive = false) where T : class
		{
			if (g == null)
			{
				return null;
			}
			return g.GetComponentsInChildren<MonoBehaviour>(includeInactive).OfType<T>().FirstOrDefault();
		}

		public static string GetFuelPercentageString(float maxFuelCapacity, float percentage)
		{
			string text = Units.Format((int)(maxFuelCapacity * percentage), UnitType.Volume);
			if (percentage >= 1f)
			{
				return text + " (Max)";
			}
			if (percentage <= 0f)
			{
				return "None";
			}
			return text + " (" + (int)(percentage * 100f + 0.5f) + "%)";
		}

		public static string GetFullObjectHierarchy(Transform transform)
		{
			if (transform.parent != null)
			{
				return GetFullObjectHierarchy(transform.parent) + "/" + transform.gameObject.name;
			}
			return transform.gameObject.name;
		}

		public static float? GetHeightAboveTerrain(Terrain terrain, Vector3 floatingOriginPosition)
		{
			Vector3 position = terrain.GetPosition();
			if (floatingOriginPosition.x > position.x && floatingOriginPosition.x < position.x + terrain.terrainData.size.x && floatingOriginPosition.z > position.z && floatingOriginPosition.z < position.z + terrain.terrainData.size.z)
			{
				return floatingOriginPosition.y - (terrain.SampleHeight(floatingOriginPosition) + terrain.transform.position.y);
			}
			return null;
		}

		public static Vector3 GetMaximumComponentVector(Vector3 v1, Vector3 v2)
		{
			return new Vector3(Mathf.Max(v1.x, v2.x), Mathf.Max(v1.y, v2.y), Mathf.Max(v1.z, v2.z));
		}

		public static Vector3 GetMinimumComponentVector(Vector3 v1, Vector3 v2)
		{
			return new Vector3(Mathf.Min(v1.x, v2.x), Mathf.Min(v1.y, v2.y), Mathf.Min(v1.z, v2.z));
		}

		public static string GetObjectHierarchy<TRoot>(GameObject obj) where TRoot : MonoBehaviour
		{
			List<string> list = new List<string>();
			while (obj.GetComponent<TRoot>() == null)
			{
				list.Insert(0, obj.name);
				Transform parent = obj.transform.parent;
				if (parent == null)
				{
					return null;
				}
				obj = parent.gameObject;
			}
			return string.Join("/", list.ToArray());
		}

		public static GameObject GetOrCreateObjectInHierarchy(Transform root, string hierarchy)
		{
			string[] array = hierarchy.Split(new char[1] { '/' }, StringSplitOptions.RemoveEmptyEntries);
			Transform transform = root;
			for (int i = 0; i < array.Length; i++)
			{
				Transform transform2 = null;
				foreach (Transform item in transform)
				{
					if (item.name == array[i])
					{
						transform2 = item;
						break;
					}
				}
				if (transform2 == null)
				{
					transform2 = new GameObject(array[i]).transform;
					transform2.SetParent(transform, worldPositionStays: false);
				}
				transform = transform2;
			}
			return transform.gameObject;
		}

		public static GameObject GetParentWithName(GameObject gameObject, string name)
		{
			if (gameObject.name == name)
			{
				return gameObject;
			}
			if (gameObject.transform.parent != null)
			{
				return GetParentWithName(gameObject.transform.parent.gameObject, name);
			}
			return null;
		}

		public static PropertyInfo GetProperty<TValue>(Expression<Func<TValue>> selector)
		{
			if (selector == null)
			{
				throw new ArgumentNullException("selector");
			}
			if (!(selector.Body is MemberExpression memberExpression))
			{
				UnityEngine.Debug.LogError("The selector is using an invalid expression format. Use this format: () => this.MyProperty");
				return null;
			}
			PropertyInfo propertyInfo = memberExpression.Member as PropertyInfo;
			if (propertyInfo == null)
			{
				UnityEngine.Debug.LogError("The selector did not provide a property. Use this format: () => this.MyProperty");
				return null;
			}
			return propertyInfo;
		}

		public static string GetRelativeObjectHierarchy(Transform target, Transform root)
		{
			if (target == root || target == null)
			{
				return string.Empty;
			}
			StringBuilder stringBuilder = new StringBuilder();
			Transform transform = target;
			while (transform != null && transform != root)
			{
				if (stringBuilder.Length > 0)
				{
					stringBuilder.Insert(0, "/");
				}
				stringBuilder.Insert(0, transform.name);
				transform = transform.parent;
			}
			if (transform == null && target != root)
			{
				UnityEngine.Debug.LogError("Could not find root '" + root.name + "' when building path for '" + target.name + "'. Is it actually a child?", target.gameObject);
				return target.name;
			}
			return stringBuilder.ToString();
		}

		public static GameObject[] GetRootGameObjects()
		{
			return SceneManager.GetActiveScene().GetRootGameObjects();
		}

		public static LeadPositionResult GetTargetLeadPrediction(Rigidbody originator, Rigidbody target, float leadAccuracy)
		{
			return GetTargetLeadPrediction(originator.transform.position, originator.linearVelocity, target.transform.position, target.linearVelocity, leadAccuracy);
		}

		public static LeadPositionResult GetTargetLeadPrediction(Vector3 originatorPosition, Vector3 originatorVelocity, Vector3 targetPosition, Vector3 targetVelocity, float leadAccuracy)
		{
			if (CompareVector3s(originatorVelocity, Vector3.zero) || CompareVector3s(targetVelocity, Vector3.zero) || CompareFloats(leadAccuracy, 0f))
			{
				return new LeadPositionResult
				{
					Position = targetPosition,
					TimeToTarget = TimeToPosition(originatorPosition, targetPosition, originatorVelocity.magnitude)
				};
			}
			float num = 0f;
			Vector3 targetPosition2 = targetPosition;
			for (int i = 0; i < 5; i++)
			{
				num = TimeToPosition(originatorPosition, targetPosition2, originatorVelocity.magnitude);
				targetPosition2 = PredictPositionInFuture(targetPosition, targetVelocity, num * leadAccuracy);
			}
			Vector3 position = PredictPositionInFuture(targetPosition, targetVelocity, num * leadAccuracy);
			return new LeadPositionResult
			{
				Position = position,
				TimeToTarget = num
			};
		}

		public static bool HasMinimalDifference(double value1, double value2, int digitsOfPrecision)
		{
			long num = BitConverter.DoubleToInt64Bits(value1);
			long num2 = BitConverter.DoubleToInt64Bits(value2);
			if (num >> 63 != num2 >> 63)
			{
				if (value1 == value2)
				{
					return true;
				}
				return false;
			}
			if (Mathd.Abs(num - num2) <= (double)digitsOfPrecision)
			{
				return true;
			}
			return false;
		}

		public static bool HasMinimalDifference(Vector3d value1, Vector3d value2, int digitsOfPrecision)
		{
			if (HasMinimalDifference(value1.x, value2.x, digitsOfPrecision) && HasMinimalDifference(value1.y, value2.y, digitsOfPrecision))
			{
				return HasMinimalDifference(value1.z, value2.z, digitsOfPrecision);
			}
			return false;
		}

		public static bool IsNan(Vector3 value)
		{
			if (float.IsNaN(value.x) || float.IsNaN(value.y) || float.IsNaN(value.z))
			{
				return true;
			}
			return false;
		}

		public static bool IsNan(Vector3d value)
		{
			if (double.IsNaN(value.x) || double.IsNaN(value.y) || double.IsNaN(value.z))
			{
				return true;
			}
			return false;
		}

		public static bool IsValidCraftUrlId(string urlId)
		{
			if (urlId != null && urlId.Length == 6)
			{
				for (int i = 0; i < urlId.Length; i++)
				{
					if (!char.IsLetterOrDigit(urlId[i]))
					{
						return false;
					}
				}
				return true;
			}
			return false;
		}

		public static bool IsValidSandboxUrlId(string urlId)
		{
			return IsValidCraftUrlId(urlId);
		}

		public static float LimitAngle180(float angle)
		{
			angle %= 360f;
			if (angle > 180f)
			{
				angle -= 360f;
			}
			else if (angle < -180f)
			{
				angle += 360f;
			}
			return angle;
		}

		public static Texture2D LoadTextureFromFile(string path)
		{
			try
			{
				if (File.Exists(path))
				{
					Texture2D texture2D = new Texture2D(2, 2);
					if (texture2D.LoadImage(File.ReadAllBytes(path)))
					{
						return texture2D;
					}
				}
			}
			catch (Exception exception)
			{
				UnityEngine.Debug.LogException(exception);
			}
			return null;
		}

		public static float Max(Vector2 vector2)
		{
			if (!(vector2.x > vector2.y))
			{
				return vector2.y;
			}
			return vector2.x;
		}

		public static Vector3 PredictPositionInFuture(Vector3 targetCurrentPosition, Vector3 targetCurrentVelocity, float timeInFuture)
		{
			return targetCurrentPosition + targetCurrentVelocity * timeInFuture;
		}

		public static string RelativeDate(DateTime d1, DateTime d2)
		{
			TimeSpan timeSpan = new TimeSpan(d1.Ticks - d2.Ticks);
			double num = System.Math.Abs(timeSpan.TotalSeconds);
			if (num < 60.0)
			{
				if (timeSpan.Seconds != 1)
				{
					return timeSpan.Seconds + " seconds ago";
				}
				return "one second ago";
			}
			if (num < 120.0)
			{
				return "a minute ago";
			}
			if (num < 2700.0)
			{
				return timeSpan.Minutes + " minutes ago";
			}
			if (num < 5400.0)
			{
				return "an hour ago";
			}
			if (num < 86400.0)
			{
				return timeSpan.Hours + " hours ago";
			}
			if (num < 172800.0)
			{
				return "yesterday";
			}
			if (num < 2592000.0)
			{
				return timeSpan.Days + " days ago";
			}
			if (num < 31104000.0)
			{
				int num2 = Convert.ToInt32(System.Math.Floor((double)timeSpan.Days / 30.0));
				if (num2 > 1)
				{
					return num2 + " months ago";
				}
				return "one month ago";
			}
			double num3 = System.Math.Floor((double)timeSpan.Days / 365.0);
			if (!(num3 <= 1.0))
			{
				return num3.ToString("F1", CultureInfo.InvariantCulture) + " years ago";
			}
			return "one year ago";
		}

		public static string RelativeDateShort(DateTime d1, DateTime d2)
		{
			TimeSpan timeSpan = new TimeSpan(d1.Ticks - d2.Ticks);
			double num = System.Math.Abs(timeSpan.TotalSeconds);
			if (num < 2700.0)
			{
				return timeSpan.Minutes + "m ago";
			}
			if (num < 86400.0)
			{
				return timeSpan.Hours + "hr ago";
			}
			if (num < 2592000.0)
			{
				return timeSpan.Days + "d ago";
			}
			if (num < 31104000.0)
			{
				return Convert.ToInt32(System.Math.Floor((double)timeSpan.Days / 30.0)) + "mo ago";
			}
			return System.Math.Floor((double)timeSpan.Days / 365.0).ToString("F1", CultureInfo.InvariantCulture) + "yr ago";
		}

		public static Vector3 RotatePointAroundPivot(Vector3 point, Vector3 pivot, Vector3 axis, float angle)
		{
			Vector3 vector = point - pivot;
			return pivot + Quaternion.AngleAxis(angle, axis) * vector;
		}

		public static Vector2d RotateVector(Vector2d v, double radians)
		{
			double num = Mathd.Cos(radians);
			double num2 = Mathd.Sin(radians);
			double new_x = num * v.x - num2 * v.y;
			double new_y = num2 * v.x + num * v.y;
			return new Vector2d(new_x, new_y);
		}

		public static Vector3d RotateVectorAroundYAxis(Vector3d v, double radians)
		{
			Vector2d vector2d = RotateVector(new Vector2d(v.x, v.z), 0.0 - radians);
			return new Vector3d(vector2d.x, v.y, vector2d.y);
		}

		public static int RoundPercentage(float x)
		{
			return (int)Mathf.Round(x * 100f);
		}

		public static Vector3 RoundVector3(Vector3 position, int decimalPlaces)
		{
			return new Vector3((float)System.Math.Round((decimal)position.x, decimalPlaces, MidpointRounding.AwayFromZero), (float)System.Math.Round((decimal)position.y, decimalPlaces, MidpointRounding.AwayFromZero), (float)System.Math.Round((decimal)position.z, decimalPlaces, MidpointRounding.AwayFromZero));
		}

		public static Ray ScreenPointToRay(Camera camera, Vector3 screenPoint)
		{
			float num = Screen.width;
			float num2 = Screen.height;
			float num3 = screenPoint.x / num * 2f - 1f;
			float num4 = screenPoint.y / num2 * 2f - 1f;
			float num5 = num / num2;
			float num6 = Mathf.Tan(MathF.PI / 180f * camera.fieldOfView / 2f);
			float num7 = num6 * num5;
			Vector3 vector = new Vector3(num3 * num7, num4 * num6, 1f);
			Vector3 direction = camera.transform.TransformDirection(vector.normalized);
			return new Ray(camera.transform.position, direction);
		}

		public static void SetInertiaTensor(this Rigidbody rigidbody, Vector3 newTensor)
		{
			if (newTensor.x > 0f && newTensor.y > 0f && newTensor.z > 0f)
			{
				rigidbody.automaticInertiaTensor = false;
				rigidbody.inertiaTensor = newTensor;
			}
		}

		public static void SetToActiveForDisabledChildren(GameObject parent)
		{
			foreach (Transform item in parent.transform)
			{
				item.gameObject.SetActive(value: true);
			}
		}

		public static float SnapToGrid(float value, float unitSize)
		{
			if (unitSize > 0f)
			{
				if (value > 0f)
				{
					return (float)(int)((value + unitSize / 2f) / unitSize) * unitSize;
				}
				return (float)(int)((value - unitSize / 2f) / unitSize) * unitSize;
			}
			return value;
		}

		public static float StepTowards(float start, float step, float target)
		{
			step = Mathf.Abs(step);
			float num = start;
			if (num < target)
			{
				num += step;
				if (num > target)
				{
					num = target;
				}
			}
			else if (num > target)
			{
				num -= step;
				if (num < target)
				{
					num = target;
				}
			}
			return num;
		}

		public static void Swap<T>(ref T lhs, ref T rhs)
		{
			T val = lhs;
			lhs = rhs;
			rhs = val;
		}

		public static float TimeToPosition(Vector3 startingPosition, Vector3 targetPosition, float speed, float maxTime = 86400f)
		{
			float num = (targetPosition - startingPosition).magnitude / speed;
			if (!(maxTime > 0f))
			{
				return num;
			}
			return Mathf.Clamp(num, 0f, maxTime);
		}

		public static XElement ToXElement<T>(this object obj)
		{
			return new UnityXmlSerializer(new UnityXmlSerializerContext
			{
				IgnoreUnderscorePrefix = true
			}).Serialize(obj);
		}

		public static string Vector2ToString(Vector2 vector2)
		{
			return DataIO.ToString(vector2.x) + "," + DataIO.ToString(vector2.y);
		}

		public static string Vector3dToString(Vector3d vector3, string numericFormat = null)
		{
			if (numericFormat == null)
			{
				return DataIO.ToString(vector3.x) + "," + DataIO.ToString(vector3.y) + "," + DataIO.ToString(vector3.z);
			}
			return DataIO.ToString(vector3.x, numericFormat) + "," + DataIO.ToString(vector3.y, numericFormat) + "," + DataIO.ToString(vector3.z, numericFormat);
		}

		public static string Vector3ToString(Vector3 vector3)
		{
			return DataIO.ToString(vector3.x) + "," + DataIO.ToString(vector3.y) + "," + DataIO.ToString(vector3.z);
		}

		public static string Vector3ToString(Vector3 vector3, float epsilon)
		{
			return DataIO.ToString((System.Math.Abs(vector3.x) < epsilon) ? 0f : vector3.x) + "," + DataIO.ToString((System.Math.Abs(vector3.y) < epsilon) ? 0f : vector3.y) + "," + DataIO.ToString((System.Math.Abs(vector3.z) < epsilon) ? 0f : vector3.z);
		}

		private static NumberFormatInfo CreatePercentageFormat(int decimalDigits)
		{
			NumberFormatInfo numberFormatInfo = new NumberFormatInfo();
			numberFormatInfo.PercentPositivePattern = 1;
			numberFormatInfo.PercentNegativePattern = 1;
			numberFormatInfo.NegativeSign = "-";
			numberFormatInfo.PercentSymbol = "%";
			numberFormatInfo.PercentDecimalDigits = decimalDigits;
			numberFormatInfo.PercentDecimalSeparator = ".";
			numberFormatInfo.PercentGroupSeparator = ",";
			numberFormatInfo.PercentGroupSizes = new int[1] { 3 };
			return numberFormatInfo;
		}

		private static void PerformDFSForComponents<T>(Transform node, List<T> results, bool includeInactive, List<T> reusableNodeComponentList, ref bool successFlag) where T : Component
		{
			bool activeSelf = node.gameObject.activeSelf;
			if (includeInactive || activeSelf)
			{
				T[] components = node.GetComponents<T>();
				if (components != null && components.Length != 0)
				{
					reusableNodeComponentList.Clear();
					reusableNodeComponentList.AddRange(components);
					if (reusableNodeComponentList.Count > 1)
					{
						reusableNodeComponentList.Sort(delegate(T a, T b)
						{
							if (a == null && b == null)
							{
								return 0;
							}
							if (a == null)
							{
								return -1;
							}
							return (b == null) ? 1 : string.CompareOrdinal(a.GetType().Name, b.GetType().Name);
						});
						for (int num = 1; num < reusableNodeComponentList.Count; num++)
						{
							if (!(reusableNodeComponentList[num] == null) && !(reusableNodeComponentList[num - 1] == null) && reusableNodeComponentList[num].GetType() == reusableNodeComponentList[num - 1].GetType())
							{
								UnityEngine.Debug.LogError("GetComponentsInChildrenOrdered: Ambiguous Order Detected! GameObject '" + node.name + "' has multiple components of the exact same type '" + reusableNodeComponentList[num].GetType().FullName + "'. Deterministic ordering based solely on type name is not possible in this case. Consider using distinct derived types or an explicit sort order field.", node.gameObject);
								successFlag = false;
								break;
							}
						}
					}
					results.AddRange(reusableNodeComponentList);
				}
			}
			if (!(includeInactive || activeSelf))
			{
				return;
			}
			int childCount = node.childCount;
			for (int num2 = 0; num2 < childCount; num2++)
			{
				Transform child = node.GetChild(num2);
				if (child != null)
				{
					PerformDFSForComponents(child, results, includeInactive, reusableNodeComponentList, ref successFlag);
				}
			}
		}
	}
}
