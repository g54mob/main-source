using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text.RegularExpressions;
using Unity.Collections;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.Jobs;
using UnityEngine.Rendering;

namespace GPUInstancerPro
{
	public static class GPUIUtility
	{
		public static bool HasComponent<T>(this GameObject go) where T : Component
		{
			return go.GetComponent<T>() != null;
		}

		public static bool HasComponentInChildren<T>(this GameObject go) where T : Component
		{
			return go.GetComponentInChildren<T>() != null;
		}

		public static bool HasComponent<T>(this Transform transform) where T : MonoBehaviour
		{
			return transform.GetComponent<T>() != null;
		}

		public static Matrix4x4 GetTransformOffset(this Transform parentTransform, Transform childTransform)
		{
			Matrix4x4 matrix4x = Matrix4x4.identity;
			Transform transform = childTransform;
			while (transform != parentTransform)
			{
				matrix4x = Matrix4x4.TRS(transform.localPosition, transform.localRotation, transform.localScale) * matrix4x;
				transform = transform.parent;
			}
			return matrix4x;
		}

		public static void GetMeshRenderers(this Transform transform, List<Renderer> meshRenderers, bool includeSkinnedMeshRenderers)
		{
			if (meshRenderers == null)
			{
				Debug.LogError("A list must be supplied to call GetMeshRenderers method.");
				return;
			}
			if (transform.TryGetComponent<MeshRenderer>(out var component))
			{
				meshRenderers.Add(component);
			}
			if (includeSkinnedMeshRenderers && transform.TryGetComponent<SkinnedMeshRenderer>(out var component2))
			{
				meshRenderers.Add(component2);
			}
			for (int i = 0; i < transform.childCount; i++)
			{
				Transform child = transform.GetChild(i);
				if (!child.HasComponent<GPUIPrefabBase>())
				{
					child.GetMeshRenderers(meshRenderers, includeSkinnedMeshRenderers);
				}
			}
		}

		public static void SetMatrixToTransform(this Transform transform, Matrix4x4 matrix)
		{
			transform.SetPositionAndRotation(matrix.GetPosition(), matrix.rotation);
			transform.localScale = matrix.lossyScale;
		}

		public static void DestroyGeneric(this UnityEngine.Object uObject)
		{
			if ((bool)uObject)
			{
				if (Application.isPlaying)
				{
					UnityEngine.Object.Destroy(uObject);
				}
				else
				{
					UnityEngine.Object.DestroyImmediate(uObject);
				}
			}
		}

		public static T AddOrGetComponent<T>(this GameObject gameObject) where T : Component
		{
			T val = gameObject.GetComponent<T>();
			if (val == null)
			{
				val = gameObject.AddComponent<T>();
			}
			return val;
		}

		public static T AddOrGetComponent<T>(this Component component) where T : Component
		{
			T val = component.GetComponent<T>();
			if (val == null)
			{
				val = component.gameObject.AddComponent<T>();
			}
			return val;
		}

		public static Bounds GetBounds(this GameObject gameObject, bool isVertexBased = false)
		{
			LODGroup component;
			Renderer[] renderers = ((!gameObject.TryGetComponent<LODGroup>(out component)) ? gameObject.GetComponentsInChildren<Renderer>() : component.GetLODs()[0].renderers);
			return renderers.GetBounds(isVertexBased);
		}

		public static Bounds GetBounds(this Renderer[] renderers, bool isVertexBased = false)
		{
			Bounds result = default(Bounds);
			bool flag = false;
			foreach (Renderer renderer in renderers)
			{
				if (renderer == null)
				{
					continue;
				}
				Mesh mesh = null;
				if (renderer.TryGetComponent<MeshFilter>(out var component))
				{
					mesh = component.sharedMesh;
				}
				else if (renderer is SkinnedMeshRenderer skinnedMeshRenderer)
				{
					mesh = skinnedMeshRenderer.sharedMesh;
				}
				if (!(mesh != null))
				{
					continue;
				}
				if (isVertexBased && mesh.isReadable)
				{
					Vector3[] vertices = mesh.vertices;
					for (int j = 0; j < vertices.Length; j++)
					{
						if (!flag)
						{
							flag = true;
							result = new Bounds(renderer.transform.localToWorldMatrix.MultiplyPoint3x4(vertices[j]), Vector3.zero);
						}
						else
						{
							result.Encapsulate(renderer.transform.localToWorldMatrix.MultiplyPoint3x4(vertices[j]));
						}
					}
				}
				else
				{
					Bounds bounds = renderer.bounds;
					if (!flag)
					{
						flag = true;
						result = new Bounds(bounds.center, bounds.size);
					}
					else
					{
						result.Encapsulate(bounds);
					}
				}
			}
			return result;
		}

		public static void SetLayer(this GameObject gameObject, int layer, bool includeChildren = true)
		{
			gameObject.layer = layer;
			if (includeChildren)
			{
				Transform[] componentsInChildren = gameObject.transform.GetComponentsInChildren<Transform>(includeInactive: true);
				for (int i = 0; i < componentsInChildren.Length; i++)
				{
					componentsInChildren[i].gameObject.layer = layer;
				}
			}
		}

		public static Bounds GetMatrixAppliedBounds(this Bounds bounds, Matrix4x4 matrix)
		{
			bounds.size = Vector3.Scale(bounds.size, matrix.lossyScale);
			bounds = bounds.GetRotationAppliedBounds(matrix.rotation);
			bounds.center += matrix.GetPosition();
			return bounds;
		}

		public static Bounds GetRotationAppliedBounds(this Bounds bounds, Quaternion rotation)
		{
			Vector3 min = bounds.min;
			Vector3 max = bounds.max;
			bounds.size = Vector3.zero;
			bounds.Encapsulate(rotation * new Vector3(min.x, max.y, min.z));
			bounds.Encapsulate(rotation * new Vector3(min.x, max.y, max.z));
			bounds.Encapsulate(rotation * new Vector3(max.x, max.y, max.z));
			bounds.Encapsulate(rotation * new Vector3(max.x, max.y, min.z));
			bounds.Encapsulate(rotation * new Vector3(max.x, min.y, min.z));
			bounds.Encapsulate(rotation * new Vector3(max.x, min.y, max.z));
			bounds.Encapsulate(rotation * new Vector3(min.x, min.y, max.z));
			bounds.Encapsulate(rotation * new Vector3(min.x, min.y, min.z));
			return bounds;
		}

		public static bool EqualOrParentOf(this GameObject parent, GameObject child)
		{
			if (parent == child)
			{
				return true;
			}
			Transform transform = parent.transform;
			Transform parent2 = child.transform.parent;
			while (parent2 != null)
			{
				if (transform == parent2)
				{
					return true;
				}
				parent2 = parent2.transform.parent;
			}
			return false;
		}

		public static GameObject GetPrefabRoot(this GameObject go)
		{
			if (go == null)
			{
				return null;
			}
			return go.transform.GetPrefabRoot().gameObject;
		}

		public static Transform GetPrefabRoot(this Transform transform)
		{
			Transform transform2 = transform;
			while (transform2 != null)
			{
				transform = transform2;
				transform2 = transform.parent;
			}
			return transform;
		}

		public static int GetLODCount(this GameObject gameObject)
		{
			if (gameObject.TryGetComponent<LODGroup>(out var component))
			{
				return component.lodCount;
			}
			return 1;
		}

		public static int GetVertexCount(this Renderer[] renderers)
		{
			int num = 0;
			foreach (Renderer renderer in renderers)
			{
				if (!(renderer == null))
				{
					Mesh mesh = null;
					if (renderer.TryGetComponent<MeshFilter>(out var component))
					{
						mesh = component.sharedMesh;
					}
					else if (renderer is SkinnedMeshRenderer skinnedMeshRenderer)
					{
						mesh = skinnedMeshRenderer.sharedMesh;
					}
					if (mesh != null)
					{
						num += mesh.vertexCount;
					}
				}
			}
			return num;
		}

		public static bool IsRenderersDisabled(this GameObject gameObject)
		{
			Renderer[] componentsInChildren = gameObject.GetComponentsInChildren<Renderer>();
			for (int i = 0; i < componentsInChildren.Length; i++)
			{
				if (componentsInChildren[i].enabled)
				{
					return false;
				}
			}
			return true;
		}

		public static bool HasShader(this GameObject gameObject, string shaderName)
		{
			Renderer[] componentsInChildren = gameObject.GetComponentsInChildren<Renderer>();
			string text = ConvertToGPUIShaderName(shaderName, null);
			Renderer[] array = componentsInChildren;
			for (int i = 0; i < array.Length; i++)
			{
				Material[] sharedMaterials = array[i].sharedMaterials;
				foreach (Material material in sharedMaterials)
				{
					if (material != null && material.shader != null && (material.shader.name == shaderName || material.shader.name == text))
					{
						return true;
					}
				}
			}
			return false;
		}

		public static bool IsShadowCasting(this Renderer renderer)
		{
			return renderer.shadowCastingMode != ShadowCastingMode.Off;
		}

		public static void SetValue(this MaterialPropertyBlock mpb, int nameID, object value)
		{
			if (mpb == null)
			{
				Debug.LogError("Given MaterialPropertyBlock is null! Can not apply override!");
			}
			else if (value == null)
			{
				Debug.LogError("Given value is null! Can not apply override!");
			}
			else if (value is Vector4 value2)
			{
				mpb.SetVector(nameID, value2);
			}
			else if (value is Vector3 vector)
			{
				mpb.SetVector(nameID, vector);
			}
			else if (value is Vector2 vector2)
			{
				mpb.SetVector(nameID, vector2);
			}
			else if (value is float value3)
			{
				mpb.SetFloat(nameID, value3);
			}
			else if (value is int value4)
			{
				mpb.SetInt(nameID, value4);
			}
			else if (value is Color value5)
			{
				mpb.SetColor(nameID, value5);
			}
			else if (value is GraphicsBuffer value6)
			{
				mpb.SetBuffer(nameID, value6);
			}
			else if (value is ComputeBuffer value7)
			{
				mpb.SetBuffer(nameID, value7);
			}
			else if (value is Texture value8)
			{
				mpb.SetTexture(nameID, value8);
			}
			else
			{
				Debug.LogError("Can not set value to MaterialPropertyBlock! Type undefined: " + value.GetType());
			}
		}

		public static string ToDateString(this DateTime dateTime)
		{
			return dateTime.ToString("MM/dd/yyyy HH:mm:ss.fff", CultureInfo.InvariantCulture);
		}

		public static bool TryParseDateTime(this string dateTimeString, out DateTime result)
		{
			return DateTime.TryParseExact(dateTimeString, "MM/dd/yyyy HH:mm:ss.fff", CultureInfo.InvariantCulture, DateTimeStyles.None, out result);
		}

		public static Vector3 Round(this Vector3 vector3, int decimals)
		{
			vector3.x = (float)Math.Round(vector3.x, decimals);
			vector3.y = (float)Math.Round(vector3.y, decimals);
			vector3.z = (float)Math.Round(vector3.z, decimals);
			return vector3;
		}

		public static int GenerateHash(params int[] numbers)
		{
			int num = 23;
			for (int i = 0; i < numbers.Length; i++)
			{
				num = num * 31 + numbers[i];
			}
			return num;
		}

		public static void SetPosition(this ref Matrix4x4 matrix, Vector3 position)
		{
			matrix.m03 = position.x;
			matrix.m13 = position.y;
			matrix.m23 = position.z;
		}

		public static void MousePointsToPlanes(Camera cam, Vector2 p1, Vector2 p2, float farPlane, Plane[] planes)
		{
			Vector3 position = cam.transform.position;
			Vector2 vector = Vector2.Min(p1, p2);
			Vector2 vector2 = Vector2.Max(p1, p2);
			vector.y = (float)cam.pixelHeight - vector.y;
			vector2.y = (float)cam.pixelHeight - vector2.y;
			Ray ray = cam.ScreenPointToRay(vector);
			Ray ray2 = cam.ScreenPointToRay(new Vector2(vector.x, vector2.y));
			Ray ray3 = cam.ScreenPointToRay(new Vector2(vector2.x, vector.y));
			Ray ray4 = cam.ScreenPointToRay(vector2);
			planes[0].Set3Points(position, ray.origin + ray.direction, ray2.origin + ray2.direction);
			planes[1].Set3Points(position, ray4.origin + ray4.direction, ray3.origin + ray3.direction);
			planes[2].Set3Points(position, ray2.origin + ray2.direction, ray4.origin + ray4.direction);
			planes[3].Set3Points(position, ray3.origin + ray3.direction, ray.origin + ray.direction);
			planes[4].Set3Points(ray4.origin - ray4.direction + position, ray3.origin - ray3.direction + position, ray.origin - ray.direction + position);
			planes[5].Set3Points(ray2.origin + ray2.direction * farPlane, ray.origin + ray.direction * farPlane, ray4.origin + ray4.direction * farPlane);
		}

		public static bool TestPlanesAABBComplete(Plane[] planes, Bounds bounds)
		{
			Vector3 min = bounds.min;
			Vector3 max = bounds.max;
			for (int i = 0; i < planes.Length; i++)
			{
				Plane plane = planes[i];
				if (!plane.GetSide(min) || !plane.GetSide(max))
				{
					return false;
				}
			}
			return true;
		}

		public static string FormatNumberWithSuffix(this long num)
		{
			if (num >= 1000000)
			{
				return ((double)num / 1000000.0).ToString("0.0M");
			}
			if (num >= 10000)
			{
				return ((double)num / 1000.0).ToString("0.0k");
			}
			return num.ToString("#,0");
		}

		public static string FormatNumberWithSuffix(this int num)
		{
			if (num >= 1000000)
			{
				return ((double)num / 1000000.0).ToString("0.0M");
			}
			if (num >= 10000)
			{
				return ((double)num / 1000.0).ToString("0.0k");
			}
			return num.ToString("#,0");
		}

		public static string FormatNumberWithSuffix(this uint num)
		{
			if (num >= 1000000)
			{
				return ((double)num / 1000000.0).ToString("0.0M");
			}
			if (num >= 10000)
			{
				return ((double)num / 1000.0).ToString("0.0k");
			}
			return num.ToString("#,0");
		}

		public static bool Approximately(this Color color, Color other, bool includeAlpha = false, float errorMargin = 0.002f)
		{
			if (math.abs(color.r - other.r) < errorMargin && math.abs(color.g - other.g) < errorMargin && math.abs(color.b - other.b) < errorMargin)
			{
				if (includeAlpha)
				{
					return math.abs(color.a - other.a) < errorMargin;
				}
				return true;
			}
			return false;
		}

		public static bool Approximately(this Quaternion rotation, Quaternion other, float errorMargin = 0.002f)
		{
			return 1f - Mathf.Abs(Quaternion.Dot(rotation, other)) < errorMargin;
		}

		public static bool Approximately(this Vector3 position, Vector3 other, float errorMargin = 0.002f)
		{
			return Vector3.Distance(position, other) < errorMargin;
		}

		public static string CamelToTitleCase(string camelCaseText)
		{
			string text = "";
			while (camelCaseText.StartsWith("_"))
			{
				camelCaseText = camelCaseText.Substring(1);
			}
			if (camelCaseText.StartsWith("gpui"))
			{
				text += "GPUI ";
				camelCaseText = camelCaseText.Substring(4);
			}
			camelCaseText = camelCaseText.Substring(0, 1).ToUpper() + camelCaseText.Substring(1);
			return text += Regex.Replace(Regex.Replace(camelCaseText, "([A-Z])([a-z])", " $1$2"), "([a-z])([A-Z])", "$1 $2").Trim();
		}

		public static bool CompareExtensionCode(string c1, string c2)
		{
			if (string.IsNullOrEmpty(c1) && string.IsNullOrEmpty(c2))
			{
				return true;
			}
			return string.Equals(c1, c2);
		}

		public static string ConvertToGPUIShaderName(string originalShaderName, string extensionCode, string shaderNamePrefix = null)
		{
			string shaderNamePrefix2 = GPUIConstants.GetShaderNamePrefix(extensionCode);
			if (string.IsNullOrEmpty(shaderNamePrefix))
			{
				shaderNamePrefix = shaderNamePrefix2;
			}
			bool num = originalShaderName.StartsWith("Hidden/");
			if (num)
			{
				originalShaderName = originalShaderName.Substring(7);
			}
			if (originalShaderName.StartsWith(shaderNamePrefix2))
			{
				originalShaderName = originalShaderName.Substring(shaderNamePrefix2.Length, originalShaderName.Length - shaderNamePrefix2.Length);
			}
			string text = shaderNamePrefix + originalShaderName;
			if (num)
			{
				text = "Hidden/" + text;
			}
			return text;
		}

		public static string RemoveSpacesAndLimitSize(this string input, int maxSize)
		{
			string text = input.Replace(" ", "");
			if (text.Length > maxSize)
			{
				text = text.Substring(0, maxSize);
			}
			return text;
		}

		public static string Matrix4x4ToString(Matrix4x4 matrix4x4)
		{
			return Regex.Replace(matrix4x4.ToString(), "[\\r\\n\\t]+", ";");
		}

		public static bool TryParseMatrix4x4(string matrixStr, out Matrix4x4 matrix4x4)
		{
			matrix4x4 = default(Matrix4x4);
			if (string.IsNullOrEmpty(matrixStr))
			{
				return false;
			}
			string[] array = matrixStr.Split(';');
			if (array.Length < 16)
			{
				return false;
			}
			for (int i = 0; i < 16; i++)
			{
				if (float.TryParse(array[i], NumberStyles.Float, CultureInfo.InvariantCulture, out var result))
				{
					matrix4x4[i / 4, i % 4] = result;
					continue;
				}
				return false;
			}
			return true;
		}

		public static Matrix4x4 Matrix4x4FromString(string matrixStr)
		{
			Matrix4x4 result = default(Matrix4x4);
			string[] array = matrixStr.Split(';');
			for (int i = 0; i < 16; i++)
			{
				result[i / 4, i % 4] = float.Parse(array[i], CultureInfo.InvariantCulture);
			}
			return result;
		}

		public static string ReadTextFileAtPath(string filePath)
		{
			string result = null;
			if (File.Exists(filePath))
			{
				using StreamReader streamReader = new StreamReader(filePath);
				result = streamReader.ReadToEnd();
			}
			return result;
		}

		public static string GetRelativePathForShader(string shaderPathString, string includeFilePathString)
		{
			if (string.IsNullOrEmpty(shaderPathString) || string.IsNullOrEmpty(includeFilePathString))
			{
				return string.Empty;
			}
			if (shaderPathString.StartsWith("Packages/"))
			{
				shaderPathString = GPUIConstants.GetGeneratedShaderPath();
			}
			string text = Path.GetRelativePath(Path.GetDirectoryName(shaderPathString), includeFilePathString).Replace("\\", "/");
			if (!text.StartsWith("."))
			{
				text = "./" + text;
			}
			return text;
		}

		public static void SetData(this GraphicsBuffer targetBuffer, GraphicsBuffer sourceBuffer, int sourceStartIndex, int targetStartIndex, int count)
		{
			if (sourceBuffer != null && targetBuffer != null && count > 0 && targetBuffer.count >= targetStartIndex + count && sourceBuffer.count >= sourceStartIndex + count)
			{
				ComputeShader cS_GraphicsBufferUtility = GPUIConstants.CS_GraphicsBufferUtility;
				cS_GraphicsBufferUtility.SetBuffer(0, GPUIConstants.PROP_sourceBuffer, sourceBuffer);
				cS_GraphicsBufferUtility.SetBuffer(0, GPUIConstants.PROP_targetBuffer, targetBuffer);
				cS_GraphicsBufferUtility.SetInt(GPUIConstants.PROP_sourceStartIndex, sourceStartIndex);
				cS_GraphicsBufferUtility.SetInt(GPUIConstants.PROP_targetStartIndex, targetStartIndex);
				cS_GraphicsBufferUtility.SetInt(GPUIConstants.PROP_count, count);
				cS_GraphicsBufferUtility.DispatchX(0, count);
			}
		}

		public static void SetAllDataTo(this GraphicsBuffer buffer, Matrix4x4 value)
		{
			ComputeShader cS_TransformModifications = GPUIConstants.CS_TransformModifications;
			cS_TransformModifications.SetBuffer(8, GPUIConstants.PROP_gpuiTransformBuffer, buffer);
			cS_TransformModifications.SetInt(GPUIConstants.PROP_bufferSize, buffer.count);
			cS_TransformModifications.SetMatrix(GPUIConstants.PROP_matrix44, value);
			cS_TransformModifications.DispatchX(8, buffer.count);
		}

		public static T[] RemoveAtAndReturn<T>(this T[] array, int toRemove)
		{
			if (array == null || toRemove >= array.Length)
			{
				return array;
			}
			T[] array2 = new T[array.Length - 1];
			if (toRemove > 0)
			{
				Array.Copy(array, 0, array2, 0, toRemove);
			}
			if (toRemove < array.Length - 1)
			{
				Array.Copy(array, toRemove + 1, array2, toRemove, array.Length - toRemove - 1);
			}
			return array2;
		}

		public static T[] AddAndReturn<T>(this T[] array, T toAdd)
		{
			T[] array2 = new T[array.Length + 1];
			Array.Copy(array, 0, array2, 0, array.Length);
			array2[array.Length] = toAdd;
			return array2;
		}

		public static T[] MirrorAndFlatten<T>(this T[,] array2D)
		{
			T[] array = new T[array2D.GetLength(0) * array2D.GetLength(1)];
			for (int i = 0; i < array2D.GetLength(0); i++)
			{
				for (int j = 0; j < array2D.GetLength(1); j++)
				{
					array[j + i * array2D.GetLength(0)] = array2D[i, j];
				}
			}
			return array;
		}

		public static bool Contains<T>(this T[] array, T element)
		{
			if (array == null)
			{
				return false;
			}
			for (int i = 0; i < array.Length; i++)
			{
				if (array[i] == null)
				{
					if (element == null)
					{
						return true;
					}
					return false;
				}
				if (array[i].Equals(element))
				{
					return true;
				}
			}
			return false;
		}

		public static void ResizeNativeArray<T>(this ref NativeArray<T> array, int newSize, Allocator allocator) where T : struct
		{
			NativeArray<T> array2 = array;
			array = new NativeArray<T>(newSize, allocator);
			if (array2.IsCreated)
			{
				int length = Math.Min(array2.Length, newSize);
				NativeSlice<T> nativeSlice = new NativeSlice<T>(array, 0, length);
				NativeSlice<T> slice = new NativeSlice<T>(array2, 0, length);
				nativeSlice.CopyFrom(slice);
				array2.Dispose();
			}
		}

		public static void ResizeTransformAccessArray(this ref TransformAccessArray array, int newSize)
		{
			TransformAccessArray transformAccessArray = array;
			TransformAccessArray.Allocate(newSize, -1, out array);
			Transform[] array2 = new Transform[newSize];
			if (transformAccessArray.isCreated)
			{
				int num = Math.Min(transformAccessArray.length, newSize);
				for (int i = 0; i < num; i++)
				{
					array2[i] = transformAccessArray[i];
				}
				transformAccessArray.Dispose();
			}
			array.SetTransforms(array2);
		}

		public static void GizmoDrawWireMesh(GPUIPrototype prototype, Matrix4x4 matrix, bool drawBounds = true)
		{
			if (GPUIRenderingSystem.IsActive && GPUIRenderingSystem.Instance.LODGroupDataProvider.TryGetData(prototype.GetKey(), out var result))
			{
				GizmoDrawWireMesh(result, matrix, drawBounds);
			}
			else if (prototype.prototypeType == GPUIPrototypeType.Prefab)
			{
				GameObject prefabObject = prototype.prefabObject;
				if (drawBounds)
				{
					GizmoDrawWireMesh(prefabObject.GetBounds(), matrix);
					return;
				}
				if (prefabObject.TryGetComponent<LODGroup>(out var component))
				{
					LOD[] lODs = component.GetLODs();
					if (lODs.Length == 0)
					{
						return;
					}
					Renderer[] renderers = lODs[0].renderers;
					for (int i = 0; i < renderers.Length; i++)
					{
						if (renderers[i].TryGetComponent<MeshFilter>(out var component2))
						{
							matrix *= component2.transform.localToWorldMatrix * prefabObject.transform.localToWorldMatrix.inverse;
							for (int j = 0; j < component2.sharedMesh.subMeshCount; j++)
							{
								Gizmos.DrawWireMesh(component2.sharedMesh, j, matrix.GetPosition(), matrix.rotation, matrix.lossyScale);
							}
						}
					}
					return;
				}
				MeshFilter[] componentsInChildren = prefabObject.GetComponentsInChildren<MeshFilter>();
				foreach (MeshFilter meshFilter in componentsInChildren)
				{
					matrix *= meshFilter.transform.localToWorldMatrix * prefabObject.transform.localToWorldMatrix.inverse;
					for (int k = 0; k < meshFilter.sharedMesh.subMeshCount; k++)
					{
						Gizmos.DrawWireMesh(meshFilter.sharedMesh, k, matrix.GetPosition(), matrix.rotation, matrix.lossyScale);
					}
				}
			}
			else if (prototype.prototypeType == GPUIPrototypeType.LODGroupData)
			{
				GizmoDrawWireMesh(prototype.gpuiLODGroupData, matrix, drawBounds);
			}
		}

		public static void GizmoDrawWireMesh(GPUILODGroupData lodGroupData, Matrix4x4 matrix, bool drawBounds = true)
		{
			if (drawBounds)
			{
				GizmoDrawWireMesh(lodGroupData.bounds, matrix);
				return;
			}
			GPUILODData gPUILODData = lodGroupData[0];
			for (int i = 0; i < gPUILODData.Length; i++)
			{
				GPUIRendererData gPUIRendererData = gPUILODData[i];
				Matrix4x4 matrix4x = matrix * gPUIRendererData.transformOffset;
				for (int j = 0; j < gPUIRendererData.rendererMesh.subMeshCount; j++)
				{
					Gizmos.DrawWireMesh(gPUIRendererData.rendererMesh, j, matrix4x.GetPosition(), matrix4x.rotation, matrix4x.lossyScale);
				}
			}
		}

		public static void GizmoDrawWireMesh(Bounds bounds, Matrix4x4 matrix)
		{
			Gizmos.matrix = matrix;
			Gizmos.DrawWireCube(bounds.center, bounds.size);
		}

		public static bool IsInLayer(int layerMask, int layer)
		{
			return layerMask == (layerMask | (1 << layer));
		}

		public static void SetBuffer<T>(this ComputeShader cs, int kernelIndex, int nameID, GPUIDataBuffer<T> gpuiDataBuffer) where T : struct
		{
			cs.SetBuffer(kernelIndex, nameID, gpuiDataBuffer.Buffer);
		}

		public static void DispatchX(this ComputeShader cs, int kernelIndex, int size)
		{
			if (GPUIConstants.CS_THREAD_COUNT == 0f)
			{
				GPUIRuntimeSettings.Instance.DetermineOperationMode();
			}
			cs.Dispatch(kernelIndex, Mathf.CeilToInt((float)size / GPUIConstants.CS_THREAD_COUNT), 1, 1);
		}

		public static void DispatchXHeavy(this ComputeShader cs, int kernelIndex, int size)
		{
			if (GPUIConstants.CS_THREAD_COUNT_HEAVY == 0f)
			{
				GPUIRuntimeSettings.Instance.DetermineOperationMode();
			}
			cs.Dispatch(kernelIndex, Mathf.CeilToInt((float)size / GPUIConstants.CS_THREAD_COUNT_HEAVY), 1, 1);
		}

		public static void DispatchXY(this ComputeShader cs, int kernelIndex, int sizeX, int sizeY)
		{
			if (GPUIConstants.CS_THREAD_COUNT == 0f)
			{
				GPUIRuntimeSettings.Instance.DetermineOperationMode();
			}
			cs.Dispatch(kernelIndex, Mathf.CeilToInt((float)sizeX / GPUIConstants.CS_THREAD_COUNT_2D), Mathf.CeilToInt((float)sizeY / GPUIConstants.CS_THREAD_COUNT_2D), 1);
		}

		public static void DispatchXZ(this ComputeShader cs, int kernelIndex, int sizeX, int sizeZ)
		{
			if (GPUIConstants.CS_THREAD_COUNT == 0f)
			{
				GPUIRuntimeSettings.Instance.DetermineOperationMode();
			}
			cs.Dispatch(kernelIndex, Mathf.CeilToInt((float)sizeX / GPUIConstants.CS_THREAD_COUNT_2D), 1, Mathf.CeilToInt((float)sizeZ / GPUIConstants.CS_THREAD_COUNT_2D));
		}

		public static void DispatchXYZ(this ComputeShader cs, int kernelIndex, int sizeX, int sizeY, int sizeZ)
		{
			if (GPUIConstants.CS_THREAD_COUNT == 0f)
			{
				GPUIRuntimeSettings.Instance.DetermineOperationMode();
			}
			cs.Dispatch(kernelIndex, Mathf.CeilToInt((float)sizeX / GPUIConstants.CS_THREAD_COUNT_3D), Mathf.CeilToInt((float)sizeY / GPUIConstants.CS_THREAD_COUNT_3D), Mathf.CeilToInt((float)sizeZ / GPUIConstants.CS_THREAD_COUNT_3D));
		}

		public static string[] GetPropertyNames(this Shader shader, List<ShaderPropertyType> ignoreTypes = null)
		{
			int propertyCount = shader.GetPropertyCount();
			List<string> list = new List<string>();
			for (int i = 0; i < propertyCount; i++)
			{
				if (ignoreTypes == null || !ignoreTypes.Contains(shader.GetPropertyType(i)))
				{
					list.Add(shader.GetPropertyName(i));
				}
			}
			return list.ToArray();
		}

		public static string[] GetPropertyNamesForType(this Shader shader, ShaderPropertyType propertyType)
		{
			int propertyCount = shader.GetPropertyCount();
			List<string> list = new List<string>();
			for (int i = 0; i < propertyCount; i++)
			{
				if (shader.GetPropertyType(i) == propertyType)
				{
					list.Add(shader.GetPropertyName(i));
				}
			}
			return list.ToArray();
		}

		public static Material CopyWithShader(this Material originalMaterial, Shader instancedShader)
		{
			Material material = new Material(instancedShader);
			material.CopyPropertiesFromMaterial(originalMaterial);
			string text = originalMaterial.name;
			if (!text.EndsWith(GPUIShaderBindings.GPUI_REPLACEMENT_MATERIAL_NAME_SUFFIX))
			{
				text += GPUIShaderBindings.GPUI_REPLACEMENT_MATERIAL_NAME_SUFFIX;
			}
			material.name = text;
			material.hideFlags = HideFlags.HideAndDontSave;
			return material;
		}

		public static void RenderMeshIndirect(in RenderParams rparams, Mesh mesh, GPUIDataBuffer<GraphicsBuffer.IndirectDrawIndexedArgs> commandBuffer, int commandCount = 1, int startCommand = 0)
		{
			Graphics.RenderMeshIndirect(in rparams, mesh, commandBuffer.Buffer, commandCount, startCommand);
		}

		public static bool IsDepthTextureAvailable(this Camera camera)
		{
			if (!camera.depthTextureMode.HasFlag(DepthTextureMode.Depth))
			{
				return camera.actualRenderingPath == RenderingPath.DeferredShading;
			}
			return true;
		}

		public static Mesh GenerateQuadMesh(float width, float height, Rect? uvRect = null, bool centerPivotAtBottom = false, float pivotOffsetX = 0f, float pivotOffsetY = 0f, bool setVertexColors = false)
		{
			Mesh mesh = new Mesh();
			mesh.name = "QuadMesh";
			mesh.vertices = new Vector3[4]
			{
				new Vector3(centerPivotAtBottom ? ((0f - width) / 2f - pivotOffsetX) : (0f - pivotOffsetX), 0f - pivotOffsetY, 0f),
				new Vector3(centerPivotAtBottom ? ((0f - width) / 2f - pivotOffsetX) : (0f - pivotOffsetX), height - pivotOffsetY, 0f),
				new Vector3(centerPivotAtBottom ? (width / 2f - pivotOffsetX) : (width - pivotOffsetX), height - pivotOffsetY, 0f),
				new Vector3(centerPivotAtBottom ? (width / 2f - pivotOffsetX) : (width - pivotOffsetX), 0f - pivotOffsetY, 0f)
			};
			if (uvRect.HasValue)
			{
				mesh.uv = new Vector2[4]
				{
					new Vector2(uvRect.Value.x, uvRect.Value.y),
					new Vector2(uvRect.Value.x, uvRect.Value.y + uvRect.Value.height),
					new Vector2(uvRect.Value.x + uvRect.Value.width, uvRect.Value.y + uvRect.Value.height),
					new Vector2(uvRect.Value.x + uvRect.Value.width, uvRect.Value.y)
				};
			}
			else
			{
				mesh.uv = new Vector2[4]
				{
					new Vector2(0f, 0f),
					new Vector2(0f, 1f),
					new Vector2(1f, 1f),
					new Vector2(1f, 0f)
				};
			}
			mesh.triangles = new int[6] { 0, 1, 3, 1, 2, 3 };
			Vector3 vector = new Vector3(0f, 0f, -1f);
			Vector4 vector2 = new Vector4(1f, 0f, 0f, -1f);
			mesh.normals = new Vector3[4] { vector, vector, vector, vector };
			mesh.tangents = new Vector4[4] { vector2, vector2, vector2, vector2 };
			if (setVertexColors)
			{
				Color[] array = new Color[mesh.vertices.Length];
				for (int i = 0; i < mesh.vertices.Length; i++)
				{
					array[i] = Color.Lerp(Color.clear, Color.white, mesh.vertices[i].y);
				}
				mesh.colors = array;
			}
			return mesh;
		}

		public static Shader FindShader(string shaderName)
		{
			Shader shader = Shader.Find(shaderName);
			if (GPUIRuntimeSettings.Instance.loadShadersFromAddressables && shader == null)
			{
				try
				{
					shader = Addressables.LoadAssetAsync<Shader>(shaderName).WaitForCompletion();
				}
				catch (Exception exception)
				{
					Debug.LogException(exception);
				}
			}
			return shader;
		}

		public static T LoadResource<T>(string path) where T : UnityEngine.Object
		{
			T val = Resources.Load<T>(path);
			if (GPUIRuntimeSettings.Instance.loadResourcesFromAddressables && val == null)
			{
				try
				{
					val = Addressables.LoadAssetAsync<T>(path).WaitForCompletion();
				}
				catch (Exception exception)
				{
					Debug.LogException(exception);
				}
			}
			return val;
		}
	}
}
