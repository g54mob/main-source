using UnityEngine;
using UnityEngine.AI;

public class nm : MonoBehaviour
{
	public Transform wp;

	private void Start()
	{
		base.gameObject.GetComponent<NavMeshAgent>().SetDestination(wp.position);
	}

	private void Update()
	{
		if (Vector3.Distance(wp.position, base.transform.position) < 0.5f)
		{
			base.gameObject.GetComponent<Animator>().SetBool("walk", value: false);
			base.gameObject.GetComponent<AudioSource>().Stop();
			base.gameObject.GetComponent<nm>().enabled = false;
		}
	}
}
