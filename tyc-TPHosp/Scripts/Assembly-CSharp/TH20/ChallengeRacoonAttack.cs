using System;
using System.Collections.Generic;
using FullInspector;
using UnityEngine;

namespace TH20
{
	public class ChallengeRacoonAttack : Challenge
	{
		private readonly ChallengeRacoonAttackConfig _config;

		private readonly List<Racoon> _racoons = new List<Racoon>();

		private readonly List<RoomItem> _binsToAttack = new List<RoomItem>();

		private float _timeUntilNextAttack;

		[DontSave]
		private AudioEmitter _audioLoop;

		[DontSave]
		private List<ParticleSystem> _environmentEffects;

		private static List<RoomItem> _binCache = new List<RoomItem>();

		public ChallengeRacoonAttack(ChallengeConfig definition, Level level)
			: base(definition, level)
		{
			_config = GetConfig<ChallengeRacoonAttackConfig>();
			FindBinsToAttack();
			SetNextAttackTime();
			RegisterEvents();
		}

		private void RegisterEvents()
		{
			BuildEvents buildEvents = base.Level.BuildEvents;
			buildEvents.OnRoomItemRemoved = (Action<RoomItem, FloorPlan>)Delegate.Combine(buildEvents.OnRoomItemRemoved, new Action<RoomItem, FloorPlan>(OnRoomItemRemoved));
		}

		private void SetNextAttackTime()
		{
			_timeUntilNextAttack = UnityEngine.Random.Range(_config.MinAttackFrequencyInSeconds, _config.MaxAttackFrequencyInSeconds);
		}

		private void FindBinsToAttack()
		{
			SharedInstance<RoomItemDefinition>[] binItems = _config.BinItems;
			foreach (SharedInstance<RoomItemDefinition> sharedInstance in binItems)
			{
				_binCache.AddRange(base.Level.WorldState.GetRoomItemsOfType(sharedInstance.Instance));
			}
			if (_binCache.Count != 0)
			{
				int num = Mathf.RoundToInt((float)_binCache.Count * _config.AttackPercentage);
				for (int j = 0; j < num; j++)
				{
					RoomItem item = _binCache.RandomItem();
					_binCache.Remove(item);
					_binsToAttack.Add(item);
				}
			}
			_binCache.Clear();
		}

		protected override int CalculateChallengeScore()
		{
			return 0;
		}

		public override void Destroy()
		{
			if (_audioLoop != null)
			{
				_audioLoop.Stop();
			}
			BuildEvents buildEvents = base.Level.BuildEvents;
			buildEvents.OnRoomItemRemoved = (Action<RoomItem, FloorPlan>)Delegate.Remove(buildEvents.OnRoomItemRemoved, new Action<RoomItem, FloorPlan>(OnRoomItemRemoved));
			base.Destroy();
		}

		public override void RestoreFromSave()
		{
			base.RestoreFromSave();
			RegisterEvents();
			if (base.ChallengeStatus == ChallengeState.InProgress)
			{
				StartEnvironmentEffects();
			}
			foreach (Racoon racoon in _racoons)
			{
				racoon.Setup(_config.RacoonPrefabs.RandomItem());
			}
		}

		protected override void OnStart()
		{
			base.OnStart();
			StartEnvironmentEffects();
			ApplyStatusEffectToCharacters();
		}

		private void ApplyStatusEffectToCharacters()
		{
			CharacterStatusEffectDefinition characterStatusEffectDefinition = ((_config.StatusEffect == null) ? null : _config.StatusEffect.Instance);
			if (characterStatusEffectDefinition == null)
			{
				return;
			}
			foreach (Character allCharacter in base.Level.CharacterManager.AllCharacters)
			{
				if (allCharacter.ModifiersComponent != null)
				{
					allCharacter.ModifiersComponent.AddStatusEffect(characterStatusEffectDefinition);
				}
			}
		}

		protected override void OnFinish(CompletionType completionType)
		{
			base.OnFinish(completionType);
			EndEnvironmentEffects();
		}

		private void StartEnvironmentEffects()
		{
			if (!_config.SFXLoop.IsNullOrEmpty())
			{
				_audioLoop = AudioManager.Instance.Play(_config.SFXLoop);
			}
			if (_config.EnvironmentEffects != null)
			{
				_environmentEffects = new List<ParticleSystem>();
				ParticleSystem[] environmentEffects = _config.EnvironmentEffects;
				for (int i = 0; i < environmentEffects.Length; i++)
				{
					ParticleSystem component = UnityEngine.Object.Instantiate(environmentEffects[i].gameObject).GetComponent<ParticleSystem>();
					_environmentEffects.Add(component);
				}
			}
		}

		private void EndEnvironmentEffects()
		{
			if (_audioLoop != null)
			{
				AudioManager.Instance.Stop(_audioLoop);
			}
			if (_environmentEffects == null)
			{
				return;
			}
			foreach (ParticleSystem environmentEffect in _environmentEffects)
			{
				environmentEffect.Stop(withChildren: true, ParticleSystemStopBehavior.StopEmitting);
				UnityEngine.Object.Destroy(environmentEffect.gameObject, 2f);
			}
			_environmentEffects.Clear();
		}

		protected override void UpdateChallenge(float timeDelta)
		{
			base.UpdateChallenge(timeDelta);
			if (_binsToAttack.Count != 0)
			{
				_timeUntilNextAttack -= GameTime.deltaTime;
				if (_timeUntilNextAttack <= 0f)
				{
					AttackNextBin();
					SetNextAttackTime();
				}
			}
			for (int num = _racoons.Count - 1; num >= 0; num--)
			{
				Racoon racoon = _racoons[num];
				if (racoon.Update())
				{
					SpawnLitter(racoon.Bin);
					racoon.Destroy();
					_racoons.Remove(racoon);
				}
			}
			if (_binsToAttack.Count == 0 && _racoons.Count == 0)
			{
				FinishChallenge();
			}
		}

		private void AttackNextBin()
		{
			Racoon racoon = new Racoon
			{
				Bin = _binsToAttack.Pop()
			};
			racoon.Setup(_config.RacoonPrefabs.RandomItem());
			_racoons.Add(racoon);
		}

		private void OnRoomItemRemoved(RoomItem roomItem, FloorPlan floorPlan)
		{
			foreach (RoomItem item in _binsToAttack)
			{
				if (item == roomItem)
				{
					_binsToAttack.Remove(roomItem);
					break;
				}
			}
			foreach (Racoon racoon in _racoons)
			{
				if (racoon.Bin == roomItem)
				{
					racoon.Destroy();
					_racoons.Remove(racoon);
					break;
				}
			}
		}

		private void SpawnLitter(RoomItem bin)
		{
			if (_config.LitterItems.IsEmpty())
			{
				return;
			}
			int num = UnityEngine.Random.Range(_config.MinLitterCount, _config.MaxLitterCount);
			for (int i = 0; i < num; i++)
			{
				if (RoomAlgorithms.GetRandomFreeTileWithinRadius(bin.FloorPlan, bin.WorldPosition, _config.LitterSpawnRadius, out var worldPositionOut))
				{
					RoomItemAlgorithms.SpawnItem(_config.LitterItems.RandomItem().Instance, worldPositionOut, 0.5f, UnityEngine.Random.Range(0, 360), base.Level, bin.OwningRoom);
				}
			}
		}
	}
}
