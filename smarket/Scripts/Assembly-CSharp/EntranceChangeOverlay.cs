using TMPro;
using UnityEngine;
using UnityEngine.UI;
using __Project__.Scripts.Cameras;
using __Project__.Scripts.ControllerInputModule;

public class EntranceChangeOverlay : MonoBehaviour
{
	[SerializeField]
	private Button m_ApproveButton;

	[SerializeField]
	private Button m_CancelButton;

	[SerializeField]
	private TMP_Text m_PriceText;

	[SerializeField]
	private GameObject m_EntranceChangeCamera;

	[SerializeField]
	private GameObject m_InteractableParent;

	[SerializeField]
	private TMP_Text m_ApprovedCanvas;

	[SerializeField]
	private TMP_Text m_SwitchTitleText;

	[SerializeField]
	private GamePadUIPanel m_gamepadPanel;

	private DoorSwitchCamera m_DoorCamera;

	private float m_Price;

	public void Initialize(float price, DoorSwitchCamera switchCamera)
	{
	}

	public void Approve()
	{
	}

	public void Cancel()
	{
	}

	public void NextButton()
	{
	}

	public void PrevButton()
	{
	}

	private void OnDisable()
	{
	}
}
