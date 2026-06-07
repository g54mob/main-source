using System;
using System.Collections.Generic;
using Gh.Tk.UI.Dialogs;
using I18n;
using UnityEngine;

namespace Gh.Tk
{
	public class CollectibleCard3DUIView : Trophy3DUIView
	{
		[Serializable]
		public class CardStyle
		{
			public CollectibleCardData.CardType cardType;

			public Sprite cardHeaderSprite;

			public Material cardBackMaterial;
		}

		private bool _useDissolve;

		[SerializeField]
		private MeshRenderer _cardBack;

		[SerializeField]
		private SpriteRenderer _cardHeader;

		[SerializeField]
		private SpriteRenderer _cardImage;

		private bool showRarityEffects;

		[SerializeField]
		private GameObject _cardRarityEdgeLegendary;

		[SerializeField]
		private GameObject _cardRarityEdgeEpic;

		[SerializeField]
		private TextMeshProI18n _titleText;

		[SerializeField]
		private TextMeshProI18n _cardTypeText;

		[SerializeField]
		private TextMeshProI18n _descriptionText;

		[SerializeField]
		private TextMeshProI18n _runNumberText;

		[SerializeField]
		private TextMeshProI18n _rarityText;

		[SerializeField]
		private List<CardStyle> _cardStyles;

		[Header("Card Rarity Colors")]
		[SerializeField]
		private Color rarityCommon;

		[SerializeField]
		private Color rarityRare;

		[SerializeField]
		private Color rarityEpic;

		[SerializeField]
		private Color rarityLegendary;

		public static List<CollectibleCard3DUIView> ActiveCards { get; }

		public static int TotalCardCount => 0;

		public CollectibleCardData CardData { get; private set; }

		private void OnEnable()
		{
		}

		private void OnDisable()
		{
		}

		public void SetData(CollectibleCardData cardData, bool useDissolve)
		{
		}

		public void SetRarityEffectsEnabled(bool isEnabled)
		{
		}

		public void UpdateVisuals()
		{
		}

		private void SetCardType(CollectibleCardData.CardType type)
		{
		}

		private void SetCardRarity(CollectibleCardData.CardRarity rarity)
		{
		}

		private void ApplyDissolveSettings()
		{
		}
	}
}
