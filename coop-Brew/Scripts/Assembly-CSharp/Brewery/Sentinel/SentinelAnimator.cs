using Unity.Netcode;
using UnityEngine;

namespace Brewery.Sentinel
{
	[RequireComponent(typeof(Animator))]
	public class SentinelAnimator : NetworkBehaviour
	{
		[Header("Components")]
		[SerializeField]
		private Animator animator;

		[Header("Settings")]
		[SerializeField]
		private float speedSmoothing;

		[SerializeField]
		private string combatLayerName;

		[Header("Debug")]
		[SerializeField]
		private bool showDebugLogs;

		private static readonly int MoveSpeedHash;

		private static readonly int CurrentGaitHash;

		private static readonly int IsGroundedHash;

		private static readonly int InCombatHash;

		private static readonly int IsUnarmedAttackingHash;

		private static readonly int UnarmedAttackIndexHash;

		private int _combatLayerIndex;

		private float _currentCombatWeight;

		private float _targetCombatWeight;

		private float _smoothedSpeed;

		private const float CombatWeightTransitionSpeed = 5f;

		public bool IsCombatActive => false;

		private void Awake()
		{
		}

		private void Start()
		{
		}

		private void FindCombatLayer()
		{
		}

		private void Update()
		{
		}

		private void UpdateCombatLayerWeight()
		{
		}

		public void SetMoveSpeed(float speed)
		{
		}

		public void SetCombatMode(bool inCombat)
		{
		}

		public void TriggerAttack(int attackIndex)
		{
		}

		public void CancelAttack()
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
