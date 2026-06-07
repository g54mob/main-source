using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace ModApi.Common.Events
{
	public class UnityEventDispatcher : MonoBehaviour
	{
		public enum EventType
		{
			Update = 0,
			FixedUpdate = 1,
			LateUpdate = 2
		}

		private class WaitWhile : CustomYieldInstruction
		{
			private Func<bool> _predicate;

			public override bool keepWaiting => _predicate();

			public WaitWhile(Func<bool> predicate)
			{
				_predicate = predicate;
			}
		}

		private static UnityEventDispatcher _instance;

		private List<Action> _fixedUpdateActions = new List<Action>();

		private List<Action> _lateUpdateActions = new List<Action>();

		private List<Action> _updateActions = new List<Action>();

		public static UnityEventDispatcher Instance
		{
			get
			{
				if (_instance == null)
				{
					_instance = new GameObject("UnityEventDispatcher").AddComponent<UnityEventDispatcher>();
				}
				return _instance;
			}
		}

		public Coroutine ExecuteCustomYield(Func<bool> predicate, Action action)
		{
			return StartCoroutine(ExecuteCustomYieldCoroutine(predicate, action));
		}

		public Coroutine ExecuteWaitForSeconds(Action action, float seconds)
		{
			return StartCoroutine(ExecuteWaitForSecondsCoroutine(action, seconds));
		}

		public Coroutine ExecuteYield<T>(Action action) where T : YieldInstruction, new()
		{
			return StartCoroutine(ExecuteYieldCoroutine<T>(action));
		}

		public Coroutine ExecuteYield<T>(Action<int?> action, int? executeCount) where T : YieldInstruction, new()
		{
			if (!executeCount.HasValue || executeCount > 0)
			{
				return StartCoroutine(ExecuteYieldCoroutine<T>(delegate
				{
					int? num = ((!executeCount.HasValue) ? ((int?)null) : (executeCount - 1));
					action(num);
					ExecuteYield<T>(action, num);
				}));
			}
			return null;
		}

		public Coroutine ExecuteYield<T>(Func<bool> action) where T : YieldInstruction, new()
		{
			return StartCoroutine(ExecuteYieldCoroutine<T>(delegate
			{
				if (action())
				{
					ExecuteYield<T>(action);
				}
			}));
		}

		public bool IsActionRegistered(Action action, EventType type)
		{
			return GetActionList(type).Contains(action);
		}

		public void Register(Action action, EventType type)
		{
			RegisterAction(action, GetActionList(type));
		}

		public void UnRegister(Action action, EventType type, bool suppressActionDoesntExistWarning)
		{
			UnRegisterAction(action, GetActionList(type), suppressActionDoesntExistWarning);
		}

		public void UnRegisterAll()
		{
			UnRegisterAll(EventType.Update);
			UnRegisterAll(EventType.FixedUpdate);
			UnRegisterAll(EventType.LateUpdate);
		}

		public void UnRegisterAll(EventType type)
		{
			List<Action> actionList = GetActionList(type);
			foreach (Action item in actionList.ToList())
			{
				UnRegisterAction(item, actionList, suppressActionDoesntExistWarning: true);
			}
		}

		protected virtual void FixedUpdate()
		{
			PerformUnityEventActions(_fixedUpdateActions);
		}

		protected virtual void LateUpdate()
		{
			PerformUnityEventActions(_lateUpdateActions);
		}

		protected virtual void Update()
		{
			PerformUnityEventActions(_updateActions);
		}

		private static void RegisterAction(Action newAction, List<Action> actionList)
		{
			actionList.Add(newAction);
		}

		private static void UnRegisterAction(Action action, List<Action> actionlist, bool suppressActionDoesntExistWarning)
		{
			bool flag = actionlist.Remove(action);
			if (!suppressActionDoesntExistWarning && flag)
			{
				Debug.LogWarning("Action didn't exist in the list");
			}
		}

		private IEnumerator ExecuteCustomYieldCoroutine(Func<bool> predicate, Action action)
		{
			yield return new WaitWhile(predicate);
			action();
		}

		private IEnumerator ExecuteWaitForSecondsCoroutine(Action action, float seconds)
		{
			yield return new WaitForSeconds(seconds);
			action();
		}

		private IEnumerator ExecuteYieldCoroutine<T>(Action action) where T : YieldInstruction, new()
		{
			yield return new T();
			action();
		}

		private List<Action> GetActionList(EventType type)
		{
			switch (type)
			{
			case EventType.Update:
				return _updateActions;
			case EventType.FixedUpdate:
				return _fixedUpdateActions;
			case EventType.LateUpdate:
				return _lateUpdateActions;
			default:
				Debug.LogError($"Unsupported action type: {type}");
				return GetActionList(EventType.Update);
			}
		}

		private void PerformUnityEventActions(List<Action> actionList)
		{
			List<Action> list = null;
			foreach (Action action in actionList)
			{
				if (action != null)
				{
					action();
					continue;
				}
				if (list == null)
				{
					list = new List<Action>();
				}
				list.Add(action);
			}
			if (list == null)
			{
				return;
			}
			foreach (Action item in list)
			{
				actionList.Remove(item);
			}
		}

		private void Remove(ref Action[] list, int index)
		{
			List<Action> list2 = list.ToList();
			list2.RemoveAt(index);
			list = list2.ToArray();
		}
	}
}
