using UnityEngine;

public class PauseMenuStageIndicator : MonoBehaviour
{
	public PugText[] pugTexts;

	private void OnEnable()
	{
		string text = (Manager.sceneHandler.isInGame ? Manager.sceneHandler.gameObject.scene.name : "paused");
		PugText[] array = pugTexts;
		for (int i = 0; i < array.Length; i++)
		{
			array[i].SetText(text);
		}
	}
}
