using System;
using UnityEngine;

namespace NSMedieval
{
	[Serializable]
	public struct BoneTransformPair
	{
		public BoneType boneType;

		public Transform boneTransform;
	}
}
