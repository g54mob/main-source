using System;
using System.Collections.Generic;

namespace Assets.Scripts.Settings___Saves.SaveFiles;

[Serializable]
public class CFGameSettings : CFSettings
{
	public int camera_shake = 1;

	public float input_delay = 2f;

	public int enemy_targeting_mode;

	public float random_enemy_targeting = 0.75f;

	public int language;

	public int show_tips = 1;

	public float minimap_size = 1.35f;

	public int minimap_rotation = 1;

	public int hp_bar_color;

	public float crosshair_height = 0.5f;

	public float crosshair_size = 0.9f;

	public float crosshair_alpha = 1f;

	public int hide_leaderboards;

	public int upload_score_to_leaderboard = 1;

	public int quick_reset = 1;

	public int debug_shrines;

	public int debug_fps;

	public int debug_speed;

	public int debug_ram;

	public int debug_enemy_scaling;

	public int pege_mode;

	public int unlock_all;

	public int auto_select_upgrades;

	public float auto_select_after_level = 200f;

	public int show_advanced_settings;

	public int show_hud = 1;

	public int skip_chest_animation;

	public int show_item_feed;

	public int skip_portal_animation;

	public int enable_silver_pots = 1;

	public float quick_reset_time = 1f;

	public int super_quick_resets;

	public List<SettingHeader> GetHeaders()
	{
		List<SettingHeader> list = new List<SettingHeader>();
		SettingHeader settingHeader = new SettingHeader(0, "GAME");
		settingHeader._002Ector(0, "GAME");
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
				goto IL_0396;
			}
			int num = default(int);
			items[num] = settingHeader;
		}
		SettingHeader settingHeader2 = new SettingHeader(4, "UI");
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
				goto IL_0396;
			}
			int num2 = default(int);
			items2[num2] = settingHeader2;
		}
		SettingHeader settingHeader3 = new SettingHeader(9, "OTHER");
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
				goto IL_0396;
			}
			int num3 = default(int);
			items3[num3] = settingHeader3;
		}
		SettingHeader settingHeader4 = new SettingHeader(25, "ADVANCED");
		int version4 = list._version + 1;
		list._version = version4;
		SettingHeader[] items4 = list._items;
		if (list._size >= items4.Length)
		{
			((List<object>)(object)list).AddWithResize((object)settingHeader4);
			return list;
		}
		int size4 = list._size + 1;
		list._size = size4;
		if (list._size < items4.Length)
		{
			int num4 = default(int);
			items4[num4] = settingHeader4;
			return list;
		}
		goto IL_0396;
		IL_0396:
		return (List<SettingHeader>)(object)new IndexOutOfRangeException();
	}
}
