using System.Collections.Generic;
using ModIO;
using ModIO.Util;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace ModIOBrowser.Implementation
{
	internal class HomeModListItem_Overlay : MonoBehaviour, IPointerExitHandler, IEventSystemHandler
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

		public HomeModListItem listItemToReplicate;

		public HomeModListItem lastListItemToReplicate;

		[SerializeField]
		private SubscribedProgressTab progressTab;

		private void OnEnable()
		{
			LayoutRebuilder.ForceRebuildLayoutImmediate(subscribeButtonText.gameObject.transform.parent as RectTransform);
		}

		private void LateUpdate()
		{
			if (base.gameObject.activeSelf)
			{
				MimicProgressBar();
			}
		}

		public void Setup(HomeModListItem listItem)
		{
			lastListItemToReplicate = listItemToReplicate;
			listItemToReplicate = listItem;
			Transform obj = base.transform;
			obj.SetParent(listItem.transform.parent);
			obj.SetAsLastSibling();
			obj.position = listItem.transform.position;
			base.gameObject.SetActive(value: true);
			failedToLoadIcon.SetActive(listItemToReplicate.failedToLoadIcon.activeSelf);
			loadingIcon.SetActive(listItemToReplicate.loadingIcon.activeSelf);
			animator.Play("Inflate");
			SetSubscribeButtonText();
			MimicProgressBar();
			listItemToReplicate.imageLoaded = ReloadImage;
			image.sprite = listItemToReplicate.image.sprite;
			title.text = listItemToReplicate.title.text;
		}

		private void MimicProgressBar()
		{
			if (listItemToReplicate != null)
			{
				progressTab?.MimicOtherProgressTab(listItemToReplicate?.progressTab);
			}
		}

		public void SubscribeButton()
		{
			if (SelfInstancingMonoSingleton<Collection>.Instance.IsSubscribed(listItemToReplicate.profile.id))
			{
				if (Collection.IsDependencyForOtherMods(listItemToReplicate.profile.id))
				{
					SelfInstancingMonoSingleton<Notifications>.Instance.AddNotificationToQueue(new Notifications.QueuedNotice
					{
						title = "",
						description = SelfInstancingMonoSingleton<TranslationManager>.Instance.Get("UnsubscribeDepText"),
						positiveAccent = false
					});
					return;
				}
				subscribeButtonText.text = SelfInstancingMonoSingleton<TranslationManager>.Instance.Get("Subscribe");
				Mods.UnsubscribeFromEvent(listItemToReplicate.profile, UpdateSubscribeButton);
			}
			else
			{
				subscribeButtonText.text = SelfInstancingMonoSingleton<TranslationManager>.Instance.Get("Unsubscribe");
				Mods.SubscribeToEvent(listItemToReplicate.profile, UpdateSubscribeButton);
			}
			LayoutRebuilder.ForceRebuildLayoutImmediate(subscribeButtonText.transform.parent as RectTransform);
		}

		public void OpenModDetailsForThisModProfile()
		{
			listItemToReplicate?.OpenModDetailsForThisProfile();
		}

		public void ShowMoreOptions()
		{
			List<ContextMenuOption> list = new List<ContextMenuOption>();
			list.Add(new ContextMenuOption
			{
				nameTranslationReference = "Vote up",
				action = delegate
				{
					ModIOUnity.RateMod(listItemToReplicate.profile.id, ModRating.Positive, delegate
					{
					});
					SelfInstancingMonoSingleton<ModioContextMenu>.Instance.Close();
				}
			});
			list.Add(new ContextMenuOption
			{
				nameTranslationReference = "Vote down",
				action = delegate
				{
					ModIOUnity.RateMod(listItemToReplicate.profile.id, ModRating.Negative, delegate
					{
					});
					SelfInstancingMonoSingleton<ModioContextMenu>.Instance.Close();
				}
			});
			list.Add(new ContextMenuOption
			{
				nameTranslationReference = "Report",
				action = delegate
				{
					SelfInstancingMonoSingleton<ModioContextMenu>.Instance.Close();
					SelfInstancingMonoSingleton<Reporting>.Instance.Open(listItemToReplicate.profile, listItemToReplicate.selectable);
				}
			});
			SelfInstancingMonoSingleton<ModioContextMenu>.Instance.Open(contextMenuPosition, list, listItemToReplicate.selectable);
		}

		public void UpdateSubscribeButton()
		{
			SetSubscribeButtonText();
		}

		public void SetSubscribeButtonText()
		{
			listItemToReplicate?.progressTab?.Setup(listItemToReplicate.profile);
			if (SelfInstancingMonoSingleton<Collection>.Instance.IsSubscribed(listItemToReplicate.profile.id))
			{
				if (Collection.IsDependencyForOtherMods(listItemToReplicate.profile.id))
				{
					subscribeButtonText.text = SelfInstancingMonoSingleton<TranslationManager>.Instance.Get("Dependency");
					subscribeButtonText.GetComponentInParent<Button>().GetComponent<Image>().color = SharedUi.colorScheme.GetSchemeColor(ColorSetterType.NegativeAccent);
				}
				else
				{
					subscribeButtonText.text = SelfInstancingMonoSingleton<TranslationManager>.Instance.Get("Unsubscribe");
					subscribeButtonText.GetComponentInParent<Button>().GetComponent<Image>().color = SharedUi.colorScheme.GetSchemeColor(ColorSetterType.Inactive1);
				}
			}
			else
			{
				subscribeButtonText.text = SelfInstancingMonoSingleton<TranslationManager>.Instance.Get("Subscribe");
				subscribeButtonText.GetComponentInParent<Button>().GetComponent<Image>().color = SharedUi.colorScheme.GetSchemeColor(ColorSetterType.Inactive1);
			}
			LayoutRebuilder.ForceRebuildLayoutImmediate(subscribeButtonText.transform.parent as RectTransform);
		}

		private void ReloadImage()
		{
			image.sprite = listItemToReplicate.image.sprite;
			failedToLoadIcon.SetActive(listItemToReplicate.failedToLoadIcon.activeSelf);
			loadingIcon.SetActive(listItemToReplicate.loadingIcon.activeSelf);
		}

		public void OnPointerExit(PointerEventData eventData)
		{
			if (!SelfInstancingMonoSingleton<ModioContextMenu>.Instance.gameObject.activeSelf)
			{
				SelfInstancingMonoSingleton<InputNavigation>.Instance.DeselectUiGameObject();
				base.gameObject.SetActive(value: false);
			}
		}
	}
}
