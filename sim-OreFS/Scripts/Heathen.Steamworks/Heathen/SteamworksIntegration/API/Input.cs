using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Steamworks;
using UnityEngine;

namespace Heathen.SteamworksIntegration.API
{
	public static class Input
	{
		public static class Client
		{
			public static ControllerDataEvent EventInputDataChanged = new ControllerDataEvent();

			private static bool initialized = false;

			private static Dictionary<string, InputActionSetHandle_t> m_inputActionSetHandles = new Dictionary<string, InputActionSetHandle_t>();

			private static Dictionary<string, InputAnalogActionHandle_t> m_inputAnalogActionHandles = new Dictionary<string, InputAnalogActionHandle_t>();

			private static Dictionary<string, InputDigitalActionHandle_t> m_inputDigitalActionHandles = new Dictionary<string, InputDigitalActionHandle_t>();

			private static Dictionary<EInputActionOrigin, Texture2D> glyphs = new Dictionary<EInputActionOrigin, Texture2D>();

			private static List<(string name, InputActionType type)> actions = new List<(string, InputActionType)>();

			private static Dictionary<InputHandle_t, InputControllerData> controllers = new Dictionary<InputHandle_t, InputControllerData>();

			private static Dictionary<InputHandle_t, int> controllerUpdates = new Dictionary<InputHandle_t, int>();

			public static bool Initialized => initialized;

			public static InputHandle_t[] Controllers
			{
				get
				{
					InputHandle_t[] array = new InputHandle_t[16];
					int connectedControllers = SteamInput.GetConnectedControllers(array);
					Array.Resize(ref array, connectedControllers);
					return array;
				}
			}

			[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
			private static void RuntimeInit()
			{
				m_inputActionSetHandles = new Dictionary<string, InputActionSetHandle_t>();
				m_inputAnalogActionHandles = new Dictionary<string, InputAnalogActionHandle_t>();
				m_inputDigitalActionHandles = new Dictionary<string, InputDigitalActionHandle_t>();
				foreach (KeyValuePair<EInputActionOrigin, Texture2D> glyph in glyphs)
				{
					if (glyph.Value != null)
					{
						UnityEngine.Object.Destroy(glyph.Value);
					}
				}
				glyphs = new Dictionary<EInputActionOrigin, Texture2D>();
				actions = new List<(string, InputActionType)>();
				controllers = new Dictionary<InputHandle_t, InputControllerData>();
				controllerUpdates = new Dictionary<InputHandle_t, int>();
				EventInputDataChanged = new ControllerDataEvent();
				initialized = false;
			}

			public static void AddInput(string name, InputActionType type)
			{
				actions.Add((name, type));
			}

			public static void RemoveInput(string name)
			{
				actions.RemoveAll(((string name, InputActionType type) p) => p.name == name);
			}

			public static InputActionData GetActionData(string name)
			{
				if (controllers.Count > 0)
				{
					return controllers.First().Value.GetActionData(name);
				}
				InputHandle_t[] array = Controllers;
				if (array.Length != 0)
				{
					return Update(array[0]).GetActionData(name);
				}
				return default(InputActionData);
			}

			public static InputActionData GetActionData(InputHandle_t controller, string name)
			{
				if (controllers.ContainsKey(controller))
				{
					return controllers[controller].GetActionData(name);
				}
				return default(InputActionData);
			}

			public static InputControllerData Update(InputHandle_t controller)
			{
				if (!controllerUpdates.ContainsKey(controller))
				{
					controllerUpdates.Add(controller, -1);
				}
				if (controllerUpdates[controller] != Time.frameCount)
				{
					controllerUpdates[controller] = Time.frameCount;
					InputControllerData inputControllerData = new InputControllerData
					{
						handle = controller,
						inputs = new InputActionData[actions.Count]
					};
					if (!controllers.ContainsKey(controller))
					{
						controllers.Add(controller, new InputControllerData
						{
							handle = controller,
							inputs = new InputActionData[0]
						});
					}
					InputControllerData inputControllerData2 = controllers[controller];
					List<InputActionUpdate> list = new List<InputActionUpdate>();
					for (int i = 0; i < actions.Count; i++)
					{
						var (name, type) = actions[i];
						if (type == InputActionType.Analog)
						{
							InputAnalogActionHandle_t analogActionHandle = GetAnalogActionHandle(name);
							if (analogActionHandle.m_InputAnalogActionHandle != 0L)
							{
								InputActionData inputActionData = inputControllerData2.inputs.FirstOrDefault((InputActionData p) => p.name == name && p.type == type);
								InputAnalogActionData_t analogActionData = GetAnalogActionData(controller, analogActionHandle);
								InputActionUpdate item = new InputActionUpdate
								{
									name = name,
									controller = controller,
									mode = analogActionData.eMode,
									type = type,
									wasActive = inputActionData.active,
									wasState = inputActionData.state,
									wasX = inputActionData.x,
									wasY = inputActionData.y,
									isActive = (analogActionData.bActive != 0),
									isState = (analogActionData.x != 0f || analogActionData.y != 0f),
									isX = analogActionData.x,
									isY = analogActionData.y
								};
								bool num = inputActionData.x != analogActionData.x || inputActionData.y != analogActionData.y || inputActionData.active != (analogActionData.bActive == 0) || inputActionData.state != (analogActionData.x != 0f || analogActionData.y != 0f);
								inputControllerData.inputs[i] = item.Data;
								if (num)
								{
									list.Add(item);
								}
							}
							continue;
						}
						InputDigitalActionHandle_t digitalActionHandle = GetDigitalActionHandle(name);
						if (digitalActionHandle.m_InputDigitalActionHandle != 0L)
						{
							InputDigitalActionData_t digitalActionData = GetDigitalActionData(controller, digitalActionHandle);
							InputActionData inputActionData2 = inputControllerData2.inputs.FirstOrDefault((InputActionData p) => p.name == name && p.type == type);
							InputActionUpdate item2 = new InputActionUpdate
							{
								name = name,
								controller = controller,
								mode = EInputSourceMode.k_EInputSourceMode_None,
								type = inputActionData2.type,
								wasActive = inputActionData2.active,
								wasState = inputActionData2.state,
								wasX = inputActionData2.x,
								wasY = inputActionData2.y,
								isActive = (digitalActionData.bActive != 0),
								isState = (digitalActionData.bState != 0),
								isX = (int)digitalActionData.bState,
								isY = (int)digitalActionData.bState
							};
							bool num2 = digitalActionData.bState != 0 != inputActionData2.state;
							inputControllerData.inputs[i] = item2.Data;
							if (num2)
							{
								list.Add(item2);
							}
						}
					}
					inputControllerData.changes = list.ToArray();
					controllers[controller] = inputControllerData;
					if (inputControllerData.changes != null && inputControllerData.changes.Length != 0)
					{
						EventInputDataChanged?.Invoke(inputControllerData);
					}
					return inputControllerData;
				}
				return controllers[controller];
			}

			public static void ActivateActionSet(InputHandle_t controllerHandle, InputActionSetHandle_t actionSetHandle)
			{
				SteamInput.ActivateActionSet(controllerHandle, actionSetHandle);
			}

			public static void ActivateActionSet(InputActionSetHandle_t actionSetHandle)
			{
				if (controllers.Count > 0)
				{
					ActivateActionSet(controllers.First().Key, actionSetHandle);
					return;
				}
				InputHandle_t[] array = Controllers;
				if (array.Length != 0)
				{
					ActivateActionSet(Update(array[0]).handle, actionSetHandle);
				}
			}

			public static void ActivateActionSet(InputHandle_t controllerHandle, string actionSet)
			{
				if (m_inputActionSetHandles.ContainsKey(actionSet))
				{
					SteamInput.ActivateActionSet(controllerHandle, m_inputActionSetHandles[actionSet]);
					return;
				}
				GetActionSetHandle(actionSet);
				SteamInput.ActivateActionSet(controllerHandle, m_inputActionSetHandles[actionSet]);
			}

			public static void ActivateActionSetLayer(InputHandle_t controllerHandle, InputActionSetHandle_t actionSetHandle)
			{
				SteamInput.ActivateActionSetLayer(controllerHandle, actionSetHandle);
			}

			public static void ActivateActionSetLayer(InputActionSetHandle_t actionSetHandle)
			{
				if (controllers.Count > 0)
				{
					ActivateActionSetLayer(controllers.First().Key, actionSetHandle);
					return;
				}
				InputHandle_t[] array = Controllers;
				if (array.Length != 0)
				{
					ActivateActionSetLayer(Update(array[0]).handle, actionSetHandle);
				}
			}

			public static void ActivateActionSetLayer(InputHandle_t controllerHandle, string actionSet)
			{
				if (m_inputActionSetHandles.ContainsKey(actionSet))
				{
					SteamInput.ActivateActionSetLayer(controllerHandle, m_inputActionSetHandles[actionSet]);
					return;
				}
				GetActionSetHandle(actionSet);
				SteamInput.ActivateActionSetLayer(controllerHandle, m_inputActionSetHandles[actionSet]);
			}

			public static void DeactivateActionSetLayer(InputHandle_t controllerHandle, InputActionSetHandle_t actionSetHandle)
			{
				SteamInput.DeactivateActionSetLayer(controllerHandle, actionSetHandle);
			}

			public static void DeactivateActionSetLayer(InputHandle_t controllerHandle, string actionSet)
			{
				if (m_inputActionSetHandles.ContainsKey(actionSet))
				{
					SteamInput.DeactivateActionSetLayer(controllerHandle, m_inputActionSetHandles[actionSet]);
					return;
				}
				GetActionSetHandle(actionSet);
				SteamInput.DeactivateActionSetLayer(controllerHandle, m_inputActionSetHandles[actionSet]);
			}

			public static void DeactivateAllActionSetLayers(InputHandle_t controllerHandle)
			{
				SteamInput.DeactivateAllActionSetLayers(controllerHandle);
			}

			public static InputActionSetHandle_t[] GetActiveActionSetLayers(InputHandle_t controllerHandle)
			{
				InputActionSetHandle_t[] array = new InputActionSetHandle_t[16];
				int activeActionSetLayers = SteamInput.GetActiveActionSetLayers(controllerHandle, array);
				Array.Resize(ref array, activeActionSetLayers);
				return array;
			}

			public static InputActionSetHandle_t GetActionSetHandle(string setName)
			{
				InputActionSetHandle_t actionSetHandle = SteamInput.GetActionSetHandle(setName);
				if (m_inputActionSetHandles.ContainsKey(setName))
				{
					m_inputActionSetHandles[setName] = actionSetHandle;
				}
				else
				{
					m_inputActionSetHandles.Add(setName, actionSetHandle);
				}
				return actionSetHandle;
			}

			public static InputAnalogActionData_t GetAnalogActionData(InputHandle_t controllerHandle, InputAnalogActionHandle_t analogActionHandle)
			{
				return SteamInput.GetAnalogActionData(controllerHandle, analogActionHandle);
			}

			public static InputAnalogActionData_t GetAnalogActionData(InputHandle_t controllerHandle, string actionName)
			{
				if (m_inputAnalogActionHandles.ContainsKey(actionName))
				{
					return SteamInput.GetAnalogActionData(controllerHandle, m_inputAnalogActionHandles[actionName]);
				}
				InputAnalogActionHandle_t analogActionHandle = GetAnalogActionHandle(actionName);
				return SteamInput.GetAnalogActionData(controllerHandle, analogActionHandle);
			}

			public static InputAnalogActionHandle_t GetAnalogActionHandle(string actionName)
			{
				InputAnalogActionHandle_t analogActionHandle = SteamInput.GetAnalogActionHandle(actionName);
				if (m_inputAnalogActionHandles.ContainsKey(actionName))
				{
					m_inputAnalogActionHandles[actionName] = analogActionHandle;
				}
				else
				{
					m_inputAnalogActionHandles.Add(actionName, analogActionHandle);
				}
				return analogActionHandle;
			}

			public static EInputActionOrigin[] GetAnalogActionOrigins(InputHandle_t controllerHandle, InputActionSetHandle_t actionSetHandle, InputAnalogActionHandle_t analogActionHandle)
			{
				EInputActionOrigin[] array = new EInputActionOrigin[8];
				SteamInput.GetAnalogActionOrigins(controllerHandle, actionSetHandle, analogActionHandle, array);
				return array;
			}

			public static EInputActionOrigin[] GetAnalogActionOrigins(InputHandle_t controllerHandle, string actionSet, string analogName)
			{
				EInputActionOrigin[] array = new EInputActionOrigin[8];
				if (!m_inputAnalogActionHandles.ContainsKey(analogName))
				{
					GetAnalogActionHandle(analogName);
				}
				if (!m_inputActionSetHandles.ContainsKey(actionSet))
				{
					GetActionSetHandle(actionSet);
				}
				SteamInput.GetAnalogActionOrigins(controllerHandle, m_inputActionSetHandles[actionSet], m_inputAnalogActionHandles[analogName], array);
				return array;
			}

			public static InputHandle_t GetControllerForGamepadIndex(int index)
			{
				return SteamInput.GetControllerForGamepadIndex(index);
			}

			public static InputActionSetHandle_t GetCurrentActionSet(InputHandle_t controllerHandle)
			{
				return SteamInput.GetCurrentActionSet(controllerHandle);
			}

			public static InputDigitalActionData_t GetDigitalActionData(InputHandle_t controllerHandle, InputDigitalActionHandle_t actionHandle)
			{
				return SteamInput.GetDigitalActionData(controllerHandle, actionHandle);
			}

			public static InputDigitalActionData_t GetDigitalActionData(InputHandle_t controllerHandle, string actionName)
			{
				if (!m_inputDigitalActionHandles.ContainsKey(actionName))
				{
					InputDigitalActionHandle_t digitalActionHandle = GetDigitalActionHandle(actionName);
					return SteamInput.GetDigitalActionData(controllerHandle, digitalActionHandle);
				}
				return SteamInput.GetDigitalActionData(controllerHandle, m_inputDigitalActionHandles[actionName]);
			}

			public static InputDigitalActionHandle_t GetDigitalActionHandle(string actionName)
			{
				InputDigitalActionHandle_t digitalActionHandle = SteamInput.GetDigitalActionHandle(actionName);
				if (m_inputDigitalActionHandles.ContainsKey(actionName))
				{
					m_inputDigitalActionHandles[actionName] = digitalActionHandle;
				}
				else
				{
					m_inputDigitalActionHandles.Add(actionName, digitalActionHandle);
				}
				return digitalActionHandle;
			}

			public static EInputActionOrigin[] GetDigitalActionOrigins(InputHandle_t controllerHandle, InputActionSetHandle_t actionSetHandle, InputDigitalActionHandle_t digitalActionHandle)
			{
				EInputActionOrigin[] array = new EInputActionOrigin[8];
				SteamInput.GetDigitalActionOrigins(controllerHandle, actionSetHandle, digitalActionHandle, array);
				return array;
			}

			public static EInputActionOrigin[] GetDigitalActionOrigins(InputHandle_t controllerHandle, string actionSet, string actionName)
			{
				EInputActionOrigin[] array = new EInputActionOrigin[8];
				if (!m_inputDigitalActionHandles.ContainsKey(actionName))
				{
					GetDigitalActionHandle(actionName);
				}
				if (!m_inputDigitalActionHandles.ContainsKey(actionSet))
				{
					GetActionSetHandle(actionSet);
				}
				SteamInput.GetDigitalActionOrigins(controllerHandle, m_inputActionSetHandles[actionSet], m_inputDigitalActionHandles[actionName], array);
				return array;
			}

			public static int GetGamepadIndexForController(InputHandle_t controllerHandle)
			{
				return SteamInput.GetGamepadIndexForController(controllerHandle);
			}

			public static Texture2D GetGlyphActionOrigin(EInputActionOrigin origin)
			{
				if (glyphs.ContainsKey(origin))
				{
					return glyphs[origin];
				}
				string glyphPNGForActionOrigin = GetGlyphPNGForActionOrigin(origin, ESteamInputGlyphSize.k_ESteamInputGlyphSize_Large, 0u);
				if (!string.IsNullOrEmpty(glyphPNGForActionOrigin))
				{
					if (File.Exists(glyphPNGForActionOrigin))
					{
						byte[] data = File.ReadAllBytes(glyphPNGForActionOrigin);
						Texture2D texture2D = new Texture2D(2, 2);
						texture2D.LoadImage(data);
						glyphs.Add(origin, texture2D);
						return texture2D;
					}
					return null;
				}
				return null;
			}

			public static void UnloadGlyphImages()
			{
				foreach (KeyValuePair<EInputActionOrigin, Texture2D> glyph in glyphs)
				{
					if (glyph.Value != null)
					{
						UnityEngine.Object.Destroy(glyph.Value);
					}
				}
				glyphs = new Dictionary<EInputActionOrigin, Texture2D>();
			}

			public static string GetGlyphPNGForActionOrigin(EInputActionOrigin origin, ESteamInputGlyphSize size, uint flags)
			{
				return SteamInput.GetGlyphPNGForActionOrigin(origin, size, flags);
			}

			public static string GetGlyphSVGForActionOrigin(EInputActionOrigin origin, uint flags)
			{
				return SteamInput.GetGlyphSVGForActionOrigin(origin, flags);
			}

			public static ESteamInputType GetInputTypeForHandle(InputHandle_t controllerHandle)
			{
				return SteamInput.GetInputTypeForHandle(controllerHandle);
			}

			public static InputMotionData_t GetMotionData(InputHandle_t controllerHandle)
			{
				return SteamInput.GetMotionData(controllerHandle);
			}

			public static string GetStringForActionOrigin(EInputActionOrigin origin)
			{
				return SteamInput.GetStringForActionOrigin(origin);
			}

			public static bool Init(IEnumerable<(string name, InputActionType type)> actions = null)
			{
				initialized = SteamInput.Init(bExplicitlyCallRunFrame: false);
				foreach (var action in actions)
				{
					Client.actions.Add(action);
				}
				return initialized;
			}

			public static void RunFrame()
			{
				SteamInput.RunFrame();
			}

			public static void SetLEDColor(InputHandle_t controllerHandle, Color32 color)
			{
				SteamInput.SetLEDColor(controllerHandle, color.r, color.g, color.b, 0u);
			}

			public static void ResetLEDColor(InputHandle_t controllerHandle)
			{
				SteamInput.SetLEDColor(controllerHandle, 0, 0, 0, 1u);
			}

			public static bool Shutdown()
			{
				initialized = false;
				return SteamInput.Shutdown();
			}

			public static void ShowBindingPanel(InputHandle_t controllerHandle)
			{
				SteamInput.ShowBindingPanel(controllerHandle);
			}

			public static void StopAnalogActionMomentum(InputHandle_t controllerHandle, InputAnalogActionHandle_t analogAction)
			{
				SteamInput.StopAnalogActionMomentum(controllerHandle, analogAction);
			}

			public static void StopAnalogActionMomentum(InputHandle_t controllerHandle, string actionName)
			{
				if (m_inputAnalogActionHandles.ContainsKey(actionName))
				{
					SteamInput.StopAnalogActionMomentum(controllerHandle, m_inputAnalogActionHandles[actionName]);
					return;
				}
				InputAnalogActionHandle_t analogActionHandle = GetAnalogActionHandle(actionName);
				SteamInput.StopAnalogActionMomentum(controllerHandle, analogActionHandle);
			}

			public static void TriggerVibration(InputHandle_t controllerHandle, ushort leftSpeed, ushort rightSpeed)
			{
				SteamInput.TriggerVibration(controllerHandle, leftSpeed, rightSpeed);
			}

			public static void GetActionOriginFromXboxOrigin(InputHandle_t controllerHandle, EXboxOrigin origin)
			{
				SteamInput.GetActionOriginFromXboxOrigin(controllerHandle, origin);
			}

			public static void TranslateActionOrigin(ESteamInputType destination, EInputActionOrigin source)
			{
				SteamInput.TranslateActionOrigin(destination, source);
			}

			public static bool GetDeviceBindingRevision(InputHandle_t controllerHandle, out int major, out int minor)
			{
				return SteamInput.GetDeviceBindingRevision(controllerHandle, out major, out minor);
			}

			public static uint GetRemotePlaySessionID(InputHandle_t controllerHandle)
			{
				return SteamInput.GetRemotePlaySessionID(controllerHandle);
			}
		}
	}
}
