using System;
using System.Collections.Generic;
using System.Reflection;
using System.Xml.Linq;
using ModApi.Common.Extensions;
using ModApi.Planet.Modifiers.Attributes;
using ModApi.Ui.Inspector;
using UnityEngine;

namespace ModApi.Planet.Modifiers.VertexData
{
	[PlanetModifierInfo("Get Height", "A planet modifier used to get the current height of the celestial body and store that value in a data output.")]
	public class GetHeight : VertexDataCommonPassPlanetModifier, ICustomInspectorFields
	{
		private enum GetHeightType
		{
			Default = 0,
			CommonHeight = 1,
			BiomeHeight = 2,
			CombinedHeight = 3
		}

		private List<FieldInfo> _biomePassFields;

		private List<FieldInfo> _commonPassFields;

		[SerializeField]
		[Range(0f, 9f)]
		[DataSlot(DataSlotType.Output, "Output", false, true, Tooltip = "The data output used to store the requested height value (in meters).")]
		private int _dataIndexOutput;

		[SerializeField]
		[InspectorProperty(null, false, Label = "Height Type", Order = 10, Tooltip = "The type of height value to retrieve. \n\nDefault: This is the common height in a non-biome pass and the biome height in a biome pass. \n\nCommon Height: Get the common height, regardless of pass. \n\nBiome Height: The biome height in a biome pass. This will retrieve the common height if ran in a non-biome pass. \n\nCombined Height: The biome height plus the common height in a biome pass. This will retrieve the common height if ran in a non-biome pass.")]
		private GetHeightType _heightType;

		[SerializeField]
		[InspectorProperty(null, false, Label = "Include Radius", Order = 0, Tooltip = "If enabled, the radius of the celestial body will be added to the output of the modifier. This is typically not enabled.")]
		private bool _includeRadius;

		private double _planetRadius;

		public override VertexDataType VertexDataType => VertexDataType.Both;

		public List<FieldInfo> GetInspectorFields()
		{
			if (!(base.Biome == null))
			{
				return _biomePassFields;
			}
			return _commonPassFields;
		}

		public override void GetVertexData(PlanetVertexDataInput input, PlanetVertexData data)
		{
			double num = (_includeRadius ? _planetRadius : 0.0);
			data.Data[_dataIndexOutput] = data.Height + num;
		}

		public override void GetVertexData(PlanetVertexDataInput input, PlanetBiomeVertexData data)
		{
			double num = (_includeRadius ? _planetRadius : 0.0);
			switch (_heightType)
			{
			case GetHeightType.Default:
			case GetHeightType.BiomeHeight:
				data.Data[_dataIndexOutput] = data.Height + num;
				break;
			case GetHeightType.CommonHeight:
				data.Data[_dataIndexOutput] = data.CommonData.Height + num;
				break;
			case GetHeightType.CombinedHeight:
				data.Data[_dataIndexOutput] = data.CommonData.Height + data.Height + num;
				break;
			default:
				throw new NotSupportedException();
			}
		}

		public override void Initialize(IPlanetData planetData)
		{
			base.Initialize(planetData);
			_planetRadius = planetData.Radius;
		}

		public override void SaveXml(XElement xml)
		{
			base.SaveXml(xml);
			xml.SetAttributeValue("dataIndexOutput", _dataIndexOutput);
			xml.SetAttributeValue("heightType", _heightType);
			xml.SetAttributeValue("includeRadius", _includeRadius);
		}

		protected override void Awake()
		{
			base.Awake();
			_commonPassFields = new List<FieldInfo> { GetType().GetField("_includeRadius", BindingFlags.Instance | BindingFlags.NonPublic) };
			_biomePassFields = new List<FieldInfo>
			{
				GetType().GetField("_includeRadius", BindingFlags.Instance | BindingFlags.NonPublic),
				GetType().GetField("_heightType", BindingFlags.Instance | BindingFlags.NonPublic)
			};
		}

		protected override void RestoreXml(XElement xml)
		{
			base.RestoreXml(xml);
			_dataIndexOutput = (int)xml.Attribute("dataIndexOutput");
			_heightType = xml.GetEnumAttribute("heightType", GetHeightType.Default);
			_includeRadius = (bool?)xml.Attribute("includeRadius") == true;
		}
	}
}
