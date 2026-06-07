using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace Assets.Scripts.Craft
{
	public class AircraftThemes
	{
		public ThemeData CustomTheme { get; private set; }

		public List<ThemeData> Themes { get; private set; }

		public AircraftThemes(string path)
		{
			Themes = new List<ThemeData>();
			LoadXml(path);
		}

		public ThemeData GetTheme(string name)
		{
			foreach (ThemeData theme in Themes)
			{
				if (theme.Name == name)
				{
					return theme;
				}
			}
			return Themes.FirstOrDefault();
		}

		private void LoadXml(string path)
		{
			XDocument xDocument = XDocument.Load(path);
			try
			{
				foreach (XElement item in xDocument.Element("Themes").Elements("Theme"))
				{
					ThemeData themeData = new ThemeData(item, 1);
					Themes.Add(themeData);
					if (themeData.Name == "Custom")
					{
						CustomTheme = themeData;
					}
				}
			}
			catch (Exception innerException)
			{
				throw new Exception("Failed to parse aircraft themes XML.", innerException);
			}
		}
	}
}
