using System;
using UnityEngine;

namespace Coffee.UIEffectInternal
{
	internal static class UIExtraCallbacks
	{
		private static bool s_IsInitializedAfterCanvasRebuild;

		private static readonly FastAction s_AfterCanvasRebuildAction;

		private static readonly FastAction s_LateAfterCanvasRebuildAction;

		private static readonly FastAction s_BeforeCanvasRebuildAction;

		private static readonly FastAction s_OnScreenSizeChangedAction;

		private static Vector2Int s_LastScreenSize;

		public static event Action onLateAfterCanvasRebuild
		{
			add
			{
			}
			remove
			{
			}
		}

		public static event Action onBeforeCanvasRebuild
		{
			add
			{
			}
			remove
			{
			}
		}

		public static event Action onAfterCanvasRebuild
		{
			add
			{
			}
			remove
			{
			}
		}

		public static event Action onScreenSizeChanged
		{
			add
			{
			}
			remove
			{
			}
		}

		static UIExtraCallbacks()
		{
		}

		private static void InitializeAfterCanvasRebuild()
		{
		}

		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
		private static void InitializeOnLoad()
		{
		}

		private static void OnBeforeCanvasRebuild()
		{
		}

		private static void OnAfterCanvasRebuild()
		{
		}
	}
}
