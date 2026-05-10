namespace CTS
{
	public interface ICareerProfileReference
	{
		bool IsCurrentProfile();

		bool HasProfile();

		CareerMetaData GetProfile();

		MapInfoSO GetLastLevelPlayed();
	}
}
