using UnityEngine;

public class SonnetShop : MonoBehaviour
{
	public Animator sonnetAnim;

	[SerializeField]
	private bool crossoverOverride;

	private float timer;

	private bool isCleaning;

	private void Start()
	{
		timer = 5f;
	}

	private void Update()
	{
		if (timer > 0f)
		{
			timer -= Time.deltaTime;
		}
		else if (crossoverOverride)
		{
			SwapCrossoverAction();
		}
		else
		{
			PickRandomAction();
		}
	}

	private void PickRandomAction()
	{
		timer = Random.Range(2.5f, 5f);
		if (isCleaning)
		{
			sonnetAnim.SetTrigger("idle");
			isCleaning = false;
		}
		else if (Random.value > 0.5f)
		{
			sonnetAnim.SetTrigger("clean");
			isCleaning = true;
		}
		else
		{
			sonnetAnim.SetTrigger("blink");
		}
	}

	private void SwapCrossoverAction()
	{
		timer = Random.Range(2.5f, 7.5f);
		isCleaning = !isCleaning;
		if (isCleaning)
		{
			sonnetAnim.SetTrigger("B");
		}
		else
		{
			sonnetAnim.SetTrigger("A");
		}
	}
}
