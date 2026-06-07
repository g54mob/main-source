using System;
using System.Collections.Generic;
using ModApi.Craft;

namespace Assets.Scripts.Craft
{
	public class ThemeManager
	{
		private class ThemeWrapper
		{
			public int NumRequests { get; set; }

			public ITheme Theme { get; set; }

			public ThemeData ThemeData { get; set; }
		}

		private List<ThemeWrapper> _themeWrappers = new List<ThemeWrapper>();

		public void DestroyAllThemes()
		{
			while (_themeWrappers.Count > 0)
			{
				DestroyTheme(_themeWrappers[0]);
			}
			_themeWrappers.Clear();
		}

		public void OnApplicationFocus()
		{
			foreach (ThemeWrapper themeWrapper in _themeWrappers)
			{
				themeWrapper.Theme.RefreshMaterialProperties();
			}
		}

		public void ReleaseTheme(ITheme theme)
		{
			ThemeWrapper themeWrapper = GetThemeWrapper(theme);
			themeWrapper.NumRequests--;
			if (themeWrapper.NumRequests <= 0)
			{
				DestroyTheme(themeWrapper);
			}
		}

		public ITheme RequestTheme(ThemeData themeData)
		{
			if (themeData.Theme == null)
			{
				themeData.Theme = new Theme(themeData);
				ThemeWrapper item = new ThemeWrapper
				{
					NumRequests = 1,
					Theme = themeData.Theme,
					ThemeData = themeData
				};
				_themeWrappers.Add(item);
			}
			else
			{
				GetThemeWrapper(themeData.Theme).NumRequests++;
			}
			return themeData.Theme;
		}

		private void DestroyTheme(ThemeWrapper themeWrapper)
		{
			_themeWrappers.Remove(themeWrapper);
			(themeWrapper.Theme as IDisposable).Dispose();
		}

		private ThemeWrapper GetThemeWrapper(ITheme theme)
		{
			foreach (ThemeWrapper themeWrapper in _themeWrappers)
			{
				if (themeWrapper.Theme == theme)
				{
					return themeWrapper;
				}
			}
			return null;
		}
	}
}
