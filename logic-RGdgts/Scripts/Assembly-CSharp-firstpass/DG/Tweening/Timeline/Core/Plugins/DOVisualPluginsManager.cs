using System;
using System.Collections.Generic;

namespace DG.Tweening.Timeline.Core.Plugins
{
	public static class DOVisualPluginsManager
	{
		public static readonly List<string> GlobalTweenPluginsIds;

		public static readonly List<string> ActionPluginsIds;

		private static readonly Dictionary<string, DOVisualTweenPlugin> _IdToGlobalTweenPlugin;

		private static readonly Dictionary<Type, DOVisualTweenPlugin> _TypeToTweenPlugin;

		private static readonly List<Func<string, DOVisualTweenPlugin>> _GlobalTweenPluginsGenerators;

		private static readonly List<Func<Type, string, DOVisualTweenPlugin>> _TweenPluginsGenerators;

		private static readonly Dictionary<string, DOVisualActionPlugin> _IdToActionPlugin;

		private static readonly List<Func<string, DOVisualActionPlugin>> _ActionPluginsGenerators;

		public static DOVisualTweenPlugin GetGlobalTweenPlugin(string id)
		{
			return null;
		}

		public static DOVisualTweenPlugin GetTweenPlugin(object target)
		{
			return null;
		}

		public static DOVisualActionPlugin GetActionPlugin(string id)
		{
			return null;
		}

		public static void RegisterGlobalTweenPlugins(Func<string, DOVisualTweenPlugin> customPluginsGenerator, params string[] ids)
		{
		}

		public static void RegisterTweenPlugins(Func<Type, string, DOVisualTweenPlugin> customPluginsGenerator)
		{
		}

		public static void RegisterActionPlugins(Func<string, DOVisualActionPlugin> customPluginsGenerator, params string[] ids)
		{
		}

		public static DOVisualTweenPlugin CacheAndReturnGlobal(string id, params ITweenPluginData[] plugDatas)
		{
			return null;
		}

		public static DOVisualTweenPlugin CacheAndReturn(Type type, params ITweenPluginData[] plugDatas)
		{
			return null;
		}

		public static DOVisualActionPlugin CacheAndReturnAction(string id, params PlugDataAction[] plugDatas)
		{
			return null;
		}
	}
}
