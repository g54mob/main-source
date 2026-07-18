using UnityEngine;

public class SnowController : MonoBehaviour
{
	public static SnowController Instance;

	[SerializeField]
	private ParticleSystem pSystem;

	[SerializeField]
	private ParticleSystem fog_pSystem;

	[SerializeField]
	private Light worldLight;

	[SerializeField]
	private GameObject worldShadow;

	[SerializeField]
	private SoundManager soundManager;

	[SerializeField]
	private AudioClip windSfx;

	private void Awake()
	{
		Instance = this;
	}

	public void StartSnow()
	{
		worldLight.intensity = 0.9f;
		worldShadow.SetActive(value: true);
		pSystem.Play();
		soundManager.PlaySound(windSfx, randomPitch: false);
	}

	private void Update()
	{
		ParticleSystem.ShapeModule shape = pSystem.shape;
		shape.radius = 15 * GridController.Instance.GetWorldSize() * 3;
		ParticleSystem.ShapeModule shape2 = fog_pSystem.shape;
		shape2.radius = shape.radius;
	}
}
