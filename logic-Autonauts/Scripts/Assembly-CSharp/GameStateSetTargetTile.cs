using UnityEngine;

public class GameStateSetTargetTile : GameStateBase
{
	public static GameStateSetTargetTile Instance;

	private ObjectSelectBar m_Title;

	private Catapult m_Catapult;

	private TileCoord m_OldTargetTile;

	private TileCoord m_LastTilePosition;

	private Arc m_Arc;

	protected new void Awake()
	{
		base.Awake();
		Instance = this;
		Transform menusRootTransform = HudManager.Instance.m_MenusRootTransform;
		GameObject original = (GameObject)Resources.Load("Prefabs/Hud/SetTargetTile", typeof(GameObject));
		m_Title = Object.Instantiate(original, menusRootTransform).GetComponent<ObjectSelectBar>();
		BaseButton component = m_Title.transform.Find("StandardCancelButton").GetComponent<BaseButton>();
		component.SetAction(OnBackClicked, component);
		m_Arc = ObjectTypeList.Instance.CreateObjectFromIdentifier(ObjectType.Arc, default(Vector3), base.transform.localRotation).GetComponent<Arc>();
		HudManager.Instance.RolloversEnabled(false);
		HudManager.Instance.SetHudButtonsActive(false);
		Cursor.Instance.SetMaterial("AreaIndicatorTargetTile");
		Cursor.Instance.EnableOutline(false);
	}

	protected new void OnDestroy()
	{
		HudManager.Instance.SetHudButtonsActive(true);
		HudManager.Instance.RolloversEnabled(true);
		m_Arc.StopUsing();
		Cursor.Instance.SetMaterial("AreaIndicatorIdle");
		Cursor.Instance.EnableOutline(true);
		base.OnDestroy();
		Object.Destroy(m_Title.gameObject);
	}

	public void OnBackClicked(BaseGadget NewGadget)
	{
		Close(true);
	}

	public void SetInfo(Farmer NewFarmer, Catapult NewCatapult)
	{
		m_Catapult = NewCatapult;
		m_OldTargetTile = m_Catapult.GetTargetTile();
		m_Arc.transform.position = m_Catapult.m_TileCoord.ToWorldPositionTileCentered();
		UpdateArc();
	}

	public void Close(bool Restore)
	{
		GameStateManager.Instance.PopState();
		m_Catapult.m_Engager.SendAction(new ActionInfo(ActionType.DisengageObject, m_Catapult.m_Engager.GetComponent<TileCoordObject>().m_TileCoord, m_Catapult));
		if (Restore)
		{
			m_Catapult.SetTargetTile(m_OldTargetTile);
		}
	}

	private void UpdateArc()
	{
		float Height;
		float Delay;
		m_Catapult.GetArc(out Height, out Delay);
		m_Arc.SetTarget(m_Catapult.GetTargetTile().ToWorldPositionTileCentered(), Height);
	}

	public override void UpdateState()
	{
		bool flag = false;
		Cursor.Instance.SetModel(ObjectTypeList.m_Total);
		Worker targetObject = null;
		TileCoord tileCoord = default(TileCoord);
		Vector3 CollisionPoint;
		GameObject gameObject = TestMouseCollision(out CollisionPoint, true, false, false, false, false);
		if ((bool)gameObject && (bool)gameObject.GetComponent<PlotRoot>())
		{
			tileCoord = new TileCoord(CollisionPoint);
			if (PlotManager.Instance.GetPlotAtTile(tileCoord).m_Visible && m_Catapult.GetIsTileAcceptable(tileCoord))
			{
				flag = true;
				if (tileCoord != m_LastTilePosition)
				{
					m_LastTilePosition = tileCoord;
					Cursor.Instance.TargetTile(tileCoord);
					m_Catapult.SetTargetTile(tileCoord);
					UpdateArc();
				}
			}
		}
		m_Arc.gameObject.SetActive(flag);
		HighlightObject(targetObject);
		CollectionManager.Instance.GetPlayers();
		if (!flag)
		{
			Cursor.Instance.NoTarget();
		}
		else if (TestMouseButtonDown(0))
		{
			AudioManager.Instance.StartEvent("CatapultTargetSelected");
			Close(false);
		}
		if (MyInputManager.m_Rewired.GetButtonDown("Quit"))
		{
			AudioManager.Instance.StartEvent("UICloseWindow");
			Close(true);
		}
		CheckPlanningToggle();
		CameraManager.Instance.UpdateInput();
	}
}
