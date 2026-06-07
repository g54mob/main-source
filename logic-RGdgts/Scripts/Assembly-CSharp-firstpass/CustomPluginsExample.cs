using System;
using DG.Tweening.Timeline.Core.Plugins;
using UnityEngine;

public static class CustomPluginsExample
{
	[RuntimeInitializeOnLoadMethod]
	private static void Register()
	{
	}

	private static DOVisualTweenPlugin GetTweenPlugin(Type targetType, string targetTypeFullName)
	{
		return null;
	}
}
