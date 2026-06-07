using UnityEngine;

public class GameStateFreeCam : GameStateBase
{
	public static GameStateFreeCam Instance;

	private bool m_Quit;

	private FreeCamSettings m_Settings;

	private CameraSequence m_Sequence;

	private bool m_Locked;

	protected new void Awake()
	{
		Instance = this;
		base.Awake();
		m_Quit = false;
		HudManager.Instance.RolloversEnabled(false);
		HudManager.Instance.SetVisible(false);
		Cursor.Instance.NoTarget(true);
		GameObject original = (GameObject)Resources.Load("Prefabs/Hud/Settings/FreeCamSettings", typeof(GameObject));
		m_Settings = Object.Instantiate(original, HudManager.Instance.m_ScaledHUDRootTransform).GetComponent<FreeCamSettings>();
		m_Sequence = HudManager.Instance.m_Sequence;
		if ((bool)m_Sequence)
		{
			m_Sequence.transform.SetParent(null);
			m_Sequence.transform.SetParent(HudManager.Instance.m_ScaledHUDRootTransform);
			m_Sequence.GetComponent<RectTransform>().anchoredPosition = new Vector2(10f, 10f);
			if (m_Sequence.m_Waypoints.Count > 0)
			{
				m_Sequence.SetActive(true);
			}
		}
		SetLocked(true);
		SettingsManager.Instance.UpdateDOF();
	}

	protected new void OnDestroy()
	{
		CameraManager.Instance.SetDOFEnabled(false);
		SetLocked(false);
		base.OnDestroy();
		Object.Destroy(m_Settings.gameObject);
		if ((bool)m_Sequence)
		{
			m_Sequence.SetActive(false);
		}
		HudManager.Instance.RolloversEnabled(true);
		HudManager.Instance.SetVisible(true);
	}

	public override void Pushed(GameStateManager.State NewState)
	{
		base.Pushed(NewState);
		m_Settings.gameObject.SetActive(false);
		if ((bool)m_Sequence)
		{
			m_Sequence.gameObject.SetActive(false);
		}
	}

	public override void Popped(GameStateManager.State NewState)
	{
		base.Popped(NewState);
		m_Settings.gameObject.SetActive(true);
		if ((bool)m_Sequence)
		{
			m_Sequence.gameObject.SetActive(true);
		}
	}

	public void SetLocked(bool Locked)
	{
		if (Locked)
		{
			CameraManager.Instance.SetState(CameraManager.State.Free);
			UnityEngine.Cursor.lockState = CursorLockMode.Locked;
			UnityEngine.Cursor.visible = false;
		}
		else
		{
			UnityEngine.Cursor.lockState = CursorLockMode.None;
			UnityEngine.Cursor.visible = true;
		}
		m_Settings.SetLocked(Locked);
		m_Locked = Locked;
	}

	public override void UpdateState()
	{
		if (m_Quit)
		{
			GameStateManager.Instance.PopState(true);
		}
		if (m_Locked)
		{
			CameraManager.Instance.UpdateInput();
			if (Input.GetMouseButtonDown(0))
			{
				SetLocked(false);
			}
		}
		if (CheatManager.Instance.m_CheatsEnabled && MyInputManager.m_Rewired.GetButtonDown("AddWaypoint") && (bool)m_Sequence)
		{
			m_Sequence.AddWaypoint();
			m_Sequence.SetActive(true);
		}
		if (MyInputManager.m_Rewired.GetButtonDown("ToggleFreeCam") || MyInputManager.m_Rewired.GetButtonDown("Quit"))
		{
			if (MyInputManager.m_Rewired.GetButtonDown("ToggleFreeCam"))
			{
				AudioManager.Instance.StartEvent("UIOptionSelected");
			}
			m_Quit = true;
			CameraManager.Instance.SetState(CameraManager.State.Normal);
		}
		CheckPlanningToggle();
	}
}
