using UnityEngine;

namespace Rhizomatic.Utility
{
	public delegate void LogFormatArgs(LogType logType, Object context, string format, params object[] args);
}
