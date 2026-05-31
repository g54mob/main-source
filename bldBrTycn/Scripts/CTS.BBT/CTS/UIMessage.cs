using System;
using System.Collections.Generic;
using CTS.BBT;
using CTS.Core;
using CTS.UI;
using CTS.Utilities;
using NaughtyAttributes;
using UnityEngine;
using UnityEngine.Localization.Components;
using UnityEngine.UI;

namespace CTS
{
	public class UIMessage : CTSSingleton<UIMessage>
	{
		[SerializeField]
		private CanvasGroupController _controller;

		[SerializeField]
		private Image _image;

		[SerializeField]
		private LocalizeStringEvent _name;

		[SerializeField]
		private GameObject _subtitleObject;

		[SerializeField]
		private LocalizeStringEvent _subtitle;

		[SerializeField]
		private LocalizeStringEvent _description;

		[SerializeField]
		private Sprite _defaultSprite;

		[Inject(false)]
		private ObjectToggleByKey _displayToggle;

		private LockToggle _time = new LockToggle();

		private readonly Queue<MessageData> _messageQueue = new Queue<MessageData>();

		private MessageData? _currentlyPlaying;

		[SerializeField]
		[Header("Debug")]
		private UIMessageBase _debugMessage;

		public static event Action MessageValidated;

		public static event Action MessageShowing;

		protected override void SingletonAwake()
		{
			_time.Add(MonoSingleton<TimeController>.Instance);
		}

		protected override void OnSingletonDestroy()
		{
		}

		public bool IsPlayingSomething()
		{
			return _currentlyPlaying.HasValue;
		}

		public bool IsPlaying(Guid id)
		{
			MessageData? currentlyPlaying = _currentlyPlaying;
			if (!currentlyPlaying.HasValue)
			{
				return false;
			}
			if (_currentlyPlaying.Value.Id == id)
			{
				return true;
			}
			foreach (MessageData item in _messageQueue)
			{
				if (item.Id == id)
				{
					return true;
				}
			}
			return false;
		}

		public Guid ShowMessage(IUIMessage messageSO)
		{
			if (messageSO == null)
			{
				Debug.LogException(new NullReferenceException("Message Data is null"));
				return default(Guid);
			}
			MessageData message = default(MessageData);
			try
			{
				message.Icon = messageSO.GetSprite();
				message.Title = messageSO.GetTitle();
				message.Subtitle = messageSO.GetSubtitle();
				message.Description = messageSO.GetDescription();
				message.EndEvent = messageSO.GetEndEvent();
				message.DisplayMode = (messageSO.ShouldUseSpecificVisual() ? messageSO.GetSpecificVisualKey() : _displayToggle.DefaultMode);
			}
			catch (Exception exception)
			{
				Debug.LogException(exception);
			}
			return ShowMessage(message);
		}

		private Guid ShowMessage(MessageData message)
		{
			message.Id = Guid.NewGuid();
			_messageQueue.Enqueue(message);
			StartEnqueuedMessage();
			return message.Id;
		}

		public void MessageValidation()
		{
			UIMessage.MessageValidated?.Invoke();
			_currentlyPlaying.GetValueOrDefault().EndEvent?.Invoke();
			_time.Unlock();
			_currentlyPlaying = null;
			StartEnqueuedMessage();
			if (!_currentlyPlaying.HasValue)
			{
				_controller.QuickHide();
			}
		}

		private void StartEnqueuedMessage()
		{
			if (_time.Locked || !_messageQueue.TryDequeue(out var result))
			{
				return;
			}
			_currentlyPlaying = result;
			_displayToggle.Swap(result.DisplayMode);
			_time.Lock();
			_image.overrideSprite = result.Icon ?? _defaultSprite;
			try
			{
				_name.StringReference = result.Title;
				_description.StringReference = result.Description;
				_subtitleObject.SetActive(result.Subtitle != null);
				if (result.Subtitle != null)
				{
					_subtitle.StringReference = result.Subtitle;
				}
			}
			catch (Exception exception)
			{
				Debug.LogException(exception);
			}
			UIMessage.MessageShowing?.Invoke();
			_controller.QuickShow();
		}

		[Button(null, EButtonEnableMode.Playmode)]
		private void PlayDebugMessage()
		{
			ShowMessage(_debugMessage);
		}
	}
}
