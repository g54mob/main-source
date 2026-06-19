using Pug.UnityExtensions;
using UnityEngine;

public class RoofingToolEffect : PoolableSimple
{
	private TimerSimple _timer;

	public ParticleSystem openRoofHoleEffect;

	public ParticleSystem closeRoofHoleEffect;

	public static void SpawnRoofingToolEffect(Vector3 renderPosition, bool openRoofHole)
	{
		RoofingToolEffect freeComponent = Manager.memory.GetFreeComponent<RoofingToolEffect>(deferOnOccupied: true);
		if (freeComponent != null)
		{
			freeComponent.transform.position = renderPosition;
			if (openRoofHole)
			{
				freeComponent.openRoofHoleEffect.Play();
			}
			else
			{
				freeComponent.closeRoofHoleEffect.Play();
			}
			freeComponent._timer.Start(4f);
		}
	}

	private void Update()
	{
		if (!_timer.isRunning || _timer.isTimerElapsed)
		{
			Free();
		}
	}
}
