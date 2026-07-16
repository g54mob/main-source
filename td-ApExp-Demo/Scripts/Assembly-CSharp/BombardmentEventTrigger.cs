using UnityEngine;

public class BombardmentEventTrigger : MonoBehaviour
{
	protected bool isTrainHit;

	protected void Start()
	{
		isTrainHit = false;
		GameManager.Instance.ringMinigame.OnTriggersReset += delegate
		{
			isTrainHit = false;
		};
	}

	protected void OnTriggerEnter2D(Collider2D other)
	{
		if (isTrainHit)
		{
			return;
		}
		Transform parent = other.transform.parent;
		if ((object)parent != null)
		{
			Transform parent2 = parent.parent;
			if ((object)parent2 != null && parent2.TryGetComponent<Wagon>(out var _))
			{
				OnTrigger();
			}
		}
	}

	protected virtual void OnTrigger()
	{
		isTrainHit = true;
	}
}
