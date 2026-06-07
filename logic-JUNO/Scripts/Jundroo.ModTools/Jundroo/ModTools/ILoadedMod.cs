using System.Collections.Generic;
using UnityEngine;

namespace Jundroo.ModTools
{
	public interface ILoadedMod
	{
		AssetBundle AssetBundle { get; }

		ModInfo ModInfo { get; }

		IReadOnlyList<GameModBase> GameMods { get; }

		IModResourceLoader ResourceLoader { get; }
	}
}
