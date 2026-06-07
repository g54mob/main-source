using TMPro;
using UnityEngine.UI;

public class MotorBlockPropertyView : BaseGUIPanelView
{
	private readonly TextMeshProUGUI jointsText;

	private readonly Button removeAllJointsButton;

	private HingeEditorView hingeEditorView;

	public MotorBlockPropertyView(HingeEditorView hingeEditorView)
	{
		this.hingeEditorView = hingeEditorView;
		base.MainPanel = hingeEditorView.mainPanel.transform.FindChildRecursively("MotorBlockPropertyPanel").gameObject;
		jointsText = base.MainPanel.transform.FindComponent<TextMeshProUGUI>("JointsText", isRecursively: true);
		removeAllJointsButton = base.MainPanel.transform.FindComponent<Button>("RemoveAllJointsButton", isRecursively: true);
		removeAllJointsButton.onClick.AddListener(hingeEditorView.RemoveAllHingeJointsFromMotorHandler);
	}

	public void UpdateMotorBlockPanel(BlockBodyModel motorBlockBodyModel)
	{
		ComponentModel componentModel = motorBlockBodyModel.GetComponentModel(ComponentType.Motor);
		int num = (componentModel.InternalProperties[MotorModel.Name] as MotorModel).HingeJointsCount();
		int propertyAsInt = componentModel.Properties.GetPropertyAsInt("maxJoints");
		hingeEditorView.HeaderHingeEditorView.SetTitleAndIcon(motorBlockBodyModel.BodySchematic.ParentSchematic.Name, HeaderHingeEditorView.IconType.MotorBlock);
		jointsText.text = "\uf085 " + num + " / " + propertyAsInt;
		removeAllJointsButton.interactable = num != 0;
	}
}
