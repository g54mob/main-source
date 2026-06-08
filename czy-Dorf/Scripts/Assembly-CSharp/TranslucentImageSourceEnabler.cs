using LeTai.Asset.TranslucentImage;
using UnityEngine;

[RequireComponent(typeof(TranslucentImageSource))]
public class TranslucentImageSourceEnabler : MonoBehaviour
{
	[SerializeField]
	private SettingsRouter settingsRouter;

	private TranslucentImageSource translucentImageSource;

	private void Awake()
	{
		translucentImageSource = GetComponent<TranslucentImageSource>();
	}

	private void Start()
	{
		settingsRouter.OnQualityLevelChanged += ChangeMaxUpdateRate;
		ChangeMaxUpdateRate(settingsRouter.QualityLevel);
		settingsRouter.OnTranslucentUiEnabled += EnableTranslucentUi;
		EnableTranslucentUi(settingsRouter.TranslucentUiEnabled);
	}

	private void ChangeMaxUpdateRate(int targetQualityLevel)
	{
		translucentImageSource.maxUpdateRate = targetQualityLevel switch
		{
			1 => 60, 
			0 => 1000, 
			_ => 30, 
		};
	}

	private void EnableTranslucentUi(bool newEnabled)
	{
		translucentImageSource.enabled = newEnabled;
	}

	private void OnDestroy()
	{
		settingsRouter.OnQualityLevelChanged -= ChangeMaxUpdateRate;
		settingsRouter.OnTranslucentUiEnabled -= EnableTranslucentUi;
	}
}
