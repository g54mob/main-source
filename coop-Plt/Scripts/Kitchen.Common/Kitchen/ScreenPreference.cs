using System;
using Platforms;
using UnityEngine;

namespace Kitchen
{
	public class ScreenPreference : Preference<ScreenPreference.ScreenData>
	{
		public struct ScreenData
		{
			public Resolution Resolution;

			public FullScreenMode FullScreenMode;
		}

		public ScreenPreference(Pref key, ScreenData default_value, Action<ScreenData> action = null)
			: base(key, default_value, action)
		{
		}

		public override void Save()
		{
			PlayerPrefs.SetInt($"{base.Key}/Width", base.Value.Resolution.width);
			PlayerPrefs.SetInt($"{base.Key}/Height", base.Value.Resolution.height);
			PlayerPrefs.SetInt($"{base.Key}/RefreshRate", base.Value.Resolution.refreshRate);
			PlayerPrefs.SetInt($"{base.Key}/FullScreenMode", (int)base.Value.FullScreenMode);
		}

		public override void Load()
		{
			if (PlatformSettings.SupportsGraphicsMenu)
			{
				if (PlayerPrefs.HasKey($"{base.Key}/Width") && PlayerPrefs.HasKey($"{base.Key}/Height") && PlayerPrefs.HasKey($"{base.Key}/RefreshRate") && PlayerPrefs.HasKey($"{base.Key}/FullScreenMode"))
				{
					base.Value = new ScreenData
					{
						Resolution = new Resolution
						{
							width = PlayerPrefs.GetInt($"{base.Key}/Width"),
							height = PlayerPrefs.GetInt($"{base.Key}/Height"),
							refreshRate = PlayerPrefs.GetInt($"{base.Key}/RefreshRate")
						},
						FullScreenMode = (FullScreenMode)PlayerPrefs.GetInt($"{base.Key}/FullScreenMode")
					};
				}
				else
				{
					base.Value = Default;
				}
			}
		}

		public override string SaveAsString()
		{
			return $"{base.Value.Resolution.width}/{base.Value.Resolution.height}/{base.Value.Resolution.refreshRate}/{(int)base.Value.FullScreenMode}";
		}

		public override void LoadFromString(string value)
		{
			string[] parts = value.Split('/');
			if (parts.Length == 4)
			{
				base.Value = new ScreenData
				{
					Resolution = new Resolution
					{
						width = as_int(parts[0]),
						height = as_int(parts[1]),
						refreshRate = as_int(parts[2])
					},
					FullScreenMode = (FullScreenMode)as_int(parts[3])
				};
			}
			int as_int(string str)
			{
				if (int.TryParse(parts[0], out var result))
				{
					return result;
				}
				return 0;
			}
		}
	}
}
