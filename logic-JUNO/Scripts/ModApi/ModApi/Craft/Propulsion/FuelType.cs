using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using Jundroo.ModTools;
using ModApi.Common.Extensions;
using UnityEngine;

namespace ModApi.Craft.Propulsion
{
	public class FuelType
	{
		public const string IdLoxRp1 = "LOX/RP1";

		public static FuelType Battery { get; private set; }

		public static FuelType Jet { get; private set; }

		public static FuelType Monopropellant { get; private set; }

		public static FuelType None { get; private set; }

		public bool AllowFuelTransfer => FuelTransferRate > 0f;

		public float CombustionTemperature { get; }

		public float Density { get; }

		public string Description { get; }

		public bool DisplayInDesigner { get; }

		public float EnginePriceScale { get; }

		public Color ExhaustColor { get; }

		public Color ExhaustColorExpanded { get; }

		public Color ExhaustColorTip { get; }

		public Color ExhaustColorShock { get; }

		public Color ExhaustColorFlame { get; }

		public Color ExhaustColorSoot { get; }

		public Color ExhaustColorSmoke { get; }

		public float GlobalIntensity { get; }

		public float ShockIntensity { get; }

		public float RimShade { get; }

		public float SmokeOffset { get; }

		public float ExplosivePower { get; }

		public float FuelTransferRate { get; }

		public float Gamma { get; }

		public string Id { get; }

		public ILoadedMod Mod { get; }

		public float MolecularWeight { get; }

		public string Name { get; }

		public float Price { get; }

		public float StorageOverhead { get; }

		public FuelType(XElement xml, ILoadedMod mod = null)
		{
			Id = xml.Attribute("id").Value;
			Name = xml.Attribute("name").Value;
			Gamma = xml.GetFloatAttribute("gamma");
			MolecularWeight = xml.GetFloatAttribute("molecularWeight");
			CombustionTemperature = xml.GetFloatAttribute("combustionTemperature");
			Density = xml.GetFloatAttribute("density");
			Price = xml.GetFloatAttribute("price");
			EnginePriceScale = xml.GetFloatAttribute("enginePriceScale", 1f);
			ExplosivePower = xml.GetFloatAttribute("explosivePower");
			Description = xml.GetStringAttribute("description");
			FuelTransferRate = xml.GetFloatAttribute("fuelTransferRate", 250f);
			DisplayInDesigner = xml.GetBoolAttribute("displayInDesigner", defaultValue: true);
			StorageOverhead = xml.GetFloatAttribute("storageOverhead", 0.45f);
			XElement orCreateElement = xml.GetOrCreateElement("Visual");
			ExhaustColor = orCreateElement.GetColorAttribute("exhaustColor", new Color(255f, 168f, 81f, 255f), XmlColorFormat.HexRGBA);
			ExhaustColorExpanded = orCreateElement.GetColorAttribute("exhaustColorExpanded", ExhaustColor, XmlColorFormat.HexRGBA);
			ExhaustColorTip = orCreateElement.GetColorAttribute("exhaustColorTip", ExhaustColor, XmlColorFormat.HexRGBA);
			ExhaustColorShock = orCreateElement.GetColorAttribute("exhaustColorShock", ExhaustColor, XmlColorFormat.HexRGBA);
			ExhaustColorFlame = orCreateElement.GetColorAttribute("exhaustColorFlame", new Color(1f, 0.4f, 0f, 0.5f), XmlColorFormat.HexRGBA);
			ExhaustColorSoot = orCreateElement.GetColorAttribute("exhaustColorSoot", new Color(0f, 0f, 0f, 1f), XmlColorFormat.HexRGBA);
			ExhaustColorSmoke = orCreateElement.GetColorAttribute("exhaustColorSmoke", new Color(1f, 1f, 1f, 1f), XmlColorFormat.HexRGBA);
			ShockIntensity = orCreateElement.GetFloatAttribute("shockIntensity", 2f);
			GlobalIntensity = orCreateElement.GetFloatAttribute("globalIntensity", 2f);
			RimShade = orCreateElement.GetFloatAttribute("rimShade", 0.5f);
			SmokeOffset = orCreateElement.GetFloatAttribute("smokeOffset", 1f);
			Mod = mod;
		}

		public static void Initialize(List<FuelType> fuels)
		{
			Battery = fuels.Where((FuelType x) => x.Id == "Battery").First();
			Monopropellant = fuels.Where((FuelType x) => x.Id == "Monopropellant").First();
			Jet = fuels.Where((FuelType x) => x.Id == "Jet").First();
			None = fuels.Where((FuelType x) => x.Id == "None").First();
		}
	}
}
