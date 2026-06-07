using System;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.Cameras
{
	[Serializable]
	[Title("Anchor Peek")]
	[Category("Anchor Peek")]
	[Image(typeof(IconShotAnchor), ColorTheme.Type.Blue)]
	[Description("Anchors to an object and allows to pan and tilt the Shot up, down and to the sides")]
	public class ShotTypeAnchorPeek : TShotType
	{
		[SerializeField]
		private ShotSystemAnchor m_ShotSystemAnchor = new ShotSystemAnchor();

		[SerializeField]
		private ShotSystemPeek m_ShotSystemPeek = new ShotSystemPeek();

		[NonSerialized]
		private readonly Transform[] m_Ignore = new Transform[1];

		public ShotSystemAnchor Anchor => m_ShotSystemAnchor;

		public ShotSystemPeek Peek => m_ShotSystemPeek;

		public override Args Args
		{
			get
			{
				if (m_Args == null)
				{
					m_Args = new Args(m_ShotCamera, null);
				}
				m_Args.ChangeTarget(Anchor.GetTargetTransform(this));
				return m_Args;
			}
		}

		public override Transform[] Ignore
		{
			get
			{
				m_Ignore[0] = Anchor.GetTargetTransform(this);
				return m_Ignore;
			}
		}

		public override bool HasTarget => Anchor.GetTargetTransform(this) != null;

		public override Vector3 Target => Anchor.GetTargetPosition(this);

		public ShotTypeAnchorPeek()
		{
			m_ShotSystems.Add(m_ShotSystemAnchor.Id, m_ShotSystemAnchor);
			m_ShotSystems.Add(m_ShotSystemPeek.Id, m_ShotSystemPeek);
		}

		protected override void OnBeforeAwake(ShotCamera shotCamera)
		{
			base.OnBeforeAwake(shotCamera);
			m_ShotSystemAnchor?.OnAwake(this);
			m_ShotSystemPeek?.OnAwake(this);
		}

		protected override void OnBeforeStart(ShotCamera shotCamera)
		{
			base.OnBeforeStart(shotCamera);
			m_ShotSystemAnchor?.OnStart(this);
			m_ShotSystemPeek?.OnStart(this);
		}

		protected override void OnBeforeDestroy(ShotCamera shotCamera)
		{
			base.OnBeforeDestroy(shotCamera);
			m_ShotSystemAnchor?.OnDestroy(this);
			m_ShotSystemPeek?.OnDestroy(this);
		}

		protected override void OnBeforeEnable(TCamera camera)
		{
			base.OnBeforeEnable(camera);
			m_ShotSystemAnchor?.OnEnable(this, camera);
			m_ShotSystemPeek?.OnEnable(this, camera);
		}

		protected override void OnBeforeDisable(TCamera camera)
		{
			base.OnBeforeDisable(camera);
			m_ShotSystemAnchor?.OnDisable(this, camera);
			m_ShotSystemPeek?.OnDisable(this, camera);
		}

		protected override void OnBeforeUpdate()
		{
			base.OnBeforeUpdate();
			m_ShotSystemAnchor?.OnUpdate(this);
			m_ShotSystemPeek?.OnUpdate(this);
		}

		public override void DrawGizmos(Transform transform)
		{
			base.DrawGizmos(transform);
			m_ShotSystemAnchor.OnDrawGizmos(this, transform);
			m_ShotSystemPeek?.OnDrawGizmos(this, transform);
		}

		public override void DrawGizmosSelected(Transform transform)
		{
			base.DrawGizmosSelected(transform);
			m_ShotSystemAnchor.OnDrawGizmosSelected(this, transform);
			m_ShotSystemPeek?.OnDrawGizmosSelected(this, transform);
		}
	}
}
