using System.Collections.Generic;

public class CategoryModel
{
	private readonly List<CreationModel> creationModelList;

	public string Name { get; private set; }

	public CategoryModel(string name)
	{
		Name = name;
		creationModelList = new List<CreationModel>();
	}

	public CreationModel GetCreationModel(int index)
	{
		if (index >= creationModelList.Count)
		{
			return null;
		}
		return creationModelList[index];
	}

	public int GetCreationModelIndex(CreationModel creationModel)
	{
		return creationModelList.IndexOf(creationModel);
	}

	public void AddCreationModel(CreationModel creationModel)
	{
		creationModelList.Add(creationModel);
	}

	public void RemoveCreationModel(CreationModel creationModel)
	{
		creationModelList.Remove(creationModel);
	}

	public ICollection<CreationModel> GetAllCreationModel()
	{
		return creationModelList.ToArray();
	}

	public int CreationModelCount()
	{
		return creationModelList.Count;
	}
}
