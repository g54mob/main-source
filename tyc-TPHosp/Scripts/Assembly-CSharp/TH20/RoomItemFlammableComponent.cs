#define LOG_LEVEL_VERBOSE
using System;
using BehaviorDesigner.Runtime;
using FullInspector;
using JetBrains.Annotations;
using UnityEngine;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class RoomItemFlammableComponent : EntityTickComponent
	{
		[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
		public class ConfigData
		{
			public SharedInstance<CharacterStatusEffectDefinition> StatusEffectJanitor;

			public SharedInstance<CharacterStatusEffectDefinition> StatusEffectPanic;

			public SharedInstance<CharacterStatusEffectDefinition> StatusEffectInjured;

			public ExternalBehavior EnterRoomBehaviour;

			public ExternalBehavior PickupExtinguisherBehaviour;

			public ExternalBehavior PutOutFireBehaviour;

			public ExternalBehavior MoveToFireBehavior;

			public ExternalBehavior PanicBehaviour;

			public int DebrisCount;

			public SharedInstance<RoomItemDefinition>[] DebrisPieces;

			public int DebrisEffectCount;

			public float DebrisEffectVelocity;

			public SharedInstance<MachineDebrisDefinition>[] DebrisEffectPieces;

			public float CameraShakeDuration = 1f;

			public float CameraShakeSpeed = 20f;

			public float CameraShakeMagnitude = 2f;

			public GameObject ExplosionEffect;

			public float ExplosionEffectTime = 10f;

			public float WreckageDelay = 0.5f;

			public bool TriggerGameEvents = true;

			public bool TriggerAudioEventOnExplode = true;

			public bool ThrowCharactersOutOfRoom = true;
		}

		[Serializable]
		public class ComponentConfig
		{
			public float _rateOfDamage;

			public SharedInstance<ConfigData> _config;

			public SharedInstance<RoomItemDefinition> _wreckage;

			public LocalisedString _advisorOnFireMessage;

			public LocalisedString _advisorExplodedMessage;
		}

		[SerializeField]
		private ComponentConfig _componentConfig;

		[DontSave]
		private AudioEmitter _fireAudioEmitter;

		private RoomItem _roomItem;

		private LookAtPOI _lookAtPOI;

		private bool _onFire;

		private float _wreckageDelay;

		public Job Job { get; set; }

		public ConfigData Config => _componentConfig._config.Instance;

		public bool IsOnFire => _onFire;

		public LocalisedString AdvisorOnFireMessage => _componentConfig._advisorOnFireMessage;

		public LocalisedString AdvisorExplodedMessage => _componentConfig._advisorExplodedMessage;

		protected override Type ValidEntityType()
		{
			return typeof(RoomItem);
		}

		internal override void InitializeComponent()
		{
			base.InitializeComponent();
			_roomItem = GetOwner<RoomItem>();
			SetupVisualData();
		}

		private void SetupVisualData()
		{
			if (_roomItem.Visual == null)
			{
				_roomItem.OnVisualSet += OnRoomItemVisualSet;
			}
			else
			{
				BindCallbacks();
			}
		}

		private void OnRoomItemVisualSet()
		{
			_roomItem.OnVisualSet -= OnRoomItemVisualSet;
			BindCallbacks();
		}

		public override void Destroy()
		{
			RemoveLookAt();
			if (_fireAudioEmitter != null)
			{
				_fireAudioEmitter.Stop();
			}
			if (_onFire)
			{
				_roomItem.Level.BuildEvents.OnRoomItemExtinguished.InvokeSafe(_roomItem);
			}
			base.Destroy();
		}

		internal override void RestoreComponentFromSave()
		{
			base.RestoreComponentFromSave();
			SetupVisualData();
			if (_lookAtPOI != null)
			{
				_lookAtPOI.RestoreFromSave(GetOwner().Level.EntityManager);
			}
		}

		private void BindCallbacks()
		{
			bool checkCallback = !base.Level.App.IsRestoringFromSave;
			if (_roomItem.FloorPlan != null && !(_roomItem.FloorPlan is BlueprintFloorPlan) && _roomItem.MaintenanceLevel != null)
			{
				_roomItem.MaintenanceLevel.GreaterThan(GameAlgorithms.Config.ItemSmokingThreshold, StartSmoking, checkCallback: true);
				_roomItem.MaintenanceLevel.LessThan(GameAlgorithms.Config.ItemSmokingThreshold, StopSmoking, checkCallback: true);
				_roomItem.MaintenanceLevel.GreaterThan(GameAlgorithms.Config.ItemSetOnFireThreshold, StartFire, checkCallback: true);
				_roomItem.MaintenanceLevel.LessThan(GameAlgorithms.Config.ItemSetOnFireThreshold, StopFire, checkCallback: true);
				_roomItem.MaintenanceLevel.Equals(100f, Explode, checkCallback);
			}
		}

		private ParticleEffectControlComponent GetEffectComponent()
		{
			ParticleEffectControlComponent component = _roomItem.Visual.GameObject.GetComponent<ParticleEffectControlComponent>();
			if (component == null)
			{
				Logging.Error(LogChannels.Gameplay, "ParticleEffectControlComponent missing in {0}", _roomItem);
			}
			return component;
		}

		private void StartSmoking()
		{
			ParticleEffectControlComponent effectComponent = GetEffectComponent();
			if (effectComponent != null)
			{
				effectComponent.EnableEffect("Smoke", enable: true);
			}
		}

		private void StopSmoking()
		{
			ParticleEffectControlComponent effectComponent = GetEffectComponent();
			if (effectComponent != null)
			{
				effectComponent.EnableEffect("Smoke", enable: false);
			}
		}

		private void StartFire()
		{
			Level level = _roomItem.Level;
			ParticleEffectControlComponent effectComponent = GetEffectComponent();
			_onFire = true;
			if (_fireAudioEmitter != null)
			{
				_fireAudioEmitter.Stop();
			}
			_fireAudioEmitter = AudioManager.Instance.Play("FireLoop", _roomItem.Visual.GameObject);
			StopSmoking();
			if (effectComponent != null)
			{
				effectComponent.EnableEffect("Fire", enable: true);
			}
			if (!base.Level.App.IsRestoringFromSave)
			{
				level.BuildEvents.OnRoomItemOnFire.InvokeSafe(_roomItem, this);
				level.ObjectiveEvents.OnGameEvent.InvokeSafe(ObjectiveGameEvent.MachineOnFire);
				if (Config.StatusEffectPanic.NotNull())
				{
					CharacterStatusEffectDefinition instance = Config.StatusEffectPanic.Instance;
					foreach (Staff staffMember in _roomItem.OwningRoom.StaffMembers)
					{
						if (staffMember.ModifiersComponent != null)
						{
							staffMember.ModifiersComponent.AddStatusEffect(instance);
						}
						if (staffMember.InteractionInterruptable && staffMember.Interaction != null)
						{
							staffMember.Interaction.EndInteraction(staffMember);
						}
					}
					foreach (Character item in _roomItem.OwningRoom.CharactersUsing)
					{
						if (item.ModifiersComponent != null)
						{
							item.ModifiersComponent.AddStatusEffect(instance);
							if (item.InteractionInterruptable && item.Interaction != null)
							{
								item.Interaction.EndInteraction(item);
							}
						}
					}
				}
				AddLookAt();
			}
			else if (Job != null)
			{
				level.StaffWorkScheduler.AddJob(Job);
			}
		}

		private void StopFire()
		{
			ParticleEffectControlComponent effectComponent = GetEffectComponent();
			_onFire = false;
			if (_fireAudioEmitter != null)
			{
				_fireAudioEmitter.Stop();
			}
			if (effectComponent != null)
			{
				effectComponent.EnableEffect("Fire", enable: false);
			}
			RemoveLookAt();
			_roomItem.Level.BuildEvents.OnRoomItemExtinguished.InvokeSafe(_roomItem);
			if (_roomItem.MaintenanceLevel != null && _roomItem.MaintenanceLevel.Value() > GameAlgorithms.Config.ItemSmokingThreshold)
			{
				StartSmoking();
			}
		}

		private void AddLookAt()
		{
			if (_lookAtPOI == null)
			{
				_lookAtPOI = new LookAtPOI(GetOwner().GetOrAddComponent<RoomItemLookAtPOISourceComponent>(), 6f, 10f);
				_roomItem.Level.CharacterLookAtManager.AddGlobalPOI(_lookAtPOI);
			}
		}

		private void RemoveLookAt()
		{
			if (_lookAtPOI != null)
			{
				_roomItem.Level.CharacterLookAtManager.RemoveGlobalPOI(_lookAtPOI);
				_lookAtPOI = null;
			}
		}

		private void Explode()
		{
			if (Config.TriggerAudioEventOnExplode)
			{
				AudioManager.Instance.Play("MachineExplosions", _roomItem.Visual.GameObject);
			}
			if (Config.ThrowCharactersOutOfRoom)
			{
				for (int num = _roomItem.OwningRoom.StaffMembers.Count - 1; num >= 0; num--)
				{
					ThrowCharacterOutOfRoom(_roomItem.OwningRoom.StaffMembers[num]);
				}
				for (int num2 = _roomItem.OwningRoom.CharactersUsing.Count - 1; num2 >= 0; num2--)
				{
					ThrowCharacterOutOfRoom(_roomItem.OwningRoom.CharactersUsing[num2]);
				}
			}
			Level level = _roomItem.Level;
			Room owningRoom = _roomItem.OwningRoom;
			Vector3 worldPosition = _roomItem.WorldPosition;
			if (Camera.main != null && Camera.main.gameObject != null)
			{
				Camera.main.gameObject.AddComponent<CameraShakeEffectComponent>().Shake(Config.CameraShakeDuration, Config.CameraShakeSpeed, Config.CameraShakeMagnitude, position: true, rotation: false);
			}
			if (Config.DebrisPieces != null)
			{
				for (int i = 0; i < Config.DebrisCount; i++)
				{
					if (RoomAlgorithms.GetRandomFreeTile(_roomItem.FloorPlan, out var worldPosition2))
					{
						RoomItemAlgorithms.SpawnItem(Config.DebrisPieces.RandomItem().Instance, worldPosition2, 0.5f, UnityEngine.Random.Range(0, 360), level, owningRoom);
					}
				}
			}
			if (Config.DebrisEffectPieces != null)
			{
				float debrisEffectVelocity = Config.DebrisEffectVelocity;
				for (int j = 0; j < Config.DebrisEffectCount; j++)
				{
					MachineDebris machineDebris = new MachineDebris(Config.DebrisEffectPieces.RandomItem().Instance, level, owningRoom);
					RoomEntityPhysicsComponent component = machineDebris.GetComponent<RoomEntityPhysicsComponent>();
					machineDebris.GetTransform().position = worldPosition;
					if (component != null)
					{
						component.Room = owningRoom;
						component.Velocity = UnityEngine.Random.onUnitSphere * debrisEffectVelocity;
					}
				}
			}
			if (Config.ExplosionEffect != null)
			{
				Transform transform = _roomItem.Visual.GameObject.transform;
				UnityEngine.Object.Destroy(UnityEngine.Object.Instantiate(Config.ExplosionEffect, transform.position, transform.rotation), Config.ExplosionEffectTime);
			}
			_wreckageDelay = Config.WreckageDelay;
			if (Config.TriggerGameEvents)
			{
				level.BuildEvents.OnRoomItemExploded.InvokeSafe(_roomItem, this);
				level.ObjectiveEvents.OnGameEvent.InvokeSafe(ObjectiveGameEvent.MachineExploded);
			}
		}

		private void SwitchToWreckage()
		{
			Room owningRoom = _roomItem.OwningRoom;
			Level level = _roomItem.Level;
			Vector3 worldPosition = _roomItem.WorldPosition;
			float rotation = _roomItem.Rotation;
			_roomItem.Level.BuildEvents.OnRoomItemDestroy.InvokeSafe(_roomItem);
			if (_componentConfig._wreckage != null)
			{
				RoomItem roomItem = RoomItemAlgorithms.SpawnItem(_componentConfig._wreckage.Instance, worldPosition, 0f, rotation, level, owningRoom);
				if (roomItem != null)
				{
					roomItem.HasBeenPurchased = true;
				}
			}
		}

		private void ThrowCharacterOutOfRoom(Character character)
		{
			if (character.Interaction == null || !character.Interaction.IsRoomDoorInteraction())
			{
				character.Idle();
				character.TeleportOutOfRoom(_roomItem.OwningRoom);
				if (character.ModifiersComponent != null)
				{
					character.ModifiersComponent.AddStatusEffect(Config.StatusEffectInjured.Instance);
					PlatformStatsAndAchievements.TriggerAchievement(AchievementId.ExplosionInjury);
				}
			}
		}

		public override void Tick()
		{
			base.Tick();
			if (_onFire && _roomItem.GetAttributes().Enabled)
			{
				_roomItem.MaintenanceLevel.Modify(_componentConfig._rateOfDamage * GameTime.deltaTime, 1f);
			}
			if (_wreckageDelay > 0f)
			{
				_wreckageDelay -= GameTime.deltaTime;
				if (_wreckageDelay <= 0f)
				{
					SwitchToWreckage();
				}
			}
		}
	}
}
