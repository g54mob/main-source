namespace LaundryBear.PlatformServices
{
	public interface IStatService
	{
		void GetStat(IUser user, string statID, OnStatGet callback);
	}
}
