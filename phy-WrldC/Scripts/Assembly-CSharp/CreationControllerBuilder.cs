using UnityEngine;

public static class CreationControllerBuilder
{
	public static CreationView BuildCreationView(Transform parent)
	{
		GameObject gameObject = new GameObject("CreationView");
		if (parent != null)
		{
			gameObject.transform.SetParent(parent);
		}
		CreationView creationView = gameObject.AddComponent<CreationView>();
		creationView.CreationRendererType = CreationView.CreationRendererTypeEnum.None;
		return creationView;
	}

	public static CreationController BuildPlaceholderController(CreationModel creationModel)
	{
		CreationView creationView = BuildCreationView(null);
		creationView.CreationRendererType = CreationView.CreationRendererTypeEnum.Placeholder;
		CreationController result = BuildController(creationModel, creationView, isGroupCentered: false);
		creationView.gameObject.AddComponent<PlaceholderCreation>();
		return result;
	}

	public static CreationController BuildModelController(CreationModel creationModel, Transform parent)
	{
		CreationView creationView = BuildCreationView(parent);
		creationView.CreationRendererType = CreationView.CreationRendererTypeEnum.Model;
		return BuildController(creationModel, creationView, isGroupCentered: true);
	}

	public static CreationController BuildRigidController(CreationModel creationModel)
	{
		return BuildRigidController(creationModel, isGroupCentered: false);
	}

	public static CreationController BuildRigidController(CreationModel creationModel, bool isGroupCentered, Transform parent = null)
	{
		CreationView creationView = BuildCreationView(parent);
		creationView.CreationRendererType = CreationView.CreationRendererTypeEnum.Rigid;
		creationView.LogicSystemView = creationView.gameObject.AddComponent<LogicSystemView>();
		return BuildController(creationModel, creationView, isGroupCentered);
	}

	private static CreationController BuildController(CreationModel creationModel, CreationView creationView, bool isGroupCentered)
	{
		creationView.IsGroupCentered = isGroupCentered;
		return new CreationController(creationView, creationModel);
	}
}
