using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace TheraBytes.BetterUi
{
	[ExecuteAlways]
	public class BetterContentSizeFitter : ContentSizeFitter, IResolutionDependency, ILayoutChildDependency
	{
		[Serializable]
		public class Settings : IScreenConfigConnection
		{
			public FitMode HorizontalFit;

			public FitMode VerticalFit;

			public bool IsAnimated;

			public float AnimationTime;

			public bool HasMinWidth;

			public bool HasMinHeight;

			public bool HasMaxWidth;

			public bool HasMaxHeight;

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
		private RectTransform source;

		[SerializeField]
		private Settings settingsFallback;

		[SerializeField]
		private SettingsConfigCollection customSettings;

		[SerializeField]
		private FloatSizeModifier minWidthSizerFallback;

		[SerializeField]
		private FloatSizeConfigCollection minWidthSizers;

		[SerializeField]
		private FloatSizeModifier minHeightSizerFallback;

		[SerializeField]
		private FloatSizeConfigCollection minHeightSizers;

		[SerializeField]
		private FloatSizeModifier maxWidthSizerFallback;

		[SerializeField]
		private FloatSizeConfigCollection maxWidthSizers;

		[SerializeField]
		private FloatSizeModifier maxHeightSizerFallback;

		[SerializeField]
		private FloatSizeConfigCollection maxHeightSizers;

		[SerializeField]
		private Vector2SizeModifier paddingFallback;

		[SerializeField]
		private Vector2SizeConfigCollection paddingSizers;

		private RectTransformData start;

		private RectTransformData end;

		private bool isAnimating;

		private RectTransform rectTransform => null;

		public Settings CurrentSettings => null;

		public RectTransform Source
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		protected override void OnEnable()
		{
		}

		protected override void OnDisable()
		{
		}

		public void OnResolutionChanged()
		{
		}

		private void Apply()
		{
		}

		public override void SetLayoutHorizontal()
		{
		}

		public override void SetLayoutVertical()
		{
		}

		private void SetLayout(int axis)
		{
		}

		private void ApplyOffsetToDefaultSize(int axis, FitMode fitMode)
		{
		}

		private float ClampSize(RectTransform.Axis axis, float size)
		{
			return 0f;
		}

		private Bounds GetChildBounds()
		{
			return default(Bounds);
		}

		public void ChildSizeChanged(Transform child)
		{
		}

		public void ChildAddedOrEnabled(Transform child)
		{
		}

		public void ChildRemovedOrDisabled(Transform child)
		{
		}

		private void ChildChanged()
		{
		}

		private void Animate()
		{
		}

		private IEnumerator CoAnimate()
		{
			return null;
		}
	}
}
