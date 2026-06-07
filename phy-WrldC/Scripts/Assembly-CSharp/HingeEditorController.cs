public class HingeEditorController : BaseController<HingeEditorView>
{
	public HingeEditorController(HingeEditorView view)
		: base(view)
	{
	}

	protected override void ViewChangeHandler(string eventName, params object[] data)
	{
		switch (eventName)
		{
		case "HingeEditorView.AddMotorJointEvent":
		{
			HingeJointModel obj4 = (HingeJointModel)data[0];
			int id = obj4.ParentBlockBodyModel.ParentBlockModel.Id;
			int index = obj4.ParentBlockBodyModel.Index;
			int index2 = obj4.Index;
			GameManager.Instance.MainCreationController.model.AddMotorJointModel(id, index, index2);
			view.RefreshPanels();
			break;
		}
		case "HingeEditorView.AddSteerableJointEvent":
		{
			HingeJointModel obj2 = (HingeJointModel)data[0];
			int id = obj2.ParentBlockBodyModel.ParentBlockModel.Id;
			int index = obj2.ParentBlockBodyModel.Index;
			int index2 = obj2.Index;
			GameManager.Instance.MainCreationController.model.AddSteerableJointModel(id, index, index2);
			view.RefreshPanels();
			break;
		}
		case "HingeEditorView.AddStepperJointEvent":
		{
			HingeJointModel obj10 = (HingeJointModel)data[0];
			int id = obj10.ParentBlockBodyModel.ParentBlockModel.Id;
			int index = obj10.ParentBlockBodyModel.Index;
			int index2 = obj10.Index;
			GameManager.Instance.MainCreationController.model.AddStepperJointModel(id, index, index2);
			view.RefreshPanels();
			break;
		}
		case "HingeEditorView.RemoveSpecializedJointsEvent":
		{
			HingeJointModel obj9 = (HingeJointModel)data[0];
			int id = obj9.ParentBlockBodyModel.ParentBlockModel.Id;
			int index = obj9.ParentBlockBodyModel.Index;
			int index2 = obj9.Index;
			GameManager.Instance.MainCreationController.model.RemoveSpecializedJointsModel(id, index, index2);
			view.RefreshPanels();
			break;
		}
		case "HingeEditorView.UpdateMotorJointEvent":
		{
			HingeJointModel obj8 = (HingeJointModel)data[0];
			int id = obj8.ParentBlockBodyModel.ParentBlockModel.Id;
			int index = obj8.ParentBlockBodyModel.Index;
			int index2 = obj8.Index;
			GameManager.Instance.MainCreationController.model.UpdateMotorJointModel(id, index, index2);
			break;
		}
		case "HingeEditorView.UpdateSteerableJointEvent":
		{
			HingeJointModel obj7 = (HingeJointModel)data[0];
			int id = obj7.ParentBlockBodyModel.ParentBlockModel.Id;
			int index = obj7.ParentBlockBodyModel.Index;
			int index2 = obj7.Index;
			GameManager.Instance.MainCreationController.model.UpdateSteerableJointModel(id, index, index2);
			break;
		}
		case "HingeEditorView.UpdateStepperJointEvent":
		{
			HingeJointModel obj6 = (HingeJointModel)data[0];
			int id = obj6.ParentBlockBodyModel.ParentBlockModel.Id;
			int index = obj6.ParentBlockBodyModel.Index;
			int index2 = obj6.Index;
			GameManager.Instance.MainCreationController.model.UpdateStepperJointModel(id, index, index2);
			break;
		}
		case "HingeEditorView.ConnectMotorToHingeJointEvent":
		{
			HingeJointModel obj5 = (HingeJointModel)data[0];
			BlockBodyModel blockBodyModel = (BlockBodyModel)data[1];
			int id2 = obj5.ParentBlockBodyModel.ParentBlockModel.Id;
			int index3 = obj5.ParentBlockBodyModel.Index;
			int index2 = obj5.Index;
			int id3 = blockBodyModel.ParentBlockModel.Id;
			int index4 = blockBodyModel.Index;
			GameManager.Instance.MainCreationController.model.ConnectMotorToHingeJoint(id2, index3, index2, id3, index4);
			break;
		}
		case "HingeEditorView.RemoveMotorFromHingeJointEvent":
		{
			HingeJointModel obj3 = (HingeJointModel)data[0];
			bool flag = (bool)data[1];
			int id = obj3.ParentBlockBodyModel.ParentBlockModel.Id;
			int index = obj3.ParentBlockBodyModel.Index;
			int index2 = obj3.Index;
			GameManager.Instance.MainCreationController.model.RemoveMotorFromHingeJoint(id, index, index2);
			if (flag)
			{
				view.RefreshPanels();
			}
			break;
		}
		case "HingeEditorView.RemoveAllHingeJointsFromMotor":
			foreach (HingeJointModel allHingeJointModel in ((data[0] as BlockBodyModel).GetComponentModel(ComponentType.Motor).InternalProperties[MotorModel.Name] as MotorModel).GetAllHingeJointModels())
			{
				int id = allHingeJointModel.ParentBlockBodyModel.ParentBlockModel.Id;
				int index = allHingeJointModel.ParentBlockBodyModel.Index;
				int index2 = allHingeJointModel.Index;
				GameManager.Instance.MainCreationController.model.RemoveMotorFromHingeJoint(id, index, index2);
			}
			view.RefreshPanels();
			break;
		case "HingeEditorView.ChangeAnchorPointEvent":
		{
			HingeJointModel obj = data[0] as HingeJointModel;
			bool isThisAnchorPoint = (bool)data[1];
			obj.IsThisAnchorPoint = isThisAnchorPoint;
			break;
		}
		case "HingeEditorView.CloseWindowEvent":
			HingeEditorState.Instance.UnSelectButton3D();
			break;
		}
	}
}
