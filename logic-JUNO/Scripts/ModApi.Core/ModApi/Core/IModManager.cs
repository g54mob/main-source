using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Jundroo.ModTools.Core;
using ModApi.Core.Events;
using ModApi.Mods;

namespace ModApi.Core
{
	public interface IModManager : IModManagerBase
	{
		IReadOnlyList<GameMod> GameMods { get; }

		ReadOnlyCollection<ModPartInfo> Parts { get; }

		event EventHandler<ModLoadedEventArgs> ModLoaded;
	}
}
