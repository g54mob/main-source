using UnityEngine;

[RequireComponent(typeof(Animator))]
public class RandomAnimatorSpeed : MonoBehaviour
{
	[SerializeField]
	private float minSpeed;

	[SerializeField]
	private float maxSpeed;

	[SerializeField]
	private Animator animator;

	private void Awake()
	{
	}

	private void Reset()
	{
	}
}
