namespace Humanizer.Localisation.Formatters
{
	public interface IFormatter
	{
		string DateHumanize_Now();

		string DateHumanize_Never();

		string DateHumanize(TimeUnit timeUnit, Tense timeUnitTense, int unit);

		string TimeSpanHumanize_Zero();

		string TimeSpanHumanize(TimeUnit timeUnit, int unit, bool toWords = false);

		string DataUnitHumanize(DataUnit dataUnit, double count, bool toSymbol = true);

		string TimeUnitHumanize(TimeUnit timeUnit);
	}
}
