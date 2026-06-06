using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using ZLinq;

[CreateAssetMenu(menuName = "Data/Simulation/UI Notification", fileName = "UINotificationSimulation")]
public class UINotificationSimulation : ScriptableObject, IIntervalIncrementalSimulation, IIncrementalSimulation
{
	private UIRegistry _registry;

	[field: SerializeField]
	public float UpdateInterval { get; private set; } = 1f;

	public void Registered(UIRegistry? registry)
	{
		if (!registry.HasValue)
		{
			throw new NullReferenceException("Trying to register " + base.name + " without a valid UI registry.");
		}
		_registry = registry.Value;
		_registry.taskbar.sequel.onClick.AddListener(delegate
		{
			Database.State.Sequel.DevelopmentNotification = false;
		});
		OnUpdateSimulation(0f);
	}

	public void Unregistered()
	{
	}

	public void OnUpdateSimulation(float deltaTime)
	{
		HandleNotificationIcons();
		HandleSystemMessages();
	}

	private void HandleNotificationIcons()
	{
		_registry.taskbar.upgradesNotification.SetActive(CatalogProvider.Upgrades.Collection.Any((UpgradeNodeData n) => Database.Commands.Upgrades.GetState(n) == UpgradeState.Purchaseable));
		_registry.taskbar.debuggerNotification.SetActive(Database.State.Debugger.StagingFull);
		_registry.taskbar.worldNotification.SetActive(Database.State.Datacenters.Details.AsValueEnumerable().Any(delegate(KeyValuePair<Datacenter, DatacenterDetails> x)
		{
			DatacenterState value = x.Value.State.Value;
			return value == DatacenterState.Degraded || value == DatacenterState.Critical;
		}));
		_registry.taskbar.auctionNotification.SetActive(Database.State.Auction.AvailableLootchests.Value >= ModifierType.AuctionLootchestCapacity.Int());
		_registry.taskbar.sequelNotification.SetActive(Database.State.Sequel.DevelopmentNotification);
	}

	private void HandleSystemMessages()
	{
		LoggedSystemLoadType value = Database.State.IRC.LoggedServerLoad.Value;
		LoggedSystemLoadType loggedSystemLoadType = ComputeBucket(Database.State.Resources.Load.Value);
		if (value == loggedSystemLoadType)
		{
			return;
		}
		Database.State.IRC.LoggedServerLoad.Value = loggedSystemLoadType;
		if (loggedSystemLoadType > value)
		{
			switch (loggedSystemLoadType)
			{
			case LoggedSystemLoadType.Over90:
				Database.Commands.IRC.Print(IRCSystem.ServerLoad90);
				break;
			case LoggedSystemLoadType.Over100:
				Database.Commands.IRC.Print(IRCSystem.ServerLoad100);
				break;
			case LoggedSystemLoadType.Over110:
				Database.Commands.IRC.Print(IRCSystem.ServerLoad110);
				break;
			}
		}
	}

	private LoggedSystemLoadType ComputeBucket(float load)
	{
		if (load >= 1f)
		{
			if (load >= 1.1f)
			{
				return LoggedSystemLoadType.Over110;
			}
			return LoggedSystemLoadType.Over100;
		}
		if (load >= 0.9f)
		{
			return LoggedSystemLoadType.Over90;
		}
		return LoggedSystemLoadType.NotTriggered;
	}
}
