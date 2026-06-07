using System.Collections.Generic;
using UnityEngine;

namespace AwesomeTechnologies.Utility.Quadtree
{
	public class QuadTreeNode<T> where T : IHasRect
	{
		private Rect _rect;

		private readonly List<T> _contentList = new List<T>();

		private readonly List<QuadTreeNode<T>> _nodes = new List<QuadTreeNode<T>>(4);

		public bool IsEmpty
		{
			get
			{
				if (_rect.width != 0f && _rect.height != 0f)
				{
					return _nodes.Count == 0;
				}
				return true;
			}
		}

		public Rect Rect => _rect;

		public int Count
		{
			get
			{
				int num = 0;
				foreach (QuadTreeNode<T> node in _nodes)
				{
					num += node.Count;
				}
				return num + _contentList.Count;
			}
		}

		public QuadTreeNode(Rect rect)
		{
			_rect = rect;
		}

		public void SubTreeContents(List<T> results)
		{
			for (int i = 0; i <= _nodes.Count - 1; i++)
			{
				_nodes[i].SubTreeContents(results);
			}
			for (int j = 0; j <= _contentList.Count - 1; j++)
			{
				results.Add(_contentList[j]);
			}
		}

		public void Query(Rect queryArea, List<T> results)
		{
			foreach (T content in _contentList)
			{
				if (queryArea.Overlaps(content.Rectangle))
				{
					results.Add(content);
				}
			}
			foreach (QuadTreeNode<T> node in _nodes)
			{
				if (!node.IsEmpty)
				{
					if (node.Rect.Contains(queryArea))
					{
						node.Query(queryArea, results);
						break;
					}
					if (queryArea.Contains(node.Rect))
					{
						node.SubTreeContents(results);
					}
					else if (node.Rect.Overlaps(queryArea))
					{
						node.Query(queryArea, results);
					}
				}
			}
		}

		public void Insert(T item)
		{
			if (!_rect.Contains(item.Rectangle))
			{
				return;
			}
			if (_nodes.Count == 0)
			{
				CreateSubNodes();
			}
			foreach (QuadTreeNode<T> node in _nodes)
			{
				if (node.Rect.Contains(item.Rectangle))
				{
					node.Insert(item);
					return;
				}
			}
			_contentList.Add(item);
		}

		public void Move(Vector2 offset)
		{
			foreach (QuadTreeNode<T> node in _nodes)
			{
				node.Move(offset);
			}
			_rect = new Rect(_rect.xMin + offset.x, _rect.yMin + offset.y, _rect.width, _rect.height);
		}

		private void CreateSubNodes()
		{
			if (!(_rect.height * _rect.width <= 10f))
			{
				float num = _rect.width / 2f;
				float num2 = _rect.height / 2f;
				_nodes.Add(new QuadTreeNode<T>(new Rect(new Vector2(_rect.xMin, _rect.yMin), new Vector2(num, num2))));
				_nodes.Add(new QuadTreeNode<T>(new Rect(new Vector2(_rect.xMin, _rect.yMin + num2), new Vector2(num, num2))));
				_nodes.Add(new QuadTreeNode<T>(new Rect(new Vector2(_rect.xMin + num, _rect.yMin), new Vector2(num, num2))));
				_nodes.Add(new QuadTreeNode<T>(new Rect(new Vector2(_rect.xMin + num, _rect.yMin + num2), new Vector2(num, num2))));
			}
		}
	}
}
