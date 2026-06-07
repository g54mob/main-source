using System;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.Cameras
{
	[Serializable]
	[Title("Third Person")]
	[Category("Third Person")]
	[Image(typeof(IconShotThirdPerson), ColorTheme.Type.Blue)]
	[Description("Follows the target from a certain distance while allowing to orbit around it")]
	public class ShotTypeThirdPerson : TShotType
	{
		[SerializeField]
		private ShotSystemZoom m_Zoom;

		[SerializeField]
		private ShotSystemThirdPerson m_ThirdPerson;

		[NonSerialized]
		private readonly Transform[] m_Ignore = new Transform[1];

		public ShotSystemZoom Zoom => m_Zoom;

		public override bool UseSmoothPosition => false;

		public override bool UseSmoothRotation => false;

		public override Args Args
		{
			get
			{
				if (m_Args == null)
				{
					m_Args = new Args(m_ShotCamera, null);
				}
				m_Args.ChangeTarget(m_ThirdPerson.Pivot);
				return m_Args;
			}
		}

		public override Transform[] Ignore
		{
			get
			{
				GameObject pivot = m_ThirdPerson.Pivot;
				m_Ignore[0] = ((pivot != null) ? pivot.transform : null);
				return m_Ignore;
			}
		}

		public override bool HasTarget => m_ThirdPerson.Pivot != null;

		public override Vector3 Target => m_ThirdPerson.PivotPosition;

		public ShotTypeThirdPerson()
		{
			m_Zoom = new ShotSystemZoom();
			m_ThirdPerson = new ShotSystemThirdPerson();
			m_ShotSystems.Add(m_Zoom.Id, m_Zoom);
			m_ShotSystems.Add(m_ThirdPerson.Id, m_ThirdPerson);
		}

		public void AddRotation(float pitch, float yaw)
		{
			m_ThirdPerson.Pitch += pitch;
			m_ThirdPerson.Yaw += yaw;
		}

		protected override void OnBeforeAwake(ShotCamera shotCamera)
		{
			base.OnBeforeAwake(shotCamera);
			m_Zoom?.OnAwake(this);
			m_ThirdPerson?.OnAwake(this);
		}

		protected override void OnBeforeStart(ShotCamera shotCamera)
		{
			base.OnBeforeStart(shotCamera);
			m_Zoom?.OnStart(this);
			m_ThirdPerson?.OnStart(this);
		}

		protected override void OnBeforeDestroy(ShotCamera shotCamera)
		{
			base.OnBeforeDestroy(shotCamera);
			m_Zoom?.OnDestroy(this);
			m_ThirdPerson?.OnDestroy(this);
		}

		protected override void OnBeforeEnable(TCamera camera)
		{
			base.OnBeforeEnable(camera);
			m_Zoom?.OnEnable(this, camera);
			m_ThirdPerson?.OnEnable(this, camera);
		}

		protected override void OnBeforeDisable(TCamera camera)
		{
			base.OnBeforeDisable(camera);
			m_Zoom?.OnDisable(this, camera);
			m_ThirdPerson?.OnDisable(this, camera);
		}

		protected override void OnBeforeUpdate()
		{
			base.OnBeforeUpdate();
			m_Recoil.Update(out var pitch, out var yaw);
			AddRotation(pitch, yaw);
			m_Zoom?.OnUpdate(this);
			m_ThirdPerson?.OnUpdate(this);
		}

		public override void DrawGizmos(Transform transform)
		{
			base.DrawGizmos(transform);
			if (Application.isPlaying)
			{
				m_Zoom.OnDrawGizmos(this, transform);
				m_ThirdPerson?.OnDrawGizmos(this, transform);
			}
		}

		public override void DrawGizmosSelected(Transform transform)
		{
			base.DrawGizmosSelected(transform);
			if (Application.isPlaying)
			{
				m_Zoom.OnDrawGizmosSelected(this, transform);
				m_ThirdPerson?.OnDrawGizmosSelected(this, transform);
			}
		}
	}
}
