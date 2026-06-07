using UnityEngine;

[RequireComponent(typeof(DynamicSpring))]
public class DynamicSpringVisualEffect : VisualEffectBase
{
	[SerializeField]
	private GameObject jointBreakParticlesPrefab;

	private DynamicSpring dynamicSpring;

	protected override void Initialize()
	{
		dynamicSpring = base.gameObject.GetComponent<DynamicSpring>();
		dynamicSpring.OnReleasedEvent += OnReleasedHandler;
	}

	private void OnReleasedHandler()
	{
		GameObject particlesInstance = VisualEffectsManager.Instance.GetParticlesInstance(jointBreakParticlesPrefab);
		particlesInstance.transform.position = dynamicSpring.transform.position;
		particlesInstance.transform.rotation = dynamicSpring.transform.rotation;
	}

	public override void SetVisualEffectsByGameStyleData(GameStylesData gameStylesData)
	{
		base.SetVisualEffectsByGameStyleData(gameStylesData);
		if (jointBreakParticlesPrefab == null)
		{
			jointBreakParticlesPrefab = gameStylesData.visualEffectStylesData.bbJointBreakParticlesPrefab;
		}
	}
}
