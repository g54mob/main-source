using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using Unity.Entities;

namespace KitchenMods
{
	public class AssemblyModPack : ModPack
	{
		private List<Type> Systems = new List<Type>();

		private List<Type> Components = new List<Type>();

		private List<IModInitializer> Initializers = new List<IModInitializer>();

		public Assembly Asm;

		private byte[] DebugData;

		public static bool TryLoadFile(string path, out AssemblyModPack pack)
		{
			pack = null;
			if (!Path.GetExtension(path).Equals(".dll"))
			{
				return false;
			}
			byte[] debug_data = new byte[0];
			try
			{
				debug_data = File.ReadAllBytes(Path.Combine(Path.GetDirectoryName(path), Path.GetFileNameWithoutExtension(path) + ".pdb"));
			}
			catch (Exception)
			{
			}
			pack = new AssemblyModPack(Path.GetFileName(path), File.ReadAllBytes(path), debug_data);
			return true;
		}

		public AssemblyModPack(string name, byte[] data, byte[] debug_data)
			: base(name, data)
		{
			DebugData = debug_data;
		}

		public override void Activate()
		{
			if (DebugData.Length == 0)
			{
				Asm = Assembly.Load(Data);
			}
			else
			{
				Asm = Assembly.Load(Data, DebugData);
			}
		}

		public override void PostActivate()
		{
			try
			{
				Type[] types = Asm.GetTypes();
				foreach (Type type in types)
				{
					if (typeof(IModInitializer).IsAssignableFrom(type))
					{
						try
						{
							if (!type.IsAbstract && Activator.CreateInstance(type) is IModInitializer item)
							{
								Initializers.Add(item);
							}
						}
						catch (Exception arg)
						{
							throw new ModPackLoadException($"Mod loading failed to instantiate IModInitializer {type}: {arg}");
						}
					}
					if (typeof(IModSystem).IsAssignableFrom(type))
					{
						Systems.Add(type);
					}
					if (typeof(IModComponent).IsAssignableFrom(type))
					{
						Components.Add(type);
					}
				}
				foreach (IModInitializer initializer in Initializers)
				{
					initializer.PostActivate(Mod);
				}
			}
			catch (ReflectionTypeLoadException arg2)
			{
				throw new ModPackLoadException($"Failed to load types of {arg2}:{Name}. Was it built for an old version of PlateUp!?");
			}
			catch (Exception arg3)
			{
				throw new ModPackLoadException($"Failed to load code pack of {Name}: {arg3}");
			}
		}

		public override void Inject(ModInjectionContext injection_context)
		{
			foreach (IModInitializer initializer in Initializers)
			{
				initializer.PreInject();
			}
			foreach (Type system in Systems)
			{
				if (typeof(IModSystem).IsAssignableFrom(system))
				{
					UpdateInGroupAttribute customAttribute = system.GetCustomAttribute<UpdateInGroupAttribute>();
					Type type = ((customAttribute == null) ? typeof(SimulationSystemGroup) : customAttribute.GroupType);
					if (injection_context.World.GetOrCreateSystem(type) is ComponentSystemGroup componentSystemGroup)
					{
						componentSystemGroup.AddSystemToUpdateList(injection_context.World.GetOrCreateSystem(system));
						componentSystemGroup.SortSystems();
					}
				}
			}
			foreach (IModInitializer initializer2 in Initializers)
			{
				initializer2.PostInject();
			}
		}
	}
}
