using System;
using System.Collections;
using System.Collections.Generic;
using Restory.Infrastructure.StateMachine;
using UnityEngine;
using Zenject;

namespace Restory.Gameplay.TimeSystems
{
	public class TickSystem : MonoBehaviour
	{
		private GlobalStateObserver globalStateObserver;

		private readonly List<ITickable> tickSubscribers = new List<ITickable>();

		private readonly List<ITickable> subscribersToAdd = new List<ITickable>();

		private readonly List<ITickable> subscribersToRemove = new List<ITickable>();

		private Coroutine doCallbackAfterEndOfFrameCoroutine;

		private float totalTime;

		private bool isActive;

		public float TotalTime => totalTime;

		public bool IsActive
		{
			get
			{
				return isActive;
			}
			set
			{
				isActive = value;
				this.OnActiveStatusChanged?.Invoke();
			}
		}

		public event Action OnActiveStatusChanged;

		[Inject]
		private void Construct(GlobalStateObserver globalStateObserver)
		{
			this.globalStateObserver = globalStateObserver;
			if (base.isActiveAndEnabled)
			{
				Init();
			}
		}

		public void OnEnable()
		{
			if (globalStateObserver != null)
			{
				Init();
			}
			RequestSubscribersRefreshCoroutine();
		}

		public void OnDisable()
		{
			globalStateObserver?.RemoveSubscriber(this);
			if (doCallbackAfterEndOfFrameCoroutine != null)
			{
				StopCoroutine(doCallbackAfterEndOfFrameCoroutine);
				doCallbackAfterEndOfFrameCoroutine = null;
			}
		}

		private void Init()
		{
			globalStateObserver.AddSubscriber(this, OnGlobalStateChanged);
			OnGlobalStateChanged();
		}

		public void AddSubscriber(ITickable subscriber)
		{
			if (subscriber == null || tickSubscribers.Contains(subscriber) || subscribersToAdd.Contains(subscriber))
			{
				return;
			}
			if (subscribersToRemove.Contains(subscriber))
			{
				subscribersToRemove.Remove(subscriber);
				return;
			}
			subscribersToAdd.Add(subscriber);
			if (base.isActiveAndEnabled)
			{
				RequestSubscribersRefreshCoroutine();
			}
		}

		public void RemoveSubscriber(ITickable subscriber)
		{
			if (subscriber == null)
			{
				return;
			}
			if (subscribersToAdd.Contains(subscriber))
			{
				subscribersToAdd.Remove(subscriber);
				return;
			}
			subscribersToRemove.Add(subscriber);
			if (base.isActiveAndEnabled)
			{
				RequestSubscribersRefreshCoroutine();
			}
		}

		private void RequestSubscribersRefreshCoroutine()
		{
			if (doCallbackAfterEndOfFrameCoroutine == null)
			{
				doCallbackAfterEndOfFrameCoroutine = StartCoroutine(DoCallbackAfterEndOfFrameCoroutine(RefreshSubscribers));
			}
		}

		private IEnumerator DoCallbackAfterEndOfFrameCoroutine(Action callback)
		{
			yield return new WaitForEndOfFrame();
			callback?.Invoke();
			doCallbackAfterEndOfFrameCoroutine = null;
		}

		private void RefreshSubscribers()
		{
			RemoveSubscribers();
			AddSubscribers();
		}

		private void AddSubscribers()
		{
			tickSubscribers.AddRange(subscribersToAdd);
			subscribersToAdd.Clear();
		}

		private void RemoveSubscribers()
		{
			foreach (ITickable item in subscribersToRemove)
			{
				for (int num = tickSubscribers.Count - 1; num >= 0; num--)
				{
					if (tickSubscribers[num] == item)
					{
						tickSubscribers.RemoveAt(num);
						break;
					}
				}
			}
			subscribersToRemove.Clear();
		}

		private void Update()
		{
			if (!isActive)
			{
				return;
			}
			totalTime += Time.deltaTime;
			foreach (ITickable tickSubscriber in tickSubscribers)
			{
				tickSubscriber?.Tick(Time.deltaTime);
			}
		}

		private void OnGlobalStateChanged()
		{
			IsActive = globalStateObserver.IsInGameLoop;
		}
	}
}
