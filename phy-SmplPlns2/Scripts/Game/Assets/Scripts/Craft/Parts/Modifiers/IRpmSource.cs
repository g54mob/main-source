namespace Assets.Scripts.Craft.Parts.Modifiers
{
	public interface IRpmSource
	{
		float ReportedRpm { get; }

		int ReportedRpmPriority { get; }

		PartScript ReportingPartScript { get; }
	}
}
