using UnityEngine;

public class AssetPhotoStudioElement : MonoBehaviour
{
	[SerializeField]
	private ParticleSystem[] psToPlay;

	public void PlayParticles()
	{
		ParticleSystem[] array = psToPlay;
		foreach (ParticleSystem obj in array)
		{
			ParticleSystem.MainModule main = obj.main;
			main.prewarm = true;
			obj.Play();
		}
	}

	public void StopParticles()
	{
		ParticleSystem[] array = psToPlay;
		for (int i = 0; i < array.Length; i++)
		{
			array[i].Stop();
		}
	}
}
