using System;
using UnityEngine;
using VampireSurvivors.Objects.Pickups;

namespace VampireSurvivors.Framework
{
	public struct PickupToSpawn
	{
		public Vector2 position;

		public float value;

		public Action<Pickup> callback;
	}
}
