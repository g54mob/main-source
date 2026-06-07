using System.Collections;
using UnityEngine;

[RequireComponent(typeof(ParticleSystem))]
public class ParticlesLifeControl : MonoBehaviour
{
	private ParticleSystem mainParticleSystem;

	private WaitForSeconds stepWait = new WaitForSeconds(0.5f);

	public bool IsExisting { get; private set; }

	public bool ShouldDestroy { get; set; }

	public bool ShouldStopControl { get; set; }

	public bool ShouldUpdatePosition { get; set; }

	private void Awake()
	{
		mainParticleSystem = GetComponent<ParticleSystem>();
		ShouldDestroy = true;
		ShouldStopControl = false;
		ShouldUpdatePosition = false;
		StartCoroutine(CheckToDestroy());
	}

	public void Recycle()
	{
		ShouldStopControl = false;
		ShouldUpdatePosition = false;
	}

	public void SetExistence(bool isExisting)
	{
		base.enabled = isExisting;
		if (isExisting)
		{
			mainParticleSystem.Play(withChildren: true);
		}
		else
		{
			mainParticleSystem.Stop(withChildren: true, ParticleSystemStopBehavior.StopEmittingAndClear);
		}
		IsExisting = isExisting;
	}

	private IEnumerator CheckToDestroy()
	{
		while (true)
		{
			yield return stepWait;
			if (!ShouldStopControl && (IsExisting || ShouldDestroy) && !mainParticleSystem.IsAlive(withChildren: true))
			{
				if (ShouldDestroy)
				{
					Object.Destroy(base.gameObject);
				}
				else
				{
					SetExistence(isExisting: false);
				}
			}
		}
	}
}
