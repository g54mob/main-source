using System;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.Cameras
{
	[Serializable]
	[AddComponentMenu("Game Creator/Cameras/Shot Camera")]
	[DefaultExecutionOrder(0)]
	public class ShotCamera : MonoBehaviour
	{
		public enum Clipping
		{
			AvoidClipping = 0,
			ClipThrough = 1
		}

		[SerializeField]
		private bool m_IsMainShot;

		[SerializeField]
		private TimeMode m_TimeMode;

		[SerializeField]
		private Clipping m_Clipping;

		[SerializeReference]
		private IShotType m_ShotType = new ShotTypeFixed();

		public IShotType ShotType => m_ShotType;

		public bool IsMainShot => m_IsMainShot;

		public bool AvoidClipping => m_Clipping == Clipping.AvoidClipping;

		public Vector3 Position => m_ShotType?.Position ?? base.transform.position;

		public Quaternion Rotation => m_ShotType?.Rotation ?? base.transform.rotation;

		public bool HasTarget => m_ShotType.HasTarget;

		public Vector3 Target => m_ShotType.Target;

		public Transform[] Ignore => m_ShotType.Ignore;

		public virtual bool UseSmoothPosition => m_ShotType?.UseSmoothPosition ?? false;

		public virtual bool UseSmoothRotation => m_ShotType?.UseSmoothRotation ?? false;

		public TimeMode TimeMode
		{
			get
			{
				return m_TimeMode;
			}
			set
			{
				m_TimeMode = value;
			}
		}

		public bool HasObstacle => m_ShotType.HasObstacle;

		public event Action<TCamera> EventChangeTo;

		public event Action<TCamera> EventChangeFrom;

		protected virtual void Awake()
		{
			if (m_IsMainShot)
			{
				ShortcutMainShot.Change(this);
			}
			m_ShotType?.Awake(this);
		}

		protected virtual void Start()
		{
			m_ShotType?.Start(this);
		}

		protected void OnDestroy()
		{
			m_ShotType?.Destroy(this);
		}

		protected virtual void LateUpdate()
		{
			m_ShotType?.Update();
		}

		private void OnDrawGizmos()
		{
			m_ShotType?.DrawGizmos(base.transform);
		}

		private void OnDrawGizmosSelected()
		{
			m_ShotType?.DrawGizmosSelected(base.transform);
		}

		public virtual void OnEnableShot(TCamera cameraSystem)
		{
			m_ShotType?.OnEnable(cameraSystem);
			m_ShotType?.Update();
			this.EventChangeTo?.Invoke(cameraSystem);
		}

		public virtual void OnDisableShot(TCamera cameraSystem)
		{
			m_ShotType?.OnDisable(cameraSystem);
			this.EventChangeFrom?.Invoke(cameraSystem);
		}
	}
}
