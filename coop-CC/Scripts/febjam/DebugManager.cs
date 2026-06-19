using System.Collections.Generic;
using Aggro.Core;
using DevCmdLine;
using DevCmdLine.UI;
using Mirror;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class DebugManager : MonoBehaviour, IInputController
{
	public GameObject graphContainer;

	public TextMeshProUGUI versionText;

	private GUIStyle _style;

	private NetworkManagerMode _networkMode;

	private static int _targetFPS = -1;

	private static int _simMS;

	private void Awake()
	{
		if (AggroEditorSettings.TryGetSettings(out var settings))
		{
			graphContainer.SetActive(settings.startWithGraphsEnabled);
		}
		else
		{
			graphContainer.SetActive(value: false);
		}
		if (versionText != null)
		{
			_networkMode = AggroNetworkManager.networkMode;
			if (AggroNetworkManager.isSinglePlayer)
			{
				versionText.text = GameUtil.gameVersionFull + " Single Player";
			}
			else
			{
				versionText.text = $"{GameUtil.gameVersionFull} {_networkMode}";
			}
		}
	}

	private void Update()
	{
		if (AggroInputManager.input.Debug.ToggleConsoleKBM.WasPressedThisFrame())
		{
			if (DevCmdConsole.isOpen)
			{
				DevCmdConsole.CloseConsole();
				AggroInputManager.RemoveController(this);
			}
			else
			{
				AggroInputManager.PushController(this);
				DevCmdConsole.ToggleConsole(DevCmdStartingSelectedButton.Input);
			}
		}
		else if (AggroInputManager.input.Debug.ToggleConsoleGamePad.WasPressedThisFrame())
		{
			if (DevCmdConsole.isOpen)
			{
				DevCmdConsole.CloseConsole();
				AggroInputManager.RemoveController(this);
			}
			else
			{
				AggroInputManager.ChangeMode(InputMode.Gamepad);
				AggroInputManager.PushController(this);
				DevCmdConsole.ToggleConsole(DevCmdStartingSelectedButton.Option);
			}
		}
		if (AggroInputManager.input.Debug.ToggleDebugGraphs.WasPressedThisFrame())
		{
			graphContainer.SetActive(!graphContainer.activeSelf);
		}
		if (AggroInputManager.input.Debug.PrintGraphicsRaycast.WasPressedThisFrame() && EventSystem.current != null)
		{
			PointerEventData pointerEventData = new PointerEventData(EventSystem.current);
			pointerEventData.position = Mouse.current.position.ReadValue();
			List<RaycastResult> list = new List<RaycastResult>();
			EventSystem.current.RaycastAll(pointerEventData, list);
			Debug.Log($"Raycasting against Graphics - Hit Count: {list.Count}");
			foreach (RaycastResult item in list)
			{
				Debug.Log("Hit " + item.gameObject.name, item.gameObject);
			}
		}
		if (versionText != null && _networkMode != AggroNetworkManager.networkMode)
		{
			_networkMode = AggroNetworkManager.networkMode;
			if (AggroNetworkManager.isSinglePlayer)
			{
				versionText.text = GameUtil.gameVersionFull + " Single Player";
			}
			else
			{
				versionText.text = $"{GameUtil.gameVersionFull} {_networkMode}";
			}
		}
	}

	public void OnInputControlGained()
	{
		AggroInputManager.EnableUIModule();
	}

	public void OnInputControlLost()
	{
		AggroInputManager.DisableUIModule();
	}

	public void OnConsoleClosed()
	{
		AggroInputManager.RemoveController(this);
	}

	private void LateUpdate()
	{
		if (_targetFPS > 0)
		{
			float num = 1f / (float)_targetFPS;
			double num2 = Time.realtimeSinceStartupAsDouble + (double)num;
			while (Time.realtimeSinceStartupAsDouble < num2)
			{
			}
		}
	}

	private void FixedUpdate()
	{
		if (_simMS > 0)
		{
			double num = Time.realtimeSinceStartupAsDouble + (double)((float)_simMS / 1000f);
			while (Time.realtimeSinceStartupAsDouble < num)
			{
			}
		}
	}

	[DevCmd("debug", "Various generic debug cmds.\r\n\r\nUsage:\r\n    debug -boxdebug\r\n        Toggles showing Box Debug visuals.\r\n\r\n    debug -fps <target>\r\n\r\n    debug -sim <time_ms>", new string[] { "boxdebug", "fps", "sim" })]
	[DevCmdVerify("^-boxdebug$")]
	[DevCmdVerify("^-fps [0-9]+")]
	[DevCmdVerify("^-sim [0-9]+")]
	private static void DebugDevCmd(DevCmdArg[] args)
	{
		switch (args[0].name)
		{
		case "boxdebug":
			BoxDebug.debugEnabled = !BoxDebug.debugEnabled;
			if (BoxDebug.debugEnabled)
			{
				Debug.Log("Box Debug Enabled!");
			}
			else
			{
				Debug.Log("Box Debug Disabled!");
			}
			break;
		case "fps":
		{
			if (int.TryParse(args[0].value, out var result2))
			{
				if (result2 > 0)
				{
					_targetFPS = result2;
				}
				else if (result2 == 0)
				{
					_targetFPS = -1;
				}
				else
				{
					Debug.LogWarning($"Invalid target fps ({result2})");
				}
			}
			else
			{
				Debug.LogWarning("Could not parse target! (" + args[0].value + ")");
			}
			break;
		}
		case "sim":
		{
			if (int.TryParse(args[0].value, out var result))
			{
				if (result >= 0)
				{
					_simMS = result;
				}
				else
				{
					Debug.LogWarning($"Invalid target sim ms ({result})");
				}
			}
			else
			{
				Debug.LogWarning("Could not parse ms! (" + args[0].value + ")");
			}
			break;
		}
		default:
			Debug.LogWarning("Unknown parameter! (" + args[0].name + ")");
			break;
		}
	}
}
