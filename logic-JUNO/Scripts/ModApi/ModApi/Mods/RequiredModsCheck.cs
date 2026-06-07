using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Jundroo.ModTools;

namespace ModApi.Mods
{
	public class RequiredModsCheck
	{
		public RequiredModsData AllRequiredMods { get; }

		public bool AllRequirementsMet { get; }

		public IReadOnlyList<RequiredModData> DisabledMods { get; }

		public IReadOnlyList<RequiredModData> DisabledOutdatedMods { get; }

		public IReadOnlyList<RequiredModData> EnabledMods { get; }

		public IReadOnlyList<RequiredModData> EnabledOutdatedMods { get; }

		public IReadOnlyList<RequiredModData> MissingMods { get; }

		public IReadOnlyList<RequiredModData> ModsMissingCodeExecutionRequirement { get; }

		public RequiredModsCheck(RequiredModsData requiredMods)
		{
			if (requiredMods == null)
			{
				requiredMods = new RequiredModsData();
			}
			int count = requiredMods.Mods.Count;
			List<RequiredModData> list = new List<RequiredModData>(count);
			List<RequiredModData> list2 = new List<RequiredModData>(count);
			List<RequiredModData> list3 = new List<RequiredModData>(count);
			List<RequiredModData> list4 = new List<RequiredModData>(count);
			List<RequiredModData> list5 = new List<RequiredModData>(count);
			List<RequiredModData> list6 = new List<RequiredModData>(count);
			IModManager modManager = Game.Instance.ModManager;
			bool flag = !modManager.SupportsCodeExecution;
			Func<ModInfo, RequiredModData, bool> isMatch = (ModInfo modInfo2, RequiredModData requiredMod) => modInfo2.Name == requiredMod.Name && modInfo2.Author == requiredMod.Author;
			Func<ModInfo, RequiredModData, bool> func = (ModInfo modInfo2, RequiredModData requiredMod) => modInfo2.Name == requiredMod.Name && modInfo2.Author == requiredMod.Author && (modInfo2.Version < requiredMod.Version || modInfo2.LastUpdated < requiredMod.LastModified);
			foreach (RequiredModData mod in requiredMods.Mods)
			{
				if (mod.RequiresCodeExecution && flag)
				{
					list6.Add(mod);
				}
				ILoadedMod loadedMod = null;
				ModInfo modInfo = null;
				if ((loadedMod = modManager?.LoadedMods.FirstOrDefault((ILoadedMod x) => isMatch(x.ModInfo, mod))) != null)
				{
					if (func(loadedMod.ModInfo, mod))
					{
						list2.Add(mod);
					}
					else
					{
						list.Add(mod);
					}
				}
				else if ((modInfo = modManager?.KnownMods.FirstOrDefault((ModInfo x) => isMatch(x, mod))) != null)
				{
					if (func(modInfo, mod))
					{
						list4.Add(mod);
					}
					else
					{
						list3.Add(mod);
					}
				}
				else
				{
					list5.Add(mod);
				}
			}
			AllRequiredMods = requiredMods;
			EnabledMods = list;
			EnabledOutdatedMods = list2;
			DisabledMods = list3;
			DisabledOutdatedMods = list4;
			MissingMods = list5;
			ModsMissingCodeExecutionRequirement = list6;
			AllRequirementsMet = ModsMissingCodeExecutionRequirement.Count == 0 && EnabledOutdatedMods.Count == 0 && DisabledMods.Count == 0 && DisabledOutdatedMods.Count == 0 && MissingMods.Count == 0;
		}

		public string BuildFailedRequirementsReport()
		{
			StringBuilder stringBuilder = new StringBuilder();
			Func<RequiredModData, string> func = (RequiredModData x) => $"    Mod Name: {x.Name},  Author: {x.Author},  Version: {x.Version},  Version Date: {x.LastModified:yyyy-MM-dd HH:mm:ss}";
			if (ModsMissingCodeExecutionRequirement.Count > 0)
			{
				stringBuilder.AppendLine();
				stringBuilder.AppendLine("Mods requiring code execution: ");
				foreach (RequiredModData item in ModsMissingCodeExecutionRequirement)
				{
					stringBuilder.AppendLine(func(item));
				}
			}
			if (EnabledOutdatedMods.Count > 0)
			{
				stringBuilder.AppendLine();
				stringBuilder.AppendLine("Mods enabled but outdated: ");
				foreach (RequiredModData enabledOutdatedMod in EnabledOutdatedMods)
				{
					stringBuilder.AppendLine(func(enabledOutdatedMod));
				}
			}
			if (DisabledMods.Count > 0)
			{
				stringBuilder.AppendLine();
				stringBuilder.AppendLine("Mods installed but not enabled: ");
				foreach (RequiredModData disabledMod in DisabledMods)
				{
					stringBuilder.AppendLine(func(disabledMod));
				}
			}
			if (DisabledOutdatedMods.Count > 0)
			{
				stringBuilder.AppendLine();
				stringBuilder.AppendLine("Mods installed but outdated and not enabled: ");
				foreach (RequiredModData disabledOutdatedMod in DisabledOutdatedMods)
				{
					stringBuilder.AppendLine(func(disabledOutdatedMod));
				}
			}
			if (MissingMods.Count > 0)
			{
				stringBuilder.AppendLine();
				stringBuilder.AppendLine("Mods not installed: ");
				foreach (RequiredModData missingMod in MissingMods)
				{
					stringBuilder.AppendLine(func(missingMod));
				}
			}
			return stringBuilder.ToString().TrimStart('\n', '\r');
		}
	}
}
