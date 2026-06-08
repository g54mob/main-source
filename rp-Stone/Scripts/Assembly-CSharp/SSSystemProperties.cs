using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SSSystemProperties : StonescriptObject
{
	private static readonly string REMOTE_FILE_URL = Path.Combine(Application.streamingAssetsPath, "Stonescript");

	private static readonly string LOCAL_FILE_URL = "local";

	public static string fileUrl;

	public static bool remoteFileChachingEnabled = true;

	public SSSystemProperties()
		: base("sys")
	{
		SSScriptableObject.Bind(this, this);
		ResetFileURL();
	}

	public static void ResetFileURL()
	{
		fileUrl = LOCAL_FILE_URL;
	}

	public static bool IsRemoteFilePath()
	{
		return fileUrl != LOCAL_FILE_URL;
	}

	public static bool IsLocalFilePath()
	{
		return fileUrl == LOCAL_FILE_URL;
	}

	[StonescriptNativeGetter("fileUrl")]
	public object Property_GetFileURL()
	{
		return fileUrl;
	}

	[StonescriptNativeMethod]
	public object SetFileUrl(List<object> parameters, InvocationContext ctx)
	{
		if (ctx.ScriptName != "Mindstone.main")
		{
			throw new StonescriptRuntimeException("sys.SetFileUrl() can only be used in the Mind Stone.");
		}
		if (parameters.Count < 1)
		{
			throw new StonescriptRuntimeException("sys.SetFileUrl() requires a parameter");
		}
		fileUrl = parameters[0] as string;
		if (string.IsNullOrEmpty(fileUrl))
		{
			ResetFileURL();
		}
		else if (fileUrl == "remote")
		{
			fileUrl = REMOTE_FILE_URL;
		}
		return null;
	}

	[StonescriptNativeGetter("cacheRemoteFiles")]
	public object Property_CacheRemoteFiles()
	{
		return remoteFileChachingEnabled;
	}

	[StonescriptNativeSetter("cacheRemoteFiles")]
	public void Property_CacheRemoteFiles(object value)
	{
		remoteFileChachingEnabled = (bool)value;
	}

	[StonescriptNativeGetter("os")]
	public object Property_OperatingSystem()
	{
		return "Windows";
	}

	[StonescriptNativeGetter("isPC")]
	public object Property_IsPC()
	{
		return true;
	}

	[StonescriptNativeGetter("isMobile")]
	public object Property_IsMobile()
	{
		return false;
	}

	[StonescriptNativeGetter("isConsole")]
	public object Property_IsConsole()
	{
		return false;
	}
}
