using System.Collections.Generic;
using Coherence.Toolkit;
using DarkTonic.MasterAudio;
using UnityEngine;
using VampireSurvivors.App.Objects;
using VampireSurvivors.Data;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Graphics;

namespace VampireSurvivors.Objects.Characters.Enemies
{
	public class EnemySketamari : EnemyController
	{
		private GameObject _container;

		private List<SpriteRenderer> _containerChildren;

		private List<SpriteAnimation> _containerChildrenAnim;

		private float _radius;

		private EnemyType[] _enemiesArray;

		private PlaySoundResult _noise;

		private MultiTargetTween _onSineTween;

		private float _maxDistance;

		private MapToken _mapToken;

		private float _angle;

		private float _scale;

		private float _sineF;

		[Sync]
		public Quaternion ContainerRotation
		{
			get
			{
				return default(Quaternion);
			}
			set
			{
			}
		}

		public override void InitEnemy(EnemyType enemyType, bool asRemote)
		{
		}

		protected override void OnUpdate()
		{
		}

		private void MoveSketamari()
		{
		}

		protected override void Die()
		{
		}

		public override void Disappear()
		{
		}

		private float GetClosestPlayerDistance()
		{
			return 0f;
		}

		private float GetDistanceToMyPlayer()
		{
			return 0f;
		}

		private void MakeSpritesDisappear()
		{
		}

		private void CheckDirection()
		{
		}

		private void AddBones(int amount, float radiusMin, float radiusMax, float scaleMax, bool flipY)
		{
		}
	}
}
