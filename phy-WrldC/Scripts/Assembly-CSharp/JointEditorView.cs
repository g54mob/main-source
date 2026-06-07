using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class JointEditorView : BaseGUIView
{
	public const string ConvertToHingeJointEvent = "JointEditorView.ConvertToHingeJointEvent";

	public const string ConvertToFixedJointEvent = "JointEditorView.ConvertToFixedJointEvent";

	public const string RemoveFixedJointEvent = "JointEditorView.RemoveFixedJointEvent";

	public const string RemoveHingeJointEvent = "JointEditorView.RemoveHingeJointEvent";

	public const string CloseWindowEvent = "JointEditorView.CloseWindowEvent";

	private GameObject jointConfigPanel;

	private TextMeshProUGUI jointNameText;

	private TextMeshProUGUI infosText;

	private TextMeshProUGUI convertJointText;

	private Button convertJointButton;

	private Button removeJointButton;

	private Button closeButton;

	private LanguagesManager languagesManager;

	private AllJointsButton3D currentButton3D;

	public override void Initialize()
	{
		languagesManager = GameManager.Instance.LanguagesManager;
		jointConfigPanel = mainPanel.transform.Find("JointConfigPanel").gameObject;
		jointNameText = jointConfigPanel.transform.FindComponent<TextMeshProUGUI>("JointNameText", isRecursively: true);
		infosText = jointConfigPanel.transform.FindComponent<TextMeshProUGUI>("InfosText", isRecursively: true);
		convertJointButton = jointConfigPanel.transform.FindComponent<Button>("ConvertJointButton", isRecursively: true);
		removeJointButton = jointConfigPanel.transform.FindComponent<Button>("RemoveJointButton", isRecursively: true);
		closeButton = jointConfigPanel.transform.FindComponent<Button>("CloseButton", isRecursively: true);
		convertJointText = convertJointButton.transform.FindComponent<TextMeshProUGUI>("Text", isRecursively: true);
		convertJointButton.onClick.AddListener(delegate
		{
			ConvertJointButtonHandler();
		});
		removeJointButton.onClick.AddListener(delegate
		{
			RemoveJointButtonHandler();
		});
		closeButton.onClick.AddListener(delegate
		{
			NotifyChange("JointEditorView.CloseWindowEvent");
		});
		Util.AddMouseOverUIEvents(jointConfigPanel, base.OnMouseOverUIHandler);
		jointConfigPanel.SetActive(value: false);
	}

	public void AllJointsButtonDeselectedHandler()
	{
		base.IsMouseOverUI = false;
		currentButton3D = null;
		jointConfigPanel.SetActive(value: false);
	}

	public void AllJointsButtonSelectedHandler(Button3D button3D)
	{
		if (button3D != currentButton3D)
		{
			GameManager.Instance.UIAudioEffectsManager.PlayAudio(GameManager.Instance.GameStylesData.blockSelected, GameManager.Instance.GameStylesData.volumeStylesData.uiVolume);
		}
		currentButton3D = button3D as AllJointsButton3D;
		if (!(currentButton3D == null))
		{
			bool num = currentButton3D.JointType == AllJointsButton3D.JointTypeEnum.Hinge;
			bool flag = currentButton3D.JointType == AllJointsButton3D.JointTypeEnum.LessInfoFixed;
			string id = (num ? "label.text.connection.hinge" : "label.text.connection.fixed");
			string text = languagesManager.GetText(id);
			jointNameText.text = text;
			string id2 = (num ? "button.text.connection.convertfixed" : "button.text.connection.converthinge");
			string text2 = languagesManager.GetText(id2);
			convertJointText.text = "<b>" + text2 + "</b>";
			convertJointButton.interactable = !flag;
			infosText.gameObject.SetActive(flag);
			jointConfigPanel.SetActive(value: true);
		}
	}

	private void ConvertJointButtonHandler()
	{
		if (!(currentButton3D == null))
		{
			if (currentButton3D.JointType == AllJointsButton3D.JointTypeEnum.FullInfoFixed)
			{
				NotifyChange("JointEditorView.ConvertToHingeJointEvent", currentButton3D);
			}
			else if (currentButton3D.JointType == AllJointsButton3D.JointTypeEnum.Hinge)
			{
				NotifyChange("JointEditorView.ConvertToFixedJointEvent", currentButton3D);
			}
		}
	}

	private void RemoveJointButtonHandler()
	{
		if (!(currentButton3D == null))
		{
			if (currentButton3D.JointType == AllJointsButton3D.JointTypeEnum.FullInfoFixed || currentButton3D.JointType == AllJointsButton3D.JointTypeEnum.LessInfoFixed)
			{
				NotifyChange("JointEditorView.RemoveFixedJointEvent", currentButton3D);
			}
			else if (currentButton3D.JointType == AllJointsButton3D.JointTypeEnum.Hinge)
			{
				NotifyChange("JointEditorView.RemoveHingeJointEvent", currentButton3D);
			}
		}
	}
}
