using System;

namespace FuryStudios.FurySDK.Settings
{
	[Serializable]
	internal class DlcInfo
	{
		public string key;

		public uint steamAPI;

		public ulong gogAPI;

		public string epicAPI;

		public int switchAPI;

		public string gdkGamePassAPI;

		public string gdkConsoleAPI;

		public string xboxAPI;
	}
}
