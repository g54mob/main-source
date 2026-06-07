using System;
using System.Collections.Generic;
using SuperTiled2Unity;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Data.Stage;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Pickups;
using VampireSurvivors.Signals;
using Zenject;

namespace VampireSurvivors.Objects.Stages
{
	public class BackgroundManager : GameMonoBehaviour
	{
		protected Camera _mainCamera;

		public Bounds _camBounds;

		protected SignalBus _signalBus;

		protected float _pickupLimitX;

		protected float _pickupRecycleOffset;

		public float RacingBoundsMinY;

		public float RacingBoundsMaxY;

		public float RacingBoundsFlyingEnemiesY;

		public float CharmMod;

		public float CurseMod;

		public Stack<SuperTile> dynamicWallTiles;

		private bool IsBackgroundActive { get; set; }

		public bool Alias { get; protected set; }

		public bool HasMovingBg { get; protected set; }

		public bool DisableMovingBg { get; set; }

		public PhaserScene scene => null;

		public virtual bool SpawnEnemiesOnStart => false;

		public int xxlBatsDefeated { get; set; }

		public virtual void Awake()
		{
		}

		protected override void OnDestroy()
		{
		}

		protected override void OnUpdate()
		{
		}

		public virtual void Create()
		{
		}

		public virtual void OnInitCompleted()
		{
		}

		public virtual void CustomPreload(Action onComplete)
		{
		}

		public virtual void Cleanup()
		{
		}

		public virtual void RosaryTriggered()
		{
		}

		private void ToggleMovingBackground(UISignals.ToggleMovingBackgroundSignal sig)
		{
		}

		private void HandleDisableMovingBackground()
		{
		}

		public virtual void CheckMinute(int minute)
		{
		}

		public virtual void DisableMovingBackground()
		{
		}

		public virtual void EnableMovingBackground()
		{
		}

		public virtual void CheckHalfMinute()
		{
		}

		public virtual void OnPropTriggered(PropType propType, PizzaCircle pizzaCircle, VampireSurvivors.Objects.Characters.CharacterController player)
		{
		}

		public virtual void OnItemTriggered(ItemType itemType, Pickup pickup, VampireSurvivors.Objects.Characters.CharacterController player)
		{
		}

		public virtual void OnPlayerEnteringDifferentTilemap()
		{
		}

		public void ResetPickupPositions()
		{
		}

		public virtual void LoopPickupPositions()
		{
		}

		public virtual void InitPickupForLoopingStage(Pickup pickup)
		{
		}

		public virtual string GetDetailedMap(StageData stageData)
		{
			return null;
		}

		public virtual string GetDetailedMapStaticBackgroundImage(StageData stageData)
		{
			return null;
		}

		public virtual void SetupDarknessFog(ref PhaserSprite fog, ref PhaserSprite fogEdgeA, ref PhaserSprite fogEdgeB)
		{
		}

		public void ContainWithinRacingBounds(Transform target)
		{
		}

		public virtual bool ShouldPlayNormalMusic()
		{
			return false;
		}

		public virtual void OnFollowerAdded(VampireSurvivors.Objects.Characters.CharacterController character)
		{
		}

		public virtual float GetKillRatio()
		{
			return 0f;
		}

		public virtual bool ShouldShowCursor(float2 position)
		{
			return false;
		}

		public virtual bool HasCustomMapRules()
		{
			return false;
		}

		public virtual bool HasCustomMadGrooveRestriction()
		{
			return false;
		}

		public virtual bool IsPositionPulledByMadGroove(float2 position)
		{
			return false;
		}

		public virtual bool HasExtraSafeXYLogic()
		{
			return false;
		}

		public virtual float2 ExtraSafeXY(float2 position, float2 playerPosition)
		{
			return default(float2);
		}

		public virtual float GetMap_SizeX()
		{
			return 0f;
		}

		public virtual float GetMap_SizeY()
		{
			return 0f;
		}

		public virtual float2 GetMap_PlayerPos()
		{
			return default(float2);
		}

		public virtual int GetMap_SupportHorizontal()
		{
			return 0;
		}

		public virtual bool GetMap_DrawGrid()
		{
			return false;
		}

		public virtual bool ShouldShowPickupIconOnMap(Vector3 worldPosition)
		{
			return false;
		}

		public Vector2 GetPlayerStartingPosition()
		{
			return default(Vector2);
		}
	}
}
