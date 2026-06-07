using UnityEngine;

namespace Assets.Nimbatus.GUI.DroneWorkshop.Scripts
{
	public class ResetTestDriveScene : MonoBehaviour
	{
		public void OnClick()
		{
			LoadTestDriveScene.LatestScene = "TestAreaScene";
		}
	}
}
