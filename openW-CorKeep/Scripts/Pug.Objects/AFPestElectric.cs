using Pug.UnityExtensions;

public class AFPestElectric : EntityMonoBehaviour
{
	private TimerSimple anticipaitonTimer = new TimerSimple(0.5f);

	private TimerSimple attackTimer = new TimerSimple(0.3f);

	public ManagedLight lightSource;

	private bool jumping;

	protected override bool updateAnimOrientation => true;

	public override void OnOccupied()
	{
		base.OnOccupied();
		if (currentHealth > 0)
		{
			lightSource.gameObject.SetActive(value: true);
		}
	}

	public override void ManagedLateUpdate()
	{
		base.ManagedLateUpdate();
		if (!jumping)
		{
			anticipaitonTimer.Stop();
			attackTimer.Stop();
		}
		else
		{
			if (!anticipaitonTimer.isRunning)
			{
				anticipaitonTimer.Start();
			}
			if (anticipaitonTimer.isTimerElapsed && !attackTimer.isRunning)
			{
				attackTimer.Start();
			}
		}
		lightSource.gameObject.SetActive(attackTimer.isRunning && !attackTimer.isTimerElapsed);
	}

	protected override void HandleAnimationTrigger(int animID)
	{
		base.HandleAnimationTrigger(animID);
		if (animID == -414722770)
		{
			Manager.effects.PlayPuff(PuffID.MediumGreenPuff, base.transform.position, 40);
			if (hasShadow)
			{
				shadow.SetActive(value: false);
			}
		}
		jumping = animID == -1481439722;
	}

	protected override void OnDeath()
	{
		base.OnDeath();
		lightSource.gameObject.SetActive(value: false);
		SpawnFadeOutLight(lightSource.lightToOptimize);
	}
}
