using UnityEngine;

public class Require
{
	public static T Component<T>(Component target) where T : Component
	{
		return null;
	}

	public static T Component<T>(GameObject target) where T : Component
	{
		return null;
	}

	public static T ComponentInChildren<T>(Component target, bool childrenOnly = false, bool optional = false) where T : Component
	{
		return null;
	}

	public static T ComponentInChildren<T>(GameObject target, bool childrenOnly = false, bool optional = false) where T : Component
	{
		return null;
	}

	public static T[] ComponentsInChildren<T>(GameObject target, bool childrenOnly = false, bool optional = false) where T : Component
	{
		return null;
	}

	public static T[] ComponentsInChildren<T>(GameObject target, bool includeInactive = false) where T : Component
	{
		return null;
	}

	public static T[] ComponentsInChildren<T>(Component target, bool includeInactive = false) where T : Component
	{
		return null;
	}

	public static T[] ComponentsInChildren<T>(Component target, int depth, bool includeInactive = false) where T : Component
	{
		return null;
	}

	private static T[] RecurseGetComponentInChildren<T>(Transform target, int depth, int currentDepth) where T : Component
	{
		return null;
	}

	public static T ComponentInParent<T>(Component target) where T : Component
	{
		return null;
	}

	public static T ComponentInParent<T>(GameObject target) where T : Component
	{
		return null;
	}

	public static T[] ComponentsInParent<T>(Component target, bool includeInactive = false) where T : Component
	{
		return null;
	}

	public static T[] ComponentsInParent<T>(GameObject target, bool includeInactive = false) where T : Component
	{
		return null;
	}

	public static Transform ChildWithTag(string tag, Component target, bool optional = false)
	{
		return null;
	}

	public static Transform ChildWithTagDeep(string tag, Component target, bool optional = false, bool includeInactive = false)
	{
		return null;
	}

	public static Transform[] ChildrenWithTagDeep(string tag, Component target, bool includeInactive = false)
	{
		return null;
	}

	public static GameObject UniqueGameObjectWithTag(string tag)
	{
		return null;
	}

	public static GameObject UniqueGameObjectWithScript<T>()
	{
		return null;
	}

	public static T UniqueScript<T>()
	{
		return default(T);
	}

	public static Collider2D ColliderInLayer(string layer, Component target)
	{
		return null;
	}

	public static Collider2D ColliderInLayer(string layer, GameObject target)
	{
		return null;
	}
}
