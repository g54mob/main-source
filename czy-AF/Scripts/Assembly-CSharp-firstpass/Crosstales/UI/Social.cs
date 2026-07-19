using Crosstales.Common.Util;
using UnityEngine;

namespace Crosstales.UI
{
	public class Social : MonoBehaviour
	{
		public void Facebook()
		{
			BaseHelper.OpenURL("https://www.facebook.com/crosstales/");
		}

		public void Twitter()
		{
			BaseHelper.OpenURL("https://twitter.com/crosstales");
		}

		public void LinkedIn()
		{
			BaseHelper.OpenURL("https://www.linkedin.com/company/crosstales");
		}

		public void Youtube()
		{
			BaseHelper.OpenURL("https://www.youtube.com/c/Crosstales");
		}

		public void Discord()
		{
			BaseHelper.OpenURL("https://discord.gg/ZbZ2sh4");
		}
	}
}
