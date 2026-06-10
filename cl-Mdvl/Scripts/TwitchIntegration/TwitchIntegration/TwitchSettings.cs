using System.Collections.Generic;
using UnityEngine;

namespace TwitchIntegration
{
	public class TwitchSettings : ScriptableObject
	{
		public bool initializeOnAwake = true;

		public bool isDebugMode = true;

		public string clientId;

		public string commandPrefix = "!";

		public string redirectUri = "http://localhost";

		public TwitchCommandsMode commandsMode;

		public List<TwitchCommand> commandList;
	}
}
