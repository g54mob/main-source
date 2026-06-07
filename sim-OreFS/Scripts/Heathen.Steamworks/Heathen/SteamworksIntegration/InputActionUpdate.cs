using System;
using Steamworks;

namespace Heathen.SteamworksIntegration
{
	[Serializable]
	public struct InputActionUpdate
	{
		public InputHandle_t controller;

		public string name;

		public InputActionType type;

		public EInputSourceMode mode;

		public bool isActive;

		public bool isState;

		public float isX;

		public float isY;

		public bool wasActive;

		public bool wasState;

		public float wasX;

		public float wasY;

		public bool IsNil => string.IsNullOrEmpty(name);

		public float DeltaX => isX - wasX;

		public float DeltaY => isY - wasY;

		public bool Active => isActive;

		public bool State => isState;

		public float X => isX;

		public float Y => isY;

		public InputActionData Data => new InputActionData
		{
			controller = controller,
			name = name,
			type = type,
			mode = mode,
			active = isActive,
			state = isState,
			x = isX,
			y = isY
		};
	}
}
