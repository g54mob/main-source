using UnityEngine;

public class NewPositionCommand : Command<ConstructionCommandFeedback>
{
	private CreationModel creationModel;

	private Vector3 newPosition;

	private Quaternion newRotation;

	private Vector3 oldPosition;

	private Quaternion oldRotation;

	public NewPositionCommand(CreationModel creationModel, Vector3 position, Quaternion rotation)
	{
		this.creationModel = creationModel;
		newPosition = position;
		newRotation = rotation;
		oldPosition = creationModel.Position;
		oldRotation = creationModel.Rotation;
	}

	public override ConstructionCommandFeedback Execute()
	{
		creationModel.SetPositions(newPosition, newRotation);
		return ConstructionCommandFeedback.Executed;
	}

	public override void Revert()
	{
		creationModel.SetPositions(oldPosition, oldRotation);
	}
}
