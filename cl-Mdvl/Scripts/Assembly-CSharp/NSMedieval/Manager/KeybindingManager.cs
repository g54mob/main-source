using System;
using System.Collections.Generic;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSEipix.Base;
using NSMedieval.Controllers;
using NSMedieval.Enums;
using NSMedieval.Tutorial;
using NSMedieval.UI.PhotoMode;
using NSMedieval.WorldMap;
using UnityEngine;

namespace NSMedieval.Manager
{
	public class KeybindingManager : MonoSingleton<KeybindingManager>, IObserver
	{
		private Dictionary<KeyInputEvent, Keybinding> keybindings;

		private Dictionary<Keybinding, EventContainer> events;

		private Dictionary<Keybinding, EventContainer> upEvents;

		private Dictionary<Keybinding, EventContainer> intervalEvents;

		private Dictionary<KeyCode, Keybinding> listenCodes;

		private readonly HashSet<KeyInputEvent> processEventOnWorldMap = new HashSet<KeyInputEvent>();

		private readonly HashSet<KeyInputEvent> processEventOnPhotoMode = new HashSet<KeyInputEvent>
		{
			KeyInputEvent.MoveUp,
			KeyInputEvent.MoveDown,
			KeyInputEvent.MoveLeft,
			KeyInputEvent.MoveRight,
			KeyInputEvent.TiltDown,
			KeyInputEvent.TiltUp,
			KeyInputEvent.CameraReset,
			KeyInputEvent.MapRotateLeft,
			KeyInputEvent.MapRotateRight,
			KeyInputEvent.ZoomIn,
			KeyInputEvent.ZoomOut
		};

		public Dictionary<KeyInputEvent, Keybinding> Keybindings => keybindings;

		public void OnKeybindingExecuted(Keybinding keybinding)
		{
		}

		protected override void OnDestroy()
		{
			base.OnDestroy();
			foreach (EventContainer value in events.Values)
			{
				value.ClearEvent();
			}
			foreach (EventContainer value2 in upEvents.Values)
			{
				value2.ClearEvent();
			}
			foreach (EventContainer value3 in intervalEvents.Values)
			{
				value3.ClearEvent();
			}
			keybindings.Clear();
			events.Clear();
			upEvents.Clear();
			intervalEvents.Clear();
			listenCodes.Clear();
			processEventOnWorldMap.Clear();
			processEventOnPhotoMode.Clear();
		}

		public void SubscribeToEvent(KeyInputEvent keyEvent, Action callback, bool activeOnWorldMap = false, bool activeOnPhotoMode = false)
		{
			if (keybindings == null || events == null || intervalEvents == null || upEvents == null)
			{
				InitEvents();
			}
			if (activeOnWorldMap)
			{
				processEventOnWorldMap.Add(keyEvent);
			}
			if (activeOnPhotoMode)
			{
				processEventOnPhotoMode.Add(keyEvent);
			}
			try
			{
				events[keybindings[keyEvent]].Event += callback;
			}
			catch (Exception)
			{
				Log.Error("Missing key event: " + keyEvent, "C:\\GIT\\dev\\Assets\\Scripts\\Managers\\KeybindingManager.cs");
			}
		}

		public void UnsubscribeFromEvent(KeyInputEvent keyEvent, Action callback)
		{
			if (processEventOnWorldMap.Contains(keyEvent))
			{
				processEventOnWorldMap.Remove(keyEvent);
			}
			if (processEventOnPhotoMode.Contains(keyEvent))
			{
				processEventOnPhotoMode.Remove(keyEvent);
			}
			if (keybindings.ContainsKey(keyEvent) && events.ContainsKey(keybindings[keyEvent]))
			{
				events[keybindings[keyEvent]].Event -= callback;
			}
		}

		public void ExecuteKeybindingEvent(KeyCode key)
		{
			bool isEnabled;
			FVLogTraceInterpolationHandler messageBuilder = new FVLogTraceInterpolationHandler(24, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Managers\\KeybindingManager.cs");
			if (isEnabled)
			{
				messageBuilder.AppendLiteral("ExecuteKeybindingEvent: ");
				messageBuilder.AppendFormatted(key);
			}
			Log.Trace(messageBuilder);
			if (!listenCodes.TryGetValue(key, out var value) || !events.ContainsKey(value) || (!processEventOnWorldMap.Contains(value.KeyInputEvent) && MonoSingleton<NSMedieval.WorldMap.WorldMap>.Instance.IsWorldMapVisible) || (!processEventOnPhotoMode.Contains(value.KeyInputEvent) && MonoSingleton<PhotoMode>.Instance.IsPhotoModeActive))
			{
				return;
			}
			if (TutorialManager.IsTutorialActive && MonoSingleton<TutorialStepManager>.Instance.TutorialInputManager.IsInputEventBlocked(value.KeyInputEvent))
			{
				FVLogDebugInterpolationHandler messageBuilder2 = new FVLogDebugInterpolationHandler(42, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Managers\\KeybindingManager.cs");
				if (isEnabled)
				{
					messageBuilder2.AppendFormatted(value.KeyInputEvent);
					messageBuilder2.AppendLiteral(" - Tutorial Forbidden! Aborting execution.");
				}
				Log.Debug(messageBuilder2);
			}
			else
			{
				events[value]?.InvokeEvent();
			}
		}

		public void SubscribeToIntervalEvent(KeyInputEvent keyEvent, Action callback)
		{
			if (keybindings == null || events == null || intervalEvents == null || upEvents == null)
			{
				InitEvents();
			}
			try
			{
				intervalEvents[keybindings[keyEvent]].Event += callback;
			}
			catch (Exception)
			{
				Log.Error("Missing key event: " + keyEvent, "C:\\GIT\\dev\\Assets\\Scripts\\Managers\\KeybindingManager.cs");
			}
		}

		public void UnsubscribeFromIntervalEvent(KeyInputEvent keyEvent, Action callback)
		{
			if (intervalEvents.ContainsKey(keybindings[keyEvent]))
			{
				intervalEvents[keybindings[keyEvent]].Event -= callback;
			}
		}

		public void ExecuteKeybindingIntervalEvent(KeyCode key)
		{
			if (listenCodes.TryGetValue(key, out var value) && intervalEvents.ContainsKey(value))
			{
				intervalEvents[value]?.InvokeEvent();
			}
		}

		public void SubscribeToUpEvent(KeyInputEvent keyEvent, Action callback, bool activeOnWorldMap = false)
		{
			if (keybindings == null || events == null || intervalEvents == null || upEvents == null)
			{
				InitEvents();
			}
			try
			{
				upEvents[keybindings[keyEvent]].Event += callback;
			}
			catch (Exception)
			{
				Log.Error("Missing key UP event: " + keyEvent, "C:\\GIT\\dev\\Assets\\Scripts\\Managers\\KeybindingManager.cs");
			}
		}

		public void UnsubscribeFromUpEvent(KeyInputEvent keyEvent, Action callback)
		{
			if (keybindings.ContainsKey(keyEvent) && upEvents.ContainsKey(keybindings[keyEvent]))
			{
				upEvents[keybindings[keyEvent]].Event -= callback;
			}
		}

		public void ExecuteKeybindingUpEvent(KeyCode key)
		{
			if (listenCodes.TryGetValue(key, out var value) && upEvents.ContainsKey(value) && (processEventOnWorldMap.Contains(value.KeyInputEvent) || !MonoSingleton<NSMedieval.WorldMap.WorldMap>.Instance.IsWorldMapVisible) && (processEventOnPhotoMode.Contains(value.KeyInputEvent) || !MonoSingleton<PhotoMode>.Instance.IsPhotoModeActive) && (!TutorialManager.IsTutorialActive || !MonoSingleton<TutorialStepManager>.Instance.TutorialInputManager.IsInputEventBlocked(value.KeyInputEvent)))
			{
				upEvents[value]?.InvokeEvent();
			}
		}

		public void UpdateKeybindings(Keybinding[] newKeybindings)
		{
			if (keybindings == null)
			{
				InitEvents();
			}
			HashSet<KeyCode> hashSet = new HashSet<KeyCode>();
			foreach (Keybinding keybinding in newKeybindings)
			{
				MonoSingleton<InputManager>.Instance.RegisterKeycodeForListening(keybinding.PrimaryKey);
				MonoSingleton<InputManager>.Instance.RegisterKeycodeForListening(keybinding.AlternativeKey);
				if (!keybindings.ContainsKey(keybinding.KeyInputEvent))
				{
					keybindings.Add(keybinding.KeyInputEvent, keybinding);
					continue;
				}
				Keybinding keybinding2 = keybindings[keybinding.KeyInputEvent];
				if (keybinding2.PrimaryKey != keybinding.PrimaryKey && listenCodes.ContainsKey(keybinding2.PrimaryKey) && !hashSet.Contains(keybinding2.PrimaryKey))
				{
					listenCodes.Remove(keybinding2.PrimaryKey);
				}
				if (keybinding2.AlternativeKey != keybinding.AlternativeKey && listenCodes.ContainsKey(keybinding2.AlternativeKey) && !hashSet.Contains(keybinding2.AlternativeKey))
				{
					listenCodes.Remove(keybinding2.AlternativeKey);
				}
				keybinding2.SetPrimaryKey(keybinding.PrimaryKey);
				keybinding2.SetAlternativeKey(keybinding.AlternativeKey);
				listenCodes[keybinding2.PrimaryKey] = keybinding2;
				listenCodes[keybinding2.AlternativeKey] = keybinding2;
				hashSet.Add(keybinding2.PrimaryKey);
				hashSet.Add(keybinding2.AlternativeKey);
			}
		}

		public bool IsKeybindingKeyDown(KeyInputEvent bindEvent, KeyCode key)
		{
			if (!ShouldProcessEvent(bindEvent))
			{
				return false;
			}
			Keybinding keybinding = keybindings[bindEvent];
			if (keybinding.PrimaryKey != key)
			{
				return keybinding.AlternativeKey == key;
			}
			return true;
		}

		public bool IsKeybindingKeyDown(KeyInputEvent bindEvent)
		{
			if (!ShouldProcessEvent(bindEvent))
			{
				return false;
			}
			Keybinding keybinding = keybindings[bindEvent];
			if (!Input.GetKey(keybinding.PrimaryKey))
			{
				return Input.GetKey(keybinding.AlternativeKey);
			}
			return true;
		}

		public bool IsKeybindingKeyPressed(KeyInputEvent bindEvent)
		{
			if (!ShouldProcessEvent(bindEvent))
			{
				return false;
			}
			Keybinding keybinding = keybindings[bindEvent];
			if (!Input.GetKeyDown(keybinding.PrimaryKey))
			{
				return Input.GetKeyDown(keybinding.AlternativeKey);
			}
			return true;
		}

		private bool ShouldProcessEvent(KeyInputEvent bindEvent)
		{
			if (keybindings == null || processEventOnWorldMap == null || processEventOnPhotoMode == null)
			{
				return false;
			}
			if (!keybindings.ContainsKey(bindEvent))
			{
				return false;
			}
			if (!processEventOnWorldMap.Contains(bindEvent) && MonoSingleton<NSMedieval.WorldMap.WorldMap>.Instance.IsWorldMapVisible)
			{
				return false;
			}
			if (!processEventOnPhotoMode.Contains(bindEvent) && MonoSingleton<PhotoMode>.Instance.IsPhotoModeActive)
			{
				return false;
			}
			if (TutorialManager.IsTutorialActive && MonoSingleton<TutorialStepManager>.Instance.TutorialInputManager.IsInputEventBlocked(bindEvent))
			{
				bool isEnabled;
				FVLogDebugInterpolationHandler messageBuilder = new FVLogDebugInterpolationHandler(42, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Managers\\KeybindingManager.cs");
				if (isEnabled)
				{
					messageBuilder.AppendFormatted(bindEvent);
					messageBuilder.AppendLiteral(" - Tutorial Forbidden! Aborting execution.");
				}
				Log.Debug(messageBuilder);
				return false;
			}
			return true;
		}

		private void InitEvents()
		{
			if (keybindings != null)
			{
				return;
			}
			Keybinding[] array = MonoSingleton<GlobalSaveController>.Instance.GlobalSettings.Keybindings;
			keybindings = new Dictionary<KeyInputEvent, Keybinding>();
			events = new Dictionary<Keybinding, EventContainer>();
			intervalEvents = new Dictionary<Keybinding, EventContainer>();
			upEvents = new Dictionary<Keybinding, EventContainer>();
			listenCodes = new Dictionary<KeyCode, Keybinding>();
			for (int i = 0; i < array.Length; i++)
			{
				MonoSingleton<InputManager>.Instance.RegisterKeycodeForListening(array[i].PrimaryKey);
				MonoSingleton<InputManager>.Instance.RegisterKeycodeForListening(array[i].AlternativeKey);
				if (!keybindings.ContainsKey(array[i].KeyInputEvent))
				{
					keybindings.Add(array[i].KeyInputEvent, array[i]);
				}
				if (!events.ContainsKey(array[i]))
				{
					events.Add(array[i], new EventContainer());
				}
				if (!intervalEvents.ContainsKey(array[i]))
				{
					intervalEvents.Add(array[i], new EventContainer());
				}
				if (!upEvents.ContainsKey(array[i]))
				{
					upEvents.Add(array[i], new EventContainer());
				}
				listenCodes[array[i].PrimaryKey] = array[i];
				listenCodes[array[i].AlternativeKey] = array[i];
			}
		}

		private void Start()
		{
			InitEvents();
		}

		private void OnEnable()
		{
			MonoSingleton<SettingsController>.Instance.KeybindingsSavedEvent += OnKeybindingsSaved;
		}

		private void OnDisable()
		{
			if (MonoSingleton<SettingsController>.IsInstantiated())
			{
				MonoSingleton<SettingsController>.Instance.KeybindingsSavedEvent -= OnKeybindingsSaved;
			}
		}

		private void OnKeybindingsSaved()
		{
			Keybinding[] array = MonoSingleton<GlobalSaveController>.Instance.GlobalSettings.Keybindings;
			if (array != null)
			{
				MonoSingleton<KeybindingManager>.Instance.UpdateKeybindings(array);
			}
		}
	}
}
