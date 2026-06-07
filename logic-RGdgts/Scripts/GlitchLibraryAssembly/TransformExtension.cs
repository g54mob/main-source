using UnityEngine;

public static class TransformExtension
{
	public static Transform FindChildDeep(this Transform parent, string childName, bool includeDisabled = true)
	{
		return null;
	}

	private static Transform FindChildRecursive(this Transform parent, string childName, bool includeDisabled)
	{
		return null;
	}

	public static void Clear(this Transform parent)
	{
	}

	public static void ResetLocal(this Transform parent)
	{
	}

	public static void LookAt2D(this Transform parent, Vector3 target, Vector3 axis, float step = 1f)
	{
	}

	public static Quaternion LookAt2DLerp(this Transform parent, Vector3 target, Vector3 axis, float step = 1f)
	{
		return default(Quaternion);
	}

	public static void LookAt2D(this Transform parent, Vector3 target)
	{
	}

	public static FakeTransform ToFakeTransform(this Transform parent, Space space)
	{
		return default(FakeTransform);
	}

	public static FakeTransform FromFakeTransform(this Transform parent, FakeTransform fakeTransform, Space space)
	{
		return default(FakeTransform);
	}

	public static FakeTransform ToFakeTransform(this Transform parent, bool local = false)
	{
		return default(FakeTransform);
	}

	public static FakeTransform FromFakeTransform(this Transform parent, FakeTransform fakeTransform, bool local = false)
	{
		return default(FakeTransform);
	}

	public static void CopyLocalFrom(this Transform parent, Transform source)
	{
	}
}
