using UnityEngine;

public class MapLoader
{
	internal struct LoadFile
	{
		public string name;

		public GridEditionDataSO data;
	}

	private static LoadFile[] _files;

	public static string MainDirectory => Application.dataPath + "/Resources/" + FileRoot;

	public static string FileRoot => "Scriptables/MapEditorSaveFiles";

	internal static LoadFile[] Files
	{
		get
		{
			if (_files == null)
			{
				GridEditionDataSO[] array = Resources.LoadAll<GridEditionDataSO>("");
				_files = new LoadFile[array.Length];
				for (int i = 0; i < array.Length; i++)
				{
					_files[i] = new LoadFile
					{
						name = array[i].name,
						data = array[i]
					};
				}
			}
			return _files;
		}
	}

	public static string[] GetFilesNames()
	{
		string[] array = new string[Files.Length];
		for (int i = 0; i < Files.Length; i++)
		{
			array[i] = Files[i].name;
		}
		return array;
	}

	public static Coroutine LoadMap(string fileName)
	{
		for (int i = 0; i < Files.Length; i++)
		{
			if (Files[i].name == fileName)
			{
				return MapEditor.Load(Files[i].data);
			}
		}
		return null;
	}
}
