using FluffyUnderware.Curvy.Controllers;
using JetBrains.Annotations;
using UnityEngine;

namespace FluffyUnderware.Curvy.Examples
{
	[ExecuteAlways]
	public class E13_TrainCarDrifter : MonoBehaviour
	{
		public float speed;

		public float wheelSpacing;

		public Vector3 bodyOffset;

		public SplineController controllerWheelLeading;

		public SplineController controllerWheelTrailing;

		public Transform trainCar;

		[UsedImplicitly]
		private void Start()
		{
		}

		[UsedImplicitly]
		private void Update()
		{
		}
	}
}
