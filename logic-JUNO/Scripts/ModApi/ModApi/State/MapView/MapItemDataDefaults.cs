using System.Xml.Linq;

namespace ModApi.State.MapView
{
	public class MapItemDataDefaults
	{
		private static class XNodeNames
		{
			public const string ShowIconsAttribute = "showIcons";

			public const string ShowOrbitLinesAttribute = "showOrbitLines";
		}

		private bool _defaultShowIcons;

		private bool _defaultShowOrbitLines;

		private bool _showIcons;

		private bool _showOrbitLines;

		public bool ShowIcons
		{
			get
			{
				return _showIcons;
			}
			set
			{
				bool showIcons = _showIcons;
				_showIcons = value;
				if (showIcons != _showIcons)
				{
					this.ShowIconsChanged?.Invoke(value);
					RaiseAnyDefaultValueChanged(value);
				}
			}
		}

		public bool ShowOrbitLines
		{
			get
			{
				return _showOrbitLines;
			}
			set
			{
				bool showOrbitLines = _showOrbitLines;
				_showOrbitLines = value;
				if (showOrbitLines != _showOrbitLines)
				{
					this.ShowOrbitLineChanged?.Invoke(value);
					RaiseAnyDefaultValueChanged(value);
				}
			}
		}

		public event PropertyChangedHandler<bool> AnyDefaultValueChanged;

		public event PropertyChangedHandler<bool> ShowIconsChanged;

		public event PropertyChangedHandler<bool> ShowOrbitLineChanged;

		public MapItemDataDefaults(bool defaultShowOrbitLines, bool defaultShowIcons)
		{
			Initialize(defaultShowOrbitLines, defaultShowIcons, defaultShowOrbitLines, defaultShowIcons);
		}

		public MapItemDataDefaults(XElement defaultsElement, bool defaultShowOrbitLines, bool defaultShowIcons)
		{
			bool showIcons;
			bool showOrbitLines;
			if (defaultsElement != null)
			{
				showIcons = Utilities.GetBoolAttribute(defaultsElement, "showIcons", defaultShowIcons);
				showOrbitLines = Utilities.GetBoolAttribute(defaultsElement, "showOrbitLines", defaultShowOrbitLines);
			}
			else
			{
				showIcons = defaultShowIcons;
				showOrbitLines = defaultShowOrbitLines;
			}
			Initialize(showOrbitLines, showIcons, defaultShowOrbitLines, defaultShowIcons);
		}

		public virtual XElement GenerateXml(string defaultsElementName)
		{
			return new XElement(defaultsElementName, new XAttribute("showOrbitLines", ShowOrbitLines), new XAttribute("showIcons", ShowIcons));
		}

		public virtual void ResetToDefault()
		{
			ShowIcons = _defaultShowIcons;
			ShowOrbitLines = _defaultShowOrbitLines;
		}

		protected void RaiseAnyDefaultValueChanged(bool value)
		{
			this.AnyDefaultValueChanged?.Invoke(value);
		}

		private void Initialize(bool showOrbitLines, bool showIcons, bool defaultShowOrbitLines, bool defaultShowIcons)
		{
			_showOrbitLines = showOrbitLines;
			_showIcons = showIcons;
			_defaultShowOrbitLines = defaultShowOrbitLines;
			_defaultShowIcons = defaultShowIcons;
		}
	}
}
