using UnityEngine;

public class RadicalMenuOption_Toggle : RadicalMenuOption
{
	public bool isOn;

	public SpriteRenderer toggleOnSR;

	public SpriteRenderer toggleOffSR;

	public GameObject selectedMarker;

	[Tooltip("Will be disabled if related option is disabled")]
	public RadicalMenuOption relatedOption;

	protected override void Awake()
	{
		base.Awake();
		selectedMarker.SetActive(value: false);
	}

	private void OnEnable()
	{
		isOn = false;
	}

	protected override void LateUpdate()
	{
		toggleOnSR.gameObject.SetActive(isOn);
		toggleOffSR.gameObject.SetActive(!isOn);
		base.LateUpdate();
	}

	public override OptionActiveState GetActiveStateInCurrentScene()
	{
		if (relatedOption != null)
		{
			OptionActiveState activeStateInCurrentScene = relatedOption.GetActiveStateInCurrentScene();
			if (activeStateInCurrentScene == OptionActiveState.INACTIVE)
			{
				return activeStateInCurrentScene;
			}
		}
		return base.GetActiveStateInCurrentScene();
	}

	public override void OnSelected()
	{
		base.OnSelected();
		selectedMarker.SetActive(value: true);
		toggleOnSR.color = PugTextEffectMenuOption.SELECTED_TEXT_COLOR;
		toggleOffSR.color = PugTextEffectMenuOption.SELECTED_TEXT_COLOR;
	}

	public override void OnDeselected(bool playEffect = true)
	{
		base.OnDeselected(playEffect);
		selectedMarker.SetActive(value: false);
		toggleOnSR.color = PugTextEffectMenuOption.UNSELECTED_TEXT_COLOR;
		toggleOffSR.color = PugTextEffectMenuOption.UNSELECTED_TEXT_COLOR;
	}

	public override void OnActivated()
	{
		base.OnActivated();
		isOn = !isOn;
	}

	public override bool IsOn()
	{
		return isOn;
	}
}
