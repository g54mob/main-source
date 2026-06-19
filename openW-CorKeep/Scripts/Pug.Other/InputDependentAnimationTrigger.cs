using System;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class InputDependentAnimationTrigger : MonoBehaviour
{
	[Serializable]
	public class InputDependentTriggerSettings : InputDependentSettings<string>
	{
	}

	public InputDependentTriggerSettings triggers;

	private Animator animator;

	private string previousTrigger;

	private void Start()
	{
		string bestSettings = triggers.GetBestSettings();
		animator = GetComponent<Animator>();
		if (bestSettings != null)
		{
			animator.SetTrigger(bestSettings);
		}
		previousTrigger = bestSettings;
	}

	private void Update()
	{
		string bestSettings = triggers.GetBestSettings();
		if (bestSettings != null && bestSettings != previousTrigger)
		{
			animator.SetTrigger(bestSettings);
			previousTrigger = bestSettings;
		}
	}
}
