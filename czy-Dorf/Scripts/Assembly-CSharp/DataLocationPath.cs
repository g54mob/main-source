using UnityEngine;

public static class DataLocationPath
{
	public static string GetPath(DataLocation dataLocation)
	{
		return dataLocation switch
		{
			DataLocation.PersistentDataPath => Constants.persistentDataPath, 
			DataLocation.StreamingAssetsPath => Application.streamingAssetsPath, 
			_ => "", 
		};
	}
}
