using Unity.Entities;
using UnityEngine;

namespace Kitchen
{
	public struct CMoveToLocation : IComponentData
	{
		public Vector3 Location;

		public Vector3 DesiredFacing;

		public float StoppingDistance;

		public Entity Chair;

		public static implicit operator Vector3(CMoveToLocation x)
		{
			return x.Location;
		}
	}
}
