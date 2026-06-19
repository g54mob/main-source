using UnityEngine;

public class CopyGameIDButton : RadicalMenuOption
{
	public bool CopyGameInfo;

	public SpriteRenderer selectedSR;

	public SpriteRenderer pressedSR;

	public SpriteRenderer unpressedSR;

	protected override void Awake()
	{
		selectedSR.gameObject.SetActive(value: false);
		base.Awake();
	}

	protected override void LateUpdate()
	{
		base.LateUpdate();
		unpressedSR.gameObject.SetActive(!base.leftClickIsHeldDown);
		pressedSR.gameObject.SetActive(base.leftClickIsHeldDown);
	}

	public override OptionActiveState GetActiveStateInCurrentScene()
	{
		if (!Manager.platform.hasNetwork)
		{
			return OptionActiveState.INACTIVE;
		}
		return base.GetActiveStateInCurrentScene();
	}

	public override void OnActivated()
	{
		string systemCopyBuffer = ((!Manager.networking.CurrentSession.IsValid()) ? "None" : (CopyGameInfo ? Manager.networking.CurrentSession.CopiedPackedInfo : Manager.networking.CurrentSession.GameID));
		GUIUtility.systemCopyBuffer = systemCopyBuffer;
		base.OnActivated();
	}

	public override void OnSelected()
	{
		pressedSR.color = PugTextEffectMenuOption.SELECTED_TEXT_COLOR;
		unpressedSR.color = PugTextEffectMenuOption.SELECTED_TEXT_COLOR;
		selectedSR.gameObject.SetActive(value: true);
		base.OnSelected();
	}

	public override void OnDeselected(bool playEffect = true)
	{
		pressedSR.color = PugTextEffectMenuOption.UNSELECTED_TEXT_COLOR;
		unpressedSR.color = PugTextEffectMenuOption.UNSELECTED_TEXT_COLOR;
		selectedSR.gameObject.SetActive(value: false);
		base.OnDeselected(playEffect);
	}
}
