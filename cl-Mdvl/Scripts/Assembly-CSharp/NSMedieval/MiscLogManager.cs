using System;
using System.Collections.Generic;
using NSEipix.Base;
using NSEipix.Repository;
using NSMedieval.Manager;
using NSMedieval.Model;
using NSMedieval.Repository;
using NSMedieval.State;
using NSMedieval.UI.Utils;
using NSMedieval.Utils.Pool;
using Social;

namespace NSMedieval
{
	public class MiscLogManager : MonoSingleton<MiscLogManager>
	{
		public void LogBanish(HumanoidInstance banished)
		{
			foreach (HumanoidInstance key in MonoSingleton<WorkerManager>.Instance.AllWorkers.Keys)
			{
				AffectionLevel affectionLevel = Repository<SocialCompatibilitySettingsRepository, SocialCompatibilitySettings>.Instance.Settings().GetAffectionLevel(key.WorkerBehaviour.WorkerSocial.GetAffectionTowards(banished));
				switch (affectionLevel)
				{
				case AffectionLevel.Rival:
					key.LogLifeEvent(LifeEventUtils.GetEventLog("banished_rival", key, banished));
					break;
				case AffectionLevel.Neutral:
					key.LogLifeEvent(LifeEventUtils.GetEventLog("banished_neutral", key, banished));
					break;
				case AffectionLevel.Friend:
					key.LogLifeEvent(LifeEventUtils.GetEventLog("banished_friend", key, banished));
					break;
				default:
					throw new ArgumentOutOfRangeException();
				}
				key.Stats.StartEffector(Repository<WorkerBaseRepository, Worker>.Instance.BaseWorker.DefaultHumanType.BanishEffectors[(int)affectionLevel]);
			}
		}

		public void LogDied(HumanoidInstance died)
		{
			foreach (HumanoidInstance key in MonoSingleton<WorkerManager>.Instance.AllWorkers.Keys)
			{
				if (key != died)
				{
					AffectionLevel affectionLevel = Repository<SocialCompatibilitySettingsRepository, SocialCompatibilitySettings>.Instance.Settings().GetAffectionLevel(key.WorkerBehaviour.WorkerSocial.GetAffectionTowards(died));
					switch (affectionLevel)
					{
					case AffectionLevel.Rival:
						key.LogLifeEvent(LifeEventUtils.GetEventLog("died_rival", key, died));
						break;
					case AffectionLevel.Neutral:
						key.LogLifeEvent(LifeEventUtils.GetEventLog("died_neutral", key, died));
						break;
					case AffectionLevel.Friend:
						key.LogLifeEvent(LifeEventUtils.GetEventLog("died_friend", key, died));
						key.HumanoidBelief.FireBeliefEvent("belief_friend_died");
						break;
					default:
						throw new ArgumentOutOfRangeException();
					}
					key.Stats.StartEffector(Repository<WorkerBaseRepository, Worker>.Instance.BaseWorker.DefaultHumanType.DiedEffectors[(int)affectionLevel]);
				}
			}
		}

		private void OnRaidEnded(ActiveRaidInfo info)
		{
			List<HumanoidInstance> list = ListPool<HumanoidInstance>.Get();
			foreach (HumanoidInstance key in MonoSingleton<WorkerManager>.Instance.AllWorkers.Keys)
			{
				if (key.HasWeapon())
				{
					list.Add(key);
				}
			}
			foreach (HumanoidInstance item in list)
			{
				foreach (HumanoidInstance item2 in list)
				{
					if (!item2.Equals(item))
					{
						item.Stats.StartAffectionEffector("AffectionBattledTogether", item2);
						item.LogLifeEvent(LifeEventUtils.GetEventLog("battled_together", item, item2));
					}
				}
			}
			ListPool<HumanoidInstance>.Return(list);
		}

		private void OnEnable()
		{
			MonoSingleton<RaidController>.Instance.RaidEndedEvent += OnRaidEnded;
		}

		private void OnDisable()
		{
			if (MonoSingleton<RaidController>.IsInstantiated())
			{
				MonoSingleton<RaidController>.Instance.RaidEndedEvent -= OnRaidEnded;
			}
		}
	}
}
