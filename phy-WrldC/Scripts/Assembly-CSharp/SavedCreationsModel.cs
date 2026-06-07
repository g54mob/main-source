using System.Collections.Generic;

public class SavedCreationsModel : BaseModel
{
	public const string AddCreationEvent = "SavedCreationsModel.AddCreation";

	public const string RemoveCreationEvent = "SavedCreationsModel.RemoveCreation";

	private readonly List<CreationModel> savedCreations;

	public SavedCreationsModel()
	{
		savedCreations = new List<CreationModel>();
	}

	public void AddCreation(CreationModel creationModel)
	{
		savedCreations.Add(creationModel);
		int num = CreationModelCountByPlace(creationModel.Place);
		NotifyChange("SavedCreationsModel.AddCreation", creationModel, num - 1);
	}

	public void RemoveCreation(CreationModel creationModel)
	{
		RemoveCreation(savedCreations.IndexOf(creationModel));
	}

	private void RemoveCreation(int index)
	{
		savedCreations.RemoveAt(index);
		NotifyChange("SavedCreationsModel.RemoveCreation", index);
	}

	public void RemoveCreationByFilePath(string filePath)
	{
		CreationModel creationModel = null;
		foreach (CreationModel savedCreation in savedCreations)
		{
			if (savedCreation.FilePath == filePath)
			{
				creationModel = savedCreation;
				break;
			}
		}
		if (creationModel != null)
		{
			RemoveCreation(creationModel);
		}
	}

	public CreationModel GetCreationModel(int index)
	{
		return savedCreations[index];
	}

	public ICollection<CreationModel> GetAllCreationModels()
	{
		return savedCreations;
	}

	public int CreationModelCount()
	{
		return savedCreations.Count;
	}

	private int CreationModelCountByPlace(CreationModel.CreationPlace creationPlace)
	{
		int num = 0;
		for (int i = 0; i < savedCreations.Count; i++)
		{
			if (savedCreations[i].Place == creationPlace)
			{
				num++;
			}
		}
		return num;
	}
}
