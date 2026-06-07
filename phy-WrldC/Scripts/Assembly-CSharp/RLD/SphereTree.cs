using System.Collections.Generic;
using UnityEngine;

namespace RLD
{
	public class SphereTree<T>
	{
		private SphereTreeNode<T> _root;

		private int _numChildrenPerNode = 2;

		public SphereTree(int numChildrenPerNode)
		{
			_numChildrenPerNode = numChildrenPerNode;
			if (_numChildrenPerNode < 2)
			{
				_numChildrenPerNode = 2;
			}
			_root = new SphereTreeNode<T>(default(T), new Sphere(Vector3.zero, 1f));
			_root.SetFlagsBits(BVHNodeFlags.Root);
		}

		public void DebugDraw()
		{
			Material gizmoSolidHandle = Singleton<MaterialPool>.Get.GizmoSolidHandle;
			gizmoSolidHandle.SetInt("_IsLit", 0);
			gizmoSolidHandle.SetColor(Color.green.KeepAllButAlpha(0.3f));
			gizmoSolidHandle.SetPass(0);
			_root.DebugDraw();
		}

		public SphereTreeNode<T> AddNode(T nodeData, Sphere sphere)
		{
			SphereTreeNode<T> sphereTreeNode = new SphereTreeNode<T>(nodeData, sphere);
			IntegrateNodeRecurse(sphereTreeNode, _root);
			return sphereTreeNode;
		}

		public void RemoveNode(SphereTreeNode<T> node)
		{
			if (!node.IsFlagBitSet(BVHNodeFlags.Root))
			{
				SphereTreeNode<T> sphereTreeNode = node.Parent;
				node.SetParent(null);
				while (sphereTreeNode != null && sphereTreeNode.NumChildren == 0 && !sphereTreeNode.IsFlagBitSet(BVHNodeFlags.Root))
				{
					SphereTreeNode<T> parent = sphereTreeNode.Parent;
					sphereTreeNode.SetParent(null);
					sphereTreeNode = parent;
				}
				sphereTreeNode.EncapsulateChildrenBottomUp();
			}
		}

		public void OnNodeSphereUpdated(SphereTreeNode<T> node)
		{
			if (node.IsFlagBitSet(BVHNodeFlags.Terminal) && node.IsOutsideParent())
			{
				SphereTreeNode<T> parent = node.Parent;
				node.SetParent(null);
				if (parent.NumChildren == 0)
				{
					RemoveNode(parent);
				}
				else
				{
					parent.EncapsulateChildrenBottomUp();
				}
				IntegrateNodeRecurse(node, _root);
			}
		}

		public List<SphereTreeNodeRayHit<T>> RaycastAll(Ray ray)
		{
			List<SphereTreeNodeRayHit<T>> list = new List<SphereTreeNodeRayHit<T>>(10);
			RaycastAllRecurse(ray, _root, list);
			return list;
		}

		public List<SphereTreeNode<T>> OverlapBox(OBB box)
		{
			List<SphereTreeNode<T>> list = new List<SphereTreeNode<T>>(20);
			OverlapBoxRecurse(box, _root, list);
			return list;
		}

		private void IntegrateNodeRecurse(SphereTreeNode<T> node, SphereTreeNode<T> parent)
		{
			if (!parent.IsFlagBitSet(BVHNodeFlags.Terminal))
			{
				if (parent.NumChildren < _numChildrenPerNode)
				{
					node.SetFlagsBits(BVHNodeFlags.Terminal);
					node.SetParent(parent);
					parent.EncapsulateChildrenBottomUp();
					return;
				}
				SphereTreeNode<T> sphereTreeNode = parent.ClosestChild(node);
				if (sphereTreeNode != null)
				{
					IntegrateNodeRecurse(node, sphereTreeNode);
				}
			}
			else
			{
				SphereTreeNode<T> sphereTreeNode2 = new SphereTreeNode<T>(default(T), parent.Sphere);
				sphereTreeNode2.SetParent(parent.Parent);
				parent.SetParent(sphereTreeNode2);
				node.SetParent(sphereTreeNode2);
				node.SetFlagsBits(BVHNodeFlags.Terminal);
				sphereTreeNode2.EncapsulateChildrenBottomUp();
			}
		}

		private void RaycastAllRecurse(Ray ray, SphereTreeNode<T> node, List<SphereTreeNodeRayHit<T>> hitList)
		{
			if (!node.IsFlagBitSet(BVHNodeFlags.Terminal))
			{
				if (!SphereMath.Raycast(ray, node.Center, node.Radius))
				{
					return;
				}
				{
					foreach (SphereTreeNode<T> child in node.Children)
					{
						RaycastAllRecurse(ray, child, hitList);
					}
					return;
				}
			}
			if (SphereMath.Raycast(ray, out var t, node.Center, node.Radius))
			{
				SphereTreeNodeRayHit<T> item = new SphereTreeNodeRayHit<T>(ray, node, t);
				hitList.Add(item);
			}
		}

		private void OverlapBoxRecurse(OBB box, SphereTreeNode<T> node, List<SphereTreeNode<T>> overlappedNodes)
		{
			if (!box.IntersectsSphere(node.Sphere))
			{
				return;
			}
			if (node.IsFlagBitSet(BVHNodeFlags.Terminal))
			{
				overlappedNodes.Add(node);
				return;
			}
			foreach (SphereTreeNode<T> child in node.Children)
			{
				OverlapBoxRecurse(box, child, overlappedNodes);
			}
		}
	}
}
