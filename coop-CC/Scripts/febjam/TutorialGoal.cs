using Aggro.Core;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;

public class TutorialGoal : EntityBehaviourBase
{
	private static readonly int Show1 = Animator.StringToHash("show");

	public GameObject container;

	public GameObject checkedContainer;

	[Space]
	public Image timer;

	public Animator animator;

	protected override void OnEntityCreated()
	{
		container.SetActive(value: false);
		timer.fillAmount = 0f;
	}

	public void Show()
	{
		container.SetActive(value: true);
		animator.SetBool(Show1, value: true);
	}

	public void Hide()
	{
		animator.SetBool(Show1, value: false);
	}

	public void Checked()
	{
		timer.fillAmount = 1f;
	}

	public void SetTimer(float normalizedValue)
	{
		timer.fillAmount = math.saturate(normalizedValue);
	}
}
