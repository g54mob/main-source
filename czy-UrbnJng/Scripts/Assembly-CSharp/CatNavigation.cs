using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CatNavigation : MonoBehaviour
{
	[SerializeField]
	private List<Transform> destinations;

	private Animator animator;

	private NavMeshAgent agent;

	private Transform currentDestination;

	private bool atDestination;

	private void Start()
	{
		agent = GetComponent<NavMeshAgent>();
		animator = GetComponent<Animator>();
		currentDestination = destinations[0];
		animator.SetBool("move", value: true);
		agent.SetDestination(currentDestination.position);
	}

	private void Update()
	{
		Debug.Log(currentDestination);
		if (!atDestination && Vector3.Distance(base.transform.position, currentDestination.position) < 2f)
		{
			atDestination = true;
			animator.SetBool("move", value: false);
			StartCoroutine(WaitBeforeChange());
		}
	}

	private IEnumerator WaitBeforeChange()
	{
		yield return new WaitForSeconds(3f);
		ChangeDestination();
	}

	private void ChangeDestination()
	{
		Transform transform = currentDestination;
		do
		{
			currentDestination = destinations[Random.Range(0, destinations.Count)];
		}
		while (transform == currentDestination);
		agent.SetDestination(currentDestination.position);
		animator.SetBool("move", value: true);
		atDestination = false;
	}
}
