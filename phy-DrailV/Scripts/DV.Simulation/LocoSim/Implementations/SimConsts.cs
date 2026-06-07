using System;
using UnityEngine;

namespace LocoSim.Implementations
{
	public static class SimConsts
	{
		public const float OUTSIDE_TEMPERATURE = 25f;

		public const float OUTSIDE_PRESSURE = 1f;

		public const float ON = 1f;

		public const float OFF = 0f;

		public const float WATER_TRIPLE_POINT = 273.15f;

		public const float COMPRESSOR_BREAK_HEALTH_PERCENTAGE_THRESHOLD = 0.2f;

		public const string ID_DELIMITER = ".";

		private const string FULL_ID_FORMAT = "{0}.{1}";

		public const string ID_EMPTY_VALUE = "-EMPTY-";

		public const float BAR_TO_PASCAL = 100000f;

		public const float CUBIC_METER_TO_LITER = 1000f;

		public const float RPM_TO_RAD_PER_S = (float)Math.PI / 30f;

		public static string GetFullId(string compId, string portId)
		{
			return $"{compId}.{portId}";
		}

		public static (string compId, string portId) ParseFullId(string fullPortId)
		{
			if (fullPortId == "-EMPTY-")
			{
				return (compId: "-EMPTY-", portId: string.Empty);
			}
			int num = fullPortId.IndexOf(".");
			if (num < 0)
			{
				Debug.LogError("Invalid full port ID: " + fullPortId);
				return (compId: fullPortId, portId: string.Empty);
			}
			return (compId: fullPortId.Substring(0, num), portId: fullPortId.Substring(num + 1));
		}
	}
}
