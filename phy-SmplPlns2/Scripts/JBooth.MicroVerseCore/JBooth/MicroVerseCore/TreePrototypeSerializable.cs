using System;
using UnityEngine;

namespace JBooth.MicroVerseCore
{
	[Serializable]
	public class TreePrototypeSerializable
	{
		public float bendFactor;

		public int navMeshLod;

		public GameObject prefab;

		public TreePrototypeSerializable()
		{
		}

		public TreePrototypeSerializable(TreePrototype p)
		{
			bendFactor = p.bendFactor;
			navMeshLod = p.navMeshLod;
			prefab = p.prefab;
		}

		public TreePrototype GetPrototype()
		{
			return new TreePrototype
			{
				prefab = prefab,
				navMeshLod = navMeshLod,
				bendFactor = bendFactor
			};
		}

		public static bool operator ==(TreePrototypeSerializable obj1, TreePrototypeSerializable obj2)
		{
			if ((object)obj1 == obj2)
			{
				return true;
			}
			if ((object)obj1 == null)
			{
				return false;
			}
			if ((object)obj2 == null)
			{
				return false;
			}
			return obj1.Equals(obj2);
		}

		public static bool operator !=(TreePrototypeSerializable obj1, TreePrototypeSerializable obj2)
		{
			return !(obj1 == obj2);
		}

		public override bool Equals(object obj)
		{
			return Equals(obj as TreePrototypeSerializable);
		}

		public bool IsEqualToTree(TreePrototype tree)
		{
			if (tree.prefab == prefab && tree.navMeshLod == navMeshLod)
			{
				return tree.bendFactor == bendFactor;
			}
			return false;
		}

		public override int GetHashCode()
		{
			return HashCode.Combine(prefab, navMeshLod, bendFactor);
		}

		public bool Equals(TreePrototypeSerializable x)
		{
			if (x.prefab == prefab && x.navMeshLod == navMeshLod)
			{
				return x.bendFactor == bendFactor;
			}
			return false;
		}
	}
}
