using UnityEngine;

namespace Assets.Dev.Philip.UiTesting.Scripts
{
	public class DebugPanel : InfoPanel
	{
		private static DebugPanel _instance;

		public static DebugPanel Instance
		{
			get
			{
				if (_instance == null)
				{
					_instance = Initialize();
				}
				return _instance;
			}
		}

		protected override void OnDestroy()
		{
			base.OnDestroy();
			_instance = null;
		}

		protected override void Update()
		{
			base.Update();
			base.Canvas.worldCamera = Camera.current;
		}

		private static DebugPanel Initialize()
		{
			return InfoPanel.Create<DebugPanel>("Debug", createHeader: true, null, 200, null, null, null, forceVisible: false);
		}
	}
}
