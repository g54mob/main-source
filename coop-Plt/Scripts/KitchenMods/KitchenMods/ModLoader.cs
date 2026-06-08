using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using KitchenData;
using UnityEngine;

namespace KitchenMods
{
	public class ModLoader
	{
		private List<Mod> Mods = new List<Mod>();

		public ModLoader()
		{
			foreach (Mod mod in ModPreload.Mods)
			{
				RegisterMod(mod);
			}
		}

		public List<Mod> GetFailedMods()
		{
			return Mods.Where((Mod x) => x.State == ModState.FailedDuringLoad).ToList();
		}

		public async Task<List<Mod>> PopulateNames(List<Mod> mods)
		{
			ModSource[] sources = ModPreload.Sources;
			for (int i = 0; i < sources.Length; i++)
			{
				mods = await sources[i].PopulateModNames(mods);
			}
			return mods;
		}

		public Mod FindModFromAssembly(Assembly asm)
		{
			foreach (Mod mod in Mods)
			{
				foreach (AssemblyModPack pack in mod.GetPacks<AssemblyModPack>())
				{
					if (pack.Asm == asm)
					{
						return mod;
					}
				}
			}
			return null;
		}

		public void Dispose()
		{
			for (int num = Mods.Count - 1; num >= 0; num--)
			{
				if (num < Mods.Count)
				{
					Mod mod = Mods[num];
					UnregisterMod(mod);
				}
			}
		}

		public void RegisterMod(Mod mod)
		{
			if (!Mods.Contains(mod))
			{
				Mods.Add(mod);
			}
		}

		public void UnregisterMod(Mod mod)
		{
			if (mod != null)
			{
				mod.Dispose();
			}
			Mods.RemoveAll((Mod x) => x == mod);
		}

		public void InjectMods(ModInjectionContext injection_context)
		{
			injection_context.Constructor = Object.Instantiate<GameDataConstructor>(injection_context.Constructor);
			Debug.Log($"Injecting {Mods.Count} mods...");
			foreach (Mod mod in Mods)
			{
				Debug.Log("    Injecting " + mod.Name);
				mod.Inject(injection_context);
			}
		}
	}
}
