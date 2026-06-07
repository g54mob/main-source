using System.Collections.Generic;
using Brewery.Core;
using UnityEngine;

namespace Brewery.Data
{
	[CreateAssetMenu(fileName = "New Legendary Recipe", menuName = "Brewery/Legendary Recipe")]
	public class LegendaryRecipe : ScriptableObject
	{
		[Header("Recipe Definition")]
		[SerializeField]
		private string m_LegendaryName;

		[SerializeField]
		private string m_LegendaryNameKey;

		[SerializeField]
		[TextArea(2, 3)]
		private string m_Description;

		[SerializeField]
		private string m_DescriptionKey;

		[SerializeField]
		private BaseType m_RequiredBaseType;

		[SerializeField]
		private List<BrewTag> m_RequiredTags;

		[Header("Bonuses")]
		[SerializeField]
		[Range(1f, 2f)]
		private float m_PriceMultiplier;

		[SerializeField]
		private int m_ReputationBonus;

		[Header("Visuals")]
		[SerializeField]
		private Sprite m_Icon;

		[SerializeField]
		private Color m_GlowColor;

		[SerializeField]
		private string m_FlavorText;

		[Header("Discovery")]
		[SerializeField]
		private bool m_StartsDiscovered;

		[SerializeField]
		private string m_DiscoveryHint;

		public string LegendaryName => null;

		public string Description => null;

		public BaseType RequiredBaseType => default(BaseType);

		public List<BrewTag> RequiredTags => null;

		public float PriceMultiplier => 0f;

		public int ReputationBonus => 0;

		public Sprite Icon => null;

		public Color GlowColor => default(Color);

		public string FlavorText => null;

		public bool StartsDiscovered => false;

		public string DiscoveryHint => null;

		public bool MatchesTags(BrewTag combinedTags, BaseType baseType)
		{
			return false;
		}

		public string GetTagsString()
		{
			return null;
		}

		public BrewTag GetCombinedTags()
		{
			return default(BrewTag);
		}

		private void OnValidate()
		{
		}
	}
}
