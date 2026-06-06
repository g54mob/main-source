using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.UI;

public class ActionTrigger : Selectable
{
	[Header("Action Trigger")]
	[SerializeField]
	private ActionBase _action;

	[SerializeField]
	private Image _actionIconImage;

	[SerializeField]
	private Animator _animator;

	[Header("GameSpeedAction")]
	[SerializeField]
	[Tooltip("The animator parameter to indicate the action game speed to set is zero and the current GameSpeed is GameSpeed.Zero.")]
	private string _zeroParameter = "Zero";

	[SerializeField]
	[Tooltip("The animator parameter to indicate the action game speed to set is zeroed. The zeroed GameSpeed is the Gamespeed when GameSpeed.Zero is toggled on.")]
	private string _zeroedParameter = "Zeroed";

	public ActionBase Action { get; private set; }

	public UnityEvent<ActionTrigger> OnSelected { get; private set; } = new UnityEvent<ActionTrigger>();

	protected override void Awake()
	{
		base.Awake();
		if (Action == null)
		{
			Initialize(_action);
		}
	}

	protected override void OnEnable()
	{
		base.OnEnable();
		if ((bool)_actionIconImage)
		{
			_actionIconImage.overrideSprite = Action.GetIcon();
		}
		if (_action is GameSpeedAction gameSpeedAction)
		{
			if (gameSpeedAction.GameSpeed == GameSpeed.Zero)
			{
				_animator.SetBool(_zeroParameter, GameSpeedManager.GameSpeed == GameSpeed.Zero);
			}
			else
			{
				_animator.SetBool(_zeroedParameter, GameSpeedManager.ZeroedGameSpeed == gameSpeedAction.GameSpeed);
			}
		}
	}

	public void Initialize(ActionBase action)
	{
		Action = action;
		if ((bool)_actionIconImage)
		{
			_actionIconImage.overrideSprite = Action.GetIcon();
		}
		base.gameObject.SetActive(value: true);
	}

	public void Trigger()
	{
		if (Action.IsInteractable)
		{
			Action?.Trigger();
		}
	}

	public override void OnSelect(BaseEventData eventData)
	{
		base.OnSelect(eventData);
		OnSelected.Invoke(this);
	}
}
