using System;
using System.Collections.Generic;
using ModIO;
using ModIO.Util;
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

		internal static Dictionary<ModId, SearchResultListItem> listItems = new Dictionary<ModId, SearchResultListItem>();

		public void OpenModDetailsForThisProfile()
		{
			if (!isPlaceholder)
			{
				SelfInstancingMonoSingleton<Details>.Instance.Open(profile, SelfInstancingMonoSingleton<SearchResults>.Instance.OpenWithoutRefreshing);
			}
		}

		private void AddToStaticDictionaryCache()
		{
			if (listItems.ContainsKey(profile.id))
			{
				listItems[profile.id] = this;
			}
			else
			{
				listItems.Add(profile.id, this);
			}
		}

		private void RemoveFromStaticDictionaryCache()
		{
			if (listItems.ContainsKey(profile.id))
			{
				listItems.Remove(profile.id);
			}
		}

		private void OnDestroy()
		{
			RemoveFromStaticDictionaryCache();
		}

		public void OnSelect(BaseEventData eventData)
		{
			SelfInstancingMonoSingleton<SelectionOverlayHandler>.Instance.MoveSelection(this);
		}

		public void OnDeselect(BaseEventData eventData)
		{
			SelfInstancingMonoSingleton<SelectionOverlayHandler>.Instance.Deselect(this);
		}

		public void OnPointerEnter(PointerEventData eventData)
		{
			SelfInstancingMonoSingleton<InputNavigation>.Instance.mouseNavigation = true;
			EventSystem.current.SetSelectedGameObject(null);
			SelfInstancingMonoSingleton<InputNavigation>.Instance.Select(selectable, selectEvenWhenUsingMouse: true);
		}

		public override void PlaceholderSetup()
		{
			base.PlaceholderSetup();
			image.color = Color.clear;
			loadingIcon.SetActive(value: true);
			failedToLoadIcon.SetActive(value: false);
			title.text = string.Empty;
			base.gameObject.SetActive(value: true);
		}

		public override void Setup(ModProfile profile)
		{
			base.Setup();
			this.profile = profile;
			image.color = Color.clear;
			loadingIcon.SetActive(value: true);
			failedToLoadIcon.SetActive(value: false);
			title.text = profile.name;
			ModIOUnity.DownloadTexture(profile.logoImage_320x180, SetIcon);
			base.gameObject.SetActive(value: true);
			progressTab.Setup(profile);
			AddToStaticDictionaryCache();
		}

		public override void SetViewportRestraint(RectTransform content, RectTransform viewport)
		{
			base.SetViewportRestraint(content, viewport);
			viewportRestraint.PercentPaddingVertical = 0.3f;
		}

		public void SetAsLastRowItem()
		{
			viewportRestraint.PercentPaddingVertical = 0.375f;
		}

		private void SetIcon(ResultAnd<Texture2D> textureAnd)
		{
			if (textureAnd.result.Succeeded() && textureAnd.value != null)
			{
				SelfInstancingMonoSingleton<QueueRunner>.Instance.AddSpriteCreation(textureAnd.value, delegate(Sprite sprite)
				{
					image.sprite = sprite;
					image.color = Color.white;
					loadingIcon.SetActive(value: false);
				});
			}
			else
			{
				failedToLoadIcon.SetActive(value: true);
				loadingIcon.SetActive(value: false);
			}
			imageLoaded?.Invoke();
		}

		internal void UpdateProgressBar(ProgressHandle handle)
		{
			progressTab.UpdateProgress(handle);
		}

		internal void UpdateStatus(ModManagementEventType updatedStatus, ModId id)
		{
			progressTab.UpdateStatus(updatedStatus, id);
		}
	}
}
