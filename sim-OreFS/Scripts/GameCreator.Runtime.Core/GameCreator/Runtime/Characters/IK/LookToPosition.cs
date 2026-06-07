using System;
using UnityEngine;

namespace GameCreator.Runtime.Characters.IK
{
	public readonly struct LookToPosition : ILookTo
	{
		[field: NonSerialized]
		public int Layer { get; }

		public bool Exists => true;

		[field: NonSerialized]
		public Vector3 Position { get; }

		public GameObject Target => null;

		public LookToPosition(int layer, Vector3 position)
		{
			Layer = layer;
			Position = position;
		}
	}
}
