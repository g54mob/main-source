using UnityEngine;

public class RadicalPauseMenuOption_ConnectBilibili : RadicalPauseMenuOption
{
	public ListIcon listIcon;

	protected override void Awake()
	{
		base.Awake();
	}

	public override OptionActiveState GetActiveStateInCurrentScene()
	{
		if (!CommandLineArgs.Has("-bilibili"))
		{
			SetActiveState(active: false);
			return OptionActiveState.INACTIVE;
		}
		SetActiveState(active: true);
		return base.GetActiveStateInCurrentScene();
	}

	public override void OnActivated()
	{
		base.OnActivated();
		Manager.menu.PushMenu(RadicalMenu.MenuType.BILIBILI_CONNECT);
	}

	private void SetActiveState(bool active)
	{
		GameObject gameObject = base.transform.parent.gameObject;
		if (gameObject.activeInHierarchy != active)
		{
			gameObject.SetActive(active);
			GetComponentInParent<LinearLayoutUIComponent>().MarkUIComponentAsDirty(render: true);
		}
	}
}
