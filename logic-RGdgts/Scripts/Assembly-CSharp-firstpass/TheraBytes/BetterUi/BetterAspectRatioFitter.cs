using System;
using UnityEngine;
using UnityEngine.UI;

namespace TheraBytes.BetterUi
{
	[ExecuteAlways]
	public class BetterAspectRatioFitter : AspectRatioFitter, IResolutionDependency
	{
		[Serializable]
		public class Settings : IScreenConfigConnection
		{
			public AspectMode AspectMode;

			public float AspectRatio;

			[SerializeField]
			private string screenConfigName;

			public string ScreenConfigName
			{
				get
				{
					return null;
				}
				set
				{
				}
			}
		}

		[Serializable]
		public class SettingsConfigCollection : SizeConfigCollection<Settings>
		{
		}

		[SerializeField]
		private Settings settingsFallback;

		[SerializeField]
		private SettingsConfigCollection customSettings;

		public Settings CurrentSettings => null;

		protected override void OnEnable()
		{
		}

		public void OnResolutionChanged()
		{
		}

		private void Apply()
		{
		}
	}
}
