using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Xml.Linq;
using Jundroo.ModTools.Serialization.Xml;
using ModApi.Common.Attributes;
using ModApi.Craft.Parts;
using ModApi.Flight.Sim;
using UnityEngine;
using UnityEngine.Networking;

namespace ModApi
{
	public static class Utilities
	{
		public static class Assert
		{
			public static bool DisableFrameCount { get; set; }

			[Conditional("DEBUG")]
			[Conditional("UNITY_EDITOR")]
			public static void LogAssert(string messageFormat, params object[] args)
			{
				UnityEngine.Debug.LogError(string.Format("(frame: " + GetFrameCount() + ") - " + messageFormat, args));
			}

			private static string GetFrameCount()
			{
				if (!DisableFrameCount)
				{
					return GetUnityFrameCount();
				}
				return "n/a";
			}

			private static string GetUnityFrameCount()
			{
				return Time.frameCount.ToString();
			}
		}

		public static class Colors
		{
		}

		public struct LeadPositionResult
		{
			public Vector3 Position;

			public float TimeToTarget;
		}

		public static class Enums
		{
			public static string GetDisplayName(Type type, object value)
			{
				if (!type.IsEnum)
				{
					throw new ArgumentException("Type must be an enumeration");
				}
				FieldInfo field = type.GetField(value.ToString());
				return field.GetCustomAttribute<DisplayNameAttribute>()?.DisplayName ?? field.Name;
			}

			public static string GetDisplayName<T>(T value) where T : struct, IConvertible
			{
				FieldInfo field = typeof(T).GetField(value.ToString());
				return field.GetCustomAttribute<DisplayNameAttribute>()?.DisplayName ?? field.Name;
			}

			public static IList<string> GetDisplayNames<T>() where T : struct, IConvertible
			{
				return (from obj in GetNames<T>()
					select GetDisplayName(Parse<T>(obj))).ToList();
			}

			public static IList<string> GetNames<T>() where T : struct, IConvertible
			{
				List<string> list = new List<string>();
				FieldInfo[] fields = typeof(T).GetFields(BindingFlags.Static | BindingFlags.Public);
				foreach (FieldInfo fieldInfo in fields)
				{
					if (ShouldIncludeInUi(fieldInfo))
					{
						list.Add(fieldInfo.Name);
					}
				}
				return list;
			}

			public static T GetValue<T>(string displayName) where T : struct, IConvertible
			{
				foreach (T value in GetValues<T>())
				{
					if (GetDisplayName(value) == displayName)
					{
						return value;
					}
				}
				throw new ArgumentException(displayName + " is not a valid display name for type: " + typeof(T).Name);
			}

			public static IList<object> GetValues(Type type)
			{
				if (!type.IsEnum)
				{
					throw new ArgumentException("Type must be an enumeration");
				}
				List<object> list = new List<object>();
				FieldInfo[] fields = type.GetFields(BindingFlags.Static | BindingFlags.Public);
				foreach (FieldInfo fieldInfo in fields)
				{
					if (ShouldIncludeInUi(fieldInfo))
					{
						list.Add(Enum.Parse(type, fieldInfo.Name, ignoreCase: false));
					}
				}
				return list;
			}

			public static IList<T> GetValues<T>() where T : struct, IConvertible
			{
				List<T> list = new List<T>();
				Type typeFromHandle = typeof(T);
				FieldInfo[] fields = typeof(T).GetFields(BindingFlags.Static | BindingFlags.Public);
				foreach (FieldInfo fieldInfo in fields)
				{
					if (ShouldIncludeInUi(fieldInfo))
					{
						list.Add((T)Enum.Parse(typeFromHandle, fieldInfo.Name, ignoreCase: false));
					}
				}
				return list;
			}

			public static T Parse<T>(string value) where T : struct, IConvertible
			{
				return (T)Enum.Parse(typeof(T), value, ignoreCase: true);
			}

			public static T ParseFromDisplayName<T>(string displayName) where T : struct, IConvertible
			{
				return GetValue<T>(displayName);
			}

			private static bool ShouldIncludeInUi(FieldInfo field)
			{
				bool result = false;
				object[] customAttributes = field.GetCustomAttributes(typeof(UiVisibilityAttribute), inherit: false);
				if (customAttributes == null || customAttributes.Length == 0)
				{
					result = true;
				}
				else
				{
					UiVisibilityAttribute uiVisibilityAttribute = customAttributes[0] as UiVisibilityAttribute;
					if (uiVisibilityAttribute.Visibility == UiVisibility.Visible || (uiVisibilityAttribute.Visibility == UiVisibility.DebugOnly && UnityEngine.Debug.isDebugBuild))
					{
						result = true;
					}
				}
				return result;
			}
		}

		public static class Input
		{
			public static bool AnyMouseButton()
			{
				if (!UnityEngine.Input.GetMouseButton(0) && !UnityEngine.Input.GetMouseButton(1))
				{
					return UnityEngine.Input.GetMouseButton(2);
				}
				return true;
			}
		}

		public static class NameGenerator
		{
			[Serializable]
			private class NamesData
			{
				public string[] Boys;

				public string[] Girls;

				public string[] Last;
			}

			private static NamesData _names;

			public static int JsonBoyNameCount { get; set; } = 1000;

			public static int JsonGirlNameCount { get; set; } = 1000;

			public static int JsonLastNameCount { get; set; } = 1000;

			public static string JsonNameResourceLocation { get; set; } = "Other/names";

			private static NamesData Names
			{
				get
				{
					if (_names == null)
					{
						_names = JsonUtility.FromJson<NamesData>(Resources.Load<TextAsset>(JsonNameResourceLocation).text);
					}
					return _names;
				}
			}

			public static string FirstName(bool? boy)
			{
				if (!boy.HasValue)
				{
					boy = UnityEngine.Random.Range(0, 2) == 0;
				}
				if (boy.Value)
				{
					return Names.Boys[UnityEngine.Random.Range(0, JsonBoyNameCount)];
				}
				return Names.Girls[UnityEngine.Random.Range(0, JsonGirlNameCount)];
			}

			public static string FullName(bool? boy)
			{
				return FirstName(boy) + " " + LastName();
			}

			public static string LastName()
			{
				return Names.Last[UnityEngine.Random.Range(0, JsonLastNameCount)];
			}
		}

		public static class PhysicsUtils
		{
			public static Bounds? BoxcastBounds(Vector3 centerPoint, int layerMask, float boxSize, float boxThickness = 0.1f, QueryTriggerInteraction queryTriggerInteraction = QueryTriggerInteraction.Ignore)
			{
				if (boxSize <= 0f)
				{
					throw new ArgumentException("boxSize must be greater than zero", "boxSize");
				}
				float num = boxSize * 0.5f;
				Vector3 vector = centerPoint;
				Quaternion identity = Quaternion.identity;
				Vector3 center = new Vector3(vector.x - num, vector.y, vector.z);
				Vector3 center2 = new Vector3(vector.x + num, vector.y, vector.z);
				Vector3 center3 = new Vector3(vector.x, vector.y - num, vector.z);
				Vector3 center4 = new Vector3(vector.x, vector.y + num, vector.z);
				Vector3 center5 = new Vector3(vector.x, vector.y, vector.z - num);
				Vector3 center6 = new Vector3(vector.x, vector.y, vector.z + num);
				if (float.IsNegativeInfinity(center.x))
				{
					center.x = float.MinValue;
				}
				if (float.IsPositiveInfinity(center2.x))
				{
					center2.x = float.MaxValue;
				}
				if (float.IsNegativeInfinity(center3.y))
				{
					center3.y = float.MinValue;
				}
				if (float.IsPositiveInfinity(center4.y))
				{
					center4.y = float.MaxValue;
				}
				if (float.IsNegativeInfinity(center5.z))
				{
					center5.z = float.MinValue;
				}
				if (float.IsPositiveInfinity(center6.z))
				{
					center6.z = float.MaxValue;
				}
				if (Physics.BoxCast(center, new Vector3(boxThickness, num, num), Vector3.right, out var hitInfo, identity, boxSize, layerMask, queryTriggerInteraction) && Physics.BoxCast(center2, new Vector3(boxThickness, num, num), Vector3.left, out var hitInfo2, identity, boxSize, layerMask, queryTriggerInteraction) && Physics.BoxCast(center3, new Vector3(num, boxThickness, num), Vector3.up, out var hitInfo3, identity, boxSize, layerMask, queryTriggerInteraction) && Physics.BoxCast(center4, new Vector3(num, boxThickness, num), Vector3.down, out var hitInfo4, identity, boxSize, layerMask, queryTriggerInteraction) && Physics.BoxCast(center5, new Vector3(num, num, boxThickness), Vector3.forward, out var hitInfo5, identity, boxSize, layerMask, queryTriggerInteraction) && Physics.BoxCast(center6, new Vector3(num, num, boxThickness), Vector3.back, out var hitInfo6, identity, boxSize, layerMask, queryTriggerInteraction))
				{
					Vector3 vector2 = new Vector3(hitInfo.point.x, hitInfo3.point.y, hitInfo5.point.z);
					Vector3 vector3 = new Vector3(hitInfo2.point.x, hitInfo4.point.y, hitInfo6.point.z) - vector2;
					return new Bounds(vector2 + vector3 * 0.5f, vector3);
				}
				return null;
			}

			public static void DepenetrateCollider(CapsuleCollider collider, Transform transToMove, Vector3 depenetrationDirection, float epsilon, int layerMask, QueryTriggerInteraction queryTriggerInteraction)
			{
				if (OverlapCapsule(collider, layerMask, queryTriggerInteraction).Length == 0)
				{
					return;
				}
				Vector3 colliderUp = GetColliderUp(collider);
				float num = collider.radius * 2f;
				float num2 = (collider.height - num) * Mathf.Abs(Vector3.Dot(colliderUp, depenetrationDirection)) + num;
				int num3 = 0;
				bool flag = true;
				while (Mathf.Abs(num2) > epsilon && num3++ < 100)
				{
					transToMove.position += depenetrationDirection * num2;
					Physics.SyncTransforms();
					if (OverlapCapsule(collider, layerMask, QueryTriggerInteraction.Ignore).Length == 0)
					{
						if (flag)
						{
							num2 = (0f - num2) * 0.5f;
						}
						flag = false;
					}
					else
					{
						if (!flag)
						{
							num2 = (0f - num2) * 0.5f;
						}
						flag = true;
					}
				}
				if (num3 >= 100)
				{
					UnityEngine.Debug.LogWarning($"Reached MaxSteps({100}) while tryinig to depenetrate the collider: {collider.name}");
				}
			}

			public static double GetAgl(Vector3 framePos)
			{
				IPlanetNode parent = Game.Instance.FlightScene.CraftNode.Parent;
				Vector3d planetPosition = Game.Instance.FlightScene.ViewManager.GameView.ReferenceFrame.FrameToPlanetPosition(framePos);
				return planetPosition.magnitude - (parent.GetTerrainHeight(planetPosition) + parent.PlanetData.Radius);
			}

			public static float GetAngularVelocityAroundAxis(Vector3 axis, Quaternion axisTransformRotation, Vector3 angularVelocityWorld)
			{
				return Vector3.Dot(axis, Quaternion.Inverse(axisTransformRotation) * angularVelocityWorld);
			}

			public static Vector3 GetColliderUp(CapsuleCollider collider)
			{
				switch (collider.direction)
				{
				case 0:
					return collider.transform.right;
				case 1:
					return collider.transform.up;
				case 2:
					return collider.transform.forward;
				default:
					UnityEngine.Debug.LogError($"Unknown capsule collider direction: {collider.direction}");
					return collider.transform.up;
				}
			}

			public static float GetRpmAroundAxis(Vector3 axis, Transform axisTransform, Vector3 angularVelocityWorld)
			{
				return GetAngularVelocityAroundAxis(axis, (axisTransform != null) ? axisTransform.rotation : Quaternion.identity, angularVelocityWorld) * 57.29578f * 60f / 360f;
			}

			public static Collider[] OverlapCapsule(CapsuleCollider collider, int layerMask, QueryTriggerInteraction queryTriggerInteraction)
			{
				Vector3 vector = GetColliderUp(collider) * (collider.height * 0.5f - collider.radius);
				Vector3 vector2 = collider.transform.TransformPoint(collider.center);
				return Physics.OverlapCapsule(vector2 + vector, vector2 - vector, collider.radius, layerMask, queryTriggerInteraction);
			}
		}

		public static class Texture
		{
			public static Texture2D CreateResizedTexture(Texture2D sourceTexture, int targetWidth, int targetHeight)
			{
				Texture2D texture2D = new Texture2D(targetWidth, targetHeight, sourceTexture.format, mipChain: false);
				for (int i = 0; i < targetWidth; i++)
				{
					for (int j = 0; j < targetHeight; j++)
					{
						float u = (float)i / (float)targetWidth;
						float v = (float)j / (float)targetHeight;
						Color pixelBilinear = sourceTexture.GetPixelBilinear(u, v);
						texture2D.SetPixel(i, j, pixelBilinear);
					}
				}
				texture2D.Apply();
				return texture2D;
			}

			public static Texture2D CreateSquareThumbnail(Texture2D sourceTexture, int size)
			{
				float num = Mathf.Max((float)size / (float)sourceTexture.width, (float)size / (float)sourceTexture.height);
				Texture2D texture2D = CreateResizedTexture(sourceTexture, (int)((float)sourceTexture.width * num), (int)((float)sourceTexture.height * num));
				Vector2i vector2i = new Vector2i(texture2D.width / 2, texture2D.height / 2);
				Vector2i min = vector2i - new Vector2i(size / 2, size / 2);
				Vector2i max = vector2i + new Vector2i(size / 2, size / 2);
				return CropTexture(texture2D, min, max);
			}

			public static Texture2D CropTexture(Texture2D sourceTexture, Vector2i min, Vector2i max)
			{
				if (min.x < 0 || min.y < 0 || min.x >= max.x || min.y >= max.y || min.x >= sourceTexture.width || min.y >= sourceTexture.height)
				{
					throw new ArgumentException($"Invalid crop region ({min})-({max}) for source texture of size {sourceTexture.width}x{sourceTexture.height}");
				}
				Texture2D texture2D = new Texture2D(max.x - min.x, max.y - min.y, sourceTexture.format, mipChain: false);
				for (int i = 0; i < texture2D.width; i++)
				{
					for (int j = 0; j < texture2D.height; j++)
					{
						int x = min.x + i;
						int y = min.y + j;
						Color pixel = sourceTexture.GetPixel(x, y);
						texture2D.SetPixel(i, j, pixel);
					}
				}
				texture2D.Apply();
				return texture2D;
			}

			public static RenderTextureFormat GetDefaultRenderTextureFormat()
			{
				if (Game.Instance.QualitySettings.ImageEffects.HdrEnabled.Value)
				{
					return RenderTextureFormat.DefaultHDR;
				}
				return RenderTextureFormat.Default;
			}
		}

		public static class UnityTransform
		{
			public enum TransformAxis
			{
				X = 0,
				Y = 1,
				Z = 2
			}

			public static void DestroyChildren(Transform parent)
			{
				int childCount = parent.childCount;
				for (int i = 0; i < childCount; i++)
				{
					UnityEngine.Object.Destroy(parent.GetChild(i).gameObject);
				}
			}

			public static Transform GetFirstChild(Transform transform)
			{
				if (transform.childCount > 0)
				{
					return transform.GetChild(0);
				}
				return null;
			}

			public static Vector3 GetRotation(TransformAxis axis, float degrees)
			{
				return axis switch
				{
					TransformAxis.X => new Vector3(degrees, 0f, 0f), 
					TransformAxis.Y => new Vector3(0f, degrees, 0f), 
					TransformAxis.Z => new Vector3(0f, 0f, degrees), 
					_ => throw new InvalidOperationException(), 
				};
			}

			public static Vector3 GetVector(Transform trans, TransformAxis axis, bool local)
			{
				return axis switch
				{
					TransformAxis.X => local ? trans.right : Vector3.right, 
					TransformAxis.Y => local ? trans.up : Vector3.up, 
					TransformAxis.Z => local ? trans.forward : Vector3.forward, 
					_ => throw new ArgumentException(), 
				};
			}

			public static void MoveChildren(Transform from, Transform to)
			{
				Transform firstChild;
				do
				{
					firstChild = GetFirstChild(from);
					if (firstChild != null)
					{
						firstChild.parent = to;
					}
				}
				while (firstChild != null);
			}

			public static void RotateChildrenAround(Transform parent, Vector3 worldPivot, Vector3 worldEulersAngles)
			{
				Transform transform = new GameObject("RotateChildrenAround_TempTransform").transform;
				transform.SetPositionAndRotation(worldPivot, Quaternion.identity);
				MoveChildren(parent, transform);
				transform.Rotate(worldEulersAngles);
				MoveChildren(transform, parent);
				UnityEngine.Object.Destroy(transform.gameObject);
			}

			public static void ScaleAroundPivot(Transform scaleTrans, Transform pivotTrans, Vector3 scale)
			{
				Transform parent = scaleTrans.parent;
				Transform parent2 = pivotTrans.parent;
				pivotTrans.parent = null;
				pivotTrans.localScale = Vector3.one;
				scaleTrans.parent = pivotTrans;
				pivotTrans.localScale = scale;
				scaleTrans.parent = parent;
				pivotTrans.parent = parent2;
			}

			public static void SetLossyWorldScale(Transform trans, Vector3 worldScale)
			{
				Vector3 lossyScale = trans.lossyScale;
				trans.localScale = new Vector3(worldScale.x / lossyScale.x, worldScale.y / lossyScale.y, worldScale.z / lossyScale.z);
			}
		}

		public const double DefaultComparisonEpsilon = 1E-06;

		private static string[] _forbiddenNames = new string[22]
		{
			"CON", "PRN", "AUX", "NUL", "COM1", "COM2", "COM3", "COM4", "COM5", "COM6",
			"COM7", "COM8", "COM9", "LPT1", "LPT2", "LPT3", "LPT4", "LPT5", "LPT6", "LPT7",
			"LPT8", "LPT9"
		};

		private static Stack<Transform> _tempTransformStack = new Stack<Transform>();

		private static char[] _vectorParseTrimChars = new char[3] { ' ', '(', ')' };

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

		public static Bounds CalculateBounds(GameObject g, bool includeSkinnedMeshRenderers = false, int? layer = null)
		{
			Vector3 vector = new Vector3(float.MinValue, float.MinValue, float.MinValue);
			Vector3 vector2 = new Vector3(float.MaxValue, float.MaxValue, float.MaxValue);
			MeshRenderer[] componentsInChildren = g.GetComponentsInChildren<MeshRenderer>();
			foreach (MeshRenderer meshRenderer in componentsInChildren)
			{
				if (!layer.HasValue || layer.Value == meshRenderer.gameObject.layer)
				{
					vector = Vector3.Max(vector, meshRenderer.bounds.max);
					vector2 = Vector3.Min(vector2, meshRenderer.bounds.min);
				}
			}
			if (includeSkinnedMeshRenderers)
			{
				SkinnedMeshRenderer[] componentsInChildren2 = g.GetComponentsInChildren<SkinnedMeshRenderer>();
				foreach (SkinnedMeshRenderer skinnedMeshRenderer in componentsInChildren2)
				{
					if (!layer.HasValue || layer.Value == skinnedMeshRenderer.gameObject.layer)
					{
						vector = Vector3.Max(vector, skinnedMeshRenderer.bounds.max);
						vector2 = Vector3.Min(vector2, skinnedMeshRenderer.bounds.min);
					}
				}
			}
			return new Bounds((vector + vector2) * 0.5f, vector - vector2);
		}

		public static Bounds CalculateBoundsOfGameObject(GameObject root)
		{
			Bounds bounds = new Bounds(root.transform.position, default(Vector3));
			Collider[] componentsInChildren = root.GetComponentsInChildren<Collider>();
			foreach (Collider collider in componentsInChildren)
			{
				bounds = ExpandBounds(bounds, collider.bounds);
			}
			bounds.size = bounds.size;
			return bounds;
		}

		public static void ChangeLayersOfGameObjectAndChildrenRecursive(GameObject objectToChange, string layerName, params string[] layersToIgnore)
		{
			int[] layersToIgnore2 = ((layersToIgnore == null || layersToIgnore.Length == 0) ? null : layersToIgnore.Select((string x) => LayerMask.NameToLayer(x)).ToArray());
			ChangeLayersOfGameObjectAndChildrenRecursive(objectToChange, LayerMask.NameToLayer(layerName), layersToIgnore2);
		}

		public static void ChangeLayersOfGameObjectAndChildrenRecursive(GameObject objectToChange, int layerNum, params int[] layersToIgnore)
		{
			if (layersToIgnore == null || !layersToIgnore.Contains(objectToChange.layer))
			{
				objectToChange.layer = layerNum;
			}
			foreach (Transform item in objectToChange.transform)
			{
				ChangeLayersOfGameObjectAndChildrenRecursive(item.gameObject, layerNum, layersToIgnore);
			}
		}

		public static List<T> CloneList<T>(IEnumerable<T> list)
		{
			List<T> list2 = new List<T>();
			foreach (T item in list)
			{
				list2.Add(item);
			}
			return list2;
		}

		public static string ColorToHex(Color32 color)
		{
			return color.r.ToString("X2") + color.g.ToString("X2") + color.b.ToString("X2");
		}

		public static string CombinePaths(params string[] paths)
		{
			return Path.Combine(paths).Replace("\\", "/");
		}

		public static bool CompareDoubles(double p1, double p2, double epsilon = 1E-06)
		{
			if (p1 == p2)
			{
				return true;
			}
			return System.Math.Abs(p1 - p2) <= epsilon;
		}

		public static bool CompareDoublesGt(double lhs, double rhs, double epsilon = 9.999999974752427E-07)
		{
			if (lhs > rhs)
			{
				return !CompareDoubles(lhs, rhs, epsilon);
			}
			return false;
		}

		public static bool CompareDoublesGte(double lhs, double rhs, double epsilon = 9.999999974752427E-07)
		{
			if (!(lhs > rhs))
			{
				return CompareDoubles(lhs, rhs, epsilon);
			}
			return true;
		}

		public static bool CompareDoublesLt(double lhs, double rhs, double epsilon = 9.999999974752427E-07)
		{
			if (lhs < rhs)
			{
				return !CompareDoubles(lhs, rhs, epsilon);
			}
			return false;
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
				return CompareFloats(quat1.w, quat2.w);
			}
			return false;
		}

		public static bool CompareTextFiles(string filePath1, string filePath2, bool ignoreLineEndings)
		{
			try
			{
				string text = File.ReadAllText(filePath1);
				string text2 = File.ReadAllText(filePath2);
				if (ignoreLineEndings)
				{
					text = text.Replace("\r\n", "\n");
					text2 = text2.Replace("\r\n", "\n");
				}
				return text.Equals(text2);
			}
			catch (Exception ex)
			{
				UnityEngine.Debug.LogError("An error occurred comparing the files: " + ex.Message);
				return false;
			}
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

		public static string ComputeHash(byte[] bytes)
		{
			using MD5CryptoServiceProvider mD5CryptoServiceProvider = new MD5CryptoServiceProvider();
			return BitConverter.ToString(mD5CryptoServiceProvider.ComputeHash(bytes)).Replace("-", string.Empty).ToLowerInvariant();
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

		public static void CopyDirectory(string sourceDirectoryPath, string destinationDirectoryPath, bool copySubDirectories, bool overwriteFiles)
		{
			DirectoryInfo directoryInfo = new DirectoryInfo(sourceDirectoryPath);
			if (!directoryInfo.Exists)
			{
				throw new DirectoryNotFoundException("Source directory does not exist: " + sourceDirectoryPath);
			}
			DirectoryInfo[] directories = directoryInfo.GetDirectories();
			if (!Directory.Exists(destinationDirectoryPath))
			{
				Directory.CreateDirectory(destinationDirectoryPath);
			}
			FileInfo[] files = directoryInfo.GetFiles();
			foreach (FileInfo fileInfo in files)
			{
				string destFileName = Path.Combine(destinationDirectoryPath, fileInfo.Name);
				fileInfo.CopyTo(destFileName, overwriteFiles);
			}
			if (copySubDirectories)
			{
				DirectoryInfo[] array = directories;
				foreach (DirectoryInfo directoryInfo2 in array)
				{
					string destinationDirectoryPath2 = Path.Combine(destinationDirectoryPath, directoryInfo2.Name);
					CopyDirectory(directoryInfo2.FullName, destinationDirectoryPath2, copySubDirectories, overwriteFiles);
				}
			}
		}

		public static void Delete(string filePath)
		{
			try
			{
				if (File.Exists(filePath))
				{
					File.Delete(filePath);
				}
			}
			catch (Exception)
			{
			}
		}

		public static void DeleteDirectory(string path)
		{
			string[] directories = Directory.GetDirectories(path);
			for (int i = 0; i < directories.Length; i++)
			{
				DeleteDirectory(directories[i]);
			}
			try
			{
				Directory.Delete(path, recursive: true);
			}
			catch (IOException)
			{
				Directory.Delete(path, recursive: true);
			}
			catch (UnauthorizedAccessException)
			{
				Directory.Delete(path, recursive: true);
			}
		}

		public static void DeleteDirectoryFromPersistentData(string path, bool recursive = false)
		{
			if (path.Contains(Application.persistentDataPath))
			{
				Directory.Delete(path, recursive);
				return;
			}
			throw new ArgumentException("Attempted to delete directory outside of persistent data path: " + path);
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
			if (bounds2.min.x < min.x)
			{
				min.x = bounds2.min.x;
			}
			if (bounds2.max.x > max.x)
			{
				max.x = bounds2.max.x;
			}
			if (bounds2.min.y < min.y)
			{
				min.y = bounds2.min.y;
			}
			if (bounds2.max.y > max.y)
			{
				max.y = bounds2.max.y;
			}
			if (bounds2.min.z < min.z)
			{
				min.z = bounds2.min.z;
			}
			if (bounds2.max.z > max.z)
			{
				max.z = bounds2.max.z;
			}
			bounds.SetMinMax(min, max);
			return bounds;
		}

		public static GameObject FindFirstGameObjectMyselfOrChildren(string name, GameObject gameObject, bool includeInactive = true)
		{
			_tempTransformStack.Clear();
			if ((object)gameObject == null)
			{
				List<GameObject> rootGameObjects = GetRootGameObjects();
				for (int num = rootGameObjects.Count - 1; num >= 0; num--)
				{
					if (includeInactive || rootGameObjects[num].activeInHierarchy)
					{
						_tempTransformStack.Push(rootGameObjects[num].transform);
					}
				}
			}
			else if (includeInactive || gameObject.activeInHierarchy)
			{
				_tempTransformStack.Push(gameObject.transform);
			}
			while (_tempTransformStack.Count > 0)
			{
				Transform transform = _tempTransformStack.Pop();
				if (transform.name == name)
				{
					_tempTransformStack.Clear();
					return transform.gameObject;
				}
				for (int num2 = transform.childCount - 1; num2 >= 0; num2--)
				{
					if (includeInactive || transform.gameObject.activeSelf)
					{
						_tempTransformStack.Push(transform.GetChild(num2));
					}
				}
			}
			_tempTransformStack.Clear();
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
				if (gameObject.name == name || name == null)
				{
					T component = gameObject.GetComponent<T>();
					if (component != null)
					{
						list.Add(component);
					}
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

		public static string FindUniqueFilename(string directoryPath, string name, string extension)
		{
			name = ScrubFileName(name);
			string text = Path.Combine(directoryPath, name + extension);
			if (File.Exists(text))
			{
				bool flag = false;
				for (int i = 1; i < 1000; i++)
				{
					string text2 = $"{name}-{i}";
					text = Path.Combine(directoryPath, text2 + extension);
					if (!File.Exists(text))
					{
						flag = true;
						break;
					}
				}
				if (!flag)
				{
					throw new Exception("Unable to find a unique filename at path " + directoryPath);
				}
			}
			return text;
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

		public static string FormatPercentage(float x)
		{
			return RoundPercentage(x) + "%";
		}

		public static Version FormatVersion(string versionString, Version defaultVersion = null)
		{
			if (Version.TryParse(versionString, out var result))
			{
				return result;
			}
			return defaultVersion;
		}

		public static T FromXElement<T>(this XElement xElement)
		{
			return new UnityXmlSerializer(new UnityXmlSerializerContext
			{
				IgnoreUnderscorePrefix = true
			}).Deserialize<T>(xElement);
		}

		public static Vector3 GameWorldToScreenPoint(Camera camera, Vector3 position)
		{
			return camera.WorldToScreenPoint(position) / Game.Instance.ResolutionScale;
		}

		public static AnimationCurve GetAnimationCurveAttribute(XElement element, string attributeName)
		{
			return new AnimationCurve((from x in ((string)element.Attribute(attributeName)).Split('|')
				select x.Split(',').ToArray()).Select(delegate(string[] x)
			{
				if (x.Length == 2)
				{
					return new Keyframe(DataIO.ParseFloat(x[0]), DataIO.ParseFloat(x[1]));
				}
				Keyframe result = new Keyframe(DataIO.ParseFloat(x[0]), DataIO.ParseFloat(x[1]), DataIO.ParseFloat(x[2]), DataIO.ParseFloat(x[3]));
				if (x.Length == 4)
				{
					return result;
				}
				result.inWeight = DataIO.ParseFloat(x[4]);
				result.outWeight = DataIO.ParseFloat(x[5]);
				if (x.Length == 6)
				{
					return result;
				}
				result.weightedMode = (WeightedMode)DataIO.ParseInt(x[6]);
				result.tangentMode = DataIO.ParseInt(x[7]);
				return result;
			}).ToArray());
		}

		public static bool GetBoolAttribute(XElement element, string attributeName, bool defaultValue)
		{
			XAttribute xAttribute = element.Attribute(attributeName);
			if (xAttribute != null)
			{
				return DataIO.ParseBool(xAttribute.Value, defaultValue);
			}
			return defaultValue;
		}

		public static bool? GetBoolNullableAttribute(XElement element, string attributeName, bool? defaultValue)
		{
			XAttribute xAttribute = element.Attribute(attributeName);
			if (xAttribute != null)
			{
				return DataIO.ParseBoolNullable(xAttribute.Value, defaultValue);
			}
			return defaultValue;
		}

		public static List<T> GetChildren<T>(string name, GameObject gameObject) where T : Component
		{
			List<T> list = new List<T>();
			if (gameObject == null)
			{
				foreach (GameObject rootGameObject in GetRootGameObjects())
				{
					List<T> list2 = FindObjectsMyselfOrChildren<T>(name, rootGameObject);
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

		public static Color GetColorAttribute(XElement element, string attributeName, Color defaultValue)
		{
			try
			{
				XAttribute xAttribute = element.Attribute(attributeName);
				if (xAttribute != null)
				{
					float[] array = (from x in xAttribute.Value.Split(',')
						select DataIO.ParseFloat(x)).ToArray();
					return new Color(array[0], array[1], array[2], array[3]);
				}
			}
			catch (Exception ex)
			{
				UnityEngine.Debug.LogErrorFormat("Unable to parse color value from XML attribute '{0}'.{1}{2}", attributeName, Environment.NewLine, ex);
			}
			return defaultValue;
		}

		public static Color GetColorAttribute(XAttribute attribute, Color defaultValue)
		{
			try
			{
				if (attribute != null)
				{
					float[] array = (from x in attribute.Value.Split(',')
						select DataIO.ParseFloat(x)).ToArray();
					return new Color(array[0], array[1], array[2], array[3]);
				}
			}
			catch (Exception ex)
			{
				UnityEngine.Debug.LogErrorFormat("Unable to parse color value from XML attribute '{0}'.{1}{2}", attribute?.Name, Environment.NewLine, ex);
			}
			return defaultValue;
		}

		public static T GetComponentInParent<T>(Transform transform)
		{
			if (transform != null)
			{
				T component = transform.GetComponent<T>();
				if (component != null)
				{
					return component;
				}
				return GetComponentInParent<T>(transform.parent);
			}
			return default(T);
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static string GetCurrentMethod()
		{
			return new StackTrace().GetFrame(1).GetMethod().Name;
		}

		public static T GetEnumAttribute<T>(XElement element, string attributeName, T defaultValue)
		{
			XAttribute xAttribute = element.Attribute(attributeName);
			if (xAttribute != null)
			{
				try
				{
					return (T)Enum.Parse(typeof(T), xAttribute.Value, ignoreCase: true);
				}
				catch (Exception)
				{
					UnityEngine.Debug.LogErrorFormat("Unable to parse attribute '{0}' as an enumeration of type '{1}'", attributeName, typeof(T).FullName);
					return defaultValue;
				}
			}
			return defaultValue;
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

		public static float GetFloatAttribute(XElement element, string attributeName, float defaultValue)
		{
			XAttribute xAttribute = element.Attribute(attributeName);
			if (xAttribute != null)
			{
				return DataIO.ParseFloat(xAttribute.Value, defaultValue);
			}
			return defaultValue;
		}

		public static Gradient GetGradientAttribute(XElement element, string attributeName, bool includeAlphaKeys, Gradient defaultValue = null)
		{
			Gradient gradient = new Gradient();
			string text = (string)element.Attribute(attributeName);
			if (text == null)
			{
				return defaultValue;
			}
			string[] array = text.Split(new string[1] { "||" }, StringSplitOptions.RemoveEmptyEntries);
			GradientColorKey[] colorKeys = (from x in array[0].Split('|')
				select (from y in x.Split(',')
					select DataIO.ParseFloat(y)).ToArray() into x
				select new GradientColorKey(new Color(x[1], x[2], x[3]), x[0])).ToArray();
			if (includeAlphaKeys && array.Length == 2)
			{
				GradientAlphaKey[] alphaKeys = (from x in array[1].Split('|')
					select (from y in x.Split(',')
						select DataIO.ParseFloat(y)).ToArray() into x
					select new GradientAlphaKey(x[1], x[0])).ToArray();
				gradient.SetKeys(colorKeys, alphaKeys);
			}
			else
			{
				gradient.SetKeys(colorKeys, new GradientAlphaKey[0]);
			}
			return gradient;
		}

		public static Guid? GetGuidAttribute(XElement element, string attributeName, Guid? defaultValue)
		{
			XAttribute xAttribute = element.Attribute(attributeName);
			if (xAttribute != null)
			{
				try
				{
					return new Guid(xAttribute.Value);
				}
				catch (Exception)
				{
					return defaultValue;
				}
			}
			return defaultValue;
		}

		public static Guid GetGuidAttribute(XElement element, string attributeName, Guid defaultValue)
		{
			XAttribute xAttribute = element.Attribute(attributeName);
			if (xAttribute != null)
			{
				try
				{
					return new Guid(xAttribute.Value);
				}
				catch (Exception)
				{
					return defaultValue;
				}
			}
			return defaultValue;
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

		public static Color? GetHtmlColorAttribute(XElement element, string attributeName, Color? defaultValue)
		{
			XAttribute xAttribute = element.Attribute(attributeName);
			if (xAttribute != null && ColorUtility.TryParseHtmlString(xAttribute.Value.StartsWith("#") ? xAttribute.Value : ("#" + xAttribute.Value), out var color))
			{
				return color;
			}
			return defaultValue;
		}

		public static int GetIntAttribute(XElement element, string attributeName, int defaultValue)
		{
			try
			{
				XAttribute xAttribute = element.Attribute(attributeName);
				if (xAttribute != null)
				{
					return DataIO.ParseInt(xAttribute.Value, defaultValue);
				}
				return defaultValue;
			}
			catch (Exception)
			{
				UnityEngine.Debug.LogError($"Error getting int attribute: \"{attributeName}\"");
				throw;
			}
		}

		public static List<int> GetIntListAttribute(XElement element, string attributeName, char separator = ',')
		{
			List<int> list = new List<int>();
			XAttribute xAttribute = element.Attribute(attributeName);
			if (xAttribute != null)
			{
				string[] array = xAttribute.Value.Split(separator);
				foreach (string stringValue in array)
				{
					int value = 0;
					if (!DataIO.TryParseInt(stringValue, out value))
					{
						break;
					}
					list.Add(value);
				}
			}
			return list;
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

		public static T GetParentOrSelf<T>(Transform transform) where T : Component
		{
			return transform.GetComponentInParent<T>();
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

		public static string GetPathToResource(string resourceFolder, string fileName)
		{
			string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(fileName);
			return CombinePaths(resourceFolder, fileNameWithoutExtension);
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

		public static float GetRemainingPercentage(this IFuelSource fuelSource)
		{
			double? num = fuelSource?.TotalCapacity;
			if (num > 0.0)
			{
				double totalFuel = fuelSource.TotalFuel;
				if (totalFuel < 9.999999747378752E-05)
				{
					return 0f;
				}
				return (float)(totalFuel / num.Value);
			}
			return 0f;
		}

		public static List<GameObject> GetRootGameObjects()
		{
			List<GameObject> list = new List<GameObject>();
			UnityEngine.Object[] array = UnityEngine.Object.FindObjectsOfType(typeof(GameObject));
			for (int i = 0; i < array.Length; i++)
			{
				GameObject gameObject = (GameObject)array[i];
				if (gameObject.transform.parent == null)
				{
					list.Add(gameObject);
				}
			}
			return list;
		}

		public static string GetStringAttribute(XElement element, string attributeName, string defaultValue)
		{
			XAttribute xAttribute = element.Attribute(attributeName);
			if (xAttribute != null)
			{
				return xAttribute.Value;
			}
			return defaultValue;
		}

		public static LeadPositionResult GetTargetLeadPrediction(Rigidbody originator, Rigidbody target, float leadAccuracy)
		{
			return GetTargetLeadPrediction(originator.transform.position, originator.velocity, target.transform.position, target.velocity, leadAccuracy);
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

		public static Vector2 GetVector2Attribute(XElement element, string attributeName, Vector2 defaultValue)
		{
			XAttribute xAttribute = element.Attribute(attributeName);
			if (xAttribute != null)
			{
				return ParseVector2(xAttribute.Value);
			}
			return defaultValue;
		}

		public static Vector3 GetVectorAttribute(XElement element, string attributeName, Vector3 defaultValue)
		{
			XAttribute xAttribute = element.Attribute(attributeName);
			if (xAttribute != null)
			{
				return ParseVector3(xAttribute.Value);
			}
			return defaultValue;
		}

		public static Vector3? GetVectorAttribute(XElement element, string attributeName, Vector3? defaultValue)
		{
			XAttribute xAttribute = element.Attribute(attributeName);
			if (xAttribute != null)
			{
				return ParseVector3(xAttribute.Value);
			}
			return defaultValue;
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

		public static Color HexToColor(string hex)
		{
			if (hex.StartsWith("#"))
			{
				hex = hex.Substring(1);
			}
			byte r = byte.Parse(hex.Substring(0, 2), NumberStyles.HexNumber);
			byte g = byte.Parse(hex.Substring(2, 2), NumberStyles.HexNumber);
			byte b = byte.Parse(hex.Substring(4, 2), NumberStyles.HexNumber);
			byte a = ((hex.Length > 6) ? byte.Parse(hex.Substring(6, 2), NumberStyles.HexNumber) : byte.MaxValue);
			if (hex.Length >= 8)
			{
				a = byte.Parse(hex.Substring(6, 2), NumberStyles.HexNumber);
			}
			return new Color32(r, g, b, a);
		}

		public static bool IsNan(Vector3 value)
		{
			if (float.IsNaN(value.x) || float.IsNaN(value.y) || float.IsNaN(value.z))
			{
				return true;
			}
			return false;
		}

		public static bool IsNan(Quaternion value)
		{
			if (!float.IsNaN(value.x) && !float.IsNaN(value.y) && !float.IsNaN(value.z))
			{
				return float.IsNaN(value.w);
			}
			return true;
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
			if (angle < -180f)
			{
				angle += 360f;
			}
			else if (angle > 180f)
			{
				angle -= 360f;
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

		public static void Move(string sourceFileName, string destFileName, bool overwriteExisting)
		{
			Delete(destFileName);
			File.Move(sourceFileName, destFileName);
		}

		public static T NextEnum<T>(T src) where T : struct
		{
			if (!typeof(T).IsEnum)
			{
				throw new ArgumentException($" {typeof(T).FullName} is not an Enum");
			}
			T[] array = (T[])Enum.GetValues(typeof(T));
			int num = Array.IndexOf(array, src) + 1;
			if (array.Length != num)
			{
				return array[num];
			}
			return array[0];
		}

		public static int ParseInt(string stringToParse, int defaultValue)
		{
			int result = 0;
			if (int.TryParse(stringToParse, out result))
			{
				return result;
			}
			return defaultValue;
		}

		public static Quaternion ParseQuaternion(string stringToParse)
		{
			string[] array = stringToParse.Trim(_vectorParseTrimChars).Split(',');
			float x = DataIO.ParseFloat(array[0]);
			float y = DataIO.ParseFloat(array[1]);
			float z = DataIO.ParseFloat(array[2]);
			float w = DataIO.ParseFloat(array[3]);
			return new Quaternion(x, y, z, w);
		}

		public static Vector2 ParseVector2(string stringToParse)
		{
			string[] array = stringToParse.Trim(_vectorParseTrimChars).Split(',');
			float x = DataIO.ParseFloat(array[0]);
			float y = DataIO.ParseFloat(array[1]);
			return new Vector2(x, y);
		}

		public static Vector3 ParseVector3(string stringToParse)
		{
			string[] array = stringToParse.Trim(_vectorParseTrimChars).Split(',');
			float x = DataIO.ParseFloat(array[0]);
			float y = DataIO.ParseFloat(array[1]);
			float z = DataIO.ParseFloat(array[2]);
			return new Vector3(x, y, z);
		}

		public static Vector3 PredictPositionInFuture(Vector3 targetCurrentPosition, Vector3 targetCurrentVelocity, float timeInFuture)
		{
			return targetCurrentPosition + targetCurrentVelocity * timeInFuture;
		}

		public static string QuaterniondToString(Quaterniond q)
		{
			return DataIO.ToString(q.x) + "," + DataIO.ToString(q.y) + "," + DataIO.ToString(q.z) + "," + DataIO.ToString(q.w);
		}

		public static string QuaternionToString(Quaternion q)
		{
			return DataIO.ToString(q.x) + "," + DataIO.ToString(q.y) + "," + DataIO.ToString(q.z) + "," + DataIO.ToString(q.w);
		}

		public static T RaycastComponent<T>(Ray ray) where T : MonoBehaviour
		{
			RaycastHit rayHit;
			return RaycastComponent<T>(ray, sphereCast: false, 0f, out rayHit);
		}

		public static T RaycastComponent<T>(Ray ray, bool sphereCast, float sphereCastRadius) where T : MonoBehaviour
		{
			RaycastHit rayHit;
			return RaycastComponent<T>(ray, sphereCast: false, sphereCastRadius, out rayHit);
		}

		public static T RaycastComponent<T>(Ray ray, bool sphereCast, float sphereCastRadius, out RaycastHit rayHit) where T : MonoBehaviour
		{
			T result = null;
			if ((!sphereCast) ? Physics.Raycast(ray, out rayHit, 10000f, 1024) : Physics.SphereCast(ray, sphereCastRadius, out rayHit, 10000f, 1024))
			{
				return rayHit.collider.gameObject.GetComponentInParent<T>();
			}
			return result;
		}

		public static byte[] ReadStreamingAssetsFileAsBytes(string path)
		{
			return ReadStreamingAssetsFile<byte[]>(path);
		}

		public static string ReadStreamingAssetsFileAsText(string path)
		{
			return ReadStreamingAssetsFile<string>(path);
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

		public static string RemoveFileExtension(string fileName)
		{
			int num = fileName.LastIndexOf('.');
			if (num > 0)
			{
				fileName = fileName.Remove(num);
			}
			return fileName;
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

		public static Ray ScreenPointToRay(Camera camera, Vector2 screenPosition, bool useResolutionScale = true)
		{
			if (useResolutionScale)
			{
				screenPosition *= Game.Instance.ResolutionScale;
			}
			return camera.ScreenPointToRay(screenPosition);
		}

		public static string ScrubFileName(string name)
		{
			string text = "!%()_-=+[{]};',. ";
			string text2 = string.Empty;
			if (!string.IsNullOrEmpty(name))
			{
				while (name.Contains(".."))
				{
					name = name.Replace("..", string.Empty);
				}
				while (name.Contains(" ."))
				{
					name = name.Replace(" .", string.Empty);
				}
				string text3 = name;
				for (int i = 0; i < text3.Length; i++)
				{
					char c = text3[i];
					text2 = ((!char.IsLetterOrDigit(c) && !text.Contains(c)) ? (text2 + " ") : (text2 + c));
				}
			}
			text2 = text2.Trim(' ', '.');
			if (_forbiddenNames.Contains(text2))
			{
				text2 += "_";
			}
			return text2;
		}

		public static string ScrubString(string s, string whitelist)
		{
			StringBuilder stringBuilder = new StringBuilder(s.Length);
			foreach (char value in s)
			{
				if (whitelist.Contains(value))
				{
					stringBuilder.Append(value);
				}
			}
			return stringBuilder.ToString();
		}

		public static void SetAnimationCurveAttribute(XElement element, string attributeName, AnimationCurve curve)
		{
			StringBuilder stringBuilder = new StringBuilder();
			Keyframe[] keys = curve.keys;
			for (int i = 0; i < keys.Length; i++)
			{
				if (i != 0)
				{
					stringBuilder.Append("|");
				}
				Keyframe keyframe = keys[i];
				stringBuilder.AppendFormat(CultureInfo.InvariantCulture, "{0},{1},{2},{3},{4},{5},{6},{7}", keyframe.time, keyframe.value, keyframe.inTangent, keyframe.outTangent, keyframe.inWeight, keyframe.outWeight, (int)keyframe.weightedMode, keyframe.tangentMode);
			}
			element.SetAttributeValue(attributeName, stringBuilder.ToString());
		}

		public static void SetColorAttribute(XElement element, string attributeName, Color color)
		{
			string[] value = new string[4]
			{
				DataIO.ToString(color.r),
				DataIO.ToString(color.g),
				DataIO.ToString(color.b),
				DataIO.ToString(color.a)
			};
			element.SetAttributeValue(attributeName, string.Join(",", value));
		}

		public static void SetGradientAttribute(XElement element, string attributeName, bool includeAlphaKeys, Gradient gradient)
		{
			StringBuilder stringBuilder = new StringBuilder();
			GradientColorKey[] colorKeys = gradient.colorKeys;
			for (int i = 0; i < colorKeys.Length; i++)
			{
				if (i != 0)
				{
					stringBuilder.Append("|");
				}
				GradientColorKey gradientColorKey = colorKeys[i];
				stringBuilder.AppendFormat(CultureInfo.InvariantCulture, "{0},{1},{2},{3}", gradientColorKey.time, gradientColorKey.color.r, gradientColorKey.color.g, gradientColorKey.color.b);
			}
			if (includeAlphaKeys)
			{
				stringBuilder.Append("||");
				GradientAlphaKey[] alphaKeys = gradient.alphaKeys;
				for (int j = 0; j < alphaKeys.Length; j++)
				{
					if (j != 0)
					{
						stringBuilder.Append("|");
					}
					GradientAlphaKey gradientAlphaKey = alphaKeys[j];
					stringBuilder.Append(DataIO.ToString(gradientAlphaKey.time));
					stringBuilder.Append(",");
					stringBuilder.Append(DataIO.ToString(gradientAlphaKey.alpha));
				}
			}
			element.SetAttributeValue(attributeName, stringBuilder.ToString());
		}

		public static void SetIntListAttribute(XElement element, string attributeName, List<int> list)
		{
			string text = string.Empty;
			foreach (int item in list)
			{
				text = text + DataIO.ToString(item) + ",";
			}
			text = text.TrimEnd(',');
			element.SetAttributeValue(attributeName, text);
		}

		public static void SetLayerRecursive(GameObject rootGameObject, int layer)
		{
			rootGameObject.layer = layer;
			foreach (Transform item in rootGameObject.transform)
			{
				SetLayerRecursive(item.gameObject, layer);
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
			if (unitSize <= 0f)
			{
				return value;
			}
			return (float)(long)(value / unitSize + ((value < 0f) ? (-0.5f) : 0.5f)) * unitSize;
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

		public static float TimeToPosition(Vector3 startingPosition, Vector3 targetPosition, float speed)
		{
			return (targetPosition - startingPosition).magnitude / speed;
		}

		public static XElement ToXElement<T>(this object obj)
		{
			return new UnityXmlSerializer(new UnityXmlSerializerContext
			{
				IgnoreUnderscorePrefix = true
			}).Serialize(obj);
		}

		public static string TrimEnd(string s, string trimString)
		{
			if (s.EndsWith(trimString))
			{
				s = s.Substring(0, s.Length - trimString.Length);
			}
			return s;
		}

		public static string Vector2dToString(Vector2d vector2, string numericFormat = null)
		{
			if (numericFormat == null)
			{
				return DataIO.ToString(vector2.x) + "," + DataIO.ToString(vector2.y);
			}
			return DataIO.ToString(vector2.x, numericFormat) + "," + DataIO.ToString(vector2.y, numericFormat);
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

		private static float ConvertMphToKph(float speedInImperialUnits)
		{
			return speedInImperialUnits * 1.609344f;
		}

		private static T ReadStreamingAssetsFile<T>(string path)
		{
			string text = Path.Combine(Application.streamingAssetsPath, path);
			DownloadHandler downloadHandler = null;
			if (Device.IsAndroidBuild)
			{
				UnityWebRequest unityWebRequest = UnityWebRequest.Get(text);
				unityWebRequest.downloadHandler = new DownloadHandlerBuffer();
				UnityWebRequestAsyncOperation unityWebRequestAsyncOperation = unityWebRequest.SendWebRequest();
				while (!unityWebRequestAsyncOperation.isDone)
				{
					Thread.Sleep(10);
				}
				if (unityWebRequest.result == UnityWebRequest.Result.ConnectionError || unityWebRequest.result == UnityWebRequest.Result.ProtocolError || unityWebRequest.result == UnityWebRequest.Result.DataProcessingError)
				{
					throw new Exception("An error occurred reading streaming assets file '" + text + "': " + unityWebRequest.error);
				}
				downloadHandler = unityWebRequest.downloadHandler;
			}
			if (typeof(T) == typeof(string))
			{
				return (T)(object)((downloadHandler == null) ? File.ReadAllText(text) : downloadHandler.text);
			}
			if (typeof(T) == typeof(byte[]))
			{
				return (T)(object)((downloadHandler == null) ? File.ReadAllBytes(text) : downloadHandler.data);
			}
			throw new NotSupportedException();
		}
	}
}
