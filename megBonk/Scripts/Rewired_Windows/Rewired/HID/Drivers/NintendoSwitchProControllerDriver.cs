using Rewired.ControllerExtensions;
using Rewired.Utils.Classes.Data;

namespace Rewired.HID.Drivers
{
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	internal sealed class NintendoSwitchProControllerDriver : NintendoSwitchGamepadDriver, IDriver_NintendoSwitchProController, IDriver_NintendoSwitchController, IControllerDriver, IHIDControllerExtension
	{
		private const int iWtEdVRnpUFbWCcfuxhfctioiAAL = 18;

		private const int zYYXkxCVYlnuTWcSpqHlVzFcoAZs = 4;

		private const int zbrTxvZrUrmPVrJNzuCeKBQIhxnd = 2;

		private const int AItFellXQKGZvnLMsHEmcLPdTxcc = 3;

		private const int cACBCzBxedDyzlMjLoPhEznOfKjs = 6;

		private const int mUOMoDBjVAuejcWCrhXBbDMEosui = 1;

		private const int hJOkzSDBpBXyjkyqjpvqFESfXQFC = 3;

		private const int LUwYoskJzanyTpAqRVkzAOUEbLrU = 5;

		private const int dsaXLnUYaFzxhGCPXxPBjFahRxPG = 7;

		private readonly byte[] EbNGzmyNVrIGSZSisSZAFCnYdwKfA;

		private readonly NativeBuffer McWNvZieiYYqznmRdUzHKNudHVHc;

		public NintendoSwitchProControllerDriver(InitArgs P_0)
			: base(null, default(TcyrPLPfzGgITAruLwqcettRbltv), 0, 0, 0)
		{
		}

		public override void Update(UpdateLoopType updateLoop)
		{
		}

		public override Controller.Extension CreateControllerExtension()
		{
			return null;
		}

		protected override void UpdateButtons(NativeBuffer inputReport, double timestamp)
		{
		}

		protected override void UpdateElements(GLNYbQuaOXeaSToXMWjUhtXAplaf[] elements, NativeBuffer inputReport, double timestamp)
		{
		}

		~NintendoSwitchProControllerDriver()
		{
		}

		protected override void Dispose(bool disposing)
		{
		}

		public static bool Matches(int vid, int pid)
		{
			return false;
		}
	}
}
