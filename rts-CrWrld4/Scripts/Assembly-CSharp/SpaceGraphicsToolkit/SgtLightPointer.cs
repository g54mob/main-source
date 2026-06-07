using System;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceGraphicsToolkit
{
	[ExecuteInEditMode]
	public class SgtLightPointer : MonoBehaviour
	{
		public class CameraState : SgtCameraState
		{
			public Quaternion LocalRotation;
		}

		[NonSerialized]
		private Light cachedLight;

		[NonSerialized]
		private bool cachedLightSet;

		[NonSerialized]
		private List<CameraState> cameraStates;

		public Light CachedLight => null;

		protected virtual void OnEnable()
		{
		}

		protected virtual void OnDisable()
		{
		}

		private void CameraPreCull(Camera camera)
		{
		}

		private void CameraPreRender(Camera camera)
		{
		}

		private void Save(Camera camera)
		{
		}

		private void Restore(Camera camera)
		{
		}

		private void Revert()
		{
		}
	}
}
