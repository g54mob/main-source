using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using JetBrains.Annotations;
using MessagePipe;
using R3;
using UnityEngine;

public readonly struct EventHubBuilder
{
	private readonly bool _persistent;

	private readonly DisposableBagBuilder _bag;

	public EventHubBuilder(bool persistent, DisposableBagBuilder bag)
	{
		_persistent = persistent;
		_bag = bag;
	}

	[HandlesResourceDisposal]
	public void Build(out IDisposable disposable)
	{
		disposable = _bag.Build();
	}

	[HandlesResourceDisposal]
	public void Build(ref DisposableBagBuilder bag)
	{
		bag.Add(_bag.Build());
	}

	[HandlesResourceDisposal]
	public void Build(Component component)
	{
		_bag.Build().AddTo(component);
	}

	[HandlesResourceDisposal]
	public void Build(GameObject go)
	{
		_bag.Build().AddTo(go);
	}

	[HandlesResourceDisposal]
	[MustDisposeResource]
	public EventHubBuilder Subscribe<TMessage>(Action<TMessage> handler, params MessageHandlerFilter<TMessage>[] filters)
	{
		if (_persistent)
		{
			PersistentMessagePipe.GetSubscriber<TMessage>().Subscribe(handler, filters).AddTo(_bag);
		}
		else
		{
			GlobalMessagePipe.GetSubscriber<TMessage>().Subscribe(handler, filters).AddTo(_bag);
		}
		return this;
	}

	[HandlesResourceDisposal]
	[MustDisposeResource]
	public EventHubBuilder Subscribe<TMessage>(Action<TMessage> handler, Func<TMessage, bool> predicate, params MessageHandlerFilter<TMessage>[] filters)
	{
		if (_persistent)
		{
			PersistentMessagePipe.GetSubscriber<TMessage>().Subscribe(handler, predicate, filters).AddTo(_bag);
		}
		else
		{
			GlobalMessagePipe.GetSubscriber<TMessage>().Subscribe(handler, predicate, filters).AddTo(_bag);
		}
		return this;
	}

	[HandlesResourceDisposal]
	[MustDisposeResource]
	public EventHubBuilder SubscribeAsync<TMessage>(Func<TMessage, CancellationToken, UniTask> handler, params AsyncMessageHandlerFilter<TMessage>[] filters)
	{
		if (_persistent)
		{
			PersistentMessagePipe.GetAsyncSubscriber<TMessage>().Subscribe(handler, filters).AddTo(_bag);
		}
		else
		{
			GlobalMessagePipe.GetAsyncSubscriber<TMessage>().Subscribe(handler, filters).AddTo(_bag);
		}
		return this;
	}

	[HandlesResourceDisposal]
	[MustDisposeResource]
	public EventHubBuilder SubscribeAsync<TMessage>(Func<TMessage, CancellationToken, UniTask> handler, Func<TMessage, bool> predicate, params AsyncMessageHandlerFilter<TMessage>[] filters)
	{
		if (_persistent)
		{
			PersistentMessagePipe.GetAsyncSubscriber<TMessage>().Subscribe(handler, predicate, filters).AddTo(_bag);
		}
		else
		{
			GlobalMessagePipe.GetAsyncSubscriber<TMessage>().Subscribe(handler, predicate, filters).AddTo(_bag);
		}
		return this;
	}

	[HandlesResourceDisposal]
	[MustDisposeResource]
	public EventHubBuilder SubscribeBuffered<TMessage>(Action<TMessage> handler, params MessageHandlerFilter<TMessage>[] filters)
	{
		if (_persistent)
		{
			PersistentMessagePipe.GetBufferedSubscriber<TMessage>().Subscribe(handler, filters).AddTo(_bag);
		}
		else
		{
			GlobalMessagePipe.GetBufferedSubscriber<TMessage>().Subscribe(handler, filters).AddTo(_bag);
		}
		return this;
	}

	[HandlesResourceDisposal]
	[MustDisposeResource]
	public EventHubBuilder SubscribeBuffered<TMessage>(Action<TMessage> handler, Func<TMessage, bool> predicate, params MessageHandlerFilter<TMessage>[] filters)
	{
		if (_persistent)
		{
			PersistentMessagePipe.GetBufferedSubscriber<TMessage>().Subscribe(handler, predicate, filters).AddTo(_bag);
		}
		else
		{
			GlobalMessagePipe.GetBufferedSubscriber<TMessage>().Subscribe(handler, predicate, filters).AddTo(_bag);
		}
		return this;
	}

	[HandlesResourceDisposal]
	[MustDisposeResource]
	public EventHubBuilder Subscribe<TKey, TMessage>(TKey key, Action<TMessage> handler, params MessageHandlerFilter<TMessage>[] filters)
	{
		if (_persistent)
		{
			PersistentMessagePipe.GetSubscriber<TKey, TMessage>().Subscribe(key, handler, filters).AddTo(_bag);
		}
		else
		{
			GlobalMessagePipe.GetSubscriber<TMessage>().Subscribe(handler, filters).AddTo(_bag);
		}
		return this;
	}

	[HandlesResourceDisposal]
	[MustDisposeResource]
	public EventHubBuilder Subscribe<TKey, TMessage>(TKey key, Action<TMessage> handler, Func<TMessage, bool> predicate, params MessageHandlerFilter<TMessage>[] filters)
	{
		if (_persistent)
		{
			PersistentMessagePipe.GetSubscriber<TKey, TMessage>().Subscribe(key, handler, predicate, filters).AddTo(_bag);
		}
		else
		{
			GlobalMessagePipe.GetSubscriber<TMessage>().Subscribe(handler, predicate, filters).AddTo(_bag);
		}
		return this;
	}

	[HandlesResourceDisposal]
	[MustDisposeResource]
	public EventHubBuilder SubscribeAsync<TKey, TMessage>(TKey key, Func<TMessage, CancellationToken, UniTask> handler, params AsyncMessageHandlerFilter<TMessage>[] filters)
	{
		if (_persistent)
		{
			PersistentMessagePipe.GetAsyncSubscriber<TKey, TMessage>().Subscribe(key, handler, filters).AddTo(_bag);
		}
		else
		{
			GlobalMessagePipe.GetAsyncSubscriber<TMessage>().Subscribe(handler, filters).AddTo(_bag);
		}
		return this;
	}

	[HandlesResourceDisposal]
	[MustDisposeResource]
	public EventHubBuilder SubscribeAsync<TKey, TMessage>(TKey key, Func<TMessage, CancellationToken, UniTask> handler, Func<TMessage, bool> predicate, params AsyncMessageHandlerFilter<TMessage>[] filters)
	{
		if (_persistent)
		{
			PersistentMessagePipe.GetAsyncSubscriber<TKey, TMessage>().Subscribe(key, handler, predicate, filters).AddTo(_bag);
		}
		else
		{
			GlobalMessagePipe.GetAsyncSubscriber<TMessage>().Subscribe(handler, predicate, filters).AddTo(_bag);
		}
		return this;
	}
}
