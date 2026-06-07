namespace DinoPoloClub
{
	public interface IAnalyticsStorageProvider
	{
		void StoreData(byte[] data);

		byte[] RetrieveData();

		void DeleteStoredData();
	}
}
