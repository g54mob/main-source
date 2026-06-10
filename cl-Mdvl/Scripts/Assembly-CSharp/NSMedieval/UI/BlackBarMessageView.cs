using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using NSEipix.Base;
using NSMedieval.Controllers;
using NSMedieval.Manager;
using NSMedieval.View;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace NSMedieval.UI
{
	public class BlackBarMessageView : UIView, IObserver
	{
		[SerializeField]
		private int maxMessages = 3;

		[SerializeField]
		private float messageDuration = 3f;

		[SerializeField]
		private AnimationCurve fadeCurve;

		[SerializeField]
		private AnimationCurve colorCurve;

		[SerializeField]
		private ButtonLayoutItemView messagePrefab;

		[SerializeField]
		private Image background;

		[NonSerialized]
		private Dictionary<ButtonLayoutItemView, float> messages = new Dictionary<ButtonLayoutItemView, float>();

		[NonSerialized]
		private readonly Dictionary<string, IEnumerator> messageShowingCoroutineByText = new Dictionary<string, IEnumerator>();

		[NonSerialized]
		private readonly Dictionary<string, ButtonLayoutItemView> messageViewByText = new Dictionary<string, ButtonLayoutItemView>();

		private void ShowMessage(string messageText, UnityAction onClick)
		{
			if (messageShowingCoroutineByText.TryGetValue(messageText, out var value) && messageViewByText.TryGetValue(messageText, out var value2))
			{
				StopCoroutine(value);
				messages[value2] = messageDuration;
				StartCoroutine(FadeoutTimer(value2));
				if (onClick != null)
				{
					value2.Button.onClick.RemoveAllListeners();
					value2.Button.onClick.AddListener(onClick);
				}
				return;
			}
			ButtonLayoutItemView key = messages.FirstOrDefault((KeyValuePair<ButtonLayoutItemView, float> pair) => !pair.Key.gameObject.activeSelf).Key;
			if (key == null)
			{
				key = messages.Aggregate((KeyValuePair<ButtonLayoutItemView, float> first, KeyValuePair<ButtonLayoutItemView, float> second) => (!(first.Value < second.Value)) ? second : first).Key;
			}
			background.enabled = true;
			key.gameObject.SetActive(value: true);
			key.gameObject.transform.SetSiblingIndex(0);
			key.SetTextData(messageText);
			if (onClick != null)
			{
				key.Button.AddCleanListener(onClick);
			}
			else
			{
				key.Button.onClick.RemoveAllListeners();
			}
			messages[key] = messageDuration;
			IEnumerator enumerator = FadeoutTimer(key);
			messageViewByText.Add(messageText, key);
			messageShowingCoroutineByText.Add(messageText, enumerator);
			StartCoroutine(enumerator);
		}

		private void OnHideAllMessages()
		{
			StopAllCoroutines();
			foreach (KeyValuePair<ButtonLayoutItemView, float> message in messages)
			{
				HideMessage(message.Key);
			}
		}

		private void HideMessage(ButtonLayoutItemView message)
		{
			string key = messageViewByText.FirstOrDefault((KeyValuePair<string, ButtonLayoutItemView> kvp) => kvp.Value == message).Key;
			if (!string.IsNullOrEmpty(key))
			{
				messageViewByText.Remove(key);
				messageShowingCoroutineByText.Remove(key);
			}
			message.gameObject.SetActive(value: false);
			message.Button.onClick.RemoveAllListeners();
			if (messages.FirstOrDefault((KeyValuePair<ButtonLayoutItemView, float> text) => text.Key.gameObject.activeSelf).Key == null)
			{
				background.enabled = false;
			}
		}

		private IEnumerator FadeoutTimer(ButtonLayoutItemView message)
		{
			float timer = messages[message];
			while (timer >= messages[message] && messages[message] > 0f)
			{
				messages[message] -= Time.unscaledDeltaTime;
				Color color = Color.Lerp(new Color(0.8f, 0.8f, 0.8f), Color.white, colorCurve.Evaluate(messages[message] * (1f / messageDuration)));
				color.a = fadeCurve.Evaluate(messages[message] * (1f / messageDuration));
				message.TextObject.color = color;
				timer = messages[message];
				yield return null;
			}
			if (messages[message] <= 0f)
			{
				HideMessage(message);
			}
		}

		private void OnMainSceneLeaving()
		{
			OnHideAllMessages();
		}

		private void OnShowClickableMessage(string messageText, Vector3 position)
		{
			UnityAction onClick = null;
			if (position != Vector3.zero)
			{
				onClick = delegate
				{
					base.CameraCenterAction(position, arg2: false);
				};
			}
			ShowMessage(messageText, onClick);
		}

		private void OnShowClickableSelectableMessage(string messageText, SelectableObject selectableObject, bool follow = false)
		{
			ShowMessage(messageText, delegate
			{
				if (selectableObject != null)
				{
					MonoSingleton<SelectableObjectManager>.Instance.SelectObject(selectableObject);
					if (follow)
					{
						base.CameraFollowAction(selectableObject.transform);
					}
					else
					{
						base.CameraCenterAction(selectableObject.transform.position, arg2: false);
					}
				}
			});
		}

		private void OnShowMessage(string messageText)
		{
			ShowMessage(messageText, null);
		}

		private void Start()
		{
			MonoSingleton<LoadingController>.Instance.MainSceneLeavingEvent += OnMainSceneLeaving;
			MonoSingleton<BlackBarMessageController>.Instance.MessageEvent += OnShowMessage;
			MonoSingleton<BlackBarMessageController>.Instance.ClickableMessageEvent += OnShowClickableMessage;
			MonoSingleton<BlackBarMessageController>.Instance.ClickableSelectableMessageEvent += OnShowClickableSelectableMessage;
			MonoSingleton<BlackBarMessageController>.Instance.HideAllMessagesEvent += OnHideAllMessages;
			for (int i = 0; i < maxMessages; i++)
			{
				messages.Add(UnityEngine.Object.Instantiate(messagePrefab, Vector3.zero, Quaternion.identity, base.transform), 0f);
			}
		}

		protected override void OnDestroy()
		{
			if (MonoSingleton<LoadingController>.IsInstantiated())
			{
				MonoSingleton<LoadingController>.Instance.MainSceneLeavingEvent -= OnMainSceneLeaving;
			}
			if (MonoSingleton<BlackBarMessageController>.IsInstantiated())
			{
				MonoSingleton<BlackBarMessageController>.Instance.MessageEvent -= OnShowMessage;
				MonoSingleton<BlackBarMessageController>.Instance.ClickableMessageEvent -= OnShowClickableMessage;
				MonoSingleton<BlackBarMessageController>.Instance.ClickableSelectableMessageEvent -= OnShowClickableSelectableMessage;
				MonoSingleton<BlackBarMessageController>.Instance.HideAllMessagesEvent -= OnHideAllMessages;
			}
			base.OnDestroy();
		}
	}
}
