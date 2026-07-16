using UnityEngine;

public class DialogAnimationProperty
{
	public Animator animator;

	public string stateName;

	public bool value;

	public DialogAnimationProperty(Animator animator, string stateName, bool value)
	{
		this.animator = animator;
		this.stateName = stateName;
		this.value = value;
	}
}
