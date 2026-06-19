using DG.Tweening;
using OUSystems.Basics.DataStructures;
using OUSystems.Basics.UI;
using UnityEngine;
using UnityEngine.UI;

public class GameHUDActionModeTab : ClickListener
{
	[SerializeField]
	private PlayerActionMode _actionMode;

	private Vector2 _basePosition;

	[SerializeField]
	private Image _buttonImage;

	public Sprite DefaultSprite;

	public Sprite ActiveSprite;

	public ButtonGuideHoverTrigger ButtonGuideTrigger;

	private Tween _tween;

	private void Start()
	{
	}

	private void OnDestroy()
	{
	}

	public void OnUpdateModeEnabled(ValueUpdateData<bool> _)
	{
	}

	public void OnModeActive()
	{
	}

	public void OnModeInactive()
	{
	}

	private void EvaluateState(bool animation = true)
	{
	}

	public override void OnHover()
	{
	}

	public override void OnHoverEnd()
	{
	}

	public override void Click()
	{
	}
}
