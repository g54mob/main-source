using System;
using System.Collections.Generic;
using InputControl;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
	public class GreaterKnowledgeDialog : BaseDialog
	{
		[Serializable]
		private class WriterComponent
		{
			public eWriterId writer;

			public bool consumption;

			public RectTransform itemArea;

			public GameObject plateArea;

			public GameObject lockImage;

			public GameObject unlockImage;

			public CursorUIGroup itemList;
		}

		[SerializeField]
		private GreaterKnowledgeItemButton itemButtonPrefab;

		[SerializeField]
		private TMP_Text money;

		[SerializeField]
		private GameObject descriptionGroup;

		[SerializeField]
		private ChoiceMenuButtonBase toolTip;

		[SerializeField]
		private Image tipsIcon;

		[SerializeField]
		private TMP_Text trialDisableText;

		[SerializeField]
		private List<WriterComponent> writerComponents;

		private Dictionary<eOutGameShopId, GreaterKnowledgeItemButton> itemButtonList;

		public override void Init()
		{
		}

		private void InitWriterPlate()
		{
		}

		private void ResetItems()
		{
		}

		private void CreateItems()
		{
		}

		public override void Open()
		{
		}

		public void UpdateMoneyText()
		{
		}

		public void OnChangedKnowledgePointForDebug()
		{
		}

		public void OnClickRssetButton()
		{
		}

		private void ReturnKnowledgePoint()
		{
		}

		public void OnClickItem(GreaterKnowledgeItemButton button)
		{
		}

		public void OnPointerEnterItem(GreaterKnowledgeItemButton button)
		{
		}

		public void OnPointerExitItem(GreaterKnowledgeItemButton button)
		{
		}

		public override void Back()
		{
		}

		private void UpdateToolTip(OutGameShopData data)
		{
		}
	}
}
