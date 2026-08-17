using System;
using System.Collections.Generic;

namespace Assets.Scripts.Settings___Saves.SaveFiles.ConfigSettingsTypes;

public class CFAudioSettings : CFSettings
{
	public float master_volume = 0.69f;

	public float music = 0.48f;

	public float game_sfx = 1f;

	public float ambience = 1f;

	public float ui = 1f;

	public float xp_and_gold = 1f;

	public List<SettingHeader> GetHeaders()
	{
		List<SettingHeader> list = new List<SettingHeader>();
		string header = default(string);
		SettingHeader settingHeader = new SettingHeader(0, header);
		settingHeader._002Ector(0, header);
		settingHeader.index = 0;
		settingHeader.header = "AUDIO";
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
