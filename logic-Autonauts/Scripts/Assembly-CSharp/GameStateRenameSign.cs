using UnityEngine;

public class GameStateRenameSign : GameStateBase
{
	[HideInInspector]
	public RenameSign m_Menu;

	private AreaIndicator m_Indicator;

	private Sign m_Sign;

	protected new void Awake()
	{
		base.Awake();
		Transform menusRootTransform = HudManager.Instance.m_MenusRootTransform;
		GameObject original = (GameObject)Resources.Load("Prefabs/Hud/RenameSign", typeof(GameObject));
		m_Menu = Object.Instantiate(original, new Vector3(0f, 0f, 0f), Quaternion.identity, menusRootTransform).GetComponent<RenameSign>();
		m_Menu.GetComponent<RectTransform>().anchoredPosition = default(Vector2);
		HudManager.Instance.RolloversEnabled(false);
		HudManager.Instance.SetHudButtonsActive(false);
	}

	protected new void OnDestroy()
	{
		base.OnDestroy();
		Object.Destroy(m_Menu.gameObject);
		HudManager.Instance.RolloversEnabled(true);
		HudManager.Instance.SetHudButtonsActive(true);
	}

	public override void Pushed(GameStateManager.State NewState)
	{
		base.Pushed(NewState);
		m_Menu.gameObject.SetActive(false);
	}

	public override void Popped(GameStateManager.State NewState)
	{
		base.Popped(NewState);
		m_Menu.gameObject.SetActive(true);
		m_Sign.m_Indicator.SetActive(true);
	}

	public void SetSign(Sign NewSign)
	{
		m_Sign = NewSign;
		m_Menu.GetComponent<RenameSign>().SetSign(NewSign);
		NewSign.ShowIndicator(true);
	}

	public override void UpdateState()
	{
		if (MyInputManager.m_Rewired.GetButtonDown("Quit"))
		{
			GameStateManager.Instance.PopState();
		}
	}
}
