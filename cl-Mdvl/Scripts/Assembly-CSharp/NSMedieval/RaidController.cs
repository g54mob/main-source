using System;
using System.Collections.Generic;
using System.Linq;
using FoxyVoxel.Logging;
using NSEipix.Base;
using NSMedieval.Controllers;
using NSMedieval.GameEventSystem;
using NSMedieval.Manager;
using NSMedieval.State;

namespace NSMedieval
{
	public class RaidController : MonoSingleton<RaidController>
	{
		public delegate void RaidSpawned(ActiveRaidInfo info, List<HumanoidInstance> enemies);

		public delegate void RaidDelegate(ActiveRaidInfo info);

		public event RaidSpawned RaidSpawnedEvent;

		public event RaidDelegate RaidEndedEvent;

		public event RaidDelegate RaidAttackEngageEvent;

		public event Action OnWorkersWonRaidEvent;

		public event Action OnWorkersLostRaidEvent;

		public event Action RaidTieEvent;

		public void OnRaidSpawned(ActiveRaidInfo info, List<HumanoidInstance> enemies)
		{
			Log.Info("OnRaidSpawned", "C:\\GIT\\dev\\Assets\\Scripts\\Controller\\RaidController.cs");
			this.RaidSpawnedEvent?.Invoke(info, enemies);
			string messageText = MonoSingleton<LocalizationController>.Instance.GetText("enemies_have_appeared").Replace("<number>", enemies.Count.ToString());
			MonoSingleton<BlackBarMessageController>.Instance.ShowClickableBlackBarMessage(messageText, enemies.First().GetPosition());
		}

		public void OnRaidEnded(ActiveRaidInfo info)
		{
			Log.Info("OnRaidEnded", "C:\\GIT\\dev\\Assets\\Scripts\\Controller\\RaidController.cs");
			this.RaidEndedEvent?.Invoke(info);
			MonoSingleton<GameEventSystemController>.Instance.RaidEnded(info);
			if (!GlobalSaveController.CurrentVillageData.IsSecondMap)
			{
				MonoSingleton<AchievementManager>.Instance.UnlockAchievement("SURVIVE_FIRST_RAID");
			}
		}

		public void OnRaidAttackEngage(ActiveRaidInfo info)
		{
			Log.Info("OnRaidAttackEngage", "C:\\GIT\\dev\\Assets\\Scripts\\Controller\\RaidController.cs");
			info.HasEngaged = true;
			this.RaidAttackEngageEvent?.Invoke(info);
		}

		public void OnWorkersWonRaid()
		{
			this.OnWorkersWonRaidEvent?.Invoke();
		}

		public void OnWorkersLostRaid()
		{
			this.OnWorkersLostRaidEvent?.Invoke();
		}

		public void OnRaidTie()
		{
			this.RaidTieEvent?.Invoke();
		}

		protected override void OnDestroy()
		{
			base.OnDestroy();
			this.RaidSpawnedEvent = null;
			this.RaidEndedEvent = null;
			this.RaidAttackEngageEvent = null;
			this.OnWorkersWonRaidEvent = null;
			this.OnWorkersLostRaidEvent = null;
			this.RaidTieEvent = null;
		}
	}
}
