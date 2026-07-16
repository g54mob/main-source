using UnityEngine;

public class SimpleSkeletonController : MonoBehaviour
{
	private Animator animator;

	private SkinnedMeshRenderer skinnedMesh;

	private void Start()
	{
		animator = GetComponent<Animator>();
	}

	private void Update()
	{
		if (Input.GetKey(KeyCode.L))
		{
			animator.SetTrigger("lying");
		}
		else if (Input.GetKeyDown(KeyCode.Space))
		{
			animator.SetTrigger("jump");
		}
		else if (Input.GetKeyDown(KeyCode.K))
		{
			animator.SetTrigger("knockdown");
		}
		else if (Input.GetKeyDown(KeyCode.Mouse0))
		{
			animator.SetTrigger("punch_L");
		}
		else if (Input.GetKeyDown(KeyCode.Mouse1))
		{
			animator.SetTrigger("punch_R");
		}
		animator.SetFloat("Vertical", Input.GetAxis("Vertical"));
		animator.SetFloat("Horizontal", Input.GetAxis("Horizontal"));
		if (Input.GetKey(KeyCode.LeftShift))
		{
			animator.SetBool("running", value: true);
		}
		else
		{
			animator.SetBool("running", value: false);
		}
		if (Input.GetKey(KeyCode.LeftControl))
		{
			animator.SetBool("sidefix", value: true);
		}
		else
		{
			animator.SetBool("sidefix", value: false);
		}
	}
}
