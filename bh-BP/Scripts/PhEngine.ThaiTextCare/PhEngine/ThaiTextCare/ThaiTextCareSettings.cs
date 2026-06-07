using UnityEngine;

namespace PhEngine.ThaiTextCare
{
	public class ThaiTextCareSettings : ScriptableObject
	{
		[Header("General")]
		[SerializeField]
		private string dictionaryResourcePath;

		[SerializeField]
		private WordBreakType wordBreakType;

		[SerializeField]
		private string customCharacter;

		[Header("Editor-Only")]
		[SerializeField]
		private bool loadDictionaryOnStart;

		public const string PluginsFolderPath = "Plugins/ThaiTextCare/Resources/";

		private static ThaiTextCareSettings unsafeInstance;

		public string WordBreakCharacter => null;

		public string DictionaryResourcePath => null;

		public bool IsLoadDictionaryOnEditorStartUp => false;

		public static string SettingsPath => null;

		public static ThaiTextCareSettings PrepareInstance()
		{
			return null;
		}
	}
}
