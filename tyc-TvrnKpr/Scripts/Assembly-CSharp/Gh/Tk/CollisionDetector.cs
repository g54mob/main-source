using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace Gh.Tk
{
	public class CollisionDetector : MonoBehaviour
	{
		public enum CollisionState
		{
			None = 0,
			Soft = 1,
			Hard = 2
		}

		[CompilerGenerated]
		private sealed class _003C_003Ec__DisplayClass20_0
		{
			public Collider col;

			public CollisionDetector _003C_003E4__this;
		}

		[CompilerGenerated]
		private sealed class _003CGetObjectsWithinCollider_003Ed__20 : IEnumerable<GameObject>, IEnumerable, IEnumerator<GameObject>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private GameObject _003C_003E2__current;

			private int _003C_003El__initialThreadId;

			private Collider col;

			public Collider _003C_003E3__col;

			public CollisionDetector _003C_003E4__this;

			private _003C_003Ec__DisplayClass20_0 _003C_003E8__1;

			private int _003CresultCount_003E5__2;

			private IEnumerator<GameObject> _003C_003E7__wrap2;

			private int _003Cindex_003E5__4;

			GameObject IEnumerator<GameObject>.Current
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
			public _003CGetObjectsWithinCollider_003Ed__20(int _003C_003E1__state)
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

			private void _003C_003Em__Finally1()
			{
			}

			[DebuggerHidden]
			void IEnumerator.Reset()
			{
			}

			[DebuggerHidden]
			IEnumerator<GameObject> IEnumerable<GameObject>.GetEnumerator()
			{
				return null;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return null;
			}
		}

		[CompilerGenerated]
		private sealed class _003CGetOverlappingObjects_003Ed__15 : IEnumerable<GameObject>, IEnumerable, IEnumerator<GameObject>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private GameObject _003C_003E2__current;

			private int _003C_003El__initialThreadId;

			public CollisionDetector _003C_003E4__this;

			private List<GameObject>.Enumerator _003C_003E7__wrap1;

			private GameObject _003Csource_003E5__3;

			private Collider[] _003C_003E7__wrap3;

			private int _003C_003E7__wrap4;

			private IEnumerator<GameObject> _003C_003E7__wrap5;

			GameObject IEnumerator<GameObject>.Current
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
			public _003CGetOverlappingObjects_003Ed__15(int _003C_003E1__state)
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

			private void _003C_003Em__Finally1()
			{
			}

			private void _003C_003Em__Finally2()
			{
			}

			private void _003C_003Em__Finally3()
			{
			}

			[DebuggerHidden]
			void IEnumerator.Reset()
			{
			}

			[DebuggerHidden]
			IEnumerator<GameObject> IEnumerable<GameObject>.GetEnumerator()
			{
				return null;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return null;
			}
		}

		private List<GameObject> _ourCollisionObjects;

		private Buildable _buildable;

		private static int[] _invalidColliderLayers;

		private const float MESH_COLLIDER_OVERLAP_TOLERANCE = 0.01f;

		private List<GameObject> _previousOverlappingObjects;

		private Collider[] _objectsWithinCollider;

		private static int _staticObstaclesLayer;

		private int _lastFrame;

		public List<string> includedTags;

		public bool blocksAccessPoints;

		private bool _isColliding;

		private bool _isCollidingWithBuiltObjects;

		private static readonly string ParticleObstacleName;

		private CollisionState _collisionState;

		public List<GameObject> OurColliders { get; set; }

		public List<GameObject> CurrentColliders { get; private set; }

		private static int StaticObstaclesLayer => 0;

		public bool IsColliding
		{
			get
			{
				return false;
			}
			private set
			{
			}
		}

		public bool IsCollidingWithBuiltObjects
		{
			get
			{
				return false;
			}
			private set
			{
			}
		}

		public CollisionState MaxCollisionState
		{
			get
			{
				return default(CollisionState);
			}
			private set
			{
			}
		}

		public event EventHandler CollisionsChanged
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public event EventHandler CollisionsUpdated
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public void Awake()
		{
		}

		public void Update()
		{
		}

		[IteratorStateMachine(typeof(_003CGetOverlappingObjects_003Ed__15))]
		private IEnumerable<GameObject> GetOverlappingObjects()
		{
			return null;
		}

		[IteratorStateMachine(typeof(_003CGetObjectsWithinCollider_003Ed__20))]
		private IEnumerable<GameObject> GetObjectsWithinCollider(Collider col)
		{
			return null;
		}

		private void DrawWireCube(Vector3 center, Vector3 size, Quaternion rotation, Color color)
		{
		}

		public void CheckCollisionsSilently(bool forceAllCollidersToUpdate = false, bool forceRecheckThisFrame = false)
		{
		}

		private IEnumerable<GameObject> UpdateCollisionData(bool forceAllCollidersToUpdate, bool forceRecheckThisFrame, List<CollisionDetector> callers)
		{
			return null;
		}

		public void CheckCollisions(bool forceAllCollidersToUpdate = false, bool forceRecheckThisFrame = false, List<CollisionDetector> callers = null)
		{
		}

		private CollisionState GetCollisionState(GameObject gameobj)
		{
			return default(CollisionState);
		}

		public void CleanUp()
		{
		}

		public void OnDestroy()
		{
		}

		private void OnDrawGizmos()
		{
		}
	}
}
