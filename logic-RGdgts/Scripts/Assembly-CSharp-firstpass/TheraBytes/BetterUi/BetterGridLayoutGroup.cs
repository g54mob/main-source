using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace TheraBytes.BetterUi
{
	[ExecuteAlways]
	public class BetterGridLayoutGroup : GridLayoutGroup, IResolutionDependency
	{
		[Serializable]
		public class Settings : IScreenConfigConnection
		{
			public Constraint Constraint;

			public int ConstraintCount;

			public TextAnchor ChildAlignment;

			public Axis StartAxis;

			public Corner StartCorner;

			public bool Fit;

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

			public Settings(BetterGridLayoutGroup grid)
			{
			}
		}

		[Serializable]
		public class SettingsConfigCollection : SizeConfigCollection<Settings>
		{
		}

		[SerializeField]
		private MarginSizeModifier paddingSizerFallback;

		[SerializeField]
		private MarginSizeConfigCollection customPaddingSizers;

		[SerializeField]
		private Vector2SizeModifier cellSizerFallback;

		[SerializeField]
		private Vector2SizeConfigCollection customCellSizers;

		[SerializeField]
		private Vector2SizeModifier spacingSizerFallback;

		[SerializeField]
		private Vector2SizeConfigCollection customSpacingSizers;

		[SerializeField]
		private Settings settingsFallback;

		[SerializeField]
		private SettingsConfigCollection customSettings;

		[SerializeField]
		private bool fit;

		public MarginSizeModifier PaddingSizer => null;

		public Vector2SizeModifier CellSizer => null;

		public Vector2SizeModifier SpacingSizer => null;

		public Settings CurrentSettings => null;

		public bool Fit
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		protected override void OnRectTransformDimensionsChange()
		{
		}

		protected override void OnEnable()
		{
		}

		private IEnumerator InitDelayed()
		{
			return null;
		}

		public void OnResolutionChanged()
		{
		}

		public void CalculateCellSize()
		{
		}

		public float GetCellWidth()
		{
			return 0f;
		}

		public float GetCellHeight()
		{
			return 0f;
		}

		private void ApplySettings(Settings settings)
		{
		}
	}
}
