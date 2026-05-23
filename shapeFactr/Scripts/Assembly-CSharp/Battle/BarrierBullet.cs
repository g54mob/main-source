using DG.Tweening;
using UnityEngine;

namespace Battle
{
	public class BarrierBullet : EnemyBaseBullet
	{
		private Barrier _barrier;

		private static readonly int PROPERTY_ADDITIVE_COLOR;

		[SerializeField]
		private MeshRenderer _renderer;

		private Material _material;

		private Sequence _seq;

		public override void Init()
		{
		}

		protected override void InitAdditionalParameter(BaseBullet bullet)
		{
		}

		public override void UpdateBullet(double deltatime)
		{
		}

		public override bool ReceiveDamage(int unitAttackPoint, eLuggage giverLuggage, bool displayDamage = true, bool isAdditionalDamage = true)
		{
			return false;
		}

		private void HitEffect()
		{
		}

		public override void DestroyObj()
		{
		}
	}
}
