using UnityEngine;

[RequireComponent(typeof(Cannon))]
public class CannonVisualEffect : VisualEffectBase
{
	[SerializeField]
	private GameObject cannonFireParticlesPrefab;

	private Cannon cannon;

	protected override void Initialize()
	{
		cannon = base.gameObject.GetComponent<Cannon>();
		cannon.OnFireEvent += OnFireHandler;
	}

	private void OnFireHandler(Vector3 firePosition, Vector3 fireDirection)
	{
		Quaternion rotation = Quaternion.FromToRotation(Vector3.up, fireDirection);
		GameObject particlesInstance = VisualEffectsManager.Instance.GetParticlesInstance(cannonFireParticlesPrefab);
		particlesInstance.transform.position = firePosition;
		particlesInstance.transform.rotation = rotation;
		particlesInstance.GetComponent<ParticlesLifeControl>().ShouldUpdatePosition = true;
		particlesInstance.GetComponent<FollowObject>().ObjectToFollow = base.gameObject;
	}

	public override void SetVisualEffectsByGameStyleData(GameStylesData gameStylesData)
	{
		base.SetVisualEffectsByGameStyleData(gameStylesData);
		if (cannonFireParticlesPrefab == null)
		{
			cannonFireParticlesPrefab = gameStylesData.visualEffectStylesData.cannonFireParticlesPrefab;
		}
	}
}
