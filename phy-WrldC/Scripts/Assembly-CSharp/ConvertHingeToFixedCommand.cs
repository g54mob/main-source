public class ConvertHingeToFixedCommand : Command<ConstructionCommandFeedback>
{
	private CreationModel creationModel;

	private HingeJointModel hingeJointModel;

	public FixedJointModel FixedJointModel { get; private set; }

	public ConvertHingeToFixedCommand(CreationModel creationModel, HingeJointModel hingeJointModel)
	{
		this.creationModel = creationModel;
		this.hingeJointModel = hingeJointModel;
	}

	public override ConstructionCommandFeedback Execute()
	{
		FixedJointModel = creationModel.ConvertHingeJointToFixedJoint(hingeJointModel, FixedJointModel);
		return ConstructionCommandFeedback.Executed;
	}

	public override void Revert()
	{
		hingeJointModel = creationModel.ConvertFixedJointToHingeJoint(FixedJointModel, hingeJointModel);
	}
}
