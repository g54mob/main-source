using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Mods
{
	public interface ILoadedMod
	{
		AssetBundle AssetBundle { get; }

		ModInfo ModInfo { get; }

		IReadOnlyList<GameModBase> GameMods { get; }

		IModResourceLoader ResourceLoader { get; }
	}
}
