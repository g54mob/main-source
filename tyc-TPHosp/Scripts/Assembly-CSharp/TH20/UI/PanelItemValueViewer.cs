using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace TH20.UI
{
	public class PanelItemValueViewer : PanelItem
	{
		public enum ValueType
		{
			ValueTypeCount = 0,
			ValueTypeMoney = 1,
			ValueTypePercentage = 2
		}

		[SerializeField]
		private ValueType _valueType;

		[SerializeField]
		private LevelStatsDatabase.Stat Stat;

		[SerializeField]
		private Sprite _alternativeBackground;

		[SerializeField]
		private int _numberOfMonthsToQuery = 1;

		private Image _cachedBackgroundImageComponent;

		private TMP_Text _cachedValueText;

		private string _queryAssertText = "LevelStatsDatabase.QueryCurrentMonthStatMonthStats does not support {0} stat";

		public void SetValueText(string theText)
		{
			if (_cachedValueText == null)
			{
				TMP_Text[] componentsInChildren = GetComponentsInChildren<TMP_Text>(includeInactive: true);
				foreach (TMP_Text tMP_Text in componentsInChildren)
				{
					if (tMP_Text.name == "Value")
					{
						_cachedValueText = tMP_Text;
						break;
					}
				}
			}
			if (_cachedValueText != null)
			{
				_cachedValueText.text = theText;
			}
		}

		public void SetValueText(float theFloatValue)
		{
			switch (_valueType)
			{
			case ValueType.ValueTypeMoney:
				SetValueText(StringUtils.FormatCurrency((int)Math.Round(theFloatValue)));
				break;
			case ValueType.ValueTypePercentage:
				SetValueText($"{theFloatValue:0%}");
				break;
			case ValueType.ValueTypeCount:
				SetValueText($"{theFloatValue:0}");
				UpdateLocalisedTitleTextForValueCount((int)theFloatValue);
				break;
			default:
				SetValueText("");
				break;
			}
		}

		public void SetValueText(int theIntValue)
		{
			switch (_valueType)
			{
			case ValueType.ValueTypeMoney:
				SetValueText(StringUtils.FormatCurrency(theIntValue));
				break;
			case ValueType.ValueTypePercentage:
				SetValueText($"{theIntValue:0%}");
				break;
			case ValueType.ValueTypeCount:
				SetValueText($"{theIntValue:0}");
				UpdateLocalisedTitleTextForValueCount(theIntValue);
				break;
			default:
				SetValueText("");
				break;
			}
		}

		public void SetAlternativeBackground()
		{
			if (_alternativeBackground == null)
			{
				return;
			}
			if (_cachedBackgroundImageComponent == null)
			{
				Image[] componentsInChildren = GetComponentsInChildren<Image>(includeInactive: true);
				foreach (Image image in componentsInChildren)
				{
					if (image.name == "Background")
					{
						_cachedBackgroundImageComponent = image;
						break;
					}
				}
			}
			if (_cachedBackgroundImageComponent != null)
			{
				_cachedBackgroundImageComponent.overrideSprite = _alternativeBackground;
			}
		}

		public void ClearAlternativeBackground()
		{
			if (_cachedBackgroundImageComponent != null)
			{
				_cachedBackgroundImageComponent.overrideSprite = null;
			}
		}

		public override void UpdateStat(LevelStatsDatabase levelStatsDatabase)
		{
			if (Stat != LevelStatsDatabase.Stat.None)
			{
				double value = 0.0;
				if (_numberOfMonthsToQuery <= 1)
				{
					levelStatsDatabase.QueryCurrentMonthStat(Stat, out value);
				}
				else
				{
					double value2 = 0.0;
					double value3 = 0.0;
					levelStatsDatabase.QueryCurrentMonthStat(Stat, out value2);
					bool flag = levelStatsDatabase.QueryPreviousMonthsStatSummed(Stat, _numberOfMonthsToQuery - 1, out value3);
					value = value2 + value3;
				}
				SetValueText((int)value);
			}
		}
	}
}
