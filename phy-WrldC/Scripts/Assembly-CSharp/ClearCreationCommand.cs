public class ClearCreationCommand : Command<ConstructionCommandFeedback>
{
	private CreationController creationController;

	private CreationModel originalCreationModel;

	private CreationModel newCreationModel;

	public ClearCreationCommand(CreationController creationController)
	{
		this.creationController = creationController;
		originalCreationModel = creationController.model;
		newCreationModel = new CreationModel("0", "", "");
	}

	public override ConstructionCommandFeedback Execute()
	{
		creationController.SetModel(newCreationModel);
		return ConstructionCommandFeedback.Executed;
	}

	public override void Revert()
	{
		creationController.SetModel(originalCreationModel);
	}
}
