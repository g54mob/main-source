using System;
using System.Collections;
using System.Collections.Generic;
using ModIO;
using ModIO.Util;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace ModIOBrowser.Implementation
{
	public class Details : SelfInstancingMonoSingleton<Details>
	{
		[Header("Mod Details Panel")]
		[SerializeField]
		public GameObject ModDetailsPanel;

		[SerializeField]
		public RectTransform ModDetailsContentRect;

		[SerializeField]
		private GameObject ModDetailsGalleryLoadingAnimation;

		[SerializeField]
		private Image ModDetailsGalleryFailedToLoadIcon;

		[SerializeField]
		private Image[] ModDetailsGalleryImage;

		[SerializeField]
		private TMP_Text ModDetailsSubscribeButtonText;

		[SerializeField]
		private TMP_Text ModDetailsName;

		[SerializeField]
		private TMP_Text ModDetailsSummary;

		[SerializeField]
		private TMP_Text ModDetailsDescription;

		[SerializeField]
		private TMP_Text ModDetailsFileSize;

		[SerializeField]
		private TMP_Text ModDetailsLastUpdated;

		[SerializeField]
		private TMP_Text ModDetailsReleaseDate;

		[SerializeField]
		private TMP_Text ModDetailsSubscribers;

		[SerializeField]
		private TMP_Text ModDetailsCreatedBy;

		[SerializeField]
		private TMP_Text ModDetailsUpVotes;

		[SerializeField]
		private TMP_Text ModDetailsDownVotes;

		[SerializeField]
		private GameObject ModDetailsUpVoteActiveOverlay;

		[SerializeField]
		private GameObject ModDetailsDownVoteActiveOverlay;

		[SerializeField]
		private TMP_Text ModDetailsUpVotesActiveOverlayText;

		[SerializeField]
		private TMP_Text ModDetailsDownVotesActiveOverlayText;

		[SerializeField]
		private GameObject ModDetailsGalleryNavBar;

		[SerializeField]
		private Transform ModDetailsGalleryNavButtonParent;

		[SerializeField]
		private GameObject ModDetailsGalleryNavButtonPrefab;

		[SerializeField]
		private GameObject ModDetailsDownloadProgressDisplay;

		[SerializeField]
		private Image ModDetailsDownloadProgressFill;

		[SerializeField]
		private TMP_Text ModDetailsDownloadProgressRemaining;

		[SerializeField]
		private TMP_Text ModDetailsDownloadProgressSpeed;

		[SerializeField]
		private TMP_Text ModDetailsDownloadProgressCompleted;

		[SerializeField]
		private WrappingHorizontalLayoutGroup ModDetailsTagsGroup;

		[SerializeField]
		private GameObject ModDetailsTagsPrefab;

		private List<ListItem> _tagsListItems;

		public SubscribedProgressTab ModDetailsProgressTab;

		public GameObject ModDetailsScrollToggleGameObject;

		private bool galleryImageInUse;

		private Sprite[] ModDetailsGalleryImages;

		private bool[] ModDetailsGalleryImagesFailedToLoad;

		private int galleryPosition;

		private float galleryTransitionTime = 0.3f;

		private IEnumerator galleryTransition;

		private ModProfile currentModProfileBeingViewed;

		private IEnumerator downloadProgressUpdater;

		private ModRating currentAssumedRating;

		internal Translation ModDetailsSubscribeButtonTextTranslation;

		private List<ListItem> _listItems = new List<ListItem>();

		private int activateNavButtonIndex;

		private Coroutine _autoRotateImagesCoroutine;

		private Action modDetailsOnCloseAction;

		private ModId detailsModIdOfLastProgressUpdate = new ModId(-1L);

		private float detailsProgressTimePassed;

		private float detailsProgressTimePassed_onLastTextUpdate;

		public static bool IsOn()
		{
			if (SelfInstancingMonoSingleton<Details>.Instance != null && SelfInstancingMonoSingleton<Details>.Instance.ModDetailsPanel != null)
			{
				return SelfInstancingMonoSingleton<Details>.Instance.ModDetailsPanel.activeSelf;
			}
			return false;
		}

		internal void Open(ModProfile profile, Action actionToInvokeWhenClosed)
		{
			ModDetailsProgressTab.Setup(profile);
			modDetailsOnCloseAction = actionToInvokeWhenClosed;
			Navigating.GoToPanel(ModDetailsPanel);
			SelfInstancingMonoSingleton<SelectionManager>.Instance.SelectView(UiViews.ModDetails);
			Refresh(profile);
			_autoRotateImagesCoroutine = StartCoroutine(AutoRotateImages());
		}

		public void Close()
		{
			ModDetailsPanel.SetActive(value: false);
			modDetailsOnCloseAction?.Invoke();
			ListItemsCleanup();
			StopCoroutine(_autoRotateImagesCoroutine);
			if (SelfInstancingMonoSingleton<InputNavigation>.Instance.mouseNavigation)
			{
				SelfInstancingMonoSingleton<SelectionOverlayHandler>.Instance.SetBrowserModListItemOverlayActive(state: false);
			}
			else if (modDetailsOnCloseAction == null)
			{
				SelfInstancingMonoSingleton<SelectionManager>.Instance.SelectPreviousView();
			}
			else
			{
				modDetailsOnCloseAction();
			}
		}

		private void Refresh(ModProfile profile)
		{
			currentModProfileBeingViewed = profile;
			UpdateSubscribeButtonText();
			UpdateRatingButtons();
			ModDetailsGalleryLoadingAnimation.SetActive(value: true);
			ModDetailsGalleryImage[0].color = Color.clear;
			ModDetailsGalleryImage[1].color = Color.clear;
			ModDetailsName.text = profile.name;
			ModDetailsDescription.text = profile.description;
			ModDetailsSummary.text = profile.summary;
			ModDetailsFileSize.text = Utility.GenerateHumanReadableStringForBytes(profile.archiveFileSize);
			ModDetailsLastUpdated.text = SelfInstancingMonoSingleton<TranslationManager>.Instance.SelectedLanguage.DateShort(profile.dateUpdated);
			ModDetailsReleaseDate.text = SelfInstancingMonoSingleton<TranslationManager>.Instance.SelectedLanguage.DateShort(profile.dateLive);
			ModDetailsCreatedBy.text = profile.creator.username;
			ModDetailsSubscribers.text = Utility.GenerateHumanReadableNumber(profile.stats.subscriberTotal);
			int num = 0;
			galleryPosition = 0;
			ModDetailsGalleryImages = new Sprite[profile.galleryImages_640x360.Length + 1];
			ModDetailsGalleryImagesFailedToLoad = new bool[ModDetailsGalleryImages.Length];
			RefreshTags(profile);
			ListItem.HideListItems<GalleryImageButtonListItem>();
			List<DownloadReference> list = new List<DownloadReference>();
			list.Add(profile.logoImage_640x360);
			list.AddRange(profile.galleryImages_640x360);
			ModDetailsGalleryNavBar.SetActive(list.Count > 1);
			foreach (DownloadReference item in list)
			{
				int thisPosition = num;
				num++;
				if (list.Count > 1)
				{
					ListItem listItem = ListItem.GetListItem<GalleryImageButtonListItem>(ModDetailsGalleryNavButtonPrefab, ModDetailsGalleryNavButtonParent, SharedUi.colorScheme);
					listItem.Setup(delegate
					{
						OnNavButtonClicked(thisPosition);
					});
					_listItems.Add(listItem);
				}
				int scopePosition = thisPosition;
				Action<ResultAnd<Texture2D>> callback = delegate(ResultAnd<Texture2D> r)
				{
					if (r.result.Succeeded())
					{
						SelfInstancingMonoSingleton<QueueRunner>.Instance.AddSpriteCreation(r.value, delegate(Sprite sprite)
						{
							if (ModDetailsGalleryImages.Length > scopePosition)
							{
								ModDetailsGalleryImages[scopePosition] = sprite;
								if (scopePosition == galleryPosition)
								{
									ModDetailsGalleryFailedToLoadIcon.gameObject.SetActive(value: false);
									ModDetailsGalleryLoadingAnimation.SetActive(value: false);
									Image currentGalleryImageComponent2 = GetCurrentGalleryImageComponent();
									currentGalleryImageComponent2.sprite = ModDetailsGalleryImages[scopePosition];
									currentGalleryImageComponent2.color = Color.white;
								}
							}
						});
					}
					else
					{
						ModDetailsGalleryImages[thisPosition] = null;
						ModDetailsGalleryImagesFailedToLoad[thisPosition] = true;
						if (thisPosition == galleryPosition)
						{
							ModDetailsGalleryLoadingAnimation.SetActive(value: false);
							ModDetailsGalleryFailedToLoadIcon.gameObject.SetActive(value: true);
							Image currentGalleryImageComponent = GetCurrentGalleryImageComponent();
							currentGalleryImageComponent.sprite = null;
							currentGalleryImageComponent.color = SharedUi.colorScheme.GetSchemeColor(ColorSetterType.Inactive3);
						}
					}
				};
				ModIOUnity.DownloadTexture(item, callback);
			}
			ActivateButton(0);
			LayoutRebuilder.ForceRebuildLayoutImmediate(ModDetailsGalleryNavButtonParent as RectTransform);
			LayoutRebuilder.ForceRebuildLayoutImmediate(ModDetailsName.transform.parent as RectTransform);
			LayoutRebuilder.ForceRebuildLayoutImmediate(ModDetailsDescription.transform.parent as RectTransform);
			LayoutRebuilder.ForceRebuildLayoutImmediate(ModDetailsDescription.transform.parent.transform.parent as RectTransform);
		}

		public async void RefreshTags(ModProfile profile)
		{
			ModDetailsTagsGroup.EmptyLayoutGroup();
			ListItem.HideListItems<ModDetailsTagListItem>();
			if (SelfInstancingMonoSingleton<SearchPanel>.Instance.tags == null)
			{
				await SelfInstancingMonoSingleton<SearchPanel>.Instance.WaitForTagsToUpdate();
				if ((long)currentModProfileBeingViewed.id != (long)profile.id)
				{
					return;
				}
			}
			List<string> hiddenTags = SelfInstancingMonoSingleton<SearchPanel>.Instance.GetHiddenTags();
			string[] tags = profile.tags;
			foreach (string text in tags)
			{
				if (!hiddenTags.Contains(text))
				{
					ListItem listItem = ListItem.GetListItem<ModDetailsTagListItem>(ModDetailsTagsPrefab, base.transform, MonoSingleton<Browser>.Instance.colorScheme);
					listItem.Setup(text);
					ModDetailsTagsGroup.AddGameObjectToLayout(listItem.gameObject);
				}
			}
		}

		public void SubscribeButtonPress()
		{
			if (!SelfInstancingMonoSingleton<Authentication>.Instance.IsAuthenticated)
			{
				Translation.Get(ModDetailsSubscribeButtonTextTranslation, "Log in to Subscribe", ModDetailsSubscribeButtonText);
				Mods.SubscribeToEvent(currentModProfileBeingViewed, UpdateSubscribeButtonText);
			}
			else if (SelfInstancingMonoSingleton<Collection>.Instance.IsSubscribed(currentModProfileBeingViewed.id))
			{
				if (Collection.IsDependencyForOtherMods(currentModProfileBeingViewed.id))
				{
					SelfInstancingMonoSingleton<Notifications>.Instance.AddNotificationToQueue(new Notifications.QueuedNotice
					{
						title = "",
						description = SelfInstancingMonoSingleton<TranslationManager>.Instance.Get("UnsubscribeDepText"),
						positiveAccent = false
					});
					return;
				}
				Translation.Get(ModDetailsSubscribeButtonTextTranslation, "Subscribe", ModDetailsSubscribeButtonText);
				Mods.UnsubscribeFromEvent(currentModProfileBeingViewed, UpdateSubscribeButtonText);
			}
			else
			{
				Translation.Get(ModDetailsSubscribeButtonTextTranslation, "Unsubscribe", ModDetailsSubscribeButtonText);
				Mods.SubscribeToEvent(currentModProfileBeingViewed, UpdateSubscribeButtonText);
			}
			ModDetailsProgressTab.Setup(currentModProfileBeingViewed);
			LayoutRebuilder.ForceRebuildLayoutImmediate(ModDetailsSubscribeButtonText.transform.parent as RectTransform);
		}

		public void RatePositiveButtonPress()
		{
			if (!SelfInstancingMonoSingleton<Authentication>.Instance.IsAuthenticated)
			{
				SelfInstancingMonoSingleton<AuthenticationPanels>.Instance.Open();
				return;
			}
			ModRating rating = ((currentAssumedRating != ModRating.Positive) ? ModRating.Positive : ModRating.None);
			UpdateRatingButtons(rating);
			Mods.RateEvent(currentModProfileBeingViewed.id, rating);
		}

		public void RateNegativeButtonPress()
		{
			if (!SelfInstancingMonoSingleton<Authentication>.Instance.IsAuthenticated)
			{
				SelfInstancingMonoSingleton<AuthenticationPanels>.Instance.Open();
				return;
			}
			ModRating rating = ((currentAssumedRating != ModRating.Negative) ? ModRating.Negative : ModRating.None);
			UpdateRatingButtons(rating);
			Mods.RateEvent(currentModProfileBeingViewed.id, rating);
		}

		public void ReportButtonPress()
		{
			Selectable component = EventSystem.current.currentSelectedGameObject.GetComponent<Selectable>();
			_ = component == null;
			SelfInstancingMonoSingleton<Reporting>.Instance.Open(currentModProfileBeingViewed, component);
		}

		public void UpdateRatingButtons()
		{
			ModIOUnity.GetCurrentUserRatingFor(currentModProfileBeingViewed.id, UpdateRatingButtons);
		}

		public void UpdateRatingButtons(ResultAnd<ModRating> response)
		{
			if (response.result.Succeeded())
			{
				UpdateRatingButtons(response.value);
			}
			else
			{
				UpdateRatingButtons(ModRating.None);
			}
		}

		public void UpdateRatingButtons(ModRating rating)
		{
			currentAssumedRating = rating;
			ModDetailsUpVotes.text = Utility.GenerateHumanReadableNumber(currentModProfileBeingViewed.stats.ratingsPositive);
			ModDetailsDownVotes.text = Utility.GenerateHumanReadableNumber(currentModProfileBeingViewed.stats.ratingsNegative);
			ModDetailsUpVotesActiveOverlayText.text = Utility.GenerateHumanReadableNumber(currentModProfileBeingViewed.stats.ratingsPositive);
			ModDetailsDownVotesActiveOverlayText.text = Utility.GenerateHumanReadableNumber(currentModProfileBeingViewed.stats.ratingsNegative);
			switch (rating)
			{
			case ModRating.Positive:
				ModDetailsDownVoteActiveOverlay.SetActive(value: false);
				ModDetailsUpVoteActiveOverlay.SetActive(value: true);
				break;
			case ModRating.Negative:
				ModDetailsDownVoteActiveOverlay.SetActive(value: true);
				ModDetailsUpVoteActiveOverlay.SetActive(value: false);
				break;
			case ModRating.None:
				ModDetailsDownVoteActiveOverlay.SetActive(value: false);
				ModDetailsUpVoteActiveOverlay.SetActive(value: false);
				break;
			}
		}

		public void UpdateSubscribeButtonText()
		{
			Button componentInParent = ModDetailsSubscribeButtonText.GetComponentInParent<Button>();
			if (!SelfInstancingMonoSingleton<Authentication>.Instance.IsAuthenticated)
			{
				Translation.Get(ModDetailsSubscribeButtonTextTranslation, "Log in to Subscribe", ModDetailsSubscribeButtonText);
				componentInParent.interactable = true;
			}
			else if (SelfInstancingMonoSingleton<Collection>.Instance.IsSubscribed(currentModProfileBeingViewed.id))
			{
				if (Collection.IsDependencyForOtherMods(currentModProfileBeingViewed.id))
				{
					Translation.Get(ModDetailsSubscribeButtonTextTranslation, "UnsubscribeDep", ModDetailsSubscribeButtonText);
					componentInParent.interactable = true;
					componentInParent.GetComponent<Image>().color = SharedUi.colorScheme.GetSchemeColor(ColorSetterType.NegativeAccent);
				}
				else
				{
					Translation.Get(ModDetailsSubscribeButtonTextTranslation, "Unsubscribe", ModDetailsSubscribeButtonText);
					componentInParent.interactable = true;
					componentInParent.GetComponent<Image>().color = SharedUi.colorScheme.GetSchemeColor(ColorSetterType.NegativeAccent);
				}
			}
			else
			{
				Translation.Get(ModDetailsSubscribeButtonTextTranslation, "Subscribe", ModDetailsSubscribeButtonText);
				Image component = componentInParent.GetComponent<Image>();
				componentInParent.interactable = true;
				component.color = SharedUi.colorScheme.GetSchemeColor(ColorSetterType.PositiveAccent);
			}
			ModIOUnity.IsAuthenticated(delegate(Result r)
			{
				if (!r.Succeeded())
				{
					SelfInstancingMonoSingleton<Authentication>.Instance.IsAuthenticated = false;
					Translation.Get(ModDetailsSubscribeButtonTextTranslation, "Log in to Subscribe", ModDetailsSubscribeButtonText);
				}
			});
		}

		public void UpdateDownloadProgress(ProgressHandle handle)
		{
			ModDetailsProgressTab.UpdateProgress(handle);
			if (handle == null || (long)handle.modId != (long)currentModProfileBeingViewed.id || handle.Completed)
			{
				ModDetailsDownloadProgressDisplay.SetActive(value: false);
				return;
			}
			if (!ModDetailsDownloadProgressDisplay.activeSelf)
			{
				ModDetailsDownloadProgressDisplay.SetActive(value: true);
			}
			if ((long)detailsModIdOfLastProgressUpdate != (long)handle.modId)
			{
				detailsModIdOfLastProgressUpdate = handle.modId;
			}
			ModDetailsDownloadProgressFill.fillAmount = handle.Progress;
			if (handle.OperationType == ModManagementOperationType.Install)
			{
				ModDetailsDownloadProgressRemaining.text = SelfInstancingMonoSingleton<TranslationManager>.Instance.Get("Installing...");
				ModDetailsDownloadProgressCompleted.text = "";
				ModDetailsDownloadProgressSpeed.text = "";
				return;
			}
			if (detailsProgressTimePassed - detailsProgressTimePassed_onLastTextUpdate >= 1f || detailsProgressTimePassed_onLastTextUpdate > detailsProgressTimePassed)
			{
				float num = ((handle.Progress == 0f) ? 0.01f : handle.Progress);
				float num2 = detailsProgressTimePassed / num - detailsProgressTimePassed;
				ModDetailsDownloadProgressRemaining.text = SelfInstancingMonoSingleton<TranslationManager>.Instance.Get("{seconds} remaining", Utility.GenerateHumanReadableTimeStringFromSeconds((int)num2) ?? "");
				ModDetailsDownloadProgressSpeed.text = SelfInstancingMonoSingleton<TranslationManager>.Instance.Get("{BytesPerSecond)}/s", Utility.GenerateHumanReadableStringForBytes(handle.BytesPerSecond));
				if (SelfInstancingMonoSingleton<Collection>.Instance.GetSubscribedProfile(handle.modId, out var profile))
				{
					ModDetailsDownloadProgressCompleted.text = SelfInstancingMonoSingleton<TranslationManager>.Instance.Get("{A} of {B}", Utility.GenerateHumanReadableStringForBytes((long)((float)profile.archiveFileSize * handle.Progress)) ?? "", Utility.GenerateHumanReadableStringForBytes(profile.archiveFileSize) ?? "");
				}
				else
				{
					ModDetailsDownloadProgressCompleted.text = "--";
				}
				detailsProgressTimePassed_onLastTextUpdate = detailsProgressTimePassed;
			}
			detailsProgressTimePassed += Time.deltaTime;
		}

		public void GalleryImageTransition(bool showNext)
		{
			StopCoroutine(_autoRotateImagesCoroutine);
			if (showNext)
			{
				ShowNextGalleryImage();
			}
			else
			{
				ShowPreviousGalleryImage();
			}
		}

		internal void ShowNextGalleryImage()
		{
			int nextIndex = GetNextIndex(galleryPosition, ModDetailsGalleryImages.Length);
			TransitionToDifferentGalleryImage(nextIndex);
			ActivateButton(nextIndex);
		}

		internal void ShowPreviousGalleryImage()
		{
			int previousIndex = GetPreviousIndex(galleryPosition, ModDetailsGalleryImages.Length);
			TransitionToDifferentGalleryImage(previousIndex);
			ActivateButton(previousIndex);
		}

		private void TransitionToDifferentGalleryImage(int index)
		{
			if (galleryTransition != null)
			{
				StopCoroutine(galleryTransition);
			}
			galleryTransition = TransitionGalleryImage(index);
			StartCoroutine(galleryTransition);
		}

		private IEnumerator TransitionGalleryImage(int index)
		{
			galleryPosition = index;
			if (index >= ModDetailsGalleryImages.Length)
			{
				yield break;
			}
			Image next = GetNextGalleryImageComponent();
			Image current = GetCurrentGalleryImageComponent();
			if (!(current.sprite == ModDetailsGalleryImages[index]))
			{
				galleryImageInUse = !galleryImageInUse;
				next.sprite = ModDetailsGalleryImages[index];
				if (next.sprite == null)
				{
					ModDetailsGalleryFailedToLoadIcon.gameObject.SetActive(value: true);
					next.color = SharedUi.colorScheme.GetSchemeColor(ColorSetterType.Inactive3);
				}
				else
				{
					ModDetailsGalleryFailedToLoadIcon.gameObject.SetActive(value: false);
					next.color = Color.white;
				}
				float timePassed = 0f;
				Color colIn = next.color;
				Color colFailedIcon = ModDetailsGalleryFailedToLoadIcon.color;
				Color colOut = current.color;
				colIn.a = 0f;
				colFailedIcon.a = 0f;
				for (; timePassed <= galleryTransitionTime; timePassed += Time.deltaTime)
				{
					colOut.a = 1f - (colFailedIcon.a = (colIn.a = timePassed / galleryTransitionTime));
					next.color = colIn;
					ModDetailsGalleryFailedToLoadIcon.color = colFailedIcon;
					current.color = colOut;
					yield return null;
				}
			}
		}

		private Image GetCurrentGalleryImageComponent()
		{
			int num = ((!galleryImageInUse) ? 1 : 0);
			return ModDetailsGalleryImage[num];
		}

		private Image GetNextGalleryImageComponent()
		{
			int num = (galleryImageInUse ? 1 : 0);
			return ModDetailsGalleryImage[num];
		}

		private void ActivateButton(int toggledIndex)
		{
			if (toggledIndex < _listItems.Count)
			{
				_listItems[activateNavButtonIndex].DeSelect();
				_listItems[toggledIndex].Select();
				activateNavButtonIndex = toggledIndex;
			}
		}

		private void ListItemsCleanup()
		{
			if (_listItems.Count > activateNavButtonIndex)
			{
				_listItems[activateNavButtonIndex].DeSelect();
			}
			activateNavButtonIndex = 0;
			_listItems.Clear();
		}

		private IEnumerator AutoRotateImages()
		{
			while (true)
			{
				yield return new WaitForSecondsRealtime(3f);
				ShowNextGalleryImage();
			}
		}

		private void OnNavButtonClicked(int position)
		{
			TransitionToDifferentGalleryImage(position);
			ActivateButton(position);
			StopCoroutine(_autoRotateImagesCoroutine);
		}

		public static int GetPreviousIndex(int current, int length)
		{
			if (length == 0)
			{
				return 0;
			}
			current--;
			if (current < 0)
			{
				current = length - 1;
			}
			return current;
		}

		public static int GetNextIndex(int current, int length)
		{
			if (length == 0)
			{
				return 0;
			}
			current++;
			if (current >= length)
			{
				current = 0;
			}
			return current;
		}
	}
}
