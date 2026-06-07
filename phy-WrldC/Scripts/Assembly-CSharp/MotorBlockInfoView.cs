using TMPro;
using UnityEngine.UI;

public class MotorBlockInfoView : BaseGUIPanelView
{
	private readonly HingeEditorView hingeEditorView;

	private readonly TextMeshProUGUI motorNameText;

	private readonly TextMeshProUGUI motorPathText;

	private readonly Button removeMotorButton;

	public MotorBlockInfoView(HingeEditorView hingeEditorView)
	{
		this.hingeEditorView = hingeEditorView;
		base.MainPanel = hingeEditorView.mainPanel.transform.FindChildRecursively("MotorBlockInfoPanel").gameObject;
		motorNameText = base.MainPanel.transform.FindComponent<TextMeshProUGUI>("MotorNameText", isRecursively: true);
		motorPathText = base.MainPanel.transform.FindComponent<TextMeshProUGUI>("MotorPathText", isRecursively: true);
		removeMotorButton = base.MainPanel.transform.FindComponent<Button>("RemoveMotorButton", isRecursively: true);
		removeMotorButton.onClick.AddListener(RemoveMotorHandler);
	}

	public void UpdateMotorBlockInfoPanel(HingeJointModel hingeJointModel)
	{
		if (hingeJointModel.MotorBlockBodyModel != null)
		{
			motorNameText.gameObject.SetActive(value: true);
			motorNameText.text = "<#2BFF2CFF>" + hingeJointModel.MotorBlockBodyModel.BodySchematic.ParentSchematic.Name;
			removeMotorButton.gameObject.SetActive(value: true);
			bool flag = hingeJointModel.CheckPhysicalPathBetweenMotor();
			motorPathText.gameObject.SetActive(!flag);
		}
		else
		{
			string text = LanguagesManager.Instance.GetText("label.text.transmission.nomotor", "No motor plugged");
			motorNameText.gameObject.SetActive(value: true);
			motorNameText.text = "<#FF2B2BFF>" + text;
			removeMotorButton.gameObject.SetActive(value: false);
			motorPathText.gameObject.SetActive(value: false);
		}
	}

	public void RemoveMotorHandler()
	{
		hingeEditorView.RemoveMotorFromHingeJointHandler();
	}
}
