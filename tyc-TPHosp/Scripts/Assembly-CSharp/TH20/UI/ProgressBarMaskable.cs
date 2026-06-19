using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace TH20.UI
{
	[AddComponentMenu("UI/Progress Bar Maskable", 110)]
	public class ProgressBarMaskable : ElementLayoutController, ILayoutGroup, ILayoutController
	{
		public enum ProgressDirection
		{
			LeftToRight = 0,
			RightToLeft = 1,
			BottomToTop = 2,
			TopToBottom = 3
		}

		private static readonly float Precision = 0.001f;

		[SerializeField]
		[FormerlySerializedAs("BarGradient")]
		private Gradient _barGradient;

		public ProgressDirection Direction;

		public RectTransform BarTransform;

		public RectOffset BarPadding;

		public bool UseMask;

		public Image BarImage;

		public bool ColorizeBar = true;

		public float MinVisibleBarSize;

		public float SmoothProgressSpeed = 1f;

		public bool Clamp = true;

		public ProgressBarChevron _chevron;

		public TMP_Text _label;

		public Action<int, int> OnLoopRound;

		private float _targetProgress;

		[Range(0f, 1f)]
		[SerializeField]
		private float _progress = 0.5f;

		private Coroutine _activeCoroutine;

		private bool _hasProgressBeenInitialised;

		public string LabelText
		{
			set
			{
				if (_label != null)
				{
					_label.text = value;
				}
			}
		}

		public float Progress
		{
			get
			{
				return _progress;
			}
			set
			{
				SetProgressInternal(value);
				_targetProgress = _progress;
			}
		}

		public Gradient BarGradient
		{
			get
			{
				return _barGradient;
			}
			set
			{
				if (_barGradient != value)
				{
					_barGradient = value;
					SetDirty();
				}
			}
		}

		public float PresentedProgress => ToPresentedProgress(_progress, Clamp);

		private static float ToPresentedProgress(float progress, bool clamp)
		{
			if (clamp)
			{
				return progress;
			}
			return (progress % 1f + 1f) % 1f;
		}

		protected override void OnEnable()
		{
			base.OnEnable();
			if (_hasProgressBeenInitialised)
			{
				SetProgressInternal(_targetProgress);
			}
		}

		private void SetProgressInternal(float progress)
		{
			float progress2 = _progress;
			if (Clamp)
			{
				_progress = Mathf.Clamp01(progress);
			}
			else
			{
				_progress = progress;
				if (Mathf.FloorToInt(progress2) != Mathf.FloorToInt(_progress))
				{
					OnLoopRound.InvokeSafe(Mathf.FloorToInt(progress2), Mathf.FloorToInt(_progress));
				}
			}
			_hasProgressBeenInitialised = true;
			if (Mathf.RoundToInt(ToPresentedProgress(progress2, Clamp) / Precision) != Mathf.RoundToInt(ToPresentedProgress(_progress, Clamp) / Precision))
			{
				SetDirty();
			}
			if (_chevron != null)
			{
				_chevron.Delta = _progress - progress2;
			}
		}

		public void SetProgressSmooth(float targetProgress)
		{
			if (!_hasProgressBeenInitialised)
			{
				Progress = targetProgress;
				_hasProgressBeenInitialised = true;
			}
			else if (Mathf.RoundToInt(targetProgress / Precision) != Mathf.RoundToInt(_targetProgress / Precision))
			{
				_targetProgress = targetProgress;
				if (_activeCoroutine == null && base.isActiveAndEnabled)
				{
					_activeCoroutine = StartCoroutine(ProgressSmooth());
				}
			}
		}

		private IEnumerator ProgressSmooth()
		{
			yield return null;
			while (Mathf.RoundToInt(_progress / Precision) != Mathf.RoundToInt(_targetProgress / Precision))
			{
				float num = Mathf.Sign(_targetProgress - _progress) * Mathf.Clamp(SmoothProgressSpeed * Time.unscaledDeltaTime, 0f, Mathf.Abs(_targetProgress - _progress));
				SetProgressInternal(Progress + num);
				yield return null;
			}
			Progress = _targetProgress;
			_activeCoroutine = null;
		}

		public void SetLayoutHorizontal()
		{
			SetBarLayout(RectTransform.Axis.Horizontal);
			SetBarColor();
		}

		public void SetLayoutVertical()
		{
			SetBarLayout(RectTransform.Axis.Vertical);
			SetBarColor();
		}

		private void SetBarLayout(RectTransform.Axis axis)
		{
			if (BarTransform == null)
			{
				return;
			}
			RectTransform rectTransform = BarTransform.parent as RectTransform;
			if (rectTransform == null)
			{
				UnityEngine.Debug.LogWarning("Bar Transform parent doesn't have a RectTransform", this);
				return;
			}
			float num = rectTransform.rect.width - (float)BarPadding.horizontal;
			float num2 = rectTransform.rect.height - (float)BarPadding.vertical;
			switch (Direction)
			{
			case ProgressDirection.LeftToRight:
			{
				float num5 = PresentedProgress * num;
				if (num5 < MinVisibleBarSize)
				{
					num5 = 0f;
					SetBarImageVisibilty(visible: false);
				}
				else
				{
					SetBarImageVisibilty(visible: true);
				}
				if (UseMask)
				{
					if (axis == RectTransform.Axis.Horizontal)
					{
						Vector2 anchoredPosition = BarTransform.anchoredPosition;
						anchoredPosition.x = num5 - num;
						BarTransform.anchoredPosition = anchoredPosition;
					}
					break;
				}
				switch (axis)
				{
				case RectTransform.Axis.Horizontal:
					BarTransform.SetInsetAndSizeFromParentEdgeSafe(RectTransform.Edge.Left, BarPadding.left, num5);
					break;
				case RectTransform.Axis.Vertical:
					BarTransform.SetInsetAndSizeFromParentEdgeSafe(RectTransform.Edge.Top, BarPadding.top, num2);
					break;
				}
				break;
			}
			case ProgressDirection.RightToLeft:
			{
				float num4 = PresentedProgress * num;
				if (num4 < MinVisibleBarSize)
				{
					num4 = 0f;
					SetBarImageVisibilty(visible: false);
				}
				else
				{
					SetBarImageVisibilty(visible: true);
				}
				switch (axis)
				{
				case RectTransform.Axis.Horizontal:
					BarTransform.SetInsetAndSizeFromParentEdgeSafe(RectTransform.Edge.Right, BarPadding.right, num4);
					break;
				case RectTransform.Axis.Vertical:
					BarTransform.SetInsetAndSizeFromParentEdgeSafe(RectTransform.Edge.Top, BarPadding.top, num2);
					break;
				}
				break;
			}
			case ProgressDirection.TopToBottom:
			{
				float num6 = PresentedProgress * num2;
				if (num6 < MinVisibleBarSize)
				{
					num6 = 0f;
					SetBarImageVisibilty(visible: false);
				}
				else
				{
					SetBarImageVisibilty(visible: true);
				}
				switch (axis)
				{
				case RectTransform.Axis.Horizontal:
					BarTransform.SetInsetAndSizeFromParentEdgeSafe(RectTransform.Edge.Left, BarPadding.left, num);
					break;
				case RectTransform.Axis.Vertical:
					BarTransform.SetInsetAndSizeFromParentEdgeSafe(RectTransform.Edge.Top, BarPadding.top, num6);
					break;
				}
				break;
			}
			case ProgressDirection.BottomToTop:
			{
				float num3 = PresentedProgress * num2;
				if (num3 < MinVisibleBarSize)
				{
					num3 = 0f;
					SetBarImageVisibilty(visible: false);
				}
				else
				{
					SetBarImageVisibilty(visible: true);
				}
				switch (axis)
				{
				case RectTransform.Axis.Horizontal:
					BarTransform.SetInsetAndSizeFromParentEdgeSafe(RectTransform.Edge.Left, BarPadding.left, num);
					break;
				case RectTransform.Axis.Vertical:
					BarTransform.SetInsetAndSizeFromParentEdgeSafe(RectTransform.Edge.Bottom, BarPadding.top, num3);
					break;
				}
				break;
			}
			}
		}

		private void SetBarImageVisibilty(bool visible)
		{
			if (BarImage != null)
			{
				BarImage.transform.localScale = (visible ? Vector3.one : Vector3.zero);
			}
		}

		private void SetBarColor()
		{
			if (BarImage != null && ColorizeBar)
			{
				BarImage.color = BarGradient.Evaluate(_progress);
			}
		}
	}
}
