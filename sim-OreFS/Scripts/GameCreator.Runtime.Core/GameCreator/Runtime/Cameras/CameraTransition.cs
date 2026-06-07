using System;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.Cameras
{
	[Serializable]
	public class CameraTransition
	{
		private const float EPSILON = 0.005f;

		private const float DEFAULT_SMOOTH_TIME = 0.1f;

		[SerializeField]
		private ShotCamera m_CurrentShotCamera;

		[SerializeField]
		private float m_SmoothTimePosition;

		[SerializeField]
		private float m_SmoothTimeRotation;

		[NonSerialized]
		private TCamera m_Camera;

		[NonSerialized]
		private ShotCamera m_PreviousShotCamera;

		[NonSerialized]
		private float m_ChangeDuration;

		[NonSerialized]
		private float m_ChangeTime;

		[NonSerialized]
		private Vector3 m_PositionVelocity;

		[NonSerialized]
		private Quaternion m_RotationVelocity;

		[NonSerialized]
		private Vector3 m_PreviousCameraPosition;

		[NonSerialized]
		private Quaternion m_PreviousCameraRotation;

		[NonSerialized]
		private Easing.Type m_Easing = Easing.Type.QuadInOut;

		[field: NonSerialized]
		public Vector3 Position { get; private set; }

		[field: NonSerialized]
		public Quaternion Rotation { get; private set; }

		public ShotCamera CurrentShotCamera
		{
			get
			{
				return m_CurrentShotCamera;
			}
			set
			{
				m_CurrentShotCamera = value;
			}
		}

		public float SmoothTimePosition
		{
			get
			{
				return m_SmoothTimePosition;
			}
			set
			{
				m_SmoothTimePosition = value;
			}
		}

		public float SmoothTimeRotation
		{
			get
			{
				return m_SmoothTimeRotation;
			}
			set
			{
				m_SmoothTimeRotation = value;
			}
		}

		public ShotCamera PreviousShotCamera => m_PreviousShotCamera;

		public event Action<ShotCamera> EventCut;

		public event Action<ShotCamera, float, Easing.Type> EventTransition;

		internal CameraTransition()
		{
			m_SmoothTimePosition = 0.1f;
			m_SmoothTimeRotation = 0.1f;
		}

		internal void OnAwake(TCamera camera)
		{
			m_Camera = camera;
			Transform transform = m_Camera.transform;
			Position = transform.position;
			Rotation = transform.rotation;
		}

		internal void OnStart(TCamera camera)
		{
			if ((bool)m_CurrentShotCamera)
			{
				ChangeToShot(CurrentShotCamera);
			}
		}

		internal void NormalUpdate()
		{
			if (!(m_CurrentShotCamera == null))
			{
				float num = m_Camera.Time.Time - m_ChangeTime;
				float t = Mathf.Clamp01((m_ChangeDuration > float.Epsilon) ? (num / m_ChangeDuration) : 1f);
				Update(t, m_Camera.Time.DeltaTime);
			}
		}

		internal void FixedUpdate()
		{
			if (!(m_CurrentShotCamera == null))
			{
				float num = m_Camera.Time.FixedTime - m_ChangeTime;
				float t = Mathf.Clamp01((m_ChangeDuration > float.Epsilon) ? (num / m_ChangeDuration) : 1f);
				Update(t, m_Camera.Time.FixedDeltaTime);
			}
		}

		internal void Sync()
		{
			if (!(m_CurrentShotCamera == null))
			{
				Position = m_CurrentShotCamera.Position;
				Rotation = m_CurrentShotCamera.Rotation;
			}
		}

		private void Update(float t, float deltaTime)
		{
			float t2 = ((t < 1f) ? Easing.GetEase(m_Easing, 0f, 1f, t) : 1f);
			Vector3 position = Vector3.LerpUnclamped(m_PreviousCameraPosition, m_CurrentShotCamera.Position, t2);
			Quaternion rotation = Quaternion.LerpUnclamped(m_PreviousCameraRotation, m_CurrentShotCamera.Rotation, t2);
			UpdatePosition(position, deltaTime);
			UpdateRotation(rotation, deltaTime);
		}

		private void UpdatePosition(Vector3 position, float deltaTime)
		{
			if (m_CurrentShotCamera.UseSmoothPosition && Position != position)
			{
				Position = ((deltaTime > float.Epsilon) ? Vector3.SmoothDamp(Position, position, ref m_PositionVelocity, m_SmoothTimePosition, float.PositiveInfinity, deltaTime) : Position);
			}
			else
			{
				Position = position;
			}
		}

		private void UpdateRotation(Quaternion rotation, float deltaTime)
		{
			if (m_CurrentShotCamera.UseSmoothRotation && Rotation != rotation)
			{
				Rotation = QuaternionUtils.SmoothDamp(Rotation, rotation, ref m_RotationVelocity, m_SmoothTimeRotation, deltaTime);
			}
			else
			{
				Rotation = rotation;
			}
		}

		public void ChangeToShot(ShotCamera shotCamera, float duration = 0f, Easing.Type easing = Easing.Type.QuadInOut)
		{
			m_Easing = easing;
			m_PreviousCameraPosition = m_Camera.transform.position;
			m_PreviousCameraRotation = m_Camera.transform.rotation;
			if (m_CurrentShotCamera != null)
			{
				m_CurrentShotCamera.OnDisableShot(m_Camera);
				m_PreviousShotCamera = m_CurrentShotCamera;
			}
			m_CurrentShotCamera = shotCamera;
			m_CurrentShotCamera.OnEnableShot(m_Camera);
			if (duration <= 0.005f)
			{
				Position = m_CurrentShotCamera.Position;
				Rotation = m_CurrentShotCamera.Rotation;
			}
			m_ChangeDuration = ((duration <= 0.005f) ? 0f : duration);
			m_ChangeTime = m_Camera.Time.Time;
			if (duration <= 0.005f)
			{
				this.EventCut?.Invoke(m_CurrentShotCamera);
			}
			else
			{
				this.EventTransition?.Invoke(m_CurrentShotCamera, duration, easing);
			}
		}

		public void ChangeToPreviousShot(float duration = 0f)
		{
			ChangeToShot(m_PreviousShotCamera, duration);
		}
	}
}
