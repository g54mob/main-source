using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using __Project__.Scripts.Multiplayer.NetworkInteractions;
using __Project__.Scripts.WallPaintSystem;

public class PlayerObjectHolder : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003CPlacingModeRoutine_003Ed__32 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public PlayerObjectHolder _003C_003E4__this;

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
		public _003CPlacingModeRoutine_003Ed__32(int _003C_003E1__state)
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
	private Transform m_ObjectHolder;

	[SerializeField]
	private float m_MaxDistance;

	[SerializeField]
	private float m_MaxVerticleAngleAllowed;

	[SerializeField]
	private float m_AngleSnapValue;

	[SerializeField]
	[Range(0f, 1f)]
	private float m_MovingObjectSmoothness;

	[SerializeField]
	private Material m_HologramMaterial;

	[SerializeField]
	private LayerMask m_PlacingLayer;

	private GameObject m_CurrentObject;

	private Camera m_Camera;

	private IPlacingMode m_CurrentPlacingMode;

	private bool m_PlacingMode;

	private LayerMask m_CurrentObjectsLayer;

	private Ray m_Ray;

	private RaycastHit m_HitInfo;

	private Quaternion m_Rotation;

	private float m_Angle;

	private Vector3 m_PositionOffset;

	private Vector3 m_RotationOffset;

	private Rigidbody m_Rigidbody;

	private PlayerInstance m_PlayerInstance;

	private Coroutine m_PlacingCoroutine;

	private NetworkPlayerObjectHolder m_NetworkPlayerObjectHolder;

	public GameObject CurrentObject
	{
		get
		{
			return null;
		}
		set
		{
		}
	}

	public bool PlacingMode
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	public Camera PlayerCamera
	{
		get
		{
			return null;
		}
		set
		{
		}
	}

	private void Awake()
	{
	}

	[IteratorStateMachine(typeof(_003CPlacingModeRoutine_003Ed__32))]
	private IEnumerator PlacingModeRoutine()
	{
		return null;
	}

	public void HoldObject(GameObject item, Vector3 positionOffset, Vector3 rotationOffset)
	{
	}

	public void StartPlacingMode(string userID = "")
	{
	}

	public bool TryDropObject()
	{
		return false;
	}

	public void DropObject()
	{
	}

	public void CancelPlacingMode()
	{
	}

	public void CancelPlacingMode(PaintBucket bucket)
	{
	}

	public void CancelPlacingMode(IceCreamBucket bucket)
	{
	}

	public bool TryThrowObject()
	{
		return false;
	}

	public bool CanThrow()
	{
		return false;
	}

	public void ThrowObject()
	{
	}

	private void NetworkRigidbodySetter()
	{
	}

	public void ThrowObjectToBin()
	{
	}

	public void PlaceBoxToRack()
	{
	}

	public void Rotate(bool clockvise)
	{
	}

	private void PlacingRaycast()
	{
	}

	private void MoveToCarryingPosition()
	{
	}

	private float GetNearestSnapAngle(float angle)
	{
		return 0f;
	}

	public bool ReleaseObject()
	{
		return false;
	}

	public void SetNullCurrentObject()
	{
	}

	private void NetworkUpdateObjectParent(bool isParentNull)
	{
	}
}
