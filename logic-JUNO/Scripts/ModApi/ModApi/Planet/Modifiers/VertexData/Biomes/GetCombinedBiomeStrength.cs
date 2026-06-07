using System;
using System.Linq;
using System.Reflection;
using System.Xml.Linq;
using ModApi.Planet.Modifiers.Attributes;
using ModApi.Ui.Inspector;
using UnityEngine;

namespace ModApi.Planet.Modifiers.VertexData.Biomes
{
	[PlanetModifierInfo("Get Biome Strength (Combined)", "A planet modifier that gets the combined strength of multiple biomes and stores it in a data output.")]
	public class GetCombinedBiomeStrength : VertexDataCommonPassPlanetModifier, ICustomObjectInspectorModelFields, IBiomeListModifiedHandler
	{
		[SerializeField]
		private int[] _biomeIndexes;

		[SerializeField]
		[Range(0f, 9f)]
		[DataSlot(DataSlotType.Output, "Output", false, true, Tooltip = "The output in which to store the combined biome strength (typically a value between 0 and 1).")]
		private int _dataIndexOutput;

		public override VertexDataPlanetModifierPassType[] SupportedPassTypes => new VertexDataPlanetModifierPassType[4]
		{
			VertexDataPlanetModifierPassType.Height,
			VertexDataPlanetModifierPassType.HeightFinal,
			VertexDataPlanetModifierPassType.Final,
			VertexDataPlanetModifierPassType.Water
		};

		public override VertexDataType VertexDataType => VertexDataType.Both;

		public bool CreateFieldModel(GroupModel groupModel, IObjectInspector inspectorObject, MemberInfo member, int? arrayIndex)
		{
			if (member.Name == "_biomeIndexes" && arrayIndex.HasValue)
			{
				int i = arrayIndex.Value;
				int count = base.TerrainData.Biomes.Count;
				groupModel.AddAndBuild(new SliderModel("Biome " + (arrayIndex + 1), () => _biomeIndexes[i], delegate(float x)
				{
					_biomeIndexes[i] = (int)x;
				}, 0f, count - 1, wholeNumbers: true, allowManualInput: false)).Build(delegate(SliderModel x)
				{
					x.ValueFormatter = (float value) => value + " : " + base.TerrainData.Biomes[(int)value].Name;
				}).Build(delegate(SliderModel x)
				{
					x.Tooltip = "One of the biomes of which the strength will be combined and added to the output data.";
				});
				return true;
			}
			return false;
		}

		public override void GetVertexData(PlanetVertexDataInput input, PlanetVertexData data)
		{
			float num = 0f;
			PlanetVertexBiomeData[] biomes = data.Biomes;
			for (int i = 0; i < _biomeIndexes.Length; i++)
			{
				num += biomes[_biomeIndexes[i]].Strength;
			}
			data.Data[_dataIndexOutput] = num;
		}

		public override void GetVertexData(PlanetVertexDataInput input, PlanetBiomeVertexData data)
		{
			float num = 0f;
			PlanetVertexBiomeData[] biomes = data.CommonData.Biomes;
			for (int i = 0; i < _biomeIndexes.Length; i++)
			{
				num += biomes[_biomeIndexes[i]].Strength;
			}
			data.Data[_dataIndexOutput] = num;
		}

		public void OnBiomeAdded(int index)
		{
			for (int i = 0; i < _biomeIndexes.Length; i++)
			{
				if (_biomeIndexes[i] >= index)
				{
					_biomeIndexes[i]++;
				}
			}
		}

		public void OnBiomeDeleted(int index)
		{
			_biomeIndexes = _biomeIndexes.Where((int x) => x != index).ToArray();
			for (int num = 0; num < _biomeIndexes.Length; num++)
			{
				if (_biomeIndexes[num] > index)
				{
					_biomeIndexes[num]--;
				}
			}
		}

		public override void SaveXml(XElement xml)
		{
			base.SaveXml(xml);
			if (_biomeIndexes == null)
			{
				_biomeIndexes = new int[0];
			}
			xml.SetAttributeValue("dataIndexOutput", _dataIndexOutput);
			xml.SetAttributeValue("biomeIndexes", string.Join(",", _biomeIndexes.Select((int x) => DataIO.ToString(x))));
		}

		protected override void RestoreXml(XElement xml)
		{
			base.RestoreXml(xml);
			_dataIndexOutput = (int)xml.Attribute("dataIndexOutput");
			_biomeIndexes = (from x in (((string)xml.Attribute("biomeIndexes")) ?? string.Empty).Split(new char[1] { ',' }, StringSplitOptions.RemoveEmptyEntries)
				select DataIO.ParseInt(x)).ToArray();
		}
	}
}
