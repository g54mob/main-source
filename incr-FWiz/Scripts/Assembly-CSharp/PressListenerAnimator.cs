using OUSystems.Basics.UI;
using UnityEngine;

public abstract class PressListenerAnimator : MonoBehaviour
{
	public enum InputState
	{
		Default = 0,
		Hover = 1,
		Pressed = 2
	}

	[SerializeField]
	private PressListener _pressHandler;

	public InputState State { get; private set; }

	public InputState LastState { get; private set; }

	public virtual void OnEnable()
	{
	}

	public virtual void OnDisable()
	{
	}

	public abstract void AfterStateUpdate();

	private void UpdateState(InputState newState)
	{
	}

	public void OnHover()
	{
	}

	public void OnHoverEnd()
	{
	}

	public void OnPress()
	{
	}

	public void OnPressEnd()
	{
	}
}
