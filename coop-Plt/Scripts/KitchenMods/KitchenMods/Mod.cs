using System;
using System.Collections.Generic;
using System.Linq;
using Sirenix.Utilities;
using UnityEngine;

namespace KitchenMods
{
	public sealed class Mod
	{
		public ModState State;

		public string Name;

		public ulong ID;

		public ModSource Source;

		private List<ModPack> Packs = new List<ModPack>();

		public Mod(ulong id, string name)
		{
			ID = id;
			Name = name;
			State = ModState.Preparation;
		}

		public Mod(ulong id, string name, params ModPack[] packs)
			: this(id, name)
		{
			Packs = packs.ToList();
		}

		public void AddPack(ModPack pack)
		{
			if (State != ModState.Preparation)
			{
				throw new Exception("Can't add ModPack to mod, non in Preparation state");
			}
			pack.Mod = this;
			Packs.Add(pack);
		}

		public List<T> GetPacks<T>() where T : ModPack
		{
			return Packs.Where((ModPack p) => p is T).Cast<T>().ToList();
		}

		public void Activate()
		{
			if (State != ModState.Preparation)
			{
				return;
			}
			State = ModState.Activated;
			if (Packs.IsNullOrEmpty())
			{
				Debug.LogError("Failed to activate Mod " + Name + ", no ModPacks found");
				State = ModState.FailedDuringLoad;
				return;
			}
			Debug.LogWarning("   Activate " + Name);
			foreach (ModPack pack in Packs)
			{
				try
				{
					pack.Activate();
				}
				catch (ModPackLoadException arg)
				{
					Debug.LogError($"Failed to activate ModPack for {Name}: {arg}");
					State = ModState.FailedDuringLoad;
					break;
				}
			}
		}

		public void PostActivate()
		{
			if (State != ModState.Activated)
			{
				return;
			}
			State = ModState.PostActivated;
			if (Packs.IsNullOrEmpty())
			{
				Debug.LogError("Failed to post-activate Mod " + Name + ", no ModPacks found");
				State = ModState.FailedDuringLoad;
				return;
			}
			Debug.LogWarning("   PostActivate " + Name);
			foreach (ModPack pack in Packs)
			{
				try
				{
					pack.PostActivate();
				}
				catch (ModPackLoadException arg)
				{
					Debug.LogError($"Failed to post-activate ModPack for {Name}: {arg}");
					State = ModState.FailedDuringLoad;
					break;
				}
			}
		}

		public void Inject(ModInjectionContext injection_context)
		{
			if (State == ModState.FailedDuringLoad)
			{
				Debug.LogWarning("Mod " + Name + " had loading errors and will not be injected");
				return;
			}
			if (State != ModState.PostActivated)
			{
				Debug.LogWarning($"Mod {Name} is in wrong state '{State}', want '{ModState.PostActivated}'");
				return;
			}
			foreach (ModPack pack in Packs)
			{
				pack.Inject(injection_context);
			}
		}

		public void Dispose()
		{
		}
	}
}
