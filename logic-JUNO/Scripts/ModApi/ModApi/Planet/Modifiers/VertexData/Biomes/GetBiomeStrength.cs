using System.Xml.Linq;
using ModApi.Planet.Modifiers.Attributes;
using ModApi.Ui.Inspector;
using UnityEngine;

namespace ModApi.Planet.Modifiers.VertexData.Biomes
{
	[PlanetModifierInfo("Get Biome Strength", "A planet modifier that gets the strength of a biome and stores it in a data output.")]
	public class GetBiomeStrength : VertexDataCommonPassPlanetModifier, ICustomObjectInspectorModel, IBiomeListModifiedHandler
	{
		[SerializeField]
		private int _biomeIndex;

		[SerializeField]
		[Range(0f, 9f)]
		[DataSlot(DataSlotType.Output, "Output", false, true, Tooltip = "The output in which to store the biome strength (a value between 0 and 1).")]
		private int _dataIndexOutput;

		public bool CreateGroup => false;

		public override VertexDataPlanetModifierPassType[] SupportedPassTypes => new VertexDataPlanetModifierPassType[4]
		{
			VertexDataPlanetModifierPassType.Height,
			VertexDataPlanetModifierPassType.HeightFinal,
			VertexDataPlanetModifierPassType.Final,
			VertexDataPlanetModifierPassType.Water
		};

		public override VertexDataType VertexDataType => VertexDataType.Both;

		public void CreateModel(GroupModel model, IObjectInspector objectInspector)
		{
			model.AddAndBuild(new SliderModel("Biome", () => _biomeIndex, delegate(float x)
			{
				_biomeIndex = (int)x;
			}, 0f, base.TerrainData.Biomes.Count - 1, wholeNumbers: true, allowManualInput: false)).Build(delegate(SliderModel x)
			{
				x.ValueFormatter = (float i) => i + " : " + base.TerrainData.Biomes[(int)i].Name;
			}).Build(delegate(SliderModel x)
			{
				x.Tooltip = "The biome for which to get the strength value (a value between 0 and 1)";
			});
		}

		public override void GetVertexData(PlanetVertexDataInput input, PlanetVertexData data)
		{
			data.Data[_dataIndexOutput] = data.Biomes[_biomeIndex].Strength;
		}

		public override void GetVertexData(PlanetVertexDataInput input, PlanetBiomeVertexData data)
		{
			data.Data[_dataIndexOutput] = data.CommonData.Biomes[_biomeIndex].Strength;
		}

		public void OnBiomeAdded(int index)
		{
			if (_biomeIndex >= index)
			{
				_biomeIndex++;
			}
		}

		public void OnBiomeDeleted(int index)
		{
			if (_biomeIndex > index)
			{
				_biomeIndex--;
			}
		}

		public override void SaveXml(XElement xml)
		{
			base.SaveXml(xml);
			xml.SetAttributeValue("biomeIndex", _biomeIndex);
			xml.SetAttributeValue("dataIndexOutput", _dataIndexOutput);
		}

		protected override void RestoreXml(XElement xml)
		{
			base.RestoreXml(xml);
			_biomeIndex = (int)xml.Attribute("biomeIndex");
			_dataIndexOutput = (int)xml.Attribute("dataIndexOutput");
		}
	}
}
