using Doozy.Engine.UI.Base;
using UnityEngine;

namespace Doozy.Engine.UI
{
	[AddComponentMenu("Doozy/UI/UICanvas", 2)]
	[RequireComponent(typeof(Canvas))]
	[DefaultExecutionOrder(-100)]
	public class UICanvas : UIComponentBase<UICanvas>
	{
		public string CanvasName;

		public bool CustomCanvasName;

		public bool DontDestroyCanvasOnLoad;

		private Canvas m_canvas;

		public static string DefaultCanvasCategory => null;

		public static string DefaultCanvasName => null;

		public static UICanvas MasterCanvas { get; private set; }

		public static string MasterCanvasName => null;

		public Canvas Canvas => null;

		public bool IsMasterCanvas => false;

		private bool DebugComponent => false;

		protected override void Reset()
		{
		}

		public override void Awake()
		{
		}

		public static UICanvas CreateUICanvas(string canvasName)
		{
			return null;
		}

		public static bool DatabaseContains(string canvasName)
		{
			return false;
		}

		public static UICanvas GetMasterCanvas(bool createMasterCanvasIfNotFound = true)
		{
			return null;
		}

		public static UICanvas GetUICanvas(string canvasName)
		{
			return null;
		}

		public static UICanvas GetUICanvas(string canvasName, bool createUICanvasIfNotFound, bool returnMasterCanvasIfUICanvasNotFound = true)
		{
			return null;
		}
	}
}
