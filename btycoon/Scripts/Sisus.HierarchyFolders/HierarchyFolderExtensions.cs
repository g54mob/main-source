using System.Collections.Generic;
using JetBrains.Annotations;
using Sisus.HierarchyFolders;
using UnityEngine;

public static class HierarchyFolderExtensions
{
	private static readonly Stack<Transform> ReusableParentsStack = new Stack<Transform>(10);

	private static readonly List<Transform> ReusableTransformList = new List<Transform>(20);

	private static readonly List<GameObject> ReusableGameObjectList = new List<GameObject>(20);

	public static bool IsHierarchyFolder([NotNull] this GameObject gameObject)
	{
		HierarchyFolder component;
		return gameObject.TryGetComponent<HierarchyFolder>(out component);
	}

	[CanBeNull]
	public static Transform GetParent([NotNull] this Transform transform)
	{
		return transform.parent;
	}

	[CanBeNull]
	public static Transform GetParent([NotNull] this Transform transform, bool skipHierarchyFolders)
	{
		Transform parent = transform.parent;
		if (skipHierarchyFolders && parent != null && parent.gameObject.IsHierarchyFolder())
		{
			return parent.GetParent(skipHierarchyFolders: true);
		}
		return parent;
	}

	[CanBeNull]
	public static GameObject GetParent([NotNull] this GameObject gameObject)
	{
		Transform parent = gameObject.transform.parent;
		if (!(parent != null))
		{
			return null;
		}
		return parent.gameObject;
	}

	[CanBeNull]
	public static GameObject GetParent([NotNull] this GameObject gameObject, bool skipHierarchyFolders)
	{
		Transform parent = gameObject.transform.parent;
		if (parent == null)
		{
			return null;
		}
		GameObject gameObject2 = parent.gameObject;
		if (skipHierarchyFolders && gameObject2.IsHierarchyFolder())
		{
			return gameObject2.GetParent(skipHierarchyFolders: true);
		}
		return gameObject2;
	}

	[NotNull]
	public static GameObject GetRoot([NotNull] this GameObject gameObject)
	{
		return gameObject.transform.root.gameObject;
	}

	[CanBeNull]
	public static GameObject GetRoot([NotNull] this GameObject gameObject, bool skipHierarchyFolders)
	{
		Transform transform = gameObject.transform;
		if (!skipHierarchyFolders)
		{
			Transform root = transform.root;
			if (!(root != null))
			{
				return null;
			}
			return root.gameObject;
		}
		GetParents(transform, ReusableParentsStack);
		for (int num = ReusableParentsStack.Count - 1; num >= 0; num--)
		{
			GameObject gameObject2 = ReusableParentsStack.Pop().gameObject;
			if (!gameObject2.IsHierarchyFolder())
			{
				ReusableParentsStack.Clear();
				return gameObject2;
			}
		}
		ReusableParentsStack.Clear();
		return null;
	}

	[NotNull]
	public static Transform GetRoot([NotNull] this Transform transform)
	{
		return transform.root;
	}

	[CanBeNull]
	public static Transform GetRoot([NotNull] this Transform transform, bool skipHierarchyFolders)
	{
		if (!skipHierarchyFolders)
		{
			return transform.root;
		}
		GetParents(transform, ReusableParentsStack);
		for (int num = ReusableParentsStack.Count - 1; num >= 0; num--)
		{
			Transform transform2 = ReusableParentsStack.Pop();
			if (!transform2.gameObject.IsHierarchyFolder())
			{
				ReusableParentsStack.Clear();
				return transform2;
			}
		}
		ReusableParentsStack.Clear();
		return null;
	}

	public static void SetParent([NotNull] this Transform child, [CanBeNull] Transform parent, bool worldPositionStays, bool skipHierarchyFolders)
	{
		child.transform.SetParent(parent, worldPositionStays);
	}

	public static void UndoableSetParent([NotNull] this Transform child, [CanBeNull] Transform parent, string undoName, bool skipHierarchyFolders = false)
	{
		child.transform.SetParent(parent, worldPositionStays: true);
	}

	[CanBeNull]
	public static Transform GetFirstChild([NotNull] this Transform transform, bool skipHierarchyFolders)
	{
		if (transform.childCount != 0)
		{
			return transform.GetChild(0);
		}
		return null;
	}

	[NotNull]
	public static Transform[] GetChildren([NotNull] this Transform transform, bool skipHierarchyFolders)
	{
		transform.GetChildren(ReusableTransformList, skipHierarchyFolders);
		Transform[] result = ReusableTransformList.ToArray();
		ReusableTransformList.Clear();
		return result;
	}

	public static void GetChildren([NotNull] this Transform transform, [NotNull] List<Transform> list, bool skipHierarchyFolders)
	{
		int i = 0;
		for (int childCount = transform.childCount; i < childCount; i++)
		{
			list.Add(transform.GetChild(i));
		}
	}

	[NotNull]
	public static GameObject[] GetChildren([NotNull] this GameObject gameObject, bool skipHierarchyFolders)
	{
		gameObject.GetChildren(ReusableGameObjectList, skipHierarchyFolders);
		GameObject[] result = ReusableGameObjectList.ToArray();
		ReusableGameObjectList.Clear();
		return result;
	}

	[CanBeNull]
	public static void GetChildren([NotNull] this GameObject gameObject, [NotNull] List<GameObject> list, bool skipHierarchyFolders)
	{
		Transform transform = gameObject.transform;
		int i = 0;
		for (int childCount = transform.childCount; i < childCount; i++)
		{
			list.Add(transform.GetChild(i).gameObject);
		}
	}

	private static void GetParents([NotNull] Transform transform, [NotNull] Stack<Transform> parentStack)
	{
		Transform parent = transform.parent;
		while (parent != null)
		{
			parentStack.Push(parent);
			parent = parent.parent;
		}
	}
}
