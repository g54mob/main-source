using UnityEngine;
using UnityEngine.InputSystem;

public class MouseClick : SoundEffectPlayer
{
	[SerializeField]
	private AudioClip click;

	[SerializeField]
	private AudioClip release;

	protected override void Start()
	{
		base.Start();
		InputAction inputAction = GetComponent<PlayerInput>().actions["Click"];
		inputAction.started += PlayClick;
		inputAction.canceled += PlayRelease;
	}

	private void PlayRelease(InputAction.CallbackContext context)
	{
		audioPlayer.PlayOneShot(release);
	}

	private void PlayClick(InputAction.CallbackContext context)
	{
		audioPlayer.PlayOneShot(click);
	}

	public void RemoveAllListeners()
	{
		InputAction inputAction = GetComponent<PlayerInput>().actions["Click"];
		inputAction.canceled -= PlayRelease;
		inputAction.started -= PlayClick;
	}
}
