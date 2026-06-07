using UnityEngine;

namespace Assets.Scripts.Flight.Missions
{
	public class ReferenceFrame : IReferenceFrame
	{
		public Vector3 LocalToWorld(Vector3 position)
		{
			return position + GameWorld.Instance.FloatingOriginOffset;
		}

		public Vector3 WorldToLocal(Vector3 position)
		{
			return position - GameWorld.Instance.FloatingOriginOffset;
		}
	}
}
