using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using JetBrains.Annotations;
using Unity.Entities;
using UnityEngine.LowLevel;

namespace DV.Utils
{
	[UsedImplicitly]
	public class DVWorldBootstrap : ICustomBootstrap
	{
		public static event Action<World> WorldInitialized;

		public bool Initialize(string defaultWorldName)
		{
			World world = (World.DefaultGameObjectInjectionWorld = (World)(typeof(World).GetConstructor(BindingFlags.Instance | BindingFlags.NonPublic, null, new Type[2]
			{
				typeof(string),
				typeof(WorldFlags)
			}, null)?.Invoke(new object[2]
			{
				defaultWorldName,
				WorldFlags.Game
			})));
			IReadOnlyList<Type> allSystems = DefaultWorldInitialization.GetAllSystems(WorldSystemFilterFlags.Default);
			DefaultWorldInitialization.AddSystemsToRootLevelSystemGroups(world, allSystems.ToArray());
			ScriptBehaviourUpdateOrder.UpdatePlayerLoop(world, PlayerLoop.GetCurrentPlayerLoop());
			DVWorldBootstrap.WorldInitialized?.Invoke(world);
			DVWorldBootstrap.WorldInitialized = null;
			return true;
		}
	}
}
