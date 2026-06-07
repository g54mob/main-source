using System.Collections.Generic;
using System.Linq;

namespace Assets.Scripts.Mods
{
	public class RequiredMods
	{
		private List<RequiredMod> _mods;

		public IReadOnlyList<RequiredMod> Mods => _mods;

		public RequiredMods()
		{
			_mods = new List<RequiredMod>();
		}

		public void Add(RequiredMods requiredMods)
		{
			foreach (RequiredMod mod in requiredMods.Mods)
			{
				Add(mod.Mod, mod.RequiresCodeExecution);
			}
		}

		public void Add(ModInfo mod, bool requiresCodeExecution)
		{
			RequiredMod requiredMod = _mods.FirstOrDefault((RequiredMod x) => x.Mod == mod);
			if (requiredMod == null)
			{
				_mods.Add(new RequiredMod(mod, requiresCodeExecution));
			}
			else if (requiresCodeExecution)
			{
				requiredMod.RequiresCodeExecution = true;
			}
		}

		public bool Remove(ModInfo mod)
		{
			return _mods.RemoveAll((RequiredMod x) => x.Mod == mod) > 0;
		}
	}
}
