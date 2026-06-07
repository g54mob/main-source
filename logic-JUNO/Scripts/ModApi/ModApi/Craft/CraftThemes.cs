using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using ModApi.Exceptions;

namespace ModApi.Craft
{
	public class CraftThemes
	{
		public List<ThemeData> Themes { get; private set; }

		public CraftThemes(string xml)
		{
			Themes = new List<ThemeData>();
			LoadXml(xml);
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

		private void LoadXml(string xml)
		{
			XDocument xDocument = XDocument.Parse(xml);
			try
			{
				foreach (XElement item2 in xDocument.Element("Themes").Elements("Theme"))
				{
					ThemeData item = new ThemeData(item2, 1);
					Themes.Add(item);
				}
			}
			catch (Exception inner)
			{
				throw new GameException("Failed to parse craft themes XML.", inner);
			}
		}
	}
}
