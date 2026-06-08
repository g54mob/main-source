using UnityEngine;

public class TileStackCounterPositioner : MonoBehaviour
{
	[SerializeField]
	private float currentAspectRatio;

	[SerializeField]
	private Vector2 aspectRatioRange;

	[SerializeField]
	private Vector2 xPosRange;

	[SerializeField]
	private SettingsRouter settingsRouter;

	private void Start()
	{
		UpdateCounterPos(settingsRouter.CurrentResolution);
		settingsRouter.OnResolutionChanged += UpdateCounterPos;
	}

	private void UpdateCounterPos(Resolution resolution)
	{
		currentAspectRatio = (float)resolution.width / (float)resolution.height;
		float t = Mathf.Clamp01(Mathf.InverseLerp(aspectRatioRange.x, aspectRatioRange.y, currentAspectRatio));
		base.transform.localPosition = new Vector3(Mathf.Lerp(xPosRange.x, xPosRange.y, t), base.transform.localPosition.y, base.transform.localPosition.z);
	}

	private void OnDestroy()
	{
		settingsRouter.OnResolutionChanged -= UpdateCounterPos;
	}
}
