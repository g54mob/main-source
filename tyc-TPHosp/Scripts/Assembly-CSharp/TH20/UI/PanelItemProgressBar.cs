using UnityEngine;
using UnityEngine.UI;

namespace TH20.UI
{
	public class PanelItemProgressBar : PanelItem
	{
		private enum DisplayType
		{
			DtLowToHigh = 0,
			DtHighToLow = 1
		}

		[SerializeField]
		private LevelStatsDatabase.Stat Stat;

		[SerializeField]
		private DisplayType _displayType;

		[SerializeField]
		private double _minValue;

		[SerializeField]
		private double _maxValue = 1000.0;

		[SerializeField]
		private Color _theBarColour;

		[SerializeField]
		private RectTransform _theBar;

		[SerializeField]
		private RectTransform _rectTranformForBarWidth;

		[SerializeField]
		private LocalisedString _aditionalTooltipText;

		[SerializeField]
		private bool _autoGenerateTooltip = true;

		[SerializeField]
		private bool _useEntirePanelForTooltip = true;

		[SerializeField]
		private bool _debugProgressBar;

		[SerializeField]
		private float _marginLeft = 2f;

		[SerializeField]
		private float _marginRight = 4f;

		[SerializeField]
		private float _marginTop = 2f;

		[SerializeField]
		private float _marginBottom = 4f;

		private float _progress = float.NegativeInfinity;

		private Image _theBarImage;

		private float _startX;

		private float _startY;

		private float _sizeX;

		private float _sizeY;

		private string _queryAssertText = "LevelStatsDatabase.QueryCurrentMonthStatMonthStats does not support {0} stat";

		public static float _overrideProgressValue = -1f;

		public float Progress
		{
			get
			{
				return _progress;
			}
			set
			{
				if (_progress != value)
				{
					_progress = value;
					if (_overrideProgressValue >= 0f)
					{
						_progress = _overrideProgressValue;
					}
					UpdateProgressBarSizeX();
				}
			}
		}

		public Color BarColour
		{
			get
			{
				if ((bool)_theBarImage)
				{
					return _theBarImage.color;
				}
				return Color.white;
			}
			set
			{
				if (_theBarColour != value)
				{
					_theBarColour = value;
					if ((bool)_theBarImage)
					{
						_theBarImage.color = _theBarColour;
					}
				}
			}
		}

		public override void Setup()
		{
			base.Setup();
			CheckUpdateProgressBarWidth();
			if (_theBar != null)
			{
				_theBarImage = _theBar.GetComponent<Image>();
			}
			BarColour = _theBarColour;
			Progress = 0f;
		}

		public void CheckUpdateProgressBarWidth()
		{
			RectTransform rectForBarWidth = GetRectForBarWidth();
			if (rectForBarWidth != null && rectForBarWidth.rect.width > 0f && rectForBarWidth.rect.height > 0f)
			{
				float num = rectForBarWidth.rect.width - _marginLeft - _marginRight;
				float num2 = rectForBarWidth.rect.height - _marginTop - _marginBottom;
				if (_sizeX != num || _sizeY != num2)
				{
					_sizeX = num;
					_sizeY = num2;
					_startX = _marginLeft;
					_startY = _marginTop;
					UpdateProgressBarSizeX();
					UpdateProgressBarSizeY();
				}
			}
		}

		private void UpdateProgressBarSizeX()
		{
			if (_theBar != null && _sizeX > 0f)
			{
				_theBar.SetInsetAndSizeFromParentEdge(RectTransform.Edge.Left, _startX, _sizeX * Mathf.Clamp01(_progress));
			}
		}

		private void UpdateProgressBarSizeY()
		{
			if (_theBar != null && _sizeY > 0f)
			{
				_theBar.SetInsetAndSizeFromParentEdge(RectTransform.Edge.Top, _startY, _sizeY);
			}
		}

		private RectTransform GetRectForBarWidth()
		{
			RectTransform rectTransform = _rectTranformForBarWidth;
			if (rectTransform == null && _theBar != null)
			{
				rectTransform = ((!(_theBar.parent != null)) ? _theBar : (_theBar.parent as RectTransform));
			}
			return rectTransform;
		}

		public void SetupTooltip(GameObject tooltipText)
		{
			if (!_autoGenerateTooltip)
			{
				return;
			}
			GameObject gameObject = base.gameObject;
			if (!_useEntirePanelForTooltip && _theBar != null)
			{
				int num = 3;
				GameObject gameObject2 = null;
				GameObject gameObject3 = _theBar.gameObject;
				for (int i = 0; i < num; i++)
				{
					if (!(gameObject3 != null))
					{
						break;
					}
					gameObject3 = gameObject3.transform.parent.gameObject;
					if (gameObject3 != null && gameObject3.GetComponent<Image>() != null)
					{
						gameObject2 = gameObject3;
						break;
					}
				}
				if (gameObject2 != null)
				{
					gameObject = gameObject2;
				}
			}
			if (!(gameObject != null))
			{
				return;
			}
			TooltipSpawner tooltipSpawner = gameObject.GetComponent<TooltipSpawner>();
			if (tooltipSpawner == null)
			{
				tooltipSpawner = gameObject.AddComponent<TooltipSpawner>();
			}
			tooltipSpawner.HoverTime = 0.25f;
			tooltipSpawner.AnchorToMouse = false;
			tooltipSpawner.Prefab = tooltipText;
			tooltipSpawner.SetDataProvider(delegate(Tooltip tooltip)
			{
				string text = string.Empty;
				bool num2 = !string.IsNullOrEmpty(_aditionalTooltipText.Term);
				if (num2)
				{
					text += "<b>";
				}
				text += $"{GetTitleText()} {StringUtils.FormatPercentageValue(Progress)}";
				if (num2)
				{
					text += "</b>";
					text += "\n";
					text += _aditionalTooltipText.Translation;
				}
				tooltip.Text = text;
			});
			Image image = gameObject.GetComponent<Image>();
			if (image == null)
			{
				image = gameObject.AddComponent<Image>();
				Color color = image.color;
				color.a = 0f;
				image.color = color;
			}
			image.raycastTarget = true;
		}

		public override void UpdateStat(LevelStatsDatabase levelStatsDatabase)
		{
			if (Stat != LevelStatsDatabase.Stat.None)
			{
				double value = 0.0;
				levelStatsDatabase.QueryCurrentMonthStat(Stat, out value);
				if (value < _minValue)
				{
					_minValue = value;
				}
				if (value > _maxValue)
				{
					_maxValue = value;
				}
				double num = _maxValue - _minValue;
				float num2 = ((num != 0.0) ? ((float)((value - _minValue) / num)) : 0f);
				Progress = ((_displayType == DisplayType.DtLowToHigh) ? num2 : (1f - num2));
			}
		}

		public void ApplyColourRange(Color[] colourRange)
		{
			if (colourRange != null && colourRange.Length != 0)
			{
				int num = (int)Mathf.Floor(Progress * (float)(colourRange.Length - 1));
				if (num >= 0 && num < colourRange.Length)
				{
					BarColour = colourRange[num];
				}
			}
		}
	}
}
