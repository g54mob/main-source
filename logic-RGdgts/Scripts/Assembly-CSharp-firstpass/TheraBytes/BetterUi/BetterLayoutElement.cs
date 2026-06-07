using System;
using UnityEngine;
using UnityEngine.UI;

namespace TheraBytes.BetterUi
{
	[ExecuteAlways]
	public class BetterLayoutElement : LayoutElement, IResolutionDependency
	{
		[Serializable]
		public class Settings : IScreenConfigConnection
		{
			public bool IgnoreLayout;

			public bool MinWidthEnabled;

			public bool MinHeightEnabled;

			public bool PreferredWidthEnabled;

			public bool PreferredHeightEnabled;

			public bool FlexibleWidthEnabled;

			public bool FlexibleHeightEnabled;

			public float FlexibleWidth;

			public float FlexibleHeight;

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

		[SerializeField]
		private FloatSizeModifier minWidthSizerFallback;

		[SerializeField]
		private FloatSizeConfigCollection customMinWidthSizers;

		[SerializeField]
		private FloatSizeModifier minHeightSizerFallback;

		[SerializeField]
		private FloatSizeConfigCollection customMinHeightSizers;

		[SerializeField]
		private FloatSizeModifier preferredWidthSizerFallback;

		[SerializeField]
		private FloatSizeConfigCollection customPreferredWidthSizers;

		[SerializeField]
		private FloatSizeModifier preferredHeightSizerFallback;

		[SerializeField]
		private FloatSizeConfigCollection customPreferredHeightSizers;

		public Settings CurrentSettings => null;

		public FloatSizeModifier MinWidthSizer => null;

		public FloatSizeModifier MinHeightSizer => null;

		public FloatSizeModifier PreferredWidthSizer => null;

		public FloatSizeModifier PreferredHeightSizer => null;

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
