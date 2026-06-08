using UnityEngine;

public class TutorialSpawner : MonoBehaviour
{
	[SerializeField]
	private CoroutineRunner runner;

	[SerializeField]
	private AssistantController assistant;

	public void SpawnAssistant()
	{
		if (LevelManager.GetCurrLevel() == 0 && !Save.IsIconClicked("0Messages"))
		{
			Save.SaveIconClick("0Messages");
			if (!assistant.gameObject.activeSelf)
			{
				runner.StartCoroutine(assistant.Spawn(0.5f));
			}
		}
	}
}
