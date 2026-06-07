public interface ILocalizationDataSource
{
	string GetLocNameString(bool isPrefix = true);

	string GetLocStatsString();
}
