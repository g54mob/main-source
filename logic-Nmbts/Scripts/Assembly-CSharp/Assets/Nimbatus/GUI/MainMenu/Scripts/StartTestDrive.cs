using Assets.Nimbatus.Scripts.Common.LevelTransition;
using Assets.Nimbatus.Scripts.WorldObjects.Items.Dragging;
using UnityEngine;

namespace Assets.Nimbatus.GUI.MainMenu.Scripts
{
	public class StartTestDrive : MonoBehaviour
	{
		public string SceneName = "TestAreaScene";

		public void OnClick()
		{
			if (!(DragAndDropHelper.DraggedItem != null))
			{
				NimbatusSceneManager.LoadScene(SceneName);
			}
		}
	}
}
