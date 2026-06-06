using System;
using System.Linq;
using MessagePipe;
using UnityEngine;

public class GameController : MonoBehaviour
{
	[SerializeField]
	private GameTimer timer;

	[SerializeField]
	private SimulationRegistry registry;

	private IDisposable _startGameSubscription;

	private void Start()
	{
		Database.Commands.Achievements.SetupTracking();
		foreach (IIncrementalSimulation item in registry.simulations.Cast<IIncrementalSimulation>())
		{
			IncrementalSimulation.RegisterSystem(item, UI.Registry);
		}
		if (Database.State.Game.Name.IsNullOrEmpty())
		{
			_startGameSubscription = EventHub.Scene.Subscribe(delegate
			{
				StartGame();
			}, Array.Empty<MessageHandlerFilter<FirstGameReleased>>());
			UI.Registry.popup.firstGame.ShowContent();
			Database.State.Resources.Money.SetValue(ModifierType.StartingCapital.Double());
			Database.State.Resources.MoneyLifetime.SetValue(ModifierType.StartingCapital.Double());
			AuctionUtility.RerollHiddenDistribution(Database.State.Auction);
			if (DebugMode.StartingMoney)
			{
				Database.State.Resources.Money.AddValue(100000.0);
			}
		}
		else if (Database.State.Studio.Ending.CurrentValue == EndingState.EndingBSelected)
		{
			_startGameSubscription = EventHub.Scene.Subscribe(delegate
			{
				StartGame();
			}, Array.Empty<MessageHandlerFilter<RehiredContinue>>());
			UI.Registry.popup.rehire.ShowContent();
		}
		else
		{
			StartGame();
		}
	}

	private void StartGame()
	{
		_startGameSubscription?.Dispose();
		timer.Resume();
	}

	private void GivePlayers(double value)
	{
		if (Application.isPlaying)
		{
			Database.State.Resources.Players.AddValue(value);
		}
	}

	private void GiveMoney(double value)
	{
		if (Application.isPlaying)
		{
			Database.State.Resources.Money.AddValue(value);
		}
	}

	private void GiveData(double value)
	{
		if (Application.isPlaying)
		{
			Database.State.Prestige.Data.AddValue(value);
		}
	}

	private void EscrowMoney(double value)
	{
		if (Application.isPlaying)
		{
			Database.State.Auction.EscrowMoney.AddValue(value);
		}
	}

	private void UnlockAllUpgrades()
	{
		foreach (UpgradeNodeData item in CatalogProvider.Upgrades.Collection)
		{
			if (!Database.State.Upgrades.IsUnlocked(item))
			{
				Database.State.Upgrades.Unlocked.Add(item);
				Database.State.Upgrades.Visited.Add(item);
				Database.Commands.Operations.Unlock(item.operation);
				Database.Modifiers.AddSource(new ModifierSourceId(ModifierSourceType.Upgrade, (int)item.ID), item.modifiers);
				EventHub.Scene.Publish(new UpgradeBought(item));
			}
		}
	}

	private void UnlockAllResearch()
	{
		foreach (ResearchNodeData item in CatalogProvider.Research.Collection)
		{
			if (!Database.State.Research.IsUnlocked(item))
			{
				Database.State.Research.Unlocked.Add(item);
				Database.Commands.Operations.Unlock(item.operation);
				Database.Modifiers.AddSource(new ModifierSourceId(ModifierSourceType.Research, (int)item.ID), item.modifiers);
				EventHub.Scene.Publish(new ResearchBought(item));
			}
		}
	}

	private void UnlockAllDatacenters()
	{
		foreach (DatacenterData item in CatalogProvider.Datacenters.Collection)
		{
			if (!Database.State.Datacenters.IsUnlocked(item))
			{
				Database.State.Datacenters.Details.Add(item.ID, new DatacenterDetails(DatacenterState.Nominal));
				Database.State.Datacenters.StateChanged.OnNext(item);
			}
		}
	}
}
