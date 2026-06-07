using System;
using UnityEngine;

namespace Logic.Threading.Events
{
	[CreateAssetMenu(menuName = "Events/EmptyMainThreadEvent", fileName = "EmptyMainThreadEvent", order = 0)]
	public class MainThreadEventSO : ScriptableObject
	{
		private readonly MainThreadEvent _mainThreadEvent = new MainThreadEvent();

		public void RegisterMainThread(Action listener)
		{
			_mainThreadEvent.RegisterMainThread(listener);
		}

		public void UnRegisterMainThread(Action listener)
		{
			_mainThreadEvent.UnRegisterMainThread(listener);
		}

		public void RegisterInline(Action listener)
		{
			_mainThreadEvent.RegisterInline(listener);
		}

		public void UnRegisterInline(Action listener)
		{
			_mainThreadEvent.UnRegisterInline(listener);
		}

		public void Fire()
		{
			_mainThreadEvent.Fire();
		}
	}
	public class MainThreadEventSO<T> : ScriptableObject
	{
		private readonly MainThreadEvent<T> _mainThreadEvent = new MainThreadEvent<T>();

		public void RegisterMainThread(Action<T> listener)
		{
			_mainThreadEvent.RegisterMainThread(listener);
		}

		public void UnRegisterMainThread(Action<T> listener)
		{
			_mainThreadEvent.UnRegisterMainThread(listener);
		}

		public void RegisterInline(Action<T> listener)
		{
			_mainThreadEvent.RegisterInline(listener);
		}

		public void UnRegisterInline(Action<T> listener)
		{
			_mainThreadEvent.UnRegisterInline(listener);
		}

		public void Fire(T data)
		{
			_mainThreadEvent.Fire(data);
		}
	}
}
