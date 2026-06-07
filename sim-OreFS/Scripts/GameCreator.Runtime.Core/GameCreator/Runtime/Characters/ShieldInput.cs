using System;
using UnityEngine;

namespace GameCreator.Runtime.Characters
{
	public readonly struct ShieldInput
	{
		[field: NonSerialized]
		public Vector3 Direction { get; }

		[field: NonSerialized]
		public Vector3 Point { get; }

		[field: NonSerialized]
		public float Power { get; }

		public ShieldInput(Vector3 direction, Vector3 point, float power)
		{
			Direction = direction;
			Point = point;
			Power = power;
		}
	}
}
