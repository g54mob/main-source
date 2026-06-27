using System;
using UnityEngine;

namespace DistantLands.Cozy.Data
{
	[Serializable]
	[CreateAssetMenu(menuName = "Distant Lands/Cozy/Satellite Profile", order = 361)]
	public class SatelliteProfile : ScriptableObject
	{
		public GameObject satelliteReference;

		public Transform orbitRef;

		public Transform moonRef;

		public Light lightRef;

		public float size = 1f;

		[Range(0f, 1f)]
		public float distance = 1f;

		public bool autoScaleByDistance = true;

		public float orbitOffset;

		public Vector3 initialRotation;

		public float satelliteRotateSpeed;

		public bool linkToDay;

		public int rotationPeriod = 28;

		public int rotationPeriodOffset;

		public Vector3 satelliteRotateAxis;

		public float satelliteDirection;

		public float satelliteRotation;

		public float satellitePitch;

		public float declination;

		public int declinationPeriod;

		public bool changedLastFrame;

		public bool open;
	}
}
