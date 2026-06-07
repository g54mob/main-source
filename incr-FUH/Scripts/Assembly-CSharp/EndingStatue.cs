using UnityEngine;

public class EndingStatue : MonoBehaviour
{
	public ParticleSystem RockPS;

	public void PlayRockPS()
	{
		RockPS.Play();
	}
}
