using System.Collections;
using UnityEngine;

public class Sprinkler : EntityMonoBehaviour
{
	public ParticleSystem ps;

	private readonly WaitForSeconds _rotationInterval = new WaitForSeconds(0.3f);

	private int _lastParticleSetting = -1;

	private Coroutine _rotateCoroutine;

	private Transform _psTransform;

	protected override void Awake()
	{
		_psTransform = ps.transform;
		base.Awake();
	}

	public override void OnOccupied()
	{
		base.OnOccupied();
		if (_lastParticleSetting != Manager.prefs.particleQuality)
		{
			if (Manager.prefs.particleQuality == 0)
			{
				ParticleSystem.EmissionModule emission = ps.emission;
				emission.rateOverTime = 10f;
				ParticleSystem.CollisionModule collision = ps.collision;
				collision.enabled = false;
			}
			else
			{
				ParticleSystem.EmissionModule emission2 = ps.emission;
				emission2.rateOverTime = 20f;
				ParticleSystem.CollisionModule collision2 = ps.collision;
				collision2.enabled = true;
			}
			_lastParticleSetting = Manager.prefs.particleQuality;
		}
	}

	private IEnumerator RotateSprinkler()
	{
		while (true)
		{
			yield return _rotationInterval;
			_psTransform.Rotate(0f, _psTransform.rotation.y + 10f, 0f, Space.Self);
		}
	}

	protected override void OnShow()
	{
		ps.Play(withChildren: true);
		float yAngle = Random.Range(0f, 90f);
		_psTransform.Rotate(0f, yAngle, 0f, Space.Self);
		_rotateCoroutine = StartCoroutine(RotateSprinkler());
		base.OnShow();
	}

	protected override void OnHide()
	{
		StopCoroutine(_rotateCoroutine);
		ps.Stop(withChildren: true);
		base.OnHide();
	}
}
