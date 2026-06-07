using System;
using UnityEngine;

namespace GameCreator.Runtime.Characters
{
	internal class BoneSnapshot
	{
		[field: NonSerialized]
		public Transform Value { get; }

		[field: NonSerialized]
		public Vector3 LocalPosition { get; }

		[field: NonSerialized]
		public Vector3 WorldPosition { get; }

		[field: NonSerialized]
		public Quaternion LocalRotation { get; }

		[field: NonSerialized]
		public Quaternion WorldRotation { get; }

		public BoneSnapshot(Transform reference)
		{
			Value = reference;
			WorldPosition = Value.position;
			LocalPosition = Value.localPosition;
			WorldRotation = Value.rotation;
			LocalRotation = Value.localRotation;
		}
	}
}
