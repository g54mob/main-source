using System.Collections.Generic;
using Rewired;
using UnityEngine;

public class RInput : MonoBehaviour
{
	public enum Mode
	{
		Play = 0,
		Ui = 1,
		Help = 2
	}

	public struct ActionInfo
	{
		public string id;

		public string textCode;
	}

	private class ActionMask
	{
		private byte[] bytes = new byte[16];

		public bool Get(int actionIndex)
		{
			int num = actionIndex / 8;
			int num2 = actionIndex % 8;
			return num < bytes.Length && (bytes[num] & (1 << num2)) != 0;
		}

		public void Set(int actionIndex, bool val)
		{
			int num = actionIndex / 8;
			int num2 = actionIndex % 8;
			if (num < bytes.Length)
			{
				if (val)
				{
					bytes[num] |= (byte)(1 << num2);
				}
				else
				{
					bytes[num] &= (byte)(~(1 << num2));
				}
			}
		}

		public void Set(int[] actionIndexes, bool val)
		{
			foreach (int actionIndex in actionIndexes)
			{
				Set(actionIndex, val);
			}
		}

		public void Clear()
		{
			for (int i = 0; i < bytes.Length; i++)
			{
				bytes[i] = 0;
			}
		}
	}

	public class ActionDecoder
	{
		public readonly string actionId;

		private string cachedName;

		private Controller activeController;

		public string name
		{
			get
			{
				if (cachedName != null)
				{
					return cachedName;
				}
				activeController = ReInput.controllers.GetLastActiveController();
				int num = ReInput.mapping.GetActionId(actionId);
				if (activeController == null)
				{
					ActionElementMap firstElementMapWithAction = player.controllers.maps.GetFirstElementMapWithAction(actionId, true);
					if (firstElementMapWithAction != null)
					{
						cachedName = firstElementMapWithAction.elementIdentifierName;
						return cachedName;
					}
				}
				else if (activeController.type == ControllerType.Joystick)
				{
					foreach (JoystickMap map in player.controllers.maps.GetMaps<JoystickMap>(activeController.id))
					{
						foreach (ActionElementMap allMap in map.AllMaps)
						{
							if (allMap.actionId == num)
							{
								cachedName = "Joy " + allMap.elementIdentifierName;
								return cachedName;
							}
						}
					}
				}
				else if (activeController.type == ControllerType.Keyboard || activeController.type == ControllerType.Mouse)
				{
					foreach (KeyboardMap allMap2 in player.controllers.maps.GetAllMaps<KeyboardMap>())
					{
						foreach (ActionElementMap allMap3 in allMap2.AllMaps)
						{
							if (allMap3.actionId == num)
							{
								cachedName = allMap3.elementIdentifierName;
								return cachedName;
							}
						}
					}
					foreach (MouseMap allMap4 in player.controllers.maps.GetAllMaps<MouseMap>())
					{
						foreach (ActionElementMap allMap5 in allMap4.AllMaps)
						{
							if (allMap5.actionId == num)
							{
								cachedName = allMap5.elementIdentifierName;
								return cachedName;
							}
						}
					}
				}
				cachedName = null;
				return "?";
			}
		}

		public ActionDecoder(string actionId_)
		{
			actionId = actionId_;
		}

		public bool CheckChanged()
		{
			if (!ReInput.isReady || activeController != ReInput.controllers.GetLastActiveController())
			{
				cachedName = null;
				return true;
			}
			return false;
		}
	}

	private static int[] actionIndexes_Play = new int[6] { 0, 1, 2, 3, 4, 53 };

	private static int[] actionIndexes_Ui = new int[15]
	{
		18, 19, 17, 10, 21, 22, 51, 52, 37, 38,
		44, 47, 48, 49, 50
	};

	private static ActionMask actionMask = new ActionMask();

	private static Mode mode_ = Mode.Play;

	private static Rewired.Player player_;

	private static Vector2 mousePosition_ = new Vector2(Screen.width / 2, Screen.height / 2);

	private static int controllerMouseEnabledUntilFrame = 0;

	private static int mutedUntilFrame = 0;

	private static List<ActionInfo> actionInfos_;

	public static Mode mode
	{
		get
		{
			return mode_;
		}
		set
		{
			mode_ = value;
			player.controllers.maps.SetMapsEnabled(mode == Mode.Play, "Play");
			player.controllers.maps.SetMapsEnabled(mode == Mode.Ui, "Ui");
			Cursor.lockState = CursorLockMode.None;
			Cursor.lockState = CursorLockMode.Locked;
			if (mode == Mode.Play)
			{
				actionMask.Set(actionIndexes_Play, true);
			}
			else if (mode == Mode.Ui)
			{
				actionMask.Set(actionIndexes_Ui, true);
			}
		}
	}

	private static Rewired.Player player
	{
		get
		{
			Rewired.Player player = ReInput.players.GetPlayer(0);
			if (player != player_)
			{
				player_ = player;
				mode = mode_;
			}
			return player;
		}
	}

	public static bool anyButton
	{
		get
		{
			Rewired.Player player = RInput.player;
			if (player == null || muted)
			{
				return false;
			}
			return player.GetAnyButton() || ReInput.controllers.Mouse.GetAnyButton();
		}
	}

	public static Vector2 physicalMousePosition
	{
		get
		{
			return ReInput.controllers.Mouse.screenPosition;
		}
	}

	public static Vector2 mousePosition
	{
		get
		{
			return mousePosition_;
		}
		set
		{
			Vector2 vector = new Vector2((float)Resolution.screenW / (float)Resolution.bufferW, (float)Resolution.screenH / (float)Resolution.bufferH);
			mousePosition_.x = Mathf.Max(vector.x, Mathf.Min((float)Resolution.screenW - vector.x, value.x));
			mousePosition_.y = Mathf.Max(vector.y, Mathf.Min((float)Resolution.screenH - vector.y, value.y));
		}
	}

	public static bool mouseIsActive
	{
		get
		{
			if (!ReInput.isReady)
			{
				return false;
			}
			Controller lastActiveController = ReInput.controllers.GetLastActiveController();
			return lastActiveController != null && lastActiveController.type == ControllerType.Mouse;
		}
	}

	private static bool controllerMouseEnabledForOneFrame
	{
		get
		{
			return controllerMouseEnabledUntilFrame > 0 && Time.frameCount <= controllerMouseEnabledUntilFrame;
		}
	}

	private static bool muted
	{
		get
		{
			return mutedUntilFrame > 0 && Time.frameCount <= mutedUntilFrame;
		}
	}

	public static List<ActionInfo> actionInfos
	{
		get
		{
			if (actionInfos_ == null && ReInput.isReady)
			{
				actionInfos_ = new List<ActionInfo>();
				foreach (InputAction action in ReInput.mapping.Actions)
				{
					actionInfos_.Add(new ActionInfo
					{
						id = action.name,
						textCode = "@" + action.name.Replace(" ", "-")
					});
				}
			}
			return actionInfos_;
		}
	}

	public static int GetActionIndex(string actionId)
	{
		return ReInput.mapping.GetActionId(actionId);
	}

	private static bool CheckMask(Rewired.Player player, int actionIndex)
	{
		if (actionMask.Get(actionIndex))
		{
			if (!player.GetButton(actionIndex))
			{
				actionMask.Set(actionIndex, false);
				return true;
			}
			return false;
		}
		return true;
	}

	public static bool GetButton(int actionIndex)
	{
		Rewired.Player player = RInput.player;
		if (player == null || muted)
		{
			return false;
		}
		return CheckMask(player, actionIndex) && player.GetButton(actionIndex);
	}

	public static bool GetButtonDown(int actionIndex)
	{
		Rewired.Player player = RInput.player;
		if (player == null || muted)
		{
			return false;
		}
		return player.GetButtonDown(actionIndex);
	}

	public static bool GetButtonUp(int actionIndex)
	{
		Rewired.Player player = RInput.player;
		if (player == null || muted)
		{
			return false;
		}
		return player.GetButtonUp(actionIndex);
	}

	public static bool GetButtonRepeating(int actionIndex)
	{
		Rewired.Player player = RInput.player;
		if (player == null || muted)
		{
			return false;
		}
		return CheckMask(player, actionIndex) && player.GetButtonRepeating(actionIndex);
	}

	public static float GetAxis(int actionIndex)
	{
		Rewired.Player player = RInput.player;
		if (player == null || muted)
		{
			return 0f;
		}
		return player.GetAxis(actionIndex);
	}

	public static bool GetAxisAsButton(int actionIndex)
	{
		Rewired.Player player = RInput.player;
		if (player == null || muted)
		{
			return false;
		}
		return Mathf.Abs(player.GetAxis(actionIndex)) > 0.001f;
	}

	public static bool GetButtonDownWhileMuted(int actionIndex)
	{
		Rewired.Player player = RInput.player;
		if (player == null)
		{
			return false;
		}
		return player.GetButtonDown(actionIndex);
	}

	public static bool GetButtonWhileMuted(int actionIndex)
	{
		Rewired.Player player = RInput.player;
		if (player == null)
		{
			return false;
		}
		return player.GetButton(actionIndex);
	}

	public static bool GetAnyButtonWhileMuted()
	{
		Rewired.Player player = RInput.player;
		if (player == null)
		{
			return false;
		}
		return player.GetButton(4) || player.GetButton(53) || player.GetButton(17) || player.GetButton(10) || player.GetButton(21) || player.GetButton(22) || player.GetButton(44) || player.GetButton(50);
	}

	public static void EnableControllerMouseForOneFrame()
	{
		controllerMouseEnabledUntilFrame = Time.frameCount + 1;
	}

	public static void MuteForOneFrame()
	{
		mutedUntilFrame = Time.frameCount + 1;
	}

	public static void UnmuteImmediately()
	{
		mutedUntilFrame = 0;
	}

	public static void UpdateMousePosition(bool appHasFocus)
	{
		if (!appHasFocus)
		{
			Cursor.lockState = CursorLockMode.None;
			Cursor.visible = true;
			return;
		}
		Cursor.lockState = CursorLockMode.Locked;
		if (Cursor.lockState == CursorLockMode.Locked)
		{
			Cursor.visible = false;
			float num = 0f;
			float num2 = 0f;
			float deltaTime = Clock.active.deltaTime;
			if (mouseIsActive)
			{
				num = Mathf.Clamp(GetAxis(47), -500f, 500f) * 1.25f * (float)Resolution.screenW / (float)Resolution.bufferW;
				num2 = Mathf.Clamp(GetAxis(48), -500f, 500f) * 1.25f * (float)Resolution.screenH / (float)Resolution.bufferH;
			}
			else if (controllerMouseEnabledForOneFrame)
			{
				num = GetAxis(18) * deltaTime * 60f * 5f * (float)Resolution.screenW / (float)Resolution.bufferW;
				num2 = GetAxis(19) * deltaTime * 60f * 5f * (float)Resolution.screenH / (float)Resolution.bufferH;
			}
			mousePosition = new Vector2(mousePosition_.x + num, mousePosition_.y + num2);
		}
	}

	public static string GetActionName(string actionId)
	{
		int actionId2 = ReInput.mapping.GetActionId(actionId);
		Controller lastActiveController = ReInput.controllers.GetLastActiveController();
		if (lastActiveController == null)
		{
			ActionElementMap firstElementMapWithAction = player.controllers.maps.GetFirstElementMapWithAction(actionId, true);
			if (firstElementMapWithAction != null)
			{
				return firstElementMapWithAction.elementIdentifierName;
			}
		}
		else if (lastActiveController.type == ControllerType.Joystick)
		{
			foreach (JoystickMap map in player.controllers.maps.GetMaps<JoystickMap>(lastActiveController.id))
			{
				foreach (ActionElementMap allMap in map.AllMaps)
				{
					if (allMap.actionId == actionId2)
					{
						return allMap.elementIdentifierName;
					}
				}
			}
		}
		else if (lastActiveController.type == ControllerType.Keyboard || lastActiveController.type == ControllerType.Mouse)
		{
			foreach (KeyboardMap allMap2 in player.controllers.maps.GetAllMaps<KeyboardMap>())
			{
				foreach (ActionElementMap allMap3 in allMap2.AllMaps)
				{
					if (allMap3.actionId == actionId2)
					{
						return allMap3.elementIdentifierName;
					}
				}
			}
			foreach (MouseMap allMap4 in player.controllers.maps.GetAllMaps<MouseMap>())
			{
				foreach (ActionElementMap allMap5 in allMap4.AllMaps)
				{
					if (allMap5.actionId == actionId2)
					{
						return allMap5.elementIdentifierName;
					}
				}
			}
		}
		return "?";
	}
}
