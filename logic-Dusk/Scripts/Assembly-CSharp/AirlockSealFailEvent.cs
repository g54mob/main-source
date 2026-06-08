using System.Collections.Generic;
using UnityEngine;

public class AirlockSealFailEvent : BaseGameEvent
{
	private class BreakingAirlock
	{
		public Corridor airlock { get; set; }

		public bool isBreaking { get; set; }

		public bool isPendingRestartEvent { get; set; }

		public bool hasShownSecondWarning { get; set; }

		public float timerToBreak { get; set; }

		public float timerToRestartEvent { get; set; }
	}

	private List<BreakingAirlock> processingAirlocks;

	public AirlockSealFailEvent(int seed)
		: base(seed)
	{
	}

	public override void Initalize()
	{
		base.Probability = 0.25f * GlobalSettings.GameState.ThePlayer.CurrentDockedDungeon.CalculatedDifficultyValues.EventDoorValue;
		base.CheckFrequency = 410f;
		base.Cooldown = 500f;
		base.Initalize();
	}

	public override void Update()
	{
		if (processingAirlocks != null)
		{
			int count = processingAirlocks.Count;
			for (int num = count - 1; num >= 0; num--)
			{
				BreakingAirlock breakingAirlock = processingAirlocks[num];
				if (breakingAirlock.isBreaking)
				{
					breakingAirlock.timerToBreak -= Time.deltaTime;
					if (breakingAirlock.timerToBreak <= 0f)
					{
						breakingAirlock.airlock.door.EndSealFailureVisual();
						breakingAirlock.airlock.door.TakeDamage(1000f, DamageType.Physical, null);
						if (breakingAirlock.airlock.onSchematic)
						{
							breakingAirlock.airlock.UpdateCameraView(true);
							breakingAirlock.airlock.droneUIObject.UpdateCameraView();
						}
						if (breakingAirlock.airlock.door.onSchematic)
						{
							SystemMessageManager.ShowSystemMessage(string.Format("'{0}' airlock no longer responding", breakingAirlock.airlock.door.Label), ConsoleMessageType.Warning);
						}
						else
						{
							SystemMessageManager.ShowSystemMessage("'unknown' airlock no longer responding", ConsoleMessageType.Warning);
						}
						processingAirlocks.RemoveAt(num);
						if (processingAirlocks.Count == 0)
						{
							processingAirlocks = null;
						}
					}
					else if (!breakingAirlock.hasShownSecondWarning && breakingAirlock.timerToBreak <= 30f)
					{
						breakingAirlock.hasShownSecondWarning = true;
						if (breakingAirlock.airlock.door.onSchematic)
						{
							SystemMessageManager.ShowSystemMessage(string.Format("Airlock '{0}': seal will fail in 30 seconds.", breakingAirlock.airlock.door.Label), ConsoleMessageType.Warning);
						}
						else
						{
							SystemMessageManager.ShowSystemMessage("Airlock 'unknown': seal will fail in 30 seconds.", ConsoleMessageType.Warning);
						}
					}
					else if (BoardingShip.Instance.CurrentAirlock == breakingAirlock.airlock)
					{
						breakingAirlock.isBreaking = false;
						breakingAirlock.isPendingRestartEvent = false;
						breakingAirlock.airlock.door.EndSealFailureVisual();
						if (breakingAirlock.airlock.door.onSchematic)
						{
							SystemMessageManager.ShowSystemMessage(string.Format("Airlock '{0}': seal stabilized", breakingAirlock.airlock.door.Label), ConsoleMessageType.Benefit);
						}
						else
						{
							SystemMessageManager.ShowSystemMessage("Airlock 'unknown': seal stabilized", ConsoleMessageType.Benefit);
						}
					}
				}
				else if (breakingAirlock.isPendingRestartEvent)
				{
					breakingAirlock.timerToRestartEvent -= Time.deltaTime;
					if (breakingAirlock.timerToRestartEvent <= 0f)
					{
						breakingAirlock.isPendingRestartEvent = false;
						breakingAirlock.isBreaking = true;
						breakingAirlock.airlock.door.BeginSealFailureVisual();
						breakingAirlock.hasShownSecondWarning = false;
						breakingAirlock.timerToBreak = 60f;
						if (breakingAirlock.airlock.door.onSchematic)
						{
							SystemMessageManager.ShowSystemMessage(string.Format("Airlock '{0}': seal integrity failing.", breakingAirlock.airlock.door.Label), ConsoleMessageType.Warning);
						}
						else
						{
							SystemMessageManager.ShowSystemMessage("Airlock 'unknown': seal integrity failing.", ConsoleMessageType.Warning);
						}
					}
				}
				else if (BoardingShip.Instance.CurrentAirlock != breakingAirlock.airlock)
				{
					breakingAirlock.isPendingRestartEvent = true;
					breakingAirlock.timerToRestartEvent = rnd.NextFloat(40f, 60f);
				}
			}
		}
		base.Update();
	}

	public override void ExecuteEvent()
	{
		Corridor corridor = null;
		int num = 0;
		do
		{
			int num2 = rnd.Next(0, DungeonManager.Instance.corridors.Length);
			Corridor corridor2 = DungeonManager.Instance.corridors[num2];
			if (corridor2.IsAirlock && BoardingShip.Instance.CurrentAirlock != corridor2 && !corridor2.door.IsDead && !corridor2.door.IsDisconnected)
			{
				corridor = corridor2;
			}
			num++;
		}
		while (corridor == null && num < 100);
		if (corridor != null)
		{
			if (processingAirlocks == null)
			{
				processingAirlocks = new List<BreakingAirlock>();
			}
			processingAirlocks.Add(new BreakingAirlock
			{
				airlock = corridor,
				timerToBreak = 60f,
				timerToRestartEvent = 0f,
				isBreaking = true,
				isPendingRestartEvent = false
			});
			corridor.door.BeginSealFailureVisual();
			if (corridor.door.onSchematic)
			{
				SystemMessageManager.ShowSystemMessage(string.Format("Airlock '{0}': seal integrity failing.", corridor.door.Label), ConsoleMessageType.Warning);
			}
			else
			{
				SystemMessageManager.ShowSystemMessage("Airlock 'unknown': seal integrity failing.", ConsoleMessageType.Warning);
			}
		}
	}
}
