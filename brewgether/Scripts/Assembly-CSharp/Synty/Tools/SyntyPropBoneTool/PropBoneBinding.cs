using System;
using UnityEngine;

namespace Synty.Tools.SyntyPropBoneTool
{
	[Serializable]
	public class PropBoneBinding
	{
		public Transform bone;

		public Transform socket;

		public Vector3 rotationOffset;

		public float scale;

		public bool IsValid => false;

		public bool IsMatch(PropBoneDefinition other)
		{
			return false;
		}
	}
}
