using ModIO;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace ModIOBrowser.Implementation
{
	internal class DownloadQueueListItem : ListItem, IDeselectHandler, IEventSystemHandler, ISelectHandler
	{
		[SerializeField]
		private TMP_Text modName;

		[SerializeField]
		private TMP_Text fileSize;

		[SerializeField]
		private Image modLogo;

		[SerializeField]
		private GameObject loadingIcon;

		[SerializeField]
		private GameObject failedToLoadIcon;

		[SerializeField]
		private GameObject failedToLoadMod;

		public ModProfile profile;

		public static DownloadQueueListItem currentDownloadQueueListItem;

		public void OpenModDetailsForThisProfile()
		{
		}

		public override void SetViewportRestraint(RectTransform content, RectTransform viewport)
		{
		}

		public override void Setup(SubscribedMod mod)
		{
		}

		private void SetIcon(ResultAnd<Texture2D> textureAnd)
		{
		}

		public void Unsubscribe()
		{
		}

		public void OnDeselect(BaseEventData eventData)
		{
		}

		public void OnSelect(BaseEventData eventData)
		{
		}
	}
}
