using UnityEngine;

[RequireComponent(typeof(LevelCollectable))]
public class LevelCollectableVisualEffect : VisualEffectBase
{
	[SerializeField]
	private GameObject goldStarParticlesPrefab;

	[SerializeField]
	private GameObject silverStarParticlesPrefab;

	protected override void Initialize()
	{
		GetComponent<LevelCollectable>().OnCollectedEvent += OnCollectedHandler;
	}

	private void OnCollectedHandler(LevelCollectable.CollectableType type)
	{
		GameObject particlesPrefab = ((type == LevelCollectable.CollectableType.Gold) ? goldStarParticlesPrefab : silverStarParticlesPrefab);
		GameObject particlesInstance = VisualEffectsManager.Instance.GetParticlesInstance(particlesPrefab);
		particlesInstance.transform.position = base.transform.position;
		particlesInstance.transform.rotation = base.transform.rotation;
	}

	public override void SetVisualEffectsByGameStyleData(GameStylesData gameStylesData)
	{
		base.SetVisualEffectsByGameStyleData(gameStylesData);
		if (goldStarParticlesPrefab == null)
		{
			goldStarParticlesPrefab = gameStylesData.visualEffectStylesData.goldStarParticlesPrefab;
		}
		if (silverStarParticlesPrefab == null)
		{
			silverStarParticlesPrefab = gameStylesData.visualEffectStylesData.silverStarParticlesPrefab;
		}
	}
}
