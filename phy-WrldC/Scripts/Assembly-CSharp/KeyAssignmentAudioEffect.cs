using UnityEngine;

[RequireComponent(typeof(KeyAssignment))]
public class KeyAssignmentAudioEffect : ToggleAudioEffect
{
	[SerializeField]
	private AudioClip keyChangedClip;

	private KeyAssignment keyAssignment;

	public AudioClip KeyChangedClip
	{
		set
		{
			keyChangedClip = value;
		}
	}

	protected override void Awake()
	{
		base.Awake();
		keyAssignment = GetComponent<KeyAssignment>();
		keyAssignment.OnKeyAssignment += KeyAssignmentHandler;
	}

	private void KeyAssignmentHandler(KeyCode key, AxisCode axis)
	{
		if (keyChangedClip != null)
		{
			PlayAudio(keyChangedClip);
		}
	}
}
