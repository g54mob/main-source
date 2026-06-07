using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace TheraBytes.BetterUi
{
	[ExecuteAlways]
	public class BetterAxisAlignedLayoutGroup : HorizontalOrVerticalLayoutGroup, IBetterHorizontalOrVerticalLayoutGroup, IResolutionDependency
	{
		[Serializable]
		public class Settings : IScreenConfigConnection
		{
			public TextAnchor ChildAlignment;

			public bool ReverseArrangement;

			public bool ChildForceExpandHeight;

			public bool ChildForceExpandWidth;

			public bool ChildScaleWidth;

			public bool ChildScaleHeight;

			public bool ChildControlWidth;

			public bool ChildControlHeight;

			public Axis Orientation;

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

			public Settings(TextAnchor childAlignment, bool expandWidth, bool expandHeight, Axis orientation)
			{
			}
		}

		[Serializable]
		public class SettingsConfigCollection : SizeConfigCollection<Settings>
		{
		}

		public enum Axis
		{
			Horizontal = 0,
			Vertical = 1
		}

		[SerializeField]
		private MarginSizeModifier paddingSizerFallback;

		[SerializeField]
		private MarginSizeConfigCollection customPaddingSizers;

		[SerializeField]
		private FloatSizeModifier spacingSizerFallback;

		[SerializeField]
		private FloatSizeConfigCollection customSpacingSizers;

		[SerializeField]
		private Settings settingsFallback;

		[SerializeField]
		private SettingsConfigCollection customSettings;

		[SerializeField]
		private Axis orientation;

		public MarginSizeModifier PaddingSizer => null;

		public FloatSizeModifier SpacingSizer => null;

		public Settings CurrentSettings => null;

		public Axis Orientation
		{
			get
			{
				return default(Axis);
			}
			set
			{
			}
		}

		private bool isVertical => false;

		protected override void OnEnable()
		{
		}

		protected override void OnTransformChildrenChanged()
		{
		}

		private IEnumerator SetDirtyDelayed()
		{
			return null;
		}

		protected override void OnRectTransformDimensionsChange()
		{
		}

		private IEnumerator InitDelayed()
		{
			return null;
		}

		public override void CalculateLayoutInputHorizontal()
		{
		}

		public override void CalculateLayoutInputVertical()
		{
		}

		public override void SetLayoutHorizontal()
		{
		}

		public override void SetLayoutVertical()
		{
		}

		public void OnResolutionChanged()
		{
		}

		public void CalculateCellSize()
		{
		}

		private void ApplySettings(Settings settings)
		{
		}
	}
}
