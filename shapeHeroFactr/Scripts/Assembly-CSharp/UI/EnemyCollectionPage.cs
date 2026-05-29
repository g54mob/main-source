using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
	public class EnemyCollectionPage : BaseCollectionPage
	{
		[Serializable]
		private class EnemyCollectionComponent
		{
			public eEnemyType type;

			public RectTransform smallTitle;

			public RectTransform collectionParent;

			public TMP_Text progressText;

			public int progressCountMax;
		}

		public CollectionListElement listElementPrefab;

		public RectTransform detailContent;

		public GameObject textContentsArea;

		public Image detailImage;

		public TMP_Text detailDesc;

		public TMP_Text flavorText;

		[SerializeField]
		private List<EnemyCollectionComponent> enemyComponents;

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

		private void SetProgressTextForSmallTitle(EnemyCollectionComponent component)
		{
		}

		public override void AddCollection(int enumNumber)
		{
		}

		public override void SelectItem(int enumNumber, bool isSecret = false)
		{
		}

		public CollectionListElement CreateEnemyListElement(eEnemy enemy)
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
