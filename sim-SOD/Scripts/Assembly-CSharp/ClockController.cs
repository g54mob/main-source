using NaughtyAttributes;
using UnityEngine;

public class ClockController : MonoBehaviour
{
	public InteractableController ic;

	public Transform hourHand;

	public Transform minuteHand;

	public Animator hourlyAnimation;

	[ReadOnly]
	public float animateTimer;

	private void Start()
	{
	}

	private void OnDestroy()
	{
	}

	public void OnHourChange()
	{
	}

	private void Update()
	{
	}
}
