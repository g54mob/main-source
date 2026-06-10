using System;
using UnityEngine;

namespace ModIO
{
	[Serializable]
	public class BuildSettings
	{
		public LogLevel logLevel;

		public UserPortal userPortal;

		[HideInInspector]
		public UserPortal defaultPortal;

		public uint requestCacheLimitKB;

		public BuildSettings()
		{
		}

		public BuildSettings(BuildSettings buildSettings)
		{
		}

		public void SetDefaultPortal()
		{
		}
	}
}
