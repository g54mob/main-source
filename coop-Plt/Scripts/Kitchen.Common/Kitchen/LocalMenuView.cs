using System;
using System.Collections.Generic;
using Controllers;
using Kitchen.Modules;
using UnityEngine;

namespace Kitchen
{
	public abstract class LocalMenuView<T> : MonoBehaviour, IInputConsumer
	{
		protected Dictionary<Type, Menu<T>> Menus = new Dictionary<Type, Menu<T>>();

		public GameObject Container;

		public Transform ButtonContainer;

		protected int ActivePlayer;

		protected PanelElement Panel;

		protected ModuleList ModuleList = new ModuleList();

		protected bool IsDismissed;

		protected InputLock.Lock GlobalLock;

		protected InputLock.Lock Lock;

		protected Stack<Type> ActiveMenuStack = new Stack<Type>();

		protected virtual bool LowPriorityInputConsumer => false;

		protected bool HasPlayer => ActivePlayer != 0;

		public void Redraw()
		{
			if (ActiveMenuStack != null && ActiveMenuStack.Count != 0)
			{
				Type type = ActiveMenuStack.Peek();
				if (!(this == null) && !(type == null) && Menus.TryGetValue(type, out var value) && value != null)
				{
					value.TriggerRedraw();
					base.transform.localPosition = -value.ModuleList.BoundingBox.center;
					SetPanelTarget(value.RequiresBackingPanel ? ModuleList : null);
				}
			}
		}

		protected virtual void CreateForPlayer(int player)
		{
			if (InputSourceIdentifier.DefaultInputSource == null)
			{
				return;
			}
			if (Panel == null)
			{
				Panel = ModuleDirectory.Add<PanelElement>(ButtonContainer);
			}
			ActivePlayer = player;
			IsDismissed = false;
			foreach (Type item in ActiveMenuStack)
			{
				if (Menus.TryGetValue(item, out var value))
				{
					value.TearDown();
				}
			}
			Menus.Clear();
			ActiveMenuStack.Clear();
			SetupMenus();
			foreach (KeyValuePair<Type, Menu<T>> menu in Menus)
			{
				menu.Value.OnRequestAction += delegate(object _, T action)
				{
					PerformAction(action);
				};
				menu.Value.OnPreviousMenu += delegate
				{
					GoBack();
				};
				menu.Value.OnRequestMenu += delegate(object _, (Type, bool) action)
				{
					SetMenu(action.Item1, skip_stack: false, action.Item2);
				};
				menu.Value.OnRequestSkipStackMenu += delegate(object _, (Type, bool) action)
				{
					SetMenu(action.Item1, skip_stack: true, action.Item2);
				};
				menu.Value.OnGoBackToRoot += delegate
				{
					GoBackToRoot();
				};
				menu.Value.OnErrorDisplay += delegate(object _, string message)
				{
					ShowErrorMenu(message);
				};
			}
			Container.SetActive(value: true);
			InputSourceIdentifier.DefaultInputSource.MakeRequest(player, GameStateRequest.InLocalMenu);
			GlobalLock = InputSourceIdentifier.DefaultInputSource.SetLock(PlayerLockState.PauseAndLockMenu);
		}

		protected abstract void SetupMenus();

		protected virtual void AddMenu(Type type, Menu<T> instance)
		{
			Menus.Add(type, instance);
			instance.CreateSubmenus(ref Menus);
		}

		public virtual void Hide()
		{
			if (IsDismissed)
			{
				return;
			}
			IsDismissed = true;
			foreach (Type item in ActiveMenuStack)
			{
				if (Menus.TryGetValue(item, out var value))
				{
					value.TearDown();
				}
			}
			base.gameObject.SetActive(value: false);
			if (InputSourceIdentifier.DefaultInputSource != null)
			{
				InputSourceIdentifier.DefaultInputSource.ReleaseLock(GlobalLock);
			}
			ActivePlayer = 0;
			UnityEngine.Object.Destroy(base.gameObject);
		}

		public virtual void Start()
		{
			LocalInputSourceConsumers.Register(this, LowPriorityInputConsumer);
		}

		public virtual void OnDestroy()
		{
			LocalInputSourceConsumers.Remove(this);
		}

		protected virtual void Update()
		{
			if (ActiveMenuStack != null && ActiveMenuStack.Count != 0)
			{
				Type type = ActiveMenuStack.Peek();
				if (!(this == null) && !(type == null) && Menus.TryGetValue(type, out var value))
				{
					value?.Update();
				}
			}
		}

		public abstract InputConsumerState TakeInput(int player_id, InputState state);

		protected virtual void SetMenu(Type menu_type, bool skip_stack = false, bool remove_current_from_stack = false)
		{
			if (menu_type == null || !Menus.TryGetValue(menu_type, out var value))
			{
				PerformAction();
				return;
			}
			if (remove_current_from_stack && ActiveMenuStack.Pop() != null && Menus.TryGetValue(menu_type, out var value2))
			{
				value2.TearDown();
			}
			Clear();
			value.Setup(ActivePlayer);
			value.PreviousMenuRequested = false;
			if (!skip_stack)
			{
				ActiveMenuStack.Push(menu_type);
			}
			base.transform.localPosition = -value.ModuleList.BoundingBox.center;
			SetPanelTarget(value.RequiresBackingPanel ? ModuleList : null);
		}

		protected virtual void ShowErrorMenu(string message)
		{
			if (!Menus.TryGetValue(typeof(ErrorMenu<MenuAction>), out var value) || !(value is ErrorMenu<MenuAction> errorMenu))
			{
				GoBackToRoot();
				return;
			}
			GoBackToRoot(activate_root: false);
			errorMenu.SetError(message);
			SetMenu(errorMenu.GetType());
		}

		protected virtual void GoBackToRoot(bool activate_root = true)
		{
			if (ActiveMenuStack.Count <= 1)
			{
				Hide();
				return;
			}
			while (ActiveMenuStack.Count > 1)
			{
				Type key = ActiveMenuStack.Pop();
				if (Menus.TryGetValue(key, out var value))
				{
					value.TearDown();
				}
			}
			if (activate_root)
			{
				SetMenu(ActiveMenuStack.Peek(), skip_stack: true);
			}
		}

		protected virtual void GoBack()
		{
			if (ActiveMenuStack.Count <= 1)
			{
				Hide();
				return;
			}
			Type key = ActiveMenuStack.Pop();
			if (Menus.TryGetValue(key, out var value))
			{
				value.TearDown();
			}
			SetMenu(ActiveMenuStack.Peek(), skip_stack: true);
		}

		protected virtual void SetPanelTarget(IModule target)
		{
			Panel.SetTarget(target);
		}

		protected void Clear()
		{
			ModuleList?.Clear();
		}

		protected virtual void SetPlayer(int player)
		{
			ActivePlayer = player;
			Color colour = (Players.Main.Has(player) ? Players.Main.Get(player).Profile.Colour : Color.grey);
			Panel.SetColour(colour);
		}

		protected abstract void PerformAction(T action = default(T));
	}
}
