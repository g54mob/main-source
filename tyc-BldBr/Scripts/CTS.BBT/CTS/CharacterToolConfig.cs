using UnityEngine;

namespace CTS
{
	public class CharacterToolConfig : ScriptableObject
	{
		public string mainPath = "Scriptables\\AgentVisualDatas\\Bodies";

		public string eyesFolderPath;

		public string charactersFolderPath;

		private static string _configFolder = "Resources/Config/";

		private static string _configFile = "CharacterToolEditorConfig.asset";

		private static CharacterToolConfig _config;

		public static CharacterToolConfig Config
		{
			get
			{
				if (_config == null)
				{
					CharacterToolConfig obj = (CharacterToolConfig)ScriptableObject.CreateInstance(typeof(CharacterToolConfig));
					obj.eyesFolderPath = "";
					obj.charactersFolderPath = "";
					obj.mainPath = "Scriptables/AgentVisualDatas/Bodies";
					_config = obj;
				}
				return _config;
			}
		}

		public static void SaveConfig()
		{
		}
	}
}
