using Assets.Scripts.Flight;
using UnityEngine;

namespace Assets.Scripts.Craft
{
	public readonly struct CraftUpdateFrameData
	{
		public readonly AircraftScript Craft;

		public readonly CraftLoadContext CraftLoadContext;

		public readonly float DeltaTime;

		public readonly float DeltaTimeUnscaled;

		public readonly bool IsAICraft;

		public readonly bool IsRemoteCraft;

		public readonly bool Paused;

		public CraftUpdateFrameData(AircraftScript craft)
		{
			Craft = craft;
			IsRemoteCraft = craft.RemoteAircraft;
			IsAICraft = (object)craft.AIScript != null;
			CraftLoadContext = craft.LoadContext;
			DeltaTime = Time.deltaTime;
			DeltaTimeUnscaled = Time.unscaledDeltaTime;
			Paused = PauseManager.Paused;
		}
	}
}
