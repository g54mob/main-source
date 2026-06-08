using UnityEngine;

public class InputSystemConfigurator : MonoBehaviour
{
	[SerializeField]
	private SettingsRouter settingsRouter;

	[SerializeField]
	private MonoBehaviour placingTilesWithClick;

	private void Start()
	{
		settingsRouter.OnPlaceTileWithClickChanged += EnablePlacingTilesWithClick;
		EnablePlacingTilesWithClick(settingsRouter.PlacingTilesWithClick);
	}

	private void EnablePlacingTilesWithClick(bool shouldEnablePlacingTilesWithClick)
	{
		placingTilesWithClick.enabled = shouldEnablePlacingTilesWithClick;
	}
}
