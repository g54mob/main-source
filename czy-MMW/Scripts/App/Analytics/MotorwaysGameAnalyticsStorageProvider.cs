using System.Text;
using DinoPoloClub;
using Factory;
using UnityEngine;

namespace Analytics
{
	public class MotorwaysGameAnalyticsStorageProvider : IAnalyticsStorageProvider
	{
		private IScope _scope;

		private const string AnalyticsStorageKey = "AnalyticsStorageKeyValue_SDGJSD43SLDKI98W4OGUYU894";

		public void DeleteStoredData()
		{
			PlayerPrefs.DeleteKey("AnalyticsStorageKeyValue_SDGJSD43SLDKI98W4OGUYU894");
		}

		public byte[] RetrieveData()
		{
			string s = PlayerPrefs.GetString("AnalyticsStorageKeyValue_SDGJSD43SLDKI98W4OGUYU894");
			return Encoding.UTF8.GetBytes(s);
		}

		public void StoreData(byte[] bytes)
		{
			string value = Encoding.UTF8.GetString(bytes);
			PlayerPrefs.SetString("AnalyticsStorageKeyValue_SDGJSD43SLDKI98W4OGUYU894", value);
		}
	}
}
