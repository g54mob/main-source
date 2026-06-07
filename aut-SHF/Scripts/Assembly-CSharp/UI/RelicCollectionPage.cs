using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.UI;

namespace UI
{
	public class RelicCollectionPage : BaseCollectionPage
	{
		[Serializable]
		private class RelicRarityCollectionComponent
		{
			public eRelicRarity rarity;

			public Sprite frameSprite;

			public RectTransform smallTitle;

			public RectTransform collectionParent;

			public Color textColor;

			public TMP_Text progressText;

			public int progressCountMax;

			public LocalizedString rarityLocalizeText;
		}

		public CollectionRelicListElement listElementPrefab;

		public RectTransform detailContent;

		public GameObject textContentsArea;

		public Image detailImage;

		public Image rarityImage;

		public Image detailMasterIcon;

		public TMP_Text detailRarityText;

		public TMP_Text detailDesc;

		[SerializeField]
		private List<RelicRarityCollectionComponent> relicRarityComponents;

		private CollectionListElement _selectedElement;

		private bool _finishInit;

		private int _selectedNumber;

		public override void Init()
		{
		}

		protected override void InitCollectionCountMax()
		{
		}

		private void UpdateSmallTitleProgressText()
		{
		}

		private void SetProgressTextForSmallTitle(RelicRarityCollectionComponent component)
		{
		}

		public override void AddCollection(int enumNumber)
		{
		}

		public override void SelectItem(int enumNumber, bool isSecret = false)
		{
		}

		public CollectionListElement CreateRalicListElement(eRelic relic)
		{
			return null;
		}

		public CollectionListElement CreateRalicListElement(MstRelicDataEntities relicData)
		{
			return null;
		}

		public override void SortElements()
		{
		}

		protected override int GetSortNum(CollectionListElement item)
		{
			return 0;
		}
	}
}
