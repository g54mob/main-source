using System;
using System.Collections.Generic;
using UnityEngine;
using VampireSurvivors.Framework.Geom;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Objects.Characters;

namespace VampireSurvivors.Objects.Stages
{
	public class BackgroundBoneZone : BackgroundManager
	{
		private float _elapsedTime;

		private float _elapsedTime2;

		private Circle _fixedCircle;

		private SpriteRenderer _groundFx;

		private List<Transform> _group;

		private List<Transform> _group2;

		private Transform _group1Parent;

		private Transform _group2Parent;

		public float _TweenTarget;

		public float _Tween2Target;

		private MultiTargetTween _tween;

		private MultiTargetTween _tween2;

		private MultiTargetTween _tween3;

		private Texture _normalMap;

		private VampireSurvivors.Objects.Characters.CharacterController Player => null;

		protected override void OnUpdate()
		{
		}

		public override void CustomPreload(Action onComplete)
		{
		}

		public override void Create()
		{
		}

		public override void OnInitCompleted()
		{
		}

		private void AddGroundFx(float x, float y)
		{
		}

		private void AddFlowers(float x, float y)
		{
		}
	}
}
