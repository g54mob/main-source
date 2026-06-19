using Pug.UnityExtensions;
using UnityEngine;

public class CicadaBossBuzzMortarProjectile : EntityMonoBehaviour
{
	public NukeAttackFX nukeAttackFX;

	private TimerSimple screamDelayTimer;

	private TimerSimple thumpDelayTimer;

	private float screamDelay = 1.5f;

	private float thumpDelay = 2.5f;

	public GameObject effectContainer;

	protected override bool hideDirectlyOnDeath => false;

	public override void OnOccupied()
	{
		base.OnOccupied();
		if (currentHealth > 0)
		{
			effectContainer.SetActive(value: true);
			nukeAttackFX.Play();
			screamDelayTimer.Start(screamDelay);
			thumpDelayTimer.Start(thumpDelay);
		}
		else
		{
			effectContainer.SetActive(value: false);
		}
	}

	public override void ManagedLateUpdate()
	{
		base.ManagedLateUpdate();
		if (currentHealth <= 0)
		{
			if (!screamDelayTimer.isTimerElapsed)
			{
				screamDelayTimer.Stop();
			}
			if (!thumpDelayTimer.isTimerElapsed)
			{
				effectContainer.SetActive(value: false);
				thumpDelayTimer.Stop();
			}
		}
		if (screamDelayTimer.isRunning && screamDelayTimer.isTimerElapsed)
		{
			AudioManager.Sfx(SfxTableID.cicadaBuzzAttackScream, base.transform.position);
			screamDelayTimer.Stop();
		}
		if (thumpDelayTimer.isRunning && thumpDelayTimer.isTimerElapsed)
		{
			AudioManager.Sfx(SfxTableID.cicadaBuzzAttackThump, base.transform.position);
			thumpDelayTimer.Stop();
		}
	}
}
