using System;
using System.Collections.Generic;
using Brewery.Core;
using Brewery.Data;
using Brewery.NPC.TradingSystem;
using UnityEngine;
using UnityEngine.Serialization;

namespace Brewery.Calendar
{
	[CreateAssetMenu(fileName = "event.new", menuName = "Brewery/Calendar/Event Definition", order = 0)]
	public class CalendarEventDefinition : ScriptableObject
	{
		[Serializable]
		public struct TagEffect
		{
			public BrewTag Tag;

			public float Multiplier;
		}

		[Serializable]
		public struct BaseTypeEffect
		{
			public BaseType BaseType;

			public float Multiplier;
		}

		[Serializable]
		public struct FactionPriceEffect
		{
			public FactionType Faction;

			public float Multiplier;
		}

		[Serializable]
		public struct CatalystPriceEffect
		{
			public CatalystData Catalyst;

			public float Multiplier;
		}

		[Serializable]
		public struct CatalystCostEffect
		{
			public CatalystData Catalyst;

			public float CostMultiplier;
		}

		[Serializable]
		public struct CatalystLimitEffect
		{
			public CatalystData Catalyst;

			public float LimitMultiplier;
		}

		[Serializable]
		public struct FactionAccessEntry
		{
			public FactionType Faction;

			public FactionAccessMode Mode;
		}

		[Serializable]
		public struct TradeAvailabilityEntry
		{
			public TradeOffer TradeOffer;

			public bool Enabled;
		}

		[Header("Identity")]
		[Tooltip("Stable unique id, e.g. 'event.faction.bikers_day'. Used for save/load and debug.")]
		[SerializeField]
		private string m_Id;

		[Tooltip("Localization key in the 'Calendar' string table.")]
		[SerializeField]
		private string m_DisplayNameKey;

		[Tooltip("Localization key for the tooltip/description.")]
		[SerializeField]
		private string m_DescriptionKey;

		[SerializeField]
		private Sprite m_Icon;

		[Tooltip("Card tint on the calendar UI (hex, e.g. #8B5A2B).")]
		[SerializeField]
		private string m_ColorHex;

		[Tooltip("Designer-level disable switch; leaves the asset untouched.")]
		[FormerlySerializedAs("m_Enabled")]
		[SerializeField]
		private bool m_IsEnabled;

		[Header("Duration")]
		[Tooltip("1 = single-day event. >1 = multi-day event starting at its scheduled day.")]
		[Min(1f)]
		[SerializeField]
		private int m_DurationDays;

		[Header("Effects (flags)")]
		[Tooltip("Which payloads are active for this event.")]
		[SerializeField]
		private CalendarEffectType m_Effects;

		[Header("Tag price multipliers (× drink final price when tag present)")]
		[SerializeField]
		private TagEffect[] m_TagEffects;

		[Header("Base type price multipliers (× drink final price by base type)")]
		[SerializeField]
		private BaseTypeEffect[] m_BaseTypeEffects;

		[Header("Faction price multipliers (× drink final price when sold to faction)")]
		[SerializeField]
		private FactionPriceEffect[] m_FactionPriceEffects;

		[Header("Catalyst sale multipliers (× drink final price when drink contains catalyst)")]
		[SerializeField]
		private CatalystPriceEffect[] m_CatalystPriceEffects;

		[Header("Catalyst trader cost multipliers (× trader buy price)")]
		[SerializeField]
		private CatalystCostEffect[] m_CatalystCostEffects;

		[Header("Catalyst daily-limit multipliers (× base daily trade limit)")]
		[SerializeField]
		private CatalystLimitEffect[] m_CatalystLimitEffects;

		[Header("Faction bar-access rules")]
		[SerializeField]
		private FactionAccessEntry[] m_FactionAccessEntries;

		[Header("Trade offer availability overrides")]
		[SerializeField]
		private TradeAvailabilityEntry[] m_TradeAvailabilityEntries;

		[Header("Stacking (reserved for future use — runtime does not enforce yet)")]
		[Tooltip("Optional group id; empty = no group.")]
		[SerializeField]
		private string m_StackGroup;

		[Tooltip("If true AND stackGroup is set, at most one event from the group fires per day.")]
		[SerializeField]
		private bool m_ExclusiveWithinGroup;

		public string Id => null;

		public string DisplayNameKey => null;

		public string DescriptionKey => null;

		public Sprite Icon => null;

		public string ColorHex => null;

		public bool Enabled => false;

		public int DurationDays => 0;

		public CalendarEffectType Effects => default(CalendarEffectType);

		public IReadOnlyList<TagEffect> TagEffects => null;

		public IReadOnlyList<BaseTypeEffect> BaseTypeEffects => null;

		public IReadOnlyList<FactionPriceEffect> FactionPriceEffects => null;

		public IReadOnlyList<CatalystPriceEffect> CatalystPriceEffects => null;

		public IReadOnlyList<CatalystCostEffect> CatalystCostEffects => null;

		public IReadOnlyList<CatalystLimitEffect> CatalystLimitEffects => null;

		public IReadOnlyList<FactionAccessEntry> FactionAccessEntries => null;

		public IReadOnlyList<TradeAvailabilityEntry> TradeAvailabilityEntries => null;

		public string StackGroup => null;

		public bool ExclusiveWithinGroup => false;

		private void OnValidate()
		{
		}
	}
}
