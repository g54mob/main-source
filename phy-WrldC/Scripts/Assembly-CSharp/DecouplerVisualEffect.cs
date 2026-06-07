using UnityEngine;

[RequireComponent(typeof(Decoupler))]
public class DecouplerVisualEffect : VisualEffectBase
{
	[SerializeField]
	private GameObject jointBreakParticlesPrefab;

	private Decoupler decoupler;

	protected override void Initialize()
	{
		decoupler = base.gameObject.GetComponent<Decoupler>();
		decoupler.OnJointBreakEvent += JointBreakHandler;
	}

	private void JointBreakHandler()
	{
		GameObject particlesInstance = VisualEffectsManager.Instance.GetParticlesInstance(jointBreakParticlesPrefab);
		particlesInstance.transform.position = decoupler.transform.position;
		particlesInstance.transform.rotation = decoupler.transform.rotation;
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
