using Coherence.Toolkit;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.PhaserTweens;

namespace VampireSurvivors.Objects.Characters.Enemies
{
	public class EnemyDSkull : EnemyDMask
	{
		[SerializeField]
		private PhaserSprite _EyesSprite;

		private MultiTargetTween _eyesFadeTween;

		private MultiTargetTween _onEnterTween;

		[Sync]
		public string EyesSprite
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		[Sync]
		public bool FlipX
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		protected override void OnUpdate()
		{
		}

		public override void InitEnemy(EnemyType enemyType, bool asRemote)
		{
		}

		public override void Despawn()
		{
		}

		public void SetEyes(string frameName = null)
		{
		}

		protected override void UpdateDepth()
		{
		}
	}
}
