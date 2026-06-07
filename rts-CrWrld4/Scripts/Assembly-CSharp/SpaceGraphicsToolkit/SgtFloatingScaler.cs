using System;
using UnityEngine;

namespace SpaceGraphicsToolkit
{
	[ExecuteInEditMode]
	public class SgtFloatingScaler : MonoBehaviour
	{
		public Vector3 BaseScale;

		public double ScaleMultiplier;

		public SgtLength DistanceMin;

		public SgtLength DistanceMax;

		[NonSerialized]
		private SgtFloatingObject cachedObject;

		protected virtual void OnEnable()
		{
		}

		protected virtual void OnDisable()
		{
		}

		private void UpdateDistance(double distance)
		{
		}
	}
}
