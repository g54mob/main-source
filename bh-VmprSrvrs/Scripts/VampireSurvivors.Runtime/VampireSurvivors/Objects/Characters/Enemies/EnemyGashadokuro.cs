using System.Collections.Generic;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Graphics;

namespace VampireSurvivors.Objects.Characters.Enemies
{
	public class EnemyGashadokuro : EnemyController
	{
		[SerializeField]
		private SpriteRenderer _FrontArm;

		[SerializeField]
		private SpriteAnimation _FrontArmAnim;

		[SerializeField]
		private SpriteRenderer _BackArm;

		[SerializeField]
		private SpriteAnimation _BackArmAnim;

		[SerializeField]
		private SpriteRenderer _Head;

		[SerializeField]
		private SpriteAnimation _HeadAnim;

		private Vector2 _frontOffset;

		private Vector2 _backOffset;

		private Vector2 _headOffset;

		private Vector2 _invFrontOffset;

		private Vector2 _invBackOffset;

		private Vector2 _invHeadOffset;

		private List<Sprite> _frameNamesArms;

		private List<Sprite> _frameNamesArmsDie;

		private List<Sprite> _frameNamesHead;

		private List<Sprite> _frameNamesHeadDie;

		private MultiTargetTween _armsSpinTween;

		private MultiTargetTween _speedTween;

		public float _SpeedMul;

		private Timer _spinTimer;

		private MultiTargetTween _armsSpinTween2;

		private MultiTargetTween _speedTween2;

		private Timer _summonTimer;

		private int _spiritsToSummon;

		private float _spinnnDelay;

		private float _summonTime;

		private float _summonDelay;

		private bool _spritesInitialised;

		private bool _hasLostTreasure;

		protected override void Awake()
		{
		}

		public override void InitEnemy(EnemyType enemyType, bool asRemote)
		{
		}

		private void InitSprites()
		{
		}

		private void PlayDeathAnimations()
		{
		}

		private void AndSpinnn()
		{
		}

		private void AndSummon()
		{
		}

		protected override void Die()
		{
		}

		private void MakeTreasureChest()
		{
		}

		public override void Disappear()
		{
		}

		public override void Despawn()
		{
		}

		protected override void OnUpdate()
		{
		}

		private void DrownerWarning()
		{
		}

		private void RedWarning()
		{
		}

		private void SingleWarning(float sizeX)
		{
		}
	}
}
