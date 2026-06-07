using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Graphics;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Characters.Enemies;
using VampireSurvivors.Objects.Items;
using VampireSurvivors.Objects.Pickups;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Stages
{
	[UsedImplicitly]
	public class Background5 : BackgroundManager
	{
		private float _wind;

		[HideInInspector]
		public float _TintHelp;

		private float _minuteValueMillis;

		private bool _hasKilledTheFinalBoss;

		private bool _hasTerraceBeenOpened;

		private Pickup _coffin;

		private BgmType _savedBgm;

		private EnemyTheEnder _ender;

		private EnemyDrownerNormal _drowner;

		private EnemyStalkerNormal _stalker;

		private EnemyStalkerNormal _trickster;

		private EnemyMaddenerNormal _maddener;

		private Transform _spritesRootTransform;

		private SpriteRenderer _snap;

		private SpriteAnimation _snapAnimation;

		private TileSprite _skyBlue;

		private TileSprite _skyRed;

		private GameObject _cloudsParent;

		private TileSprite _cloudsBlue;

		private TileSprite _cloudsWhite;

		private TileSprite _cloudsAddBlue;

		private TileSprite _cloudsAddRed;

		private TileSprite _cloudsRed;

		private SpriteRenderer _whiteFader;

		private SpriteRenderer _shootingRay;

		private SpriteRenderer _shootingRing;

		private TileSprite _floorLights;

		private TileSprite _skyLights;

		private SpriteRenderer _purpleOverlay;

		private SpriteRenderer _purpleOverlayAdd;

		private List<SpriteRenderer> _purpleClouds;

		private List<MultiTargetTween> _movingBgTweens;

		private MultiTargetTween _floorLightsTween;

		private MultiTargetTween _skyLightsTween;

		private List<EquipmentInfo> _playerEquipment;

		private bool _useReaperMinuteCheck;

		private Pickup _cosmoPavone;

		protected virtual bool AlwaysSpawnEnder => false;

		protected virtual bool DropGospel => false;

		protected virtual float EnderShieldTime => 0f;

		public WindowWeapon WindowWeapon { get; set; }

		protected override void OnDestroy()
		{
		}

		protected override void OnUpdate()
		{
		}

		public override void Create()
		{
		}

		private void OnRemoteItemInstantiated(Pickup item)
		{
		}

		private void OnMaddenerSpawned(GameObject enemy)
		{
		}

		private void OnRemoteEnemySpawned(EnemyController enemy)
		{
		}

		public override void Cleanup()
		{
		}

		public override void DisableMovingBackground()
		{
		}

		public override void EnableMovingBackground()
		{
		}

		private void GenerateSprites()
		{
		}

		private void SetupCoffinTrigger()
		{
		}

		private void SetupCosmoTrigger()
		{
		}

		private bool UpdateEnemyAndBossData()
		{
			return false;
		}

		private void SetDefaultEnemyAndBossData()
		{
		}

		public override void CheckMinute(int minute)
		{
		}

		private void OnTricksterSpawned(GameObject enemyTrickster)
		{
		}

		private void OnStalkerSpawned(GameObject enemyStalker)
		{
		}

		private void OnDrownerSpawned(GameObject enemy)
		{
		}

		private void SnapEggs()
		{
		}

		private void SnapYellows()
		{
		}

		public void PerformSnapYellows(PickupWeapon gRing, PickupWeapon sRing, PickupWeapon lMeta, PickupWeapon rMeta, VampireSurvivors.Objects.Characters.CharacterController player, Weapon cs, Weapon ic)
		{
		}

		private void TryRemoveStagePickup(Pickup pickup)
		{
		}

		private void RemovePowers(List<string> frames)
		{
		}

		private void EnterTheBossi()
		{
		}

		private void RemoveWalls()
		{
		}

		private void FadeOutSky()
		{
		}

		private void OnEnderSpawned(GameObject enemyEnder)
		{
		}

		private void PowerOfFriendshipGoPlanet()
		{
		}

		private void StaggerMoveReaper(int index, SpriteRenderer reaper)
		{
		}

		private void EnterPurpleSky()
		{
		}

		private void FadeOutPurpleSky()
		{
		}

		private void ShowPurpleOverlays()
		{
		}

		private void FadeToMad()
		{
		}

		private void RevertMad()
		{
		}

		private void ToggleBlue(bool visible)
		{
		}

		private void ToggleRed(bool visible)
		{
		}

		private void ToggleAlias(bool toggle)
		{
		}

		public void OpenTerrace()
		{
		}
	}
}
