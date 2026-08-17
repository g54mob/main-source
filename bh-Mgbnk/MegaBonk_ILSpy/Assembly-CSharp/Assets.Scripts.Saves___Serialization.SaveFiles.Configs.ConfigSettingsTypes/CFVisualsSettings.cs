using System;
using System.Collections.Generic;
using Assets.Scripts.Settings___Saves.SaveFiles;

namespace Assets.Scripts.Saves___Serialization.SaveFiles.Configs.ConfigSettingsTypes;

public class CFVisualsSettings : CFSettings
{
	public int damage_numbers = 1;

	public int damage_flash = 1;

	public int low_hp_effects = 1;

	public float particle_opacity = 1f;

	public int particle_auto_opacity = 1;

	public int warning_color;

	public int xp_gold_hud = 1;

	public List<SettingHeader> GetHeaders()
	{
		//IL_0107: Expected O, but got I
		List<SettingHeader> list = new List<SettingHeader>();
		string header = default(string);
		SettingHeader settingHeader = new SettingHeader(0, header);
		settingHeader._002Ector(0, header);
		settingHeader.index = 0;
		settingHeader.header = "VISUALS";
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
				goto IL_0211;
			}
			int num = default(int);
			items[num] = settingHeader;
		}
		SettingHeader settingHeader2 = new SettingHeader(0, (string)0);
		settingHeader2.index = 6;
		settingHeader2.header = "ADVANCED";
		int version2 = list._version + 1;
		list._version = version2;
		SettingHeader[] items2 = list._items;
		if (list._size >= items2.Length)
		{
			((List<object>)(object)list).AddWithResize((object)settingHeader2);
			return list;
		}
		int size2 = list._size + 1;
		list._size = size2;
		if (list._size < items2.Length)
		{
			int num2 = default(int);
			items2[num2] = settingHeader2;
			return list;
		}
		goto IL_0211;
		IL_0211:
		return (List<SettingHeader>)(object)new IndexOutOfRangeException();
	}
}
