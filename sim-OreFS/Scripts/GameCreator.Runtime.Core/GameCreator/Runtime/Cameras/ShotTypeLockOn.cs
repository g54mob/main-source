using System;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.Cameras
{
	[Serializable]
	[Title("Lock On")]
	[Category("Lock On")]
	[Image(typeof(IconShotLockOn), ColorTheme.Type.Blue)]
	[Description("Follows an object from a distance and tracks another one, so both are framed")]
	public class ShotTypeLockOn : TShotTypeLook
	{
		[SerializeField]
		private ShotSystemZoom m_ShotSystemZoom;

		[SerializeField]
		private ShotSystemLockOn m_ShotSystemLockOn;

		[NonSerialized]
		private readonly Transform[] m_Ignore = new Transform[2];

		public override Transform[] Ignore
		{
			get
			{
				m_Ignore[0] = base.Look.GetLookTarget(this);
				m_Ignore[1] = LockOn.GetAnchorTarget(this);
				return m_Ignore;
			}
		}

		public ShotSystemZoom Zoom => m_ShotSystemZoom;

		public ShotSystemLockOn LockOn => m_ShotSystemLockOn;

		public ShotTypeLockOn()
		{
			m_ShotSystemLook = new ShotSystemLook(GetGameObjectInstance.Create(), GetDirectionVector3Zero.Create());
			m_ShotSystemZoom = new ShotSystemZoom();
			m_ShotSystemLockOn = new ShotSystemLockOn();
			m_ShotSystems.Add(m_ShotSystemLook.Id, m_ShotSystemLook);
			m_ShotSystems.Add(m_ShotSystemZoom.Id, m_ShotSystemZoom);
			m_ShotSystems.Add(m_ShotSystemLockOn.Id, m_ShotSystemLockOn);
		}

		protected override void OnBeforeAwake(ShotCamera shotCamera)
		{
			base.OnBeforeAwake(shotCamera);
			m_ShotSystemZoom?.OnAwake(this);
			m_ShotSystemLockOn?.OnAwake(this);
		}

		protected override void OnBeforeStart(ShotCamera shotCamera)
		{
			base.OnBeforeStart(shotCamera);
			m_ShotSystemZoom?.OnStart(this);
			m_ShotSystemLockOn?.OnStart(this);
		}

		protected override void OnBeforeDestroy(ShotCamera shotCamera)
		{
			base.OnBeforeDestroy(shotCamera);
			m_ShotSystemZoom?.OnDestroy(this);
			m_ShotSystemLockOn?.OnDestroy(this);
		}

		protected override void OnBeforeEnable(TCamera camera)
		{
			base.OnBeforeEnable(camera);
			m_ShotSystemZoom?.OnEnable(this, camera);
			m_ShotSystemLockOn?.OnEnable(this, camera);
		}

		protected override void OnBeforeDisable(TCamera camera)
		{
			base.OnBeforeDisable(camera);
			m_ShotSystemZoom?.OnDisable(this, camera);
			m_ShotSystemLockOn?.OnDisable(this, camera);
		}

		protected override void OnBeforeUpdate()
		{
			base.OnBeforeUpdate();
			m_ShotSystemZoom?.OnUpdate(this);
			m_ShotSystemLockOn.SyncWithZoom(Args, Zoom);
			m_ShotSystemLockOn?.OnUpdate(this);
		}

		public override void DrawGizmos(Transform transform)
		{
			base.DrawGizmos(transform);
			if (Application.isPlaying)
			{
				m_ShotSystemZoom.OnDrawGizmos(this, transform);
				m_ShotSystemLockOn.OnDrawGizmos(this, transform);
			}
		}

		public override void DrawGizmosSelected(Transform transform)
		{
			base.DrawGizmosSelected(transform);
			m_ShotSystemZoom.OnDrawGizmosSelected(this, transform);
			m_ShotSystemLockOn.OnDrawGizmosSelected(this, transform);
		}
	}
}
