using Unity.Mathematics;
using UnityEngine;

namespace Aggro.Core
{
	public sealed class ResolutionSetting : AggroSettingBase
	{
		public int width { get; private set; }

		public int height { get; private set; }

		public int minWidth { get; private set; }

		public int minHeight { get; private set; }

		public int maxWidth { get; private set; }

		public int maxHeight { get; private set; }

		public float minAspectRatio { get; private set; }

		public ResolutionSetting(int minWidth, int minHeight, int maxWidth, int maxHeight, float minAspectRatio)
		{
			this.minWidth = minWidth;
			this.minHeight = minHeight;
			this.maxWidth = maxWidth;
			this.maxHeight = maxHeight;
			this.minAspectRatio = minAspectRatio;
		}

		public override void SetToDefault()
		{
		}

		protected override void SaveToPrefs(string preferencesKey)
		{
			Screen.SetResolution(width, height, Screen.fullScreenMode);
		}

		protected override void LoadFromPrefs(string preferencesKey)
		{
			width = Screen.width;
			height = Screen.height;
		}

		public void SetResolution(int width, int height)
		{
			this.width = math.clamp(width, minWidth, maxWidth);
			this.height = math.clamp(height, minHeight, maxHeight);
		}
	}
}
