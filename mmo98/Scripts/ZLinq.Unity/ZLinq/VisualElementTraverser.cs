using System;
using System.Runtime.InteropServices;
using UnityEngine.UIElements;

namespace ZLinq
{
	[StructLayout(LayoutKind.Auto)]
	public struct VisualElementTraverser : ITraverser<VisualElementTraverser, VisualElement>, IDisposable
	{
		private static readonly object CalledTryGetNextChild = new object();

		private static readonly object ParentNotFound = new object();

		private readonly VisualElement visualElement;

		private object? initializedState;

		private int childCount;

		private int index;

		public VisualElement Origin => visualElement;

		public VisualElementTraverser(VisualElement origin)
		{
			visualElement = origin;
			initializedState = null;
			childCount = 0;
			index = 0;
		}

		public VisualElementTraverser ConvertToTraverser(VisualElement next)
		{
			return new VisualElementTraverser(next);
		}

		public bool TryGetParent(out VisualElement parent)
		{
			VisualElement parent2 = visualElement.parent;
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
			count = visualElement.childCount;
			return true;
		}

		public bool TryGetHasChild(out bool hasChild)
		{
			hasChild = visualElement.childCount != 0;
			return true;
		}

		public bool TryGetNextChild(out VisualElement child)
		{
			if (initializedState == null)
			{
				initializedState = CalledTryGetNextChild;
				childCount = visualElement.childCount;
			}
			if (index < childCount)
			{
				child = visualElement[index++];
				return true;
			}
			child = null;
			return false;
		}

		public bool TryGetNextSibling(out VisualElement next)
		{
			if (initializedState == null)
			{
				VisualElement parent = this.visualElement.parent;
				if (parent == null)
				{
					initializedState = ParentNotFound;
					next = null;
					return false;
				}
				initializedState = parent;
				childCount = parent.childCount;
				index = parent.IndexOf(this.visualElement) + 1;
			}
			else if (initializedState == ParentNotFound)
			{
				next = null;
				return false;
			}
			VisualElement visualElement = (VisualElement)initializedState;
			if (index < childCount)
			{
				next = visualElement[index++];
				return true;
			}
			next = null;
			return false;
		}

		public bool TryGetPreviousSibling(out VisualElement previous)
		{
			if (initializedState == null)
			{
				VisualElement parent = this.visualElement.parent;
				if (parent == null)
				{
					initializedState = ParentNotFound;
					previous = null;
					return false;
				}
				initializedState = parent;
				childCount = parent.IndexOf(this.visualElement);
				index = 0;
			}
			else if (initializedState == ParentNotFound)
			{
				previous = null;
				return false;
			}
			VisualElement visualElement = (VisualElement)initializedState;
			if (index < childCount)
			{
				previous = visualElement[index++];
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
