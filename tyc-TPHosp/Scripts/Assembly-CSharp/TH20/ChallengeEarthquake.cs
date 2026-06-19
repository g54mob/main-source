using System.Collections.Generic;
using UnityEngine;

namespace TH20
{
	public class ChallengeEarthquake : Challenge
	{
		private readonly ChallengeEarthquakeConfig _config;

		private float _duration;

		private readonly float _debrisOverTime;

		private float _debrisToSpawn;

		[DontSave]
		private AudioEmitter _earthquakeLoop;

		[DontSave]
		private List<ParticleSystem> _environmentEffects;

		public ChallengeEarthquake(ChallengeConfig config, Level level)
			: base(config, level)
		{
			_config = GetConfig<ChallengeEarthquakeConfig>();
			_duration = (float)_config.DurationInDays * GameAlgorithms.Config.SecondsPerDay;
			int num = 0;
			foreach (HospitalPlot hospitalPlot in level.WorldState.HospitalPlots)
			{
				if (hospitalPlot.Built && hospitalPlot.HospitalMap != null)
				{
					num += hospitalPlot.HospitalMap.FloorPlan.TileCount;
				}
			}
			num /= 100;
			_debrisOverTime = ((_config.DebrisCount != 0) ? (_duration / (float)(num * _config.DebrisCount)) : 0f);
		}

		public override void RestoreFromSave()
		{
			base.RestoreFromSave();
			if (base.ChallengeStatus == ChallengeState.InProgress)
			{
				StartEnvironmentEffects();
			}
		}

		protected override void OnStart()
		{
			base.OnStart();
			Camera.main.gameObject.AddComponent<CameraShakeEffectComponent>().Shake(_duration, _config.CameraShakeSpeed, _config.CameraShakeMagnitude, _config.CameraShakePosition, _config.CameraShakeRotation);
			CharacterStatusEffectDefinition characterStatusEffectDefinition = ((_config.StatusEffect == null) ? null : _config.StatusEffect.Instance);
			if (characterStatusEffectDefinition != null)
			{
				foreach (Character allCharacter in base.Level.CharacterManager.AllCharacters)
				{
					if (allCharacter.ModifiersComponent != null)
					{
						allCharacter.ModifiersComponent.AddStatusEffect(characterStatusEffectDefinition);
					}
				}
			}
			StartEnvironmentEffects();
		}

		protected override void OnFinish(CompletionType completionType)
		{
			base.OnFinish(completionType);
			EndEnvironmentEffects();
		}

		private void StartEnvironmentEffects()
		{
			if (!_config.EarthquakeLoopSFX.IsNullOrEmpty())
			{
				_earthquakeLoop = AudioManager.Instance.Play(_config.EarthquakeLoopSFX);
			}
			if (_config.EnvironmentEffects != null)
			{
				_environmentEffects = new List<ParticleSystem>();
				ParticleSystem[] environmentEffects = _config.EnvironmentEffects;
				for (int i = 0; i < environmentEffects.Length; i++)
				{
					ParticleSystem component = Object.Instantiate(environmentEffects[i].gameObject).GetComponent<ParticleSystem>();
					_environmentEffects.Add(component);
				}
			}
		}

		private void EndEnvironmentEffects()
		{
			if (_earthquakeLoop != null)
			{
				AudioManager.Instance.Stop(_earthquakeLoop);
			}
			if (_environmentEffects == null)
			{
				return;
			}
			foreach (ParticleSystem environmentEffect in _environmentEffects)
			{
				environmentEffect.Stop(withChildren: true, ParticleSystemStopBehavior.StopEmitting);
				Object.Destroy(environmentEffect.gameObject, 2f);
			}
			_environmentEffects.Clear();
		}

		protected override void UpdateChallenge(float timeDelta)
		{
			base.UpdateChallenge(timeDelta);
			float modifyValue = _config.DamageOverTime * timeDelta;
			List<Room> allRooms = base.Level.WorldState.AllRooms;
			foreach (Room item in allRooms)
			{
				for (int num = item.FloorPlan.Items.Count - 1; num >= 0; num--)
				{
					RoomItem roomItem = item.FloorPlan.Items[num];
					JobMaintenance.JobDescription maintenanceDescription = roomItem.Definition.MaintenanceDescription;
					if ((maintenanceDescription == JobMaintenance.JobDescription.None || maintenanceDescription == JobMaintenance.JobDescription.BrokenMachine) && roomItem.MaintenanceLevel != null)
					{
						roomItem.MaintenanceLevel.Modify(modifyValue, 1f);
					}
				}
			}
			if (_config.DebrisCount != 0 && _config.DebrisItems != null && _config.DebrisItems.Length != 0)
			{
				_debrisToSpawn += timeDelta;
				while (_debrisToSpawn > _debrisOverTime)
				{
					Room room = allRooms.WeightedRandomItem((Room room2) => (!room2.Definition.IsHospitalUnbuilt) ? room2.FloorPlan.TileCount : 0);
					if (!room.Definition.IsHospitalUnbuilt)
					{
						if (RoomAlgorithms.GetRandomFreeTile(room.FloorPlan, out var worldPosition))
						{
							RoomItemAlgorithms.SpawnItem(_config.DebrisItems.RandomItem().Instance, worldPosition, _config.SpawnPositionRange, Random.Range(0f, _config.SpawnRotationRange), base.Level, room);
						}
						_debrisToSpawn -= _debrisOverTime;
					}
				}
			}
			_duration -= timeDelta;
			if (_duration <= 0f)
			{
				FinishChallenge();
			}
		}

		protected override int CalculateChallengeScore()
		{
			return 0;
		}

		public override void Destroy()
		{
			base.Destroy();
			if (_earthquakeLoop != null)
			{
				_earthquakeLoop.Stop();
			}
		}
	}
}
