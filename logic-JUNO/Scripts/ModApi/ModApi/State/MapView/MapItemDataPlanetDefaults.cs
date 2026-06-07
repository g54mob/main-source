using System.Xml.Linq;

namespace ModApi.State.MapView
{
	public class MapItemDataPlanetDefaults : MapItemDataDefaults
	{
		private static class XNodeNames
		{
			public const string ShowSpheresOfInfluenceAttribute = "showSpheresOfInfluence";
		}

		private bool _defaultShowSpheresOfInfluence;

		private bool _showSpheresOfInfluence;

		public bool ShowSpheresOfInfluence
		{
			get
			{
				return _showSpheresOfInfluence;
			}
			set
			{
				bool showSpheresOfInfluence = _showSpheresOfInfluence;
				_showSpheresOfInfluence = value;
				if (showSpheresOfInfluence != _showSpheresOfInfluence)
				{
					this.ShowSpheresOfInfluenceChanged?.Invoke(value);
					RaiseAnyDefaultValueChanged(value);
				}
			}
		}

		public event PropertyChangedHandler<bool> ShowSpheresOfInfluenceChanged;

		public MapItemDataPlanetDefaults(bool defaultShowOrbitLines, bool defaultShowIcons, bool defaultShowSpheresOfInfluence)
			: base(defaultShowOrbitLines, defaultShowIcons)
		{
			Initialize(defaultShowSpheresOfInfluence, defaultShowSpheresOfInfluence);
		}

		public MapItemDataPlanetDefaults(XElement defaultsElement, bool defaultShowOrbitLines, bool defaultShowIcons, bool defaultShowSpheresOfInfluence)
			: base(defaultsElement, defaultShowOrbitLines, defaultShowIcons)
		{
			bool showSpheresOfInfluence = defaultShowSpheresOfInfluence;
			if (defaultsElement != null)
			{
				showSpheresOfInfluence = Utilities.GetBoolAttribute(defaultsElement, "showSpheresOfInfluence", defaultShowSpheresOfInfluence);
			}
			Initialize(showSpheresOfInfluence, defaultShowSpheresOfInfluence);
		}

		public override XElement GenerateXml(string defaultsElementName)
		{
			XElement xElement = base.GenerateXml(defaultsElementName);
			xElement.Add(new XAttribute("showSpheresOfInfluence", ShowSpheresOfInfluence));
			return xElement;
		}

		public override void ResetToDefault()
		{
			base.ResetToDefault();
			ShowSpheresOfInfluence = _defaultShowSpheresOfInfluence;
		}

		private void Initialize(bool showSpheresOfInfluence, bool defaultShowSpheresOfInfluence)
		{
			_showSpheresOfInfluence = showSpheresOfInfluence;
			_defaultShowSpheresOfInfluence = defaultShowSpheresOfInfluence;
		}
	}
}
