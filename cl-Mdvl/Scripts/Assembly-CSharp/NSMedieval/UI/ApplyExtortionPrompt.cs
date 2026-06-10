using System;
using System.Collections.Generic;
using NSEipix;
using NSEipix.View.UI;
using TMPro;
using UnityEngine;

namespace NSMedieval.UI
{
	public class ApplyExtortionPrompt : UIView
	{
		[SerializeField]
		private TMP_Text title;

		[SerializeField]
		private TMP_Text message;

		[SerializeField]
		private TMP_Text giveLabel;

		[SerializeField]
		private LayoutGroupView giveListGroup;

		[SerializeField]
		private SoundButton acceptButton;

		[SerializeField]
		private SoundButton cancelButton;

		private readonly List<LayoutGroupItemView> giveLayoutViews = new List<LayoutGroupItemView>();

		private void Start()
		{
			cancelButton.onClick.AddListener(Hide);
		}

		public void SetDataAndShow(string titleText, string message, List<KeyValuePair<string, List<string>>> giveResources, Action acceptAction)
		{
			Show();
			title.SetText(titleText);
			this.message.SetText(message);
			giveLayoutViews.SetAllActive(active: false);
			giveLabel.gameObject.SetActive(giveResources.Count > 0);
			foreach (KeyValuePair<string, List<string>> giveResource in giveResources)
			{
				LayoutGroupItemView next = giveLayoutViews.GetNext(giveListGroup);
				next.SetText(giveResource.Key);
				next.TooltipNew.SetLines(giveResource.Value);
			}
			acceptButton.AddCleanListener(acceptAction.Invoke);
		}
	}
}
