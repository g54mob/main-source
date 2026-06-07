using System;
using UnityEngine;
using UnityEngine.UI;

namespace Coffee.UIParticleInternal
{
	internal static class UIExtraCallbacks
	{
		private static bool s_IsInitializedAfterCanvasRebuild;

		private static readonly FastAction s_AfterCanvasRebuildAction;

		private static readonly FastAction s_LateAfterCanvasRebuildAction;

		private static readonly FastAction s_BeforeCanvasRebuildAction;

		public static event Action onLateAfterCanvasRebuild
		{
			add
			{
				s_LateAfterCanvasRebuildAction.Add(value);
			}
			remove
			{
				s_LateAfterCanvasRebuildAction.Remove(value);
			}
		}

		public static event Action onBeforeCanvasRebuild
		{
			add
			{
				s_BeforeCanvasRebuildAction.Add(value);
			}
			remove
			{
				s_BeforeCanvasRebuildAction.Remove(value);
			}
		}

		public static event Action onAfterCanvasRebuild
		{
			add
			{
				s_AfterCanvasRebuildAction.Add(value);
			}
			remove
			{
				s_AfterCanvasRebuildAction.Remove(value);
			}
		}

		static UIExtraCallbacks()
		{
			s_AfterCanvasRebuildAction = new FastAction();
			s_LateAfterCanvasRebuildAction = new FastAction();
			s_BeforeCanvasRebuildAction = new FastAction();
			Canvas.willRenderCanvases += OnBeforeCanvasRebuild;
		}

		private static void InitializeAfterCanvasRebuild()
		{
			if (!s_IsInitializedAfterCanvasRebuild)
			{
				s_IsInitializedAfterCanvasRebuild = true;
				CanvasUpdateRegistry.IsRebuildingLayout();
				Canvas.willRenderCanvases += OnAfterCanvasRebuild;
			}
		}

		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
		private static void InitializeOnLoad()
		{
			Canvas.willRenderCanvases -= OnAfterCanvasRebuild;
			s_IsInitializedAfterCanvasRebuild = false;
		}

		private static void OnBeforeCanvasRebuild()
		{
			s_BeforeCanvasRebuildAction.Invoke();
			InitializeAfterCanvasRebuild();
		}

		private static void OnAfterCanvasRebuild()
		{
			s_AfterCanvasRebuildAction.Invoke();
			s_LateAfterCanvasRebuildAction.Invoke();
		}
	}
}
