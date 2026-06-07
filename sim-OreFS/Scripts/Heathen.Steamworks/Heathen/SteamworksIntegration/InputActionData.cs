using System;
using Steamworks;

namespace Heathen.SteamworksIntegration
{
	[Serializable]
	public struct InputActionData
	{
		public string name;

		public InputActionType type;

		public InputHandle_t controller;

		public bool active;

		public EInputSourceMode mode;

		public bool state;

		public float x;

		public float y;

		public override string ToString()
		{
			if (type == InputActionType.Analog)
			{
				if (active)
				{
					return "Active: X[" + x + "] Y[" + y + "]";
				}
				return "Inactive";
			}
			if (active)
			{
				return "Active: " + (state ? "Engaged" : "Idle");
			}
			return "Inactive";
		}
	}
}
