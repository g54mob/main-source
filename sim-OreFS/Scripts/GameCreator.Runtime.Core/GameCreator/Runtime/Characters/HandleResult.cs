using System;
using UnityEngine;

namespace GameCreator.Runtime.Characters
{
	public struct HandleResult
	{
		public static readonly HandleResult None = new HandleResult(default(Bone), Vector3.zero, Quaternion.identity);

		[field: NonSerialized]
		public Bone Bone { get; }

		[field: NonSerialized]
		public Vector3 LocalPosition { get; }

		[field: NonSerialized]
		public Quaternion LocalRotation { get; }

		public HandleResult(Bone bone, Vector3 position, Quaternion rotation)
		{
			Bone = bone;
			LocalPosition = position;
			LocalRotation = rotation;
		}
	}
}
