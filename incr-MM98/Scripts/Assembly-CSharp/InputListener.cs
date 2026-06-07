using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

[RequireComponent(typeof(PlayerInput))]
public class InputListener : MonoSingleton<InputListener>
{
	public interface IHandler
	{
		int Priority { get; }

		void Handle(InputEvent ctx);
	}

	private static readonly InputEvent ctx = new InputEvent();

	private readonly List<IHandler> _handlers = new List<IHandler>();

	public static bool Alt;

	public static bool AltF4;

	public void Register(IHandler handler)
	{
		_handlers.Add(handler);
		_handlers.Sort((IHandler a, IHandler b) => a.Priority.CompareTo(b.Priority));
	}

	public void Unregister(IHandler handler)
	{
		_handlers.Remove(handler);
	}

	private void OnSubmit()
	{
		Trigger(InputEvent.Key.Submit);
	}

	private void OnCancel()
	{
		Trigger(InputEvent.Key.Cancel);
	}

	private void OnPause()
	{
		Trigger(InputEvent.Key.Pause);
	}

	private void OnDashboard()
	{
		Trigger(InputEvent.Key.DashboardView);
	}

	private void OnUpgrades()
	{
		Trigger(InputEvent.Key.UpgradesView);
	}

	private void OnDebugger()
	{
		Trigger(InputEvent.Key.DebuggerView);
	}

	private void OnWorld()
	{
		Trigger(InputEvent.Key.WorldView);
	}

	private void OnAuction()
	{
		Trigger(InputEvent.Key.AuctionView);
	}

	private void OnSequel()
	{
		Trigger(InputEvent.Key.SequelView);
	}

	private void OnResearch()
	{
		Trigger(InputEvent.Key.ResearchView);
	}

	private void OnAlt(InputValue value)
	{
		Alt = value.isPressed;
	}

	private void OnAltF4()
	{
		AltF4 = true;
	}

	private void Trigger(InputEvent.Key key)
	{
		if ((bool)EventSystem.current && (bool)EventSystem.current.currentSelectedGameObject && (bool)EventSystem.current.currentSelectedGameObject.GetComponent<TMP_InputField>())
		{
			return;
		}
		ctx.Input = key;
		ctx.Consumed = false;
		foreach (IHandler handler in _handlers)
		{
			handler.Handle(ctx);
			if (ctx.Consumed)
			{
				break;
			}
		}
	}
}
