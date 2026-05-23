using UnityEngine;

namespace Battle
{
	public class DarkDragonMeteo : BaseEnemy
	{
		public HitEffect meteor;

		public HitEffect meteorOut;

		public LoopEffect symbol;

		public LoopEffect line;

		[SerializeField]
		private Transform lineEndPos;

		public float displayDelay;

		public override void Init()
		{
		}

		public override void EnemyUpdate(double deltaTime)
		{
		}

		public void InvincibleMode()
		{
		}

		public void PlayLineEffect(Vector3 targetPos)
		{
		}

		public void StopLineEffect()
		{
		}

		public override void DestroyObj()
		{
		}
	}
}
