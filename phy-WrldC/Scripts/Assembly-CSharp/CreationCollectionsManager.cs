public class CreationCollectionsManager
{
	public CreationModelCollection CreationModelFromSchematicCollection { get; private set; }

	public CreationModelCollection DevCreationModelCollection { get; private set; }

	public CreationModelCollection UserCreationModelCollection { get; private set; }

	public CreationModelCollection MenuCreationModelCollection { get; private set; }

	public CreationModelCollection BestCreationModelCollection { get; private set; }

	public CreationCollectionsManager()
	{
		CreationModelFromSchematicCollection = new CreationModelCollection();
		DevCreationModelCollection = new CreationModelCollection();
		UserCreationModelCollection = new CreationModelCollection();
		MenuCreationModelCollection = new CreationModelCollection();
		BestCreationModelCollection = new CreationModelCollection();
	}

	public CreationModel GetCreationModel(string id)
	{
		CreationModel creationModel = CreationModelFromSchematicCollection.GetCreationModel(id);
		if (creationModel == null)
		{
			creationModel = DevCreationModelCollection.GetCreationModel(id);
		}
		if (creationModel == null)
		{
			creationModel = UserCreationModelCollection.GetCreationModel(id);
		}
		return creationModel;
	}
}
