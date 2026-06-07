using System;
using UnityEngine;

namespace DevConsole
{
	[Serializable]
	internal struct Settings
	{
		public AnimationCurve curve;

		[Tooltip("When checked, logs from the Debug class and exceptions will be printed to the Console")]
		public bool showDebugLog;

		[Tooltip("Wether or not to add the built-in commands")]
		public bool defaultCommands;

		[Tooltip("Log additional errors information")]
		public bool logVerbose;

		[Tooltip("If none is set, the default one will be used")]
		public GUISkin skin;

		[Tooltip("If none is set, the default one will be used")]
		public Font font;
	}
}
