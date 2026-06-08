using System.Collections.Generic;

namespace GRP.Net
{
	public class NetSimSessionServer : NetModuleServer
	{
		public SimSessionStart startMsg;

		public List<int> keyboardKeys;

		public Dictionary<int, bool> keyboardValues;

		public Dictionary<int, bool> lastKeyboardValues;

		public Dictionary<NetPlayer, Dictionary<int, bool>> keyboardByPlayer;

		public NetSessionServer<SimSessionStart, SimSessionJoin, SimSessionLeave> session;

		public override void Setup()
		{
		}

		public override void Build()
		{
		}

		public void UpdateKeyboard()
		{
		}
	}
}
