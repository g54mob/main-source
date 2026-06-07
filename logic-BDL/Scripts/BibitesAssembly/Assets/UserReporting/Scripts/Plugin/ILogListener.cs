using UnityEngine;

namespace Assets.UserReporting.Scripts.Plugin
{
	public interface ILogListener
	{
		void ReceiveLogMessage(string logString, string stackTrace, LogType logType);
	}
}
