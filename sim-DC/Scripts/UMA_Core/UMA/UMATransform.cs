using System;
using System.Collections.Generic;
using UnityEngine;

namespace UMA
{
	[Serializable]
	public class UMATransform
	{
		public class UMATransformComparer : IComparer<UMATransform>
		{
			public int Compare(UMATransform x, UMATransform y)
			{
				return 0;
			}
		}

		public Vector3 position;

		public Quaternion rotation;

		public Vector3 scale;

		public string name;

		public int hash;

		public int parent;

		public static UMATransformComparer TransformComparer;

		public UMATransform()
		{
		}

		public UMATransform(Transform transform, int nameHash, int parentHash)
		{
		}

		public UMATransform Duplicate()
		{
			return null;
		}

		public void Assign(UMATransform other)
		{
		}
	}
}
