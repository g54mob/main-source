using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.Pool;
using UnityEngine.SceneManagement;

namespace ZLinq
{
	[StructLayout(LayoutKind.Auto)]
	public struct TransformTraverser : ITraverser<TransformTraverser, Transform>, IDisposable
	{
		private static readonly object CalledTryGetNextChild = new object();

		private static readonly object ParentNotFound = new object();

		private readonly Transform transform;

		private object? initializedState;

		private int childCount;

		private int index;

		public Transform Origin => transform;

		public TransformTraverser(Transform origin)
		{
			transform = origin;
			initializedState = null;
			childCount = 0;
			index = 0;
		}

		public TransformTraverser ConvertToTraverser(Transform next)
		{
			return new TransformTraverser(next);
		}

		public bool TryGetParent(out Transform parent)
		{
			Transform parent2 = transform.parent;
			if (parent2 != null)
			{
				parent = parent2;
				return true;
			}
			parent = null;
			return false;
		}

		public bool TryGetChildCount(out int count)
		{
			count = transform.childCount;
			return true;
		}

		public bool TryGetHasChild(out bool hasChild)
		{
			hasChild = transform.childCount != 0;
			return true;
		}

		public bool TryGetNextChild(out Transform child)
		{
			if (initializedState == null)
			{
				initializedState = CalledTryGetNextChild;
				childCount = transform.childCount;
			}
			if (index < childCount)
			{
				child = transform.GetChild(index++);
				return true;
			}
			child = null;
			return false;
		}

		public bool TryGetNextSibling(out Transform next)
		{
			if (initializedState == null)
			{
				Transform parent = this.transform.parent;
				if (parent == null)
				{
					Scene scene = this.transform.gameObject.scene;
					if (!scene.IsValid())
					{
						initializedState = ParentNotFound;
						next = null;
						return false;
					}
					initializedState = scene;
					childCount = scene.rootCount;
					index = this.transform.GetSiblingIndex() + 1;
				}
				else
				{
					initializedState = parent;
					childCount = parent.childCount;
					index = this.transform.GetSiblingIndex() + 1;
				}
			}
			else if (initializedState == ParentNotFound)
			{
				next = null;
				return false;
			}
			if (initializedState is Transform transform)
			{
				if (index < childCount)
				{
					next = transform.GetChild(index++);
					return true;
				}
			}
			else if (initializedState is Scene scene2 && index < childCount)
			{
				List<GameObject> list = CollectionPool<List<GameObject>, GameObject>.Get();
				scene2.GetRootGameObjects(list);
				next = list[index++].transform;
				CollectionPool<List<GameObject>, GameObject>.Release(list);
				return true;
			}
			next = null;
			return false;
		}

		public bool TryGetPreviousSibling(out Transform previous)
		{
			if (initializedState == null)
			{
				Transform parent = this.transform.parent;
				if (parent == null)
				{
					Scene scene = this.transform.gameObject.scene;
					if (!scene.IsValid())
					{
						initializedState = ParentNotFound;
						previous = null;
						return false;
					}
					initializedState = scene;
					childCount = this.transform.GetSiblingIndex();
					index = 0;
				}
				else
				{
					initializedState = parent;
					childCount = this.transform.GetSiblingIndex();
					index = 0;
				}
			}
			else if (initializedState == ParentNotFound)
			{
				previous = null;
				return false;
			}
			if (initializedState is Transform transform)
			{
				if (index < childCount)
				{
					previous = transform.GetChild(index++);
					return true;
				}
			}
			else if (initializedState is Scene scene2 && index < childCount)
			{
				List<GameObject> list = CollectionPool<List<GameObject>, GameObject>.Get();
				scene2.GetRootGameObjects(list);
				previous = list[index++].transform;
				CollectionPool<List<GameObject>, GameObject>.Release(list);
				return true;
			}
			previous = null;
			return false;
		}

		public void Dispose()
		{
		}
	}
}
