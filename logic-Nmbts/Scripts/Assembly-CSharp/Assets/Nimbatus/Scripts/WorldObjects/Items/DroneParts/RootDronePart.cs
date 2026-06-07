using System.Collections;
using System.Collections.Generic;
using Assets.Nimbatus.Scripts.GalaxyMap.Boss;
using Assets.Nimbatus.Scripts.GalaxyMap.Race;
using Assets.Nimbatus.Scripts.GalaxyMap.Tournaments;
using Assets.Nimbatus.Scripts.Missions;
using Assets.Nimbatus.Scripts.Persistence;
using Assets.Nimbatus.Scripts.Persistence.Achievements;
using Assets.Nimbatus.Scripts.ResourceCollection;
using Assets.Nimbatus.Scripts.Tutorial.TutorialScenes;
using Assets.Nimbatus.Scripts.World.Terrain.Common;
using Assets.Nimbatus.Scripts.WorldObjects.Items.DroneParts.SensorParts;
using UnityEngine;

namespace Assets.Nimbatus.Scripts.WorldObjects.Items.DroneParts
{
	public class RootDronePart : BindableDronePart, IHasEventKeyHub, IHasResourceHub
	{
		private KeyBinding _explodeKeyBind;

		public float HighestVelocity { get; private set; }

		public float HighestAngularVelocity { get; private set; }

		public float CurrentVelocity { get; private set; }

		public float CurrentAngularVelocity { get; private set; }

		[HideInInspector]
		public new EventKeyHub KeyEventHub { get; private set; }

		[HideInInspector]
		public ResourceHub ResourceHub { get; private set; }

		public override List<KeyBinding> GetKeyBindings()
		{
			_explodeKeyBind = new KeyBinding("Explode", KeyCode.None);
			return new List<KeyBinding> { _explodeKeyBind };
		}

		protected override void Awake()
		{
			base.Awake();
			IsDraggable = false;
			Unlocked = true;
			HealthPool.Heal(HealthPool.ActiveMaxHealth);
			if (Joint != null)
			{
				Joint.breakForce = float.PositiveInfinity;
			}
			foreach (KeyValuePair<tk2dSprite, Color> sprite in Sprites)
			{
				sprite.Key.GetComponent<Renderer>().enabled = true;
			}
			KeyEventHub = base.gameObject.AddComponent<EventKeyHub>();
			KeyEventHub.CheckInput = true;
			ResourceHub = new ResourceHub();
			ResourceHub.Init();
		}

		protected override void DronePartBreak()
		{
			base.DronePartBreak();
			if (IsBroken)
			{
				return;
			}
			ResourceHub.Reset();
			Vector3 position = base.transform.position;
			position.z = 0f;
			List<Collider> list = new List<Collider>();
			list.AddRange(Physics.OverlapSphere(position, 30f));
			HashSet<GameObject> hashSet = new HashSet<GameObject>();
			foreach (Collider item in list)
			{
				if (item != null && item.attachedRigidbody != null && !item.isTrigger && !hashSet.Contains(item.gameObject))
				{
					item.attachedRigidbody.AddExplosionForce(150f, position, 30f);
					hashSet.Add(item.gameObject);
				}
			}
			if (ExplosionEffect != null)
			{
				ExplosionEffect.PlayEffect(base.transform);
			}
			TerrainModificationHelper.LerpRemoveTerrainSphere(RuntimeGlobals.WorldController.ForeGroundTerrain, position, 30f, 0f);
			Explode();
		}

		public IEnumerator GameOver()
		{
			if (!Activated)
			{
				yield break;
			}
			switch (RuntimeGlobals.RunningMode)
			{
			case ERunningMode.Normal:
			case ERunningMode.Space:
				SerializableMonobehaviour<MissionManager, MissionData>.Instance.PlayerDroneDestroyed();
				break;
			case ERunningMode.BossFight:
				if (BossfightManager.Instance != null)
				{
					BossfightManager.Instance.GameOver();
				}
				break;
			case ERunningMode.Tutorial:
				if (GenericTutorialLogic.Instance != null)
				{
					GenericTutorialLogic.Instance.IsDroneDead = true;
				}
				break;
			}
			foreach (KeyValuePair<tk2dSprite, Color> sprite in Sprites)
			{
				sprite.Key.GetComponent<Renderer>().enabled = false;
			}
			yield return new WaitForSeconds(3f);
			if (RuntimeGlobals.GameMode == EGameMode.Campaign)
			{
				BaseSingleton<AchievementManager>.Instance.UnlockAchievement(EAchievement.RealNimbatus);
			}
			Activated = false;
			if (BaseRaceManager.Instance == null)
			{
				RuntimeGlobals.IsGameOver = true;
			}
		}

		public override void Update()
		{
			base.Update();
			if (!IsBroken && CanControlDrone && !RuntimeGlobals.IsGamePaused && Activated)
			{
				ResourceHub.Update();
				if (_explodeKeyBind.IsPressed(KeyEventHub))
				{
					BaseSingleton<AchievementManager>.Instance.UnlockAchievement(EAchievement.SelfDestruction);
					Explode();
				}
			}
		}

		public override void FixedUpdate()
		{
			base.FixedUpdate();
			if (GlobalSerializableMonobehaviour<TournamentManager, TournamentManagerSaveData>.Instance.ActiveTournament != null && !GlobalSerializableMonobehaviour<TournamentManager, TournamentManagerSaveData>.Instance.IsInTraining && GlobalSerializableMonobehaviour<TournamentManager, TournamentManagerSaveData>.Instance.ActiveTournament.GetCurrentDrone() != null && GlobalSerializableMonobehaviour<TournamentManager, TournamentManagerSaveData>.Instance.ActiveTournament.GetCurrentDrone().UniqueId == RootDrone.DroneData.UniqueId)
			{
				TournamentStatistics.CurrentMaxAngularVelocity = Mathf.Max(TournamentStatistics.CurrentMaxAngularVelocity, Rigidbody.angularVelocity.magnitude);
				TournamentStatistics.CurrentMaxVelocity = Mathf.Max(TournamentStatistics.CurrentMaxVelocity, Rigidbody.velocity.magnitude);
			}
			CurrentVelocity = Rigidbody.velocity.magnitude;
			CurrentAngularVelocity = Rigidbody.angularVelocity.magnitude * 57.29578f;
			if (CurrentVelocity > HighestVelocity)
			{
				HighestVelocity = CurrentVelocity;
			}
			if (CurrentAngularVelocity > HighestAngularVelocity)
			{
				HighestAngularVelocity = CurrentAngularVelocity;
			}
			if (!RootDrone.DroneData.IsOpponentDrone)
			{
				if (CurrentVelocity >= 450f)
				{
					BaseSingleton<AchievementManager>.Instance.UnlockAchievement(EAchievement.AimForTheTop);
				}
				if (CurrentAngularVelocity >= 2000f)
				{
					BaseSingleton<AchievementManager>.Instance.UnlockAchievement(EAchievement.LetItRip);
				}
			}
		}

		private void Explode()
		{
			HealthPool.Die();
			StartCoroutine(GameOver());
		}

		public void ChangeParentHub(ResourceHub newParent)
		{
		}
	}
}
