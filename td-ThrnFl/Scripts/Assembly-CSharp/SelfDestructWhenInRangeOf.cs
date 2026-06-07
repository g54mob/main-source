using UnityEngine;

public class SelfDestructWhenInRangeOf : MonoBehaviour
{
	[SerializeField]
	private TargetPriority selfDestructIfInRangeOf;

	[SerializeField]
	private float checkInterval = 0.5f;

	private float timeTillNextCheck;

	private Hp hp;

	private void Start()
	{
		hp = GetComponent<Hp>();
		timeTillNextCheck = checkInterval;
	}

	private void Update()
	{
		timeTillNextCheck -= Time.deltaTime;
		if (timeTillNextCheck <= 0f)
		{
			timeTillNextCheck = checkInterval;
			if (selfDestructIfInRangeOf.FindClosestTaggedObject(base.transform.position) != null && (bool)hp)
			{
				hp.TakeDamage(1E+09f);
			}
		}
	}
}
