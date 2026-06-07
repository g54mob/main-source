using PajamaLlama.Debugs;
using UnityEngine;

public class AudioUIPlayer : MonoBehaviour
{
	[Tooltip("Clip properties to play when triggered.")]
	[SerializeField]
	private AudioClipProperties _clipProperties;

	public void Play()
	{
		if (_clipProperties == null)
		{
			Debugger.Warning($"No audio clip properties set for {base.gameObject.name}.", base.gameObject);
		}
		else
		{
			AudioManager.Play(_clipProperties);
		}
	}
}
