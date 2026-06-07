using System;
using System.IO;
using UnityEngine;

namespace Lobby.Tools
{
	public static class EnvironmentUtils
	{
		private static string _personalFolder;

		private static string _personalAppDataFolder;

		private static string _myDocumentsFolder;

		private static string _personalLogFolder;

		private static string _personalScreenshotsFolder;

		private static string _personalConfigFolder;

		private static string _commonConfigFolder;

		private static string _inputConfigFolder;

		private static string _sessionConfigFolder;

		private static string _resourcesFolder;

		private static string _unityLogFilePath;

		private static string _logsFolderName;

		private static string _spectatorClientFileName;

		private static string _productName;

		private static string _castleExecutableDirectory;

		private static bool _inited = false;

		private static DateTime _initNow = DateTime.MinValue;

		public static string ProductName
		{
			get
			{
				if (!_inited)
				{
					Init();
				}
				return _productName;
			}
		}

		public static string PersonalFolder
		{
			get
			{
				if (!_inited)
				{
					Init();
				}
				return _personalFolder;
			}
		}

		public static string SpectatorClientFileName
		{
			get
			{
				if (!_inited)
				{
					Init();
				}
				return _spectatorClientFileName;
			}
		}

		public static string PersonalAppDataFolder
		{
			get
			{
				if (!_inited)
				{
					Init();
				}
				return _personalAppDataFolder;
			}
		}

		public static string MyDocumentsFolder
		{
			get
			{
				if (!_inited)
				{
					Init();
				}
				return _myDocumentsFolder;
			}
		}

		public static string PersonalLogFolder
		{
			get
			{
				if (!_inited)
				{
					Init();
				}
				return _personalLogFolder;
			}
		}

		public static string PersonalScreenShotsFolder
		{
			get
			{
				if (!_inited)
				{
					Init();
				}
				return _personalScreenshotsFolder;
			}
		}

		public static string PersonalConfigFolder
		{
			get
			{
				if (!_inited)
				{
					Init();
				}
				return _personalConfigFolder;
			}
		}

		public static string CommonConfigFolder
		{
			get
			{
				if (!_inited)
				{
					Init();
				}
				return _commonConfigFolder;
			}
		}

		public static string SessionConfigFolder
		{
			get
			{
				if (!_inited)
				{
					Init();
				}
				return _sessionConfigFolder;
			}
		}

		public static string InputConfigFolder
		{
			get
			{
				if (!_inited)
				{
					Init();
				}
				return _inputConfigFolder;
			}
		}

		public static string ResourcesFolder
		{
			get
			{
				if (!_inited)
				{
					Init();
				}
				return _resourcesFolder;
			}
		}

		public static string UnityLogFilePath
		{
			get
			{
				if (!_inited)
				{
					Init();
				}
				return _unityLogFilePath;
			}
		}

		public static string LogsFolderName
		{
			get
			{
				if (!_inited)
				{
					Init();
				}
				return _logsFolderName;
			}
		}

		public static string CastleExecutableDirectory
		{
			get
			{
				if (!_inited)
				{
					Init();
				}
				return _castleExecutableDirectory;
			}
		}

		public static DateTime InitNow => _initNow;

		private static void Init()
		{
			char directorySeparatorChar = Path.DirectorySeparatorChar;
			if (Application.platform == RuntimePlatform.OSXPlayer)
			{
				_myDocumentsFolder = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + directorySeparatorChar + "Documents";
			}
			else
			{
				_myDocumentsFolder = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
			}
			char directorySeparatorChar2;
			if (Application.isEditor)
			{
				string dataPath = Application.dataPath;
				directorySeparatorChar2 = Path.DirectorySeparatorChar;
				_personalFolder = dataPath + directorySeparatorChar2;
			}
			else if (Application.platform == RuntimePlatform.WindowsPlayer || Application.platform == RuntimePlatform.OSXPlayer)
			{
				if (AssemblyInfoAccessor.IsShippingAssembly)
				{
					_personalFolder = _myDocumentsFolder + directorySeparatorChar + "My Games" + directorySeparatorChar + AssemblyInfoAccessor.Title + directorySeparatorChar + AssemblyInfoAccessor.ComponentName + directorySeparatorChar;
				}
				else if (Application.platform == RuntimePlatform.WindowsPlayer)
				{
					_personalFolder = Application.dataPath + directorySeparatorChar + ".." + directorySeparatorChar;
				}
			}
			else
			{
				string dataPath2 = Application.dataPath;
				directorySeparatorChar2 = Path.DirectorySeparatorChar;
				_personalFolder = dataPath2 + directorySeparatorChar2;
			}
			_personalAppDataFolder = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
			_sessionConfigFolder = _myDocumentsFolder + directorySeparatorChar + "My Games" + directorySeparatorChar + AssemblyInfoAccessor.Title + directorySeparatorChar;
			if (Application.isEditor)
			{
				_personalLogFolder = _personalFolder + string.Format("{0}..{0}logs{0}", directorySeparatorChar);
				_personalScreenshotsFolder = _personalFolder + string.Format("{0}..{0}screenshots{0}", directorySeparatorChar);
			}
			else
			{
				_personalLogFolder = _personalFolder + string.Format("{0}logs{0}", Path.DirectorySeparatorChar);
				_personalScreenshotsFolder = _personalFolder + string.Format("{0}screenshots{0}", Path.DirectorySeparatorChar);
			}
			if (Application.isEditor)
			{
				_personalConfigFolder = "Assets/Resources/Profiles/editor/";
			}
			else
			{
				string personalFolder = _personalFolder;
				directorySeparatorChar2 = Path.DirectorySeparatorChar;
				_personalConfigFolder = personalFolder + "Profiles" + directorySeparatorChar2;
			}
			if (Application.isEditor)
			{
				_commonConfigFolder = "Assets/Resources/Profiles/editor/";
			}
			else if (Application.platform == RuntimePlatform.WindowsPlayer)
			{
				string dataPath3 = Application.dataPath;
				directorySeparatorChar2 = Path.DirectorySeparatorChar;
				string text = directorySeparatorChar2.ToString();
				directorySeparatorChar2 = Path.DirectorySeparatorChar;
				_commonConfigFolder = dataPath3 + text + "Profiles" + directorySeparatorChar2;
			}
			else if (Application.platform == RuntimePlatform.OSXPlayer)
			{
				string[] obj = new string[6]
				{
					Application.dataPath,
					null,
					null,
					null,
					null,
					null
				};
				directorySeparatorChar2 = Path.DirectorySeparatorChar;
				obj[1] = directorySeparatorChar2.ToString();
				obj[2] = "Data";
				directorySeparatorChar2 = Path.DirectorySeparatorChar;
				obj[3] = directorySeparatorChar2.ToString();
				obj[4] = "Profiles";
				directorySeparatorChar2 = Path.DirectorySeparatorChar;
				obj[5] = directorySeparatorChar2.ToString();
				_commonConfigFolder = string.Concat(obj);
			}
			if (Application.isEditor)
			{
				DirectoryInfo directoryInfo = new DirectoryInfo(Application.dataPath);
				string[] obj2 = new string[6]
				{
					directoryInfo.Parent.Parent.Parent.FullName,
					null,
					null,
					null,
					null,
					null
				};
				directorySeparatorChar2 = Path.DirectorySeparatorChar;
				obj2[1] = directorySeparatorChar2.ToString();
				obj2[2] = "ProfilesExternals";
				directorySeparatorChar2 = Path.DirectorySeparatorChar;
				obj2[3] = directorySeparatorChar2.ToString();
				obj2[4] = "PvP";
				directorySeparatorChar2 = Path.DirectorySeparatorChar;
				obj2[5] = directorySeparatorChar2.ToString();
				_inputConfigFolder = string.Concat(obj2);
			}
			else
			{
				_inputConfigFolder = _commonConfigFolder;
			}
			_resourcesFolder = Application.dataPath;
			if (Application.isEditor)
			{
				_resourcesFolder = new DirectoryInfo(_resourcesFolder).Parent.Parent.Parent.FullName;
			}
			_resourcesFolder = _resourcesFolder.Replace('\\', Path.DirectorySeparatorChar);
			string resourcesFolder = _resourcesFolder;
			directorySeparatorChar2 = Path.DirectorySeparatorChar;
			string text2 = directorySeparatorChar2.ToString();
			directorySeparatorChar2 = Path.DirectorySeparatorChar;
			_resourcesFolder = resourcesFolder + text2 + "Resources" + directorySeparatorChar2;
			if (Application.platform == RuntimePlatform.OSXPlayer || Application.platform == RuntimePlatform.WindowsPlayer)
			{
				_spectatorClientFileName = Application.dataPath;
				_spectatorClientFileName = new DirectoryInfo(_spectatorClientFileName).Parent.Parent.FullName;
				_spectatorClientFileName += string.Format("{0}PvP{0}BinS{0}PW_Game.exe", directorySeparatorChar);
			}
			if (Application.isEditor)
			{
				_unityLogFilePath = string.Empty;
			}
			else if (Application.platform == RuntimePlatform.WindowsPlayer)
			{
				string dataPath4 = Application.dataPath;
				directorySeparatorChar2 = Path.DirectorySeparatorChar;
				_unityLogFilePath = dataPath4 + directorySeparatorChar2 + "output_log.txt";
			}
			else if (Application.platform == RuntimePlatform.OSXPlayer)
			{
				string[] obj3 = new string[9]
				{
					Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
					null,
					null,
					null,
					null,
					null,
					null,
					null,
					null
				};
				directorySeparatorChar2 = Path.DirectorySeparatorChar;
				obj3[1] = directorySeparatorChar2.ToString();
				obj3[2] = "Library";
				directorySeparatorChar2 = Path.DirectorySeparatorChar;
				obj3[3] = directorySeparatorChar2.ToString();
				obj3[4] = "Logs";
				directorySeparatorChar2 = Path.DirectorySeparatorChar;
				obj3[5] = directorySeparatorChar2.ToString();
				obj3[6] = "Unity";
				directorySeparatorChar2 = Path.DirectorySeparatorChar;
				obj3[7] = directorySeparatorChar2.ToString();
				obj3[8] = "Player.log";
				_unityLogFilePath = string.Concat(obj3);
			}
			_initNow = DateTime.UtcNow;
			_logsFolderName = _personalLogFolder + _initNow.ToString("yyyy.MM.dd-HH.mm.ss.fff");
			_productName = $"{AssemblyInfoAccessor.ShortTitle}-{AssemblyInfoAccessor.BranchVersion}-{AssemblyInfoAccessor.FullVersion}";
			_castleExecutableDirectory = Directory.GetParent(Application.dataPath).FullName;
			_inited = true;
		}
	}
}
