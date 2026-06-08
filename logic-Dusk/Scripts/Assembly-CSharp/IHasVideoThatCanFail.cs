public interface IHasVideoThatCanFail
{
	float TimePassed { get; }

	bool VideoSignalLost { get; set; }

	float TimeOfNextVideoLoss { get; set; }

	float TimeOfNextWarningVideoLoss { get; set; }

	float VideoLossDuration { get; set; }

	float TimeOfNextVideoRestore { get; set; }

	float TimeTilNextFailMin { get; set; }

	float TimeTilNextFailMax { get; set; }
}
