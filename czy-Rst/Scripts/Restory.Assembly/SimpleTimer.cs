using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class SimpleTimer : MonoBehaviour
{
	[Header("General settings")]
	[SerializeField]
	private bool activateOnStart = true;

	[SerializeField]
	private float delay;

	[SerializeField]
	private float countdown = 2.5f;

	[Header("Events")]
	public UnityEvent OnBegin = new UnityEvent();

	public UnityEvent OnComplete = new UnityEvent();

	private Coroutine mainCoroutine;

	private void Start()
	{
		if (activateOnStart)
		{
			StartCountdown();
		}
	}

	public void StartCountdown()
	{
		StopCountdown();
		mainCoroutine = StartCoroutine(CountdownRoutine());
	}

	public void StopCountdown()
	{
		if (mainCoroutine != null)
		{
			StopCoroutine(mainCoroutine);
			mainCoroutine = null;
		}
	}

	private IEnumerator CountdownRoutine()
	{
		yield return new WaitForSeconds(delay);
		OnBegin.Invoke();
		yield return new WaitForSeconds(countdown);
		OnComplete.Invoke();
	}
}
