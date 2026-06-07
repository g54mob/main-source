using System.Collections.Generic;

public class CreationModelCollection
{
	private readonly Dictionary<string, CreationModel> collection;

	public CreationModelCollection()
	{
		collection = new Dictionary<string, CreationModel>();
	}

	public void AddCreationModel(CreationModel creationModel)
	{
		collection.Add(creationModel.Id, creationModel);
	}

	public CreationModel GetCreationModel(string id)
	{
		if (!collection.ContainsKey(id))
		{
			return null;
		}
		return collection[id];
	}

	public bool HasCreationModel(CreationModel creationModel)
	{
		return collection.ContainsKey(creationModel.Id);
	}

	public ICollection<CreationModel> GetAllCreationModels()
	{
		return collection.Values;
	}

	public void RemoveCreationModel(string id)
	{
		if (collection.ContainsKey(id))
		{
			collection.Remove(id);
		}
	}

	public int CreationModelCount()
	{
		return collection.Values.Count;
	}
}
