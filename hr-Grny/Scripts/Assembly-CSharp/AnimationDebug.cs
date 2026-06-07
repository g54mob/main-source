using System;
using UnityEngine;

[Serializable]
[RequireComponent(typeof(AnimationController))]
public class AnimationDebug : MonoBehaviour
{
	private AnimationController animationController;

	private CharacterController character;

	public virtual void Start()
	{
	}

	public virtual void OnGUI()
	{
	}
}
