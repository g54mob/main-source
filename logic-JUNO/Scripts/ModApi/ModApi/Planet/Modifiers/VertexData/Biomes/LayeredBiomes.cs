using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Xml.Linq;
using ModApi.Planet.Modifiers.Attributes;
using ModApi.Ui.Inspector;
using UnityEngine;

namespace ModApi.Planet.Modifiers.VertexData.Biomes
{
	[PlanetModifierInfo("Biomes (Layered)", "A biome pass planet modifier that takes sets of inputs and converts them into biome strengths. Biome inputs are applied in layers with the higher priority ones taking precedence over lower priority A default biome can also be defined to fill in any gaps that may be left.")]
	public class LayeredBiomes : VertexDataPlanetModifier, IDataSlotConfiguration, ICustomObjectInspectorModelFields, IBiomeListModifiedHandler
	{
		public enum BiomeInputType
		{
			SingleBiome = 0,
			DualBiome_NegativeAndPositive = 1,
			DualBiome_PositiveAndRemainder = 2
		}

		[Serializable]
		private class BiomeInput : ICustomObjectInspectorModelFields
		{
			[SerializeField]
			[DataSlot(DataSlotType.Input, "Input", false, true)]
			public int InputDataIndex;

			[SerializeField]
			[InspectorProperty(null, false, Label = "Type", Order = 0, Tooltip = "Determines how the input is converted to biomes. \n\nSingle Biome - The biome input value represents the strength of the primary biome from 0% at 0 to 100% at 1. \n\nDual Biome Negative And Positive - The biome input value represents two biomes. The primary biome strength is represented by values from 0 (0%) to 1 (100%). The other biome strength is represented by values from 0 (0%) to -1 (100%). \n\nDual Biome Positive And Remainder - The biome input value represents two biomes. The primary biome strength is represented by values from 0 (0%) to 1 (100%). The other biome strengths is 100% minus the strength of the primary biome.")]
			public BiomeInputType InputType;

			[SerializeField]
			[InspectorProperty(null, false, Order = 20)]
			public int OtherBiomeIndex;

			[SerializeField]
			[InspectorProperty(null, false, Order = 10)]
			public int PrimaryBiomeIndex;

			public bool CreateFieldModel(GroupModel groupModel, IObjectInspector inspectorObject, MemberInfo member, int? arrayIndex)
			{
				if (member.Name == "PrimaryBiomeIndex" || member.Name == "OtherBiomeIndex")
				{
					List<PlanetBiome> biomes = (inspectorObject.Target as LayeredBiomes)?.TerrainData?.Biomes;
					if (biomes == null)
					{
						Debug.LogError("Unable to get the biomes for custom field models in the object inspector for the LayeredBiomes modifier.");
						return true;
					}
					if (member.Name == "PrimaryBiomeIndex")
					{
						groupModel.AddAndBuild(new SliderModel("Primary Biome", () => PrimaryBiomeIndex, delegate(float x)
						{
							PrimaryBiomeIndex = (int)x;
						}, 0f, biomes.Count - 1, wholeNumbers: true, allowManualInput: false)).Build(delegate(SliderModel x)
						{
							x.ValueFormatter = (float i) => i + " : " + biomes[(int)i].Name;
						}).Build(delegate(SliderModel x)
						{
							x.Tooltip = "The primary biome being assigned by the input.";
						});
					}
					else if (member.Name == "OtherBiomeIndex")
					{
						groupModel.AddAndBuild(new SliderModel("Other Biome", () => OtherBiomeIndex, delegate(float x)
						{
							OtherBiomeIndex = (int)x;
						}, 0f, biomes.Count - 1, wholeNumbers: true, allowManualInput: false)).Build(delegate(SliderModel x)
						{
							x.ValueFormatter = (float i) => i + " : " + biomes[(int)i].Name;
						}).Build(delegate(SliderModel x)
						{
							x.Tooltip = "The other biome being assigned by the input if the input type assigns two biomes.";
						});
					}
					return true;
				}
				return false;
			}
		}

		[Serializable]
		private class BiomeInputLayer
		{
			[SerializeField]
			public BiomeInput[] BiomeInputs;

			public static BiomeInputLayer CreateFromXml(XElement xml)
			{
				BiomeInputLayer biomeInputLayer = new BiomeInputLayer();
				List<XElement> list = xml.Elements("BiomeInput").ToList();
				biomeInputLayer.BiomeInputs = new BiomeInput[list.Count];
				for (int i = 0; i < list.Count; i++)
				{
					BiomeInput biomeInput = new BiomeInput();
					biomeInput.InputType = (BiomeInputType)Enum.Parse(typeof(BiomeInputType), (string)list[i].Attribute("inputType"), ignoreCase: true);
					biomeInput.InputDataIndex = (int)list[i].Attribute("inputDataIndex");
					biomeInput.PrimaryBiomeIndex = (int)list[i].Attribute("primaryBiomeIndex");
					biomeInput.OtherBiomeIndex = (int)list[i].Attribute("otherBiomeIndex");
					biomeInputLayer.BiomeInputs[i] = biomeInput;
				}
				return biomeInputLayer;
			}

			public XElement GenerateXml()
			{
				XElement xElement = new XElement("BiomeLayer");
				if (BiomeInputs != null)
				{
					BiomeInput[] biomeInputs = BiomeInputs;
					foreach (BiomeInput biomeInput in biomeInputs)
					{
						XElement xElement2 = new XElement("BiomeInput");
						xElement2.SetAttributeValue("inputType", biomeInput.InputType);
						xElement2.SetAttributeValue("inputDataIndex", biomeInput.InputDataIndex);
						xElement2.SetAttributeValue("primaryBiomeIndex", biomeInput.PrimaryBiomeIndex);
						xElement2.SetAttributeValue("otherBiomeIndex", biomeInput.OtherBiomeIndex);
						xElement.Add(xElement2);
					}
				}
				return xElement;
			}
		}

		[SerializeField]
		[InspectorProperty(null, false, Order = 10)]
		private BiomeInputLayer[] _biomeLayers;

		[SerializeField]
		[InspectorProperty(null, false, Order = 0)]
		private int _defaultBiomeIndex;

		public override VertexDataPlanetModifierPassType Pass => VertexDataPlanetModifierPassType.Biome;

		public override VertexDataType VertexDataType => VertexDataType.Common;

		public bool CreateFieldModel(GroupModel groupModel, IObjectInspector inspectorObject, MemberInfo member, int? arrayIndex)
		{
			if (member.Name == "_defaultBiomeIndex")
			{
				List<PlanetBiome> biomes = base.TerrainData.Biomes;
				groupModel.AddAndBuild(new SliderModel("Default Biome", () => _defaultBiomeIndex, delegate(float x)
				{
					_defaultBiomeIndex = (int)x;
				}, 0f, biomes.Count - 1, wholeNumbers: true, allowManualInput: false)).Build(delegate(SliderModel x)
				{
					x.ValueFormatter = (float i) => i + " : " + biomes[(int)i].Name;
				}).Build(delegate(SliderModel x)
				{
					x.Tooltip = "The default biome to be assigned if there is assigned biome strength remaining after evaluating all layers and inputs.";
				});
				return true;
			}
			return false;
		}

		public void GetDataSlots(List<DataSlotField> dataSlots)
		{
			for (int i = 0; i < _biomeLayers.Length; i++)
			{
				BiomeInputLayer biomeInputLayer = _biomeLayers[i];
				for (int j = 0; j < biomeInputLayer.BiomeInputs.Length; j++)
				{
					BiomeInput biomeInput = biomeInputLayer.BiomeInputs[j];
					DataSlotField item = new DataSlotField(biomeInput, new DataSlotAttribute(DataSlotType.Input, $"Layer {i + 1} - Input {j + 1}"), Utilities.GetField(() => biomeInput.InputDataIndex));
					dataSlots.Add(item);
				}
			}
		}

		public override void GetVertexData(PlanetVertexDataInput input, PlanetVertexData data)
		{
			double[] biomeTempData = data.CacheData.BiomeTempData;
			PlanetVertexBiomeData[] biomes = data.Biomes;
			double[] data2 = data.Data;
			double num = 1.0;
			BiomeInputLayer[] biomeLayers = _biomeLayers;
			foreach (BiomeInputLayer biomeInputLayer in biomeLayers)
			{
				double num2 = 0.0;
				BiomeInput[] biomeInputs = biomeInputLayer.BiomeInputs;
				foreach (BiomeInput biomeInput in biomeInputs)
				{
					double num3 = data2[biomeInput.InputDataIndex];
					switch (biomeInput.InputType)
					{
					case BiomeInputType.SingleBiome:
						if (num3 > 1.0)
						{
							num3 = 1.0;
						}
						else if (num3 < 0.0)
						{
							num3 = 0.0;
						}
						biomeTempData[biomeInput.PrimaryBiomeIndex] = num3;
						num2 += num3;
						break;
					case BiomeInputType.DualBiome_NegativeAndPositive:
						if (num3 < 0.0)
						{
							num3 = 0.0 - num3;
							if (num3 > 1.0)
							{
								num3 = 1.0;
							}
							else if (num3 < 0.0)
							{
								num3 = 0.0;
							}
							biomeTempData[biomeInput.PrimaryBiomeIndex] = 0.0;
							biomeTempData[biomeInput.OtherBiomeIndex] = num3;
						}
						else
						{
							if (num3 > 1.0)
							{
								num3 = 1.0;
							}
							else if (num3 < 0.0)
							{
								num3 = 0.0;
							}
							biomeTempData[biomeInput.PrimaryBiomeIndex] = num3;
							biomeTempData[biomeInput.OtherBiomeIndex] = 0.0;
						}
						num2 += num3;
						break;
					case BiomeInputType.DualBiome_PositiveAndRemainder:
						if (num3 > 1.0)
						{
							num3 = 1.0;
						}
						else if (num3 < 0.0)
						{
							num3 = 0.0;
						}
						biomeTempData[biomeInput.PrimaryBiomeIndex] = num3;
						biomeTempData[biomeInput.OtherBiomeIndex] = 1.0 - num3;
						num2 += 1.0;
						break;
					default:
						throw new NotSupportedException();
					}
				}
				if (num < num2)
				{
					double num4 = num / num2;
					biomeInputs = biomeInputLayer.BiomeInputs;
					foreach (BiomeInput biomeInput2 in biomeInputs)
					{
						int primaryBiomeIndex = biomeInput2.PrimaryBiomeIndex;
						biomes[primaryBiomeIndex].Strength += (float)(biomeTempData[primaryBiomeIndex] * num4);
						if (biomeInput2.InputType != BiomeInputType.SingleBiome)
						{
							int otherBiomeIndex = biomeInput2.OtherBiomeIndex;
							biomes[otherBiomeIndex].Strength += (float)(biomeTempData[otherBiomeIndex] * num4);
						}
					}
				}
				else
				{
					biomeInputs = biomeInputLayer.BiomeInputs;
					foreach (BiomeInput biomeInput3 in biomeInputs)
					{
						int primaryBiomeIndex2 = biomeInput3.PrimaryBiomeIndex;
						biomes[primaryBiomeIndex2].Strength += (float)biomeTempData[primaryBiomeIndex2];
						if (biomeInput3.InputType != BiomeInputType.SingleBiome)
						{
							int otherBiomeIndex2 = biomeInput3.OtherBiomeIndex;
							biomes[otherBiomeIndex2].Strength += (float)biomeTempData[otherBiomeIndex2];
						}
					}
				}
				num -= num2;
				if (num < (double)Mathf.Epsilon)
				{
					break;
				}
			}
			if (num > (double)Mathf.Epsilon)
			{
				biomes[_defaultBiomeIndex].Strength = (float)num;
			}
		}

		public override void GetVertexData(PlanetVertexDataInput input, PlanetBiomeVertexData data)
		{
			throw new NotSupportedException("Modifier '" + GetType().FullName + "' does not support biome-specific vertex data.");
		}

		public override void Initialize(IPlanetData planetData)
		{
			base.Initialize(planetData);
		}

		public void OnBiomeAdded(int index)
		{
			if (_defaultBiomeIndex >= index)
			{
				_defaultBiomeIndex++;
			}
			BiomeInputLayer[] biomeLayers = _biomeLayers;
			for (int i = 0; i < biomeLayers.Length; i++)
			{
				BiomeInput[] biomeInputs = biomeLayers[i].BiomeInputs;
				foreach (BiomeInput biomeInput in biomeInputs)
				{
					if (biomeInput.PrimaryBiomeIndex >= index)
					{
						biomeInput.PrimaryBiomeIndex++;
					}
					if (biomeInput.OtherBiomeIndex >= index)
					{
						biomeInput.OtherBiomeIndex++;
					}
				}
			}
		}

		public void OnBiomeDeleted(int index)
		{
			if (_defaultBiomeIndex > index)
			{
				_defaultBiomeIndex--;
			}
			BiomeInputLayer[] biomeLayers = _biomeLayers;
			for (int i = 0; i < biomeLayers.Length; i++)
			{
				BiomeInput[] biomeInputs = biomeLayers[i].BiomeInputs;
				foreach (BiomeInput biomeInput in biomeInputs)
				{
					if (biomeInput.PrimaryBiomeIndex > index)
					{
						biomeInput.PrimaryBiomeIndex--;
					}
					if (biomeInput.OtherBiomeIndex > index)
					{
						biomeInput.OtherBiomeIndex--;
					}
				}
			}
		}

		public override void OnCreatingInPlanetStudio(PlanetTerrainDataScript terrainData, VertexDataPlanetModifier parentModifier)
		{
			base.OnCreatingInPlanetStudio(terrainData, parentModifier);
			_biomeLayers = new BiomeInputLayer[0];
		}

		public override void SaveXml(XElement xml)
		{
			base.SaveXml(xml);
			xml.SetAttributeValue("defaultBiomeIndex", _defaultBiomeIndex);
			if (_biomeLayers != null)
			{
				BiomeInputLayer[] biomeLayers = _biomeLayers;
				foreach (BiomeInputLayer biomeInputLayer in biomeLayers)
				{
					xml.Add(biomeInputLayer.GenerateXml());
				}
			}
		}

		protected override void RestoreXml(XElement xml)
		{
			base.RestoreXml(xml);
			_defaultBiomeIndex = (int)xml.Attribute("defaultBiomeIndex");
			_biomeLayers = (from x in xml.Elements("BiomeLayer")
				select BiomeInputLayer.CreateFromXml(x)).ToArray();
		}
	}
}
