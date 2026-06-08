using UnityEngine;
using UnityEngine.Rendering.Universal;

public class PostProcessingEnabler : MonoBehaviour
{
	[SerializeField]
	private SettingsRouter settingsRouter;

	private UniversalAdditionalCameraData cameraData;

	private void Awake()
	{
		cameraData = GetComponent<UniversalAdditionalCameraData>();
	}

	private void Start()
	{
		EnablePostProcessing(settingsRouter.PostProcessingEnabled);
		settingsRouter.OnPostProcessingEnabled += EnablePostProcessing;
	}

	private void EnablePostProcessing(bool newEnabled)
	{
		cameraData.renderPostProcessing = newEnabled;
		OverwritingSingleton<IngameUi>.Instance.UpdateCameraVolumeStack();
	}

	private void OnDestroy()
	{
		settingsRouter.OnPostProcessingEnabled -= EnablePostProcessing;
	}
}
