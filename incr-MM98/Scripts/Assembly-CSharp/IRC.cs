using System;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using MessagePipe;
using ObservableCollections;
using R3;
using UnityEngine;
using UnityEngine.UI;

public class IRC : MonoBehaviour
{
	private const float RefreshThreshold = 0.05f;

	[SerializeField]
	private RectTransform content;

	[SerializeField]
	private ScrollRect scroll;

	[SerializeField]
	private IRCLine linePrefab;

	private readonly List<IRCTab> _tabs = new List<IRCTab>();

	private readonly List<IRCMessage> _renderBuffer = new List<IRCMessage>(90);

	private readonly RingBuffer<IRCLine> _pool = new RingBuffer<IRCLine>(30);

	private IRCTab _activeTab;

	private IDisposable _disposable;

	private bool _pendingSnapToBottom;

	private bool _frozen;

	private bool IsNearBottom => scroll.verticalNormalizedPosition <= 0.05f;

	private void Awake()
	{
		Initializer.Bag(out var bag).Each(GetComponentsInChildren<IRCTab>(), _tabs.Add).Each(_tabs, delegate(IRCTab tab)
		{
			tab.ChangeChannel += ChangeChannel;
		})
			.Context(scroll)
			.OnValueChanged(HandleScrolling)
			.Invoke(InitializePool)
			.Invoke(delegate
			{
				ChangeChannel(_tabs[0]);
			})
			.SceneEvents(bag)
			.Subscribe(delegate
			{
				RefreshMessages();
			}, Array.Empty<MessageHandlerFilter<Prestiged>>())
			.Build(out _disposable);
		Database.State.IRC.NewMessage.Subscribe(NewMessage).AddTo(this);
		(from channel in Database.State.IRC.ChannelCleared.ThrottleLastFrame(1)
			where _activeTab.Channels.HasFlag(channel)
			select channel).Subscribe(delegate
		{
			RefreshMessages();
		}).AddTo(this);
	}

	private void OnDestroy()
	{
		_disposable?.Dispose();
	}

	public void ToggleTab(IRCChannel channel, bool state)
	{
		foreach (IRCTab tab in _tabs)
		{
			if (tab.Channels.IsExactly(channel))
			{
				tab.gameObject.SetActive(state);
				if (_activeTab == tab)
				{
					ChangeChannel(_tabs[0]);
				}
			}
		}
	}

	private void InitializePool()
	{
		for (int i = 0; i < 30; i++)
		{
			IRCLine iRCLine = UnityEngine.Object.Instantiate(linePrefab, content);
			iRCLine.gameObject.SetActive(value: false);
			_pool.AddLast(iRCLine);
		}
	}

	private void ChangeChannel(IRCTab tab)
	{
		if (!(_activeTab == tab))
		{
			_activeTab?.SetInactive();
			_activeTab = tab;
			_activeTab.SetActive();
			RefreshMessages();
			RequestSnapToBottom();
		}
	}

	private void NewMessage(IRCMessage message)
	{
		if ((_activeTab.Channels & message.Channel) != IRCChannel.None && IsNearBottom)
		{
			AppendMessage(message);
			RequestSnapToBottom();
		}
	}

	private void AppendMessage(IRCMessage message)
	{
		IRCLine iRCLine = _pool.RemoveFirst();
		iRCLine.gameObject.SetActive(value: true);
		iRCLine.transform.SetAsLastSibling();
		iRCLine.SetContent(message);
		LayoutRebuilder.ForceRebuildLayoutImmediate(content);
		_pool.AddLast(iRCLine);
	}

	private void RefreshMessages()
	{
		_renderBuffer.Clear();
		if (_activeTab.Channels.HasFlag(IRCChannel.Default))
		{
			_renderBuffer.AddRange(Database.State.IRC.General);
		}
		if (_activeTab.Channels.HasFlag(IRCChannel.System))
		{
			_renderBuffer.AddRange(Database.State.IRC.System);
		}
		if (_activeTab.Channels.HasFlag(IRCChannel.Twitch))
		{
			_renderBuffer.AddRange(Database.State.IRC.Twitch);
		}
		_renderBuffer.Sort((IRCMessage a, IRCMessage b) => a.Sequence.CompareTo(b.Sequence));
		int num = Mathf.Max(0, _renderBuffer.Count - 30);
		int num2 = _renderBuffer.Count - num;
		DisableAllLines();
		for (int num3 = 0; num3 < 30; num3++)
		{
			IRCLine iRCLine = _pool.RemoveFirst();
			_pool.AddLast(iRCLine);
			if (num3 < num2)
			{
				iRCLine.gameObject.SetActive(value: true);
				iRCLine.transform.SetSiblingIndex(num3);
				iRCLine.SetContent(_renderBuffer[num + num3]);
			}
		}
		LayoutRebuilder.ForceRebuildLayoutImmediate(content);
		RequestSnapToBottom();
	}

	private IRCLine GetNextHiddenLine()
	{
		for (int i = 0; i < 30; i++)
		{
			IRCLine iRCLine = _pool.RemoveFirst();
			_pool.AddLast(iRCLine);
			if (!iRCLine.gameObject.activeSelf)
			{
				return iRCLine;
			}
		}
		return _pool.RemoveFirst();
	}

	private void DisableAllLines()
	{
		for (int i = 0; i < 30; i++)
		{
			IRCLine iRCLine = _pool.RemoveFirst();
			_pool.AddLast(iRCLine);
			iRCLine.gameObject.SetActive(value: false);
			iRCLine.transform.SetSiblingIndex(i);
		}
	}

	private void HandleScrolling(Vector2 position)
	{
		_frozen = !IsNearBottom;
		if (IsNearBottom && _frozen)
		{
			_frozen = false;
			RefreshMessages();
		}
	}

	private void RequestSnapToBottom()
	{
		if (!_pendingSnapToBottom)
		{
			_pendingSnapToBottom = true;
			SnapToBottomDeferred().Forget();
		}
	}

	private async UniTaskVoid SnapToBottomDeferred()
	{
		await UniTask.Yield(PlayerLoopTiming.PostLateUpdate);
		_pendingSnapToBottom = false;
		scroll.verticalNormalizedPosition = 0f;
	}
}
