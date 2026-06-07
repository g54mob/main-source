using UnityEngine;

public class HandAnimationController : MonoBehaviour
{
	private Animator animator;

	private void Awake()
	{
		animator = GetComponent<Animator>();
	}

	private void Start()
	{
		if (base.gameObject.transform.childCount > 0)
		{
			FirstPersonController.S.itemOnHand = base.gameObject.transform.GetChild(0).gameObject;
		}
	}

	private void Update()
	{
		animator.SetBool("Eating", GameManager.S.player.isEating);
	}
}
