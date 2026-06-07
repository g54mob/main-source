using System.Collections.Generic;
using Coherence.Toolkit;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Framework.Phaser;

namespace VampireSurvivors.Objects.Characters.Enemies
{
	public class EnemyBeelzebub : EnemyController
	{
		private List<EnemyBeelzebubSection> _sections;

		private EnemyBeelzebubSection _head;

		private EnemyBeelzebubSection _leftArm;

		private EnemyBeelzebubSection _leftHand;

		private EnemyBeelzebubSection _rightArm;

		private EnemyBeelzebubSection _rightHand;

		private EnemyBeelzebubSection _leftThigh;

		private EnemyBeelzebubSection _leftLeg;

		private EnemyBeelzebubSection _rightThigh;

		private EnemyBeelzebubSection _rightLeg;

		private EnemyBeelzebubSection _belly;

		private List<EnemyBeelzebubBee> _beeList;

		private float _beeTimer;

		private PhaserSprite[] _torsoChains;

		private bool _isRunningDeathAnimation;

		public List<EnemyBeelzebubSection> Sections => null;

		[Sync]
		public GameObject Head
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
		public GameObject LeftArm
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
		public GameObject LeftHand
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
		public GameObject RightArm
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
		public GameObject RightHand
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
		public GameObject LeftThigh
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
		public GameObject LeftLeg
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
		public GameObject RightThigh
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
		public GameObject RightLeg
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
		public GameObject Belly
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public override void InitEnemy(EnemyType enemyType, bool asRemote)
		{
		}

		private void SpawnBodyParts()
		{
		}

		private void UpdateBodyParts()
		{
		}

		public override void Disappear()
		{
		}

		protected override void Die()
		{
		}

		public override void Despawn()
		{
		}

		public override void GetDamaged(float value, HitVfxType showHitVfx = HitVfxType.Default, float damageKb = 1f, WeaponType damageType = WeaponType.VOID, bool hasKb = true)
		{
		}

		protected override void OnUpdate()
		{
		}

		private void DoDeathAnimation()
		{
		}

		private void DropReward()
		{
		}
	}
}
