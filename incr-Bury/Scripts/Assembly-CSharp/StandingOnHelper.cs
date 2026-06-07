using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandingOnHelper : MonoBehaviour
{
	[SerializeField]
	private PlayerMovement playerMovement;

	private Rigidbody rb;

	private List<Collider> recentCols = new List<Collider>();

	private void Awake()
	{
		rb = GetComponentInParent<Rigidbody>();
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag("Trampoline") && other.isTrigger && !recentCols.Contains(other))
		{
			other.gameObject.transform.root.gameObject.GetComponentInChildren<TrampolineTrigger>().PlayBounceFeedbacks();
			playerMovement.SteppedOnTrampoline();
			StartCoroutine(AddWaitThenRemoveFromRecentCols(other));
		}
	}

	private IEnumerator AddWaitThenRemoveFromRecentCols(Collider _other)
	{
		recentCols.Add(_other);
		yield return new WaitForSeconds(0.25f);
		recentCols.Remove(_other);
	}
}
