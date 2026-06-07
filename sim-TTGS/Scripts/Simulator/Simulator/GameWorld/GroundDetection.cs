using System;
using UnityEngine;

namespace Simulator.GameWorld
{
	public class GroundDetection : MonoBehaviour
	{
		[Header("Ground Detection")]
		[SerializeField]
		private Transform m_groundCheckTransform;

		private readonly Collider[] m_overlapSphereResult = new Collider[1];

		public bool WasGrounded { get; private set; }

		public bool IsGrounded => m_overlapSphereResult[0] != null;

		public Collider GroundCollider => m_overlapSphereResult[0];

		public event Action<Collider> OnGrounded;

		public event Action OnUnGrounded;

		public void Refresh()
		{
			WasGrounded = IsGrounded;
			int overlapCount = Overlap();
			RefreshOverlapResult(overlapCount);
			OnRefresh();
		}

		private int Overlap()
		{
			return Physics.OverlapSphereNonAlloc(m_groundCheckTransform.position, PlayerMovementSettings.GroundCheckRadius, m_overlapSphereResult, PlayerMovementSettings.GroundCheckMask, QueryTriggerInteraction.Ignore);
		}

		private void RefreshOverlapResult(int overlapCount)
		{
			if (overlapCount == 0)
			{
				m_overlapSphereResult[0] = null;
			}
		}

		private void OnRefresh()
		{
			InvokeGroundEvents();
		}

		private void InvokeGroundEvents()
		{
			if (WasGrounded != IsGrounded)
			{
				if (IsGrounded)
				{
					this.OnGrounded?.Invoke(GroundCollider);
				}
				else
				{
					this.OnUnGrounded?.Invoke();
				}
			}
		}
	}
}
