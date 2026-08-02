using UnityEngine;

public class AnimationStarter : MonoBehaviour
{
	[SerializeField]
	private KeyCode key;

	private Animator animator;

	public string animName = "";

	private void Start()
	{
		animator = GetComponent<Animator>();
	}

	private void Update()
	{
		if (Input.GetKeyDown(key))
		{
			animator.SetTrigger(animName);
		}
	}
}
