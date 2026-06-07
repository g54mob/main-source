using UnityEngine;

public class FactoryObjectAnimator : MonoBehaviour
{
	[SerializeField]
	private Animator _animator;

	private static readonly int PassResource = Animator.StringToHash("PassResource");

	private void Reset()
	{
		_animator = GetComponentInChildren<Animator>();
	}

	public void PlayActivityStart()
	{
		_animator.SetTrigger(PassResource);
	}
}
