using System;
using System.IO;
using System.Xml.Linq;

[Serializable]
public class WOCMetaData
{
	public enum FileType
	{
		Contraption = 0,
		Level = 1
	}

	public string WorkshopId { get; set; }

	public string LocalId { get; set; }

	public FileType Type { get; set; }

	public void SaveToDisk(string filePath)
	{
		XDocument.Parse(this.XmlSerialize()).Save(filePath);
	}

	public static WOCMetaData LoadFromDisk(string filePath)
	{
		if (File.Exists(filePath))
		{
			return File.ReadAllText(filePath).XmlDeserialize<WOCMetaData>();
		}
		return null;
	}

	public static WOCMetaData LoadFromCreationModel(CreationModel creationModel)
	{
		return LoadFromOtherFilePath(creationModel.FilePath);
	}

	public static WOCMetaData LoadFromLevelModel(LevelModel levelModel)
	{
		return LoadFromOtherFilePath(levelModel.FilePath);
	}

	private static WOCMetaData LoadFromOtherFilePath(string filePath)
	{
		if (string.IsNullOrEmpty(filePath) || string.IsNullOrWhiteSpace(filePath))
		{
			return null;
		}
		string[] files = Directory.GetFiles(Path.GetDirectoryName(filePath), "*.wocmeta", SearchOption.TopDirectoryOnly);
		if (files.Length == 0)
		{
			return null;
		}
		return LoadFromDisk(files[0]);
	}
}
