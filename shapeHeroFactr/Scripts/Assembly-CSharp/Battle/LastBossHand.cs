using UnityEngine;

namespace Battle
{
	public class LastBossHand : BaseEnemy
	{
		[SerializeField]
		private HitEffect attackEffect;

		[SerializeField]
		private Vector3 punchGoalPos;

		private bool _arrivedCharge;

		private double _sinkTimer;

		private float _defaultSpeed;

		private bool _isCancel;

		public LastBoss Parent { get; private set; }

		public bool IsLeft { get; private set; }

		public bool IsFinishPunch { get; private set; }

		private bool CheckGateDistance => false;

		public override void EnemyUpdate(double deltaTime)
		{
		}

		public override void Init()
		{
		}

		public void SetParent(LastBoss parent, EnemyBaseInfo status, bool isLeft)
		{
		}

		public void StartPunch()
		{
		}

		public void FinishPunch()
		{
		}

		public void CancelPunch()
		{
		}

		protected override void AttackTown()
		{
		}

		public override bool ReceiveDamage(int unitAttackPoint, eLuggage giverLuggage, bool displayDamage = true, bool isAdditionalDamage = true)
		{
			return false;
		}

		public override bool ReceiveStatusDamage(int damagePoint, eLuggage giverLuggage, SpriteNo.eDamageType damageType, bool displayDamage = true)
		{
			return false;
		}

		public override void DestroyObj()
		{
		}

		public void HitEffectHand()
		{
		}
	}
}
