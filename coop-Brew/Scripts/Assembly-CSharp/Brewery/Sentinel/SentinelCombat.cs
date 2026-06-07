using Pathfinding;
using Unity.Netcode;
using UnityEngine;

namespace Brewery.Sentinel
{
	public class SentinelCombat : NetworkBehaviour
	{
		[Header("Movement")]
		[SerializeField]
		private float moveSpeed;

		[SerializeField]
		private float rotationSpeed;

		[Header("Combat")]
		[SerializeField]
		private float attackCooldown;

		[SerializeField]
		private float attackDamage;

		[SerializeField]
		private int attackVariations;

		[Header("Hit Detection")]
		[SerializeField]
		private float hitRange;

		[SerializeField]
		private float hitAngle;

		[SerializeField]
		private Transform hitOrigin;

		[SerializeField]
		private LayerMask hitLayers;

		[Header("Components")]
		[SerializeField]
		private SentinelAnimator animator;

		private IAstarAI _ai;

		private Seeker _seeker;

		private float _lastAttackTime;

		private bool _isAttacking;

		private Transform _attackTarget;

		private bool _attackWindowOpen;

		public bool IsAttacking => false;

		private void Awake()
		{
		}

		public override void OnNetworkSpawn()
		{
		}

		private void Update()
		{
		}

		private void UpdateAnimatorSpeed()
		{
		}

		public void SetDestination(Vector3 destination)
		{
		}

		public void Stop()
		{
		}

		public void FaceTarget(Vector3 targetPosition)
		{
		}

		public void TryAttack(Transform target)
		{
		}

		private void StartAttack()
		{
		}

		public void OnAttackStart()
		{
		}

		public void OnHit()
		{
		}

		public void OnAttackEnd()
		{
		}

		private bool IsTargetInHitZone(Transform target)
		{
			return false;
		}

		private void DealDamage(Transform target)
		{
		}

		public void StopAttacking()
		{
		}

		private void OnDrawGizmosSelected()
		{
		}

		protected override void __initializeVariables()
		{
		}

		protected override void __initializeRpcs()
		{
		}

		protected internal override string __getTypeName()
		{
			return null;
		}
	}
}
