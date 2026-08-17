using System;
using System.Collections.Generic;
using Cpp2ILInjected;

namespace Assets.Scripts.Settings___Saves.SaveFiles;

public class CFControlSettings : CFSettings
{
	public float sensitivity;

	public float look_smoothing;

	public float controller_sensitivity;

	public int inverted_horizontal_axis;

	public int inverted_vertical_axis;

	public int hold_crouch;

	public int hold_aim;

	public int rotate_camera_with_arrow_keys;

	public int select_upgrades_with_number_keys;

	public string keyboard_move_forward;

	public string keyboard_move_backward;

	public string keyboard_move_left;

	public string keyboard_move_right;

	public string keyboard_jump;

	public string keyboard_interact;

	public string keyboard_slide;

	public string keyboard_aim;

	public string keyboard_quick_reset;

	public string map_overlay;

	public int controller;

	public float controller_vibration;

	public string controller_jump;

	public string controller_interact;

	public string controller_slide;

	public string controller_aim;

	public string controller_quick_reset;

	public string controller_map_overlay;

	public int pause_on_controller_disconnect;

	public int space_navigation;

	public int horizontal_navigation;

	public string keyboard_jump_ignore_extra_jumps;

	public string keyboard_hold_to_wallrun;

	public List<SettingHeader> GetHeaders()
	{
		List<SettingHeader> list = new List<SettingHeader>();
		SettingHeader settingHeader = new SettingHeader(0, "GENERAL");
		settingHeader._002Ector(0, "GENERAL");
		int version = list._version + 1;
		list._version = version;
		SettingHeader[] items = list._items;
		if (list._size >= items.Length)
		{
			((List<object>)(object)list).AddWithResize((object)settingHeader);
		}
		else
		{
			int size = list._size + 1;
			list._size = size;
			if (list._size >= items.Length)
			{
				goto IL_0472;
			}
			int num = default(int);
			items[num] = settingHeader;
		}
		SettingHeader settingHeader2 = new SettingHeader(9, "KEYBOARD INPUT");
		int version2 = list._version + 1;
		list._version = version2;
		SettingHeader[] items2 = list._items;
		if (list._size >= items2.Length)
		{
			((List<object>)(object)list).AddWithResize((object)settingHeader2);
		}
		else
		{
			int size2 = list._size + 1;
			list._size = size2;
			if (list._size >= items2.Length)
			{
				goto IL_0472;
			}
			int num2 = default(int);
			items2[num2] = settingHeader2;
		}
		SettingHeader settingHeader3 = new SettingHeader(19, "CONTROLLER INPUT");
		int version3 = list._version + 1;
		list._version = version3;
		SettingHeader[] items3 = list._items;
		if (list._size >= items3.Length)
		{
			((List<object>)(object)list).AddWithResize((object)settingHeader3);
		}
		else
		{
			int size3 = list._size + 1;
			list._size = size3;
			if (list._size >= items3.Length)
			{
				goto IL_0472;
			}
			int num3 = default(int);
			items3[num3] = settingHeader3;
		}
		SettingHeader settingHeader4 = new SettingHeader(27, "EXTRA");
		int version4 = list._version + 1;
		list._version = version4;
		SettingHeader[] items4 = list._items;
		if (list._size >= items4.Length)
		{
			((List<object>)(object)list).AddWithResize((object)settingHeader4);
		}
		else
		{
			int size4 = list._size + 1;
			list._size = size4;
			if (list._size >= items4.Length)
			{
				goto IL_0472;
			}
			int num4 = default(int);
			items4[num4] = settingHeader4;
		}
		SettingHeader settingHeader5 = new SettingHeader(30, "ADVANCED");
		int version5 = list._version + 1;
		list._version = version5;
		SettingHeader[] items5 = list._items;
		if (list._size >= items5.Length)
		{
			((List<object>)(object)list).AddWithResize((object)settingHeader5);
			return list;
		}
		int size5 = list._size + 1;
		list._size = size5;
		if (list._size < items5.Length)
		{
			int num5 = default(int);
			items5[num5] = settingHeader5;
			return list;
		}
		goto IL_0472;
		IL_0472:
		return (List<SettingHeader>)(object)new IndexOutOfRangeException();
	}

	public CFControlSettings()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1831725C7]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		sensitivity = 1f;
		look_smoothing = 0.6f;
		controller_sensitivity = 3.2f;
		hold_crouch = 1;
		select_upgrades_with_number_keys = 1;
		keyboard_move_forward = "Move Vertical";
		keyboard_move_backward = "Move Vertical";
		keyboard_move_left = "Move Horizontal";
		keyboard_move_right = "Move Horizontal";
		keyboard_jump = "Jump";
		keyboard_interact = "Interact";
		keyboard_slide = "Slide";
		keyboard_aim = "Aim";
		keyboard_quick_reset = "QuickReset";
		map_overlay = "MapOverlay";
		controller_vibration = 1f;
		controller_jump = "Jump";
		controller_interact = "Interact";
		controller_slide = "Slide";
		controller_aim = "Aim";
		controller_quick_reset = "QuickReset";
		controller_map_overlay = "MapOverlay";
		pause_on_controller_disconnect = 1;
		space_navigation = 1;
		keyboard_jump_ignore_extra_jumps = "Jump Bhop";
		keyboard_hold_to_wallrun = "Wallrun";
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1803321E0");
	}
}
