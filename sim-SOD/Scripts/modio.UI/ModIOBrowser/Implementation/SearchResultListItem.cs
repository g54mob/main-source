using System;
using System.Collections.Generic;
using ModIO;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace ModIOBrowser.Implementation
{
	internal class SearchResultListItem : ListItem, IDeselectHandler, IEventSystemHandler, ISelectHandler, IPointerEnterHandler
	{
		public Image image;

		public TMP_Text title;

		public GameObject loadingIcon;

		public GameObject failedToLoadIcon;

		public Action imageLoaded;

		public ModProfile profile;

		public SubscribedProgressTab progressTab;

		internal static Dictionary<ModId, SearchResultListItem> listItems;

		public void OpenModDetailsForThisProfile()
		{
		}

		private void AddToStaticDictionaryCache()
		{
		}

		private void RemoveFromStaticDictionaryCache()
		{
		}

		private void OnDestroy()
		{
		}

		public void OnSelect(BaseEventData eventData)
		{
		}

		public void OnDeselect(BaseEventData eventData)
		{
		}

		public void OnPointerEnter(PointerEventData eventData)
		{
		}

		public override void PlaceholderSetup()
		{
		}

		public override void Setup(ModProfile profile)
		{
		}

		public override void SetViewportRestraint(RectTransform content, RectTransform viewport)
		{
		}

		public void SetAsLastRowItem()
		{
		}

		private void SetIcon(ResultAnd<Texture2D> textureAnd)
		{
		}

		internal void UpdateProgressBar(ProgressHandle handle)
		{
		}

		internal void UpdateStatus(ModManagementEventType updatedStatus, ModId id)
		{
		}
	}
}
