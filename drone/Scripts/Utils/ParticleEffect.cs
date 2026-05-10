using UnityEngine;

[RequireComponent(typeof(ParticleSystem))]
public class ParticleEffect : MonoBehaviour, IVisualEffect
{
	private ParticleSystem particles;

	private void Awake()
	{
		particles = GetComponent<ParticleSystem>();
	}

	public bool IsPlaying()
	{
		return particles.isPlaying;
	}

	public void Play()
	{
		particles.Play();
	}

	public void SetColor(Color color)
	{
		ParticleSystem.MainModule main = particles.main;
		main.startColor = color;
	}

	public float SetText(string text)
	{
		return 0f;
	}
}
