using System;
using System.Collections.Generic;
using Assets.Scripts.Settings___Saves.SaveFiles;

namespace Assets.Scripts.Saves___Serialization.SaveFiles.Configs.ConfigSettingsTypes;

public class CFOtherSettings : CFSettings
{
	public List<SettingHeader> GetHeaders()
	{
		List<SettingHeader> list = new List<SettingHeader>();
		string header = default(string);
		SettingHeader settingHeader = new SettingHeader(0, header);
		settingHeader._002Ector(0, header);
		settingHeader.index = 0;
		settingHeader.header = "SAVES";
		int version = list._version + 1;
		list._version = version;
		SettingHeader[] items = list._items;
		if (list._size >= items.Length)
		{
			((List<object>)(object)list).AddWithResize((object)settingHeader);
			return list;
		}
		int size = list._size + 1;
		list._size = size;
		if (list._size < items.Length)
		{
			int num = default(int);
			items[num] = settingHeader;
			return list;
		}
		return (List<SettingHeader>)(object)new IndexOutOfRangeException();
	}
}
