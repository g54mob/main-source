using UnityEngine;

public class SoundTrigger : MonoBehaviour
{
	public void OnSoundTrigger(string name)
	{
		SoundManager.PlaySoundOnce(name);
		Debug.Log("Animation SoundTrigger: " + name);
	}
}
