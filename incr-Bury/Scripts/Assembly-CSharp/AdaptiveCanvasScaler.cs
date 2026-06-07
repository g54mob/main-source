using UnityEngine;
using UnityEngine.UI;

public class AdaptiveCanvasScaler : MonoBehaviour
{
	public CanvasScaler scaler;

	[Tooltip("Aspect ratio below which we stop forcing width")]
	public float tallAspectThreshold = 1.7f;

	private void Awake()
	{
		ApplyScaling();
	}

	private void FixedUpdate()
	{
		ApplyScaling();
	}

	private void ApplyScaling()
	{
		if ((bool)OptionsManager.Singleton)
		{
			if (OptionsManager.Singleton.forceUIScale_Setting == 1)
			{
				if (scaler.screenMatchMode != CanvasScaler.ScreenMatchMode.Expand)
				{
					Debug.Log("Changing UI scaling mode to Expand.");
					scaler.screenMatchMode = CanvasScaler.ScreenMatchMode.Expand;
				}
				return;
			}
			if (scaler.screenMatchMode != CanvasScaler.ScreenMatchMode.MatchWidthOrHeight)
			{
				Debug.Log("Changing UI scaling mode to Match Width Or Height.");
				scaler.screenMatchMode = CanvasScaler.ScreenMatchMode.MatchWidthOrHeight;
			}
		}
		if ((float)Screen.width / (float)Screen.height < tallAspectThreshold)
		{
			scaler.matchWidthOrHeight = 0f;
		}
		else
		{
			scaler.matchWidthOrHeight = 1f;
		}
	}
}
