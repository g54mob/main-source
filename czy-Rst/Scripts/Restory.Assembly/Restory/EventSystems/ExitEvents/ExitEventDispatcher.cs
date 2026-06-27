using System;
using System.Collections.Generic;
using Restory.Data.Identifications;
using Restory.Gameplay.PlayerInput;
using Rewired;
using UnityEngine;
using Zenject;

namespace Restory.EventSystems.ExitEvents
{
	public class ExitEventDispatcher : MonoBehaviour, IInitializable, IDisposable
	{
		private readonly Dictionary<string, IExitEventHandler> registeredHandlers = new Dictionary<string, IExitEventHandler>();

		private IPlayerInput playerInput;

		private ExitEventSettingsProvider settingsProvider;

		private ExitEventLayers layers;

		public event Action OnNothingToExit;

		[Inject]
		private void Construct(IPlayerInput playerInput, ExitEventSettings exitEventSettings)
		{
			this.playerInput = playerInput;
			settingsProvider = new ExitEventSettingsProvider(exitEventSettings);
			layers = new ExitEventLayers();
		}

		public void Initialize()
		{
			playerInput.AddInputEventDelegate(ResolveExitButtonJustPressed, InputActionEventType.ButtonJustPressed, 24);
		}

		public void Dispose()
		{
			playerInput.RemoveInputEventDelegate(ResolveExitButtonJustPressed, InputActionEventType.ButtonJustPressed, 24);
		}

		public void Register(IExitEventHandler handler)
		{
			if (!registeredHandlers.TryAdd(handler.ID, handler))
			{
				return;
			}
			if (settingsProvider.TryGetSettings(handler.ID, out var handlerSettings))
			{
				foreach (UniqueIdentificator incompatible in handlerSettings.Incompatibles)
				{
					ExecuteExitIfRegistered(incompatible.ID);
				}
				layers.AddHandler(handler, handlerSettings.LayerOrder);
			}
			else
			{
				registeredHandlers.Remove(handler.ID);
			}
		}

		public void Unregister(IExitEventHandler handler)
		{
			if (registeredHandlers.Remove(handler.ID) && settingsProvider.TryGetSettings(handler.ID, out var handlerSettings))
			{
				layers.RemoveHandler(handler, handlerSettings.LayerOrder);
			}
		}

		private void ResolveExitButtonJustPressed(InputActionEventData eventData)
		{
			if (!base.gameObject.activeSelf)
			{
				return;
			}
			if (!layers.TryTakeLastHandler(out var lastHandler))
			{
				foreach (KeyValuePair<string, IExitEventHandler> registeredHandler in registeredHandlers)
				{
					Debug.LogError("registeredHandlers contains unexpected handler " + registeredHandler.Key);
				}
				this.OnNothingToExit?.Invoke();
				return;
			}
			if (!registeredHandlers.Remove(lastHandler.ID))
			{
				Debug.LogError("registeredHandlers not contains handler " + lastHandler.ID);
				return;
			}
			lastHandler.ExecuteExit();
			lastHandler.ConfirmExitExecution();
			if (!settingsProvider.TryGetSettings(lastHandler.ID, out var handlerSettings))
			{
				return;
			}
			foreach (UniqueIdentificator subordinate in handlerSettings.Subordinates)
			{
				ExecuteExitIfRegistered(subordinate.ID);
			}
		}

		private void ExecuteExitIfRegistered(string handlerID)
		{
			if (registeredHandlers.Remove(handlerID, out var value) && settingsProvider.TryGetSettings(value.ID, out var handlerSettings))
			{
				value.ExecuteExit();
				layers.RemoveHandler(value, handlerSettings.LayerOrder);
				value.ConfirmExitExecution();
			}
		}
	}
}
