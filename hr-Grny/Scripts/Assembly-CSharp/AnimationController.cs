using System;
using UnityEngine;

[Serializable]
public class AnimationController : MonoBehaviour
{
	public Animation animationTarget;

	public float maxForwardSpeed;

	public float maxBackwardSpeed;

	public float maxSidestepSpeed;

	private CharacterController character;

	private Transform thisTransform;

	private bool jumping;

	private int minUpwardSpeed;

	public virtual void Start()
	{
	}

	public virtual void OnEndGame()
	{
	}

	public virtual void Update()
	{
	}
}
