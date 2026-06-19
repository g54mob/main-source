using FMODUnity;
using OUSystems.Basics.UI;
using UnityEngine;

public class HoldListenerSFX : MonoBehaviour
{
	[SerializeField]
	private HoldListener _uiHoldListener;

	public EventReference HoverSound;

	public EventReference HoverEndSound;

	public EventReference PressSound;

	public EventReference PressEndSound;

	public EventReference CompleteSound;

	public virtual void Start()
	{
	}

	public virtual void OnDestroy()
	{
	}

	public void PlayHoverSound()
	{
	}

	public void PlayHoverEndSound()
	{
	}

	public void PlayPressSound()
	{
	}

	public void PlayPressEndSound()
	{
	}

	public void PlayCompleteSound()
	{
	}
}
