using UnityEngine;
using UnityEngine.Events;

public class PlayerEnterTrigger : MonoBehaviour
{
	public UnityEvent OnUse;

	[SerializeField]
	private bool oneTimeUse;

	private bool hasUsed;

	private void Start()
	{
	}

	private void Update()
	{
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Player") && (!oneTimeUse || !hasUsed))
		{
			OnUse?.Invoke();
			hasUsed = true;
		}
	}
}
