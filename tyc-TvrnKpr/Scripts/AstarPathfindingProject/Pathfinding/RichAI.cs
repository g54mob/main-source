using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Pathfinding.Util;
using UnityEngine;

namespace Pathfinding
{
	[AddComponentMenu("Pathfinding/AI/RichAI (3D, for navmesh)")]
	[UniqueComponent(tag = "ai")]
	[DisallowMultipleComponent]
	public class RichAI : AIBase, IAstarAI
	{
		[CompilerGenerated]
		private sealed class _003CTraverseOffMeshLinkFallback_003Ed__80 : IEnumerator<object>, IEnumerator, IDisposable
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
			public _003CTraverseOffMeshLinkFallback_003Ed__80(int _003C_003E1__state)
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
		private sealed class _003CTraverseSpecial_003Ed__79 : IEnumerator<object>, IEnumerator, IDisposable
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
			public _003CTraverseSpecial_003Ed__79(int _003C_003E1__state)
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

		public float wallForce;

		public float wallDist;

		public bool funnelSimplification;

		public bool slowWhenNotFacingTarget;

		public bool preventMovingBackwards;

		public Func<RichSpecial, IEnumerator> onTraverseOffMeshLink;

		protected readonly RichPath richPath;

		protected bool delayUpdatePath;

		protected bool lastCorner;

		private Vector2 rotationFilterState;

		private Vector2 rotationFilterState2;

		protected float distanceToSteeringTarget;

		protected readonly List<Vector3> nextCorners;

		protected readonly List<Vector3> wallBuffer;

		protected static readonly Color GizmoColorPath;

		public bool traversingOffMeshLink { get; protected set; }

		public float remainingDistance => 0f;

		public bool reachedEndOfPath => false;

		public override bool reachedDestination => false;

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

		bool IAstarAI.simulateMovement
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		NativeMovementPlane IAstarAI.movementPlane => default(NativeMovementPlane);

		public bool approachingPartEndpoint => false;

		public bool approachingPathEndpoint => false;

		public override Vector3 endOfPath => default(Vector3);

		public override Quaternion rotation
		{
			get
			{
				return default(Quaternion);
			}
			set
			{
			}
		}

		protected override bool shouldRecalculatePath => false;

		public override void Teleport(Vector3 newPosition, bool clearPath = true)
		{
		}

		protected virtual Vector3 ClampPositionToGraph(Vector3 newPosition)
		{
			return default(Vector3);
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

		public void GetRemainingPath(List<Vector3> buffer, List<PathPartWithLinkInfo> partsBuffer, out bool stale)
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

		private void FinalMovement(Vector3 position3D, float deltaTime, float distanceToEndOfPath, float speedLimitFactor, out Vector3 nextPosition, out Quaternion nextRotation)
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

		[IteratorStateMachine(typeof(_003CTraverseSpecial_003Ed__79))]
		protected virtual IEnumerator TraverseSpecial(RichSpecial link)
		{
			return null;
		}

		[IteratorStateMachine(typeof(_003CTraverseOffMeshLinkFallback_003Ed__80))]
		protected IEnumerator TraverseOffMeshLinkFallback(RichSpecial link)
		{
			return null;
		}

		public override void DrawGizmos()
		{
		}
	}
}
