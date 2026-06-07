using System.Collections.Generic;
using UnityEngine;

namespace RLD
{
	public class SphereTreeNode<T>
	{
		private Sphere _sphere;

		private T _data;

		private SphereTreeNode<T> _parent;

		private List<SphereTreeNode<T>> _children = new List<SphereTreeNode<T>>();

		private BVHNodeFlags _flags;

		public List<SphereTreeNode<T>> Children => new List<SphereTreeNode<T>>(_children);

		public Sphere Sphere
		{
			get
			{
				return _sphere;
			}
			set
			{
				_sphere = value;
			}
		}

		public Vector3 Center
		{
			get
			{
				return _sphere.Center;
			}
			set
			{
				_sphere.Center = value;
			}
		}

		public float Radius
		{
			get
			{
				return _sphere.Radius;
			}
			set
			{
				_sphere.Radius = value;
			}
		}

		public SphereTreeNode<T> Parent => _parent;

		public int NumChildren => _children.Count;

		public T Data
		{
			get
			{
				return _data;
			}
			set
			{
				_data = value;
			}
		}

		public SphereTreeNode()
		{
			_sphere = new Sphere(Vector3.zero, 1f);
			_data = default(T);
		}

		public SphereTreeNode(T data, Sphere sphere)
		{
			_sphere = sphere;
			_data = data;
		}

		public void SetFlags(BVHNodeFlags flags)
		{
			_flags = flags;
		}

		public bool IsFlagBitSet(BVHNodeFlags bit)
		{
			return (_flags & bit) != 0;
		}

		public void SetFlagsBits(BVHNodeFlags bits)
		{
			_flags |= bits;
		}

		public void ClearFlagsBits(BVHNodeFlags bits)
		{
			_flags &= ~bits;
		}

		public bool IsOutsideParent()
		{
			if (_parent == null)
			{
				return false;
			}
			if ((Center - _parent.Center).magnitude + Radius > _parent.Radius)
			{
				return true;
			}
			return false;
		}

		public SphereTreeNode<T> ClosestChild(SphereTreeNode<T> node)
		{
			if (NumChildren == 0)
			{
				return null;
			}
			int count = _children.Count;
			float num = float.MaxValue;
			SphereTreeNode<T> result = null;
			for (int i = 0; i < count; i++)
			{
				SphereTreeNode<T> sphereTreeNode = _children[i];
				float sqrMagnitude = (node.Center - sphereTreeNode.Center).sqrMagnitude;
				if (sqrMagnitude < num)
				{
					num = sqrMagnitude;
					result = sphereTreeNode;
				}
			}
			return result;
		}

		public void SetParent(SphereTreeNode<T> newParent)
		{
			if (newParent != this && newParent != _parent)
			{
				if (_parent != null)
				{
					_parent._children.Remove(this);
					_parent = null;
				}
				if (newParent != null)
				{
					_parent = newParent;
					_parent._children.Add(this);
				}
				else
				{
					_parent = null;
				}
			}
		}

		public void EncapsulateChildrenBottomUp()
		{
			if (NumChildren == 0)
			{
				return;
			}
			for (SphereTreeNode<T> sphereTreeNode = this; sphereTreeNode != null; sphereTreeNode = sphereTreeNode.Parent)
			{
				Vector3 zero = Vector3.zero;
				foreach (SphereTreeNode<T> child in sphereTreeNode._children)
				{
					zero += child.Center;
				}
				sphereTreeNode.Center = zero * (1f / (float)sphereTreeNode.NumChildren);
				float num = float.MinValue;
				foreach (SphereTreeNode<T> child2 in sphereTreeNode._children)
				{
					float num2 = (child2.Center - sphereTreeNode._sphere.Center).magnitude + child2.Radius;
					if (num2 > num)
					{
						num = num2;
					}
				}
				sphereTreeNode.Radius = num;
			}
		}

		public void DebugDraw()
		{
			Matrix4x4 matrix = Matrix4x4.TRS(_sphere.Center, Quaternion.identity, Vector3Ex.FromValue(_sphere.Radius));
			Graphics.DrawMeshNow(Singleton<MeshPool>.Get.UnitSphere, matrix);
			foreach (SphereTreeNode<T> child in _children)
			{
				child.DebugDraw();
			}
		}
	}
}
