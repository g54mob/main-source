using System.Collections.Generic;
using UnityEngine;

namespace AwesomeTechnologies.Utility.Quadtree
{
	public class QuadTree<T> where T : IHasRect
	{
		private readonly QuadTreeNode<T> _root;

		private Rect _rect;

		public int Count => _root.Count;

		public QuadTree(Rect rect)
		{
			_rect = rect;
			_root = new QuadTreeNode<T>(_rect);
		}

		public void Insert(T item)
		{
			_root.Insert(item);
		}

		public void Move(Vector2 offset)
		{
			_rect = new Rect(_rect.xMin + offset.x, _rect.yMin + offset.y, _rect.width, _rect.height);
			_root.Move(offset);
		}

		public void Query(Rect area, List<T> results)
		{
			_root.Query(area, results);
		}
	}
}
