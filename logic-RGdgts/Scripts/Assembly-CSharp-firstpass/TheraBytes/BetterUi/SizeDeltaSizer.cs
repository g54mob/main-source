using System;
using UnityEngine;

namespace TheraBytes.BetterUi
{
	[ExecuteAlways]
	public class SizeDeltaSizer : ResolutionSizer<Vector2>
	{
		[Serializable]
		public class Settings : IScreenConfigConnection
		{
			[SerializeField]
			private bool applyWidth;

			[SerializeField]
			private bool applyHeight;

			[SerializeField]
			private string screenConfigName;

			public bool ApplyWidth
			{
				get
				{
					return false;
				}
				set
				{
				}
			}

			public bool ApplyHeight
			{
				get
				{
					return false;
				}
				set
				{
				}
			}

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
		private Vector2SizeModifier deltaSizerFallback;

		[SerializeField]
		private Vector2SizeConfigCollection customDeltaSizers;

		private DrivenRectTransformTracker rectTransformTracker;

		public Settings CurrentSettings => null;

		public Vector2SizeModifier DeltaSizer => null;

		protected override ScreenDependentSize<Vector2> sizer => null;

		protected override void OnDisable()
		{
		}

		protected override void ApplySize(Vector2 newSize)
		{
		}
	}
}
