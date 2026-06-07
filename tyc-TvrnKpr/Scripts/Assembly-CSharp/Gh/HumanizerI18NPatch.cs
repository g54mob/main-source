using System.Collections.Generic;
using System.Globalization;
using System.Reflection;
using System.Resources;
using Gh.Tk;
using UnityEngine.Scripting;

namespace Gh
{
	[InitializeOnGameStarted]
	internal static class HumanizerI18NPatch
	{
		private sealed class DictionaryLookupResourceManager : ResourceManager
		{
			private readonly Assembly _assembly;

			private readonly Dictionary<string, Dictionary<string, string>> _cache;

			private readonly HashSet<string> _doesNotExistSet;

			private readonly object _lock;

			public DictionaryLookupResourceManager(Assembly asm)
			{
			}

			public override string GetString(string name, CultureInfo culture)
			{
				return null;
			}

			public override object GetObject(string name, CultureInfo culture)
			{
				return null;
			}

			private void EnsureLoaded(string culture)
			{
			}
		}

		private static ResourceManager _resourceManager;

		private const string _dllName = "humanizer.all";

		private const string _prefix = "Humanizer.Properties.Resources.";

		private const string _suffix = ".resources";

		private const string _neutralName = "Humanizer.Properties.Resources.resources";

		[Preserve]
		private static void OnGameStarted()
		{
		}
	}
}
