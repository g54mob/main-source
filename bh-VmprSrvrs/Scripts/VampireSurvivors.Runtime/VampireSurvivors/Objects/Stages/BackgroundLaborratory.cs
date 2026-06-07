using System.Collections.Generic;
using SuperTiled2Unity;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Data.Stage;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Items;
using VampireSurvivors.Objects.Props;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Stages
{
	public class BackgroundLaborratory : BackgroundManager
	{
		private float2 _TrainCoords;

		private List<Vector2> _leverLocations;

		private List<Vector2> _leverLocations2;

		private List<Vector2> _leverLocations3;

		private List<Vector2> _leverLocations4;

		private List<SuperObject> _doorScriptsA;

		private List<SuperObject> _doorScriptsB;

		private List<Vector2> _doorLocationsA;

		private List<Vector2> _doorLocationsB;

		private List<PropLeverTrain> _AllLevers;

		private List<Destructible> _AllDoors;

		private Timer _checkLeversTimer;

		private TilingTileset _tilingTileset;

		private List<Destructible> _spawnedLevers;

		private Timer _trainLeversTimer;

		private float _trainLeversFrequency;

		private float _leverChance;

		private Timer _itemLeversTimer;

		private float _lever2Chance;

		private float _lever3Chance;

		private float _lever4Chance;

		private float _leverMaxSuccessRate;

		private float _leverDefaultSuccessRate;

		private int _centralLeverPulledTimes;

		private VampireSurvivors.Data.Stage.Event Event_YellowReapers;

		private VampireSurvivors.Data.Stage.Event Event_ExplodingAngels;

		private VampireSurvivors.Data.Stage.Event Event_Trinacrias;

		private VampireSurvivors.Data.Stage.Event Event_EyeSwarm;

		private List<EnemyType> MinorEvent_EnemyTypes;

		private List<VampireSurvivors.Data.Stage.Event> SpecialEvent_Types;

		public TrainHazardWeapon TrainWeapon { get; set; }

		public override void Awake()
		{
		}

		public override void Create()
		{
		}

		public override void OnPropTriggered(PropType propType, PizzaCircle pizzaCircle, VampireSurvivors.Objects.Characters.CharacterController player)
		{
		}

		public void ManageSpawning(ref List<WeaponType> weaponChoice, ref List<ItemType> itemChoice, ref List<EnemyType> enemyChoice, ref PizzaCircle pizzaCircle, bool specialEvents = false)
		{
		}

		public void ManageGuardians(PickupGuarded pickupGuard, WeaponType wType)
		{
		}

		public override void OnInitCompleted()
		{
		}

		private void TryToSpawnTrainLevers()
		{
		}

		private void TryToSpawnLabLevers()
		{
		}

		private void SeparateLevers()
		{
		}

		private void TryToSpawnDoors()
		{
		}

		private void SeparateDoors()
		{
		}

		public override void OnPlayerEnteringDifferentTilemap()
		{
		}

		protected override void OnUpdate()
		{
		}

		public override void Cleanup()
		{
		}
	}
}
