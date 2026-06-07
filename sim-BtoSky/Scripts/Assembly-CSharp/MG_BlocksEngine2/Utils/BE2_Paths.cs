using MG_BlocksEngine2.EditorScript;
using UnityEngine;

namespace MG_BlocksEngine2.Utils
{
	public class BE2_Paths
	{
		public static string NewInstructionPath
		{
			get
			{
				return BE2_Inspector.Instance.newInstructionPath;
			}
			set
			{
				BE2_Inspector.Instance.newInstructionPath = value;
			}
		}

		public static string NewBlockPrefabPath
		{
			get
			{
				return BE2_Inspector.Instance.newBlockPrefabPath;
			}
			set
			{
				BE2_Inspector.Instance.newBlockPrefabPath = value;
			}
		}

		public static string SavedCodesPath
		{
			get
			{
				return BE2_Inspector.Instance.savedCodesPath;
			}
			set
			{
				BE2_Inspector.Instance.savedCodesPath = value;
			}
		}

		public static string TranslateMarkupPath(string pathMarkup)
		{
			string text = pathMarkup;
			if (BE2_Inspector.Instance.usePersistentPathOnBuild && !Application.isEditor)
			{
				text = text.Replace("[dataPath]", Application.persistentDataPath);
				return text.Replace("[persistentDataPath]", Application.persistentDataPath);
			}
			text = text.Replace("[dataPath]", Application.dataPath);
			return text.Replace("[persistentDataPath]", Application.persistentDataPath);
		}

		public static string PathToResources(string pathMarkup)
		{
			if (!pathMarkup.ToLower().Contains("resources"))
			{
				Debug.LogError("The path is not set to a Resources folder.");
				return pathMarkup;
			}
			int num = pathMarkup.ToLower().IndexOf("resources/");
			return pathMarkup.Substring(num + 10);
		}
	}
}
