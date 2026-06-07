using UnityEngine.Localization.Tables;

namespace ScriptableObjects.ScriptableObjectScripts.Settings
{
	public static class LocalizeTextUtils
	{
		public const string MissingMiscString = "MissingMiscString.txt";

		public const string MissmatchTextString = "MissmatchText.csv";

		public static string GetLocalizedMasterString(LocalizeTextMasterStringKey localizeTextMasterStringKey, params object[] args)
		{
			return null;
		}

		public static string ToSingle(string multi)
		{
			return null;
		}

		public static string ToMulti(string single)
		{
			return null;
		}

		public static string GetLocalizedMiscString(string textJa)
		{
			return null;
		}

		public static T Clone<T>(T org)
		{
			return default(T);
		}

		public static void UpdateSharedComment(SharedTableData.SharedTableEntry key, string commentText)
		{
		}

		public static void UpdateStringTableComment(StringTableEntry key, string commentText)
		{
		}
	}
}
