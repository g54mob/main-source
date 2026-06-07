using System;
using System.Collections.Generic;
using RainbowArt.CleanFlatUI;
using UnityEngine;

public class BoilingDoneChecker : MonoBehaviour
{
	private List<Buoyancy> cookedFoodInBowl;

	public ProgressBarSpecialPattern boilingGage;

	private void OnTriggerEnter(Collider other)
	{
		Buoyancy componentInParent = other.GetComponentInParent<Buoyancy>();
		if ((bool)componentInParent && componentInParent.cooked)
		{
			cookedFoodInBowl.Add(componentInParent);
		}
		float num = 0f;
		foreach (Buoyancy item in cookedFoodInBowl)
		{
			num = ((item.numOfIngred != 1) ? ((item.numOfIngred != 2) ? (num + 33.3f) : (num + 50f)) : 100f);
		}
		boilingGage.CurrentValue = num;
	}

	private void OnTriggerExit(Collider other)
	{
		Buoyancy componentInParent = other.GetComponentInParent<Buoyancy>();
		if ((bool)componentInParent && componentInParent.cooked)
		{
			cookedFoodInBowl.Remove(componentInParent);
		}
		float num = 0f;
		foreach (Buoyancy item in cookedFoodInBowl)
		{
			num = ((item.numOfIngred != 1) ? ((item.numOfIngred != 2) ? (num + 33.3f) : (num + 50f)) : 100f);
		}
		boilingGage.CurrentValue = num;
	}

	private void Start()
	{
		cookedFoodInBowl = new List<Buoyancy>();
		GameManager.S.OnBoilCookingDone += Gm_OnBoilCookingDone;
	}

	private void Gm_OnBoilCookingDone(object sender, EventArgs e)
	{
		cookedFoodInBowl.Clear();
	}

	private void Update()
	{
	}
}
