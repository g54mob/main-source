using System;
using System.Collections.Generic;
using UnityEngine;

namespace DG.Tweening.Timeline.Core.Plugins
{
	public class DOVisualTweenPlugin : IPlugin
	{
		public readonly Type targetType;

		public readonly ITweenPluginData[] pluginDatas;

		private readonly Dictionary<string, ITweenPluginData> _guidToPlugData;

		public int totPluginDatas { get; }

		public IPluginData[] editor_iPluginDatas => null;

		public bool isSupportedViaSubtype { get; private set; }

		public string subtypeId { get; private set; }

		public DOVisualTweenPlugin(Type targetType, params ITweenPluginData[] pluginDatas)
		{
		}

		public ITweenPluginData GetPlugData(DOTweenClipElement clipElement)
		{
			return null;
		}

		public ITweenPluginData GetPlugData(string plugDataGuid, int plugDataIndex)
		{
			return null;
		}

		public bool HasPlugData(DOTweenClipElement clipElement)
		{
			return false;
		}

		public Tweener CreateTween(DOTweenClipElement clipElement, object target, float timeMultiplier, ITweenPluginData plugData)
		{
			return null;
		}

		public DOVisualTweenPlugin IsSupportedViaSubtype(string subtypeId)
		{
			return null;
		}

		private static Rect Add(Rect a, Rect b)
		{
			return default(Rect);
		}
	}
}
