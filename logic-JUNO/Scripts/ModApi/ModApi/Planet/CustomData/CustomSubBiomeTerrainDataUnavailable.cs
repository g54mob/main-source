using System.Xml.Linq;
using ModApi.Ui.Inspector;

namespace ModApi.Planet.CustomData
{
	public class CustomSubBiomeTerrainDataUnavailable : CustomSubBiomeTerrainData, ICustomObjectInspectorModel
	{
		private string _id;

		public bool CreateGroup => false;

		public override string Id => _id;

		public string Xml { get; private set; }

		public CustomSubBiomeTerrainDataUnavailable(string id, string xml)
		{
			_id = id;
			Xml = xml;
		}

		public override void ApplyBiomeData(CustomPlanetVertexData customPlanetVertexData, float biomeStrength)
		{
		}

		public void CreateModel(GroupModel model, IObjectInspector objectInspector)
		{
			model.AddAndBuild(new TextInputModel("Mod Not Installed", () => Xml, delegate(string x)
			{
				Xml = x;
			}));
		}

		public override void RestoreFromXml(XElement xmlCustomData)
		{
		}

		public override XElement SaveXml(XElement customDataXml)
		{
			if (!string.IsNullOrWhiteSpace(Xml))
			{
				return XElement.Parse(Xml);
			}
			return null;
		}
	}
}
