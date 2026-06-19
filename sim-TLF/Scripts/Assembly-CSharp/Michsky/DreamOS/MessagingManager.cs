using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using UnityEngine.UI;

namespace Michsky.DreamOS
{
	public class MessagingManager : MonoBehaviour
	{
		[Serializable]
		public class ChatItem
		{
			public string chatTitle = "Chat Title";

			public string individualName = "Name";

			public string individualSurname = "Surname";

			public Sprite individualPicture;

			public MessagingChat chatAsset;

			public Status defaultStatus;

			[Tooltip("Sets the visibility of chat item button.")]
			public bool isVisible = true;
		}

		public class StorytellerReplyEvent
		{
			public string replyID;

			public UnityEvent onReplySelect = new UnityEvent();
		}

		public enum Status
		{
			Offline = 0,
			Online = 1
		}

		[SerializeField]
		private Transform chatParent;

		public Transform chatViewer;

		public GameObject chatLayout;

		[SerializeField]
		private GameObject chatItem;

		[SerializeField]
		private GameObject textMessageSent;

		[SerializeField]
		private GameObject textMessageRecieved;

		[SerializeField]
		private GameObject imageMessageSent;

		[SerializeField]
		private GameObject imageMessageRecieved;

		[SerializeField]
		private GameObject audioMessageSent;

		[SerializeField]
		private GameObject audioMessageRecieved;

		public GameObject chatMessageTimer;

		[SerializeField]
		private GameObject messageDate;

		public GameObject beginningIndicator;

		public TMP_InputField messageInput;

		public Animator storyTellerAnimator;

		[SerializeField]
		private Transform storyTellerList;

		public GameObject storyTellerObject;

		[SerializeField]
		private PhotoGalleryManager photoGalleryManager;

		public MessageStoring messageStoring;

		public List<ChatItem> chatList = new List<ChatItem>();

		public List<ChatLayoutPreset> createdLayoutPresets = new List<ChatLayoutPreset>();

		public List<StorytellerReplyEvent> storytellerReplyEvents = new List<StorytellerReplyEvent>();

		public AudioClip sentMessageSFX;

		public AudioClip receivedMessageSFX;

		public Sprite notificationIcon;

		public bool debugStoryTeller = true;

		public bool useNotifications = true;

		public bool useLocalization = true;

		public bool dynamicSorting = true;

		public bool saveMessageHistory;

		[SerializeField]
		[TextArea(2, 3)]
		private string audioMessageNotification = "Sent an audio message";

		[SerializeField]
		[TextArea(2, 3)]
		private string imageMessageNotification = "Sent an image";

		private bool sentSoundHelper;

		private string latestDynamicMessage;

		private string latestSTMessage;

		private string tempInputMessage;

		private float cachedStorytellerPanelLength = 0.5f;

		[HideInInspector]
		public bool allowInputSubmit;

		[HideInInspector]
		public ChatLayoutPreset selectedLayout;

		[HideInInspector]
		public int currentLayout;

		[HideInInspector]
		public int dynamicMessageIndex;

		[HideInInspector]
		public int storyTellerIndex;

		[HideInInspector]
		public int stItemIndex;

		[HideInInspector]
		public int stIndexHelper;

		[HideInInspector]
		public bool isStoryTellerOpen;

		[HideInInspector]
		public string latestPerson;

		[HideInInspector]
		public UnityEvent externalEvents = new UnityEvent();

		private void Awake()
		{
			if (photoGalleryManager == null && UnityEngine.Object.FindObjectsByType<PhotoGalleryManager>(FindObjectsSortMode.None).Length != 0)
			{
				photoGalleryManager = UnityEngine.Object.FindObjectsByType<PhotoGalleryManager>(FindObjectsSortMode.None)[0];
			}
			if (storyTellerAnimator != null)
			{
				cachedStorytellerPanelLength = DreamOSInternalTools.GetAnimatorClipLength(storyTellerAnimator, "StoryTeller_In") + 0.1f;
			}
			Initialize();
			if (messageStoring != null && saveMessageHistory)
			{
				messageStoring.ReadMessageData();
			}
		}

		private void OnEnable()
		{
			if (isStoryTellerOpen && stIndexHelper == currentLayout && storyTellerAnimator != null)
			{
				ShowStorytellerPanel();
			}
			else if (!isStoryTellerOpen && storyTellerAnimator != null)
			{
				SetStorytellerPanelDefault();
			}
			if (chatList[currentLayout].isVisible && selectedLayout != null)
			{
				selectedLayout.Show();
			}
		}

		private void Update()
		{
			if (!string.IsNullOrEmpty(messageInput.text) && !(EventSystem.current.currentSelectedGameObject != messageInput.gameObject))
			{
				if (!messageInput.isFocused)
				{
					messageInput.ActivateInputField();
				}
				if (allowInputSubmit && Keyboard.current.enterKey.wasPressedThisFrame)
				{
					CreateCustomMessageFromInput(null, isSelf: true);
				}
			}
		}

		public void Initialize()
		{
			createdLayoutPresets.Clear();
			foreach (Transform item in chatParent)
			{
				UnityEngine.Object.Destroy(item.gameObject);
			}
			foreach (Transform item2 in chatViewer)
			{
				UnityEngine.Object.Destroy(item2.gameObject);
			}
			for (int i = 0; i < chatList.Count; i++)
			{
				GameObject gameObject = UnityEngine.Object.Instantiate(chatLayout, new Vector3(0f, 0f, 0f), Quaternion.identity);
				gameObject.transform.SetParent(chatViewer, worldPositionStays: false);
				gameObject.gameObject.name = chatList[i].chatTitle;
				ChatLayoutPreset component = gameObject.GetComponent<ChatLayoutPreset>();
				component.manager = this;
				component.personPicture = chatList[i].individualPicture;
				component.personName = chatList[i].individualName + " " + chatList[i].individualSurname;
				createdLayoutPresets.Add(component);
				if (beginningIndicator != null)
				{
					UnityEngine.Object.Instantiate(beginningIndicator, new Vector3(0f, 0f, 0f), Quaternion.identity).transform.SetParent(component.messageParent, worldPositionStays: false);
				}
				for (int j = 0; j < chatList[i].chatAsset.messageList.Count; j++)
				{
					if (chatList[i].chatAsset.messageList[j].objectType == MessagingChat.ObjectType.Message)
					{
						GameObject original = null;
						if (chatList[i].chatAsset.messageList[j].messageAuthor == MessagingChat.MessageAuthor.Individual)
						{
							original = textMessageRecieved;
						}
						else if (chatList[i].chatAsset.messageList[j].messageAuthor == MessagingChat.MessageAuthor.Self)
						{
							original = textMessageSent;
						}
						GameObject gameObject2 = UnityEngine.Object.Instantiate(original, new Vector3(0f, 0f, 0f), Quaternion.identity);
						gameObject2.transform.SetParent(component.messageParent, worldPositionStays: false);
						ChatMessagePreset messagePreset = gameObject2.GetComponent<ChatMessagePreset>();
						messagePreset.timeText.text = chatList[i].chatAsset.messageList[j].sentTime;
						LocalizedObject tempLoc = messagePreset.contentText.gameObject.GetComponent<LocalizedObject>();
						if (!useLocalization || string.IsNullOrEmpty(chatList[i].chatAsset.messageList[j].messageKey) || tempLoc == null || !tempLoc.CheckLocalizationStatus())
						{
							messagePreset.contentText.text = chatList[i].chatAsset.messageList[j].messageContent;
						}
						else if (tempLoc != null)
						{
							tempLoc.localizationKey = chatList[i].chatAsset.messageList[j].messageKey;
							tempLoc.onLanguageChanged.AddListener(delegate
							{
								messagePreset.contentText.text = tempLoc.GetKeyOutput(tempLoc.localizationKey);
							});
							tempLoc.InitializeItem();
							tempLoc.UpdateItem();
						}
					}
					else if (chatList[i].chatAsset.messageList[j].objectType == MessagingChat.ObjectType.AudioMessage)
					{
						GameObject original2 = null;
						if (chatList[i].chatAsset.messageList[j].messageAuthor == MessagingChat.MessageAuthor.Individual)
						{
							original2 = audioMessageRecieved;
						}
						else if (chatList[i].chatAsset.messageList[j].messageAuthor == MessagingChat.MessageAuthor.Self)
						{
							original2 = audioMessageSent;
						}
						GameObject obj = UnityEngine.Object.Instantiate(original2, new Vector3(0f, 0f, 0f), Quaternion.identity);
						obj.transform.SetParent(component.messageParent, worldPositionStays: false);
						AudioMessage component2 = obj.GetComponent<AudioMessage>();
						component2.aSource = AudioManager.instance.audioSource;
						component2.aClip = chatList[i].chatAsset.messageList[j].audioMessage;
						component2.timeText.text = chatList[i].chatAsset.messageList[j].sentTime;
					}
					else if (chatList[i].chatAsset.messageList[j].objectType == MessagingChat.ObjectType.ImageMessage)
					{
						GameObject original3 = null;
						if (chatList[i].chatAsset.messageList[j].messageAuthor == MessagingChat.MessageAuthor.Individual)
						{
							original3 = imageMessageRecieved;
						}
						else if (chatList[i].chatAsset.messageList[j].messageAuthor == MessagingChat.MessageAuthor.Self)
						{
							original3 = imageMessageSent;
						}
						GameObject obj2 = UnityEngine.Object.Instantiate(original3, new Vector3(0f, 0f, 0f), Quaternion.identity);
						obj2.transform.SetParent(component.messageParent, worldPositionStays: false);
						ImageMessage component3 = obj2.GetComponent<ImageMessage>();
						component3.title = chatList[i].chatAsset.messageList[j].messageContent;
						component3.description = chatList[i].individualName + " " + chatList[i].individualSurname;
						component3.spriteVar = chatList[i].chatAsset.messageList[j].imageMessage;
						component3.imageObject.sprite = component3.spriteVar;
						component3.timeText.text = chatList[i].chatAsset.messageList[j].sentTime;
						if (photoGalleryManager != null)
						{
							component3.pgm = photoGalleryManager;
						}
					}
					else if (chatList[i].chatAsset.messageList[j].objectType == MessagingChat.ObjectType.Date)
					{
						GameObject obj3 = UnityEngine.Object.Instantiate(messageDate, new Vector3(0f, 0f, 0f), Quaternion.identity);
						obj3.transform.SetParent(component.messageParent, worldPositionStays: false);
						obj3.GetComponent<ChatMessagePreset>().contentText.text = chatList[i].chatAsset.messageList[j].messageContent;
					}
				}
				GameObject gameObject3 = UnityEngine.Object.Instantiate(chatItem, new Vector3(0f, 0f, 0f), Quaternion.identity);
				gameObject3.transform.SetParent(chatParent, worldPositionStays: false);
				gameObject3.gameObject.name = chatList[i].chatTitle;
				ChatItemPreset itemPreset = gameObject3.GetComponent<ChatItemPreset>();
				itemPreset.coverImage.sprite = chatList[i].individualPicture;
				itemPreset.nameText.text = chatList[i].individualName + " " + chatList[i].individualSurname;
				itemPreset.timeText.text = chatList[i].chatAsset.messageList[chatList[i].chatAsset.messageList.Count - 1].sentTime;
				LocalizedObject tempChatLoc = itemPreset.latestMessage.gameObject.GetComponent<LocalizedObject>();
				if (!useLocalization || string.IsNullOrEmpty(chatList[i].chatAsset.messageList[chatList[i].chatAsset.messageList.Count - 1].messageKey) || tempChatLoc == null || !tempChatLoc.CheckLocalizationStatus())
				{
					itemPreset.latestMessage.text = chatList[i].chatAsset.messageList[chatList[i].chatAsset.messageList.Count - 1].messageContent;
				}
				else if (tempChatLoc != null)
				{
					tempChatLoc.localizationKey = chatList[i].chatAsset.messageList[chatList[i].chatAsset.messageList.Count - 1].messageKey;
					tempChatLoc.onLanguageChanged.AddListener(delegate
					{
						itemPreset.latestMessage.text = tempChatLoc.GetKeyOutput(tempChatLoc.localizationKey);
					});
					tempChatLoc.InitializeItem();
					tempChatLoc.UpdateItem();
				}
				if (chatList[i].defaultStatus == Status.Offline)
				{
					itemPreset.ChangeStatus(Status.Offline);
				}
				else if (chatList[i].defaultStatus == Status.Online)
				{
					itemPreset.ChangeStatus(Status.Online);
				}
				ButtonManager itemButton = gameObject3.GetComponent<ButtonManager>();
				itemButton.onClick.AddListener(delegate
				{
					if (!(selectedLayout != null) || !(selectedLayout.name == itemButton.gameObject.name))
					{
						if (selectedLayout != null && selectedLayout.gameObject.activeInHierarchy)
						{
							selectedLayout.Hide();
						}
						int num = 0;
						for (int k = 0; k < createdLayoutPresets.Count; k++)
						{
							if (createdLayoutPresets[k].name == itemButton.gameObject.name)
							{
								selectedLayout = createdLayoutPresets[k];
								num = k;
								currentLayout = k;
								break;
							}
						}
						selectedLayout.gameObject.SetActive(value: true);
						selectedLayout.GetComponent<ChatLayoutPreset>().Show();
						if (isStoryTellerOpen && stIndexHelper != num && storyTellerAnimator != null)
						{
							HideStorytellerPanel();
						}
						else if (isStoryTellerOpen && stIndexHelper == num && storyTellerAnimator != null)
						{
							ShowStorytellerPanel();
						}
						itemPreset.EnableNotificationBadge(value: false);
						latestPerson = itemPreset.nameText.text;
					}
				});
				gameObject.SetActive(value: false);
				if (!chatList[i].isVisible)
				{
					gameObject3.SetActive(value: false);
				}
				if (i == 0)
				{
					selectedLayout = component;
				}
			}
		}

		public void CreateMessageFromInput()
		{
			CreateCustomMessageFromInput(null, isSelf: true);
			messageInput.text = "";
		}

		private void CreateCustomMessageFromInput(ChatLayoutPreset parent, bool isSelf)
		{
			if (parent == null)
			{
				parent = selectedLayout;
			}
			if (string.IsNullOrEmpty(messageInput.text) || messageInput.text == " ")
			{
				messageInput.text = "";
				return;
			}
			if (selectedLayout != null)
			{
				GameObject obj = UnityEngine.Object.Instantiate(textMessageSent, new Vector3(0f, 0f, 0f), Quaternion.identity);
				obj.transform.SetParent(parent.messageParent, worldPositionStays: false);
				ChatMessagePreset component = obj.GetComponent<ChatMessagePreset>();
				component.contentText.text = messageInput.text;
				component.timeText.text = GetTimeData();
				if (saveMessageHistory && messageStoring != null && isSelf)
				{
					messageStoring.ApplyMessageData(parent.name, "standard", "self", messageInput.text, component.timeText.text);
				}
				else if (saveMessageHistory && messageStoring != null && !isSelf)
				{
					messageStoring.ApplyMessageData(parent.name, "standard", "individual", messageInput.text, component.timeText.text);
				}
				LayoutRebuilder.ForceRebuildLayoutImmediate(obj.GetComponentInParent<RectTransform>());
				LayoutRebuilder.ForceRebuildLayoutImmediate(obj.GetComponent<RectTransform>());
			}
			if (currentLayout <= chatList.Count && chatList[currentLayout].chatAsset.useDynamicMessages && selectedLayout != null && messageInput.text.Length >= 1)
			{
				latestDynamicMessage = messageInput.text.Replace("\n", "");
				CreateDynamicMessage(currentLayout);
			}
			if (currentLayout <= chatList.Count && debugStoryTeller && selectedLayout != null && messageInput.text.Length >= 1 && chatList[currentLayout].chatAsset.useStoryTeller)
			{
				latestSTMessage = messageInput.text.Replace("\n", "");
				CreateStoryTeller(chatList[currentLayout].chatTitle, latestSTMessage);
			}
			if (AudioManager.instance != null && !sentSoundHelper)
			{
				AudioManager.instance.audioSource.PlayOneShot(sentMessageSFX);
			}
			if (isSelf)
			{
				UpdateChatItem(parent.name, messageInput.text, useUnreadBadge: false);
			}
			else
			{
				UpdateChatItem(parent.name, messageInput.text, useUnreadBadge: true);
			}
			externalEvents.Invoke();
			messageInput.text = tempInputMessage;
			sentSoundHelper = false;
		}

		public void CreateMessage(ChatLayoutPreset parent, string msgContent)
		{
			if (selectedLayout == null)
			{
				selectedLayout = parent;
			}
			tempInputMessage = messageInput.text;
			messageInput.text = msgContent;
			CreateCustomMessageFromInput(parent, isSelf: true);
		}

		public void CreateMessage(int layoutIndex, string msgContent)
		{
			ChatLayoutPreset component = chatViewer.Find(chatList[layoutIndex].chatTitle).GetComponent<ChatLayoutPreset>();
			CreateMessage(component, msgContent);
		}

		public void CreateIndividualMessage(ChatLayoutPreset parent, string msgContent, string locKey = null)
		{
			if (selectedLayout == null)
			{
				selectedLayout = parent;
			}
			sentSoundHelper = true;
			GameObject gameObject = textMessageSent;
			textMessageSent = textMessageRecieved;
			tempInputMessage = messageInput.text;
			LocalizedObject component = base.gameObject.GetComponent<LocalizedObject>();
			if (!useLocalization || string.IsNullOrEmpty(locKey) || component == null || !component.CheckLocalizationStatus())
			{
				messageInput.text = msgContent;
			}
			else if (component != null)
			{
				messageInput.text = component.GetKeyOutput(locKey);
			}
			CreateCustomMessageFromInput(parent, isSelf: false);
			textMessageSent = gameObject;
			if ((useNotifications && !parent.gameObject.activeInHierarchy) || (useNotifications && selectedLayout.name != parent.name))
			{
				for (int i = 0; i < chatList.Count; i++)
				{
					if (parent.name == chatList[i].chatTitle && latestPerson != chatList[i].individualName)
					{
						CreatePopupNotification(notificationIcon, chatList[i].individualName + " " + chatList[i].individualSurname, msgContent);
						break;
					}
				}
			}
			else if (AudioManager.instance != null)
			{
				AudioManager.instance.audioSource.PlayOneShot(receivedMessageSFX);
			}
		}

		public void CreateIndividualMessage(int layoutIndex, string msgContent, string locKey = null)
		{
			ChatLayoutPreset component = chatViewer.Find(chatList[layoutIndex].chatTitle).GetComponent<ChatLayoutPreset>();
			CreateIndividualMessage(component, msgContent, locKey);
		}

		public void CreateExternalMessage(Transform parent, string msgContent, string msgAuthor)
		{
			GameObject obj = UnityEngine.Object.Instantiate(textMessageRecieved, new Vector3(0f, 0f, 0f), Quaternion.identity);
			obj.transform.SetParent(parent, worldPositionStays: false);
			ChatMessagePreset component = obj.GetComponent<ChatMessagePreset>();
			component.contentText.text = msgContent;
			component.timeText.text = GetTimeData();
			if ((useNotifications && !parent.gameObject.activeInHierarchy) || (useNotifications && latestPerson != msgAuthor))
			{
				CreatePopupNotification(notificationIcon, msgAuthor, msgContent);
			}
			else if (AudioManager.instance != null)
			{
				AudioManager.instance.audioSource.PlayOneShot(receivedMessageSFX);
			}
		}

		public void CreateStoredMessage(string msgID, string message, string time, bool isSelf)
		{
			int index = 0;
			for (int i = 0; i < chatList.Count; i++)
			{
				if (chatList[i].chatTitle == msgID)
				{
					index = i;
					break;
				}
			}
			ChatLayoutPreset component = chatViewer.Find(chatList[index].chatTitle).GetComponent<ChatLayoutPreset>();
			GameObject gameObject;
			if (isSelf)
			{
				gameObject = UnityEngine.Object.Instantiate(textMessageSent, new Vector3(0f, 0f, 0f), Quaternion.identity);
				UpdateChatItem(chatList[index].chatTitle, message, useUnreadBadge: false, time);
			}
			else
			{
				gameObject = UnityEngine.Object.Instantiate(textMessageRecieved, new Vector3(0f, 0f, 0f), Quaternion.identity);
				UpdateChatItem(chatList[index].chatTitle, message, useUnreadBadge: true);
			}
			gameObject.transform.SetParent(component.messageParent, worldPositionStays: false);
			gameObject.GetComponent<ChatMessagePreset>().contentText.text = message;
			LayoutRebuilder.ForceRebuildLayoutImmediate(gameObject.GetComponent<RectTransform>());
		}

		public void CreateCustomMessage(ChatLayoutPreset parent, string message, string time, string locKey = null)
		{
			GameObject gameObject = UnityEngine.Object.Instantiate(textMessageSent, new Vector3(0f, 0f, 0f), Quaternion.identity);
			gameObject.transform.SetParent(parent.messageParent, worldPositionStays: false);
			ChatMessagePreset messagePreset = gameObject.GetComponent<ChatMessagePreset>();
			messagePreset.timeText.text = time;
			LocalizedObject tempLoc = messagePreset.contentText.gameObject.GetComponent<LocalizedObject>();
			if (!useLocalization || string.IsNullOrEmpty(locKey) || tempLoc == null || !tempLoc.CheckLocalizationStatus())
			{
				messagePreset.contentText.text = message;
			}
			else if (tempLoc != null)
			{
				tempLoc.localizationKey = locKey;
				tempLoc.onLanguageChanged.AddListener(delegate
				{
					messagePreset.contentText.text = tempLoc.GetKeyOutput(tempLoc.localizationKey);
				});
				tempLoc.InitializeItem();
				tempLoc.UpdateItem();
				message = messagePreset.contentText.text;
			}
			LayoutRebuilder.ForceRebuildLayoutImmediate(gameObject.GetComponent<RectTransform>());
			if (AudioManager.instance != null)
			{
				AudioManager.instance.audioSource.PlayOneShot(sentMessageSFX);
			}
			if (saveMessageHistory && messageStoring != null)
			{
				messageStoring.ApplyMessageData(parent.name, "standard", "self", message, time);
			}
			UpdateChatItem(parent.name, message, useUnreadBadge: false);
		}

		public void CreateCustomMessage(int layoutIndex, string message, string time, string locKey = null)
		{
			ChatLayoutPreset component = chatViewer.Find(chatList[layoutIndex].chatTitle).GetComponent<ChatLayoutPreset>();
			CreateCustomMessage(component, message, time, locKey);
		}

		public void CreateCustomIndividualMessage(ChatLayoutPreset parent, string message, string time, string locKey = null)
		{
			GameObject gameObject = UnityEngine.Object.Instantiate(textMessageRecieved, new Vector3(0f, 0f, 0f), Quaternion.identity);
			gameObject.transform.SetParent(parent.messageParent, worldPositionStays: false);
			ChatMessagePreset messagePreset = gameObject.GetComponent<ChatMessagePreset>();
			messagePreset.timeText.text = time;
			if (!useLocalization || string.IsNullOrEmpty(locKey))
			{
				messagePreset.contentText.text = message;
			}
			else
			{
				LocalizedObject tempLoc = messagePreset.contentText.gameObject.GetComponent<LocalizedObject>();
				if (tempLoc != null)
				{
					tempLoc.localizationKey = locKey;
					tempLoc.onLanguageChanged.AddListener(delegate
					{
						messagePreset.contentText.text = tempLoc.GetKeyOutput(tempLoc.localizationKey);
					});
					tempLoc.InitializeItem();
					tempLoc.UpdateItem();
					message = messagePreset.contentText.text;
				}
			}
			LayoutRebuilder.ForceRebuildLayoutImmediate(gameObject.GetComponent<RectTransform>());
			if ((useNotifications && !parent.gameObject.activeInHierarchy) || (useNotifications && selectedLayout.name != parent.name))
			{
				for (int num = 0; num < chatList.Count; num++)
				{
					if (parent.name == chatList[num].chatTitle)
					{
						CreatePopupNotification(notificationIcon, chatList[num].individualName + " " + chatList[num].individualSurname, message);
						break;
					}
				}
			}
			else if (AudioManager.instance != null)
			{
				AudioManager.instance.audioSource.PlayOneShot(receivedMessageSFX);
			}
			if (saveMessageHistory && messageStoring != null)
			{
				messageStoring.ApplyMessageData(parent.name, "standard", "individual", message, time);
			}
			UpdateChatItem(parent.name, message, useUnreadBadge: true);
		}

		public void CreateCustomIndividualMessage(int layoutIndex, string message, string time, string locKey = null)
		{
			ChatLayoutPreset component = chatViewer.Find(chatList[layoutIndex].chatTitle).GetComponent<ChatLayoutPreset>();
			CreateCustomIndividualMessage(component, message, time, locKey);
		}

		public void CreateDate(ChatLayoutPreset parent, string date)
		{
			GameObject obj = UnityEngine.Object.Instantiate(messageDate, new Vector3(0f, 0f, 0f), Quaternion.identity);
			obj.transform.SetParent(parent.messageParent, worldPositionStays: false);
			obj.GetComponent<ChatMessagePreset>().contentText.text = date;
			LayoutRebuilder.ForceRebuildLayoutImmediate(obj.GetComponent<RectTransform>());
		}

		public void CreateDate(int layoutIndex, string date)
		{
			ChatLayoutPreset component = chatViewer.Find(chatList[layoutIndex].chatTitle).GetComponent<ChatLayoutPreset>();
			CreateDate(component, date);
		}

		public void CreateImageMessage(ChatLayoutPreset parent, Sprite sprite, string title, string description, string time = null)
		{
			_ = parent == null;
			GameObject obj = UnityEngine.Object.Instantiate(imageMessageSent, new Vector3(0f, 0f, 0f), Quaternion.identity);
			obj.transform.SetParent(parent.messageParent, worldPositionStays: false);
			ImageMessage component = obj.GetComponent<ImageMessage>();
			component.title = title;
			component.description = description;
			component.spriteVar = sprite;
			component.imageObject.sprite = component.spriteVar;
			if (photoGalleryManager != null)
			{
				component.pgm = photoGalleryManager;
			}
			if (string.IsNullOrEmpty(time))
			{
				component.timeText.text = GetTimeData();
			}
			else
			{
				component.timeText.text = time;
			}
			LayoutRebuilder.ForceRebuildLayoutImmediate(obj.GetComponent<RectTransform>());
			if (AudioManager.instance != null)
			{
				AudioManager.instance.audioSource.PlayOneShot(sentMessageSFX);
			}
			UpdateChatItem(parent.name, title, useUnreadBadge: false);
		}

		public void CreateImageMessage(int layoutIndex, Sprite sprite, string title, string description, string time = "")
		{
			ChatLayoutPreset component = chatViewer.Find(chatList[layoutIndex].chatTitle).GetComponent<ChatLayoutPreset>();
			CreateImageMessage(component, sprite, title, description, time);
		}

		public void CreateIndividualImageMessage(ChatLayoutPreset parent, Sprite sprite, string title, string description, string time = null)
		{
			GameObject obj = UnityEngine.Object.Instantiate(imageMessageRecieved, new Vector3(0f, 0f, 0f), Quaternion.identity);
			obj.transform.SetParent(parent.messageParent, worldPositionStays: false);
			ImageMessage component = obj.GetComponent<ImageMessage>();
			component.title = title;
			component.description = description;
			component.spriteVar = sprite;
			component.imageObject.sprite = component.spriteVar;
			if (photoGalleryManager != null)
			{
				component.pgm = photoGalleryManager;
			}
			if (string.IsNullOrEmpty(time))
			{
				component.timeText.text = GetTimeData();
			}
			else
			{
				component.timeText.text = time;
			}
			LayoutRebuilder.ForceRebuildLayoutImmediate(obj.GetComponent<RectTransform>());
			if ((useNotifications && !parent.gameObject.activeInHierarchy) || (useNotifications && selectedLayout.name != parent.name))
			{
				for (int i = 0; i < chatList.Count; i++)
				{
					if (parent.name == chatList[i].chatTitle)
					{
						CreatePopupNotification(notificationIcon, chatList[i].individualName + " " + chatList[i].individualSurname, imageMessageNotification);
						break;
					}
				}
			}
			else if (AudioManager.instance != null)
			{
				AudioManager.instance.audioSource.PlayOneShot(receivedMessageSFX);
			}
			UpdateChatItem(parent.name, title, useUnreadBadge: true);
		}

		public void CreateIndividualImageMessage(int layoutIndex, Sprite sprite, string title, string description, string time = null)
		{
			ChatLayoutPreset component = chatViewer.Find(chatList[layoutIndex].chatTitle).GetComponent<ChatLayoutPreset>();
			CreateIndividualImageMessage(component, sprite, title, description, time);
		}

		public void CreateAudioMessage(ChatLayoutPreset parent, AudioClip audio, string time = null)
		{
			GameObject obj = UnityEngine.Object.Instantiate(audioMessageSent, new Vector3(0f, 0f, 0f), Quaternion.identity);
			obj.transform.SetParent(parent.messageParent, worldPositionStays: false);
			AudioMessage component = obj.GetComponent<AudioMessage>();
			component.aSource = AudioManager.instance.audioSource;
			component.aClip = audio;
			if (string.IsNullOrEmpty(time))
			{
				component.timeText.text = GetTimeData();
			}
			else
			{
				component.timeText.text = time;
			}
			LayoutRebuilder.ForceRebuildLayoutImmediate(obj.GetComponent<RectTransform>());
			if (AudioManager.instance != null)
			{
				AudioManager.instance.audioSource.PlayOneShot(sentMessageSFX);
			}
			UpdateChatItem(parent.name, audio.name, useUnreadBadge: false);
		}

		public void CreateAudioMessage(int layoutIndex, AudioClip audio, string time = null)
		{
			ChatLayoutPreset component = chatViewer.Find(chatList[layoutIndex].chatTitle).GetComponent<ChatLayoutPreset>();
			CreateAudioMessage(component, audio, time);
		}

		public void CreateIndividualAudioMessage(ChatLayoutPreset parent, AudioClip audio, string time = null)
		{
			GameObject obj = UnityEngine.Object.Instantiate(audioMessageRecieved, new Vector3(0f, 0f, 0f), Quaternion.identity);
			obj.transform.SetParent(parent.messageParent, worldPositionStays: false);
			AudioMessage component = obj.GetComponent<AudioMessage>();
			component.aSource = AudioManager.instance.audioSource;
			component.aClip = audio;
			if (string.IsNullOrEmpty(time))
			{
				component.timeText.text = GetTimeData();
			}
			else
			{
				component.timeText.text = time;
			}
			LayoutRebuilder.ForceRebuildLayoutImmediate(obj.GetComponent<RectTransform>());
			if ((useNotifications && !parent.gameObject.activeInHierarchy) || (useNotifications && selectedLayout.name != parent.name))
			{
				for (int i = 0; i < chatList.Count; i++)
				{
					if (parent.name == chatList[i].chatTitle)
					{
						CreatePopupNotification(notificationIcon, chatList[i].individualName + " " + chatList[i].individualSurname, audioMessageNotification);
						break;
					}
				}
			}
			else if (AudioManager.instance != null)
			{
				AudioManager.instance.audioSource.PlayOneShot(receivedMessageSFX);
			}
			UpdateChatItem(parent.name, audio.name, useUnreadBadge: true);
		}

		public void CreateIndividualAudioMessage(int layoutIndex, AudioClip audio, string time = null)
		{
			ChatLayoutPreset component = chatViewer.Find(chatList[layoutIndex].chatTitle).GetComponent<ChatLayoutPreset>();
			CreateIndividualAudioMessage(component, audio, time);
		}

		public void CreateDynamicMessage(int layoutIndex, bool waitingForTimer = true)
		{
			for (int i = 0; i < chatList[layoutIndex].chatAsset.dynamicMessages.Count; i++)
			{
				if (latestDynamicMessage == chatList[layoutIndex].chatAsset.dynamicMessages[i].messageContent)
				{
					if (!chatList[layoutIndex].chatAsset.dynamicMessages[i].enableReply)
					{
						return;
					}
					dynamicMessageIndex = i;
					break;
				}
			}
			if (!string.IsNullOrEmpty(chatList[layoutIndex].chatAsset.dynamicMessages[dynamicMessageIndex].runStoryteller) && chatList[layoutIndex].chatAsset.useDynamicMessages && chatList[layoutIndex].chatAsset.dynamicMessages[dynamicMessageIndex].messageContent == latestDynamicMessage)
			{
				string text = null;
				for (int j = 0; j < chatList[layoutIndex].chatAsset.storyTeller.Count; j++)
				{
					if (chatList[layoutIndex].chatAsset.storyTeller[j].itemID == chatList[layoutIndex].chatAsset.dynamicMessages[dynamicMessageIndex].runStoryteller)
					{
						text = chatList[layoutIndex].chatAsset.storyTeller[j].itemID;
						break;
					}
				}
				if (text == null)
				{
					Debug.Log("Couldn't find any Storyteller item with the following ID: " + chatList[layoutIndex].chatAsset.dynamicMessages[dynamicMessageIndex].runStoryteller);
				}
				else
				{
					CreateStoryTeller(chatList[layoutIndex].chatTitle, chatList[layoutIndex].chatAsset.dynamicMessages[dynamicMessageIndex].runStoryteller);
				}
			}
			else if (!waitingForTimer && chatList[layoutIndex].chatAsset.useDynamicMessages && chatList[layoutIndex].chatAsset.dynamicMessages[dynamicMessageIndex].messageContent == latestDynamicMessage)
			{
				GameObject gameObject = UnityEngine.Object.Instantiate(textMessageRecieved, new Vector3(0f, 0f, 0f), Quaternion.identity);
				ChatLayoutPreset chatLayoutPreset = null;
				try
				{
					chatLayoutPreset = chatViewer.Find(chatList[layoutIndex].chatTitle).GetComponent<ChatLayoutPreset>();
					gameObject.transform.SetParent(chatLayoutPreset.messageParent, worldPositionStays: false);
				}
				catch
				{
					gameObject.transform.SetParent(selectedLayout.messageParent, worldPositionStays: false);
				}
				ChatMessagePreset messagePreset = gameObject.GetComponent<ChatMessagePreset>();
				messagePreset.timeText.text = GetTimeData();
				LocalizedObject tempLoc = messagePreset.contentText.gameObject.GetComponent<LocalizedObject>();
				if (!useLocalization || string.IsNullOrEmpty(chatList[layoutIndex].chatAsset.dynamicMessages[dynamicMessageIndex].replyKey) || tempLoc == null || !tempLoc.CheckLocalizationStatus())
				{
					messagePreset.contentText.text = chatList[layoutIndex].chatAsset.dynamicMessages[dynamicMessageIndex].replyContent;
				}
				else if (tempLoc != null)
				{
					tempLoc.localizationKey = chatList[layoutIndex].chatAsset.dynamicMessages[dynamicMessageIndex].replyKey;
					tempLoc.onLanguageChanged.AddListener(delegate
					{
						messagePreset.contentText.text = tempLoc.GetKeyOutput(tempLoc.localizationKey);
					});
					tempLoc.InitializeItem();
					tempLoc.UpdateItem();
				}
				if (saveMessageHistory && messageStoring != null)
				{
					messageStoring.ApplyMessageData(chatLayoutPreset.gameObject.name, "standard", "individual", messagePreset.contentText.text, messagePreset.timeText.text);
				}
				LayoutRebuilder.ForceRebuildLayoutImmediate(gameObject.GetComponentInParent<RectTransform>());
				LayoutRebuilder.ForceRebuildLayoutImmediate(gameObject.GetComponent<RectTransform>());
				if ((useNotifications && !chatLayoutPreset.gameObject.activeInHierarchy) || (useNotifications && selectedLayout.name != chatLayoutPreset.gameObject.name))
				{
					CreatePopupNotification(notificationIcon, chatList[layoutIndex].individualName + " " + chatList[layoutIndex].individualSurname, chatList[layoutIndex].chatAsset.dynamicMessages[dynamicMessageIndex].replyContent);
				}
				else if (AudioManager.instance != null)
				{
					AudioManager.instance.audioSource.PlayOneShot(receivedMessageSFX);
				}
				UpdateChatItem(chatList[layoutIndex].chatTitle, chatList[layoutIndex].chatAsset.dynamicMessages[dynamicMessageIndex].replyContent, useUnreadBadge: true);
			}
			else if (waitingForTimer && chatList[layoutIndex].chatAsset.dynamicMessages[dynamicMessageIndex].messageContent == latestDynamicMessage)
			{
				allowInputSubmit = false;
				DynamicMessageHandler dynamicMessageHandler = new GameObject
				{
					name = "[Temp Dynamic Message Handler]"
				}.AddComponent<DynamicMessageHandler>();
				dynamicMessageHandler.manager = this;
				dynamicMessageHandler.StartCoroutine(dynamicMessageHandler.HandleDynamicMessage(chatList[layoutIndex].chatAsset.dynamicMessages[dynamicMessageIndex].replyLatency, layoutIndex));
			}
		}

		public void CreateStoryTeller(string chatTitle, string storyTellerID)
		{
			if (storyTellerAnimator == null || storyTellerList == null)
			{
				return;
			}
			bool flag = false;
			int num = -1;
			string replyLocKey = null;
			for (int i = 0; i < chatList.Count; i++)
			{
				if (chatTitle == chatList[i].chatTitle)
				{
					num = i;
					break;
				}
			}
			if (num == -1)
			{
				return;
			}
			for (int j = 0; j < chatList[num].chatAsset.storyTeller.Count; j++)
			{
				if (storyTellerID == chatList[num].chatAsset.storyTeller[j].itemID)
				{
					storyTellerIndex = j;
					flag = true;
					break;
				}
			}
			if (!flag)
			{
				return;
			}
			stIndexHelper = num;
			foreach (Transform storyTeller in storyTellerList)
			{
				UnityEngine.Object.Destroy(storyTeller.gameObject);
			}
			DynamicMessageHandler dynamicMessageHandler = new GameObject
			{
				name = "[Temp Storyteller Handler] " + chatList[num].chatAsset.storyTeller[storyTellerIndex].itemID
			}.AddComponent<DynamicMessageHandler>();
			dynamicMessageHandler.manager = this;
			if (!string.IsNullOrEmpty(chatList[num].chatAsset.storyTeller[storyTellerIndex].messageContent) && chatList[num].chatAsset.storyTeller[storyTellerIndex].messageAuthor == MessagingChat.MessageAuthor.Self)
			{
				dynamicMessageHandler.StartCoroutine(dynamicMessageHandler.HandleStoryTeller(chatList[num].chatAsset.storyTeller[storyTellerIndex].messageLatency, num, isIndividual: false));
			}
			else if (!string.IsNullOrEmpty(chatList[num].chatAsset.storyTeller[storyTellerIndex].messageContent) && chatList[num].chatAsset.storyTeller[storyTellerIndex].messageAuthor == MessagingChat.MessageAuthor.Individual)
			{
				dynamicMessageHandler.StartCoroutine(dynamicMessageHandler.HandleStoryTeller(chatList[num].chatAsset.storyTeller[storyTellerIndex].messageLatency, num, isIndividual: true));
			}
			for (int k = 0; k < chatList[num].chatAsset.storyTeller[storyTellerIndex].replies.Count; k++)
			{
				GameObject gameObject = UnityEngine.Object.Instantiate(storyTellerObject, new Vector3(0f, 0f, 0f), Quaternion.identity);
				gameObject.transform.SetParent(storyTellerList, worldPositionStays: false);
				TextMeshProUGUI strBrief = gameObject.transform.GetComponentInChildren<TextMeshProUGUI>();
				LocalizedObject tempLoc = strBrief.gameObject.GetComponent<LocalizedObject>();
				if (!useLocalization || string.IsNullOrEmpty(chatList[num].chatAsset.storyTeller[storyTellerIndex].replies[k].briefKey) || tempLoc == null || !tempLoc.CheckLocalizationStatus())
				{
					strBrief.text = chatList[num].chatAsset.storyTeller[storyTellerIndex].replies[k].replyBrief;
				}
				else
				{
					tempLoc.localizationKey = chatList[num].chatAsset.storyTeller[storyTellerIndex].replies[k].briefKey;
					tempLoc.onLanguageChanged.AddListener(delegate
					{
						strBrief.text = tempLoc.GetKeyOutput(tempLoc.localizationKey);
					});
					tempLoc.InitializeItem();
					tempLoc.UpdateItem();
					replyLocKey = tempLoc.GetKeyOutput(chatList[num].chatAsset.storyTeller[storyTellerIndex].replies[k].contentKey);
				}
				ChatLayoutPreset component = chatViewer.Find(chatList[num].chatTitle).GetComponent<ChatLayoutPreset>();
				StorytellerItem component2 = gameObject.GetComponent<StorytellerItem>();
				component2.layout = component;
				component2.layoutIndex = num;
				component2.itemIndex = k;
				component2.msgManager = this;
				component2.handler = dynamicMessageHandler;
				component2.name = chatList[num].chatAsset.storyTeller[storyTellerIndex].replies[k].replyID;
				component2.replyLocKey = replyLocKey;
			}
		}

		public string GetTimeData()
		{
			string result = null;
			if (DateAndTimeManager.instance != null && DateAndTimeManager.instance.useShortTimeFormat)
			{
				result = ((DateAndTimeManager.instance.currentMinute.ToString().Length != 1) ? (DateAndTimeManager.instance.currentHour + ":" + DateAndTimeManager.instance.currentMinute) : (DateAndTimeManager.instance.currentHour + ":0" + DateAndTimeManager.instance.currentMinute));
				result = ((!DateAndTimeManager.instance.isAm) ? (result + " PM") : (result + " AM"));
			}
			else if (DateAndTimeManager.instance != null && !DateAndTimeManager.instance.useShortTimeFormat)
			{
				result = ((DateAndTimeManager.instance.currentMinute.ToString().Length != 1) ? (DateAndTimeManager.instance.currentHour + ":" + DateAndTimeManager.instance.currentMinute) : (DateAndTimeManager.instance.currentHour + ":0" + DateAndTimeManager.instance.currentMinute));
			}
			return result;
		}

		public void EnableDynamicMessageReply(string messageID)
		{
			for (int i = 0; i < chatList[currentLayout].chatAsset.dynamicMessages.Count; i++)
			{
				if (messageID == chatList[currentLayout].chatAsset.dynamicMessages[i].messageID)
				{
					chatList[currentLayout].chatAsset.dynamicMessages[i].enableReply = true;
					break;
				}
			}
		}

		public void EnableDynamicMessageReply(int layoutIndex, string messageID)
		{
			for (int i = 0; i < chatList[layoutIndex].chatAsset.dynamicMessages.Count; i++)
			{
				if (messageID == chatList[layoutIndex].chatAsset.dynamicMessages[i].messageID)
				{
					chatList[layoutIndex].chatAsset.dynamicMessages[i].enableReply = true;
					break;
				}
			}
		}

		public void DisableDynamicMessageReply(string messageID)
		{
			for (int i = 0; i < chatList[currentLayout].chatAsset.dynamicMessages.Count; i++)
			{
				if (messageID == chatList[currentLayout].chatAsset.dynamicMessages[i].messageID)
				{
					chatList[currentLayout].chatAsset.dynamicMessages[i].enableReply = false;
					break;
				}
			}
		}

		public void DisableDynamicMessageReply(int layoutIndex, string messageID)
		{
			for (int i = 0; i < chatList[layoutIndex].chatAsset.dynamicMessages.Count; i++)
			{
				if (messageID == chatList[layoutIndex].chatAsset.dynamicMessages[i].messageID)
				{
					chatList[layoutIndex].chatAsset.dynamicMessages[i].enableReply = false;
					break;
				}
			}
		}

		public void EnableChat(string chatTitle)
		{
			chatParent.Find(chatTitle).gameObject.SetActive(value: true);
		}

		public void UpdateChatItem(string chatTitle, string newMessage, bool useUnreadBadge, string time = null)
		{
			ChatItemPreset component = chatParent.Find(chatTitle).GetComponent<ChatItemPreset>();
			if (!(component == null))
			{
				if (dynamicSorting)
				{
					component.transform.SetAsFirstSibling();
				}
				if (string.IsNullOrEmpty(time))
				{
					component.UpdateLatestMessage(newMessage, GetTimeData());
				}
				else
				{
					component.UpdateLatestMessage(newMessage, time);
				}
				if (selectedLayout != null && !selectedLayout.gameObject.activeInHierarchy && useUnreadBadge)
				{
					component.EnableNotificationBadge(value: true);
				}
				else if (selectedLayout != null && chatTitle != selectedLayout.name && useUnreadBadge)
				{
					component.EnableNotificationBadge(value: true);
				}
			}
		}

		public void ChangeStatus(Status status, string chatTitle)
		{
			chatParent.Find(chatTitle).GetComponent<ChatItemPreset>().ChangeStatus(status);
		}

		public void AllowInputSubmit(bool value)
		{
			allowInputSubmit = value;
		}

		public void ShowStorytellerPanel()
		{
			isStoryTellerOpen = true;
			storyTellerAnimator.enabled = true;
			storyTellerAnimator.Play("In");
			StopCoroutine("DisableStorytellerAnimator");
			StartCoroutine("DisableStorytellerAnimator");
		}

		public void HideStorytellerPanel()
		{
			storyTellerAnimator.enabled = true;
			storyTellerAnimator.Play("Out");
			StopCoroutine("DisableStorytellerAnimator");
			StartCoroutine("DisableStorytellerAnimator");
		}

		private void SetStorytellerPanelDefault()
		{
			storyTellerAnimator.enabled = true;
			storyTellerAnimator.Play("Start");
			StopCoroutine("DisableStorytellerAnimator");
			StartCoroutine("DisableStorytellerAnimator");
		}

		private void CreatePopupNotification(Sprite icon, string name, string description)
		{
			if (!(NotificationManager.instance == null))
			{
				NotificationManager.instance.CreatePopupNotification(icon, name, description, enableSound: true, receivedMessageSFX);
			}
		}

		private IEnumerator DisableStorytellerAnimator()
		{
			yield return new WaitForSeconds(cachedStorytellerPanelLength);
			storyTellerAnimator.enabled = false;
		}

		public int GetChatLayoutIndexFromTitle(string chatTitle)
		{
			int result = 0;
			for (int i = 0; i < chatList.Count; i++)
			{
				if (chatList[i].chatTitle == chatTitle)
				{
					result = i;
					break;
				}
			}
			return result;
		}

		public string GetChatLayoutTitleFromIndex(int index)
		{
			return chatList[index].chatTitle;
		}
	}
}
