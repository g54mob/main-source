using UnityEngine;

public class BreedingTravelButton : MonoBehaviour
{
	private SceneManagerBase sceneRef;

	private void Start()
	{
		sceneRef = ObjectRegistration.GetRegistrationScript().GetGlobalComponent<SceneManagerBase>(GlobalObject.SCENE_MANAGER);
		if (sceneRef.GetGameMode() != GameMode.HOME)
		{
			base.gameObject.SetActive(value: false);
		}
	}

	public void OnClick()
	{
	}
}
