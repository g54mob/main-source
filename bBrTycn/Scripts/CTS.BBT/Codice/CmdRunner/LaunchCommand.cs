using System.IO;
using System.Xml.Serialization;

namespace Codice.CmdRunner
{
	public class LaunchCommand
	{
		private LaunchCommandConfig mConfig;

		private static LaunchCommand mInstance = null;

		private static string mExecutablePath = "cm";

		public static void SetExecutablePath(string executablepath)
		{
			mExecutablePath = executablepath;
		}

		public static LaunchCommand Get()
		{
			if (mInstance == null)
			{
				mInstance = new LaunchCommand();
			}
			return mInstance;
		}

		public string GetFullServerCommand()
		{
			return mConfig.FullServerCommand;
		}

		public string GetCmShellCommand()
		{
			return mConfig.CmShellComand;
		}

		public string GetAllServerPrefixCommand()
		{
			return mConfig.AllServerPrefixCommand;
		}

		public string GetClientPath()
		{
			return mConfig.ClientPath;
		}

		private static LaunchCommandConfig LoadFromFile(string file)
		{
			FileStream stream = new FileStream(file, FileMode.Open, FileAccess.Read);
			return (LaunchCommandConfig)new XmlSerializer(typeof(LaunchCommandConfig)).Deserialize(stream);
		}

		private LaunchCommand()
		{
			string text = "launchcommand.conf";
			if (File.Exists(text))
			{
				mConfig = LoadFromFile(text);
			}
			else
			{
				mConfig = new LaunchCommandConfig();
			}
			if (string.IsNullOrEmpty(mConfig.FullServerCommand))
			{
				mConfig.FullServerCommand = "[SERVERPATH]plasticd --console";
			}
			if (string.IsNullOrEmpty(mConfig.CmShellComand))
			{
				mConfig.CmShellComand = $"{mExecutablePath} shell --logo";
			}
			if (mConfig.ClientPath == null)
			{
				mConfig.ClientPath = string.Empty;
			}
			if (mConfig.CmShellComand == null)
			{
				mConfig.CmShellComand = string.Empty;
			}
		}
	}
}
