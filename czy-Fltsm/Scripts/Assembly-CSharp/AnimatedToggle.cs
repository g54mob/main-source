using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class AnimatedToggle : PLToggle
{
	[Header("Animated Toggle")]
	[Tooltip("The name of the bool parameter that is set on the Animator.")]
	[SerializeField]
	private string _isOnParameter = "IsOn";

	[SerializeField]
	[Tooltip("The name of the bool parameter that is set on the Animator.")]
	private string _interactableParameter = "Interactable";

	[SerializeField]
	[Tooltip("The name of the bool parameter that is set on the Animator.")]
	private string _completedParameter = "Completed";

	private bool _animatorIsOn;

	protected override void OnEnable()
	{
		base.OnEnable();
		SetAnimatorBool();
	}

	protected override void LateUpdate()
	{
		base.LateUpdate();
		if (_animatorIsOn != base.isOn)
		{
			SetAnimatorBool();
		}
		UpdateParameters();
	}

	public override void Initialize(IToggleable toggleable)
	{
		base.Initialize(toggleable);
		SetAnimatorBool();
		UpdateParameters();
	}

	public void SetCompleted()
	{
		if (!(base.animator == null) && !base.animator.GetBool(_completedParameter))
		{
			base.animator?.SetBool(_completedParameter, value: true);
		}
	}

	protected override void OnValueChanged(bool value)
	{
		base.OnValueChanged(value);
		SetAnimatorBool();
	}

	private void SetAnimatorBool()
	{
		_animatorIsOn = base.isOn;
		if (base.transition == Transition.Animation)
		{
			base.animator?.SetBool(_isOnParameter, base.isOn);
		}
	}

	private void UpdateParameters()
	{
		if (base.Toggleable != null)
		{
			if (base.Toggleable.IsCompleted)
			{
				SetCompleted();
			}
			base.animator?.SetBool(_interactableParameter, base.Toggleable.IsInteractable);
		}
	}

	public override void OnSelect(BaseEventData eventData)
	{
		if (FlotsamInputManager.IsJoystick)
		{
			base.OnSelect(eventData);
		}
	}

	public override void OnDeselect(BaseEventData eventData)
	{
		if (FlotsamInputManager.IsJoystick)
		{
			base.OnDeselect(eventData);
		}
	}
}
