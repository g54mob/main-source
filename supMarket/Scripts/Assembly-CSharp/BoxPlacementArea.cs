using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using PG;
using UnityEngine;

public class BoxPlacementArea : MonoBehaviour
{
	public struct RayResult
	{
		public Vector3 Position;

		public float Scale;
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass38_0
	{
		public Rigidbody rb;

		internal bool _003CDoBoxFallPhysicsSimulation_003Eb__0()
		{
			return false;
		}
	}

	[CompilerGenerated]
	private sealed class _003CDoBoxFallPhysicsSimulation_003Ed__38 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public IPlacementAreaPhysicsBody body;

		public BoxPlacementArea _003C_003E4__this;

		private _003C_003Ec__DisplayClass38_0 _003C_003E8__1;

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
		public _003CDoBoxFallPhysicsSimulation_003Ed__38(int _003C_003E1__state)
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

	[SerializeField]
	private float m_Height;

	private List<IPlacementAreaObject> m_Objects;

	private static Collider[] m_OverlapCache;

	private static RaycastHit[] m_HitCache;

	private const float SKIN_WIDTH = 0.01f;

	private Rigidbody m_AttachedRigidbody;

	private Collider[] m_RigidbodyColliders;

	private Dictionary<IPlacementAreaPhysicsBody, Coroutine> m_PhysicsCoroutinePairs;

	private BoxCollider m_Collider;

	[SerializeField]
	private bool m_Snap;

	[SerializeField]
	[ShowInInspectorIf("m_Snap")]
	private Vector3 m_SnapPosition;

	[SerializeField]
	[ShowInInspectorIf("m_Snap")]
	private Vector3 m_SnapEulerAngles;

	[SerializeField]
	private bool m_LimitExtents;

	[SerializeField]
	[ShowInInspectorIf("m_LimitExtents")]
	private Vector2 m_MaxAllowedExtents;

	[SerializeField]
	private PreventationStrategy m_PreventationStrategy;

	[SerializeField]
	private int m_MaxCount;

	[SerializeField]
	private bool m_AllowRotation;

	[SerializeField]
	private bool m_FitToArea;

	private List<IPlacementAreaObject> m_ReleaseQueue;

	public PreventationStrategy PreventationStrategy => default(PreventationStrategy);

	public bool AllowRotation => false;

	public event Action<IPlacementAreaObject> ObjectPlaced
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

	public event Action<IPlacementAreaObject> ObjectReleased
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

	private void Awake()
	{
	}

	public bool GetPointOn(Ray ray, Bounds placementBounds, out RayResult result)
	{
		result = default(RayResult);
		return false;
	}

	public bool CanBePlaced(IPlacementAreaObject obj)
	{
		return false;
	}

	public bool CheckOverlap(IPlacementAreaObject obj)
	{
		return false;
	}

	private void ToggleCollision(IPlacementAreaObject obj, bool value)
	{
	}

	public void Place(IPlacementAreaObject obj)
	{
	}

	public void Release(IPlacementAreaObject obj)
	{
	}

	private void CollectAllNeighbors(IPlacementAreaObject box)
	{
	}

	private void ActivatePhysicsFor(IPlacementAreaPhysicsBody physicsBody)
	{
	}

	[IteratorStateMachine(typeof(_003CDoBoxFallPhysicsSimulation_003Ed__38))]
	private IEnumerator DoBoxFallPhysicsSimulation(IPlacementAreaPhysicsBody body)
	{
		return null;
	}

	public void LoadObject(IPlacementAreaObject obj)
	{
	}

	public void LoadBox(Box box)
	{
	}

	public IEnumerable<IPlacementAreaObject> GetObjects()
	{
		return null;
	}

	public void AddReleaseBatch(IPlacementAreaObject obj)
	{
	}

	public IPlacementAreaObject DequeueFromReleaseBatch()
	{
		return null;
	}

	public void ApplyReleaseBatch()
	{
	}
}
