using UnityEngine;

namespace Assets.Scripts.Flight.Missions
{
	public interface IReferenceFrame
	{
		Vector3 LocalToWorld(Vector3 position);

		Vector3 WorldToLocal(Vector3 position);
	}
}
