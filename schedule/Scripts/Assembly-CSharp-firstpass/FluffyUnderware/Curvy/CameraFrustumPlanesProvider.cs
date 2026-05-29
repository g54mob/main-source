using System;
using UnityEngine;

namespace FluffyUnderware.Curvy
{
	public class CameraFrustumPlanesProvider
	{
		private static readonly Lazy<CameraFrustumPlanesProvider> instance;

		private static object lockObject;

		private readonly Plane[] cachedPlanes;

		private Vector3 cachedPosition;

		private Vector3 cachedForward;

		private float cachedFov;

		private int cachedPixelWidth;

		private int cachedPixelHeight;

		public static CameraFrustumPlanesProvider Instance => null;

		public Plane[] GetFrustumPlanes(Camera camera)
		{
			return null;
		}

		private bool IsCacheOutdated(Vector3 cameraPosition, Vector3 cameraZDirection, int cameraPixelWidth, int cameraPixelHeight, float cameraFieldOfView)
		{
			return false;
		}
	}
}
