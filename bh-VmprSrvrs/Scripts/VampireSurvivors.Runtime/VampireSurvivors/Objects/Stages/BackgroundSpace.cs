using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Tilemaps;
using VampireSurvivors.Data;
using VampireSurvivors.Framework.Geom;
using VampireSurvivors.Framework.Particles;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Graphics;
using VampireSurvivors.Objects.Pickups;

namespace VampireSurvivors.Objects.Stages
{
	public class BackgroundSpace : BackgroundManager
	{
		private TileSprite _stars2;

		private TileSprite _starsA;

		private TileSprite _starsB;

		private TileSprite _starsC;

		private TileSprite _starsD;

		private float _yMul;

		private BgmType _saveBgm;

		private BgmModType _saveBgmMod;

		private float _speedFactor;

		private int alphaMinuteStart;

		private List<Tilemap> stageTilemaps;

		private bool _spawnBraveStory;

		private bool _checkHeartDistance;

		private float2 relicPosition;

		private float2 _center;

		protected PhaserSprite _zodiacSprite;

		private MultiTargetTween _tween1;

		private MultiTargetTween _tween2;

		private MultiTargetTween _tween3;

		private float _value;

		private Pickup _spawnedBraveStoryRelic;

		private ParticleSystem _pfxSnowEmitter;

		private ParticleEmitterManager _pfxManager;

		private List<MultiTargetTween> spaceTweens;

		private bool _spaceTweensActive;

		private Circle _heartCircle;

		private PhaserSprite _heartSprite;

		public override void Create()
		{
		}

		public override void OnInitCompleted()
		{
		}

		private void GetCenter()
		{
		}

		protected override void OnUpdate()
		{
		}

		public override void CheckMinute(int minute)
		{
		}

		public void StartSpaceTweens()
		{
		}

		public override void Cleanup()
		{
		}

		public override void EnableMovingBackground()
		{
		}

		public override void DisableMovingBackground()
		{
		}
	}
}
