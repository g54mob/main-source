using System.Collections.Generic;
using Brewery.Core;
using UnityEngine;

namespace Brewery.Data
{
	[CreateAssetMenu(fileName = "New Catalyst", menuName = "Brewery/Catalyst")]
	public class CatalystData : ScriptableObject
	{
		[Header("Basic Information")]
		[SerializeField]
		private string m_CatalystId;

		[SerializeField]
		private string m_CatalystName;

		[SerializeField]
		private string m_CatalystNameKey;

		[SerializeField]
		[TextArea(2, 3)]
		private string m_Description;

		[SerializeField]
		private string m_DescriptionKey;

		[SerializeField]
		private Sprite m_Icon;

		[Header("Tags")]
		[SerializeField]
		private List<BrewTag> m_Tags;

		[Header("Properties")]
		[SerializeField]
		private Rarity m_Rarity;

		[SerializeField]
		private string m_TypicalSource;

		[Header("Economy")]
		[SerializeField]
		private float m_BaseAcquisitionCost;

		[SerializeField]
		private float m_MarketAvailability;

		public string CatalystId => null;

		public string CatalystName => null;

		public string Description => null;

		public Sprite Icon => null;

		public List<BrewTag> Tags => null;

		public Rarity Rarity => default(Rarity);

		public string TypicalSource => null;

		public float BaseAcquisitionCost => 0f;

		public float MarketAvailability => 0f;

		public BrewTag GetCombinedTags()
		{
			return default(BrewTag);
		}

		public bool HasTag(BrewTag tag)
		{
			return false;
		}

		public string GetTagsString()
		{
			return null;
		}

		private void OnValidate()
		{
		}
	}
}
