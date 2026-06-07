using Factory;

public class HapticFeedbackGenerator
{
	[Dependency]
	private IHardwareCapabilities _hardwareCapabilities;

	[Dependency]
	private IActivePlayer _player;

	public void GenerateFeedback(HapticFeedbackType feedbackType)
	{
		if (_player.HasActivePlayer && _player.IsVibrationEnabled)
		{
			_hardwareCapabilities.GenerateHapticFeedback(feedbackType);
		}
	}
}
