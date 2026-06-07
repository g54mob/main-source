using System;
using System.Collections.Generic;
using Brewery.Core;
using UnityEngine;

namespace Brewery.Data
{
	[CreateAssetMenu(fileName = "New Faction", menuName = "Brewery/Faction")]
	public class FactionData : ScriptableObject
	{
		[Serializable]
		public class TagMultiplier
		{
			public BrewTag Tag;

			public float Multiplier;
		}

		[Serializable]
		public class BaseTypeMultiplier
		{
			public BaseType BaseType;

			public float Multiplier;
		}

		[Header("Basic Information")]
		[SerializeField]
		private FactionType m_FactionType;

		[SerializeField]
		private string m_FactionName;

		[SerializeField]
		[TextArea(2, 3)]
		private string m_Description;

		[Header("Localization")]
		[SerializeField]
		private string factionNameKey;

		[SerializeField]
		private string descriptionKey;

		[Header("Visual")]
		[SerializeField]
		private Sprite m_FactionIcon;

		[SerializeField]
		private Color m_FactionColor;

		[Header("Tag Multipliers")]
		[SerializeField]
		private TagMultiplier[] m_TagMultipliers;

		[Header("Base Type Multipliers")]
		[SerializeField]
		private BaseTypeMultiplier[] m_BaseTypeMultipliers;

		[Header("Buying Behavior")]
		[SerializeField]
		private string m_BuyingStyle;

		[SerializeField]
		private float m_VolumePreference;

		[SerializeField]
		private float m_QualityPreference;

		private Dictionary<BrewTag, float> m_TagMultiplierCache;

		private Dictionary<BaseType, float> m_BaseMultiplierCache;

		public FactionType FactionType => default(FactionType);

		public string FactionName => null;

		public string Description => null;

		public Sprite FactionIcon => null;

		public Color FactionColor => default(Color);

		public string BuyingStyle => null;

		public float VolumePreference => 0f;

		public float QualityPreference => 0f;

		public float GetTagMultiplier(BrewTag tag)
		{
			return 0f;
		}

		public float GetBaseTypeMultiplier(BaseType baseType)
		{
			return 0f;
		}

		public float CalculateCombinedMultiplier(BaseType baseType, BrewTag tags)
		{
			return 0f;
		}

		public bool WillRefuse(BrewTag tags)
		{
			return false;
		}

		public BrewTag GetRefusedTags()
		{
			return default(BrewTag);
		}

		private void BuildCacheIfNeeded()
		{
		}

		private void OnValidate()
		{
		}
	}
}
