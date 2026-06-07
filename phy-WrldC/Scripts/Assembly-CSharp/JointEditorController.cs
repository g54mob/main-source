public class JointEditorController : BaseController<JointEditorView>
{
	public JointEditorController(JointEditorView view)
		: base(view)
	{
	}

	protected override void ViewChangeHandler(string eventName, params object[] data)
	{
		switch (eventName)
		{
		case "JointEditorView.ConvertToHingeJointEvent":
		{
			AllJointsButton3D allJointsButton3D = data[0] as AllJointsButton3D;
			CreationModel model4 = GameManager.Instance.MainCreationController.model;
			FixedJointModel fixedJointModel = allJointsButton3D.FixedJointModel;
			ConvertFixedToHingeCommand convertFixedToHingeCommand = new ConvertFixedToHingeCommand(model4, fixedJointModel);
			GameManager.Instance.ConstructionCommandManager.ExecuteNewCommand(convertFixedToHingeCommand);
			allJointsButton3D.HingeJointModel = convertFixedToHingeCommand.HingeJointModel;
			allJointsButton3D.SetJointType(AllJointsButton3D.JointTypeEnum.Hinge);
			view.AllJointsButtonSelectedHandler(allJointsButton3D);
			break;
		}
		case "JointEditorView.ConvertToFixedJointEvent":
		{
			AllJointsButton3D allJointsButton3D = data[0] as AllJointsButton3D;
			CreationModel model3 = GameManager.Instance.MainCreationController.model;
			HingeJointModel hingeJointModel = allJointsButton3D.HingeJointModel;
			ConvertHingeToFixedCommand convertHingeToFixedCommand = new ConvertHingeToFixedCommand(model3, hingeJointModel);
			GameManager.Instance.ConstructionCommandManager.ExecuteNewCommand(convertHingeToFixedCommand);
			allJointsButton3D.FixedJointModel = convertHingeToFixedCommand.FixedJointModel;
			allJointsButton3D.SetJointType(AllJointsButton3D.JointTypeEnum.FullInfoFixed);
			view.AllJointsButtonSelectedHandler(allJointsButton3D);
			break;
		}
		case "JointEditorView.RemoveFixedJointEvent":
		{
			AllJointsButton3D allJointsButton3D = data[0] as AllJointsButton3D;
			CreationModel model2 = GameManager.Instance.MainCreationController.model;
			FixedJointModel fixedJointModel = allJointsButton3D.FixedJointModel;
			RemoveFixedJointCommand command2 = new RemoveFixedJointCommand(model2, fixedJointModel);
			GameManager.Instance.ConstructionCommandManager.ExecuteNewCommand(command2);
			allJointsButton3D.gameObject.SetActive(value: false);
			JointEditorState.Instance.UnSelectButton3D();
			break;
		}
		case "JointEditorView.RemoveHingeJointEvent":
		{
			AllJointsButton3D allJointsButton3D = data[0] as AllJointsButton3D;
			CreationModel model = GameManager.Instance.MainCreationController.model;
			HingeJointModel hingeJointModel = allJointsButton3D.HingeJointModel;
			RemoveHingeJointCommand command = new RemoveHingeJointCommand(model, hingeJointModel);
			GameManager.Instance.ConstructionCommandManager.ExecuteNewCommand(command);
			allJointsButton3D.gameObject.SetActive(value: false);
			JointEditorState.Instance.UnSelectButton3D();
			break;
		}
		case "JointEditorView.CloseWindowEvent":
			JointEditorState.Instance.UnSelectButton3D();
			break;
		}
	}
}
