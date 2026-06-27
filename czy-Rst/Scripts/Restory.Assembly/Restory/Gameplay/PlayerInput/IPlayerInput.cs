using System;
using System.Collections.Generic;
using Rewired;
using UnityEngine;
using Zenject;

namespace Restory.Gameplay.PlayerInput
{
	public interface IPlayerInput : IInitializable, IDisposable
	{
		int Id { get; }

		int ControllerId { get; }

		string Name { get; }

		Player.ControllerHelper Controllers { get; }

		bool Enable { get; set; }

		event Action<int> ControllerAddedEvent;

		event Action<int> ControllerRemovedEvent;

		void AddInputEventDelegate(Action<InputActionEventData> callback);

		void RemoveInputEventDelegate(Action<InputActionEventData> callback);

		void AddInputEventDelegate(Action<InputActionEventData> callback, int actionId);

		void RemoveInputEventDelegate(Action<InputActionEventData> callback, int actionId);

		void AddInputEventDelegate(Action<InputActionEventData> callback, InputActionEventType eventType);

		void RemoveInputEventDelegate(Action<InputActionEventData> callback, InputActionEventType eventType);

		void AddInputEventDelegate(Action<InputActionEventData> callback, InputActionEventType eventType, int actionId);

		void RemoveInputEventDelegate(Action<InputActionEventData> callback, InputActionEventType eventType, int actionId);

		void AddInputEventDelegate(Action<InputActionEventData> callback, InputActionEventType eventType, int actionId, params object[] args);

		bool IsCurrentInputSource(int actionId, ControllerType controllerType);

		bool GetAnyButton();

		bool GetAnyButtonDown();

		bool GetAnyButtonUp();

		bool GetAnyNegativeButton();

		bool GetAnyNegativeButtonDown();

		bool GetAnyNegativeButtonUp();

		float GetAxis(int actionId);

		float GetAxis(string actionName);

		float GetAxisDelta(int actionId);

		float GetAxisDelta(string actionName);

		Vector2 GetAxis2D(int xAxisActionId, int yAxisActionId);

		Vector2 GetAxis2D(string xAxisActionName, string yAxisActionName);

		float GetAxisRaw(int actionId);

		float GetAxisRaw(string actionName);

		float GetAxisRawDelta(int actionId);

		float GetAxisRawDelta(string actionName);

		bool GetButton(int actionId);

		bool GetButtonDown(int actionId);

		bool GetButtonUp(int actionId);

		bool GetButtonTimedPress(int actionId, float time);

		bool GetButtonTimedPressDown(int actionId, float time);

		bool GetButtonTimedPressUp(int actionId, float time);

		bool GetButtonPrev(int actionId);

		bool GetNegativeButton(int actionId);

		bool GetNegativeButtonDown(int actionId);

		bool GetNegativeButtonUp(int actionId);

		Vector2 GetMousePosition();

		bool GetLeftMouseButtonDown(int index = 0);

		string GetMapEnableTag();

		bool SetMapEnableTag(string tag);

		ControllerMap GetMap(Controller controller, int categoryId);

		ControllerMap GetMap(ControllerType controllerType, int controllerId, int categoryId);

		void ResetToDefaults(ControllerType controllerType);

		IEnumerable<ControllerMap> GetAllMapsInCategory(int categoryId);

		void AddLastActiveControllerChangedDelegate(PlayerActiveControllerChangedDelegate callback, ControllerType controllerType);

		void RemoveLastActiveControllerChangedDelegate(PlayerActiveControllerChangedDelegate callback, ControllerType controllerType);

		void AddLastActiveControllerChangedDelegate(PlayerActiveControllerChangedDelegate callback);

		void RemoveLastActiveControllerChangedDelegate(PlayerActiveControllerChangedDelegate callback);

		Controller GetController(ControllerType controllerType, int controllerId);

		Controller GetLastActiveController();

		Controller GetLastActiveController(ControllerType controllerType);
	}
}
