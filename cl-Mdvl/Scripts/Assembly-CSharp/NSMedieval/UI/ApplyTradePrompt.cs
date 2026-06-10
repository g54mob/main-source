using System;
using System.Collections.Generic;
using NSEipix;
using NSEipix.View.UI;
using TMPro;
using UnityEngine;

namespace NSMedieval.UI
{
	public class ApplyTradePrompt : UIView
	{
		[SerializeField]
		private TMP_Text tradeTitle;

		[SerializeField]
		private TMP_Text tradeMessage;

		[SerializeField]
		private TMP_Text acquireLabel;

		[SerializeField]
		private TMP_Text profferLabel;

		[SerializeField]
		private LayoutGroupView acquireListGroup;

		[SerializeField]
		private LayoutGroupView profferListGroup;

		[SerializeField]
		private SoundButton acceptButton;

		[SerializeField]
		private SoundButton cancelButton;

		private readonly List<LayoutGroupItemView> acquireLayoutViews = new List<LayoutGroupItemView>();

		private readonly List<LayoutGroupItemView> profferLayoutViews = new List<LayoutGroupItemView>();

		private void Start()
		{
			cancelButton.onClick.AddListener(Hide);
		}

		public void SetDataAndShow(string titleText, string message, List<KeyValuePair<string, List<string>>> acquireResources, List<KeyValuePair<string, List<string>>> profferResources, Action acceptAction)
		{
			Show();
			tradeTitle.SetText(titleText);
			tradeMessage.SetText(message);
			acquireLayoutViews.SetAllActive(active: false);
			profferLayoutViews.SetAllActive(active: false);
			acquireLabel.gameObject.SetActive(acquireResources.Count > 0);
			profferLabel.gameObject.SetActive(profferResources.Count > 0);
			foreach (KeyValuePair<string, List<string>> acquireResource in acquireResources)
			{
				LayoutGroupItemView next = acquireLayoutViews.GetNext(acquireListGroup);
				next.SetText(acquireResource.Key);
				next.TooltipNew.SetLines(acquireResource.Value);
			}
			foreach (KeyValuePair<string, List<string>> profferResource in profferResources)
			{
				LayoutGroupItemView next2 = profferLayoutViews.GetNext(profferListGroup);
				next2.SetText(profferResource.Key);
				next2.TooltipNew.SetLines(profferResource.Value);
			}
			acceptButton.AddCleanListener(acceptAction.Invoke);
		}
	}
}
