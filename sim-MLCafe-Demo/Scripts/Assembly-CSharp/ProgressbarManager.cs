using System.Collections;
using UnityEngine;

public class ProgressbarManager : MonoBehaviour
{
	[SerializeField]
	private ProgressBarComponent progressBarCleaning;

	[SerializeField]
	private ProgressBarComponent progressBarDefault;

	[SerializeField]
	private ProgressBarComponent progressBarHeat;

	[SerializeField]
	private ProgressBarComponent progressBarWaterFill;

	private static ProgressbarManager instance;

	public void Awake()
	{
		if (instance == null)
		{
			instance = this;
		}
		else
		{
			Object.Destroy(this);
		}
		Object.DontDestroyOnLoad(instance);
		HideForce();
	}

	private void Start()
	{
		StartCoroutine(ForceHideDelay());
	}

	private IEnumerator ForceHideDelay()
	{
		yield return new WaitForSeconds(0.05f);
		HideForce();
	}

	private void HideForce()
	{
		if (progressBarCleaning != null)
		{
			GetCleaningProgressBar().HideForce();
		}
		if (progressBarDefault != null)
		{
			GetDefaultProgressBar().HideForce();
		}
		if (progressBarHeat != null)
		{
			GetHeatProgressBar().HideForce();
		}
		if (progressBarWaterFill != null)
		{
			GetWaterFillProgressBar().HideForce();
		}
	}

	public static void HideAll()
	{
		if (instance.progressBarCleaning != null && GetCleaningProgressBar().IsVisible())
		{
			GetCleaningProgressBar().HideProgressbar();
		}
		if (instance.progressBarDefault != null && GetDefaultProgressBar().IsVisible())
		{
			GetDefaultProgressBar().HideProgressbar();
		}
		if (instance.progressBarHeat != null && GetHeatProgressBar().IsVisible())
		{
			GetHeatProgressBar().HideProgressbar();
		}
		if (instance.progressBarWaterFill != null && GetWaterFillProgressBar().IsVisible())
		{
			GetWaterFillProgressBar().HideProgressbar();
		}
	}

	public static ProgressBarComponent GetCleaningProgressBar()
	{
		return instance.progressBarCleaning;
	}

	public static ProgressBarComponent GetDefaultProgressBar()
	{
		return instance.progressBarDefault;
	}

	public static ProgressBarComponent GetHeatProgressBar()
	{
		return instance.progressBarHeat;
	}

	public static ProgressBarComponent GetWaterFillProgressBar()
	{
		return instance.progressBarWaterFill;
	}
}
