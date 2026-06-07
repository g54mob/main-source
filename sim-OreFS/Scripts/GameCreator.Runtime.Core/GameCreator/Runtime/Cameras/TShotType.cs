using System;
using System.Collections.Generic;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.Cameras
{
	[Serializable]
	public abstract class TShotType : IShotType
	{
		[SerializeField]
		protected ShotSystemViewport m_ShotSystemViewport;

		[NonSerialized]
		protected ShotCamera m_ShotCamera;

		[NonSerialized]
		protected Transform m_Transform;

		[NonSerialized]
		protected Args m_Args;

		[NonSerialized]
		protected Dictionary<int, IShotSystem> m_ShotSystems;

		[NonSerialized]
		protected ShotFeatureRecoil m_Recoil;

		public virtual Vector3 Position
		{
			get
			{
				if (!(m_Transform != null))
				{
					return default(Vector3);
				}
				return m_Transform.position;
			}
			set
			{
				m_Transform.position = value;
			}
		}

		public virtual Quaternion Rotation
		{
			get
			{
				if (!(m_Transform != null))
				{
					return default(Quaternion);
				}
				return m_Transform.rotation;
			}
			set
			{
				m_Transform.rotation = value;
			}
		}

		public bool IsActive { get; private set; }

		public abstract Transform[] Ignore { get; }

		public abstract Args Args { get; }

		public ShotCamera ShotCamera => m_ShotCamera;

		public Transform Transform => m_Transform;

		public virtual bool UseSmoothPosition => true;

		public virtual bool UseSmoothRotation => true;

		public IShotSystem[] ShotSystems
		{
			get
			{
				List<IShotSystem> list = new List<IShotSystem>();
				foreach (IShotSystem value in m_ShotSystems.Values)
				{
					list.Add(value);
				}
				return list.ToArray();
			}
		}

		public virtual bool HasObstacle => false;

		public abstract bool HasTarget { get; }

		public abstract Vector3 Target { get; }

		public virtual ShotFeatureRecoil Recoil => m_Recoil;

		protected TShotType()
		{
			m_ShotSystems = new Dictionary<int, IShotSystem>();
			m_ShotSystemViewport = new ShotSystemViewport();
			m_ShotSystems.Add(m_ShotSystemViewport.Id, m_ShotSystemViewport);
		}

		public void Awake(ShotCamera shotCamera)
		{
			m_ShotCamera = shotCamera;
			m_Args = new Args(m_ShotCamera);
			m_Recoil = new ShotFeatureRecoil(shotCamera);
			m_Transform = m_ShotCamera.transform;
			OnBeforeAwake(shotCamera);
			OnAfterAwake(shotCamera);
		}

		public void Start(ShotCamera shotCamera)
		{
			OnBeforeStart(shotCamera);
			OnAfterStart(shotCamera);
		}

		public void Destroy(ShotCamera shotCamera)
		{
			OnBeforeDestroy(shotCamera);
			OnAfterDestroy(shotCamera);
		}

		public void Update()
		{
			OnBeforeUpdate();
			OnAfterUpdate();
		}

		public void OnEnable(TCamera camera)
		{
			IsActive = true;
			OnBeforeEnable(camera);
			OnAfterEnable(camera);
		}

		public void OnDisable(TCamera camera)
		{
			IsActive = false;
			OnBeforeDisable(camera);
			OnAfterDisable(camera);
		}

		protected virtual void OnBeforeAwake(ShotCamera shotCamera)
		{
		}

		protected virtual void OnAfterAwake(ShotCamera shotCamera)
		{
		}

		protected virtual void OnBeforeStart(ShotCamera shotCamera)
		{
		}

		protected virtual void OnAfterStart(ShotCamera shotCamera)
		{
		}

		protected virtual void OnBeforeDestroy(ShotCamera shotCamera)
		{
		}

		protected virtual void OnAfterDestroy(ShotCamera shotCamera)
		{
		}

		protected virtual void OnBeforeUpdate()
		{
		}

		protected virtual void OnAfterUpdate()
		{
		}

		protected virtual void OnBeforeDisable(TCamera camera)
		{
		}

		protected virtual void OnAfterDisable(TCamera camera)
		{
		}

		protected virtual void OnBeforeEnable(TCamera camera)
		{
		}

		protected virtual void OnAfterEnable(TCamera camera)
		{
		}

		public virtual void DrawGizmos(Transform transform)
		{
		}

		public virtual void DrawGizmosSelected(Transform transform)
		{
		}

		public IShotSystem GetSystem(int systemID)
		{
			return m_ShotSystems.GetValueOrDefault(systemID);
		}
	}
}
