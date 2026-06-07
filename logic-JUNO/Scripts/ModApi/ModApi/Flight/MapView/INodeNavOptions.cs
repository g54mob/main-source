namespace ModApi.Flight.MapView
{
	public interface INodeNavOptions
	{
		bool AutoDeleteManeuverNodes { get; }

		bool AutoWarpToNextNode { get; }

		bool ChangeCameraWhenWarping { get; }

		bool CheatAutoBurns { get; }

		double MaxBurnTimePerPass { get; set; }

		bool ShowAutoBurnVectors { get; }

		double WarpBufferSeconds { get; }

		double WarpSpeedModifier { get; }
	}
}
