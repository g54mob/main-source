using System;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.Cameras
{
	[Serializable]
	[Title("Animation")]
	[Category("Animation")]
	[Image(typeof(IconShotAnimation), ColorTheme.Type.Blue)]
	[Description("Plays an animation where the Camera moves along a path")]
	public class ShotTypeAnimation : TShotTypeLook
	{
		[SerializeField]
		private ShotSystemAnimation m_ShotSystemAnimation;

		public ShotSystemAnimation Animation => m_ShotSystemAnimation;

		public override Vector3 Position { get; set; }

		public override Quaternion Rotation { get; set; }

		public ShotTypeAnimation()
		{
			m_ShotSystemAnimation = new ShotSystemAnimation();
			m_ShotSystems.Add(m_ShotSystemLook.Id, m_ShotSystemLook);
			m_ShotSystems.Add(m_ShotSystemAnimation.Id, m_ShotSystemAnimation);
		}

		protected override void OnBeforeAwake(ShotCamera shotCamera)
		{
			base.OnBeforeAwake(shotCamera);
			Position = shotCamera.transform.position;
			Rotation = shotCamera.transform.rotation;
			m_ShotSystemAnimation.OnAwake(this);
		}

		protected override void OnBeforeEnable(TCamera camera)
		{
			base.OnBeforeEnable(camera);
			m_ShotSystemAnimation.OnEnable(this, camera);
		}

		protected override void OnBeforeUpdate()
		{
			base.OnBeforeUpdate();
			m_ShotSystemAnimation.OnUpdate(this);
		}

		public override void DrawGizmos(Transform transform)
		{
			base.DrawGizmos(transform);
			m_ShotSystemAnimation.OnDrawGizmos(this, transform);
		}

		public override void DrawGizmosSelected(Transform transform)
		{
			base.DrawGizmosSelected(transform);
			m_ShotSystemAnimation.OnDrawGizmosSelected(this, transform);
		}
	}
}
