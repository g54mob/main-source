using Pug.UnityExtensions;

public class PetElectric : PetBase
{
	private TimerSimple anticipaitonTimer = new TimerSimple(0.2f);

	private TimerSimple attackTimer = new TimerSimple(0.3f);

	public ManagedLight lightSource;

	private bool jumping;

	protected override bool updateAnimOrientation => true;

	public override void OnOccupied()
	{
		base.OnOccupied();
		lightSource.gameObject.SetActive(value: true);
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
		jumping = animID == 1203776827;
	}
}
