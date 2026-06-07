using Assets.Nimbatus.Scripts.WorldObjects.Items.DroneParts;
using UnityEngine;

namespace Assets.Nimbatus.Scripts.GalaxyMap.Race.Tracker
{
	public class TrackerData
	{
		public DronePart Sensor;

		public float PositionAlongSpline;

		public float TargetPositionAlongSpline;

		public Vector3 TargetPosition;

		public GameObject Visualizer;
	}
}
