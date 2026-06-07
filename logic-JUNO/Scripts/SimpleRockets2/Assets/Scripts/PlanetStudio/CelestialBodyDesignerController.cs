using ModApi.PlanetStudio;
using UI.Xml;

namespace Assets.Scripts.PlanetStudio
{
	public class CelestialBodyDesignerController : XmlLayoutController, IPlanetStudioInitialized
	{
		private CelestialBodyDesignerScript _designer;

		public override void LayoutRebuilt(ParseXmlResult parseResult)
		{
			base.LayoutRebuilt(parseResult);
		}

		public void OnInitialized(IPlanetStudioUI planetStudioUI)
		{
			_designer = planetStudioUI.PlanetStudio.CelestialBodyDesigner as CelestialBodyDesignerScript;
		}
	}
}
