using System.Collections.Generic;
using UnityEngine;

public class DebugManager : Singleton<DebugManager>
{
	public enum eFontSize
	{
		NORMAL = 0,
		LARGE = 1,
		SUPER_LARGE = 2
	}

	public enum eTimeFormat
	{
		DISABLED = 0,
		SHORT = 1,
		LONG = 2,
		MILLISECONDS = 3
	}

	private enum eLogType
	{
		LOG = 0,
		WARNING = 1,
		ASSERTION = 2,
		ERROR = 3
	}

	[SerializeField]
	private DebugSettingSO settings;

	private Dictionary<eDebugKey, DebugSettingData> dic_Data;

	private eTimeFormat timeFormat;

	private eFontSize fontSize;

	private const int FONTSIZE_NORMAL = 11;

	private const int FONTSIZE_LARGE = 14;

	private const int FONTSIZE_SUPER_LARGE = 18;

	private bool isInitialized;

	protected override void Awake()
	{
	}

	private void Initialize()
	{
	}

	public static void Log(eDebugKey key, string msg, Object context = null)
	{
	}

	public static void LogWarning(eDebugKey key, string msg, Object context = null)
	{
	}

	public static void LogError(eDebugKey key, string msg, Object context = null)
	{
	}

	public static void LogAssertion(eDebugKey key, string msg, Object context = null)
	{
	}

	private void log(eLogType logType, eDebugKey key, string msg, Object context = null)
	{
	}

	private void PrintLog(eLogType logType, string fullMsg, Object context = null)
	{
	}

	private void BasicLog(eLogType logType, string msg)
	{
	}

	public int GetFontSize(eFontSize fontsize)
	{
		return 0;
	}

	private void Update()
	{
	}

	private void Start()
	{
	}
}
