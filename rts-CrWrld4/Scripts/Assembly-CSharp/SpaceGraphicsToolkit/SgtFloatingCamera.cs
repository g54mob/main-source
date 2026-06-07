using System;
using UnityEngine;

namespace SpaceGraphicsToolkit
{
	[ExecuteInEditMode]
	public class SgtFloatingCamera : SgtLinkedBehaviour<SgtFloatingCamera>
	{
		public long Scale;

		public float SnapDistance;

		public static Action<SgtFloatingCamera, Vector3> OnSnap;

		public bool UseOrigin;

		public SgtPosition SnappedPoint;

		public bool SnappedPointSet;

		[NonSerialized]
		private Camera cachedCamera;

		[NonSerialized]
		private bool cachedCameraSet;

		[SerializeField]
		private Vector3 expectedPosition;

		[SerializeField]
		private bool expectedPositionSet;

		public Camera CachedCamera => null;

		public static bool TryGetCamera(int layer, ref SgtFloatingCamera matchingCamera)
		{
			return false;
		}

		public bool IsRendering(int targetLayer)
		{
			return false;
		}

		public SgtPosition GetPosition(Vector3 localPosition)
		{
			return default(SgtPosition);
		}

		public Vector3 CalculatePosition(ref SgtPosition input)
		{
			return default(Vector3);
		}

		public void Snap()
		{
		}

		protected override void OnEnable()
		{
		}

		protected virtual void LateUpdate()
		{
		}

		protected override void OnDisable()
		{
		}

		private void PreCull(Camera camera)
		{
		}

		private static void CheckForPositionChangesAll()
		{
		}

		private void CheckForPositionChanges()
		{
		}

		private void UpdatePosition()
		{
		}

		private void UpdatePositionNow()
		{
		}
	}
}
