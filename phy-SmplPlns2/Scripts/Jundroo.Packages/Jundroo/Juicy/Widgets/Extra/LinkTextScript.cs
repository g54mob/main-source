using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Jundroo.Juicy.Widgets.Extra
{
	public class LinkTextScript : MonoBehaviour, IPointerClickHandler, IEventSystemHandler
	{
		public delegate void LinkDelegate(LinkTextScript linkText, string linkUrl);

		private bool _cancelLink;

		public event LinkDelegate LinkClicked;

		public void OnPointerClick(PointerEventData eventData)
		{
			Canvas componentInParent = GetComponentInParent<Canvas>();
			TextMeshProUGUI component = GetComponent<TextMeshProUGUI>();
			if (!(componentInParent != null) || !(component != null))
			{
				return;
			}
			int num = TMP_TextUtilities.FindIntersectingLink(component, eventData.position, componentInParent.worldCamera);
			if (num != -1)
			{
				TMP_LinkInfo tMP_LinkInfo = component.textInfo.linkInfo[num];
				string linkID = tMP_LinkInfo.GetLinkID();
				_cancelLink = false;
				if (this.LinkClicked != null)
				{
					this.LinkClicked(this, linkID);
				}
				if (!_cancelLink)
				{
					GetComponentInParent<Widget>().Context.LinkHandler?.OpenUrl(linkID);
				}
			}
		}
	}
}
