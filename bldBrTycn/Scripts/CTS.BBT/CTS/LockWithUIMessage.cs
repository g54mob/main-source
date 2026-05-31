using CTS.Core;
using UnityEngine;

namespace CTS
{
	public class LockWithUIMessage : CTSBehaviour
	{
		[SerializeField]
		private SoftReference<ILockable> _lockable;

		private readonly LockToggle _lock = new LockToggle();

		private void Start()
		{
			_lock.Add(_lockable.Value);
			if (CTSSingleton<UIMessage>.InstanceExists() && CTSSingleton<UIMessage>.Instance.IsPlayingSomething())
			{
				OnMessageShowing();
			}
			UIMessage.MessageShowing += OnMessageShowing;
			UIMessage.MessageValidated += OnMessageValidated;
			CTSSingleton<UIMessage>.Destroyed += OnMessageSingletonDestroyed;
		}

		private void OnDestroy()
		{
			UIMessage.MessageShowing -= OnMessageShowing;
			UIMessage.MessageValidated -= OnMessageValidated;
			CTSSingleton<UIMessage>.Destroyed -= OnMessageSingletonDestroyed;
		}

		private void OnMessageShowing()
		{
			_lock.Lock();
		}

		private void OnMessageValidated()
		{
			_lock.Unlock();
		}

		private void OnMessageSingletonDestroyed(UIMessage obj)
		{
			OnMessageValidated();
		}
	}
}
