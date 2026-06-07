using UnityEngine;

public class Crosshair : MonoBehaviour
{
	[Header("Crosshair Type")]
	public GameObject currentCrosshairObject;

	public CrosshairType currentCrosshair;

	public CanvasGroup crosshairList;

	[Header("Crosshair Objects")]
	public GameObject pointCrosshair;

	public GameObject plusCrosshair;

	public GameObject circleCrosshair;

	public GameObject hitmarker;

	public void SetCrosshairType(CrosshairType newType)
	{
		if (currentCrosshair != newType)
		{
			currentCrosshair = newType;
			UpdateCrosshair();
		}
	}

	public void OnFire()
	{
		if (currentCrosshairObject != null)
		{
			Animator component = currentCrosshairObject.GetComponent<Animator>();
			if (component != null)
			{
				component.SetTrigger("Fire");
			}
		}
	}

	public void OnHitmarker()
	{
		Animator component = hitmarker.GetComponent<Animator>();
		if (component != null)
		{
			component.SetTrigger("Hitmarker");
		}
	}

	public void ShowCrosshair()
	{
		crosshairList.alpha = 1f;
	}

	public void HideCrosshair()
	{
		crosshairList.alpha = 0f;
	}

	private void UpdateCrosshair()
	{
		if (pointCrosshair != null)
		{
			pointCrosshair.SetActive(value: false);
		}
		if (plusCrosshair != null)
		{
			plusCrosshair.SetActive(value: false);
		}
		if (circleCrosshair != null)
		{
			circleCrosshair.SetActive(value: false);
		}
		switch (currentCrosshair)
		{
		case CrosshairType.Point:
			currentCrosshairObject = pointCrosshair;
			break;
		case CrosshairType.Plus:
			currentCrosshairObject = plusCrosshair;
			break;
		case CrosshairType.Circle:
			currentCrosshairObject = circleCrosshair;
			break;
		}
		if (currentCrosshairObject != null)
		{
			currentCrosshairObject.SetActive(value: true);
		}
	}

	private void OnEnable()
	{
		UpdateCrosshair();
	}
}
