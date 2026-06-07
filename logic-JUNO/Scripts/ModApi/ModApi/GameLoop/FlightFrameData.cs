using ModApi.Flight;
using UnityEngine;

namespace ModApi.GameLoop
{
	public readonly struct FlightFrameData
	{
		public readonly float DeltaTime;

		public readonly float DeltaTimeUnscaled;

		public readonly double DeltaTimeWorld;

		public readonly IFlightScene FlightScene;

		public readonly int FrameCount;

		public readonly bool IsPaused;

		public readonly bool IsWarping;

		public readonly ITimeManager TimeManager;

		public FlightFrameData(IFlightScene flightScene)
		{
			FlightScene = flightScene;
			TimeManager = flightScene.TimeManager;
			FrameCount = Time.frameCount;
			DeltaTime = Time.deltaTime;
			DeltaTimeUnscaled = Time.unscaledDeltaTime;
			DeltaTimeWorld = TimeManager.DeltaTime;
			IsPaused = TimeManager.Paused;
			IsWarping = TimeManager.CurrentMode.WarpMode;
		}
	}
}
