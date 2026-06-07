using System;
using System.Collections.Generic;
using Gh;
using Gh.Tk;
using TMPro;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public static class ExtensionMethods
{
	private static readonly int[] IgnoredLayers;

	private const string INDENT_STRING = "    ";

	public static T PickRandomByPercentageWeighting<T>(this T[] arr, Func<T, float> weightInPercentageSelector)
	{
		return default(T);
	}

	public static T PickRandom<T>(this T[] arr)
	{
		return default(T);
	}

	public static T PickRandom<T>(this IEnumerable<T> enumerable, Func<T, bool> predicate)
	{
		return default(T);
	}

	public static T PickRandom<T>(this IEnumerable<T> enumerable)
	{
		return default(T);
	}

	public static T PickRandom<T>(this IEnumerable<T> enumerable, IRng customRng)
	{
		return default(T);
	}

	public static T PickRandom<T>(this IEnumerable<T> enumerable, Func<T, float> weightFunc)
	{
		return default(T);
	}

	public static IEnumerable<T> Shuffle<T>(this IEnumerable<T> enumerable, Func<T, float> weightFunc = null)
	{
		return null;
	}

	public static void InsertAtRandomPosition<T>(this List<T> list, T item)
	{
	}

	public static IEnumerable<T> GetPercentageOfItemsAtRandom<T>(this IEnumerable<T> enumerable, int percentage)
	{
		return null;
	}

	public static IEnumerable<T> ExcludeDeadObjects<T>(this IEnumerable<T> list) where T : UnityEngine.Object
	{
		return null;
	}

	public static T GetOrAddComponent<T>(this Component co) where T : Component
	{
		return null;
	}

	public static T GetOrAddComponent<T>(this GameObject go) where T : Component
	{
		return null;
	}

	public static void DestroyComponentsInChildren<T>(this GameObject obj) where T : Component
	{
	}

	public static void DestroyImmediateComponentsInChildren<T>(this GameObject obj) where T : Component
	{
	}

	public static void SetLayerRecursivly(this GameObject go, int layer)
	{
	}

	public static Bounds GetObjectBounds(this GameObject go, LayerMask? layersToIgnore = null)
	{
		return default(Bounds);
	}

	public static bool IsAlive(this UnityEngine.Object obj)
	{
		return false;
	}

	public static bool IsTrueNull(this UnityEngine.Object obj)
	{
		return false;
	}

	public static Transform GetChildOrDefault(this Transform t, int index)
	{
		return null;
	}

	public static bool IsAnimating(this Animator animator, int layer = 0)
	{
		return false;
	}

	public static bool IsInState(this Animator animator, string state, int layer = 0)
	{
		return false;
	}

	public static bool HasArrivedAtDestination(this NavMeshAgent agent)
	{
		return false;
	}

	public static float GetXZDistanceTo(this Vector3 a, Vector3 b)
	{
		return 0f;
	}

	public static void AssertComponentIsSet(this MonoBehaviour monoBehavior, object component, Type componentType)
	{
	}

	public static void SetMaxParticles(this GameObject obj, int maxParticles)
	{
	}

	public static string[] GetValuesFromToken(this AnimatorControllerParameter parameter, string token)
	{
		return null;
	}

	public static string[] GetValuesFromToken(this string parameterName, string token)
	{
		return null;
	}

	public static void ResetLocalValues(this Transform transform)
	{
	}

	public static void AppendAfter(this Transform us, Transform objToAppend)
	{
	}

	public static string GetPath(this Transform transform)
	{
		return null;
	}

	public static void ScrollToTop(this ScrollRect scrollRect)
	{
	}

	public static void ScrollToBottom(this ScrollRect scrollRect)
	{
	}

	public static void DetachAndDestroy(this GameObject obj)
	{
	}

	public static int GetRoundedHashCode(this Vector3 vec, int precision = 1000)
	{
		return 0;
	}

	public static int GetRoundedHashCode(this Quaternion q, int precision = 1000)
	{
		return 0;
	}

	public static float CalculateDistanceFromBounds(this Bounds bounds, Vector3 decorPosition)
	{
		return 0f;
	}

	public static Color AdjustColor(this Color color, float hue, float saturation, float brightness)
	{
		return default(Color);
	}

	private static float CycleFloat(float max, float current)
	{
		return 0f;
	}

	public static string JsonPrettify(this string jsonString)
	{
		return null;
	}

	public static float3 Invert(this float3 f)
	{
		return default(float3);
	}

	public static float3 GetScale(this float4x4 matrix)
	{
		return default(float3);
	}

	public static float4x4 ScaleBy(this float4x4 matrix, float3 scale)
	{
		return default(float4x4);
	}

	public static quaternion GetRotationWithoutScale(this GameObject go)
	{
		return default(quaternion);
	}

	public static quaternion GetRotationWithoutScaleLocal(this GameObject go)
	{
		return default(quaternion);
	}

	public static int GetLayerForWorld(int world)
	{
		return 0;
	}

	public static int GetLayerMaskForWorld(int world)
	{
		return 0;
	}

	public static EntityObject GetEntityObject(this GameObject gameObject)
	{
		return null;
	}

	public static EntityObject GetParent(this EntityObject entityObject)
	{
		return null;
	}

	public static GameObjectX GetParentGox(this GameObject go)
	{
		return null;
	}

	public static int GetParentGoxId(this GameObject go)
	{
		return 0;
	}

	public static TMP_TextInfo GetTextInfo(this TMP_Text text)
	{
		return null;
	}

	public static Material[] GetFontSharedMaterials(this TMP_Text text)
	{
		return null;
	}

	public static void AddIfNotPresent<T>(this IList<T> list, T item) where T : ICloneable
	{
	}

	public static string HumanizeSafely(this DateTime date, bool? utcDate = null)
	{
		return null;
	}

	public static string HumanizeSafely(this string date)
	{
		return null;
	}

	public static string HumanizeSafely(this Enum input)
	{
		return null;
	}

	public static bool EndsWith(this int value, string endValue)
	{
		return false;
	}

	public static bool DoesPutIntoStorageJobExist(this GameItem item)
	{
		return false;
	}
}
