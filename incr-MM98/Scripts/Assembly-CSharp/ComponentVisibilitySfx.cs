using UnityEngine;

public class ComponentVisibilitySfx : MonoBehaviour
{
	[SerializeField]
	private bool playOnEnable;

	[SerializeField]
	private AudioDataType onEnableSfx;

	[SerializeField]
	private bool playOnDisable;

	[SerializeField]
	private AudioDataType onDisableSfx;

	private void OnEnable()
	{
		if (playOnEnable)
		{
			Audio.PlaySfx(onEnableSfx);
		}
	}

	private void OnDisable()
	{
		if (playOnDisable)
		{
			Audio.PlaySfx(onDisableSfx);
		}
	}
}
