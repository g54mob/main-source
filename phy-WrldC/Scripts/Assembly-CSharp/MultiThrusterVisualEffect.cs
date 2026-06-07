using UnityEngine;

[RequireComponent(typeof(MultiThruster))]
public class MultiThrusterVisualEffect : VisualEffectBase
{
	[SerializeField]
	private GameObject multiThrusterParticlesPrefab;

	private MultiThruster multiThruster;

	public ThrusterParticleControl ParticleControlPX { get; private set; }

	public ThrusterParticleControl ParticleControlNX { get; private set; }

	public ThrusterParticleControl ParticleControlPY { get; private set; }

	public ThrusterParticleControl ParticleControlNY { get; private set; }

	public float MinValueToStart { get; private set; }

	protected override void Initialize()
	{
		multiThruster = base.gameObject.GetComponent<MultiThruster>();
		base.gameObject.AddComponent<MultiThrusterVEReplay>();
		MinValueToStart = 0.01f;
	}

	protected override void Update()
	{
		base.Update();
		CheckAndActiveParticles(multiThruster.CurrentThrustVector.x, ParticleControlPX, ParticleControlNX);
		CheckAndActiveParticles(multiThruster.CurrentThrustVector.y, ParticleControlPY, ParticleControlNY);
	}

	public override void SetVisualEffectsByGameStyleData(GameStylesData gameStylesData)
	{
		base.SetVisualEffectsByGameStyleData(gameStylesData);
		if (multiThrusterParticlesPrefab == null)
		{
			multiThrusterParticlesPrefab = gameStylesData.visualEffectStylesData.multiThrusterParticlesPrefab;
		}
		GameObject gameObject = Object.Instantiate(multiThrusterParticlesPrefab, base.transform);
		ParticleControlPX = gameObject.transform.FindComponent<ThrusterParticleControl>("SinglePX");
		ParticleControlNX = gameObject.transform.FindComponent<ThrusterParticleControl>("SingleNX");
		ParticleControlPY = gameObject.transform.FindComponent<ThrusterParticleControl>("SinglePY");
		ParticleControlNY = gameObject.transform.FindComponent<ThrusterParticleControl>("SingleNY");
	}

	public void CheckAndActiveParticles(float axisValue, ThrusterParticleControl particleControlPos, ThrusterParticleControl particleControlNeg)
	{
		float num = axisValue / multiThruster.MaxThrust;
		if (num > MinValueToStart)
		{
			if (!particleControlPos.MainParticleSystem.isPlaying)
			{
				particleControlPos.MainParticleSystem.Play(withChildren: true);
			}
			if (particleControlNeg.MainParticleSystem.isPlaying)
			{
				particleControlNeg.MainParticleSystem.Stop(withChildren: true);
			}
			particleControlPos.SetStrength(num);
		}
		else if (num < 0f - MinValueToStart)
		{
			if (particleControlPos.MainParticleSystem.isPlaying)
			{
				particleControlPos.MainParticleSystem.Stop(withChildren: true);
			}
			if (!particleControlNeg.MainParticleSystem.isPlaying)
			{
				particleControlNeg.MainParticleSystem.Play(withChildren: true);
			}
			particleControlNeg.SetStrength(Mathf.Abs(num));
		}
		else
		{
			if (particleControlPos.MainParticleSystem.isPlaying)
			{
				particleControlPos.MainParticleSystem.Stop(withChildren: true);
			}
			if (particleControlNeg.MainParticleSystem.isPlaying)
			{
				particleControlNeg.MainParticleSystem.Stop(withChildren: true);
			}
		}
	}
}
