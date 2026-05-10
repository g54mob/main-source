using CTS.Core;

namespace CTS
{
	public class OpenSettingsInterface : CTSBehaviour
	{
		public void Open()
		{
			CTSSingleton<SettingsInterface>.Instance.Open();
		}
	}
}
