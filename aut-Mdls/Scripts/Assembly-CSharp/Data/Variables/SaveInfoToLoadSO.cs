using UnityEngine;

namespace Data.Variables
{
	[CreateAssetMenu(menuName = "Variables/SaveInfoToLoad", fileName = "SaveInfoToLoad", order = 0)]
	public class SaveInfoToLoadSO : ScriptableObject
	{
		public class Info
		{
			public string SavePath;

			public string NewSaveMapPath;

			public bool NewSaveIsZen;

			public Info(string savePath)
			{
				SavePath = savePath;
				NewSaveMapPath = string.Empty;
				NewSaveIsZen = false;
			}

			public Info(string savePath, string mapPath, bool isZenMode)
			{
				SavePath = savePath;
				NewSaveMapPath = mapPath;
				NewSaveIsZen = isZenMode;
			}
		}

		private const string StreamingAssetsPath = "StreamingAssets";

		private Info _value;

		public Info Value => _value;

		private void OnEnable()
		{
			_value = null;
		}

		private void OnDisable()
		{
			_value = null;
		}

		public void SetPathToLoad(string savePath)
		{
			_value = new Info(savePath);
		}

		public void SetNewSave(string savePath, string mapPath, bool isZenMode)
		{
			_value = new Info(savePath, mapPath, isZenMode);
		}

		public static bool IsSaveablePath(string path)
		{
			if (!string.IsNullOrEmpty(path) && path.Contains("StreamingAssets"))
			{
				return false;
			}
			return true;
		}
	}
}
