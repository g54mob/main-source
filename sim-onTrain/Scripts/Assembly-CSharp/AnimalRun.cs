using UnityEngine;

public class AnimalRun : MonoBehaviour
{
	public float moveSpeed;

	private Rigidbody rb;

	[SerializeField]
	private bool move;

	private void Start()
	{
		rb = GetComponent<Rigidbody>();
	}

	private void Update()
	{
		if (move)
		{
			MoveForward();
		}
	}

	private void MoveForward()
	{
		rb.velocity = base.transform.forward * moveSpeed * Time.deltaTime;
	}
}
