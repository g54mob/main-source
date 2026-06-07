using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace TheraBytes.BetterUi
{
	[ExecuteAlways]
	public class OverrideScreenProperties : UIBehaviour, IResolutionDependency
	{
		public enum ScreenProperty
		{
			Width = 0,
			Height = 1,
			Dpi = 2
		}

		public enum OverrideMode
		{
			Override = 0,
			Inherit = 1,
			ActualScreenProperty = 2
		}

		[Serializable]
		public class Settings : IScreenConfigConnection
		{
			[Serializable]
			public class OverrideProperty
			{
				[SerializeField]
				private OverrideMode mode;

				[SerializeField]
				private float value;

				public OverrideMode Mode => default(OverrideMode);

				public float Value => 0f;
			}

			public OverrideProperty OptimizedWidthOverride;

			public OverrideProperty OptimizedHeightOverride;

			public OverrideProperty OptimizedDpiOverride;

			[SerializeField]
			private string screenConfigName;

			public OverrideProperty Item => null;

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

			public IEnumerable<OverrideProperty> PropertyIterator()
			{
				return null;
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

		private ScreenInfo optimizedOverride;

		private ScreenInfo currentOverride;

		public Settings CurrentSettings => null;

		public ScreenInfo OptimizedOverride => null;

		public ScreenInfo CurrentSize => null;

		protected override void OnEnable()
		{
		}

		protected override void OnTransformParentChanged()
		{
		}

		protected override void OnRectTransformDimensionsChange()
		{
		}

		public void OnResolutionChanged()
		{
		}

		private IEnumerator RecalculateRoutine()
		{
			return null;
		}

		private void Recalculate(Settings settings)
		{
		}

		public float CalculateOptimizedValue(Settings settings, ScreenProperty property, OverrideScreenProperties parent)
		{
			return 0f;
		}

		private float CalculateCurrentValue(Settings settings, ScreenProperty property, OverrideScreenProperties parent, Rect rect)
		{
			return 0f;
		}

		public void InformChildren()
		{
		}
	}
}
