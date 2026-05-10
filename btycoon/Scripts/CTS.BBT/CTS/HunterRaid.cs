using System;
using System.Collections;
using CTS.BBT.AI;
using CTS.Core;
using CTS.Core.Utilities;
using UnityEngine;
using UnityEngine.Serialization;

namespace CTS
{
	public class HunterRaid : CTSSingleton<HunterRaid>
	{
		[FormerlySerializedAs("<RaidData>k__BackingField")]
		[SerializeField]
		private HunterRaidData _baseRaidData;

		private bool _started;

		public HunterRaidData CurrentRaidData { get; private set; }

		[field: SerializeField]
		public bool CanKillWorkers { get; set; } = true;

		[field: SerializeField]
		public bool CanDestroyMachines { get; set; } = true;

		public static bool IsRaidInProgress
		{
			get
			{
				foreach (Customer currentHunter in CTSSingleton<HostileCharacterSpawner>.Instance.CurrentHunters)
				{
					if (currentHunter.HasTag(BBTAgentTags.HunterRaiders))
					{
						return true;
					}
				}
				return false;
			}
		}

		protected override void SingletonAwake()
		{
		}

		protected override void OnSingletonDestroy()
		{
		}

		private IEnumerator Start()
		{
			yield return Coroutines.WaitForSeconds(2f);
			_started = true;
			OnVigilanceChanged(MonoSingleton<VigilanceHandlers>.Instance.CurrentVigilance);
		}

		protected override void OnEnabled()
		{
			base.OnEnabled();
			VigilanceHandlers.VigilanceChanged += OnVigilanceChanged;
			HostileCharacterSpawner.HunterLeft += OnHunterLeftBar;
		}

		protected override void OnDisabled()
		{
			base.OnDisabled();
			VigilanceHandlers.VigilanceChanged -= OnVigilanceChanged;
			HostileCharacterSpawner.HunterLeft -= OnHunterLeftBar;
		}

		public void SetRaidData(HunterRaidData data)
		{
			if ((object)data == null)
			{
				CurrentRaidData = _baseRaidData;
			}
			else
			{
				CurrentRaidData = data;
			}
		}

		private void OnHunterLeftBar(Customer obj)
		{
			if (obj.HasTag(BBTAgentTags.HunterRaiders) && !IsRaidInProgress)
			{
				int value = -CurrentRaidData.VigilanceLossWhenRaidFinished;
				MonoSingleton<VigilanceHandlers>.Instance.ChangeVigilanceBy(value, obj, EBone.HeadTop);
			}
		}

		private void OnVigilanceChanged(int obj)
		{
			if (_started && !IsRaidInProgress && MonoSingleton<VigilanceHandlers>.Instance.CurrentVigilance >= MonoSingleton<VigilanceHandlers>.Instance.GetMaxVigilanceWithDifficulty())
			{
				StartRaid();
			}
		}

		public void StartRaid()
		{
			float duration = CurrentRaidData.DurationRange.RandomInRange();
			int num = UnityEngine.Random.Range(CurrentRaidData.HunterCount.x, CurrentRaidData.HunterCount.y + 1);
			for (int i = 0; i < num; i++)
			{
				Customer customer = CTSSingleton<HostileCharacterSpawner>.Instance.SpawnHunter();
				if ((object)customer == null)
				{
					Debug.LogException(new Exception("Couldn't spawn a raider?"));
					continue;
				}
				customer.ContextualFSM.SetStatePanicking();
				customer.Cooldowns.StartCooldown(BBTAgentTags.StartedPanicking, duration);
				customer.AddTag(BBTAgentTags.HunterRaiders);
				customer.AddTag(BBTAgentTags.NoReview);
				customer.ActionPlayer.ForceAction(new AgentActionEnterBar(forceEnter: true), EActionPriority.Forced);
			}
		}
	}
}
