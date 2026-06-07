using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Serialization;

namespace Pathfinding
{
	[AddComponentMenu("Pathfinding/AI/RichAI (3D, for navmesh)")]
	public class RichAI : AIBase, IAstarAI
	{
		[CompilerGenerated]
		private sealed class _003CTraverseOffMeshLinkFallback_003Ed__69 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public RichAI _003C_003E4__this;

			public RichSpecial link;

			private float _003Cduration_003E5__2;

			private float _003CstartTime_003E5__3;

			object IEnumerator<object>.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			[DebuggerHidden]
			public _003CTraverseOffMeshLinkFallback_003Ed__69(int _003C_003E1__state)
			{
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				return false;
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			[DebuggerHidden]
			void IEnumerator.Reset()
			{
			}
		}

		[CompilerGenerated]
		private sealed class _003CTraverseSpecial_003Ed__68 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public RichAI _003C_003E4__this;

			public RichSpecial link;

			object IEnumerator<object>.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			[DebuggerHidden]
			public _003CTraverseSpecial_003Ed__68(int _003C_003E1__state)
			{
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				return false;
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			[DebuggerHidden]
			void IEnumerator.Reset()
			{
			}
		}

		public float acceleration;

		public float rotationSpeed;

		public float slowdownTime;

		public float endReachedDistance;

		public float wallForce;

		public float wallDist;

		public bool funnelSimplification;

		public bool slowWhenNotFacingTarget;

		public Func<RichSpecial, IEnumerator> onTraverseOffMeshLink;

		protected readonly RichPath richPath;

		protected bool delayUpdatePath;

		protected bool lastCorner;

		protected float distanceToSteeringTarget;

		protected readonly List<Vector3> nextCorners;

		protected readonly List<Vector3> wallBuffer;

		protected static readonly Color GizmoColorPath;

		[FormerlySerializedAs("anim")]
		[SerializeField]
		[HideInInspector]
		private Animation animCompatibility;

		public bool traversingOffMeshLink { get; protected set; }

		public float remainingDistance => 0f;

		public bool reachedEndOfPath => false;

		public bool reachedDestination => false;

		public bool hasPath => false;

		public bool pathPending => false;

		public Vector3 steeringTarget { get; protected set; }

		float IAstarAI.radius
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		float IAstarAI.height
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		float IAstarAI.maxSpeed
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		bool IAstarAI.canSearch
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		bool IAstarAI.canMove
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public bool approachingPartEndpoint => false;

		public bool approachingPathEndpoint => false;

		protected override bool shouldRecalculatePath => false;

		[Obsolete("Use velocity instead (lowercase 'v'). [AstarUpgradable: 'Velocity' -> 'velocity']")]
		public Vector3 Velocity => default(Vector3);

		[Obsolete("Use steeringTarget instead. [AstarUpgradable: 'NextWaypoint' -> 'steeringTarget']")]
		public Vector3 NextWaypoint => default(Vector3);

		[Obsolete("Use Vector3.Distance(transform.position, ai.steeringTarget) instead.")]
		public float DistanceToNextWaypoint => 0f;

		[Obsolete("Use canSearch instead. [AstarUpgradable: 'repeatedlySearchPaths' -> 'canSearch']")]
		public bool repeatedlySearchPaths
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		[Obsolete("When unifying the interfaces for different movement scripts, this property has been renamed to reachedEndOfPath (lowercase t).  [AstarUpgradable: 'TargetReached' -> 'reachedEndOfPath']")]
		public bool TargetReached => false;

		[Obsolete("Use pathPending instead (lowercase 'p'). [AstarUpgradable: 'PathPending' -> 'pathPending']")]
		public bool PathPending => false;

		[Obsolete("Use approachingPartEndpoint (lowercase 'a') instead")]
		public bool ApproachingPartEndpoint => false;

		[Obsolete("Use approachingPathEndpoint (lowercase 'a') instead")]
		public bool ApproachingPathEndpoint => false;

		[Obsolete("This property has been renamed to 'traversingOffMeshLink'. [AstarUpgradable: 'TraversingSpecial' -> 'traversingOffMeshLink']")]
		public bool TraversingSpecial => false;

		[Obsolete("This property has been renamed to steeringTarget")]
		public Vector3 TargetPoint => default(Vector3);

		[Obsolete("Use the onTraverseOffMeshLink event or the ... component instead. Setting this value will add a ... component")]
		public Animation anim
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public override void Teleport(Vector3 newPosition, bool clearPath = true)
		{
		}

		protected override void OnDisable()
		{
		}

		public override void SearchPath()
		{
		}

		protected override void OnPathComplete(Path p)
		{
		}

		protected override void ClearPath()
		{
		}

		protected void NextPart()
		{
		}

		public void GetRemainingPath(List<Vector3> buffer, out bool stale)
		{
			stale = default(bool);
		}

		protected virtual void OnTargetReached()
		{
		}

		protected virtual Vector3 UpdateTarget(RichFunnel fn)
		{
			return default(Vector3);
		}

		protected override void MovementUpdateInternal(float deltaTime, out Vector3 nextPosition, out Quaternion nextRotation)
		{
			nextPosition = default(Vector3);
			nextRotation = default(Quaternion);
		}

		private void TraverseFunnel(RichFunnel fn, float deltaTime, out Vector3 nextPosition, out Quaternion nextRotation)
		{
			nextPosition = default(Vector3);
			nextRotation = default(Quaternion);
		}

		private void FinalMovement(Vector3 position3D, float deltaTime, float distanceToEndOfPath, float slowdownFactor, out Vector3 nextPosition, out Quaternion nextRotation)
		{
			nextPosition = default(Vector3);
			nextRotation = default(Quaternion);
		}

		protected override Vector3 ClampToNavmesh(Vector3 position, out bool positionChanged)
		{
			positionChanged = default(bool);
			return default(Vector3);
		}

		private Vector2 CalculateWallForce(Vector2 position, float elevation, Vector2 directionToTarget)
		{
			return default(Vector2);
		}

		[IteratorStateMachine(typeof(_003CTraverseSpecial_003Ed__68))]
		protected virtual IEnumerator TraverseSpecial(RichSpecial link)
		{
			return null;
		}

		[IteratorStateMachine(typeof(_003CTraverseOffMeshLinkFallback_003Ed__69))]
		protected IEnumerator TraverseOffMeshLinkFallback(RichSpecial link)
		{
			return null;
		}

		protected override void OnDrawGizmos()
		{
		}

		protected override int OnUpgradeSerializedData(int version, bool unityThread)
		{
			return 0;
		}

		[Obsolete("Use SearchPath instead. [AstarUpgradable: 'UpdatePath' -> 'SearchPath']")]
		public void UpdatePath()
		{
		}
	}
}
