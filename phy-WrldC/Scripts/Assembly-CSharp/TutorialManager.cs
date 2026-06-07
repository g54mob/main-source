using System.Collections.Generic;

public class TutorialManager
{
	private Dictionary<string, CreationModel> creationModels;

	private Dictionary<string, QuickInventoryModel> quickInventoryModels;

	public static TutorialManager Instance { get; } = new TutorialManager();

	private TutorialManager()
	{
		creationModels = new Dictionary<string, CreationModel>();
		quickInventoryModels = new Dictionary<string, QuickInventoryModel>();
	}

	public void AddCreationModel(string tutorialId, CreationModel creationModel)
	{
		if (creationModels.ContainsKey(tutorialId))
		{
			creationModels[tutorialId] = creationModel;
		}
		else
		{
			creationModels.Add(tutorialId, creationModel);
		}
	}

	public CreationModel GetClonedCreationModel(string tutorialId)
	{
		if (!creationModels.ContainsKey(tutorialId))
		{
			return null;
		}
		return CreationCloner.Clone(creationModels[tutorialId]);
	}

	public void AddQuickInventoryModel(string tutorialId, QuickInventoryModel quickInventoryModel)
	{
		if (quickInventoryModels.ContainsKey(tutorialId))
		{
			quickInventoryModels[tutorialId] = quickInventoryModel;
		}
		else
		{
			quickInventoryModels.Add(tutorialId, quickInventoryModel);
		}
	}

	public QuickInventoryModel GetClonedQuickInventoryModel(string tutorialId)
	{
		if (!quickInventoryModels.ContainsKey(tutorialId))
		{
			return null;
		}
		return quickInventoryModels[tutorialId].Clone<QuickInventoryModel>();
	}
}
