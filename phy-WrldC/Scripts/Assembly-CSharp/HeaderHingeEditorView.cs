using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HeaderHingeEditorView : BaseGUIPanelView
{
	public enum IconType
	{
		None = 0,
		HingeJoint = 1,
		MotorBlock = 2
	}

	private TextMeshProUGUI headerText;

	private Button closeButton;

	private GameObject hingeIcon;

	private GameObject motorIcon;

	public HeaderHingeEditorView(HingeEditorView hingeEditorView)
	{
		base.MainPanel = hingeEditorView.mainPanel.transform.FindChildRecursively("HeaderPanel").gameObject;
		headerText = base.MainPanel.transform.FindComponent<TextMeshProUGUI>("HeaderText", isRecursively: true);
		closeButton = base.MainPanel.transform.FindComponent<Button>("CloseButton", isRecursively: true);
		hingeIcon = base.MainPanel.transform.FindChildRecursively("HingeIcon").gameObject;
		motorIcon = base.MainPanel.transform.FindChildRecursively("MotorIcon").gameObject;
		closeButton.onClick.AddListener(hingeEditorView.CloseWindowHanlder);
	}

	public void SetTitleAndIcon(string title, IconType iconType)
	{
		headerText.text = title;
		switch (iconType)
		{
		case IconType.None:
			hingeIcon.SetActive(value: false);
			motorIcon.SetActive(value: false);
			break;
		case IconType.HingeJoint:
			hingeIcon.SetActive(value: true);
			motorIcon.SetActive(value: false);
			break;
		case IconType.MotorBlock:
			hingeIcon.SetActive(value: false);
			motorIcon.SetActive(value: true);
			break;
		}
	}
}
