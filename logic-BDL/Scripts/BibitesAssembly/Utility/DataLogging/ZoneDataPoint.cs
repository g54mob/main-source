using SettingScripts;
using SimulationScripts;
using UnityEngine;

namespace Utility.DataLogging
{
	public struct ZoneDataPoint
	{
		public short posX;

		public short posY;

		public ushort radius;

		public float fertility;

		public float biomass;

		public bool present
		{
			get
			{
				if (radius > 0)
				{
					return fertility > 0f;
				}
				return false;
			}
		}

		public static byte sizeOfPoint => 14;

		public ZoneDataPoint(Zone zone)
		{
			ZoneSettings settings = zone.settings;
			posX = (short)(Mathf.Clamp(settings.posX.val, -0.9999f, 0.9999f) * 32767f);
			posY = (short)(Mathf.Clamp(settings.posY.val, -0.9999f, 0.9999f) * 32767f);
			if (settings.isRect)
			{
				radius = (ushort)(Mathf.Max(settings.relativeWidth / 2f, settings.relativeHeight / 2f) * 32767f);
			}
			else
			{
				radius = (ushort)(settings.relativeRadius * 32767f);
			}
			fertility = settings.totalGrowth;
			biomass = zone.pelletBiomass;
		}

		public ZoneDataPoint(ZoneSettings settings)
		{
			posX = (short)(Mathf.Clamp(settings.posX.val, -0.9999f, 0.9999f) * 32767f);
			posY = (short)(Mathf.Clamp(settings.posY.val, -0.9999f, 0.9999f) * 32767f);
			if (settings.isRect)
			{
				radius = (ushort)(Mathf.Max(settings.relativeWidth / 2f, settings.relativeHeight / 2f) * 32767f);
			}
			else
			{
				radius = (ushort)(settings.relativeRadius * 32767f);
			}
			fertility = settings.totalGrowth;
			biomass = settings.maxBiomass;
		}
	}
}
