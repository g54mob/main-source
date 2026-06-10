using System;
using NSEipix.Base;
using NSMedieval.GameEventSystem;
using NSMedieval.GameEventSystem.Events;
using NSMedieval.Manager;
using NSMedieval.State;

namespace NSMedieval
{
	public class BeliefLogManager : MonoSingleton<BeliefLogManager>
	{
		private void OnRaidEnded(ActiveRaidInfo info)
		{
			if (info.RaidStatus == RaidStatus.Tie)
			{
				return;
			}
			string beliefEventId = (info.Won ? "belief_raid_won" : "belief_raid_lost");
			foreach (HumanoidInstance key in MonoSingleton<WorkerManager>.Instance.AllWorkers.Keys)
			{
				key.HumanoidBelief.FireBeliefEvent(beliefEventId);
			}
		}

		private void OnEventStart(GameEventInstance eventInstance)
		{
			string text = string.Empty;
			if (!(eventInstance is HailstormEvent))
			{
				if (!(eventInstance is ThunderstormEvent))
				{
					if (!(eventInstance is AlterWeatherEvent))
					{
						if (eventInstance is CropBlightEvent)
						{
							text = "belief_nature_blight";
						}
					}
					else
					{
						string iD = eventInstance.Blueprint.GetID();
						if (!(iD == "game_event_cold_snap"))
						{
							if (iD == "game_event_heat_wave")
							{
								text = "belief_nature_heatwave";
							}
						}
						else
						{
							text = "belief_nature_coldsnap";
						}
					}
				}
				else
				{
					text = "belief_nature_thunderstorm";
				}
			}
			else
			{
				text = "belief_nature_hailstorm";
			}
			if (string.IsNullOrEmpty(text))
			{
				return;
			}
			foreach (HumanoidInstance key in MonoSingleton<WorkerManager>.Instance.AllWorkers.Keys)
			{
				key.HumanoidBelief.FireBeliefEvent(text);
			}
		}

		private void OnEnable()
		{
			MonoSingleton<RaidController>.Instance.RaidEndedEvent += OnRaidEnded;
			NSMedieval.GameEventSystem.GameEventSystem gameEventSystem = MonoSingleton<NSMedieval.GameEventSystem.GameEventSystem>.Instance;
			gameEventSystem.EventStart = (Action<GameEventInstance>)Delegate.Combine(gameEventSystem.EventStart, new Action<GameEventInstance>(OnEventStart));
		}

		private void OnDisable()
		{
			if (MonoSingleton<RaidController>.IsInstantiated())
			{
				MonoSingleton<RaidController>.Instance.RaidEndedEvent -= OnRaidEnded;
			}
			if (MonoSingleton<NSMedieval.GameEventSystem.GameEventSystem>.IsInstantiated())
			{
				NSMedieval.GameEventSystem.GameEventSystem gameEventSystem = MonoSingleton<NSMedieval.GameEventSystem.GameEventSystem>.Instance;
				gameEventSystem.EventStart = (Action<GameEventInstance>)Delegate.Remove(gameEventSystem.EventStart, new Action<GameEventInstance>(OnEventStart));
			}
		}
	}
}
