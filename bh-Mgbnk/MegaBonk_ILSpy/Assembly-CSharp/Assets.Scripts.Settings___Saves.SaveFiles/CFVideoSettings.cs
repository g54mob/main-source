using System;
using System.Collections.Generic;

namespace Assets.Scripts.Settings___Saves.SaveFiles;

public class CFVideoSettings : CFSettings
{
	public int resolution;

	public int target_monitor;

	public int fullscreen_mode;

	public int vsync;

	public float fps_limit;

	public float fov;

	public float camera_distance;

	public int grass_quality;

	public int shadow_quality;

	public int shadow_resolution;

	public int anti_aliasing;

	public int soft_particles;

	public int bloom;

	public int motion_blur;

	public int ambient_occlusion;

	public List<SettingHeader> GetHeaders()
	{
		List<SettingHeader> list = new List<SettingHeader>();
		SettingHeader settingHeader = new SettingHeader(0, "SCREEN");
		settingHeader._002Ector(0, "SCREEN");
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
				goto IL_01de;
			}
			int num = default(int);
			items[num] = settingHeader;
		}
		SettingHeader settingHeader2 = new SettingHeader(7, "GRAPHICS");
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
		goto IL_01de;
		IL_01de:
		return (List<SettingHeader>)(object)new IndexOutOfRangeException();
	}

	public CFVideoSettings()
	{
		//IL_000f: Expected I4, but got I8
		resolution = -1;
		fullscreen_mode = 1;
		vsync = 1;
		fps_limit = 144f;
		fov = 85f;
		grass_quality = 1;
		shadow_quality = 1;
		soft_particles = 1;
		bloom = 1;
		ambient_occlusion = 1;
		base._002Ector();
	}
}
