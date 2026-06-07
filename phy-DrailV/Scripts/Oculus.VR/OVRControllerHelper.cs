using UnityEngine;

public class OVRControllerHelper : MonoBehaviour
{
	private enum ControllerType
	{
		QuestAndRiftS = 1,
		Rift = 2,
		Quest2 = 3
	}

	public GameObject m_modelOculusTouchQuestAndRiftSLeftController;

	public GameObject m_modelOculusTouchQuestAndRiftSRightController;

	public GameObject m_modelOculusTouchRiftLeftController;

	public GameObject m_modelOculusTouchRiftRightController;

	public GameObject m_modelOculusTouchQuest2LeftController;

	public GameObject m_modelOculusTouchQuest2RightController;

	public OVRInput.Controller m_controller;

	private Animator m_animator;

	private GameObject m_activeController;

	private bool m_controllerModelsInitialized;

	private bool m_hasInputFocus = true;

	private bool m_hasInputFocusPrev;

	private ControllerType activeControllerType = ControllerType.Rift;

	private bool m_prevControllerConnected;

	private bool m_prevControllerConnectedCached;

	private void Start()
	{
		if (OVRManager.OVRManagerinitialized)
		{
			InitializeControllerModels();
		}
	}

	private void InitializeControllerModels()
	{
		if (!m_controllerModelsInitialized)
		{
			OVRPlugin.SystemHeadset systemHeadsetType = OVRPlugin.GetSystemHeadsetType();
			switch (systemHeadsetType)
			{
			case OVRPlugin.SystemHeadset.Rift_CV1:
				activeControllerType = ControllerType.Rift;
				break;
			case OVRPlugin.SystemHeadset.Oculus_Quest_2:
				activeControllerType = ControllerType.Quest2;
				break;
			case OVRPlugin.SystemHeadset.Oculus_Link_Quest_2:
				activeControllerType = ControllerType.Quest2;
				break;
			default:
				activeControllerType = ControllerType.QuestAndRiftS;
				break;
			}
			Debug.LogFormat("OVRControllerHelp: Active controller type: {0} for product {1} (headset {2})", activeControllerType, OVRPlugin.productName, systemHeadsetType);
			m_modelOculusTouchQuestAndRiftSLeftController.SetActive(value: false);
			m_modelOculusTouchQuestAndRiftSRightController.SetActive(value: false);
			m_modelOculusTouchRiftLeftController.SetActive(value: false);
			m_modelOculusTouchRiftRightController.SetActive(value: false);
			m_modelOculusTouchQuest2LeftController.SetActive(value: false);
			m_modelOculusTouchQuest2RightController.SetActive(value: false);
			OVRManager.InputFocusAcquired += InputFocusAquired;
			OVRManager.InputFocusLost += InputFocusLost;
			m_controllerModelsInitialized = true;
		}
	}

	private void OnDestroy()
	{
		if (OVRManager.OVRManagerinitialized && m_controllerModelsInitialized)
		{
			OVRManager.InputFocusAcquired -= InputFocusAquired;
			OVRManager.InputFocusLost -= InputFocusLost;
		}
	}

	private void Update()
	{
		if (!m_controllerModelsInitialized)
		{
			if (!OVRManager.OVRManagerinitialized)
			{
				return;
			}
			InitializeControllerModels();
		}
		bool flag = OVRInput.IsControllerConnected(m_controller);
		if (flag != m_prevControllerConnected || !m_prevControllerConnectedCached || m_hasInputFocus != m_hasInputFocusPrev)
		{
			if (activeControllerType == ControllerType.Rift)
			{
				m_modelOculusTouchQuestAndRiftSLeftController.SetActive(value: false);
				m_modelOculusTouchQuestAndRiftSRightController.SetActive(value: false);
				m_modelOculusTouchRiftLeftController.SetActive(flag && m_controller == OVRInput.Controller.LTouch);
				m_modelOculusTouchRiftRightController.SetActive(flag && m_controller == OVRInput.Controller.RTouch);
				m_modelOculusTouchQuest2LeftController.SetActive(value: false);
				m_modelOculusTouchQuest2RightController.SetActive(value: false);
				m_animator = ((m_controller == OVRInput.Controller.LTouch) ? m_modelOculusTouchRiftLeftController.GetComponent<Animator>() : m_modelOculusTouchRiftRightController.GetComponent<Animator>());
				m_activeController = ((m_controller == OVRInput.Controller.LTouch) ? m_modelOculusTouchRiftLeftController : m_modelOculusTouchRiftRightController);
			}
			else if (activeControllerType == ControllerType.Quest2)
			{
				m_modelOculusTouchQuestAndRiftSLeftController.SetActive(value: false);
				m_modelOculusTouchQuestAndRiftSRightController.SetActive(value: false);
				m_modelOculusTouchRiftLeftController.SetActive(value: false);
				m_modelOculusTouchRiftRightController.SetActive(value: false);
				m_modelOculusTouchQuest2LeftController.SetActive(flag && m_controller == OVRInput.Controller.LTouch);
				m_modelOculusTouchQuest2RightController.SetActive(flag && m_controller == OVRInput.Controller.RTouch);
				m_animator = ((m_controller == OVRInput.Controller.LTouch) ? m_modelOculusTouchQuest2LeftController.GetComponent<Animator>() : m_modelOculusTouchQuest2RightController.GetComponent<Animator>());
				m_activeController = ((m_controller == OVRInput.Controller.LTouch) ? m_modelOculusTouchQuest2LeftController : m_modelOculusTouchQuest2RightController);
			}
			else
			{
				m_modelOculusTouchQuestAndRiftSLeftController.SetActive(flag && m_controller == OVRInput.Controller.LTouch);
				m_modelOculusTouchQuestAndRiftSRightController.SetActive(flag && m_controller == OVRInput.Controller.RTouch);
				m_modelOculusTouchRiftLeftController.SetActive(value: false);
				m_modelOculusTouchRiftRightController.SetActive(value: false);
				m_modelOculusTouchQuest2LeftController.SetActive(value: false);
				m_modelOculusTouchQuest2RightController.SetActive(value: false);
				m_animator = ((m_controller == OVRInput.Controller.LTouch) ? m_modelOculusTouchQuestAndRiftSLeftController.GetComponent<Animator>() : m_modelOculusTouchQuestAndRiftSRightController.GetComponent<Animator>());
				m_activeController = ((m_controller == OVRInput.Controller.LTouch) ? m_modelOculusTouchQuestAndRiftSLeftController : m_modelOculusTouchQuestAndRiftSRightController);
			}
			m_activeController.SetActive(m_hasInputFocus && flag);
			m_prevControllerConnected = flag;
			m_prevControllerConnectedCached = true;
			m_hasInputFocusPrev = m_hasInputFocus;
		}
		if (m_animator != null)
		{
			m_animator.SetFloat("Button 1", OVRInput.Get(OVRInput.Button.One, m_controller) ? 1f : 0f);
			m_animator.SetFloat("Button 2", OVRInput.Get(OVRInput.Button.Two, m_controller) ? 1f : 0f);
			m_animator.SetFloat("Button 3", OVRInput.Get(OVRInput.Button.Start, m_controller) ? 1f : 0f);
			m_animator.SetFloat("Joy X", OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick, m_controller).x);
			m_animator.SetFloat("Joy Y", OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick, m_controller).y);
			m_animator.SetFloat("Trigger", OVRInput.Get(OVRInput.Axis1D.PrimaryIndexTrigger, m_controller));
			m_animator.SetFloat("Grip", OVRInput.Get(OVRInput.Axis1D.PrimaryHandTrigger, m_controller));
		}
	}

	public void InputFocusAquired()
	{
		m_hasInputFocus = true;
	}

	public void InputFocusLost()
	{
		m_hasInputFocus = false;
	}
}
