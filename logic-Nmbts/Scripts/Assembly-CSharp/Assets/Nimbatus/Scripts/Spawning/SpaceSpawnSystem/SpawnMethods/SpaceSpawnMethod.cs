using System;
using Assets.Nimbatus.Scripts.Characters.Player;
using Assets.Nimbatus.Scripts.Combat;
using Assets.Nimbatus.Scripts.Persistence;
using Assets.Nimbatus.Scripts.Spawning.PlanetSpawnSystem.SpawnMethods;
using Assets.Nimbatus.Scripts.WorldObjects;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Assets.Nimbatus.Scripts.Spawning.SpaceSpawnSystem.SpawnMethods
{
	public abstract class SpaceSpawnMethod
	{
		public ESpawnLayer ObjectPlacement;

		public bool IgnoreCollision;

		[HideIf("IgnoreCollision", true)]
		public float MinDistance = 10f;

		public ESpaceOriginPosition SpawnOrigin;

		public Vector2 Coordinates;

		protected System.Random RandomGenerator;

		public void Init(System.Random randomGenerator)
		{
			RandomGenerator = randomGenerator;
			Init();
		}

		public virtual void Init()
		{
		}

		protected Vector2 GetSpawnOrigin()
		{
			switch (SpawnOrigin)
			{
			case ESpaceOriginPosition.Coordinates:
				return Coordinates;
			case ESpaceOriginPosition.Drone:
				return (Vector2)RuntimeGlobals.NimbatusPlayer.transform.position + Coordinates;
			case ESpaceOriginPosition.Nimbatus:
				return (Vector2)NimbatusSpaceShip.Instance.transform.position + Coordinates;
			default:
				return Coordinates;
			}
		}

		public abstract InteractiveWorldObject TryToSpawn(InteractiveWorldObject objectToSpawn);

		public InteractiveWorldObject InstantiateSpawnObject(InteractiveWorldObject objectToSpawn, Vector2 position, Quaternion rotation)
		{
			float z = 0f;
			switch (ObjectPlacement)
			{
			case ESpawnLayer.Background:
				z = 1f;
				break;
			case ESpawnLayer.Foreground:
				z = -0.5f;
				break;
			}
			Vector3 position2 = new Vector3(position.x, position.y, z);
			if (!Physics.CheckSphere(position, MinDistance, BaseSingleton<CollisionLayerManager>.Instance.SpawnCheckLayerStructures) || IgnoreCollision)
			{
				InteractiveWorldObject interactiveWorldObject = UnityEngine.Object.Instantiate(objectToSpawn, position2, rotation);
				int seed = RandomGenerator.Next(int.MinValue, int.MaxValue);
				interactiveWorldObject.InitSpawn(seed);
				return interactiveWorldObject;
			}
			return null;
		}
	}
}
