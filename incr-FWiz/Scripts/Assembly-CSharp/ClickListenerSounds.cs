using FMODUnity;
using OUSystems.Basics.UI;
using UnityEngine;

public class ClickListenerSounds : MonoBehaviour
{
	[SerializeField]
	private ClickListener _clickListener;

	public EventReference HoverSound;

	public EventReference PressSound;

	public EventReference ClickSound;

	private void OnEnable()
	{
	}

	private void OnDisable()
	{
	}

	public void OnHover()
	{
	}

	public void OnClick()
	{
	}

	public void OnPress()
	{
	}
}
