using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Xml.Linq;
using ModApi.Common.Extensions;
using ModApi.Expressions;
using UnityEngine;

namespace Assets.Scripts.Career.Milestones
{
	public class Milestone
	{
		public delegate void MilestoneTierDelegate(Milestone milestone, MilestoneTier tier);

		public class MilestoneTier
		{
			public string Description { get; set; }

			public long Money { get; set; }

			public int Research { get; set; }

			public string RewardMessage { get; set; }

			public double Value { get; set; }
		}

		public const string ElementName = "Milestone";

		private static string[] _attributes = new string[11]
		{
			"accumulate", "description", "event", "expression", "id", "name", "persistent", "planet", "reversed", "startValue",
			"valueFormat"
		};

		private static string[] _attributesTier = new string[5] { "research", "money", "value", "description", "rewardMessage" };

		private Func<double> _compiledFunction;

		private double _startValue;

		public bool Accumulate { get; }

		public int CurrentTierIndex { get; private set; }

		public string Description { get; }

		public MilestoneEventType EventType { get; private set; }

		public string Expression { get; }

		public string Id { get; private set; }

		public bool IsActive { get; set; }

		public bool IsComplete => Tier == null;

		public string Name { get; }

		public bool Persistent { get; }

		public string Planet { get; }

		public bool Reversed { get; }

		public string ThresholdText
		{
			get
			{
				if (!IsComplete)
				{
					return StringProcessor.FormatDouble(Tier.Value, ValueFormat);
				}
				return "COMPLETE";
			}
		}

		public MilestoneTier Tier { get; private set; }

		public float TierPercentageComplete
		{
			get
			{
				if (IsComplete)
				{
					return 1f;
				}
				double num = _startValue;
				if (CurrentTierIndex > 0)
				{
					num = Tiers[CurrentTierIndex - 1].Value;
				}
				return (float)Mathd.InverseLerp(num, Tier.Value, Value);
			}
		}

		public List<MilestoneTier> Tiers { get; private set; } = new List<MilestoneTier>();

		public double Value { get; private set; }

		public string ValueFormat { get; }

		public string ValueText
		{
			get
			{
				if (!IsComplete)
				{
					return StringProcessor.FormatDouble(Value, ValueFormat);
				}
				return "COMPLETE";
			}
		}

		public event MilestoneTierDelegate AdvancedToNextTier;

		public Milestone(XElement xml)
		{
			Planet = xml.GetStringAttribute("planet");
			Id = ((Planet != null) ? (Planet + ".") : string.Empty) + xml.GetStringAttribute("id");
			Name = xml.GetStringAttribute("name");
			Description = xml.GetStringAttribute("description");
			ValueFormat = xml.GetStringAttribute("valueFormat");
			Expression = CareerUtilities.GetExpressionString(xml, "expression");
			Persistent = xml.GetBoolAttribute("persistent");
			Reversed = xml.GetBoolAttribute("reversed");
			Accumulate = xml.GetBoolAttribute("accumulate");
			_startValue = xml.GetDoubleAttribute("startValue");
			Value = _startValue;
			EventType = xml.GetEnumAttribute("event", MilestoneEventType.Update);
			foreach (XElement item2 in xml.Elements("Tier"))
			{
				MilestoneTier item = new MilestoneTier
				{
					Research = item2.GetIntAttribute("research"),
					Money = item2.GetLongAttribute("money", 0L),
					Value = item2.GetDoubleAttribute("value"),
					Description = item2.GetStringAttribute("description"),
					RewardMessage = item2.GetStringAttribute("rewardMessage")
				};
				Tiers.Add(item);
				ValidateTierAttributes(item2);
			}
			SetTier(0);
			ValidateAttributes(xml);
		}

		public XElement GenerateStatusXml()
		{
			XElement xElement = new XElement("Milestone");
			xElement.SetAttributeValue("id", Id);
			xElement.SetAttributeValue("value", Value);
			xElement.SetAttributeValue("tier", CurrentTierIndex);
			return xElement;
		}

		public void OnFlightEnd()
		{
			_compiledFunction = null;
		}

		public void OnFlightStart(IFlightContext flight)
		{
			try
			{
				Context context = new Context(true, (typeof(IFlightContext), flight, null, true));
				PropertyInfo property = GetType().GetProperty("Value");
				context.AddVariable("value", property.GetGetMethod(), this);
				_compiledFunction = Parser.Process<double>(Expression, context);
			}
			catch (Exception arg)
			{
				Debug.LogError($"Milestone expression error: {Expression}\n{arg}");
				_compiledFunction = null;
			}
		}

		public void RestoreStatus(XElement statusElement)
		{
			Value = statusElement.GetDoubleAttribute("value");
			SetTier(statusElement.GetIntAttribute("tier"));
		}

		public void Update()
		{
			if (_compiledFunction != null)
			{
				double num = _compiledFunction();
				if (Accumulate)
				{
					Value += num;
				}
				else
				{
					Value = num;
				}
				UpdateTier(Value);
			}
		}

		private void SetTier(int tierIndex)
		{
			CurrentTierIndex = tierIndex;
			if (tierIndex < Tiers.Count)
			{
				Tier = Tiers[tierIndex];
			}
			else
			{
				Tier = null;
			}
		}

		private void UpdateTier(double value)
		{
			if (Tier != null && (Reversed ? (value <= Tier.Value) : (value >= Tier.Value)))
			{
				this.AdvancedToNextTier?.Invoke(this, Tier);
				SetTier(CurrentTierIndex + 1);
				UpdateTier(value);
			}
		}

		private void ValidateAttributes(XElement xml)
		{
			foreach (XAttribute item in xml.Attributes())
			{
				if (!_attributes.Contains(item.Name.LocalName))
				{
					throw new Exception($"Milestone {Id} has unsupported attribute {item.Name}");
				}
			}
		}

		private void ValidateTierAttributes(XElement xml)
		{
			foreach (XAttribute item in xml.Attributes())
			{
				if (!_attributesTier.Contains(item.Name.LocalName))
				{
					throw new Exception($"Milestone {Id} has unsupported attribute {item.Name} in one of its tiers.");
				}
			}
		}
	}
}
