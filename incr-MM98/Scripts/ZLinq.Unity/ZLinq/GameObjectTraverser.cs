using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.Pool;
using UnityEngine.SceneManagement;

namespace ZLinq
{
	[StructLayout(LayoutKind.Auto)]
	public struct GameObjectTraverser : ITraverser<GameObjectTraverser, GameObject>, IDisposable
	{
		private static readonly object CalledTryGetNextChild = new object();

		private static readonly object ParentNotFound = new object();

		private readonly GameObject gameObject;

		private readonly Transform transform;

		private object? initializedState;

		private int childCount;

		private int index;

		public GameObject Origin => gameObject;

		public GameObjectTraverser(GameObject origin)
		{
			gameObject = origin;
			transform = gameObject.transform;
			initializedState = null;
			childCount = 0;
			index = 0;
		}

		public GameObjectTraverser ConvertToTraverser(GameObject next)
		{
			return new GameObjectTraverser(next);
		}

		public bool TryGetParent(out GameObject parent)
		{
			Transform parent2 = transform.parent;
			if (parent2 != null)
			{
				parent = parent2.gameObject;
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

		public bool TryGetNextChild(out GameObject child)
		{
			if (initializedState == null)
			{
				initializedState = CalledTryGetNextChild;
				childCount = transform.childCount;
			}
			if (index < childCount)
			{
				child = transform.GetChild(index++).gameObject;
				return true;
			}
			child = null;
			return false;
		}

		public bool TryGetNextSibling(out GameObject next)
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
					next = transform.GetChild(index++).gameObject;
					return true;
				}
			}
			else if (initializedState is Scene scene2 && index < childCount)
			{
				List<GameObject> list = CollectionPool<List<GameObject>, GameObject>.Get();
				scene2.GetRootGameObjects(list);
				next = list[index++];
				CollectionPool<List<GameObject>, GameObject>.Release(list);
				return true;
			}
			next = null;
			return false;
		}

		public bool TryGetPreviousSibling(out GameObject previous)
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
					previous = transform.GetChild(index++).gameObject;
					return true;
				}
			}
			else if (initializedState is Scene scene2 && index < childCount)
			{
				List<GameObject> list = CollectionPool<List<GameObject>, GameObject>.Get();
				scene2.GetRootGameObjects(list);
				previous = list[index++];
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
