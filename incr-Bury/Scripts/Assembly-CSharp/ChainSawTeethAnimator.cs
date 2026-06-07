using System;
using UnityEngine;

public class ChainSawTeethAnimator : MonoBehaviour
{
	[SerializeField]
	private bool stopAtNight;

	[SerializeField]
	private GameObject[] teethChains;

	private bool animateTeeth = true;

	private int teethAnim_Index;

	[SerializeField]
	private float chainMoveSpeed;

	private float chainAnimTimer_Curr;

	private void Start()
	{
		if (stopAtNight)
		{
			GameManager singleton = GameManager.Singleton;
			singleton.OnNightTime_Action = (Action)Delegate.Combine(singleton.OnNightTime_Action, new Action(OnNightTime));
		}
	}

	private void OnDestroy()
	{
		if (stopAtNight)
		{
			GameManager singleton = GameManager.Singleton;
			singleton.OnNightTime_Action = (Action)Delegate.Remove(singleton.OnNightTime_Action, new Action(OnNightTime));
		}
	}

	private void Update()
	{
		HandleChainAnimation();
	}

	private void HandleChainAnimation()
	{
		if (animateTeeth)
		{
			if (chainAnimTimer_Curr > 0f)
			{
				chainAnimTimer_Curr -= Time.deltaTime;
				return;
			}
			chainAnimTimer_Curr = chainMoveSpeed;
			HideAllTeethChains();
			teethChains[teethAnim_Index].SetActive(value: true);
			teethAnim_Index = (teethAnim_Index + 1) % teethChains.Length;
		}
	}

	private void HideAllTeethChains()
	{
		GameObject[] array = teethChains;
		for (int i = 0; i < array.Length; i++)
		{
			array[i].SetActive(value: false);
		}
	}

	private void OnNightTime()
	{
		if (stopAtNight)
		{
			animateTeeth = false;
		}
	}
}
