#define ENABLE_DEBUG_LOGS
#define ENABLE_DEBUG_ERRORS
using System;
using Presentation.UI;
using UnityEngine;
using Utils;

namespace Data.Variables
{
	[CreateAssetMenu(menuName = "Variables/Settings/AllowedFullscreenMode", fileName = "AllowedFullscreenMode", order = 0)]
	public class AllowedFullscreenModeSO : VariableSO<AllowedFullscreenMode>
	{
		public override void SetValue(AllowedFullscreenMode value)
		{
			if (value == Value)
			{
				return;
			}
			if (!Enum.IsDefined(typeof(AllowedFullscreenMode), value))
			{
				this.LogError($"Tried to set fullscreen dropdown to an index that does not exist: {value}", "SetValue", 18);
				return;
			}
			this.Log($"Set window mode to: {value}", "SetValue", 22);
			switch (value)
			{
			case AllowedFullscreenMode.Fullscreen:
				Screen.fullScreenMode = FullScreenMode.ExclusiveFullScreen;
				break;
			case AllowedFullscreenMode.BorderlessFullscreen:
				Screen.fullScreenMode = FullScreenMode.FullScreenWindow;
				break;
			case AllowedFullscreenMode.Windowed:
				Screen.fullScreenMode = FullScreenMode.Windowed;
				break;
			}
			base.SetValue(value);
		}

		protected override void OnEnable()
		{
		}

		protected override void OnDisable()
		{
		}
	}
}
