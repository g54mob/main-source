using UnityEngine;

public class DogPoop : MonoBehaviour
{
	public GameObject actionParticles;

	private string objectDestroySound = "object_destroy";

	private float currentTimer;

	private float autoCleanupTimer = 10f;

	private float autoCleanupJiggle = 5f;

	private void Awake()
	{
		currentTimer = Random.Range(0f - autoCleanupJiggle, 0f);
	}

	private void Update()
	{
		if (GameSettings.IsPassiveModeEnabled() && GameSettings.PassiveModeAutoCleanPoop())
		{
			currentTimer += Time.deltaTime;
			if (currentTimer >= autoCleanupTimer)
			{
				Vector3 objCenter = ObjectUtil.GetObjCenter(base.gameObject);
				Object.Instantiate(actionParticles, objCenter, Quaternion.identity);
				AudioController.Play(objectDestroySound, objCenter);
				CleanUp();
			}
		}
	}

	public void CleanUp()
	{
		GoalsController.ReportGoalEvent(GoalCondition.CLEAN_POOP);
		Object.Destroy(base.gameObject);
	}
}
