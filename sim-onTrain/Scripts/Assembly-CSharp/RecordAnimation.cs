using UnityEngine;

public class RecordAnimation : MonoBehaviour
{
	[SerializeField]
	private KeyCode key;

	private Animator animator;

	private Animation anim;

	public bool isAnim;

	private void Start()
	{
		if (isAnim)
		{
			anim = GetComponent<Animation>();
			anim.enabled = false;
		}
		else
		{
			animator = GetComponent<Animator>();
			animator.speed = 0f;
		}
	}

	private void Update()
	{
		if (!Input.GetKeyDown(key))
		{
			return;
		}
		if (isAnim)
		{
			if (anim.isActiveAndEnabled)
			{
				anim.enabled = false;
			}
			else
			{
				anim.enabled = true;
			}
		}
		else if (animator.speed == 0f)
		{
			animator.speed = 1f;
		}
		else
		{
			animator.speed = 0f;
		}
	}
}
