using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using Unity.Entities;
using UnityEngine;

namespace Kitchen
{
	public class WorldBootstrapper
	{
		private struct SystemSpec
		{
			public Type System;

			public Type Parent;

			public GameSetupMode ModeFilter;
		}

		public World CreatedWorld;

		private static Type[] DefaultSystems = new Type[3]
		{
			typeof(SimulationSystemGroup),
			typeof(InitializationSystemGroup),
			typeof(PresentationSystemGroup)
		};

		private static List<SystemSpec> SystemList;

		public static async void BuildSystemList()
		{
			if (SystemList == null)
			{
				SystemList = new List<SystemSpec>();
			}
			SystemList.Clear();
			IReadOnlyList<Type> allSystems = DefaultWorldInitialization.GetAllSystems(WorldSystemFilterFlags.All);
			HashSet<Type> added_systems = new HashSet<Type>();
			foreach (Type item in allSystems)
			{
				if (item.Namespace != null && item.Namespace.StartsWith("Kitchen") && item.GetCustomAttribute<DisableAutoCreationAttribute>() == null)
				{
					add_system(item);
				}
			}
			add_system(typeof(EndSimulationEntityCommandBufferSystem));
			void add_system(Type system)
			{
				if (added_systems.Add(system) && !DefaultSystems.Contains(system))
				{
					FilterModesAttribute customAttribute = system.GetCustomAttribute<FilterModesAttribute>();
					UpdateInGroupAttribute customAttribute2 = system.GetCustomAttribute<UpdateInGroupAttribute>();
					Type type = ((customAttribute2 != null) ? customAttribute2.GroupType : typeof(SimulationSystemGroup));
					SystemList.Add(new SystemSpec
					{
						System = system,
						Parent = type,
						ModeFilter = (customAttribute?.AllowedModes ?? GameSetupMode.Server)
					});
					add_system(type);
				}
			}
		}

		private List<(SystemSpec, ComponentSystemBase)> PopulateFromSystemList(World world, GameSetupMode mode)
		{
			new Stopwatch().Start();
			List<(SystemSpec, ComponentSystemBase)> list = new List<(SystemSpec, ComponentSystemBase)>();
			foreach (SystemSpec system in SystemList)
			{
				if (system.ModeFilter.HasFlag(mode))
				{
					ComponentSystemBase orCreateSystem = CreatedWorld.GetOrCreateSystem(system.System);
					list.Add((system, orCreateSystem));
				}
			}
			foreach (var (systemSpec, componentSystemBase) in list)
			{
				if (systemSpec.ModeFilter.HasFlag(mode))
				{
					if (!(world.GetOrCreateSystem(systemSpec.Parent) is ComponentSystemGroup componentSystemGroup))
					{
						UnityEngine.Debug.LogError($"Failed for find parent system {systemSpec.Parent} for new system {systemSpec.System}");
						continue;
					}
					ComponentSystemBase sys = componentSystemBase;
					componentSystemGroup.AddSystemToUpdateList(sys);
				}
			}
			return list;
		}

		public WorldBootstrapper(string name, GameSetupMode mode)
		{
			CreatedWorld = new World(name);
			if (SystemList == null)
			{
				BuildSystemList();
			}
			foreach (var (systemSpec, componentSystemBase) in PopulateFromSystemList(CreatedWorld, mode))
			{
				try
				{
					if (systemSpec.System.IsSubclassOf(typeof(ComponentSystemGroup)))
					{
						((ComponentSystemGroup)componentSystemBase).SortSystems();
					}
					if (systemSpec.System.IsSubclassOf(typeof(GenericSystemBase)))
					{
						((GenericSystemBase)componentSystemBase).PostInitialisation();
					}
				}
				catch (Exception)
				{
					UnityEngine.Debug.LogError($"Failed to post-initialise system {componentSystemBase}");
				}
			}
			DefaultWorldInitialization.AddSystemsToRootLevelSystemGroups(CreatedWorld, DefaultSystems);
			ScriptBehaviourUpdateOrder.AddWorldToCurrentPlayerLoop(CreatedWorld);
		}
	}
}
