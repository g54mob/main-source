public class ConvertFixedToHingeCommand : Command<ConstructionCommandFeedback>
{
	private CreationModel creationModel;

	private FixedJointModel fixedJointModel;

	public HingeJointModel HingeJointModel { get; private set; }

	public ConvertFixedToHingeCommand(CreationModel creationModel, FixedJointModel fixedJointModel)
	{
		this.creationModel = creationModel;
		this.fixedJointModel = fixedJointModel;
	}

	public override ConstructionCommandFeedback Execute()
	{
		HingeJointModel = creationModel.ConvertFixedJointToHingeJoint(fixedJointModel, HingeJointModel);
		return ConstructionCommandFeedback.Executed;
	}

	public override void Revert()
	{
		fixedJointModel = creationModel.ConvertHingeJointToFixedJoint(HingeJointModel, fixedJointModel);
	}
}
