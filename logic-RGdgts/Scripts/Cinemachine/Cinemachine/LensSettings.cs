using System;
using UnityEngine;

namespace Cinemachine
{
	[Serializable]
	public struct LensSettings
	{
		public enum OverrideModes
		{
			None = 0,
			Orthographic = 1,
			Perspective = 2,
			Physical = 3
		}

		public static LensSettings Default;

		public float FieldOfView;

		public float OrthographicSize;

		public float NearClipPlane;

		public float FarClipPlane;

		public float Dutch;

		public OverrideModes ModeOverride;

		public Vector2 LensShift;

		public Camera.GateFitMode GateFit;

		[SerializeField]
		private Vector2 m_SensorSize;

		private bool m_OrthoFromCamera;

		private bool m_PhysicalFromCamera;

		public bool Orthographic
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public Vector2 SensorSize
		{
			get
			{
				return default(Vector2);
			}
			set
			{
			}
		}

		public float Aspect => 0f;

		public bool IsPhysicalCamera
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public static LensSettings FromCamera(Camera fromCamera)
		{
			return default(LensSettings);
		}

		public void SnapshotCameraReadOnlyProperties(Camera camera)
		{
		}

		public void SnapshotCameraReadOnlyProperties(ref LensSettings lens)
		{
		}

		public LensSettings(float verticalFOV, float orthographicSize, float nearClip, float farClip, float dutch)
		{
			FieldOfView = 0f;
			OrthographicSize = 0f;
			NearClipPlane = 0f;
			FarClipPlane = 0f;
			Dutch = 0f;
			ModeOverride = default(OverrideModes);
			LensShift = default(Vector2);
			GateFit = default(Camera.GateFitMode);
			m_SensorSize = default(Vector2);
			m_OrthoFromCamera = false;
			m_PhysicalFromCamera = false;
		}

		public static LensSettings Lerp(LensSettings lensA, LensSettings lensB, float t)
		{
			return default(LensSettings);
		}

		public void Validate()
		{
		}
	}
}
