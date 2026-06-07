using System;
using UnityEngine;

namespace GameCreator.Runtime.Characters
{
	public readonly struct ShieldOutput
	{
		public static readonly ShieldOutput NO_BLOCK = new ShieldOutput(isBlocked: false, Vector3.zero, 0f, BlockType.None);

		[field: NonSerialized]
		public bool IsBlocked { get; }

		[field: NonSerialized]
		public Vector3 Point { get; }

		[field: NonSerialized]
		public float ElapsedTime { get; }

		[field: NonSerialized]
		public BlockType Type { get; }

		public ShieldOutput(bool isBlocked, Vector3 point, float elapsedTime, BlockType type)
		{
			IsBlocked = isBlocked;
			Point = point;
			ElapsedTime = elapsedTime;
			Type = type;
		}
	}
}
