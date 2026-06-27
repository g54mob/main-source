using System;
using System.Collections.Generic;
using Rewired;
using UnityEngine;
using UnityEngine.Events;
using Zenject;

namespace Restory.Gameplay.PlayerInput
{
	public abstract class PlayerActionMapperBase : MonoBehaviour, IInitializable, IDisposable
	{
		[Serializable]
		private class ActionMap
		{
			public enum ButtonInteractionType
			{
				Press = 0,
				Hold = 1,
				Release = 2
			}

			[Header("Action (please select only one of them):")]
			[RewiredActionsDropdown]
			public int playerActionDefault = -1;

			[RewiredActionsDropdown]
			public int playerActionInteractions = -1;

			[RewiredActionsDropdown]
			public int playerActionSystem = -1;

			[RewiredActionsDropdown]
			public int playerActionUI = -1;

			[Header("Type of button interaction")]
			public ButtonInteractionType buttonInteractionType;

			[Header("Will trigger event:")]
			public UnityEvent unityEvent;

			public int GetPlayerAction()
			{
				if (playerActionDefault >= 0)
				{
					return playerActionDefault;
				}
				if (playerActionInteractions >= 0)
				{
					return playerActionInteractions;
				}
				if (playerActionSystem >= 0)
				{
					return playerActionSystem;
				}
				if (playerActionUI >= 0)
				{
					return playerActionUI;
				}
				return -1;
			}

			public void Dispose()
			{
				unityEvent.RemoveAllListeners();
			}
		}

		[SerializeField]
		private List<ActionMap> actionMaps = new List<ActionMap>
		{
			new ActionMap()
		};

		private readonly Dictionary<ActionMap, Action<InputActionEventData>> subscriptions = new Dictionary<ActionMap, Action<InputActionEventData>>();

		private IPlayerInput player;

		[Inject]
		private void Construct(IPlayerInput player, DisposableManager disposableManager)
		{
			this.player = player;
			if (!disposableManager.Contains(this))
			{
				disposableManager.Add(this);
			}
		}

		public void Initialize()
		{
			SubscribeAll();
		}

		public void Dispose()
		{
			UnsubscribeAll();
			CleanActionMaps();
		}

		private void CleanActionMaps()
		{
			foreach (ActionMap actionMap in actionMaps)
			{
				actionMap.Dispose();
			}
			actionMaps.Clear();
		}

		private void SubscribeAll()
		{
			UnsubscribeAll();
			foreach (ActionMap actionMap in actionMaps)
			{
				Action<InputActionEventData> action = ActionDependingOnButtonInteractionType(actionMap);
				subscriptions.Add(actionMap, action);
				int playerAction = actionMap.GetPlayerAction();
				if (playerAction >= 0)
				{
					player.AddInputEventDelegate(action, playerAction);
				}
			}
		}

		protected void UnsubscribeAll()
		{
			foreach (ActionMap key in subscriptions.Keys)
			{
				player.RemoveInputEventDelegate(subscriptions[key], key.GetPlayerAction());
			}
			subscriptions.Clear();
		}

		private Action<InputActionEventData> ActionDependingOnButtonInteractionType(ActionMap map)
		{
			return map.buttonInteractionType switch
			{
				ActionMap.ButtonInteractionType.Press => delegate(InputActionEventData eventData)
				{
					if (eventData.GetButtonDown())
					{
						map.unityEvent.Invoke();
					}
				}, 
				ActionMap.ButtonInteractionType.Hold => delegate(InputActionEventData eventData)
				{
					if (eventData.GetButton())
					{
						map.unityEvent.Invoke();
					}
				}, 
				ActionMap.ButtonInteractionType.Release => delegate(InputActionEventData eventData)
				{
					if (eventData.GetButtonUp())
					{
						map.unityEvent.Invoke();
					}
				}, 
				_ => throw new ArgumentOutOfRangeException(), 
			};
		}
	}
}
