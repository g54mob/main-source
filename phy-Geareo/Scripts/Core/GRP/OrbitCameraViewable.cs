using System;
using Rhizomatic.Reactive;
using UnityEngine;

namespace GRP
{
	public class OrbitCameraViewable : Viewable
	{
		public Vector3 position;

		public Vector3 rotation;

		public float zoom;

		public Action load;

		public Action<Vector3> goTo;

		public Action<Vector3, Quaternion> goToRotation;

		public Action<Vector3, float> goToZoom;

		public bool hasData;

		public void GoTo(Vector3 position)
		{
		}

		public void GoTo(Vector3 position, float zoom)
		{
		}

		public void GoTo(Vector3 position, Quaternion rotation)
		{
		}

		public void CopyTo(OrbitCameraViewable viewable)
		{
		}

		public float GetZoomDistance()
		{
			return 0f;
		}

		public OrbitCameraData Serialize()
		{
			return null;
		}

		public void Deserialize(OrbitCameraData data)
		{
		}
	}
}
