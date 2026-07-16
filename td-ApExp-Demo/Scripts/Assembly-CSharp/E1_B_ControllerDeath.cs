using UnityEngine;

public class E1_B_ControllerDeath : StateBase
{
	private CentipedeController controller;

	private float deathExplosionTimer;

	private int deathExplosionIndex;

	private float timeBetweenDeathExplosions = 0.25f;

	private bool stopUpdate;

	private float deathXOffset;

	private float slowdownModifier = 1f;

	public override string Key => "Death";

	public E1_B_ControllerDeath(StateMachine sm, CentipedeController controller)
		: base(sm)
	{
		transitionStates = new string[0];
		this.controller = controller;
	}

	public E1_B_ControllerDeath(StateMachine sm, string[] transitionStates, CentipedeController controller)
		: base(sm, transitionStates)
	{
		this.controller = controller;
	}

	public override bool CanEnter()
	{
		return false;
	}

	public override void EnterState()
	{
		deathExplosionIndex = controller.segments.Length - 1;
		deathXOffset = -3f - (float)Train.Instance.Wagons.Count;
	}

	public override void UpdateState()
	{
		if (stopUpdate)
		{
			return;
		}
		deathExplosionTimer -= Time.deltaTime;
		controller.xOffset -= Time.deltaTime * slowdownModifier * Train.Instance.TrainSpeedNormalized;
		if (deathExplosionTimer <= 0f)
		{
			if (deathExplosionIndex > 0)
			{
				CentipedeSegment centipedeSegment = controller.segments[deathExplosionIndex];
				controller.segments[deathExplosionIndex] = null;
				Object.Instantiate(controller.explosionPrefab, centipedeSegment.gameObject.transform.position, Quaternion.identity).GetComponent<Explosion>().Initialize(null, 0.25f, 0f);
				centipedeSegment.Explode();
				slowdownModifier -= 0.1f;
				deathExplosionIndex--;
				CameraController.Instance.Shake(0.2f, 0.4f);
			}
			else if (deathExplosionIndex == 0)
			{
				Object.Instantiate(controller.explosionPrefab, controller.eyeAnim.transform.position, Quaternion.identity).GetComponent<Explosion>().Initialize(null, 0.125f, 0f);
				controller.eyeAnim.Play("Dead", 0, 0f);
				deathExplosionIndex--;
				CameraController.Instance.Shake(0.2f, 0.4f);
			}
			else if (deathExplosionIndex < 0)
			{
				Object.Instantiate(controller.explosionPrefab, controller.eyeAnim.transform.position, Quaternion.identity).GetComponent<Explosion>().Initialize(null, 0.5f, 0f);
				CameraController.Instance.Shake(0.2f, 0.6f);
				controller.segments[0].Explode();
				controller.IsFullyDead = true;
				EnemyManager.Instance.OnCentipedeDestroyed();
				stopUpdate = true;
				LevelManager.Instance.HandleBossBeaten(controller.coresToDrop);
				controller.DestroySelf();
			}
			deathExplosionTimer = timeBetweenDeathExplosions;
			if (deathExplosionIndex < 0)
			{
				deathExplosionTimer = 2f;
			}
		}
	}

	public override void ExitState()
	{
	}

	public override bool CanExit()
	{
		return false;
	}
}
