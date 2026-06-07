using System;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.Cameras
{
	[Serializable]
	public abstract class TShotTypeLook : TShotType
	{
		private const float OBSTACLE_MIN_DISTANCE = 0.5f;

		private const int OBSTACLE_LAYER_MASK = -1;

		[SerializeField]
		protected ShotSystemLook m_ShotSystemLook = new ShotSystemLook();

		[NonSerialized]
		private readonly Transform[] m_Ignore = new Transform[1];

		[NonSerialized]
		private readonly RaycastHit[] m_ObstacleHits = new RaycastHit[10];

		public ShotSystemLook Look => m_ShotSystemLook;

		public override bool HasTarget => Look.GetLookTarget(this) != null;

		public override Vector3 Target => m_ShotSystemLook.GetLookPosition(this);

		public override Args Args
		{
			get
			{
				if (m_Args == null)
				{
					m_Args = new Args(m_ShotCamera, null);
				}
				m_Args.ChangeTarget(Look.GetLookTarget(this));
				return m_Args;
			}
		}

		public override Transform[] Ignore
		{
			get
			{
				m_Ignore[0] = Look.GetLookTarget(this);
				return m_Ignore;
			}
		}

		public override bool HasObstacle
		{
			get
			{
				Vector3 lookPosition = m_ShotSystemLook.GetLookPosition(this);
				int num = Physics.RaycastNonAlloc(new Ray(Position, (lookPosition != default(Vector3)) ? (lookPosition - Position) : (Rotation * Vector3.forward)), maxDistance: (lookPosition != default(Vector3)) ? Vector3.Distance(Position, lookPosition) : 0.5f, results: m_ObstacleHits, layerMask: -1, queryTriggerInteraction: QueryTriggerInteraction.Ignore);
				Transform[] ignore = Ignore;
				for (int i = 0; i < num; i++)
				{
					RaycastHit raycastHit = m_ObstacleHits[i];
					bool flag = true;
					Transform[] array = ignore;
					foreach (Transform parent in array)
					{
						if (raycastHit.transform.IsChildOf(parent))
						{
							flag = false;
							break;
						}
					}
					if (flag)
					{
						return true;
					}
				}
				return false;
			}
		}

		protected override void OnBeforeAwake(ShotCamera shotCamera)
		{
			base.OnBeforeAwake(shotCamera);
			Look.OnAwake(this);
		}

		protected override void OnBeforeStart(ShotCamera shotCamera)
		{
			base.OnBeforeStart(shotCamera);
			Look.OnStart(this);
		}

		protected override void OnBeforeDestroy(ShotCamera shotCamera)
		{
			base.OnBeforeDestroy(shotCamera);
			Look.OnDestroy(this);
		}

		protected override void OnAfterUpdate()
		{
			base.OnAfterUpdate();
			Look.OnUpdate(this);
		}

		protected override void OnBeforeDisable(TCamera camera)
		{
			base.OnBeforeDisable(camera);
			Look.OnDisable(this, camera);
		}

		protected override void OnBeforeEnable(TCamera camera)
		{
			base.OnBeforeEnable(camera);
			Look.OnEnable(this, camera);
		}

		public override void DrawGizmos(Transform transform)
		{
			Look.OnDrawGizmos(this, transform);
		}

		public override void DrawGizmosSelected(Transform transform)
		{
			Look.OnDrawGizmosSelected(this, transform);
		}
	}
}
