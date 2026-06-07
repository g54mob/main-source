using System;
using System.Collections.Generic;
using System.Xml.Linq;
using Jundroo.ModTools;
using ModApi.Common.Extensions;
using UnityEngine;

namespace ModApi.Craft.Propulsion
{
	public class RocketNozzleType
	{
		private float _altitudeCompensation;

		private float _altitudeCompensationScale;

		private float _extensionMax;

		private float _extensionMin;

		private float _extensionRadius;

		private float _nozzleDensity;

		private float _nozzleLength;

		private float _thickness;

		public float Efficiency { get; }

		public float ExhaustBend { get; }

		public float ShockDirection { get; }

		public float ExhaustRadiusScale { get; }

		public float ExtensionOverlap { get; }

		public string ExtensionPrefabId { get; }

		public List<string> ExtensionTextureStyleIds { get; } = new List<string>();

		public string Id { get; }

		public ILoadedMod Mod { get; }

		public string Name { get; }

		public float NozzleRadius { get; }

		public string PrefabId { get; }

		public float PriceScale { get; }

		public List<string> TextureStyleIds { get; } = new List<string>();

		public float ThroatRadius { get; }

		public float OverexpansionDamageThreshold { get; }

		public RocketNozzleType(XElement xml, ILoadedMod mod = null)
		{
			Id = xml.Attribute("id").Value;
			Name = xml.Attribute("name").Value;
			PrefabId = xml.GetStringAttribute("prefabId", Id);
			ExtensionPrefabId = xml.GetStringAttribute("extensionPrefabId");
			_extensionRadius = xml.GetFloatAttribute("extensionRadius");
			_extensionMin = xml.GetFloatAttribute("extensionMin");
			_extensionMax = xml.GetFloatAttribute("extensionMax");
			ExtensionOverlap = xml.GetFloatAttribute("extensionOverlap");
			NozzleRadius = xml.GetFloatAttribute("nozzleRadius");
			ThroatRadius = xml.GetFloatAttribute("throatRadius");
			ExhaustRadiusScale = xml.GetFloatAttribute("exhaustRadiusScale", 1f);
			_altitudeCompensation = xml.GetFloatAttribute("altitudeCompensation");
			_altitudeCompensationScale = xml.GetFloatAttribute("altitudeCompensationScale");
			PriceScale = xml.GetFloatAttribute("priceScale", 1f);
			_nozzleLength = xml.GetFloatAttribute("nozzleLength");
			ExhaustBend = xml.GetFloatAttribute("exhaustBend");
			ShockDirection = xml.GetFloatAttribute("shockDirection", 0.5f);
			_nozzleDensity = xml.GetFloatAttribute("density", 500f);
			_thickness = xml.GetFloatAttribute("thickness", 0.025f);
			OverexpansionDamageThreshold = xml.GetFloatAttribute("overexpansionDamageThreshold");
			Efficiency = xml.GetFloatAttribute("efficiency", 1f);
			TextureStyleIds.AddRange((((string)xml.Attribute("textureStyleIds")) ?? string.Empty).Split(new char[1] { ',' }, StringSplitOptions.RemoveEmptyEntries));
			ExtensionTextureStyleIds.AddRange((((string)xml.Attribute("extensionTextureStyleIds")) ?? string.Empty).Split(new char[1] { ',' }, StringSplitOptions.RemoveEmptyEntries));
			Mod = mod;
		}

		public float CalculateMass(float scale, float extensionSize)
		{
			float num = GetExitRadius(extensionSize) * scale;
			float length = (_nozzleLength + GetExtensionLength(extensionSize)) * scale;
			float num2 = CalculateVolume(scale, num, length);
			float num3 = 0f;
			if (_thickness < 1f)
			{
				num3 = CalculateVolume(scale * (1f - _thickness), num * (1f - _thickness), length);
			}
			return (num2 - num3) * _nozzleDensity;
		}

		public float GetAltitudeCompensation(float extensionLength)
		{
			if (_altitudeCompensation > 0f)
			{
				return _altitudeCompensation + _altitudeCompensationScale * extensionLength;
			}
			return 0f;
		}

		public float GetExitRadius(float extensionPercentage)
		{
			return GetNozzleExtensionScale(extensionPercentage) * _extensionRadius + NozzleRadius;
		}

		public float GetExtensionLength(float extensionPercentage)
		{
			return GetNozzleExtensionScale(extensionPercentage);
		}

		private static float CalculateVolume(float r1, float r2, float length)
		{
			return MathF.PI / 3f * (r1 * r1 + r1 * r2 + r2 * r2) * length;
		}

		private float GetNozzleExtensionScale(float extensionPercentage)
		{
			return Mathf.LerpUnclamped(_extensionMin, _extensionMax, extensionPercentage);
		}
	}
}
