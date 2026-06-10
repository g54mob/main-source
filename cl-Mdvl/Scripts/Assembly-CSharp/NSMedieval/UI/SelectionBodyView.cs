using System.Collections.Generic;
using NSEipix;
using UnityEngine;
using UnityEngine.UI;

namespace NSMedieval.UI
{
	public class SelectionBodyView : UIView
	{
		[SerializeField]
		private LayoutGroupView descriptionGroup;

		[SerializeField]
		private ContentSizeFitter sizeFiter;

		private readonly List<LayoutGroupItemView> descriptions = new List<LayoutGroupItemView>();

		public void InitializeBody(InfoPanelBody descriptions)
		{
			sizeFiter.enabled = false;
			this.descriptions.SetAllActive(active: false);
			foreach (string description in descriptions.Descriptions)
			{
				this.descriptions.GetNext(descriptionGroup).SetText(description);
			}
			sizeFiter.enabled = true;
		}
	}
}
