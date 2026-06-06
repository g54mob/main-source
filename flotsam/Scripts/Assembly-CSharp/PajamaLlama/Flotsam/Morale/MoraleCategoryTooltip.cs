using System.Text;
using System.Text.RegularExpressions;
using UnityEngine;

namespace PajamaLlama.Flotsam.Morale
{
	[DisallowMultipleComponent]
	public class MoraleCategoryTooltip : Tooltip
	{
		private MoraleCategory _moraleCategory;

		private Agent _agent;

		private static readonly StringBuilder _tooltipBuilder = new StringBuilder();

		public MoraleProperties MoraleProperties
		{
			get
			{
				if (!(_agent == null))
				{
					return _agent.Morale.Properties;
				}
				return null;
			}
		}

		public int CurrentLevel
		{
			get
			{
				if (!(_agent == null))
				{
					return _agent.Attributes.Level;
				}
				return 0;
			}
		}

		public int MaximumLevel
		{
			get
			{
				if (!(_agent == null))
				{
					return _agent.Attributes.MaximumDrifterLevel;
				}
				return 0;
			}
		}

		public void Initialize(MoraleCategory category, Agent agent)
		{
			_moraleCategory = category;
			_agent = agent;
			LocalizedText = category.Name;
		}

		public override string ParsedText()
		{
			_tooltipBuilder.Clear();
			_tooltipBuilder.AppendLine("<style=\"Tooltip Name\">" + base.ParsedText() + "</style>");
			string replacement = $"<color=#{ColorUtility.ToHtmlStringRGBA(_moraleCategory.Color)}>{_moraleCategory.SpeedMultiplier:0%}</color>";
			_tooltipBuilder.AppendLine(Regex.Replace(_moraleCategory.EffectTooltip, "%SPEED%", replacement, RegexOptions.IgnoreCase));
			if (MoraleProperties != null && MoraleProperties.TryReturnCategoryLimits(CurrentLevel, MaximumLevel, _moraleCategory, out var limits))
			{
				string input = Regex.Replace(_moraleCategory.RangeTooltip, "%MINIMUM%", limits.Minimum.ToString().AddSign(limits.Minimum), RegexOptions.IgnoreCase);
				input = Regex.Replace(input, "%MAXIMUM%", limits.Maximum.ToString().AddSign(limits.Maximum), RegexOptions.IgnoreCase);
				_tooltipBuilder.AppendLine(input);
			}
			return _tooltipBuilder.ToString();
		}
	}
}
