using System;
using Doozy.Engine.Nody.Models;

namespace Doozy.Engine.UI.Connections
{
	[Serializable]
	public class UIConnection
	{
		public const float DEFAULT_TIME_DELAY = 3f;

		public string ButtonCategory;

		public string ButtonName;

		public string GameEvent;

		public float TimeDelay;

		public UIConnectionTrigger Trigger;

		private void Reset()
		{
		}

		public static UIConnection GetValue(Socket socket)
		{
			return null;
		}

		public static void SetValue(Socket socket, UIConnection value)
		{
		}
	}
}
