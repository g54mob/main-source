using System;
using System.Collections.Generic;
using FullInspector;
using JetBrains.Annotations;
using UnityEngine;

namespace TH20
{
	public class GuestTrainers : MustCallDestroy
	{
		[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
		public class Config
		{
			public SharedInstance<GuestTrainerDefinition>[] GuestTrainers;
		}

		private class TrainerOnArrival : IArrivedCallback
		{
			private GuestTrainer _trainer;

			private readonly GuestTrainers _guestTrainers;

			private readonly CharacterManager _characterManager;

			public TrainerOnArrival(GuestTrainer trainer, GuestTrainers guestTrainers, CharacterManager characterManager)
			{
				_trainer = trainer;
				_guestTrainers = guestTrainers;
				_characterManager = characterManager;
				_guestTrainers._arriving.AddUnique(_trainer);
			}

			public Character OnArrived(Vector3 position)
			{
				GuestTrainer trainer = _trainer;
				_guestTrainers._arriving.Remove(_trainer);
				if (!_trainer.HasBeenDestroyed())
				{
					_trainer.SetEnabled(enabled: true);
					_guestTrainers._spawned.AddUnique(_trainer);
					_characterManager.AddSpecialCharacter(_trainer);
				}
				_trainer = null;
				return trainer;
			}

			public void OnFailed()
			{
				_guestTrainers._arriving.Remove(_trainer);
				_trainer.Level.CharacterManager.DestroyOrphan(_trainer);
				_trainer = null;
			}

			public bool HasPatientSpawnedCallback(IPatientSpawned patientSpawned)
			{
				return false;
			}

			public bool IsValid()
			{
				if (_trainer != null)
				{
					return _trainer.GameObject != null;
				}
				return false;
			}

			public int GetArrivalPriority()
			{
				return GameAlgorithms.Config.ArrivalPriorityGuestTrainer;
			}
		}

		private readonly Config _config;

		private readonly Level _level;

		private readonly List<GuestTrainer> _pool;

		private readonly List<GuestTrainer> _spawned;

		private List<GuestTrainer> _arriving;

		private readonly List<GuestTrainerDefinition> _assigned;

		public GuestTrainers(Config config, Level level)
		{
			_config = config;
			_level = level;
			_pool = new List<GuestTrainer>();
			_spawned = new List<GuestTrainer>();
			_arriving = new List<GuestTrainer>();
			_assigned = new List<GuestTrainerDefinition>();
			RegisterEvents();
		}

		public override void RestoreFromSave()
		{
			base.RestoreFromSave();
			if (_arriving == null)
			{
				_arriving = new List<GuestTrainer>();
			}
			_arriving.RemoveDuplicates();
			_arriving.RemoveAll(delegate(GuestTrainer trainer)
			{
				if (trainer.Enabled && trainer.IsOrphaned())
				{
					trainer.Level.CharacterManager.DestroyOrphan(trainer);
					return true;
				}
				return false;
			});
			_spawned.RemoveDuplicates();
			_spawned.RemoveAll(delegate(GuestTrainer trainer)
			{
				if ((trainer.Enabled && trainer.IsOrphaned()) || trainer.GameObject == null)
				{
					trainer.Level.CharacterManager.DestroyOrphan(trainer);
					return true;
				}
				return false;
			});
			_assigned.RemoveAll(delegate(GuestTrainerDefinition definition)
			{
				bool flag = false;
				foreach (GuestTrainer item in _spawned)
				{
					if (item.Definition == definition)
					{
						flag = true;
					}
				}
				return !flag;
			});
			RegisterEvents();
		}

		public void ClearPool()
		{
			_pool.ClearAndCallDestroy();
		}

		public override void Destroy()
		{
			UnregisterEvents();
			ClearPool();
			_spawned.ClearAndCallDestroy();
			_arriving.ClearAndCallDestroy();
			base.Destroy();
		}

		private void RegisterEvents()
		{
			CharacterEvents characterEvents = _level.CharacterEvents;
			characterEvents.OnCharacterDestroyed = (Action<Character>)Delegate.Combine(characterEvents.OnCharacterDestroyed, new Action<Character>(OnCharacterDestroyed));
			CharacterEvents characterEvents2 = _level.CharacterEvents;
			characterEvents2.OnCharacterLeftHospital = (Action<Character>)Delegate.Combine(characterEvents2.OnCharacterLeftHospital, new Action<Character>(OnCharacterLeftHospital));
			CharacterEvents characterEvents3 = _level.CharacterEvents;
			characterEvents3.OnStaffReadyToStartTraining = (Action<Staff, Room>)Delegate.Combine(characterEvents3.OnStaffReadyToStartTraining, new Action<Staff, Room>(OnStaffReadyToStartTraining));
			CharacterEvents characterEvents4 = _level.CharacterEvents;
			characterEvents4.OnStaffEndedTraining = (Action<Staff>)Delegate.Combine(characterEvents4.OnStaffEndedTraining, new Action<Staff>(OnStaffEndedTraining));
		}

		private void UnregisterEvents()
		{
			CharacterEvents characterEvents = _level.CharacterEvents;
			characterEvents.OnCharacterDestroyed = (Action<Character>)Delegate.Remove(characterEvents.OnCharacterDestroyed, new Action<Character>(OnCharacterDestroyed));
			CharacterEvents characterEvents2 = _level.CharacterEvents;
			characterEvents2.OnCharacterLeftHospital = (Action<Character>)Delegate.Remove(characterEvents2.OnCharacterLeftHospital, new Action<Character>(OnCharacterLeftHospital));
			CharacterEvents characterEvents3 = _level.CharacterEvents;
			characterEvents3.OnStaffReadyToStartTraining = (Action<Staff, Room>)Delegate.Remove(characterEvents3.OnStaffReadyToStartTraining, new Action<Staff, Room>(OnStaffReadyToStartTraining));
			CharacterEvents characterEvents4 = _level.CharacterEvents;
			characterEvents4.OnStaffEndedTraining = (Action<Staff>)Delegate.Remove(characterEvents4.OnStaffEndedTraining, new Action<Staff>(OnStaffEndedTraining));
		}

		public List<GuestTrainer> GetTrainers(QualificationDefinition qualification)
		{
			List<GuestTrainer> list = new List<GuestTrainer>();
			ClearPool();
			SharedInstance<GuestTrainerDefinition>[] guestTrainers = _config.GuestTrainers;
			for (int i = 0; i < guestTrainers.Length; i++)
			{
				GuestTrainerDefinition instance = guestTrainers[i].Instance;
				if (instance.GetSkill(qualification) != null && !_assigned.Contains(instance) && !HasBeenSpawned(instance) && !IsArriving(instance))
				{
					GuestTrainer item = new GuestTrainer(new JobApplicant(instance), _level, _level.VisualManager, _level.CharacterManager.TakeNextCharacterID());
					_pool.Add(item);
					list.Add(item);
				}
			}
			foreach (GuestTrainer item2 in _spawned)
			{
				if (item2.Definition.GetSkill(qualification) != null && !_assigned.Contains(item2.Definition))
				{
					list.Add(item2);
				}
			}
			foreach (GuestTrainer item3 in _arriving)
			{
				if (item3.Definition.GetSkill(qualification) != null && !_assigned.Contains(item3.Definition))
				{
					list.Add(item3);
				}
			}
			return list;
		}

		private bool HasBeenSpawned(GuestTrainerDefinition definition)
		{
			foreach (GuestTrainer item in _spawned)
			{
				if (item.Definition == definition)
				{
					return true;
				}
			}
			return false;
		}

		private bool IsArriving(GuestTrainerDefinition definition)
		{
			foreach (GuestTrainer item in _arriving)
			{
				if (item.Definition == definition)
				{
					return true;
				}
			}
			return false;
		}

		private void OnStaffReadyToStartTraining(Staff trainer, Room room)
		{
			if (trainer is GuestTrainer guestTrainer)
			{
				_assigned.AddUnique(guestTrainer.Definition);
				if (!_spawned.Contains(guestTrainer) && !_arriving.Contains(guestTrainer))
				{
					_pool.Remove(guestTrainer);
					CharacterManager characterManager = _level.CharacterManager;
					ArrivalMethodDefinition methodDefinition = ((guestTrainer.Definition.ArrivalMethod != null) ? guestTrainer.Definition.ArrivalMethod.Instance : characterManager.GetDefaultArrivalMethod());
					characterManager.ArrivalsManager.Add(methodDefinition, new TrainerOnArrival(guestTrainer, this, characterManager));
				}
			}
		}

		private void OnStaffEndedTraining(Staff staff)
		{
			if (staff is GuestTrainer guestTrainer)
			{
				_assigned.Remove(guestTrainer.Definition);
			}
		}

		private bool RemoveTrainer(Character character)
		{
			if (character is GuestTrainer guestTrainer)
			{
				_spawned.Remove(guestTrainer);
				_assigned.Remove(guestTrainer.Definition);
				return true;
			}
			return false;
		}

		private void OnCharacterDestroyed(Character character)
		{
			RemoveTrainer(character);
		}

		private void OnCharacterLeftHospital(Character character)
		{
			RemoveTrainer(character);
		}
	}
}
