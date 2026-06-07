using System;
using UnityEngine;

namespace GameCreator.Runtime.Characters
{
	public readonly struct ReactionInput
	{
		[field: NonSerialized]
		public Vector3 Direction { get; }

		[field: NonSerialized]
		public float Power { get; }

		public ReactionInput(Vector3 direction, float power)
		{
			Direction = direction;
			Power = power;
		}
	}
}
