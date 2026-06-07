using UnityEngine;

[RequireComponent(typeof(SolidRocket))]
public class SolidRocketVisualEffect : VisualEffectBase
{
	[SerializeField]
	private GameObject solidRocketParticlesPrefab;

	private SolidRocket solidRocket;

	public ThrusterParticleControl SolidRocketParticleControl { get; private set; }

	public float MinValueToStart { get; private set; }

	protected override void Initialize()
	{
		solidRocket = base.gameObject.GetComponent<SolidRocket>();
		base.gameObject.AddComponent<SolidRocketVEReplay>();
		MinValueToStart = 0.01f;
	}

	public override void SetVisualEffectsByGameStyleData(GameStylesData gameStylesData)
	{
		base.SetVisualEffectsByGameStyleData(gameStylesData);
		if (solidRocketParticlesPrefab == null)
		{
			solidRocketParticlesPrefab = gameStylesData.visualEffectStylesData.solidRocketParticlesPrefab;
		}
		GameObject gameObject = Object.Instantiate(solidRocketParticlesPrefab, base.transform);
		SolidRocketParticleControl = gameObject.GetComponent<ThrusterParticleControl>();
	}

	protected override void Update()
	{
		base.Update();
		CheckAndActiveParticles(solidRocket.CurrentThrust);
	}

	public void CheckAndActiveParticles(float thrust)
	{
		float num = thrust / solidRocket.MaxThrust;
		if (num > MinValueToStart && !SolidRocketParticleControl.MainParticleSystem.isPlaying)
		{
			SolidRocketParticleControl.MainParticleSystem.Play();
		}
		else if (num < MinValueToStart && SolidRocketParticleControl.MainParticleSystem.isPlaying)
		{
			SolidRocketParticleControl.MainParticleSystem.Stop(withChildren: true);
		}
		if (SolidRocketParticleControl.MainParticleSystem.isPlaying)
		{
			SolidRocketParticleControl.SetStrength(num);
		}
	}
}
