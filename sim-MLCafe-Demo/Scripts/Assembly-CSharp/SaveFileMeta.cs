using System;
using System.Collections.Generic;

[Serializable]
public class SaveFileMeta
{
	public string lastPlayedFile;

	public List<GameDataPreview> files = new List<GameDataPreview>();
}
