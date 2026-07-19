using System.Collections.Generic;
using UnityEngine;

namespace UniHumanoid
{
	public class BvhBone : IBone
	{
		private List<IBone> _children = new List<IBone>();

		public string Name { get; private set; }

		public Vector3 SkeletonLocalPosition { get; private set; }

		public IBone Parent { get; private set; }

		public IList<IBone> Children => _children;

		public BvhBone(string name, Vector3 position)
		{
			Name = name;
			SkeletonLocalPosition = position;
		}

		public override string ToString()
		{
			return $"<BvhBone: {Name}>";
		}

		public void Build(Transform t)
		{
			foreach (Transform item in t)
			{
				BvhBone bvhBone = new BvhBone(item.name, SkeletonLocalPosition + item.localPosition);
				bvhBone.Parent = this;
				_children.Add(bvhBone);
				bvhBone.Build(item);
			}
		}

		public void Build(BvhNode node)
		{
			foreach (BvhNode child in node.Children)
			{
				BvhBone bvhBone = new BvhBone(child.Name, SkeletonLocalPosition + child.Offset.ToXReversedVector3());
				bvhBone.Parent = this;
				_children.Add(bvhBone);
				bvhBone.Build(child);
			}
		}

		public IEnumerable<BvhBone> Traverse()
		{
			yield return this;
			foreach (IBone child in Children)
			{
				foreach (IBone item in child.Traverse())
				{
					yield return (BvhBone)item;
				}
			}
		}
	}
}
