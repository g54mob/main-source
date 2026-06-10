using System;
using System.Collections.Generic;
using System.Linq;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSEipix.Base;
using NSMedieval.Components;
using NSMedieval.Map;
using NSMedieval.StructurePresets;
using NSMedieval.UI;
using NSMedieval.WorldMap;
using UnityEngine;

namespace NSMedieval.Manager
{
	public class InputManager : MonoSingleton<InputManager>, IObserver
	{
		private const int ReservedTemporaryListenerSlots = 10;

		private static readonly int[] HandleMouseButtons = new int[2] { 0, 1 };

		private readonly HashSet<KeyCode> handleKeys = new HashSet<KeyCode>();

		private readonly SortedDictionary<int, InputListener> listeners = new SortedDictionary<int, InputListener>();

		private readonly HashSet<int> listenersToRemove = new HashSet<int>();

		private readonly HashSet<KeyCode> pressedKeys = new HashSet<KeyCode>();

		private readonly HashSet<InputListener> tempListenersToAdd = new HashSet<InputListener>();

		private bool enableUpdate;

		private MouseFullClickData mouseFullClickData = new MouseFullClickData
		{
			Button = -1,
			Position = Vector3.zero
		};

		private bool wasKeyDown;

		public bool InputEnabled { get; private set; } = true;

		protected override void OnDestroy()
		{
			if (MonoSingleton<UIController>.IsInstantiated())
			{
				MonoSingleton<UIController>.Instance.GameStartedEvent -= IsGameStarted;
			}
			if (MonoSingleton<SceneUIManager>.IsInstantiated())
			{
				MonoSingleton<SceneUIManager>.Instance.OnPanelOpenEvent -= DisableMultiSelect;
			}
			foreach (InputListener value in listeners.Values)
			{
				value?.Dispose();
			}
			listeners.Clear();
			base.OnDestroy();
		}

		private void Start()
		{
			MonoSingleton<UIController>.Instance.GameStartedEvent += IsGameStarted;
			MonoSingleton<SceneUIManager>.Instance.OnPanelOpenEvent += DisableMultiSelect;
			RegisterListener(-3, new RtsCameraInputListener());
			RegisterListener(-2, new GuiInputListener());
			RegisterListener(-1, new KeybindingsInputListener());
			RegisterListener(10, new DebugInputListener());
			MonoSingleton<World>.Instance.MapLoadedEvent += delegate
			{
				RegisterListener(11, new TrebuchetInputListener());
				RegisterListener(12, new ConstructionPlacementInputListener());
				RegisterListener(13, new SelectionInputListener());
				RegisterListener(14, new DraftInputListener());
				RegisterListener(15, new StructurePresetInputListener());
				RegisterListener(16, new SpawnPointInputListener());
				RegisterListener(17, new SelectableObjectInputListener());
				GetListener(InputListenerType.Trebuchet).Disable();
			};
			for (int num = 0; num < 10; num++)
			{
				if (listeners.ContainsKey(num))
				{
					Log.Warning("Temporary listener slot in use before game start", "C:\\GIT\\dev\\Assets\\Scripts\\Managers\\InputManager.cs");
					break;
				}
			}
		}

		private void Update()
		{
			if (!enableUpdate || !MonoSingleton<SceneController>.IsInstantiated() || !MonoSingleton<SceneController>.Instance.enabled)
			{
				return;
			}
			FlushQueuedListeners();
			if (Input.anyKeyDown && !wasKeyDown)
			{
				wasKeyDown = true;
				HandleKeyEvents();
			}
			else if (!Input.anyKeyDown && wasKeyDown)
			{
				wasKeyDown = false;
				HandleKeyEvents();
			}
			else if (pressedKeys.Any())
			{
				HandleKeyEvents();
			}
			if (!InputEnabled)
			{
				return;
			}
			bool flag = false;
			foreach (KeyValuePair<int, InputListener> listener in listeners)
			{
				if (!listener.Value.IsEnabled)
				{
					continue;
				}
				if (flag)
				{
					if (listener.Value is TrebuchetInputListener)
					{
						listener.Value.Update();
					}
					else
					{
						listener.Value.BlockedUpdate();
					}
				}
				else
				{
					listener.Value.Update();
					flag = listener.Value.IsStopEventPropagation();
				}
			}
			HandleMouseEvent();
		}

		public void RegisterKeycodeForListening(KeyCode code)
		{
			handleKeys.Add(code);
		}

		public void UnregisterKeycodeFromListening(KeyCode code)
		{
			handleKeys.Remove(code);
		}

		public void RegisterListener(int priority, InputListener listener)
		{
			if (listeners.ContainsKey(priority))
			{
				Log.Error("Trying to register listener with priority " + priority + " but some listener already exist with same priority." + listener, "C:\\GIT\\dev\\Assets\\Scripts\\Managers\\InputManager.cs");
				return;
			}
			if (listeners.Values.Any((InputListener item) => item.Type == listener.Type))
			{
				Log.Warning("Tried to register multiple listeners of same type " + listener.Type, "C:\\GIT\\dev\\Assets\\Scripts\\Managers\\InputManager.cs");
				return;
			}
			listener.OnAdded();
			listeners.Add(priority, listener);
		}

		public void RemoveListener(int priority)
		{
			if (listeners.ContainsKey(priority))
			{
				listenersToRemove.Add(priority);
			}
		}

		public void RemoveListener(InputListener listener)
		{
			KeyValuePair<int, InputListener> keyValuePair = listeners.FirstOrDefault((KeyValuePair<int, InputListener> item) => item.Value.Type == listener.Type);
			if (!keyValuePair.Equals(default(KeyValuePair<int, InputListener>)))
			{
				RemoveListener(keyValuePair.Key);
			}
		}

		public void SetInputTypesEnabled(bool enabled, HashSet<InputListenerType> inputListeners)
		{
			foreach (KeyValuePair<int, InputListener> listener in listeners)
			{
				InputListener value = listener.Value;
				if (inputListeners.Contains(value.Type))
				{
					if (enabled)
					{
						value.Enable();
					}
					else
					{
						value.Disable();
					}
				}
			}
			LogDebugInfo("Input was " + (enabled ? "enabled" : "disabled"));
		}

		public void SetInputEnabled(bool value)
		{
			bool isEnabled;
			FVLogTraceInterpolationHandler messageBuilder = new FVLogTraceInterpolationHandler(25, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Managers\\InputManager.cs");
			if (isEnabled)
			{
				messageBuilder.AppendLiteral("Setting input enabled to ");
				messageBuilder.AppendFormatted(value);
			}
			Log.Trace(messageBuilder);
			if (InputEnabled == value)
			{
				return;
			}
			InputEnabled = value;
			foreach (KeyValuePair<int, InputListener> listener in listeners)
			{
				InputListener value2 = listener.Value;
				if (value)
				{
					if (value2.WasEnabled)
					{
						value2.Enable();
					}
				}
				else
				{
					value2.WasEnabled = value2.IsEnabled;
					value2.Disable();
				}
			}
			LogDebugInfo("Input was " + (value ? "enabled" : "disabled"));
		}

		public void RegisterTemporaryListener(InputListener listener)
		{
			for (int i = tempListenersToAdd.Count; i < 10; i++)
			{
				if (!listeners.ContainsKey(i))
				{
					tempListenersToAdd.Add(listener);
					LogDebugInfo("New temporary input listener added");
					return;
				}
			}
			Log.Warning("Could not find free slots to register temporary input listener", "C:\\GIT\\dev\\Assets\\Scripts\\Managers\\InputManager.cs");
		}

		public bool HasListener(Func<InputListener, bool> condition)
		{
			return listeners.Values.Any(condition);
		}

		public void ClearTemporaryListeners()
		{
			for (int i = 0; i < 10; i++)
			{
				RemoveListener(i);
			}
		}

		public InputListener GetListener(InputListenerType type)
		{
			return listeners.Values.FirstOrDefault((InputListener item) => item.Type == type);
		}

		private void HandleKeyEvents()
		{
			bool key = Input.GetKey(KeyCode.Escape);
			if (!InputEnabled && !key)
			{
				if (pressedKeys.Contains(KeyCode.Escape))
				{
					pressedKeys.Remove(KeyCode.Escape);
					LogDebugInfo("ESC Key silently released");
				}
				return;
			}
			foreach (KeyCode code in handleKeys)
			{
				if (Input.GetKey(code))
				{
					if (pressedKeys.Add(code))
					{
						ExecuteListener(delegate(InputListener listener)
						{
							listener.KeyDown(code);
						}, key);
						LogDebugInfo("Key pressed: " + code);
					}
					ExecuteListener(delegate(InputListener listener)
					{
						listener.KeyDownTick(code);
					}, key);
					LogDebugInfo("Key tick: " + code);
				}
				else if (pressedKeys.Contains(code))
				{
					pressedKeys.Remove(code);
					ExecuteListener(delegate(InputListener listener)
					{
						listener.KeyUp(code);
					}, key);
					LogDebugInfo("Key released: " + code);
				}
			}
		}

		private void HandleMouseEvent()
		{
			if (MonoSingleton<NSMedieval.WorldMap.WorldMap>.Instance.IsWorldMapVisible)
			{
				return;
			}
			Vector3 mousePosition = Input.mousePosition;
			bool flag = false;
			int[] handleMouseButtons = HandleMouseButtons;
			foreach (int button in handleMouseButtons)
			{
				if (Input.GetMouseButtonDown(button))
				{
					if (mouseFullClickData.Button >= 0 && mouseFullClickData.Button != button)
					{
						mouseFullClickData.Button = -1;
						flag = true;
					}
					else if (!flag)
					{
						mouseFullClickData.Button = button;
						mouseFullClickData.Position = InputUtils.GetPosScaled(mousePosition);
					}
					InputListenerType inputListenerType = ExecuteListener(delegate(InputListener listener)
					{
						listener.MouseButtonDown(button, mousePosition);
					});
					if (inputListenerType != InputListenerType.None)
					{
						LogDebugInfo($"Input event MouseButtonDown propagation blocked by: {inputListenerType}");
					}
				}
				if (Input.GetMouseButton(button))
				{
					if (mouseFullClickData.Button == button && !IsFullClicked(button, mousePosition))
					{
						mouseFullClickData.Button = -1;
					}
					InputListenerType inputListenerType2 = ExecuteListener(delegate(InputListener listener)
					{
						listener.MouseButtonTick(button, mousePosition);
					});
					if (inputListenerType2 != InputListenerType.None)
					{
						LogDebugInfo($"Input event MoseButtonTick propagation blocked by: {inputListenerType2}");
					}
				}
				if (!Input.GetMouseButtonUp(button))
				{
					continue;
				}
				InputListenerType inputListenerType3 = ExecuteListener(delegate(InputListener listener)
				{
					listener.MouseButtonUp(button, mousePosition);
				});
				if (inputListenerType3 != InputListenerType.None)
				{
					LogDebugInfo($"Input event MoseButtonUp propagation blocked by: {inputListenerType3}");
				}
				if (IsFullClicked(button, mousePosition))
				{
					InputListenerType inputListenerType4 = ExecuteListener(delegate(InputListener listener)
					{
						listener.MouseFullClick(button, mousePosition);
					});
					if (inputListenerType4 != InputListenerType.None)
					{
						LogDebugInfo($"Input event MouseFullClick propagation blocked by: {inputListenerType4}");
					}
				}
				mouseFullClickData.Button = -1;
			}
		}

		private InputListenerType ExecuteListener(Action<InputListener> action, bool overrideKeyBinding = false)
		{
			foreach (KeyValuePair<int, InputListener> listener in listeners)
			{
				bool flag = listener.Value is KeybindingsInputListener && overrideKeyBinding;
				InputListener value = listener.Value;
				if (!value.IsEnabled && !flag)
				{
					value.BeginDisabled();
					if (!value.IsEnabled)
					{
						continue;
					}
				}
				value.Begin();
				action(value);
				if (value.IsStopEventPropagation())
				{
					return value.Type;
				}
			}
			return InputListenerType.None;
		}

		private bool IsFullClicked(int button, Vector3 mousePosition)
		{
			if (mouseFullClickData.Button != button)
			{
				return false;
			}
			return Vector3.Distance(mouseFullClickData.Position, InputUtils.GetPosScaled(mousePosition)) <= 0.05f;
		}

		private void FlushQueuedListeners()
		{
			if (listenersToRemove.Count > 0)
			{
				foreach (int item in listenersToRemove)
				{
					listeners[item]?.OnRemoved();
					listeners.Remove(item);
				}
				listenersToRemove.Clear();
			}
			if (tempListenersToAdd.Count <= 0)
			{
				return;
			}
			for (int i = tempListenersToAdd.Count; i < 10; i++)
			{
				if (!listeners.ContainsKey(i))
				{
					if (tempListenersToAdd.Count == 0)
					{
						break;
					}
					InputListener inputListener = tempListenersToAdd.FirstOrDefault();
					if (inputListener != null)
					{
						tempListenersToAdd.Remove(inputListener);
						RegisterListener(i, inputListener);
					}
				}
			}
			tempListenersToAdd.Clear();
		}

		private void IsGameStarted(bool started)
		{
			enableUpdate = started;
		}

		private void LogDebugInfo(string text)
		{
		}

		private void DisableMultiSelect(string message)
		{
			if (message.Equals("WorldMap"))
			{
				(listeners.FirstOrDefault((KeyValuePair<int, InputListener> l) => l.Value is SelectableObjectInputListener).Value as SelectableObjectInputListener)?.DisableMultiselect();
			}
		}
	}
}
