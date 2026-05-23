using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
	public class MachineCollectionPage : BaseCollectionPage
	{
		[Serializable]
		private class PaletteCategoryCollectionComponent
		{
			public ePaletteCategory category;

			public RectTransform smallTitle;

			public RectTransform collectionParent;

			public List<eMachine> machines;

			public bool itemCheck;

			public TMP_Text progressText;

			public int progressCountMax;
		}

		public CollectionListElement listElementPrefab;

		public RectTransform detailContent;

		public GameObject textContentsArea;

		public Image detailImage;

		public TMP_Text detailDesc;

		public CollectionArtifactDescriptionCtrl descCtrl;

		public TMP_Text specText;

		[SerializeField]
		private List<PaletteCategoryCollectionComponent> paletteCategoryComponents;

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

		private void SetProgressTextForSmallTitle(PaletteCategoryCollectionComponent component)
		{
		}

		public override void AddCollection(int enumNumber)
		{
		}

		public override void SelectItem(int enumNumber, bool isSecret = false)
		{
		}

		public CollectionListElement CreateMachineListElement(eMachine machine)
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
