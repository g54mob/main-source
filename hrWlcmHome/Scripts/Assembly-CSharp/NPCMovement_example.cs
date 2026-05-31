using UnityEngine;

public class NPCMovement_example : MonoBehaviour
{
	[SerializeField]
	public bool IsIdle = true;

	[SerializeField]
	private Animator animator;

	[SerializeField]
	private Transform destination;

	[SerializeField]
	private float speed;

	private void Start()
	{
	}

	private void Update()
	{
		animator.SetBool("IsIdle", IsIdle);
		if (!IsIdle)
		{
			base.transform.LookAt(new Vector3(destination.position.x, 0f, destination.position.z));
			Vector3 b = new Vector3(destination.position.x, base.transform.position.y, destination.position.z);
			base.transform.position = Vector3.Lerp(base.transform.position, b, speed * Time.deltaTime);
		}
	}
}
