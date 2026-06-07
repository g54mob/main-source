using Assets.Nimbatus.Scripts.Common.LevelTransition;
using Assets.Nimbatus.Scripts.WorldObjects.Items.Dragging;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Assets.Nimbatus.GUI.DroneWorkshop.Scripts
{
	public class LoadTestDriveScene : MonoBehaviour
	{
		public static string LatestScene;

		public bool LoadLatest;

		[HideIf("LoadLatest", true)]
		public string SceneName;

		public void OnClick()
		{
			if (DragAndDropHelper.DraggedItem != null)
			{
				return;
			}
			if (LoadLatest)
			{
				if (string.IsNullOrEmpty(LatestScene))
				{
					LatestScene = "TestAreaScene";
				}
				NimbatusSceneManager.LoadScene(LatestScene);
			}
			else
			{
				NimbatusSceneManager.LoadScene(SceneName);
				LatestScene = SceneName;
			}
		}
	}
}
