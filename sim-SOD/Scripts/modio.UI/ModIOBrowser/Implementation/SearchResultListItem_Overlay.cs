using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace ModIOBrowser.Implementation
{
	internal class SearchResultListItem_Overlay : MonoBehaviour, IPointerExitHandler, IEventSystemHandler
	{
		[SerializeField]
		private Animator animator;

		[SerializeField]
		private Image image;

		[SerializeField]
		private GameObject failedToLoadIcon;

		[SerializeField]
		private GameObject loadingIcon;

		[SerializeField]
		private TMP_Text title;

		[SerializeField]
		private TMP_Text subscribeButtonText;

		[SerializeField]
		private Transform contextMenuPosition;

		public SearchResultListItem listItemToReplicate;

		public SearchResultListItem lastListItemToReplicate;

		private Translation subscribeButtonTextTranslation;

		[SerializeField]
		private SubscribedProgressTab progressTab;

		private void LateUpdate()
		{
		}

		public void Setup(SearchResultListItem listItem)
		{
		}

		private void MimicProgressBar()
		{
		}

		public void SubscribeButton()
		{
		}

		public void OpenModDetailsForThisModProfile()
		{
		}

		public void ShowMoreOptions()
		{
		}

		public void UpdateSubscribeButton()
		{
		}

		public void SetSubscribeButtonText()
		{
		}

		private void ReloadImage()
		{
		}

		public void OnPointerExit(PointerEventData eventData)
		{
		}
	}
}
