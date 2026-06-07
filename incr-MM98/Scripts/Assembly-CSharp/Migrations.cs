using System;
using System.Collections.Generic;
using UnityEngine;

public static class Migrations
{
	public const int CURRENT_VERSION = 3;

	private static readonly Dictionary<int, Action<StateFileDto>> migrations;

	static Migrations()
	{
		migrations = new Dictionary<int, Action<StateFileDto>>
		{
			{ 2, MigrateVersion2 },
			{ 3, MigrateVersion3 }
		};
	}

	public static void Migrate(StateFileDto state)
	{
		while (state.Version < 3)
		{
			state.Version++;
			if (migrations.TryGetValue(state.Version, out var value))
			{
				Debug.Log($"Migrating from {state.Version - 1} to {state.Version}.");
				value(state);
			}
			else
			{
				Debug.Log($"No migration found for version {state.Version}. Skipping.");
			}
		}
	}

	private static void MigrateVersion2(StateFileDto state)
	{
		if (state.Operations.Activations.TryGetValue((Operation)5957616, out var value))
		{
			state.Operations.Activations[Operation.BuyServerNode] = value;
			state.Operations.Activations.Remove((Operation)5957616);
		}
		if (state.Operations.Instances.TryGetValue((Operation)5957616, out var value2))
		{
			state.Operations.Instances[Operation.BuyServerNode] = value2;
			state.Operations.Instances.Remove((Operation)5957616);
		}
	}

	private static void MigrateVersion3(StateFileDto state)
	{
		if (state.Upgrades.Unlocked.Contains((UpgradeNode)380907331))
		{
			state.Upgrades.Unlocked.Remove((UpgradeNode)380907331);
		}
		if (state.Upgrades.Visited.Contains((UpgradeNode)380907331))
		{
			state.Upgrades.Visited.Remove((UpgradeNode)380907331);
		}
	}
}
